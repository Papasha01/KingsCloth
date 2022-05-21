using System;
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
using Word = Microsoft.Office.Interop.Word;

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
        private readonly string path = @"c:\test.docx";
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    reqDB req = new reqDB();
        //    var table = req.select_history();
        //    var q1 = 0;
        //    var s1 = 0;
        //    var d1 = 0;
        //    for (int i = 0; i < table.Rows.Count; i++)
        //    {
        //        q1 += (int)table.Rows[i]["count_product"];
        //        s1 += (int)table.Rows[i]["cost"];
        //        d1 += (int)table.Rows[i]["discount"];
        //    }

        //    var wordApp = new Word.Application();
        //    wordApp.Visible = false;
        //    var wordDoc = wordApp.Documents.Open(path);

        //    replace_text("{q1}", q1.ToString(), wordDoc);
        //    replace_text("{s1}", s1.ToString(), wordDoc);
        //    replace_text("{d1}", d1.ToString(), wordDoc);
        //    wordDoc.SaveAs(@"c:\done.docx");
        //    wordApp.Visible = true;
        //}
        private void replace_text(string replace, string text, Word.Document wordDoc)
        {
            var range = wordDoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: replace, ReplaceWith: text);
        }

        private void btn_test(object sender, RoutedEventArgs e)
        {
            reqDB req = new reqDB();
            var table = req.select_history();
            var q1 = 0;
            double s1 = 0;
            double d1 = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                q1 += (int)table.Rows[i]["count_product"];
                s1 += Convert.ToDouble(table.Rows[i]["cost"]);
                d1 += Convert.ToDouble(table.Rows[i]["discount"]);
            }

            var wordApp = new Word.Application();
            wordApp.Visible = false;
            var wordDoc = wordApp.Documents.Open(path);

            //replace_text("{q1}", q1.ToString(), wordDoc);
            //replace_text("{s1}", s1.ToString(), wordDoc);
            //replace_text("{d1}", d1.ToString(), wordDoc);
            //wordDoc.SaveAs(@"c:\done.docx");
            //wordApp.Visible = true;
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
