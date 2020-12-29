using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Binarization : IManipulation
    {
        private Bitmap _img;
        private int _value;

        public Binarization(BitmapImage img, int value)
        {
            _img = BitmapConverter.ConvertToBitmap(img);
            _value = value;
        }

        public async Task<BitmapImage> Apply()
        {
            await Task.Run(Manipulate);

            return BitmapConverter.ConvertToBitmapImage(_img);
        }

        public Action Manipulate()
        {
            for (int i = 0; i < _img.Width; i++)
            {
                for (int j = 0; j < _img.Height; j++)
                {
                    var pix = _img.GetPixel(i, j);

                    byte newColor = (byte)((pix.R + pix.G + pix.B) / 3);

                    if(_value != 0)
                    {
                        if (newColor >= _value)
                        {
                            newColor = 0;
                        }
                        else
                        {
                            newColor = 255;
                        }

                        var colorToSet = Color.FromArgb(255, newColor, newColor, newColor);

                        _img.SetPixel(i, j, colorToSet);
                    }
                }
            }

            return null;
        }
    }
}
