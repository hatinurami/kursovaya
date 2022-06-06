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
using elj.classFunc;
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

            cb_Status.SelectedIndex = 0;
            cb_Group.SelectedIndex = 0;
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

        
        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            UserAdd add = new UserAdd();
            add.ShowDialog();
        }

        private void Comboboxes()
        {
            List<string> Status = new List<string>();

            Status.Add("Все");
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

        //private void cb_FILTER_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    Filtr();
        //}

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {
            
                GroupAdd add = new GroupAdd();
                add.ShowDialog();
            
        }

        private void cb_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* чтоб не мешалось делать другие фильтры
             
            int cbk = cb_Kurs.SelectedIndex;
            string cbs = cb_Status.SelectedValue.ToString();
            string cbg = cb_Group.SelectedValue.ToString();
            if (cbs == "Все" && cbk == -1)
            {       
                infoGridStudents.ItemsSource = context.Student.
                       Where(i => i.StudGroup1.groupName == cbg).ToList();
            }
            else if (cbk != -1 && cbs == "Все")
            {
                
                cbk = cb_Kurs.SelectedIndex +1;
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk).ToList();
            }
            else if (cbk == -1 && cbs !="Все" )
            {
                cbs = cb_Status.SelectedValue.ToString();
                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.groupName == cbg && i.status == cbs.ToString()).ToList();

            }
            else
            {
                cbk = cb_Kurs.SelectedIndex + 1;
                cbs = cb_Status.SelectedValue.ToString();
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cbs.ToString()).ToList();
            }

            */
        }

        private void cb_Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cbk = cb_Kurs.SelectedIndex;
            string cbs = cb_Status.SelectedValue.ToString();
            string cbg = cb_Group.SelectedValue.ToString();
            if (cbg == null && cbk == -1)
            {
                infoGridStudents.ItemsSource = context.Student.
                       Where(i => i.status == cbs).ToList();
            }
            else if (cbk != -1 && cbg == null)
            {
                cbk = cb_Kurs.SelectedIndex + 1;
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.status == cbs && i.StudGroup1.course == cbk).ToList();
            }
            else if (cbk == -1 && cbg != null)
            {
                cbg = cb_Group.SelectedItem.ToString();
                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.groupName == cbg && i.status == cbs.ToString()).ToList();

            }
            //else
            //{
            //    cbk = cb_Kurs.SelectedIndex + 1;
            //    cbs = cb_Status.SelectedValue.ToString();
            //    infoGridStudents.ItemsSource = context.Student.
            //          Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cbs.ToString()).ToList();
            //}
        }

        private void cb_Kurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int cbk = 0;
            //string cbs = null;
            //int cbg = 0;

            //var cbk = cb_Kurs.SelectedIndex + 1;
            //string cbs = null;
            //string cbg = null;

            //cb_Group.ItemsSource = context.StudGroup.Where(i=> i.course == cbk).ToList();
            //if (cbs == null && cbk != -1 && cbg == null)
            //{
            //     //cbk = cb_Kurs.SelectedIndex + 1;
            //     //cbs = cb_Status.SelectedValue.ToString();
            //     //cbg = cb_Group.SelectedIndex + 1;
                
            //    infoGridStudents.ItemsSource = context.Student.
            //          Where(i => i.StudGroup1.course == cbk).ToList();
            //}
            //else if (cbs != null && cbg == null)
            //{
            //    cbg = cb_Group.SelectedItem.ToString();
            //    cbs = cb_Status.SelectedValue.ToString();
            //    infoGridStudents.ItemsSource = context.Student.
            //          Where(i => i.status == cbs && i.StudGroup1.course == cbk).ToList();
            //}
            //else if (cbg != null && cbk != -1 && cbs != null)
            //{
            //    cbs = cb_Status.SelectedValue.ToString();
            //    infoGridStudents.ItemsSource = context.Student.
            //          Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cbs).ToList();
            //}
        }

        private void cb_Position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_Subj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
