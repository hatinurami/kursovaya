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
    /// Логика взаимодействия для UserAdd.xaml
    /// </summary>
    public partial class UserAdd : Window
    {
        public UserAdd()
        {
            InitializeComponent();
            type_cb.SelectedIndex = 0;
            CB_Items();
        }

        private void CB_Items()
        {
            group_cb.ItemsSource = context.StudGroup.ToList();
            position_cb.ItemsSource = context.Position.ToList();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
           
            if(name_tb.Text == string.Empty ||
                lname_tb.Text == string.Empty ||
                patr_tb.Text == string.Empty ||
                dateofb_dp.Text == string.Empty ||
                (genM_rb.IsChecked == false && genW_gb.IsChecked == false) ||
                (group_cb.SelectedIndex == -1 && position_cb.SelectedIndex == -1)||
                lod_tb.Text == string.Empty||
                pass_tb.Text == string.Empty)
            {

                MessageBox.Show("Введите все данные.");
            }
            else
            {
                AddUser();
            }

        }

        private void AddUser()
        {
            try
            {

                var execuser = context.Users.Where(i => i.login == lod_tb.Text).FirstOrDefault();

                if (execuser == null)
                {
                    int gender = 0;
                    if (genM_rb.IsChecked == true)
                        gender = 2;
                    else if (genW_gb.IsChecked == true)
                        gender = 1;
                    context.Users.Add(new appdata.Users
                    {
                        fName = name_tb.Text,
                        lName = lname_tb.Text,
                        patronim = patr_tb.Text,
                        dateOfBirth = dateofb_dp.SelectedDate ?? DateTime.MinValue,
                        login = lod_tb.Text,
                        password = pass_tb.Text,
                        idGender = gender
                    }
                        );

                    context.SaveChanges();
                    if (type_cb.SelectedIndex == 0)
                    {

                        context.Student.Add(new appdata.Student
                        {
                            idUser = context.Users.Where(i => i.login == lod_tb.Text).Select(c => c.idUser).FirstOrDefault(),
                            studGroup = group_cb.SelectedIndex + 1,
                            status = "обучается"

                        });
                        context.SaveChanges();
                    }
                    else if (type_cb.SelectedIndex == 1)
                    {

                        context.Teacher.Add(new appdata.Teacher
                        {
                            idUser = context.Users.Where(i => i.login == lod_tb.Text).Select(c => c.idUser).FirstOrDefault(),
                            idPosition = position_cb.SelectedIndex + 1,
                            workExperience = 0
                        });
                        context.SaveChanges();
                    }

                    MessageBox.Show("Запись добавлена");


                    name_tb.Text = string.Empty;
                    lname_tb.Text = string.Empty;
                    patr_tb.Text = string.Empty;
                    dateofb_dp.Text = string.Empty;
                    genM_rb.IsChecked = false;
                    genW_gb.IsChecked = false;
                    group_cb.SelectedIndex = -1;
                    position_cb.SelectedIndex = -1;
                    lod_tb.Text = string.Empty;
                     pass_tb.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show("Пользователь с таким логином уже существует! Проверьте введённые данные.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            catch (Exception)
            {

                MessageBox.Show("Ошибка сохранения");
            }
        }

        private void type_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (type_cb.SelectedIndex == 0)
            {
                group_tb.Visibility = Visibility.Visible;
                group_cb.Visibility = Visibility.Visible;
                posit_tb.Visibility = Visibility.Collapsed;
                position_cb.Visibility = Visibility.Collapsed;
            }
            else
            {
                group_tb.Visibility = Visibility.Collapsed;
                group_cb.Visibility = Visibility.Collapsed;
                posit_tb.Visibility = Visibility.Visible;
                position_cb.Visibility = Visibility.Visible;
            }
        }
    }
}
