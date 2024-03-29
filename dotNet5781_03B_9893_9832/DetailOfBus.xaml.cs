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
    /// Interaction logic for DetailOfBus.xaml
    /// </summary>

    //A new window showing details of a bus
    public partial class DetailOfBus : Window
    {
        Bus temp;
        public DetailOfBus()
        {
            InitializeComponent();
        }

        //constructor
        public DetailOfBus(Bus bus)
        {
            temp = bus as Bus;
            InitializeComponent();
            idBus.DataContext = bus;
            dateStart.DataContext = bus;
            dateTreat.DataContext = bus;
            sumKm.DataContext = bus;
            fuel.DataContext = bus;
            state.DataContext = bus;
            KmFrom.DataContext = bus;
            timerTextBlock.DataContext = bus;
            toFull.DataContext = bus;
            toTreat.DataContext = bus;
            
        }

        // to full
        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            temp.fullFuel();
            temp.state = (Status)2;
        }

        // to do treat
        private void Button_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            temp.doTreat();
            temp.state = (Status)3;
        }
    }
}
