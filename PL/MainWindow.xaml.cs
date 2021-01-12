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
            userPassShow.Visibility = Visibility.Hidden;
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            Management management = new Management(bl);
            management.Left = this.Left;
            management.Top = this.Top;
            management.Show();

        }

        private void showPass_Checked(object sender, RoutedEventArgs e)
        {
            userPass.Visibility = Visibility.Hidden;
            userPassShow.Visibility = Visibility.Visible;
            userPassShow.Text = userPass.Password;
        }

        private void showPass_Unchecked(object sender, RoutedEventArgs e)
        {
            userPass.Visibility = Visibility.Visible;
            userPassShow.Visibility = Visibility.Hidden;
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(bl);
            userWindow.Left = this.Left;
            userWindow.Top = this.Top;
            userWindow.Show();
        }
    }
}
