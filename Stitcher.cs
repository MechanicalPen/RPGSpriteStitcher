using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SpriteStitcher
{
	static class Stitcher
	{
		public static Bitmap StitchFromImgPaths(List<string> imgPaths, int sheetRows, int sheetCols)
		{
			int _maxSpriteWidth = 0;
			int _maxSpriteHeight = 0;
			return stitch(imgPaths, sheetRows, sheetCols, out _maxSpriteWidth, out _maxSpriteHeight);
		}

		public static Bitmap StitchFromImgPaths(List<string> imgPaths, int sheetRows, int sheetCols, out int maxSpriteWidth, out int maxSpriteHeight)
		{
			return stitch(imgPaths, sheetRows, sheetCols, out maxSpriteWidth, out maxSpriteHeight);
		}

		private static Bitmap stitch(List<string> imgPaths, int sheetRows, int sheetCols, out int maxSpriteWidth, out int maxSpriteHeight)
		{
			// Find all images in the current directory
			if (imgPaths.Count() != 0)
			{
				// Read in images and get the dimensions of the largest image
				maxSpriteWidth = 0;
				maxSpriteHeight = 0;
				List<Bitmap> _images = new List<Bitmap>();
				foreach (string _imgPath in imgPaths)
				{
					Bitmap _newImage = new Bitmap(_imgPath);

					if (_newImage.Height > maxSpriteHeight)
					{
						maxSpriteHeight = _newImage.Height;
					}

					if (_newImage.Width > maxSpriteWidth)
					{
						maxSpriteWidth = _newImage.Width;
					}

					_images.Add(_newImage);
				}

				// Build the composite image (the sprite sheet)
				Bitmap _composite = new Bitmap(maxSpriteWidth * sheetCols, maxSpriteHeight * sheetRows);
				using (Graphics _graphics = Graphics.FromImage(_composite))
				{
					for (int _imgCount = 0; _imgCount < imgPaths.Count() && _imgCount < (sheetCols * sheetRows); _imgCount++)
					{
						string _imgPath = imgPaths.ElementAt(_imgCount);
						Bitmap _image = new Bitmap(_imgPath);

                        // we want to center smaller sprites to the bottom middle.
                        int myActualWidth = _image.Width;
                        int myActualHeight = _image.Height;

						int frameX0 = (_imgCount % sheetCols) * maxSpriteWidth;
						int framey0 = (_imgCount / sheetCols) * maxSpriteHeight;

                        // since 0,0 is the top left of the bitmap, we need to add the difference
                        // to the x,y position of the frame. one half the x differenence will
                        // center the image on the X axis. ALL of the y difference will place the
                        // image at the bottom of the frame.

                        int _drawX = frameX0 + (maxSpriteWidth - myActualWidth) / 2;
                        int _drawY = framey0 + (maxSpriteHeight - myActualHeight);

						_graphics.DrawImage(
							_image,
							_drawX,
							_drawY,
                            myActualWidth,
                            myActualHeight
                        );
					}
				}
				return _composite;
			}
			else
			{
				throw new Exception("Error producing stitched spritesheet: No sprites were passed to the stitcher");
			}
		}
	}
}
