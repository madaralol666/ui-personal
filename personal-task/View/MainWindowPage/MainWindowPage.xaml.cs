using personal_task.Core;
using personal_task.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            ItemsControlInfo.ItemsSource = FrameNavigate.DB.Users.Where(u => u.LastName == LastNameUser.lastName).ToList();
            /*LBMenu.ItemsSource = (from u in FrameNavigate.DB.UserCircles where u.User.LastName == LastNameUser.lastName select u.Circle.CircleName).ToList();*/
            LBMenu.ItemsSource = FrameNavigate.DB.UserCircles.Where(u => u.User.LastName == LastNameUser.lastName).ToList();
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

        private void LBMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //var name = (LBMenu.SelectedItem as UserCircle).Circle.CircleName;
            if ((LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim() != null)
            {
                LastNameUser.SourceLink = $"source\\FileDescription{(LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim()}.txt";
                if (File.Exists(LastNameUser.SourceLink) == false)
                {
                    LastNameUser.templink = System.IO.Path.GetDirectoryName(LastNameUser.SourceLink);
                    Directory.CreateDirectory(LastNameUser.templink);
                    File.Create(LastNameUser.SourceLink).Close();
                }

                /*GridMenu.Children.Clear(); */

                LastNameUser.CircleName = (LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim();
                StreamReader streamReader = new StreamReader(LastNameUser.SourceLink);
                string test = streamReader.ReadToEnd();
                streamReader.Close();
                tbcircle.Text = test;
                /*FrameNavigate.objectFrame.Navigate(new MainWindowUC());*/
            }
        }

        private void tbcircle_TextChanged(object sender, TextChangedEventArgs e)
        {
            string rtbox = tbcircle.Text;
            switch (LastNameUser.CircleName)
            {
                case "C#":
                    if (File.Exists(LastNameUser.SourceLink))
                    {

                        LastNameUser.templink = System.IO.Path.GetDirectoryName(LastNameUser.SourceLink);
                        Directory.CreateDirectory(LastNameUser.templink);
                        File.Create(LastNameUser.SourceLink).Close();

                        StreamWriter SWCSharp = new StreamWriter(LastNameUser.SourceLink, true);
                        SWCSharp.WriteLine(String.Format(rtbox));
                        SWCSharp.Close();
                    }
                    break;
                case "WPF":
                    if (File.Exists(LastNameUser.SourceLink))
                    {

                        LastNameUser.templink = System.IO.Path.GetDirectoryName(LastNameUser.SourceLink);
                        Directory.CreateDirectory(LastNameUser.templink);
                        File.Create(LastNameUser.SourceLink).Close();

                        StreamWriter SWCpp = new StreamWriter(LastNameUser.SourceLink, true);
                        SWCpp.WriteLine(String.Format(rtbox));
                        SWCpp.Close();
                    }
                    break;
                case "C++":
                    if (File.Exists(LastNameUser.SourceLink))
                    {

                        LastNameUser.templink = System.IO.Path.GetDirectoryName(LastNameUser.SourceLink);
                        Directory.CreateDirectory(LastNameUser.templink);
                        File.Create(LastNameUser.SourceLink).Close();

                        StreamWriter SWcpp = new StreamWriter(LastNameUser.SourceLink, true);
                        SWcpp.WriteLine(String.Format(rtbox));
                        SWcpp.Close();

                    }
                    break;


            }
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPublish_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
