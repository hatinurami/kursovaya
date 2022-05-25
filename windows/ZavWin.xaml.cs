using elj.frames;
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
using System.Windows.Shapes;

namespace elj.windows
{
    /// <summary>
    /// Логика взаимодействия для ZavWin.xaml
    /// </summary>
    public partial class ZavWin : Window
    {
        public ZavWin(int a)
        {
            InitializeComponent();
            mainFrame.Navigate(new Zavuch());
            CalendarWind();
        }

       

        private void extClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void btnKab_Click(object sender, RoutedEventArgs e)
        {
            int idUs = appdata.DBapp.auttch.Users.idUser;
            mainFrame.Navigate(new Account(idUs));

        }

        private void CalendarWind()
        {
            DateTime date = DateTime.Today;
            numdayTB.Text = date.Day.ToString();
            monTB.Text = date.ToString("MMMM");
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Zavuch());
        }

        private void btnZRasp_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new CreateRasp());
        }
    }
}
