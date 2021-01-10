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
    public partial class DetailOfBus : Window
    {
        BO.Bus temp;
        public DetailOfBus()
        {
            InitializeComponent();
        }

        public DetailOfBus(BO.Bus bus)
        {
            temp = bus as BO.Bus;
            InitializeComponent();
            idBus.DataContext = bus;
            dateStart.DataContext = bus;
            dateTreat.DataContext = bus;
            sumKm.DataContext = bus;
            fuel.DataContext = bus;
            state.DataContext = bus;
            KmFrom.DataContext = bus;
        }
    }
}
