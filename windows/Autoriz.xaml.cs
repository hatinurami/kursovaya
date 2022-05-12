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
using static elj.appdata.DBapp;


namespace elj.windows
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Window
    {
        public Autoriz()
        {
            InitializeComponent();
        }

        private void entBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var log = context.Users.ToList().
                    Where(i => logTxt.Text == i.login && pasPbx.Password == i.password).FirstOrDefault();

                if (log != null)
                {
                    var stdAut = context.Student.ToList().
                        Where(j => log.idUser == j.idUser);

                    var prepAut = context.Teacher.ToList().
                        Where(j => log.idUser == j.idUser);

                    if (stdAut != null)
                    {
                        autst = stdAut.FirstOrDefault();
                        int stGr = Convert.ToInt32(autst.studGroup);
                        MainWindow main = new MainWindow(stGr);
                        main.ShowDialog();
                    }
                    else if (prepAut != null)
                    {
                        auttch = prepAut.FirstOrDefault();
                        int idTS = Convert.ToInt32(context.TeachSubject.
                            Where(i=> i.idTeach == auttch.idTeach));
                        MainWindow main = new MainWindow(idTS);
                        main.ShowDialog();
                    }
                }
                else
                {
                    if (logTxt.Text == null || pasPbx == null)
                        MessageBox.Show("заполните поля!");
                   
                    MessageBox.Show("ой");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
               
            }


        }


        private void extBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            logTxt.Text = logTxt.Text.Replace(" ", string.Empty);
            logTxt.SelectionStart = logTxt.Text.Length;

            
            
        }

        
    }


}

