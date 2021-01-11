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
using System.ComponentModel;
using System.Collections.ObjectModel;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for BusWindow.xaml
    /// </summary>
    public partial class BusWindow : Window
    {
        IBL bl;
        void refreshListBus()
        {
            listBus.DataContext = bl.getAllBusses();
        }

        public BusWindow()
        {
            InitializeComponent();
        }
        public BusWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            refreshListBus();
            
        }

        private void DoubleClickToAddNewBus(object sender, MouseButtonEventArgs e)
        {
            frame.Visibility = Visibility.Visible;
            frame.Content = new AddNewBus(bl, listBus);
        }

        private void numberBus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsDigit(x));
        }

        private void listBus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.Bus bus = listBus.SelectedItem as BO.Bus;
            frame.Visibility = Visibility.Visible;
            frame.Content = new DetailOfBus(bl, bus, listBus);
        }
    }
}
