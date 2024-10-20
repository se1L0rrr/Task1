using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeBackground_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            byte r = (byte)random.Next(256);
            byte g = (byte)random.Next(256);
            byte b = (byte)random.Next(256);
            this.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            statusText.Text = "Фон изменен.";
        }

        private void AboutDeveloper_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Idrisov Khasan\nКонтакт: @se1L0rrr", "Информация о разработчике", MessageBoxButton.OK, MessageBoxImage.Information);
            statusText.Text = "Показана информация о разработчике.";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}