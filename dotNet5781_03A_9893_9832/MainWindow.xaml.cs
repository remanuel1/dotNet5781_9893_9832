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
using System.Windows.Navigation;
using System.Windows.Shapes;
using dotNet5781_02_9893_9832;


namespace dotNet5781_03A_9893_9832
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CollectionOfLineBus totalBuses = new CollectionOfLineBus();
        private LineBus currentDisplayBusLine;

        public void ShowBusLine(int index)
        {
            currentDisplayBusLine = totalBuses[index];
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.listOfBus;
        }

        static void restart(ref ListOfBusStation station, ref CollectionOfLineBus line)
        {
            station = new ListOfBusStation();
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine(i);
                station.addBusStation();
            }
            //station.Add(new BusStation());
            List<LineBus> lines = new List<LineBus>();
            lines.Add(new LineBus(station.total[0], station.total[1]));
            lines[0].addstation(station.total[2]);
            lines[0].addstation(station.total[3]);
            lines.Add(new LineBus(station.total[4], station.total[5]));
            lines[1].addstation(station.total[6]);
            lines[1].addstation(station.total[7]);
            lines.Add(new LineBus(station.total[8], station.total[9]));
            lines[2].addstation(station.total[10]);
            lines[2].addstation(station.total[11]);
            lines.Add(new LineBus(station.total[12], station.total[13]));
            lines[3].addstation(station.total[14]);
            lines[3].addstation(station.total[15]);
            lines.Add(new LineBus(station.total[16], station.total[17]));
            lines[4].addstation(station.total[18]);
            lines[4].addstation(station.total[19]);
            lines.Add(new LineBus(station.total[20], station.total[21]));
            lines[5].addstation(station.total[22]);
            lines[5].addstation(station.total[23]);
            lines.Add(new LineBus(station.total[24], station.total[25]));
            lines[6].addstation(station.total[26]);
            lines[6].addstation(station.total[27]);
            lines.Add(new LineBus(station.total[28], station.total[29]));
            lines[7].addstation(station.total[30]);
            lines[7].addstation(station.total[31]);
            lines.Add(new LineBus(station.total[32], station.total[33]));
            lines[8].addstation(station.total[34]);
            lines[8].addstation(station.total[35]);
            lines.Add(new LineBus(station.total[36], station.total[37]));
            lines[9].addstation(station.total[38]);
            lines[9].addstation(station.total[39]);
            lines[0].addstation(station.total[4]);
            lines[1].addstation(station.total[8]);
            lines[2].addstation(station.total[12]);
            lines[3].addstation(station.total[16]);
            lines[4].addstation(station.total[20]);
            lines[5].addstation(station.total[24]);
            lines[6].addstation(station.total[28]);
            lines[7].addstation(station.total[32]);
            lines[8].addstation(station.total[36]);
            lines[9].addstation(station.total[0]);
            line = new CollectionOfLineBus();
            for (int i = 0; i < 10; i++)
                line.addLineToCollection(lines[i]);
        }

        public MainWindow()
        {
            ListOfBusStation stations = new ListOfBusStation();
            restart(ref stations, ref totalBuses);
            InitializeComponent();
            cbBusLines.ItemsSource = totalBuses;
            cbBusLines.DisplayMemberPath = " numberBus ";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(cbBusLines.SelectedIndex);
            
        }

        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int numBus = (cbBusLines.SelectedValue as LineBus).numberBus;
            ShowBusLine(totalBuses.findIndex(numBus));
        }
    }
}
