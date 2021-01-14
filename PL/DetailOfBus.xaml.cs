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
    /// Interaction logic for DetailOfBus.xaml
    /// </summary>
    public partial class DetailOfBus : Page
    {
        IBL bl;
        BO.Bus temp;
        ListBox listBus;
        public DetailOfBus()
        {
            InitializeComponent();
        }

        public DetailOfBus(IBL _bl, BO.Bus bus, ListBox _listBus)
        {
            bl = _bl;
            listBus = _listBus;
            temp = bus as BO.Bus;
            InitializeComponent();
            numberBus.DataContext = temp;
            dateBus.DataContext = temp;
            dateTreat.DataContext = temp;
            sumKm.Text = "" + temp.sumKM;
            fuel.Text = "" + temp.totalFuel;
            KmFrom.Text = "" + temp.sumKMFromLastTreat;
            status.DataContext = temp;
        }

        private void refuel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.refuel(temp);
                fuel.Text = "" + temp.totalFuel;
                listBus.DataContext = bl.getAllBusses();
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void treat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.treat(temp);
                listBus.DataContext = bl.getAllBusses();
                dateTreat.SelectedDate = temp.lastTreat;
                KmFrom.Text = "" + temp.sumKMFromLastTreat;
            }
            catch (BO.BadIDExceptions ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
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
                listBus.ItemsSource = bl.getAllBusses();
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
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult delete = MessageBox.Show($"did you shure to delete bus {temp}?", "delete bus", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (delete == MessageBoxResult.Yes)
            {
                try
                {
                    bl.deleteBus(temp);
                    listBus.ItemsSource = bl.getAllBusses();
                    MessageBox.Show("delete complete", "OK", MessageBoxButton.OK, MessageBoxImage.None);
                }
                catch (BO.BadIDExceptions ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            this.Visibility = Visibility.Hidden;
        }

        private void numberBus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsDigit(x));
        }

    }
}
