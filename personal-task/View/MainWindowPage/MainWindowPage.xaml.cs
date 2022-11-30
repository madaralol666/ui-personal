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
            User userModel = FrameNavigate.DB.User.FirstOrDefault(u => u.LastName == LastNameUser.lastName);
            Role rolemodel = FrameNavigate.DB.Role.FirstOrDefault(u => u.RoleID == userModel.RoleID);

            TBID.Text = "@" + userModel.LastName;
            TBRole.Text =rolemodel.RoleName;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
