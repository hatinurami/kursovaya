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
                        Where(j => log.idUser == j.idUser).FirstOrDefault();
                    //var stdAut = context.

                    var prepAut = context.Teacher.ToList().
                        Where(j => log.idUser == j.idUser).FirstOrDefault();

                    if (stdAut != null)
                    {
                        autst = stdAut;
                        int stGr = Convert.ToInt32(autst.studGroup);
                        MainWindow main = new MainWindow(stGr);
                        Close();
                        main.ShowDialog();
                    }
                    else if (prepAut != null)
                    {
                        auttch = prepAut;
                        if (auttch.Position.idPos == 1)
                        {
                            int idTS = context.Teacher.
                            Where(i => i.idTeach == auttch.idTeach).Select(c => c.idTeach).FirstOrDefault();
                            ZavWin main = new ZavWin(idTS);
                            Close();
                            main.ShowDialog();
                        }
                        else 
                        {
                            int idTS = Convert.ToInt32(context.TeachSubject.
                            Where(i=> i.idTeach == auttch.idTeach).Select(c => c.idTeach));
                            Close();
                            MainWindow main = new MainWindow(idTS);
                            main.ShowDialog();
                        }           
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

