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
            Load();
        }

            reqDB req = new reqDB();
        private void Load()
        {
            var dt = req.select_product();

            List<products> productList = new List<products>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                products product = new products();
                product.id = (int)dt.Rows[i]["id"];
                product.name = dt.Rows[i]["name"].ToString();
                product.color = dt.Rows[i]["color"].ToString();
                product.price = (int)dt.Rows[i]["price"];
                product.description = dt.Rows[i]["description"].ToString();
                product.id_size = (int)dt.Rows[i]["id_size"];
                if (dt.Rows[i]["image"] != System.DBNull.Value)
                    product.image = (BitmapSource)new ImageSourceConverter().ConvertFrom(dt.Rows[i]["image"]);

                productList.Add(product);
            }

            listview_product.ItemsSource = productList;
        }

        private void MouseLeftBtn(object sender, RoutedEventArgs e)
        {
            total.id_product = (listview_product.SelectedItem as products).id;
            total.price = (listview_product.SelectedItem as products).price;
            total.name = (listview_product.SelectedItem as products).name;
            total.left = req.select_size((listview_product.SelectedItem as products).id_size);
            total.color = (listview_product.SelectedItem as products).color;
            total.description = (listview_product.SelectedItem as products).description;
            total.image = (listview_product.SelectedItem as products).image;


            Pages.CatalogDialog catalogDialog = new Pages.CatalogDialog();
            catalogDialog.Show();

        }
    }
}
