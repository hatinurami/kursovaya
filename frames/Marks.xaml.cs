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
    /// Логика взаимодействия для Marks.xaml
    /// </summary>
    public partial class Marks : Page
    {
        int StudentID;
        public Marks(int a)
        {
            InitializeComponent();
            StudentID = a;
            Update();
        }
        private void Update()
        {
            msr = context.MarkStud(StudentID).ToList();
            MarkGrid.ItemsSource = msr;

            var columns = msr.Select(i => i.Дисциплина).Distinct().ToList();

            foreach (var item in columns)
            {
               // MarkGrid.Columns.Add(new DataGridColumn());
            }
            

        }
    }
}
