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
    /// Interaction logic for UpdateBus.xaml
    /// </summary>
    public partial class UpdateBus : Window
    {
        IBL bl;
        BO.Bus bus;
        ListView allBusesList;
        public UpdateBus()
        {
            InitializeComponent();
        }

        public UpdateBus(IBL _bl, BO.Bus _bus, ListView listView)
        {
            InitializeComponent();
            bl = _bl;
            bus = _bus;
            allBusesList = listView;
            numberBus.DataContext = bus;
            dateBus.DataContext = bus;
            dateTreat.DataContext = bus;
            sumKm.Text = ""+bus.sumKM;
            fuel.Text = ""+bus.totalFuel;
            KmFrom.Text = ""+bus.sumKMFromLastTreat;

        }

        private void update_Click(object sender, RoutedEventArgs e)
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
                allBusesList.DataContext = bl.getAllBusses();
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
            this.Close();
        }

        private void TextBox_OnlyNumbers_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text == null) return;
            if (e == null) return;

            //allow get out of the text box
            if (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Tab)
            {
                return;
            }


            //allow list of system keys (add other key here if you want to allow)
            if (e.Key == Key.Escape || e.Key == Key.Back || e.Key == Key.Delete ||
                e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.Home
             || e.Key == Key.End || e.Key == Key.Insert || e.Key == Key.Down || e.Key == Key.Right)
                return;

            char c = (char)KeyInterop.VirtualKeyFromKey(e.Key);

            //allow control system keys
            if (Char.IsControl(c)) return;

            //allow digits (without Shift or Alt)
            if (Char.IsDigit(c))
                if (!(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightAlt)))
                    return; //let this key be written inside the textbox

            //forbid letters and signs (#,$, %, ...)
            e.Handled = true; //ignore this key. mark event as handled, will not be routed to other controls
            return;

        }
    }
}
