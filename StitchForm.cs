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
			//TODO: Save JSON file mapping image inputs to output
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
    }
}
