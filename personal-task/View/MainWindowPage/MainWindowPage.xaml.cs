using personal_task.Core;
using personal_task.Model;
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

namespace personal_task.View.MainWindowPage
{
    /// <summary>
    /// Логика взаимодействия для MainWindowPage.xaml
    /// </summary>
    public partial class MainWindowPage1 : Page
    {
        public MainWindowPage1()
        {
            InitializeComponent();
            User userModel = FrameNavigate.DB.Users.FirstOrDefault(u => u.LastName == LastNameUser.lastName);
            Role rolemodel = FrameNavigate.DB.Roles.FirstOrDefault(u => u.RoleID == userModel.RoleID);
            UsersCircle UCModel = FrameNavigate.DB.UsersCircles.def

           
            TBRole.Text = rolemodel.RoleName;
            TBID.Text = "@" + userModel.FirstName;
            TBInfo.Text = Convert.ToString($"{userModel.Date.Day}.{userModel.Date.Month}.{userModel.Date.Year} {userModel.UsersCircles}");


        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Ошибка данных",
                       "Системное сообщение",
                       MessageBoxButton.OK,
                       MessageBoxImage.Error);
        }
    }
}
