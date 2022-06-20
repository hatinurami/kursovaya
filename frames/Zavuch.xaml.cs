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
    /// Логика взаимодействия для Zavuch.xaml
    /// </summary>
    public partial class Zavuch : Page
    {
        
        public Zavuch()
        {
            InitializeComponent();
           
          
            Update();
            studVis.IsChecked = true;
            infoGridStudents.Visibility = Visibility.Visible;
            infoGridPrepod.Visibility = Visibility.Collapsed;
            prepGB.Visibility = Visibility.Collapsed;
            studentGB.Visibility = Visibility.Visible;
            //cb_Group.SelectedIndex = 0;
            //cb_Kurs.SelectedIndex = 0;
            //cb_Status.SelectedIndex = 0;

        }


        private void Update()
        {  
            Comboboxes();
            infoGridPrepod.ItemsSource = context.TeachSubject.ToList();
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
            Kourse.Add("Все");
            Kourse.Add("1");
            Kourse.Add("2");
            Kourse.Add("3");
            Kourse.Add("4");
            Kourse.Add("5");



            var grp = context.StudGroup.ToList();
            cb_Group.Items.Add("Все");
            foreach (var item in grp)
            {
                cb_Group.Items.Add(item.groupName);
            }


            //cb_Group.ItemsSource = grp;
            var pos = context.Position.ToList();
            cb_Position.Items.Add("Все");
            foreach (var item in pos)
            {
                cb_Position.Items.Add(item.position1);
            }
            
            cb_Status.ItemsSource = Status;
            cb_Kurs.ItemsSource = Kourse;

            var subj = context.Subject.ToList();
            cb_Subj.Items.Add("Все");
            foreach (var item in subj)
            {
                cb_Subj.Items.Add(item.subjectname);
            }
           
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

        private void addGroup_Click(object sender, RoutedEventArgs e)
        {            
                GroupAdd add = new GroupAdd();
                add.ShowDialog();   
        }

        private void cb_Group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int cbk = -1;
            //string cbs = null;
            //string cbg = null;

            int cbk = cb_Kurs.SelectedIndex;
            int cbs = cb_Status.SelectedIndex;
                //cb_Status.SelectedValue.ToString();
            string cbg = cb_Group.SelectedValue.ToString();
            if (cbs == 0 && cbk == 0 && cbg == "Все")
            {     
                infoGridStudents.ItemsSource = context.Student.ToList();
            }
            else if (cbk == 0 && cbs == 0 && cbg != "Все")
            {
              //  cbg = cb_Group.SelectedValue.ToString();
               
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.groupName == cbg).ToList();
            }
            else if (cbk == 0 && cbs != 0 && cbg != "Все")
            {

                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.groupName == cbg && i.status == cb_Status.SelectedValue.ToString()).ToList();

            }
            else if (cbk != 0 && cbs == 0 && cbg != "Все")
            {

                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk).ToList();

            }
            else if (cbk != 0 && cbs != 0 && cbg != "Все")
            {
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cb_Status.SelectedValue.ToString()).ToList();
            }


        }

        private void cb_Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cbk = cb_Kurs.SelectedIndex;
            int cbs = cb_Status.SelectedIndex;
            string cbg = cb_Group.SelectedValue.ToString();
            if (cbs == 0 && cbk == 0 && cbg == "Все")
            {
                infoGridStudents.ItemsSource = context.Student.ToList();
            }
            else if (cbk == 0 && cbs != 0 && cbg == "Все")
            {
                //  cbg = cb_Group.SelectedValue.ToString();
               // string stat = cb_Status.SelectedValue.ToString();
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.status == cb_Status.SelectedValue.ToString()).ToList();
            }
            else if (cbk == 0 && cbs != 0 && cbg != "Все")
            {

                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.groupName == cbg && i.status == cb_Status.SelectedValue.ToString()).ToList();

            }
            else if (cbk != 0 && cbs != 0 && cbg == "Все")
            {

                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.course == cbk && i.status == cb_Status.SelectedValue.ToString()).ToList();

            }
            else if (cbk != 0 && cbs != 0 && cbg != "Все")
            {
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cb_Status.SelectedValue.ToString()).ToList();
            }
        }

        private void cb_Kurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int cbk = cb_Kurs.SelectedIndex;
            int cbs = cb_Status.SelectedIndex;
            string cbg = cb_Group.SelectedValue.ToString();
            
                
           
           
            if (cbs == 0 && cbk == 0 && cbg == "Все")
            {
                infoGridStudents.ItemsSource = context.Student.ToList();
            }
            else if (cbk != 0 && cbs == 0 && cbg == "Все")
            {
               
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.course == cbk).ToList();
            }
            else if (cbk != 0 && cbs == 0 && cbg != "Все")
            {
                //var newgrp = context.StudGroup.Where(i => i.course == cbk).ToList();
                //cb_Group.Items.Clear();
                //cb_Group.Items.Add("Все");
                //foreach (var item in newgrp)
                //{
                //    cb_Group.Items.Add(item.groupName);
                //}
                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk).ToList();

            }
            else if (cbk != 0 && cbs != 0 && cbg == "Все")
            {
                //    cb_Group.Items.Clear();
                //var newgrp = context.StudGroup.Where(i => i.course == cbk).ToList();
                //cb_Group.Items.Add("Все");
                //foreach (var item in newgrp)
                //{
                //    cb_Group.Items.Add(item.groupName);
                //}
                infoGridStudents.ItemsSource = context.Student.
                     Where(i => i.StudGroup1.course == cbk && i.status == cb_Status.SelectedValue.ToString()).ToList();

            }
            else if (cbk != 0 && cbs != 0 && cbg != "Все")
            {
                //    cb_Group.Items.Clear();
                //var newgrp = context.StudGroup.Where(i => i.course == cbk).ToList();
                //cb_Group.Items.Add("Все");
                //foreach (var item in newgrp)
                //{
                //    cb_Group.Items.Add(item.groupName);
                //}
                infoGridStudents.ItemsSource = context.Student.
                      Where(i => i.StudGroup1.groupName == cbg && i.StudGroup1.course == cbk && i.status == cb_Status.SelectedValue.ToString()).ToList();
            }
        }

        private void cb_Position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cbp = cb_Position.SelectedIndex;
            int cbs = cb_Subj.SelectedIndex;

            if (cbp == 0 && cbs == 0 )
            {
                infoGridPrepod.ItemsSource = context.TeachSubject.ToList();
            }
            else if (cbp != 0 && cbs == 0)
            {
                infoGridPrepod.ItemsSource = context.TeachSubject.Where(i=>i.Teacher.idPosition == cbp).ToList();
            }
            else if (cbp == 0 && cbs != 0)
            {
                //var prepid = context.TeachSubject.Where(q => q.idSubj == cbs).Select(w => w.idTeach).FirstOrDefault();
                infoGridPrepod.ItemsSource = context.TeachSubject.Where(i => i.idSubj == cbs).ToList();
            }
            else if (cbp != 0 && cbs != 0)
            {
                //var prepid = context.TeachSubject.Where(q => q.idSubj == cbs).Select(w => w.idTeach).FirstOrDefault();
                infoGridPrepod.ItemsSource = context.TeachSubject.Where(i => i.idSubj == cbs && i.Teacher.idPosition == cbp).ToList();

            }


        }

        private void cb_Subj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cbp = cb_Position.SelectedIndex;
            int cbs = cb_Subj.SelectedIndex;

            if (cbp == 0 && cbs == 0)
            {
                infoGridPrepod.ItemsSource = context.TeachSubject.ToList();
            }
            else if (cbp != 0 && cbs == 0)
            {
                infoGridPrepod.ItemsSource = context.TeachSubject.Where(i => i.Teacher.idPosition == cbp).ToList();
            }
            else if (cbp == 0 && cbs != 0)
            {
                //var prepid = context.TeachSubject.Where(q => q.idSubj == cbs).Select(w => w.idTeach).FirstOrDefault();
                infoGridPrepod.ItemsSource = context.TeachSubject.Where(i => i.idSubj == cbs).ToList();
            }
            else if (cbp != 0 && cbs != 0)
            {
                //var prepid = context.TeachSubject.Where(q => q.idSubj == cbs).Select(w => w.idTeach).FirstOrDefault();
                infoGridPrepod.ItemsSource = context.TeachSubject.Where(i => i.idSubj == cbs && i.Teacher.idPosition == cbp).ToList();

            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
