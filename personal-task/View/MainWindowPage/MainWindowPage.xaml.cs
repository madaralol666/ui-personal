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
            ItemsControlInfo.ItemsSource = FrameNavigate.DB.Users.Where(u => u.LastName == Transfer.lastName).ToList();            
            LBMenu.ItemsSource = FrameNavigate.DB.UserCircles.Where(u => u.User.LastName == Transfer.lastName).ToList();

            if (Transfer.RoleName == "Student")
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
            if (Transfer.RoleName != "Student")
            {
                BtnFile.Visibility = Visibility.Visible;
            }
            if ((LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim() != null)
            {
                Transfer.SourceLink = $"source\\FileDescription{(LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim()}.txt";
                
                if (File.Exists(Transfer.SourceLink) == false)
                {
                        Transfer.templink = Path.GetDirectoryName(Transfer.SourceLink);
                        Directory.CreateDirectory(Transfer.templink);
                        File.Create(Transfer.SourceLink).Close();
                }

                Transfer.CircleName = (LBMenu.SelectedItem as UserCircle).Circle.CircleName.Trim();
                tbCircleName.Text = $"Задание {Transfer.CircleName}";
                StreamReader streamReader = new StreamReader(Transfer.SourceLink);
                var SRlines = streamReader.ReadToEnd();
                streamReader.Close();
                tbcircle.Text = SRlines;

                Transfer.listOffile = Directory.GetFiles("Source");
                foreach (string stringOffile in Transfer.listOffile)
                {
                    if (stringOffile.Contains($"{Transfer.CircleName}_File"))
                    {
                        BtnOpen.Visibility = Visibility.Visible;
                        Transfer.stringoffile = stringOffile;
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
            if (File.Exists(Transfer.SourceLink))
            {
                Transfer.templink = System.IO.Path.GetDirectoryName(Transfer.SourceLink);
                Directory.CreateDirectory(Transfer.templink);
                File.Create(Transfer.SourceLink).Close();

                StreamWriter SWCSharp = new StreamWriter(Transfer.SourceLink, true);
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
                Transfer.FileLink  = $"Source\\{Transfer.CircleName}_File{Path.GetExtension(openFileDialog.SafeFileName)}";
                File.Copy(openFileDialog.FileName, Transfer.FileLink);
                Transfer.stringoffile = Transfer.FileLink;
            }
            BtnOpen.Visibility = Visibility.Visible;

        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(Transfer.stringoffile);
        }

        private void borderdrop_Drop(object sender, DragEventArgs e)
        {
            try
            {               
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                Transfer.FileLink = $"Source\\{Transfer.CircleName}_File{Path.GetExtension(files[0])}";
                File.Copy(files[0], Transfer.FileLink);
                Transfer.stringoffile = Transfer.FileLink;
                BtnOpen.Visibility = Visibility.Visible;
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
