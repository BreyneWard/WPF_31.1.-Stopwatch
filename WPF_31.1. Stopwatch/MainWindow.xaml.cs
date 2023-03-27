using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace WPF_31._1._Stopwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dt_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        }
        void dt_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                TimeSpan ts = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                clocktxtblock.Text = currentTime;
            }
        }

        private void startbtn_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            dispatcherTimer.Start();
        }

        private void stopbtn_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning)
            {
                stopWatch.Stop();
            }
            elapsedtimeitem.Items.Add(currentTime);
        }

        private void resetbtn_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Reset();
            clocktxtblock.Text = "00:00:00";
        }
    }
}
