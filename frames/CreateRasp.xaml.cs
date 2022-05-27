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
using elj.windows;

namespace elj.frames
{
    /// <summary>
    /// Логика взаимодействия для CreateRasp.xaml
    /// </summary>
    public partial class CreateRasp : Page
    {
        public CreateRasp()
        {
             InitializeComponent();
            Update();


            List<string> Kourse = new List<string>();

            Kourse.Add("1");
            Kourse.Add("2");
            Kourse.Add("3");
            Kourse.Add("4");
            Kourse.Add("5");



            var grp = context.StudGroup.ToList();
            //grp.Add();

           
            groups_cb.ItemsSource = grp;
        }
        private void Update()
        {
            raspGrid.ItemsSource = context.Shedule.ToList();
           // dayweek.ItemsSource = context.WeekDay.Select(c => c.nameDay).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspAdd raspAdd = new RaspAdd();
            raspAdd.ShowDialog();
        }
    }
}
