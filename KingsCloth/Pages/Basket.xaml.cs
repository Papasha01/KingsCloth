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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Page
    {

        public Basket()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            List<basket> basketList = new List<basket>();
            for (int i = 0; i < basket_data.dt_prod.Rows.Count; i++)
            {
                basket basket = new basket();
                basket.id = (int)basket_data.dt_prod.Rows[i]["id"];
                basket.count = 1;
                basket.price = (int)basket_data.dt_prod.Rows[i]["price"];
                basket.name = (string)basket_data.dt_prod.Rows[i]["name"];

                for (int y = 1; y < basket_data.dt_size.Columns.Count; y++)
                {
                    if (basket_data.dt_size.Rows[i][y] != DBNull.Value)
                    {
                        basket.size = basket_data.dt_size.Columns[y].ColumnName.ToString();
                        basket.count_size = (int)basket_data.dt_size.Rows[i][y];
                        break;
                    }
                }

                if (basket_data.dt_prod.Rows[i]["image"] != System.DBNull.Value)
                    basket.image = (BitmapSource)new ImageSourceConverter().ConvertFrom(basket_data.dt_prod.Rows[i]["image"]);

                basketList.Add(basket);
            }
            listview_basket.ItemsSource = basketList;

            update_total_cost();
            update_product_count();
        }




        private int update_product_count()
        {
            total.badget_count = 0;
            for (int i = 0; i < listview_basket.Items.Count; i++)
            {
                total.badget_count += (listview_basket.Items[i] as basket).count;
            }

            tx_product_count.Text = Convert.ToString("(" + total.badget_count + ")");
           

            return total.badget_count;
        }

        

        public long update_total_cost()
        {
            long total_cost = 0;
            long discount = 0;

            for (int i = 0; i < listview_basket.Items.Count; i++)
            {
                total_cost += (listview_basket.Items[i] as basket).price * (listview_basket.Items[i] as basket).count;
            }
            if (total.code == true)
            {
                total_cost = (long)Math.Round(total_cost * 0.8);
                discount = (long)Math.Round(total_cost * 0.2);
                tx_total_cost.Text = Convert.ToString(total_cost + "$");
            }
            if(total.code == false)
            {
                tx_total_cost.Text = Convert.ToString(total_cost + "$");
            }
            
            total.cost = total_cost.ToString();
            total.discount = discount;
            return total_cost;

        }

        public long update_discount()
        {
            long discount = total.discount;

            return discount;
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            if ((listview_basket.SelectedItem as basket).count_size > (listview_basket.SelectedItem as basket).count)
            {
                (listview_basket.SelectedItem as basket).count = (listview_basket.SelectedItem as basket).count + 1;
                update_product_count();
                update_total_cost();
                listview_basket.Items.Refresh();
            }
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if ((listview_basket.SelectedItem as basket).count > 1)
            {
                (listview_basket.SelectedItem as basket).count = (listview_basket.SelectedItem as basket).count - 1;
                listview_basket.Items.Refresh();
                update_product_count();
                update_total_cost();
            }

        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[1-9]+[0-9]*$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            basket_data.dt_prod.Rows.Remove(basket_data.dt_prod.Rows[listview_basket.SelectedIndex]);
            basket_data.dt_size.Rows.Remove(basket_data.dt_size.Rows[listview_basket.SelectedIndex]);

            List<basket> basket = new List<basket>();
            basket = (List<basket>)listview_basket.ItemsSource;
            basket.RemoveAt(listview_basket.SelectedIndex);
            listview_basket.ItemsSource = basket;
            listview_basket.Items.Refresh();
            update_total_cost();
            update_product_count();
        }

        private void ButtonSendCheck_Click(object sender, RoutedEventArgs e)
        {
            string products = "";

            for (int i = 0; i < listview_basket.Items.Count; i++)
            {
                products += ((listview_basket.Items[i] as basket).name + "; ");
            }


            reqDB req = new reqDB();
            try
            {
                req.insert_history(update_total_cost(),
                    products,
                    tx_fio.Text,
                    Convert.ToInt64(tx_phone.Text),
                    tx_email.Text,
                    tx_address.Text, DateTime.Now.ToString(),
                    update_discount(), update_product_count()); ;
                total.email = tx_email.Text;
                SuccessfulDialog dialog = new SuccessfulDialog();
                dialog.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Введены не корректные данные");
            }
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (promo.Text.Equals("sale"))
            {
                promo.Foreground = Brushes.Green;
                total.code = true;
                update_total_cost();
            }
            else
            {
                promo.Foreground = Brushes.Red;
                total.code = false;
                update_total_cost();
            }
        }
    }
}