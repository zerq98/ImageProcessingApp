   M S B A M L   `   `   `  ����M  IImageProcessingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ImageProcessingAppImageProcessingApp  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   (    "ImageProcessingApp.HistogramWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:ImageProcessingApp     5   	   Dchr4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	     � Title$  HistogramWindow��5	   	   $	��550��6!   $
��1200��6.    � WindowStyle$
 None=�6;    � 
ResizeMode$ NoResize=�6N   '  !System.Windows.Shell.WindowChrome   WindowChrome 5
        5   
      CaptionHeight$ 30Q�6   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   $��30��6!   ���#3c3c3c��6-   ��  �� ElementName$ 
MainScreen�� �� Path$ ActualWidth�.+�5      ��  �� TextAlignment$ Center=�6   $
��Left=�6/   ���#cdcdcd	 �� Padding$	 0,5,0,0q�6Z   	Histogram6w   � 5      $��40��6   $��Right=�6#   $��Right=�6:   .+�5      �� -   5        
 ��Name$
 CloseBtn��5         IsHitTestVisibleInChrome . 
������    Button.Hoverless#���   6q   $��30��6�   $��30��6�   $	��5,0q�6�   .��5      �� $#��/Resources/Graphics/close.png��6   5      5      5      #  LiveCharts.Wpf.CartesianChart  5   
   -   5        $��
ColorChart��5      $��2��6/   $��10, 50, 10, 20q�6<   &   LiveCharts.Wpf.Charts.Base.Chart   	Hoverable .     DataTooltip 6f   Z�    AxisX 5        LiveCharts.Wpf.Axis     Labels9  3LiveCharts.Wpf.Converters.StringCollectionConverter$) #0-50,51-100,101-150,151-200,201-255 6      Title$ Color values��6H   6_      AxisY 5        $ 	Intensity��6   6/      Series 5"      !  LiveCharts.Wpf.ColumnSeries  -   5          Name$ 	RedSeries��5"   #     LiveCharts.Wpf.Series   Fill
 �  ��66     5#      -   5        $ GreenSeries��5#   #   
 � � �68     5$      -   5        $ 
BlueSeries��5$   #   
 ��  �67   5&      5'      5(      