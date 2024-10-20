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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp27
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing = false;
        private Point startPoint;
        private SolidColorBrush currentColor = Brushes.Black;
        private double brushSize = 20;
        private bool isErasing = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorComboBox.SelectedItem is ComboBoxItem item)
                currentColor = (SolidColorBrush)new BrushConverter().ConvertFromString(item.Tag.ToString());
        }

        private void BrushSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            brushSize = e.NewValue;
            BrushSizeTextBlock.Text = $"Размер: {brushSize}";
        }

        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDrawing = true;
                startPoint = e.GetPosition(DrawingCanvas);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point endPoint = e.GetPosition(DrawingCanvas);
                if (!isErasing)
                    DrawLine(startPoint, endPoint);
                else
                    Erase(endPoint);
                startPoint = endPoint;
            }
        }

        private void DrawingCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if
        (e.LeftButton == MouseButtonState.Released)
                isDrawing = false;
        }

        private void DrawLine(Point start, Point end)
        {
            var line = new Line { Stroke = currentColor, StrokeThickness = brushSize, X1 = start.X, Y1 = start.Y, X2 = end.X, Y2 = end.Y };
            DrawingCanvas.Children.Add(line);
        }

        private void Erase(Point position)
        {
            var eraser = new Rectangle
            {
                Fill = Brushes.White,
                Width = brushSize,
                Height = brushSize
            };
            Canvas.SetLeft(eraser, position.X - (brushSize / 2));
            Canvas.SetTop(eraser, position.Y - (brushSize / 2));
            DrawingCanvas.Children.Add(eraser);
        }

        private void EraseButton_Click(object sender, RoutedEventArgs e)
        {
            isErasing = !isErasing;
            EraseButton.Background = isErasing ? Brushes.LightGray : Brushes.LightBlue;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            DrawingCanvas.Children.Clear();
        }
    }
}