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
                var SRlines = streamReader.ReadToEnd();
                streamReader.Close();
                tbcircle.Text = SRlines;

                LastNameUser.listOffile = Directory.GetFiles("Source");
                foreach (string stringOffile in LastNameUser.listOffile)
                {
                    if (stringOffile.Contains($"{LastNameUser.CircleName}_File"))
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
        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Files (*.DOCX;*.DOCM;*.DOTX;*.DOTM)|*.DOCX;*.DOCM;*.DOTX;*.DOTM";
            if (openFileDialog.ShowDialog() == true)
            {
                LastNameUser.FileLink  = $"Source\\{LastNameUser.CircleName}_File{Path.GetExtension(openFileDialog.SafeFileName)}";
                File.Copy(openFileDialog.FileName, LastNameUser.FileLink);
                LastNameUser.stringoffile = LastNameUser.FileLink;
            }
            BtnOpen.Visibility = Visibility.Visible;

        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(LastNameUser.stringoffile);
        }

        private void borderdrop_Drop(object sender, DragEventArgs e)
        {
            try
            {               
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                LastNameUser.FileLink = $"Source\\{LastNameUser.CircleName}_File{Path.GetExtension(files[0])}";
                File.Copy(files[0], LastNameUser.FileLink);
                LastNameUser.stringoffile = LastNameUser.FileLink;
                BtnOpen.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
