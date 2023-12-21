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
using System.Windows.Threading;

namespace Practic
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {

        //Таймер
        DispatcherTimer _timer;
        //Счетчик попыток входа
        int _countLogin = 1;

        public Autorization()
        {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            txtbxLogin.Focus();
            Data.Login = "";
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 10);
            _timer.Tick += new EventHandler(timer_Tick);
        }

        void GetCaptcha()
        {
            string masChar = "QWERTYUIOPLKJHGFDSAZXCVBNM" +
                "mnbvcxzlkjhgfdsapoiuytrewq1234567890";
            string captcha = "";
            Random rnd = new Random();

            for (int i = 1; i < 6; i++)
            {
                captcha = captcha + masChar[rnd.Next(0, masChar.Length)];
            }

            txtxblcCaptcha.Visibility = Visibility.Visible;
            txtbxCaptcha.Visibility = Visibility.Visible;
            line.Visibility = Visibility.Visible;
            txtxblcCaptcha.Text = captcha;
            txtbxCaptcha.Text = null;
            txtxblcCaptcha.LayoutTransform = new RotateTransform(rnd.Next(-15, 15));

            line.X1 = 10;
            line.Y1 = rnd.Next(10, 40);
            line.X2 = 280;
            line.Y2 = rnd.Next(10, 40);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            grdReg.IsEnabled = true;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

            //Если запись найдена
            if (txtbxLogin.Text == "Admin" && txtbxCaptcha.Text == txtxblcCaptcha.Text)
            {
                //запоминаем данные
                Data.Login = "Admin";
                MainWindow mainWindow = new MainWindow();
                Close();
                mainWindow.ShowDialog();
            }
            else
            {
                if (txtbxLogin.Text == "Admin")
                {
                    MessageBox.Show("Капча введена неверно, повторите ввод",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Ошибка в логине или пароле, повторите попытку",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
                GetCaptcha();

                if (_countLogin >= 2)
                {
                    grdReg.IsEnabled = false;
                    _timer.Start();
                }
                _countLogin++;
                txtbxLogin.Focus();
            }
        }

        private void btnEnterG_Click(object sender, RoutedEventArgs e)
        {
            txtbxLogin.Text = "User";
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.ShowDialog();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
