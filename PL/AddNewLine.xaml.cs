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
using System.Collections.ObjectModel;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewLine : Page
    {
        IBL bl;
        ListBox listLines;
        ObservableCollection<BO.BusStation> stationsInNewLine = new ObservableCollection<BO.BusStation>();
        //BO.Area lineArea;

        public AddNewLine()
        {
            InitializeComponent();
        }

        public AddNewLine(IBL _bl, ListBox _listLines)
        {
            InitializeComponent();
            bl = _bl;
            listLines = _listLines;
            allArea.ItemsSource = Enum.GetValues(typeof(BO.Area));
            listStationForNewLine.ItemsSource = bl.getAllBusStations();
            stationSelected.ItemsSource = stationsInNewLine;
        }

        private void listStationForNewLine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BO.BusStation station = listStationForNewLine.SelectedItem as BO.BusStation;
            if (stationsInNewLine.Contains(station) == false && station!=null)
                stationsInNewLine.Add(listStationForNewLine.SelectedItem as BO.BusStation);
        }

        private void garbage_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.BusStation station = (sender as Button).DataContext as BO.BusStation;
            stationsInNewLine.Remove(station);
        }

        private void addLine_Click(object sender, RoutedEventArgs e)
        {
            if (stationsInNewLine.Count < 2)
                MessageBox.Show("Line must to contain at least 2 stations.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                int id = 0;
                List<BO.LineStation> lineStations = new List<BO.LineStation>();
                BO.LineBus newLine = new BO.LineBus();
                newLine.numberLine = int.Parse(numberLine.Text);
                newLine.area = (BO.Area)allArea.SelectedItem;
                for (int i = 0; i < stationsInNewLine.Count; i++)
                {
                    if (stationsInNewLine.ElementAt(0) == null)
                        stationsInNewLine.RemoveAt(0);
                    BO.LineStation temp = new BO.LineStation();
                    temp.numberStation = stationsInNewLine.ElementAt(i).numberStation;
                    temp.numberStationInLine = i + 1;
                    try
                    {
                        bl.insertLineStation(temp);
                        lineStations.Add(temp);
                    }
                    catch (BO.BadIDExceptions ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                newLine.listStaion = lineStations;
                try
                {
                    id = bl.insertLineBus(newLine);
                }
                catch (BO.BadIDExceptions ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                foreach (BO.LineStation item in lineStations)
                {
                    BO.LineStation temp = new BO.LineStation();
                    temp.numberStation = item.numberStation;
                    temp.numberStationInLine = item.numberStationInLine;
                    temp.timeFromPriorStation = item.timeFromPriorStation;
                    temp.identifyLine = id;
                    try
                    {
                        bl.updateLineStation(item, temp);
                    }
                    catch (BO.BadIDExceptions ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                MessageBoxResult add = MessageBox.Show($"Line {numberLine.Text} was successfully added.\n did you want to add a new line?", "Verification", MessageBoxButton.YesNo, MessageBoxImage.Question);
                listLines.DataContext = bl.getAllLineBus();
                if (add == MessageBoxResult.Yes)
                {

                    numberLine.Text = "";
                    stationsInNewLine.Clear();
                    listStationForNewLine.SelectedIndex = -1;
                    allArea.SelectedIndex = -1;
                }
                else
                {
                    this.Visibility = Visibility.Hidden;
                }
                
            }
        }

        private void numberLine_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsDigit(x));
        }

    }
}
