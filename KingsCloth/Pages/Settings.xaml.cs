using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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

namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {

        DispatcherTimer timer = new DispatcherTimer();

        public Settings()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += timer_Tick;


        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SnackbarTwo.IsActive = true;
            timer.Start();

        }
        private void timer_Tick(object sender, EventArgs e)
        {
            SnackbarTwo.IsActive = false;
        }

        private void LightTheme_Checked(object sender, RoutedEventArgs e)
        {
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Colors/LightTheme.xaml", UriKind.RelativeOrAbsolute) });

        }

        private void DarkTheme_Checked(object sender, RoutedEventArgs e)
        {
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Colors/DarkTheme.xaml", UriKind.RelativeOrAbsolute) });

        }
    }
}

