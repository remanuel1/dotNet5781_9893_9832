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
    /// Interaction logic for DetailStation.xaml
    /// </summary>
    public partial class DetailStation : Page
    {
        IBL bl;
        BO.BusStation BusStation;
        ListView listStation;
        public DetailStation()
        {
            InitializeComponent();
        }

        public DetailStation(IBL _bl, BO.BusStation _BusStation, ListView _listStation)
        {
            InitializeComponent();
            bl = _bl;
            BusStation = _BusStation;
            listStation = _listStation;

            detailStation.DataContext = BusStation;
            lines.ItemsSource = bl.getLineInBusStations(BusStation);
        }

        private void number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult delete = MessageBox.Show($"did you shure to delete station {BusStation}?", "delete bus", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (delete == MessageBoxResult.Yes)
            {
                try
                {
                    bl.deleteBusStation(BusStation);
                    detailStation.Visibility = Visibility.Hidden;
                    MessageBox.Show("station is deleted", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
                    listStation.ItemsSource = bl.getAllBusStations();
                }
                catch (BO.BadIDExceptions ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.updateBusStation(BusStation);
                MessageBox.Show("station is update", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
                listStation.ItemsSource = bl.getAllBusStations();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
