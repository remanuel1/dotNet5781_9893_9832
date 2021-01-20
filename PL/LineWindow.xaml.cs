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
        ObservableCollection<BO.LineBus> lineBusesAreaCenter = new ObservableCollection<BO.LineBus>();
        ObservableCollection<BO.LineBus> lineBusesAreaGeneral = new ObservableCollection<BO.LineBus>();
        ObservableCollection<BO.LineBus> lineBusesAreaNorth = new ObservableCollection<BO.LineBus>();
        ObservableCollection<BO.LineBus> lineBusesAreaSouth = new ObservableCollection<BO.LineBus>();
        IEnumerable<BO.LineBus> all = new ObservableCollection<BO.LineBus>();
        BO.Area area;

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
            comboBoxArea.ItemsSource = Enum.GetValues(typeof(BO.Area));
            comboBoxArea.SelectedIndex = 4;
            refreshListLines();
        }

        private void Button_ClickToAdd(object sender, RoutedEventArgs e)
        {
            frame.Content = new AddNewLine(bl, listLines);
        }

        private void listLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.LineBus line = listLines.SelectedItem as BO.LineBus;
            frame.Content = new DetailLine(bl, line, listLines);
        }
        

        private void toMain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void toBus_Click(object sender, RoutedEventArgs e)
        {
            BusWindow bus = new BusWindow(bl);
            bus.Left = this.Left;
            bus.Top = this.Top;
            bus.Show();
            this.Close();
        }

        private void toStation_Click(object sender, RoutedEventArgs e)
        {
            StationWindow station = new StationWindow(bl);
            station.Left = this.Left;
            station.Top = this.Top;
            station.Show();
            this.Close();
        }

        private void toUser_Click(object sender, RoutedEventArgs e)
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

        private void loadGroupToList()
        {
            all = null;
            switch (area)
            {
                case BO.Area.center:
                    {
                        all = lineBusesAreaCenter;
                        break;
                    }
                case BO.Area.general:
                    {
                        all = lineBusesAreaGeneral;
                        break;
                    }

                case BO.Area.north:
                    {
                        all = lineBusesAreaNorth;
                        break;
                    }
                case BO.Area.south:
                    {
                        all = lineBusesAreaSouth;
                        break;
                    }
                case BO.Area.all:
                    {
                        all = bl.getAllLineBus();
                        break;
                    }
            }
            listLines.ItemsSource = all;
            listLines.Items.Refresh();
        }

        private void creatGroupLine()
        {
            lineBusesAreaCenter.Clear();
            lineBusesAreaGeneral.Clear();
            lineBusesAreaNorth.Clear();
            lineBusesAreaSouth.Clear();

            foreach (var group in bl.getAllLineBusByArea())
            {
                if (group.Key == BO.Area.center)
                    foreach (var line in group)
                        lineBusesAreaCenter.Add(line);
                if (group.Key == BO.Area.general)
                    foreach (var line in group)
                        lineBusesAreaGeneral.Add(line);
                if (group.Key == BO.Area.north)
                    foreach (var line in group)
                        lineBusesAreaNorth.Add(line);
                if (group.Key == BO.Area.south)
                    foreach (var line in group)
                        lineBusesAreaSouth.Add(line);
            }

        }
        private void comboBoxArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            creatGroupLine();
            area = (BO.Area)(comboBoxArea.SelectedItem);
            loadGroupToList();
        }

    }
}
