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
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for Management.xaml
    /// </summary>
    public partial class Management : Window
    {
        IBL bl;
        public Management(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
        }

        private void btBus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BusWindow bus = new BusWindow(bl);
            bus.Left = this.Left;
            bus.Top = this.Top;
            bus.Show();
            this.Close();
        }

        private void btStation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StationWindow station = new StationWindow(bl);
            station.Left = this.Left;
            station.Top = this.Top;
            station.Show();
            this.Close();
        }

        private void btLine_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LineWindow line = new LineWindow(bl);
            line.Left = this.Left;
            line.Top = this.Top;
            line.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
