using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Median : IManipulation
    {
        private Bitmap _img;

        public Median(BitmapImage img)
        {
            _img = BitmapConverter.ConvertToBitmap(img);
        }

        public async Task<BitmapImage> Apply()
        {
            await Task.Run(Manipulate);

            return BitmapConverter.ConvertToBitmapImage(_img);
        }

        public Action Manipulate()
        {
            for (int column = 2; column < (_img.Width - 2); column++)
            {
                for (int row = 2; row < (_img.Height - 2); row++)
                {
                    double sumBlue = 0;
                    double sumGreen = 0;
                    double sumRed = 0;
                    for (int i = -2 / 2; i <= 2 / 2; i++)
                    {
                        for (int j = -2 / 2; j <= 2 / 2; j++)
                        {
                            var pixelValue = _img.GetPixel(column + i, row + j);
                            var red = pixelValue.R;
                            var green = pixelValue.G;
                            var blue = pixelValue.B;
                            sumRed += red;
                            sumGreen += green;
                            sumBlue += blue;
                        }
                    }
                    var averageRed = (int)(sumRed / 9);
                    var averageGreen = (int)(sumGreen / 9);
                    var averageBlue = (int)(sumBlue / 9);
                    _img.SetPixel(column, row, Color.FromArgb(averageRed, averageGreen, averageBlue));
                }
            }

            return null;
        }
    }
}
