﻿using ImageProcessingApp.Processes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create((BitmapSource)ModifiedImage.Source));
            using (FileStream stream = new FileStream("./save.png", FileMode.Create))
                encoder.Save(stream);
        }

        private void GrayScaleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (bmp != null)
            {
                ModifiedImage.Source = new Grayscale(bmp).Apply();
            }
        }
    }
}
