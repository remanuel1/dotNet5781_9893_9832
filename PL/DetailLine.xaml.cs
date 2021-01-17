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
    /// Interaction logic for DetailLine.xaml
    /// </summary>
    public partial class DetailLine : Page
    {
        IBL bl;
        BO.LineBus line;
        ListBox allLines;

        public DetailLine()
        {
            InitializeComponent();
        }

        public DetailLine(IBL _bl, BO.LineBus _line, ListBox _allLines)
        {
            bl = _bl;
            line = _line;
            allLines = _allLines;
            InitializeComponent();

            numberLineForDetail.Text = "" + line.numberLine;
            numberIdForDetail.Text = "" + line.identifyBus;
            lineArea.ItemsSource = Enum.GetValues(typeof(BO.Area));
            lineArea.SelectedItem = line.area;
            stationInLine.ItemsSource = line.listStaion;

            listStationForNewStation.Visibility = Visibility.Hidden;
            listNumber.Visibility = Visibility.Hidden;
            addStationToLine.Visibility = Visibility.Hidden;
        }

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            int range = line.listStaion.Count() + 1;
            listStationForNewStation.Visibility = Visibility.Visible;
            listNumber.Visibility = Visibility.Visible;
            addStationToLine.Visibility = Visibility.Visible;
            listStationForNewStation.ItemsSource = bl.getAllBusStations();
            listNumber.ItemsSource = Enumerable.Range(1, range).Select(i => (object)i).ToArray();
        }

        private void toDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation lineStation = (sender as Button).DataContext as BO.LineStation;
            MessageBoxResult add = MessageBox.Show($"did you shure to delete station {lineStation.numberStation}?", "delete station", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (add == MessageBoxResult.Yes)
                try
                {
                    bl.deleteStationInLine(line, lineStation);
                }
                catch (BO.BadLineExceptions ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            stationInLine.ItemsSource = line.listStaion;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            line.numberLine = int.Parse(numberLineForDetail.Text);
            line.area = (BO.Area)lineArea.SelectedItem;
            try
            {
                bl.updateLineBus(line);
                MessageBox.Show("line is change", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
                allLines.ItemsSource = bl.getAllLineBus();
            }
            catch (BO.BadLineExceptions ex)
            {

                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult add = MessageBox.Show($"did you shure to delete Line {line.numberLine}?", "delete line", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (add == MessageBoxResult.Yes)
            {
                bl.deleteLineBus(line);
                allLines.ItemsSource = bl.getAllLineBus();
            }
            this.Visibility = Visibility.Hidden;
        }

        private void addStationToLine_Click(object sender, RoutedEventArgs e)
        {
            BO.BusStation stationToAdd = listStationForNewStation.SelectedItem as BO.BusStation;
            int index = int.Parse(listNumber.SelectedItem.ToString());
            try
            {
                bl.addStationToLine(line, stationToAdd, index);
                allLines.ItemsSource = bl.getAllLineBus();
                stationInLine.ItemsSource = bl.getLineBus(line.identifyBus).listStaion;
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            listStationForNewStation.Visibility = Visibility.Hidden;
            listNumber.Visibility = Visibility.Hidden;
            addStationToLine.Visibility = Visibility.Hidden;
        }

        private void onlyNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsDigit(x));
        }
    }
}
