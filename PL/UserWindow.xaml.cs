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
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BLAPI;

namespace PL
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        IBL bl;
        BO.BusStation station;
        private Stopwatch stopWatch;
        private bool isTimerRun;
        BackgroundWorker timerworker;
        
        public UserWindow()
        {
            InitializeComponent();
        }

        public UserWindow(IBL _bl)
        {
            InitializeComponent();
            bl = _bl;
            listStation.ItemsSource = bl.getAllBusStations();
            stopWatch = new Stopwatch();

            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
        }

        private void listStation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            station = (sender as ListBox).SelectedItem as BO.BusStation;
            listLineTiming.ItemsSource = bl.GetLineTimingsForStation(station.numberStation, TimeSpan.Parse(timerTextBlock.Text));
            lineInStation.ItemsSource = bl.getLineInBusStations(station);
        }

        void setTextInvok(string text)
        {
            this.timerTextBlock.Text = text;
        }
        void runTimer()
        {
            while(!isTimerRun)
            {
                string timerText = stopWatch.Elapsed.ToString();
                timerText = timerText.Substring(0, 8);
                this.timerTextBlock.Text = timerText;
            }
        }

        private void startTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRun)
            {
                stopWatch.Restart();
                isTimerRun = true;
                timerworker.RunWorkerAsync();
            }
        }

        private void stopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (isTimerRun)
            {
                stopWatch.Stop();
                isTimerRun = false;
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string timerText = stopWatch.Elapsed.ToString();
            timerText = timerText.Substring(0, 8);
            listLineTiming.ItemsSource = bl.GetLineTimingsForStation(station.numberStation, TimeSpan.Parse(timerText));
            this.timerTextBlock.Text = timerText;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(1000);
            }
        }

    }
}
