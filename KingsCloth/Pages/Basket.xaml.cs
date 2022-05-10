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
        int i = 1;
        

        public Basket()
        {
            InitializeComponent();
            load();
        }

        private void load()
        {
            List<basket> basketList = new List<basket>();
            for (int i = 0; i < basket_data.dt_prod.Length; i++)
            {
                basket basket = new basket();
                basket.id = (int)basket_data.dt_prod[i].Rows[0]["id"];
                basket.price = (int)basket_data.dt_prod[i].Rows[0]["price"];
                basket.name = (string)basket_data.dt_prod[i].Rows[0]["name"];

                if (basket_data.dt_prod[i].Rows[0]["image"] != System.DBNull.Value)
                    basket.image = (BitmapSource)new ImageSourceConverter().ConvertFrom(basket_data.dt_prod[i].Rows[0]["image"]);

                basketList.Add(basket);
            }
            listview_basket.ItemsSource = basketList;
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            i++;
            //CountTextBox.Text = Convert.ToString(i);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[1-9]+[0-9]*$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (i > 0)
                i--;
            //CountTextBox.Text = Convert.ToString(i);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var i = (listview_basket.SelectedItem as basket).id;
            MessageBox.Show(Convert.ToString(i));
        }

        private void ButtonSendCheck_Click(object sender, RoutedEventArgs e)
        {
            SuccessfulDialog dialog = new SuccessfulDialog();
            dialog.Show();
        }
    }
}