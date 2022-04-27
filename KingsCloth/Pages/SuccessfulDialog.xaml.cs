using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuccessfulDialog.xaml
    /// </summary>
    public partial class SuccessfulDialog : Window
    {
        const int MaxTimerCounter = 100;
        const int MinTimerCounter = 0;

        DispatcherTimer _dispTimer;
        int _dispTimerCounter;

        public SuccessfulDialog()
        {
            InitializeComponent();
            System.Timers.Timer timer = new System.Timers.Timer();

            _dispTimerCounter = MinTimerCounter;
            _dispTimer = new DispatcherTimer();
            _dispTimer.Interval = TimeSpan.FromMilliseconds(10);
            _dispTimer.Tick += new EventHandler(dispTimer_Tick);
            _dispTimer.Start();
        }
        void dispTimer_Tick(object sender, EventArgs e)
        {
            //сначала выводится значение, потом инкрементируется (не для всех очевидно)
            _dispTimerCounter++.ToString();
            PrBar.Value = _dispTimerCounter;
            if (_dispTimerCounter > MaxTimerCounter)
            {
                _dispTimerCounter = MinTimerCounter;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _dispTimer.Stop();
        }
    }
}
