using ImageProcessingApp.Processes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageProcessingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bmp;
        private delegate Task ImageManipulation(IManipulation manipulation);
        private ImageManipulation Manipulation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CloseBtn.Click += (s, e) => this.Close();
            MinimizeBtn.Click += (s, e) => MainScreen.WindowState = WindowState.Minimized;
            MaximizeBtn.Click += (s, e) =>
            {
                if (MainScreen.WindowState == WindowState.Maximized)
                {
                    MainScreen.WindowState = WindowState.Normal;
                }
                else
                {
                    MainScreen.WindowState = WindowState.Maximized;
                }
            };

            Manipulation = ApplyManipulationAsync;
        }

        private void LoadImage(string path)
        {
            bmp = new BitmapImage(new Uri(path));
            OriginalImage.Source = bmp;
            ModifiedImage.Source = bmp;
        }

        private void LoadImageBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                LoadImage(fileDialog.FileName);
            }
        }

        private void SaveImageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)ModifiedImage.Source));
                using (FileStream stream = new FileStream("./save.png", FileMode.Create))
                    encoder.Save(stream);

                MessageBox.Show("Saved!!");
            }
            else
            {
                MessageBox.Show("Nothing to save!!");
            }
        }

        private async Task ApplyManipulationAsync(IManipulation manipulation)
        {
            if (bmp != null)
            {
                ModifiedImage.Source = await manipulation.Apply();
            }
        }

        private void GrayScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null){
                Manipulation.Invoke(new Grayscale(bmp));
            }
        }

        private void ContrastSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new ContrastCorrection(bmp, (int)ContrastSlider.Value));
            }
        }

        private void BrightnessSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new BrightnessCorrection(bmp, (int)BrightnessSlider.Value));
            }
        }

        private void NegativeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new Negative(bmp));
            }
        }

        private void BinarySlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new Binarization(bmp, (int)BinarySlider.Value));
            }
        }

        private void HistogramBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                var histogramWindow = new HistogramWindow(bmp);
                histogramWindow.Show();
            }
        }

        private void MedianBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new Median(bmp));
            }
        }

        private void GausseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new Gaussian(bmp));
            }
        }

        private void SharpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                Manipulation.Invoke(new Sharpen(bmp));
            }
        }
    }
}
