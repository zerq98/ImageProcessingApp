using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Grayscale : IManipulation
    {
        private Bitmap _img;

        public Grayscale(BitmapImage img)
        {
            _img = BitmapConverter.ConvertToBitmap(img);
        }

        public BitmapImage Apply()
        {
            for(int i = 0; i < _img.Width; i++)
            {
                for (int j = 0; j < _img.Height; j++)
                {
                    var pix = _img.GetPixel(i, j);

                    byte newColor = (byte)((pix.R + pix.G + pix.B) / 3);

                    var colorToSet = Color.FromArgb(255,newColor,newColor,newColor);

                    _img.SetPixel(i, j, colorToSet);
                }
            }

            return BitmapConverter.ConvertToBitmapImage(_img);
        }
    }
}
