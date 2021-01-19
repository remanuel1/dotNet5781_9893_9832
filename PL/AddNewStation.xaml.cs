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
    public partial class AddNewStation : Page
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
            // add new bus station
            BO.BusStation station = new BO.BusStation();
            station.nameStation = addNameStation.Text;
            station.address = addAddressStation.Text;
            station.Latitude = double.Parse(addLocatLatitude.Text);
            station.Longitude = double.Parse(addLocatLongitude.Text);
            station.lineInStation = null;
            try
            {
                bl.insertBusStation(station);
                listAllStation.ItemsSource = bl.getAllBusStations();
                this.Visibility = Visibility.Hidden;
                
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadLocalExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void onlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // func to able only enter digit or '.'
            e.Handled = !e.Text.Any(x => (char.IsDigit(x) || x=='.'));
        }
    }
}
