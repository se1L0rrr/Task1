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

namespace WpfApp25
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Имя не может быть пустым!", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (name.Any(c => c >='А' && c <= 'я'))
            {
                MessageBox.Show("Введите имя на английском");
            }
            else
            {
                MessageBox.Show("Вы ввели: " + name, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
