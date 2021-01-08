using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Gaussian : IManipulation
    {
        private Bitmap _img;

        public Gaussian(BitmapImage img)
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
            int[,] mask = new int[3, 3];
            mask[0, 0] = 1;
            mask[0, 1] = 4;
            mask[0, 2] = 1;

            mask[1, 0] = 4;
            mask[1, 1] = 12;
            mask[1, 2] = 4;

            mask[2, 0] = 1;
            mask[2, 1] = 4;
            mask[2, 2] = 1;

            Color p1, p2, p3, p4, p5, p6, p7, p8, p9;
            int newR, newG, newB;
            for (int y = 1; y < _img.Height - 2; y++)
            {
                for (int x = 1; x < _img.Width - 2; x++)
                {
                    p1 = _img.GetPixel(x, y);
                    p2 = _img.GetPixel(x + 1, y);
                    p3 = _img.GetPixel(x + 2, y);
                    p4 = _img.GetPixel(x, y + 1);
                    p5 = _img.GetPixel(x + 1, y + 1);
                    p6 = _img.GetPixel(x + 2, y + 1);
                    p7 = _img.GetPixel(x, y + 2);
                    p8 = _img.GetPixel(x + 1, y + 2);
                    p9 = _img.GetPixel(x + 2, y + 2);

                    int dividing = 0;
                    for (int a = 0; a != 3; a++)
                    {
                        for (int b = 0; b != 3; b++)
                        {
                            dividing += mask[a, b];
                        }
                    }
                    int r1, r2, r3, r4, r5, r6, r7, r8, r9;
                    int g1, g2, g3, g4, g5, g6, g7, g8, g9;
                    int b1, b2, b3, b4, b5, b6, b7, b8, b9;

                    r1 = p1.R; g1 = p1.G; b1 = p1.B;
                    r2 = p2.R; g2 = p2.G; b2 = p2.B;
                    r3 = p3.R; g3 = p3.G; b3 = p3.B;
                    r4 = p4.R; g4 = p4.G; b4 = p4.B;
                    r5 = p5.R; g5 = p5.G; b5 = p5.B;
                    r6 = p6.R; g6 = p6.G; b6 = p6.B;
                    r7 = p7.R; g7 = p7.G; b7 = p7.B;
                    r8 = p8.R; g8 = p8.G; b8 = p8.B;
                    r9 = p9.R; g9 = p9.G; b9 = p9.B;

                    newR = ((r1 * mask[0, 0] + r2 * mask[0, 1] + r3 * mask[0, 2] + r4 * mask[1, 0] + r5 * mask[1, 1] + r6 * mask[1, 2] + r7 * mask[2, 0] + r8 * mask[2, 1] + r9 * mask[2, 2]) / dividing);
                    if (newR > 255) newR = 255; else if (newR < 0) newR = 0;
                    newG = ((g1 * mask[0, 0] + g2 * mask[0, 1] + g3 * mask[0, 2] + g4 * mask[1, 0] + g5 * mask[1, 1] + g6 * mask[1, 2] + g7 * mask[2, 0] + g8 * mask[2, 1] + g9 * mask[2, 2]) / dividing);
                    if (newG > 255) newG = 255; else if (newG < 0) newG = 0;
                    newB = ((b1 * mask[0, 0] + b2 * mask[0, 1] + b3 * mask[0, 2] + b4 * mask[1, 0] + b5 * mask[1, 1] + b6 * mask[1, 2] + b7 * mask[2, 0] + b8 * mask[2, 1] + b9 * mask[2, 2]) / dividing);
                    if (newB > 255) newB = 255; else if (newB < 0) newB = 0;
                    Color newColor = Color.FromArgb(newR, newG, newB);
                    _img.SetPixel(x, y, newColor);
                }

            }

            return null;
        }
    }
}
