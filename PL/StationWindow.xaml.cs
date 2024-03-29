﻿using System;
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

        }


        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            page.Content = new AddNewStation(bl, listStation);

        }

        /*private void Button_Click_Update(object sender, RoutedEventArgs e)
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
        }*/

        /*private void Button_Click_Delete(object sender, RoutedEventArgs e)
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
        }*/

        /*private void ADDButton_Click(object sender, RoutedEventArgs e)
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
        }*/

        private void listStation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.BusStation station = (sender as ListBox).SelectedItem as BO.BusStation;
            page.Content = new DetailStation(bl, station, listStation);
            /*detailStation.Visibility = Visibility.Visible;
            addNewStation.Visibility = Visibility.Hidden;
            BO.BusStation station = (sender as ListBox).SelectedItem as BO.BusStation;

            detailStation.DataContext = station;
            lines.ItemsSource = bl.getLineInBusStations(station);*/
        }

        private void toBus_Click(object sender, RoutedEventArgs e)
        {
            BusWindow bus = new BusWindow(bl);
            bus.Left = this.Left;
            bus.Top = this.Top;
            bus.Show();
            this.Close();
        }

        private void toline_Click(object sender, RoutedEventArgs e)
        {
            LineWindow line = new LineWindow(bl);
            line.Left = this.Left;
            line.Top = this.Top;
            line.Show();
            this.Close();
        }

        private void touser_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(bl);
            userWindow.Left = this.Left;
            userWindow.Top = this.Top;
            userWindow.Show();
            this.Close();
        }

        private void toexit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void toMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    
    }
}
