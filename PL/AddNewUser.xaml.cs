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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for AnnNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Window
    {
        IBL bl;
        BO.Type typeUser;
        public AddNewUser()
        {
            InitializeComponent();
        }

        public AddNewUser(IBL _bl, BO.Type _typeUser)
        {
            InitializeComponent();
            bl = _bl;
            typeUser = _typeUser;
            newUserLabel.Content = "  add new " + typeUser;
            if (_typeUser == BO.Type.manager)
                loginButton.Content = "add";
            else
                loginButton.Content = "sign up";
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // add a new user

            BO.User userToAdd = new BO.User();
            userToAdd.name = nameOfUser.Text;
            userToAdd.userName = userName.Text;
            userToAdd.password = userPass.Text;
            userToAdd.mail = mailOfUser.Text;
            userToAdd.type = typeUser;
            try
            {
                bl.addUser(userToAdd);
                MessageBox.Show("addition " +userToAdd.name + " as "+ userToAdd.type + " was done");
            }
            catch
            {
                ;
            }
            this.Close();
        }

        private void notSpace_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.Any(x => char.IsWhiteSpace(x));
        }
    }
}
