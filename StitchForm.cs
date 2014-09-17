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
			int _sheetRows;
			int _sheetCols;
			int _frameWidth;
			int _frameHeight;

			if (filePaths.Count() != 0 && Int32.TryParse(tbx_sheetRows.Text, out _sheetRows) && Int32.TryParse(tbx_sheetCols.Text, out _sheetCols))
			{
				Image _img = Stitcher.StitchFromImgPaths(filePaths, _sheetRows, _sheetCols, out _frameWidth, out _frameHeight);

				pbx_stitchPreview.Image = _img;
				lbl_outputSizeVw.Text = _img.Width + " x " + _img.Height;
				lbl_frameSizeVw.Text = _frameWidth + " x " + _frameHeight;
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
				ImageFormat _format = ImageFormat.Bmp;

				switch (_extension.ToLower())
				{
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
	}
}
