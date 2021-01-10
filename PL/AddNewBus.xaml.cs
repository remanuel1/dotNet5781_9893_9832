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
    /// Interaction logic for AddNewBus.xaml
    /// </summary>
    public partial class AddNewBus : Page
    {
        IBL bl;
        ListView allBuses;
        public AddNewBus()
        {
            InitializeComponent();
        }
        public AddNewBus(IBL _bl, ListView _allBuses)
        {
            InitializeComponent();
            bl = _bl;
            allBuses = _allBuses;

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            BO.Bus temp = new BO.Bus();
            temp.numberLicense = (string)numberBus.Text;
            temp.startActivity = (DateTime)dateBus.SelectedDate;
            if (sumKm.Text == "")
                temp.sumKM = 0;
            else
                temp.sumKM = float.Parse(sumKm.Text);

            if (dateTreat.SelectedDate.ToString() == "")
                temp.lastTreat = temp.startActivity;
            else
                temp.lastTreat = (DateTime)dateTreat.SelectedDate;

            if (fuel.Text == "")
                temp.totalFuel = 1200;
            else
                temp.totalFuel = int.Parse(fuel.Text);

            if (KmFrom.Text == "")
                temp.sumKMFromLastTreat = 0;
            else
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
                bl.insertBus(temp);
                allBuses.DataContext = bl.getAllBusses();
                MessageBox.Show("The bus was successfully added", "O.K.", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void numberBus_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsDigit(x));
        }
    }
}
