using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Roberts : IManipulation
    {
        private Bitmap _img;

        public Roberts(BitmapImage img)
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
            Color p1, p2, p3, p4;
            int r1, r2, r3, r4, g1, g2, g3, g4, b1, b2, b3, b4;
            int r, g, b;
            Color p;
            int w1 = 1, w2 = -1, w3 = -1;
            for (int y = 0; y < _img.Height - 1; y++)
            {
                for (int x = 0; x < _img.Width - 1; x++)
                {
                    p1 = _img.GetPixel(x, y);
                    p2 = _img.GetPixel(x + 1, y);
                    p3 = _img.GetPixel(x, y + 1);
                    p4 = _img.GetPixel(x + 1, y + 1);

                    r1 = p1.R; g1 = p1.G; b1 = p1.B;
                    r2 = p2.R; g2 = p2.G; b2 = p2.B;
                    r3 = p3.R; g3 = p3.G; b3 = p3.B;
                    r4 = p4.R; g4 = p4.G; b4 = p4.B;

                    r = Math.Abs(r1 * w1 + r2 * w2) + Math.Abs(r1 * w1 + r3 * w3);
                    g = Math.Abs(r1 * w1 + g2 * w2) + Math.Abs(g1 * w1 + g3 * w3);
                    b = Math.Abs(r1 * w1 + b2 * w2) + Math.Abs(b1 * w1 + b3 * w3);

                    if (r > 255) r = 255; else if (r < 0) r = 0;
                    if (g > 255) g = 255; else if (g < 0) g = 0;
                    if (b > 255) b = 255; else if (b < 0) b = 0;

                    p = Color.FromArgb(r, g, b);
                    _img.SetPixel(x, y, p);
                }
            }

            return null;
        }
    }
}
