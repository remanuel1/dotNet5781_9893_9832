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
        TimeSpan startTime = TimeSpan.Parse("08:00:00");
        int speed = 1;
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
            startTime = DateTime.Now.TimeOfDay;
            timerTextBlock.Text = startTime.ToString().Substring(0,8);
            station = bl.getAllBusStations().First();
            nameStation.Content = "satation: " + station.nameStation;
            lineInStation.ItemsSource = bl.getLineInBusStations(station);

            stopWatch = new Stopwatch();
            timerworker = new BackgroundWorker();
            timerworker.DoWork += Worker_DoWork;
            timerworker.ProgressChanged += Worker_ProgressChanged;
            timerworker.WorkerReportsProgress = true;
            stopWatch.Restart();
            isTimerRun = true;
            timerworker.RunWorkerAsync();
        }

        private void listStation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            station = (sender as ListBox).SelectedItem as BO.BusStation;
            nameStation.Content = "satation: " + station.nameStation;
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
            TimeSpan timerText = new TimeSpan(stopWatch.ElapsedTicks * speed);
            timerText = timerText + startTime;
            listLineTiming.ItemsSource = bl.GetLineTimingsForStation(station.numberStation, timerText);
            this.timerTextBlock.Text = timerText.ToString().Substring(0, 8);
            if (this.timerTextBlock.Text == "23:59:59")
            {
                startTime = TimeSpan.Zero;
                stopWatch.Restart();
            }

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (isTimerRun)
            {
                timerworker.ReportProgress(1);
                Thread.Sleep(1000);
            }
        }

        private void findDriving_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Stop();
            isTimerRun = false;
            SearchRideWindow searchRideWindow = new SearchRideWindow(bl);
            searchRideWindow.Show();
        }

        private void speedTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            speed = int.Parse(speedTb.Text);
        }

        private void speedTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(x => char.IsDigit(x));
        }
    }
}
