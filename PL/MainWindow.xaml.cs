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
            managerPassShow.Visibility = Visibility.Hidden;
            userPassShow.Visibility = Visibility.Hidden;
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            BO.User manager = bl.getUser(managerName.Text);
            if (manager.password == managerPass.Password && manager.type == BO.Type.manager)
            {
                Management management = new Management(bl, manager);
                management.Left = this.Left;
                management.Top = this.Top;
                management.Show();
                
            }
            else
            {
                if (manager.type == BO.Type.user)
                    MessageBox.Show("oopps..\n you are not manager. you can try to sing up as user.");
                else
                    MessageBox.Show("userName or password is wrong. try again");
            }
            managerName.Text= "";
            managerPass.Password = "";
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
            BO.User user = bl.getUser(userName.Text);
            if (user.password == userPass.Password)
            {
                if(user.type == BO.Type.manager)
                    MessageBox.Show("you connection like user");
                UserWindow userWindow = new UserWindow(bl);
                userWindow.Left = this.Left;
                userWindow.Top = this.Top;
                userWindow.Show();
            }
            else
            {
                MessageBox.Show("userName or password is wrong. try again");
            }
            managerName.Text = "";
            managerPass.Password = "";
        }

        private void newUser_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AddNewUser newUser = new AddNewUser(bl, BO.Type.user);
            newUser.Top = this.Top + 100;
            newUser.Left = this.Left + 100;
            newUser.Show();
        }

        private void managerShowPass_Checked(object sender, RoutedEventArgs e)
        {
            managerPass.Visibility = Visibility.Hidden;
            managerPassShow.Visibility = Visibility.Visible;
            managerPassShow.Text = managerPass.Password;
        }

        private void managerShowPass_Unchecked(object sender, RoutedEventArgs e)
        {
            managerPass.Visibility = Visibility.Visible;
            managerPassShow.Visibility = Visibility.Hidden;
        }

        private void forget_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SendMail sendMail = new SendMail(bl);
            sendMail.Top = this.Top + 100;
            sendMail.Left = this.Left + 100;
            sendMail.Show();
        }
    }
}
