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
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Threading;
using System.Diagnostics;


namespace dotNet5781_03B_9893_9832
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Bus> totalBus = TotalBus.totalBus;

        public MainWindow()
        {
            InitializeComponent();
            listBus.DataContext = totalBus;
            
        }

        //see detail of bus
        private void listBus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bus bus = listBus.SelectedItem as Bus;
            DetailOfBus detailOfBus = new DetailOfBus(bus);
            detailOfBus.Show();
        }

        // add a new bus
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addNewBus addNewBus = new addNewBus();
            addNewBus.Show();
            listBus.DataContext = totalBus;
        }

        //new driving
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Bus bus = (sender as Button).DataContext as Bus;
            NewDriving newDriving = new NewDriving(bus);
            newDriving.Show();
            

        }

        //full the fuel
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Bus bus = (sender as Button).DataContext as Bus;
            bus.fullFuel();

        }



    }
}
