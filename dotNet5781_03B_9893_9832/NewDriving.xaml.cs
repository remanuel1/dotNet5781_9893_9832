﻿using System;
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
    /// Interaction logic for NewDriving.xaml
    /// </summary>

    //A new window for entering miles for a new driving
    public partial class NewDriving : Window
    {
        
        Bus item;
        public NewDriving()
        {
            InitializeComponent();
        }

        public NewDriving(Bus bus)
        {
            item = bus;
            InitializeComponent();
        }

        //A function that allows the entry of numbers only
        private void TextBox_OnlyNumbers_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBox text = sender as TextBox;
            if (text == null) return;
            if (e == null) return;

            //allow get out of the text box
            if (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Tab)
            {
                float sumKm = float.Parse(sumKM.Text);
                //int sumKm = int.Parse(sumKM.Text);
                if (item.checkDriving(sumKm))
                {
                    
                }
                else
                {
                    MessageBox.Show("The bus not available to this driving", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
//                return;
                Close();
            }


            //allow list of system keys (add other key here if you want to allow)
            if (e.Key == Key.Escape || e.Key == Key.Back || e.Key == Key.Delete ||
                e.Key == Key.CapsLock || e.Key == Key.LeftShift || e.Key == Key.Home
             || e.Key == Key.End || e.Key == Key.Insert || e.Key == Key.Down || e.Key == Key.Right || e.Key == Key.OemPeriod)
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
