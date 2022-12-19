using personal_task.Core;
using personal_task.Model;
using personal_task.View.MainWindowPage;
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

namespace personal_task.View.LoginPage
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            User userModel = FrameNavigate.DB.Users.FirstOrDefault(u => u.LastName == TbLogin.Text);
            TbLogin.Text = Properties.Settings.Default.RememberMe;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User userModel = FrameNavigate.DB.Users.FirstOrDefault(u => u.LastName == TbLogin.Text);
                if (userModel != null)
                {
                    LastNameUser.lastName = TbLogin.Text;
                    LastNameUser.RoleName = userModel.Role.RoleName.Trim();
                    if (LastNameUser.RoleName == "Admin")
                    {
                        FrameNavigate.objectFrame.Navigate(new AdminPage.AdminPage());
                    }
                    else
                    {
                        FrameNavigate.objectFrame.Navigate(new MainWindowPage1());
                    }

                }
                else
                {
                    MessageBox.Show("Ошибка данных",
                       "Системное сообщение",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Системная ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void TbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        private void BtnRembMe_Click(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == string.Empty)
            {
                MessageBox.Show("Заполните Поле",
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                BtnRembMe.IsChecked = false;
            }            
        }

        private void TbLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BtnRembMe.IsChecked == true)
            {
                Properties.Settings.Default.RememberMe = TbLogin.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.RememberMe = string.Empty;
                Properties.Settings.Default.Save();
            }
        }
    }
}
