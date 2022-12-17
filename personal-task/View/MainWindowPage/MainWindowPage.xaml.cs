using Microsoft.Win32;
using personal_task.Core;
using personal_task.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

            if (LastNameUser.RoleName == "Student")
            {
                BtnFile.IsEnabled = false;
                BtnFile.Visibility = Visibility.Collapsed;
                tbcircle.IsReadOnly = true;
            }
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
            tbcircle.IsEnabled= true;
            if (LastNameUser.RoleName != "Student")
            {
                BtnFile.Visibility = Visibility.Visible;
            }
            if ((LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim() != null)
            {
                LastNameUser.SourceLink = $"source\\FileDescription{(LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim()}.txt";
                
                if (File.Exists(LastNameUser.SourceLink) == false)
                {
                    LastNameUser.templink = System.IO.Path.GetDirectoryName(LastNameUser.SourceLink);
                    Directory.CreateDirectory(LastNameUser.templink);
                    File.Create(LastNameUser.SourceLink).Close();
                }

                LastNameUser.CircleName = (LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim();
                tbCircleName.Text = $"Задание {LastNameUser.CircleName}";
                StreamReader streamReader = new StreamReader(LastNameUser.SourceLink);
                string test = streamReader.ReadToEnd();
                streamReader.Close();
                tbcircle.Text = test;

                LastNameUser.listOffile = Directory.GetFiles("Source");
                foreach (string stringOffile in LastNameUser.listOffile)
                {
                    if (stringOffile.Contains($"{LastNameUser.CircleName}File_"))
                    {
                        BtnOpen.Visibility = Visibility.Visible;
                        LastNameUser.stringoffile = stringOffile;
                        break;
                    }
                    else
                    {
                        BtnOpen.Visibility = Visibility.Collapsed;
                    }
                }

            }
        }

        private void tbcircle_TextChanged(object sender, TextChangedEventArgs e)
        {
            string rtbox = tbcircle.Text;
            if (File.Exists(LastNameUser.SourceLink))
            {
                LastNameUser.templink = System.IO.Path.GetDirectoryName(LastNameUser.SourceLink);
                Directory.CreateDirectory(LastNameUser.templink);
                File.Create(LastNameUser.SourceLink).Close();

                StreamWriter SWCSharp = new StreamWriter(LastNameUser.SourceLink, true);
                SWCSharp.WriteLine(String.Format(rtbox));
                SWCSharp.Close();

            }
/*            switch (LastNameUser.CircleName)
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


            }*/
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {
            foreach (string stringOflist in LastNameUser.listOffile)
            {
                if (stringOflist.Contains($"{LastNameUser.CircleName}File_"))
                {
                    File.Delete(stringOflist);
                    BtnOpen.Visibility = Visibility.Visible;
                }
                else
                {
                    BtnOpen.Visibility = Visibility.Visible;
                }
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Files (*.DOCX;*.DOCM;*.DOTX;*.DOTM)|*.DOCX;*.DOCM;*.DOTX;*.DOTM";
            if (openFileDialog.ShowDialog() == true)
            {
                LastNameUser.FileLink  = $"Source\\{LastNameUser.CircleName}File_{openFileDialog.SafeFileName}";
                File.Copy(openFileDialog.FileName, LastNameUser.FileLink);
                LastNameUser.stringoffile = LastNameUser.FileLink;
            }

        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(LastNameUser.stringoffile);
        }
    }
}
