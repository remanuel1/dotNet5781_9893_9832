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
    /// Interaction logic for AddNewStation.xaml
    /// </summary>
    public partial class AddNewStation : Window
    {
        IBL bl;
        ListView listAllStation;
        public AddNewStation()
        {
            InitializeComponent();
        }

        public AddNewStation(IBL _bl, ListView _listStation)
        {
            InitializeComponent();
            bl = _bl;
            listAllStation = _listStation;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            BO.BusStation station = new BO.BusStation();
            station.nameStation = nameStation.Text;
            station.address = addressStation.Text;
            station.Latitude = double.Parse(locatLatitude.Text);
            station.Longitude = double.Parse(locatLongitude.Text);
            station.lineInStation = null;
            try
            {
                bl.insertBusStation(station);
                listAllStation.ItemsSource = bl.getAllBusStations();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadLocalExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
