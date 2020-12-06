using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class BrightnessCorrection
    {
        private Bitmap _img;
        private int _value;

        public BrightnessCorrection(BitmapImage img, int value)
        {
            _img = BitmapConverter.ConvertToBitmap(img);
            _value = value;
        }

        public BitmapImage Apply()
        {
            for (int i = 0; i < _img.Width; i++)
            {
                for (int j = 0; j < _img.Height; j++)
                {
                    var pix = _img.GetPixel(i, j);

                    int r = pix.R + _value;
                    int b = pix.B + _value;
                    int g = pix.G + _value;

                    if (r >= 256)
                    {
                        r = 255;
                    }
                    else if (r < 0)
                    {
                        r = 0;
                    }

                    if (g >= 256)
                    {
                        g = 255;
                    }
                    else if (g < 0)
                    {
                        g = 0;
                    }

                    if (b >= 256)
                    {
                        b = 255;
                    }
                    else if (b < 0)
                    {
                        b = 0;
                    }

                    var colorToSet = Color.FromArgb(255, r, g, b);

                    _img.SetPixel(i, j, colorToSet);
                }
            }

            return BitmapConverter.ConvertToBitmapImage(_img);
        }
    }
}
