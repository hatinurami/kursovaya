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
using elj.frames;

namespace elj.windows
{
    /// <summary>
    /// Логика взаимодействия для Teacher.xaml
    /// </summary>
    public partial class Teacher : Window
    {
        public Teacher(int a)
        {
            InitializeComponent();
            int idTh = appdata.DBapp.auttch.TeachSubject.Select(c => c.idTeach).FirstOrDefault();
            mainFrame.Navigate(new TeachPage(idTh));
            CalendarWind();
        }

        private void journl_Click(object sender, RoutedEventArgs e)
        {
            int idTh = appdata.DBapp.auttch.TeachSubject.Select(c => c.idTeach).FirstOrDefault();
            mainFrame.Navigate(new TeachPage(idTh));
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
        private void extClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
