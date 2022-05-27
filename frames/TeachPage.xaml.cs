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
using static elj.appdata.DBapp;

namespace elj.frames
{
    /// <summary>
    /// Логика взаимодействия для TeachPage.xaml
    /// </summary>
    public partial class TeachPage : Page
    {
        int PrepId; 
        public TeachPage(int a)
        {
            InitializeComponent();
            PrepId = a;
            markwin.ItemsSource = context.StudentPerfomance.ToList();
        }

    }
}
