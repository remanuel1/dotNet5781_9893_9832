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
    /// Interaction logic for LineWindow.xaml
    /// </summary>
    public partial class LineWindow : Window
    {
        IBL bl;
        ObservableCollection<BO.BusStation> stationsInNewLine = new ObservableCollection<BO.BusStation>();

        void refreshListLines()
        {
            listLines.DataContext = bl.getAllLineBus();
        }

        public LineWindow()
        {
            InitializeComponent();
        }
        public LineWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            detailOfLine.Visibility = Visibility.Hidden;
            listStationForNewStation.Visibility = Visibility.Hidden;
            listNumber.Visibility = Visibility.Hidden;
            addStationToLine.Visibility = Visibility.Hidden;
            refreshListLines();
        }

        private void Button_ClickToAdd(object sender, RoutedEventArgs e)
        {
            detailOfLine.Visibility = Visibility.Hidden;
            frame.Content = new AddNewLine(bl, listLines);
        }

        private void listLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            detailOfLine.Visibility = Visibility.Visible;
            BO.LineBus line = listLines.SelectedItem as BO.LineBus;
            numberLineForDetail.Text = "" + line.numberLine;
            numberIdForDetail.Text = "" + line.identifyBus;
            lineArea.ItemsSource = Enum.GetValues(typeof(BO.Area));
            lineArea.SelectedItem = line.area;
            stationInLine.ItemsSource = line.listStaion;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            BO.LineBus lineBus = listLines.SelectedItem as BO.LineBus;
            lineBus.numberLine = int.Parse(numberLineForDetail.Text);
            lineBus.area = (BO.Area)lineArea.SelectedItem;
            try
            {
                bl.updateLineBus(lineBus);
                MessageBox.Show("line is change", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
                refreshListLines();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            BO.LineBus line = listLines.SelectedItem as BO.LineBus;
            MessageBoxResult add = MessageBox.Show($"did you shure to delete Line {line.numberLine}?", "delete line", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(add == MessageBoxResult.Yes)
                bl.deleteLineBus(line);
            detailOfLine.Visibility = Visibility.Hidden;
            refreshListLines();
        }

        private void toDeleteStation_Click(object sender, RoutedEventArgs e)
        {
            BO.LineStation lineStation = (sender as Button).DataContext as BO.LineStation;
            MessageBoxResult add = MessageBox.Show($"did you shure to delete station {lineStation.numberStation}?", "delete station", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (add == MessageBoxResult.Yes)
                bl.deleteStationInLine(bl.getLineBus(lineStation.identifyLine), lineStation);
            stationInLine.ItemsSource = bl.getLineBus(lineStation.identifyLine).listStaion;
        }

        private void addStation_Click(object sender, RoutedEventArgs e)
        {
            BO.LineBus lineBus = listLines.SelectedItem as BO.LineBus;
            int range = lineBus.listStaion.Count()+1;
            listStationForNewStation.Visibility = Visibility.Visible;
            listNumber.Visibility = Visibility.Visible;
            addStationToLine.Visibility = Visibility.Visible;
            listStationForNewStation.ItemsSource = bl.getAllBusStations();
            listNumber.ItemsSource = Enumerable.Range(1, range).Select(i => (object)i).ToArray();
        }

        private void addStationToLine_Click(object sender, RoutedEventArgs e)
        {
            BO.BusStation stationToAdd = listStationForNewStation.SelectedItem as BO.BusStation;
            BO.LineBus lineBus = listLines.SelectedItem as BO.LineBus;
            int index = int.Parse(listNumber.SelectedItem.ToString());
            try
            {
                bl.addStationToLine(lineBus, stationToAdd, index);
                refreshListLines();
                stationInLine.ItemsSource = bl.getLineBus(lineBus.identifyBus).listStaion;
            }
            catch(BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            listStationForNewStation.Visibility = Visibility.Hidden;
            listNumber.Visibility = Visibility.Hidden;
            addStationToLine.Visibility = Visibility.Hidden;
        }
    }
}
