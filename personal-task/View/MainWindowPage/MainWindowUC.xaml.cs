using Microsoft.Win32;
using personal_task.Core;
using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace personal_task.View.MainWindowPage
{
    /// <summary>
    /// Логика взаимодействия для MainWindowUC.xaml
    /// </summary>
    public partial class MainWindowUC : UserControl
    {
        public MainWindowUC()
        {
            InitializeComponent();

        }

        private void BtnFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPublish_Click(object sender, RoutedEventArgs e)
        {
         
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
    }
}
