using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        public Catalog()
        {
            InitializeComponent();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            CatalogDialog dialog = new CatalogDialog();
            dialog.Show();
        }

        private void ButtonBasket_Click(object sender, RoutedEventArgs e)
        {
            //fContainer.NavigationService.Navigate(new Uri("Pages/Basket.xaml", UriKind.Relative));

            reqDB db = new reqDB();
            var table = db.select_product();
            
            List<products> productList = new List<products>();
            productList = (from DataRow dr in table.Rows
                           select new products()
                           {
                               name = dr["name"].ToString(),
                               color = dr["color"].ToString(),
                               price = Convert.ToInt32(dr["price"]),
                               description = dr["description"].ToString(),
                               image = (BitmapSource)new ImageSourceConverter().ConvertFrom(dr["image"])
                           }).ToList();

            listview_product.Items.Clear();
            listview_product.ItemsSource = productList;
        }
    }
}
