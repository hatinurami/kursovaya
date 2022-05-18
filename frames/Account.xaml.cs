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
using elj.appdata;

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
            var userdata = DBapp.context.Users.Where(i => i.idUser == Usrr).ToList();
            var usergroupid = DBapp.context.Student.Where(i => i.idUser == Usrr).Select(c => c.studGroup).FirstOrDefault();
            string usergroup = DBapp.context.StudGroup.Where(i => i.idGroup == usergroupid).Select(c => c.groupName).FirstOrDefault().ToString();


            string _name = userdata.Select(c => c.fName).FirstOrDefault().ToString();
            string _patr = userdata.Select(c => c.patronim).FirstOrDefault().ToString();
            string _fname = userdata.Select(c => c.fName).FirstOrDefault().ToString();

            logBlk.Text = userdata.Select(c => c.login).FirstOrDefault();
            fioTxt.Text = $"{_name} {_patr} {_fname} | студент группы {usergroup}";

        }

        private void AddData()
        {
            
        }
        
           
        
        

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            var userdata = DBapp.context.Users.Where(i => i.idUser == Usrr).FirstOrDefault();
            userdata.login = logEdit.Text;
            logBlk.Text = logEdit.Text;
            userdata.password = pasEdit.Text;
            DBapp.context.SaveChanges();
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

            var userdata = DBapp.context.Users.Where(i => i.idUser == Usrr).ToList();
            pasBlk.Visibility = Visibility.Collapsed;
            pasEdit.Visibility = Visibility.Visible;
            pasEdit.Text = userdata.Select(c => c.password).FirstOrDefault();

            save_btn.Visibility = Visibility.Visible;
            edit_btn.Visibility = Visibility.Collapsed;

        }
    }
}
