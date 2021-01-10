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
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        IBL bl;
        public Management(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (rbBuses.IsChecked == true)
            {
                BusWindow bus = new BusWindow(bl);
                bus.Show();
            }
            else if (rbStations.IsChecked == true)
            {
                StationWindow station = new StationWindow(bl);
                station.Show();
            }
            else
            {
                LineWindow line = new LineWindow(bl);
                line.Show();

            }
        }
    }
}
