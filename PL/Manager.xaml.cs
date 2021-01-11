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
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        IBL bl;
        IEnumerable<BO.Bus> Buses;
        ObservableCollection<BO.Bus> allBuses;

        public ObservableCollection<T> convert<T>(IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }
        public Manager()
        {
            InitializeComponent();
        }

        public Manager(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            Buses = bl.getAllBusses();
            allBuses = convert(Buses);
            listBus.DataContext = allBuses;
        }

        private void DoubleClickToAddNewBus(object sender, MouseButtonEventArgs e)
        {

        }

        private void treat_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus bus = (sender as Button).DataContext as BO.Bus;
            bl.treat(bus);
        }

        private void refuel_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus bus = (sender as Button).DataContext as BO.Bus;
            bl.refuel(bus);
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.Bus bus = (sender as Button).DataContext as BO.Bus;
            bl.deleteBus(bus);
            //allBuses = convert(bl.getAllBusses());
            listBus.DataContext = allBuses;
        }

        private void listBus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*BO.Bus bus = listBus.SelectedItem as BO.Bus;
            DetailOfBus detailOfBus = new DetailOfBus(bus);
            detailOfBus.Show();*/
        }
    }
}
