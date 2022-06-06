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
    /// Логика взаимодействия для GroupAdd.xaml
    /// </summary>
    public partial class GroupAdd : Window
    {
        public GroupAdd()
        {
            InitializeComponent();
            spec_cb.ItemsSource = context.Speciality.ToList();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {            
            var execgroup = context.StudGroup.Where(i => i.groupName == titlespec.Text)
                .FirstOrDefault();
            if (execgroup == null)
            {
                context.StudGroup.Add(new appdata.StudGroup
                {
                    groupName = titlespec.Text,
                    specialty = spec_cb.SelectedIndex+1,
                    course = 1
                    
                });
                context.SaveChanges();
                    MessageBox.Show("Группа создана.");
                    titlespec.Text = string.Empty;
                    spec_cb.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Такая группа уже сущетвует");
            }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка сохранения.");
            }
        }
    }
}
