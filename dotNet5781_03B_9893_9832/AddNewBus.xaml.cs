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

namespace dotNet5781_03B_9893_9832
{
    /// <summary>
    /// Interaction logic for addNewBus.xaml
    /// </summary>
   
     //new window for insert a new bus
    public partial class addNewBus : Window 
    {
        public addNewBus()
        {
            InitializeComponent();
          
        }
        //Click event to enter new bus details
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = (string)idBus.Text;
            DateTime date = (DateTime)dateBus.SelectedDate;
            Bus temp;
            try
            {
                temp = new Bus(id, date);
                if (TotalBus.search(temp.ID)) //If there is such a bus
                    MessageBox.Show("לא ניתן להוסיף אוטובוס קיים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    TotalBus.addNewBus(temp);//Add the bus to the list

            }
            catch
            {
                //MessageBox.Show("הכנסת נתונים לא תקינים", "שגיאה");
                MessageBox.Show("הכנסת נתונים לא זמינים", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Close();
        }
        //event that lets you enter only numbers for distance
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
