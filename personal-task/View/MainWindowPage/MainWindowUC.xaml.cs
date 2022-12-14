using personal_task.Core;
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
    /// Логика взаимодействия для MainWindowUC.xaml
    /// </summary>
    public partial class MainWindowUC : UserControl
    {
        public MainWindowUC()
        {
            InitializeComponent();
            switch(LastNameUser.CircleName)
            {
                case "C#":
                    tbCircleName.Text = "C#";
                    break;
                case "WPF":
                    tbCircleName.Text = "WPF";
                    break;
                case "C++":
                    tbCircleName.Text = "C++";
                    break;

            }
        }
    }
}
