﻿using System;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stats.xaml
    /// </summary>
    public partial class Stats : Page
    {
        public double cost()
        {
            reqDB req = new reqDB();
            long prof = req.select_all_cost();
            return prof;

            
        }
        public double discount()
        {
            reqDB req = new reqDB();
            long prof = req.select_all_discount();
            return prof;
        }
        public SeriesCollection SeriesCollection { get; set; }
        public Stats()
        {

            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Discount",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(discount()) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Sales profit",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(cost()) },
                    DataLabels = true
                }
            };

            DataContext = this;
        }


        //private void Products_for_the_quarter(object sender, RoutedEventArgs e)
        //{
        //    ChartGrid.Visibility = Visibility.Visible;
        //    CircleGrid.Visibility = Visibility.Hidden;
        //}
        //private void Revenue(object sender, RoutedEventArgs e)
        //{
        //    ChartGrid.Visibility = Visibility.Visible;
        //    CircleGrid.Visibility = Visibility.Hidden;
        //}
        //private void Cost_of_goods(object sender, RoutedEventArgs e)
        //{
        //    ChartGrid.Visibility = Visibility.Hidden;
        //    CircleGrid.Visibility = Visibility.Visible;
        //}
        //private void Discounts_and_referrals(object sender, RoutedEventArgs e)
        //{
        //    ChartGrid.Visibility = Visibility.Visible;
        //    CircleGrid.Visibility = Visibility.Hidden;
        //}

        //private void Surplus_value(object sender, RoutedEventArgs e)
        //{
        //    ChartGrid.Visibility = Visibility.Visible;
        //    CircleGrid.Visibility = Visibility.Hidden;
        //}


    }
}
