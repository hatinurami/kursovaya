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
using elj.appdata;
using elj.windows;

namespace elj.frames
{
    /// <summary>
    /// Логика взаимодействия для Zavuch.xaml
    /// </summary>
    public partial class Zavuch : Page
    {
        
        public Zavuch()
        {
            InitializeComponent();
            Comboboxes();
            Update();
            studVis.IsChecked = true;
            infoGridStudents.Visibility = Visibility.Visible;
            infoGridPrepod.Visibility = Visibility.Collapsed;
            prepGB.Visibility = Visibility.Collapsed;
            studentGB.Visibility = Visibility.Visible;

        }


        private void Update()
        {   
            //Filtr();         
            infoGridPrepod.ItemsSource = context.Teacher.ToList();
            infoGridStudents.ItemsSource = context.Student.ToList();
            
        }

        private void Filtr()
        {


            if (cb_Group.SelectedItem != null || cb_Kurs.SelectedItem != null || cb_Status.SelectedItem != null)
            {

                int filtr_gr = cb_Group.SelectedItem != null ? cb_Group.SelectedIndex + 1 : 0 ;
                int filtr_krs = cb_Kurs.SelectedItem != null ? cb_Kurs.SelectedIndex + 1 : 0 ;
                string filtr_statis = cb_Status.SelectedItem != null ? cb_Status.SelectedValue.ToString() : null;

                if (filtr_gr != 0)
                {
                    infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.studGroup == filtr_gr);
                    if (filtr_krs != 0)
                    {
                        infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.course == filtr_krs && i.studGroup == filtr_gr);
                        if (filtr_statis != null)
                        {
                            infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.course == filtr_krs && i.studGroup == filtr_gr && i.status == filtr_statis);
                        }
                    }
                }

            }



        }
        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            UserAdd add = new UserAdd();
            add.ShowDialog();
        }

        private void Comboboxes()
        {
            List<string> Status = new List<string>();
           
            Status.Add("обучается");
            Status.Add("отчислен");
            Status.Add("академический отпуск");

            List<string> Kourse = new List<string>();
           
            Kourse.Add("1");
            Kourse.Add("2");
            Kourse.Add("3");
            Kourse.Add("4");
            Kourse.Add("5");



            var grp = context.StudGroup.ToList();
            //grp.Add();


            cb_Group.ItemsSource = grp;
            cb_Position.ItemsSource = context.Position.ToList();
            cb_Status.ItemsSource = Status;
            cb_Kurs.ItemsSource = Kourse;
            cb_Subj.ItemsSource = context.Subject.ToList();
           
        }


        private void nLef_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nRig_Click(object sender, RoutedEventArgs e)
        {

        }

        private void prepVis_Click(object sender, RoutedEventArgs e)
        {
            infoGridPrepod.Visibility = Visibility.Visible;
            infoGridStudents.Visibility = Visibility.Collapsed;
            prepGB.Visibility = Visibility.Visible;
            studentGB.Visibility = Visibility.Collapsed;
        }

        private void studVis_Click(object sender, RoutedEventArgs e)
        {
            infoGridStudents.Visibility = Visibility.Visible;
            infoGridPrepod.Visibility = Visibility.Collapsed;
            prepGB.Visibility = Visibility.Collapsed;
            studentGB.Visibility = Visibility.Visible;
        }

        private void cb_FILTER_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtr();
        }

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {
            
                GroupAdd add = new GroupAdd();
                add.ShowDialog();
            
        }

    }
}
