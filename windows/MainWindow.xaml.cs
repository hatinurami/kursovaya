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
using elj.frames;

namespace elj.windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
#pragma warning disable CS0103 // Имя "InitializeComponent" не существует в текущем контексте.
            InitializeComponent();
#pragma warning restore CS0103 // Имя "InitializeComponent" не существует в текущем контексте.
#pragma warning disable CS0103 // Имя "mainFrame" не существует в текущем контексте.
            mainFrame.Navigate(new PageRasp());
#pragma warning restore CS0103 // Имя "mainFrame" не существует в текущем контексте.
        }

        private void extClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
