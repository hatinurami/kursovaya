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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            Update();
            studVis.IsChecked = true;

            infoGridStudents.Visibility = Visibility.Visible;
            infoGridPrepod.Visibility = Visibility.Collapsed;
            
        }
        private void Update()
        {
            //Filtr();         
            infoGridPrepod.ItemsSource = context.Teacher.ToList();
            infoGridStudents.ItemsSource = context.Student.ToList();

        }

        private void prepVis_Click(object sender, RoutedEventArgs e)
        {
            infoGridPrepod.Visibility = Visibility.Visible;
            infoGridStudents.Visibility = Visibility.Collapsed;
           
        }

        private void studVis_Click(object sender, RoutedEventArgs e)
        {
            infoGridStudents.Visibility = Visibility.Visible;
            infoGridPrepod.Visibility = Visibility.Collapsed;
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            UserAdd add = new UserAdd();
            add.ShowDialog();
        }

        //private void cb_FILTER_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Filtr();
        //}

        //private void Filtr()
        //{


        //    if (cb_Group.SelectedItem != null || cb_Kurs.SelectedItem != null || cb_Status.SelectedItem != null)
        //    {

        //        int filtr_gr = cb_Group.SelectedItem != null ? cb_Group.SelectedIndex + 1 : 0;
        //        int filtr_krs = cb_Kurs.SelectedItem != null ? cb_Kurs.SelectedIndex + 1 : 0;
        //        string filtr_statis = cb_Status.SelectedItem != null ? cb_Status.SelectedValue.ToString() : null;

        //        if (filtr_gr != 0)
        //        {
        //            infoGridStudents.ItemsSource = context.Student.
        //              Where(i => i.studGroup == filtr_gr);
        //            if (filtr_krs != 0)
        //            {
        //                infoGridStudents.ItemsSource = context.Student.
        //              Where(i => i.StudGroup1.course == filtr_krs && i.studGroup == filtr_gr);
        //                if (filtr_statis != null)
        //                {
        //                    infoGridStudents.ItemsSource = context.Student.
        //              Where(i => i.StudGroup1.course == filtr_krs && i.studGroup == filtr_gr && i.status == filtr_statis);
        //                }
        //            }
        //        }

        //    }
        //}
    }
}

