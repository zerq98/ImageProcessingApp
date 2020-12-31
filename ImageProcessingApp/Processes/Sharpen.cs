using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Sharpen : IManipulation
    {
        private Bitmap _img;

        public Sharpen(BitmapImage img)
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
            int filterWidth = 3;
            int filterHeight = 3;
            int w = _img.Width;
            int h = _img.Height;

            double[,] filter = new double[filterWidth, filterHeight];

            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] =
           filter[2, 0] = filter[2, 2] = -1;
            filter[2, 1] = 1;
            filter[1, 1] = 9;

            double factor = 1.0;
            double bias = 0.0;

            Color[,] result = new Color[_img.Width, _img.Height];

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    double red = 0.0, green = 0.0, blue = 0.0;


                    for (int filterX = 0; filterX < filterWidth; filterX++)
                    {
                        for (int filterY = 0; filterY < filterHeight; filterY++)
                        {
                            int imageX = (x - filterWidth / 2 + filterX + w) % w;
                            int imageY = (y - filterHeight / 2 + filterY + h) % h;

                            Color imageColor = _img.GetPixel(imageX, imageY);
                            red += imageColor.R * filter[filterX, filterY];
                            green += imageColor.G * filter[filterX, filterY];
                            blue += imageColor.B * filter[filterX, filterY];
                        }
                        int r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                        int g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                        int b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                        result[x, y] = Color.FromArgb(r, g, b);
                    }
                }
            }
            for (int i = 0; i < w; ++i)
            {
                for (int j = 0; j < h; ++j)
                {
                    _img.SetPixel(i, j, result[i, j]);
                }
            }

            return null;
        }
    }
}
