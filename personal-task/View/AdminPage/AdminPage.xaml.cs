using personal_task.Model;
using personal_task.View.AdminPage.AdminUC;
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

namespace personal_task.View.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void MenuItemUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItemUerCircle_Click(object sender, RoutedEventArgs e)
        {
            GridMenuLoad.Children.Clear();
            GridMenuLoad.Children.Add(new UserCircleUC());
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
