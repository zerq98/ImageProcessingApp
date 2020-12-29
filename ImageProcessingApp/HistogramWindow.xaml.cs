using ImageProcessingApp.Processes;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ImageProcessingApp
{
    public partial class HistogramWindow : Window
    {
        public HistogramWindow(BitmapImage bmp)
        {
            InitializeComponent();
            InitializeChart(bmp);
            this.CloseBtn.Click += (s, e) => this.Close();
        }

        public void InitializeChart(BitmapImage bmp)
        {
            var listOfColors = new Histogram(bmp).GetColors();

            RedSeries.Values = new ChartValues<int>(listOfColors[0]);
            GreenSeries.Values = new ChartValues<int>(listOfColors[1]);
            BlueSeries.Values = new ChartValues<int>(listOfColors[2]);
        }
    }
}
