using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textBox.FontSize = e.NewValue;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Сохранить текст"
            };

            if (saveFile.ShowDialog() == true)
            {
                File.WriteAllText(saveFile.FileName, textBox.Text);
            }
        }
    }
}