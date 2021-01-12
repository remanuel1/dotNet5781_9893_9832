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
using System.Collections.ObjectModel;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for LineWindow.xaml
    /// </summary>
    public partial class LineWindow : Window
    {
        IBL bl;
        ObservableCollection<BO.BusStation> stationsInNewLine = new ObservableCollection<BO.BusStation>();

        void refreshListLines()
        {
            listLines.DataContext = bl.getAllLineBus();
        }

        public LineWindow()
        {
            InitializeComponent();
        }
        public LineWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;

            refreshListLines();
        }

        private void Button_ClickToAdd(object sender, RoutedEventArgs e)
        {
            frame.Content = new AddNewLine(bl, listLines);
        }

        private void listLines_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.LineBus line = listLines.SelectedItem as BO.LineBus;
            frame.Content = new DetailLine(bl, line, listLines);
        }

    }
}
