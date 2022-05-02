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

        private void MouseLeftBtn(object sender, RoutedEventArgs e)
        {
            total.id_product = (listview_product.SelectedItem as products).id;
            total.price = (listview_product.SelectedItem as products).price;
            total.name = (listview_product.SelectedItem as products).name;
            //total.left = (listview_product.SelectedItem as products).left;
            total.color = (listview_product.SelectedItem as products).color;
            total.description = (listview_product.SelectedItem as products).description;
            total.image = (listview_product.SelectedItem as products).image;


            Pages.CatalogDialog catalogDialog = new Pages.CatalogDialog();
            catalogDialog.Show();

        }

        private void ButtonBasket_Click(object sender, RoutedEventArgs e)
        {
            reqDB req = new reqDB();
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
                if (dt.Rows[i]["image"] != System.DBNull.Value)
                    product.image = (BitmapSource)new ImageSourceConverter().ConvertFrom(dt.Rows[i]["image"]);
                total.left = req.select_product_quantity((int)dt.Rows[i]["id_size"]);
                int all_lefl = 
                (int)total.left.Rows[0][0] +
                (int)total.left.Rows[0][1] +
                (int)total.left.Rows[0][2] +
                (int)total.left.Rows[0][3] +
                (int)total.left.Rows[0][4] +
                (int)total.left.Rows[0][5];
                product.left = all_lefl;

                productList.Add(product);
            }

            listview_product.ItemsSource = productList;
        }
    }
}
