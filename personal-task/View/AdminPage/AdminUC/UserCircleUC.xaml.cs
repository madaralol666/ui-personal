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

namespace personal_task.View.AdminPage.AdminUC
{
    /// <summary>
    /// Логика взаимодействия для UserCircleUC.xaml
    /// </summary>
    public partial class UserCircleUC : UserControl
    {
        public UserCircleUC()
        {
            InitializeComponent();
            DataUser.ItemsSource = FrameNavigate.DB.UserCircles.OrderBy(u => u.UserID).ToList();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            int Circleid = (DataUser.SelectedItem as UserCircle).CircleID;
            int idUser = (DataUser.SelectedItem as UserCircle).User.UserID;
            List<UserCircle> userCircle = (from u in FrameNavigate.DB.UserCircles where u.UserID == idUser && u.Circle.CircleID == Circleid select u).ToList();
            foreach (var templist in userCircle)
            {
                FrameNavigate.DB.UserCircles.Remove(templist);
            }
            FrameNavigate.DB.SaveChanges();
            DataUser.ItemsSource = FrameNavigate.DB.UserCircles.OrderBy(u => u.UserID).ToList();
        }
    }
}
    