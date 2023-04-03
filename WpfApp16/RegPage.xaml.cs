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

namespace WpfApp16
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            MainWindow.GetWindow(this)?.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registr(Log.Text, Password1.Password, Password2.Password, FIO.Text);
        }
        public bool Registr(string Log, string Password1, string Password2, string FIO)
        {
            string log_reg = Log;
            string fio_reg = FIO;
            string password_reg = Password1;
            string password_again = Password2;


            if (string.IsNullOrEmpty(log_reg) || string.IsNullOrEmpty(fio_reg) ||
                string.IsNullOrEmpty(password_reg) || string.IsNullOrEmpty(password_again))
            {
                MessageBox.Show("Вы не заполнили поля или одно из полей!", "Ошибка пустого значаения");
                return false;
            }
            else if (password_reg != password_again)
            {
                MessageBox.Show("Пароли не совпадают, попробуйте проверить введеный вами пароль и его подтверждение!", "Не совпадение пароля");
                return false;
            }
            else if (password_reg.Length < 1)
            {
                MessageBox.Show("Пароль содержит меньше 1 знака, увеличь его!", "Маленький пароль");
                return false;
            }
            else
            {
                var db = new UserEntities();
                User userObject = db.User.FirstOrDefault(u => u.Login == log_reg);
                if (userObject != null)
                {
                    MessageBox.Show("Такой пользователь с логином уже существует", "Существующий пользователь");
                    return false;
                }
                else
                {
                    userObject = new User
                    {
                        Login = Log,
                        Password = Password1,
                        FIO = FIO,
                        Role = "Пользователь",
                    };
                    db.User.Add(userObject);
                    db.SaveChanges();

                    MessageBox.Show($"Здраствуйте \"{FIO}\", вы были зарегестрированы!", "Регистрация");
                    return true;
                }

            }
        }
    }
}
