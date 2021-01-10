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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            Management management = new Management(bl);
            management.Show();
            //Manager manager = new Manager(bl);
            //manager.Show();
        }

        private void showPass_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void showPass_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
