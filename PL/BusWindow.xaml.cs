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

        /*private void listBus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.Bus bus = listBus.SelectedItem as BO.Bus;
            frame.Visibility = Visibility.Hidden;
            detailOfBus.Visibility = Visibility.Visible;
            refuel.Visibility = Visibility.Visible;
            treat.Visibility = Visibility.Visible;
            delete.Visibility = Visibility.Visible;
            update.Visibility = Visibility.Visible;
            numberBus.Text = "" + bus.numberLicense;
            dateBus.DataContext = bus;
            dateTreat.DataContext = bus;
            sumKm.Text = "" + bus.sumKM;
            fuel.Text = "" + bus.totalFuel;
            KmFrom.Text = "" + bus.sumKMFromLastTreat;
            status.Text = "" + bus.Status;
        }*/

        /*private void update_Click(object sender, RoutedEventArgs e)
        {

            BO.Bus temp = new BO.Bus();
            temp.numberLicense = (string)numberBus.Text;
            temp.startActivity = (DateTime)dateBus.SelectedDate;
            temp.sumKM = float.Parse(sumKm.Text);
            temp.lastTreat = (DateTime)dateTreat.SelectedDate;
            temp.totalFuel = int.Parse(fuel.Text);
            temp.sumKMFromLastTreat = float.Parse(KmFrom.Text);
            DateTime dateNow = DateTime.Now;
            TimeSpan t = dateNow - temp.lastTreat;
            if (temp.sumKMFromLastTreat >= 20000 || t.Days > 365)
            {
                temp.Status = BO.Status.needTreat;
            }
            else
                temp.Status = BO.Status.ready;
            try
            {
                bl.updateBus(temp);
                refreshListBus();
                MessageBox.Show("update complete", "Done", MessageBoxButton.OK, MessageBoxImage.None);
            }
            catch (BO.BadDateExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadIDAndDateExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }*/

        /*private void delete_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus bus = listBus.SelectedItem as BO.Bus;
            MessageBoxResult delete = MessageBox.Show($"did you shure to delete bus {bus}?", "delete bus", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (delete == MessageBoxResult.Yes)
            {
                try
                {
                    bl.deleteBus(bus);
                    refreshListBus();
                    MessageBox.Show("delete complete", "OK", MessageBoxButton.OK, MessageBoxImage.None);
                }
                catch (BO.BadIDExceptions ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }*/

        private void DoubleClickToAddNewBus(object sender, MouseButtonEventArgs e)
        {
            /*detailOfBus.Visibility = Visibility.Hidden;
            refuel.Visibility = Visibility.Hidden;
            treat.Visibility = Visibility.Hidden;
            delete.Visibility = Visibility.Hidden;
            update.Visibility = Visibility.Hidden;*/
            frame.Visibility = Visibility.Visible;
            frame.Content = new AddNewBus(bl, listBus);
        }

        /*private void refuel_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus bus = listBus.SelectedItem as BO.Bus;
            try
            {
                bl.refuel(bus);
                fuel.Text = "" + bus.totalFuel;
                refreshListBus();
            }
            catch(BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }*/

        /*private void treat_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus bus = listBus.SelectedItem as BO.Bus;
            try
            {
                bl.treat(bus);
                refreshListBus();
                dateTreat.DataContext = bus;
                KmFrom.Text = "" + bus.sumKMFromLastTreat;
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }*/

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
