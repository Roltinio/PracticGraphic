using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Practic
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<double> numericLeft = new List<double>();
       
        
        public MainWindow()
        {
            InitializeComponent();

            RandomGraphDrawer randomGraphDrawer = new RandomGraphDrawer(canvas);
            randomGraphDrawer.DrawGraph();

            if (Data.Login != "Admin")
            {
                btnCalculateInput.IsEnabled = false;
                stacPanel.Visibility = Visibility.Hidden;
            }
        }

        //автоматический рассчет
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            RandomGraphDrawer randomGraphDrawer = new RandomGraphDrawer(canvas);
            randomGraphDrawer.DrawGraph();
        }

        //ручной ввод
        private void btnInput(object sender, RoutedEventArgs e)
        {
            //Переносим все значения из TextBox в массив
            string input = Month3.Text.Trim();
            string[] numbers = input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string[] values = new string[9];//Создаем массив для записи

            try
            {
                for (int i = 0; i <= 8; i++)
                {
                    values[i] = numbers[i];
                }
            }
            catch 
            {
                MessageBox.Show("Введите значения",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
                
            
            UserInputGraphDrawer userInputGraphDrawer = new UserInputGraphDrawer(canvas, values);
            userInputGraphDrawer.DrawGraph();
        }

        private void mnI1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnI2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnI3_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Вы действительно хотите выйти?",
                "Выход",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
