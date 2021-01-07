using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Sobel : IManipulation
    {
        private Bitmap _img;

        public Sobel(BitmapImage img)
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
            int p1, p2, p3, p4, p5, p6, p7, p8, p9;
            for (int y = 1; y < _img.Height - 2; y++)
            {
                for (int x = 1; x < _img.Width - 2; x++)
                {
                    int newR, newG, newB;
                    {
                        p1 = _img.GetPixel(x, y).R;
                        p2 = _img.GetPixel(x + 1, y).R;
                        p3 = _img.GetPixel(x + 2, y).R;
                        p4 = _img.GetPixel(x, y + 1).R;
                        p5 = _img.GetPixel(x + 1, y + 1).R;
                        p6 = _img.GetPixel(x + 2, y + 1).R;
                        p7 = _img.GetPixel(x, y + 2).R;
                        p8 = _img.GetPixel(x + 1, y + 2).R;
                        p9 = _img.GetPixel(x + 2, y + 2).R;

                        int R1, R2;
                        R1 = Math.Abs((-p1) + p3 - (2 * p4) + (2 * p6) + (-p7) + p9);
                        R2 = Math.Abs(p1 + (2 * p2) + p3 - p7 - (2 * p8) - p9);
                        newR = R1 + R2;
                    }
                    {
                        p1 = _img.GetPixel(x, y).G;
                        p2 = _img.GetPixel(x + 1, y).G;
                        p3 = _img.GetPixel(x + 2, y).G;
                        p4 = _img.GetPixel(x, y + 1).G;
                        p5 = _img.GetPixel(x + 1, y + 1).G;
                        p6 = _img.GetPixel(x + 2, y + 1).G;
                        p7 = _img.GetPixel(x, y + 2).G;
                        p8 = _img.GetPixel(x + 1, y + 2).G;
                        p9 = _img.GetPixel(x + 2, y + 2).G;

                        int G1, G2;
                        G1 = Math.Abs((-p1) + p3 - (2 * p4) + (2 * p6) + (-p7) + p9);
                        G2 = Math.Abs(p1 + (2 * p2) + p3 - p7 - (2 * p8) - p9);
                        newG = G1 + G2;
                    }
                    {
                        p1 = _img.GetPixel(x, y).B;
                        p2 = _img.GetPixel(x + 1, y).B;
                        p3 = _img.GetPixel(x + 2, y).B;
                        p4 = _img.GetPixel(x, y + 1).B;
                        p5 = _img.GetPixel(x + 1, y + 1).B;
                        p6 = _img.GetPixel(x + 2, y + 1).B;
                        p7 = _img.GetPixel(x, y + 2).B;
                        p8 = _img.GetPixel(x + 1, y + 2).B;
                        p9 = _img.GetPixel(x + 2, y + 2).B;

                        int B1, B2;
                        B1 = Math.Abs((-p1) + p3 - (2 * p4) + (2 * p6) + (-p7) + p9);
                        B2 = Math.Abs(p1 + (2 * p2) + p3 - p7 - (2 * p8) - p9);
                        newB = B1 + B2;
                    }

                    if (newR > 255) newR = 255; else if (newR < 0) newR = 0;
                    if (newG > 255) newG = 255; else if (newG < 0) newG = 0;
                    if (newB > 255) newB = 255; else if (newB < 0) newB = 0;
                    Color nowypixel = Color.FromArgb(newR, newG, newB);
                    _img.SetPixel(x, y, nowypixel);
                }
            }
                    return null;
        }
    }
}
