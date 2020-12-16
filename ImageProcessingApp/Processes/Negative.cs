using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Negative : IManipulation
    {
        private readonly Bitmap _img;

        public Negative(BitmapImage image)
        {
            _img = BitmapConverter.ConvertToBitmap(image);
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

                    int r = 255 - pix.R;
                    int g = 255 - pix.G;
                    int b = 255 - pix.B;

                    var colorToSet = Color.FromArgb(255, r, g, b);

                    _img.SetPixel(i, j, colorToSet);
                }
            }

            return null;
        }
    }
}
