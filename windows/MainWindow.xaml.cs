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
using elj.frames;

namespace elj.windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int usrgr;
        public MainWindow(int a)
        {
            usrgr = a;
            InitializeComponent();
            mainFrame.Navigate(new PageRasp(usrgr));

        }

        private void extClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRasp_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PageRasp(usrgr));
        }

        private void btnMark_Click(object sender, RoutedEventArgs e)
        {
            int idSt = appdata.DBapp.autst.idStud;
            mainFrame.Navigate(new Marks(idSt));
        }

        private void btnKab_Click(object sender, RoutedEventArgs e)
        {
            int idUs = appdata.DBapp.autst.Users.idUser;
            mainFrame.Navigate(new Account(idUs));
        }
    }
}
