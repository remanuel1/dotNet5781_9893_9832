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
    /// Interaction logic for SearchRideWindow.xaml
    /// </summary>
    public partial class SearchRideWindow : Window
    {
        IBL bl;
        public SearchRideWindow()
        {
            InitializeComponent();
        }

        public SearchRideWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            sourseStation.ItemsSource = bl.getAllBusStations();
            destinationStation.ItemsSource = bl.getAllBusStations();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            listLine.ItemsSource = null;
            numberLine.Content = null;

            BO.BusStation sourse = sourseStation.SelectedItem as BO.BusStation;
            BO.BusStation destination = destinationStation.SelectedItem as BO.BusStation;
            if(sourse == destination)
                MessageBox.Show("enter two different station", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                foreach (BO.LineBus line in bl.getAllLineBus())
                {
                    BO.LineStation s = line.listStaion.ToList().Find(l => l.numberStation == sourse.numberStation);
                    BO.LineStation d = line.listStaion.ToList().Find(l => l.numberStation == destination.numberStation);
                    if (s != null && d!= null && s.numberStationInLine<d.numberStationInLine)
                    {
                        listLine.ItemsSource = (from BO.LineStation item in line.listStaion
                                               where item.numberStationInLine >= s.numberStationInLine && item.numberStationInLine <= d.numberStationInLine
                                               orderby item.numberStationInLine
                                               select item.nameStation).ToList();
                        numberLine.Content = line.numberLine;
                        break;
                    }

                }
                if(numberLine.Content == null)
                    MessageBox.Show("sorry.. \n not found line between these stations.", "not found", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            sourseStation.SelectedItem = -1;
            sourseStation.SelectedItem = -1;
        }
    }
}
