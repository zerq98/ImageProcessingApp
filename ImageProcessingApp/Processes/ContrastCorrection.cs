using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class ContrastCorrection:IManipulation
    {
        private Bitmap _img;
        private int _value;

        public ContrastCorrection(BitmapImage img, int value)
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

                    float factor = (259 * (255 + _value)) / (255 * (259 - _value));

                    double r = Math.Truncate(factor * (pix.R - 128) + 128);
                    double g = Math.Truncate(factor * (pix.G - 128) + 128);
                    double b = Math.Truncate(factor * (pix.B - 128) + 128);

                    if (r > 255)
                    {
                        r = 255;
                    }else if (r < 0)
                    {
                        r = 0;
                    }

                    if (g > 255)
                    {
                        g = 255;
                    }
                    else if (g < 0)
                    {
                        g = 0;
                    }

                    if (b > 255)
                    {
                        b = 255;
                    }
                    else if (b < 0)
                    {
                        b = 0;
                    }

                    var colorToSet = Color.FromArgb(255, (int)r, (int)g, (int)b);

                    _img.SetPixel(i, j, colorToSet);
                }
            }

            return BitmapConverter.ConvertToBitmapImage(_img);
        }
    }
}
