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
    /// Логика взаимодействия для PageRasp.xaml
    /// </summary>
    public partial class PageRasp : Page
    {
        private int GroupSt;
        public PageRasp(int a)
        {
            InitializeComponent();
            GroupSt = a;
            Update();
        }

        private void Update()
        {
            ob = context.RaspGroup(GroupSt).ToList();
            RaspAdd();

        }
        private void RaspAdd()
        {
            listRasp.ItemsSource = ob.Where(i => i.Day == titleDay.Content.ToString()).ToList();
            listRasp1.ItemsSource = ob.Where(i => i.Day == titleDay1.Content.ToString()).ToList();
            listRasp2.ItemsSource = ob.Where(i => i.Day == titleDay2.Content.ToString()).ToList();
            listRasp3.ItemsSource = ob.Where(i => i.Day == titleDay3.Content.ToString()).ToList();
            listRasp4.ItemsSource = ob.Where(i => i.Day == titleDay4.Content.ToString()).ToList();
            listRasp5.ItemsSource = ob.Where(i => i.Day == titleDay5.Content.ToString()).ToList();
        }

       
    }
}
