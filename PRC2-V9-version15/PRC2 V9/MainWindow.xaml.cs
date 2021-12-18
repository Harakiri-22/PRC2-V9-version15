using System;
using Microsoft.Win32;
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
using Lib_9;
using LibMas;

namespace PRC2_V9
{
    // Ввести n целых чисел(>0 или <0). Найти произведение чисел. Результат вывести на экран.
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private LibMas.Array _thisArray = new LibMas.Array(10);

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Мишин Дмитрий ИСП-34", "Разработчик", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Calculation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                multiplication.Clear();
                multiplication.Text = _thisArray.MultiplyingAnArray();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            multiplication.Clear();
            _thisArray.Fill();
            dataGrid.ItemsSource = _thisArray.ToTableData().DefaultView;
        }

        private void ClearArray_Click(object sender, RoutedEventArgs e)
        {
            _thisArray.Clear();
            multiplication.Clear();
            dataGrid.ItemsSource = _thisArray.ToTableData().DefaultView;
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.DefaultExt = ".txt";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.Title = "Экспорт массива";

                if (saveFileDialog.ShowDialog() == true)
                {
                    _thisArray.Export(saveFileDialog.FileName);
                }
                multiplication.Clear();
                dataGrid.ItemsSource = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }
        private void OpenArray_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.DefaultExt = ".txt";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Импорт массива";

                if (openFileDialog.ShowDialog() == true)
                {
                    _thisArray.Import(openFileDialog.FileName);
                }
                multiplication.Clear();
                dataGrid.ItemsSource = _thisArray.ToTableData().DefaultView;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
