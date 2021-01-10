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
using System.Collections.ObjectModel;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for StationWindow.xaml
    /// </summary>
    public partial class StationWindow : Window
    {
        IBL bl;


        void refreshListBusStation()
        {
            listStation.ItemsSource = bl.getAllBusStations();
        }
        public StationWindow()
        {
            InitializeComponent();
        }
        public StationWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            refreshListBusStation();
            detailStation.Visibility = Visibility.Hidden;
            addNewStation.Visibility = Visibility.Hidden;
        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            //addNewStation.Visibility = Visibility.Visible;
            detailStation.Visibility = Visibility.Hidden;
            AddNewStation addNewStation = new AddNewStation(bl, listStation);
            addNewStation.Show();
            //busStations = bl.getAllBusStations();
            //allBusStation = convert(busStations);
            //listStation.ItemsSource = allBusStation;
        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            BO.BusStation station = (sender as Button).DataContext as BO.BusStation;
            try
            {
                bl.updateBusStation(station);
                MessageBox.Show("station is change", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
                refreshListBusStation();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            BO.BusStation station = (sender as Button).DataContext as BO.BusStation;
            try
            {
                bl.deleteBusStation(station);
                detailStation.Visibility = Visibility.Hidden;
                MessageBox.Show("station is deleted", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
                refreshListBusStation();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ADDButton_Click(object sender, RoutedEventArgs e)
        {
            BO.BusStation station = new BO.BusStation();
            station.nameStation = addNameStation.Text;
            station.address = addAddressStation.Text;
            station.Latitude = double.Parse(addLocatLatitude.Text);
            station.Longitude = double.Parse(addLocatLongitude.Text);
            try
            {
                bl.insertBusStation(station);
                refreshListBusStation();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            addNewStation.Visibility = Visibility.Hidden;
        }

        private void listStation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            detailStation.Visibility = Visibility.Visible;
            addNewStation.Visibility = Visibility.Hidden;
            BO.BusStation station = (sender as ListBox).SelectedItem as BO.BusStation;
            detailStation.DataContext = station;
            lines.ItemsSource = bl.getLineInBusStations(station);
        }
    }
}
