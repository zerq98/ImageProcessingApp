using ImageProcessingApp.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageProcessingApp.Processes
{
    public class Histogram
    {
        private List<int> R;
        private List<int> G;
        private List<int> B;
        private Bitmap _img;

        public Histogram(BitmapImage img)
        {
            _img = BitmapConverter.ConvertToBitmap(img);
            R = new List<int>();
            G = new List<int>();
            B = new List<int>();

            for(int i = 0; i < 5; i++)
            {
                R.Add(0);
                G.Add(0);
                B.Add(0);
            }
        }

        public List<List<int>> GetColors()
        {
            var listOfColors = new List<List<int>>() { R,G,B };

            for (int i = 0; i < _img.Width; i++)
            {
                for (int j = 0; j < _img.Height; j++)
                {
                    var pix = _img.GetPixel(i, j);

                    if(pix.R <= 50)
                    {
                        R[0]++;

                    }else if(pix.R >=51 && pix.R <= 100)
                    {
                        R[1]++;
                    }
                    else if (pix.R >= 101 && pix.R <= 150)
                    {
                        R[2]++;
                    }
                    else if (pix.R >= 151 && pix.R <= 200)
                    {
                        R[3]++;
                    }
                    else
                    {
                        R[4]++;
                    }


                    if (pix.G <= 50)
                    {
                        G[0]++;

                    }
                    else if (pix.G >= 51 && pix.G <= 100)
                    {
                        G[1]++;
                    }
                    else if (pix.G >= 101 && pix.G <= 150)
                    {
                        G[2]++;
                    }
                    else if (pix.G >= 151 && pix.G <= 200)
                    {
                        G[3]++;
                    }
                    else
                    {
                        G[4]++;
                    }


                    if (pix.B <= 50)
                    {
                        B[0]++;

                    }
                    else if (pix.B >= 51 && pix.B <= 100)
                    {
                        B[1]++;
                    }
                    else if (pix.B >= 101 && pix.B <= 150)
                    {
                        B[2]++;
                    }
                    else if (pix.B >= 151 && pix.B <= 200)
                    {
                        B[3]++;
                    }
                    else
                    {
                        B[4]++;
                    }
                }
            }

            return listOfColors;
        }
    }
}
