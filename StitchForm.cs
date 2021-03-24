using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpriteStitcher;
using System.IO;
using System.Drawing.Imaging;

namespace SpriteBitcher
{
    public partial class StitchForm : Form
    {
        private List<string> filePaths;

        private int swapIndexA = -1;
        private int swapIndexB = -1;

        private int sheetRows = 0;
        private int sheetCols = 0;
        private int frameWidth = 0;
        private int frameHeight = 0;

        public StitchForm()
        {
            InitializeComponent();

            filePaths = new List<string>();
            tbx_sheetRows.Text = "1";
            tbx_sheetCols.Text = "1";
            lbl_outputSizeVw.Text = "";
            lbl_frameSizeVw.Text = "";

            cbx_template.SelectedItem = "4x3 character style [VX MV MZ]";
        }

        public void UpdateSpritesheetResourcesUi()
        {

            if (filePaths.Count() != 0 && Int32.TryParse(tbx_sheetRows.Text, out sheetRows) && Int32.TryParse(tbx_sheetCols.Text, out sheetCols))
            {
                Image _img = Stitcher.StitchFromImgPaths(filePaths, sheetRows, sheetCols, out frameWidth, out frameHeight);

                pbx_stitchPreview.Image = _img;
                lbl_outputSizeVw.Text = _img.Width + " x " + _img.Height;
                lbl_frameSizeVw.Text = frameWidth + " x " + frameHeight;
            }
        }

        private void saveStitchFile()
        {
            DialogResult _result = sfd_stitchSaver.ShowDialog();
            if (_result == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(sfd_stitchSaver.FileName))
                {
                    file.WriteLine(cbx_template.Text);

                    // rows cols.
                    file.WriteLine(sheetRows.ToString() + "," + sheetCols.ToString());

                    foreach (string filePath in filePaths)
                    {
                        file.WriteLine(filePath);
                    }
                }

            }
        }

        private void loadStitchFile()
        {
            string tempTemplate = "";
            int tempRows = 0;
            int tempCols = 0;
            List<string> tempFilePaths = new List<string>();

            DialogResult _result = ofd_stitchLoader.ShowDialog();
            if (_result == System.Windows.Forms.DialogResult.OK)
            {
                using (System.IO.StreamReader file =
                new System.IO.StreamReader(ofd_stitchLoader.FileName))
                {
                    string line;

                    if ((line = file.ReadLine()) != null)
                    {
                        tempTemplate = line;
                    }

                    if ((line = file.ReadLine()) != null)
                    {
                        string[] rowcol = line.Split(',');
                        Int32.TryParse(rowcol[0], out tempRows);
                        Int32.TryParse(rowcol[1], out tempCols);
                    }

                    while ((line = file.ReadLine()) != null)
                    {
                        tempFilePaths.Add(locallyModifiedimgFile(line, ofd_stitchLoader.FileName));
                    }
                }

                if (tempTemplate != "" && tempRows > 0 && tempCols > 0 && tempFilePaths.Count > 0)
                {
                    cbx_template.SelectedItem = tempTemplate;

                    tbx_sheetRows.Text = tempRows.ToString();
                    tbx_sheetCols.Text = tempCols.ToString();
                    filePaths = tempFilePaths;
                }

                UpdateSpritesheetResourcesUi();
            }
        }

        private string locallyModifiedimgFile(string imgPath, string SSSpath)
        {
            string imageInWithSSS = Path.GetDirectoryName(SSSpath);
            imageInWithSSS += Path.DirectorySeparatorChar + Path.GetFileName(imgPath);

            if (File.Exists(imageInWithSSS))
            {
                return imageInWithSSS;
            }
            else
            {
                return imgPath;
            }
        }

        private void tbx_sheetRows_TextChanged(object sender, EventArgs e)
        {
            UpdateSpritesheetResourcesUi();
        }

        private void tbx_sheetCols_TextChanged(object sender, EventArgs e)
        {
            UpdateSpritesheetResourcesUi();
        }

        private void btn_addSprite_Click(object sender, EventArgs e)
        {
            DialogResult _result = ofd_spriteChooser.ShowDialog();
            if (_result == System.Windows.Forms.DialogResult.OK)
            {
                filePaths.Clear();

                foreach (string _file in ofd_spriteChooser.FileNames)
                {
                    filePaths.Add(_file);
                }

                UpdateSpritesheetResourcesUi();
            }
        }

        private void btn_saveOutput_Click(object sender, EventArgs e)
        {
            //TODO: Save output to new image file
            DialogResult _result = sfd_spritesheetSaver.ShowDialog();
            if (_result == System.Windows.Forms.DialogResult.OK)
            {
                string _extension = Path.GetExtension(sfd_spritesheetSaver.FileName);
                ImageFormat _format = ImageFormat.Png;

                switch (_extension.ToLower())
                {
                    case ".bmp":
                        _format = ImageFormat.Bmp;
                        break;
                    case ".jpg":
                        // ToDo: Save as JPEG
                        _format = ImageFormat.Jpeg;
                        break;
                    case ".jpeg":
                        // ToDo: Save as JPEG
                        _format = ImageFormat.Jpeg;
                        break;
                    case ".png":
                        _format = ImageFormat.Png;
                        break;
                    case ".gif":
                        _format = ImageFormat.Gif;
                        break;
                    case ".tif":
                        _format = ImageFormat.Tiff;
                        break;
                }

                // Save the newly-stitched spritesheet out to a file
                Image _img = Stitcher.StitchFromImgPaths(filePaths, Int32.Parse(tbx_sheetRows.Text), Int32.Parse(tbx_sheetCols.Text));
                _img.Save(sfd_spritesheetSaver.FileName, _format);
            }
        }

        private void btn_saveStitch_Click(object sender, EventArgs e)
        {
            saveStitchFile();
        }

        private void btn_loadStitch_Click(object sender, EventArgs e)
        {
            loadStitchFile();
        }

        private int getPictureIndexFromXY(int x, int y)
        {
            // check bounds so we don't crash

            int selectedFrameRow = x / frameWidth;
            int selectedFrameCol = y / frameHeight;

            int selectedFrameIndex = selectedFrameCol * sheetCols + selectedFrameRow;
            // we'll catch swap index b on mouseup.
            return selectedFrameIndex;
        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        private void pbx_stitchPreview_MouseDown(object sender, MouseEventArgs e)
        {
            if (filePaths.Count > 0)
            {
                // we'll catch swap index b on mouseup.
                swapIndexA = getPictureIndexFromXY(e.X, e.Y);
            }

        }

        private void pbx_stitchPreview_MouseUp(object sender, MouseEventArgs e)
        {
            if (filePaths.Count > 0)
            {
                // we'll catch swap index b on mouseup.
                swapIndexB = getPictureIndexFromXY(e.X, e.Y);
            }

            if (swapIndexA > -1 && swapIndexA < filePaths.Count && swapIndexB > -1 && swapIndexB < filePaths.Count)
            {
                Swap(filePaths, swapIndexA, swapIndexB);
                swapIndexA = -1;
                swapIndexB = -1;
                UpdateSpritesheetResourcesUi();
            }
        }

        private void pbx_stitchPreview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // replace the image!
            int replaceIndex = getPictureIndexFromXY(e.X, e.Y);
            string whichImage = filePaths[replaceIndex];
            string imageNameOnly = Path.GetFileName(whichImage);

            bool oldMultifile = ofd_spriteChooser.Multiselect;
            string oldTitle = ofd_spriteChooser.Title;
            ofd_spriteChooser.Multiselect = false;
            ofd_spriteChooser.Title = "Choose a sprite to replace: " + imageNameOnly;

            DialogResult _result = ofd_spriteChooser.ShowDialog();
            if (_result == System.Windows.Forms.DialogResult.OK)
            {
                string _file = ofd_spriteChooser.FileName;
                filePaths[replaceIndex] = _file;
                UpdateSpritesheetResourcesUi();
            }

            ofd_spriteChooser.Multiselect = oldMultifile;
            ofd_spriteChooser.Title = oldTitle;
        }

        private void cbx_template_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)cbx_template.SelectedItem == "4x4 character style [XP]")
            {
                tbx_sheetRows.Text = "4";
                tbx_sheetCols.Text = "4";
            }
            else if ((string)cbx_template.SelectedItem == "4x3 character style [VX MV MZ]")
            {
                tbx_sheetRows.Text = "4";
                tbx_sheetCols.Text = "3";
            }
            else if ((string)cbx_template.SelectedItem == "16x12 multi-character style [VX MV MZ]")
            {
                tbx_sheetRows.Text = "16";
                tbx_sheetCols.Text = "12";
            }
            else if ((string)cbx_template.SelectedItem == "9x6 SV Battler style [MV MZ]")
            {
                tbx_sheetRows.Text = "9";
                tbx_sheetCols.Text = "6";
            }
            else if ((string)cbx_template.SelectedItem == "")
            {
                cbx_template.SelectedItem = "Custom";
            }


            if ((string)cbx_template.SelectedItem == "Custom")
            {
                tbx_sheetRows.ReadOnly = false;
                tbx_sheetCols.ReadOnly = false;
            }
            else
            {
                tbx_sheetRows.ReadOnly = true;
                tbx_sheetCols.ReadOnly = true;
            }

        }

    }
}
