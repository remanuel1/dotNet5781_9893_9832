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
    /// Interaction logic for SeeAllUsers.xaml
    /// </summary>
    public partial class SeeAllUsers : Window
    {
        IBL bl;
        public SeeAllUsers()
        {
            InitializeComponent();
        }

        public SeeAllUsers(IBL _bl)
        {
            bl = _bl;
            InitializeComponent();
            allUsers.ItemsSource = bl.getAllUser();
        }


    }
}
