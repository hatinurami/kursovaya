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
            if (cb_Group.SelectedItem != null)
            {
                cb_Kurs.IsEnabled = false;
                int filtr_gr = cb_Group.SelectedIndex +1;
                infoGridStudents.ItemsSource = context.Student.Where(i => i.studGroup == filtr_gr).ToList();
                if (cb_Status.SelectedItem != null)
                {
                    string filtr_statis = cb_Status.SelectedValue.ToString();
                    infoGridStudents.ItemsSource = context.Student.
                        Where(i => i.studGroup == filtr_gr && i.status == filtr_statis).ToList();
                }

            }


            
            
            
            
            
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
            grp.Add("fgddfg");


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
    }
}
