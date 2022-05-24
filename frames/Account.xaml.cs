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
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        int Usrr;

        public Account(int a)
        {
            InitializeComponent();
            Usrr = a;
            Update();

        }
        private void Update()
        {
            if (auttch != null )
            {
                var userdataprep = context.Users.Where(i => i.idUser == Usrr).ToList();
                var position = context.Teacher.Where(i => i.idUser == Usrr).Select(c => c.Position).FirstOrDefault();
                
                string _nameprep = userdataprep.Select(c => c.fName).FirstOrDefault().ToString();
                string _patrprep = userdataprep.Select(c => c.patronim).FirstOrDefault().ToString();
                string _fnameprep = userdataprep.Select(c => c.lName).FirstOrDefault().ToString();
                string _posit =

                logBlk.Text = userdataprep.Select(c => c.login).FirstOrDefault();
                fioTxt.Text = $"{_nameprep} {_patrprep} {_fnameprep} | {position}";
                dobSt.Text = $"Дата рождения {userdataprep.Select(c => c.dateOfBirth.ToShortDateString()).FirstOrDefault()}";

            }
            else if (autst != null)
            {
                var userdata = context.Users.Where(i => i.idUser == Usrr).ToList();
                var usergroupid = context.Student.Where(i => i.idUser == Usrr).Select(c => c.studGroup).FirstOrDefault();
                string usergroup = context.StudGroup.Where(i => i.idGroup == usergroupid).Select(c => c.groupName).FirstOrDefault().ToString();


                string _name = userdata.Select(c => c.fName).FirstOrDefault().ToString();
                string _patr = userdata.Select(c => c.patronim).FirstOrDefault().ToString();
                string _fname = userdata.Select(c => c.lName).FirstOrDefault().ToString();

                logBlk.Text = userdata.Select(c => c.login).FirstOrDefault();
                fioTxt.Text = $"{_name} {_patr} {_fname} | студент группы {usergroup}";
                dobSt.Text = $"Дата рождения {userdata.Select(c => c.dateOfBirth.ToShortDateString()).FirstOrDefault()}";
            }


            //var userdata = context.Users.Where(i => i.idUser == Usrr).ToList();
            //var usergroupid = context.Student.Where(i => i.idUser == Usrr).Select(c => c.studGroup).FirstOrDefault();
            //string usergroup = context.StudGroup.Where(i => i.idGroup == usergroupid).Select(c => c.groupName).FirstOrDefault().ToString();


            //string _name = userdata.Select(c => c.fName).FirstOrDefault().ToString();
            //string _patr = userdata.Select(c => c.patronim).FirstOrDefault().ToString();
            //string _fname = userdata.Select(c => c.lName).FirstOrDefault().ToString();

            //logBlk.Text = userdata.Select(c => c.login).FirstOrDefault();
            //fioTxt.Text = $"{_name} {_patr} {_fname} | студент группы {usergroup}";
            //dobSt.Text = $"Дата рождения {userdata.Select(c => c.dateOfBirth.ToShortDateString()).FirstOrDefault()}";
        }

        
        
           
        
        

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            
            var userdata = context.Users.Where(i => i.idUser == Usrr).FirstOrDefault();
            userdata.login = logEdit.Text;
            logBlk.Text = logEdit.Text;
            userdata.password = pasEdit.Text;
            context.SaveChanges();
            MessageBox.Show("Данные обновлены");

            logBlk.Visibility = Visibility.Visible;
            logEdit.Visibility = Visibility.Collapsed;
            logBlk.Text = logEdit.Text;

            pasBlk.Visibility = Visibility.Visible;
            pasEdit.Visibility = Visibility.Collapsed;
            

            save_btn.Visibility = Visibility.Collapsed;
            edit_btn.Visibility = Visibility.Visible;
        }

        private void edit_btn_Click(object sender, RoutedEventArgs e)
        {
            logBlk.Visibility = Visibility.Collapsed;
            logEdit.Visibility = Visibility.Visible;
            logEdit.Text = logBlk.Text;

            var userdata = context.Users.Where(i => i.idUser == Usrr).ToList();
            pasBlk.Visibility = Visibility.Collapsed;
            pasEdit.Visibility = Visibility.Visible;
            pasEdit.Text = userdata.Select(c => c.password).FirstOrDefault();

            save_btn.Visibility = Visibility.Visible;
            edit_btn.Visibility = Visibility.Collapsed;

        }

        //private void savepd_btn_Click(object sender, RoutedEventArgs e)
        //{
        //    var userdata = DBapp.context.Users.Where(i => i.idUser == Usrr).FirstOrDefault();
        //    userdata.login = logEdit.Text;
        //    logBlk.Text = logEdit.Text;
        //    userdata.password = pasEdit.Text;
        //    DBapp.context.SaveChanges();
        //    MessageBox.Show("Данные обновлены");

        //    logBlk.Visibility = Visibility.Visible;
        //    logEdit.Visibility = Visibility.Collapsed;
        //    logBlk.Text = logEdit.Text;

        //    pasBlk.Visibility = Visibility.Visible;
        //    pasEdit.Visibility = Visibility.Collapsed;


        //    save_btn.Visibility = Visibility.Collapsed;
        //    edit_btn.Visibility = Visibility.Visible;
        //}
    }
}
