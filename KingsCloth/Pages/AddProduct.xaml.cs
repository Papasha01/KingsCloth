using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Drawing;



namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
        {
            InitializeComponent();

        }

        byte[] imageData = null;

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;...",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                var file = openFileDialog.FileName;

                using (FileStream fs = new FileStream(file, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }

                picture.Source = new BitmapImage(new Uri(file));
            }
        }

        private void clck_upload(object sender, RoutedEventArgs e)
        {
            reqDB req = new reqDB();

            using (var stream = new MemoryStream(req.select_picture_product(21)))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                picture.Source = image;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(tx_xs.Text) +
                Convert.ToInt32(tx_s.Text) +
                Convert.ToInt32(tx_m.Text) +
                Convert.ToInt32(tx_l.Text) +
                Convert.ToInt32(tx_xl.Text) +
                Convert.ToInt32(tx_xxl.Text) > 0)
                {
                    reqDB req = new reqDB();
                    req.insert_product(tx_title.Text, Convert.ToInt32(tx_cost.Text), (int)cmb_category.SelectedIndex, tx_material.Text, cmb_color.Text, "some text", imageData);
                    int max_id_product = Convert.ToInt32(req.select_max_id_product().Rows[0][0]);
                    req.insert_size(max_id_product,
                        Convert.ToInt32(tx_xs.Text),
                        Convert.ToInt32(tx_s.Text),
                        Convert.ToInt32(tx_m.Text),
                        Convert.ToInt32(tx_l.Text),
                        Convert.ToInt32(tx_xl.Text),
                        Convert.ToInt32(tx_xxl.Text));
                }
                else
                {
                    MessageBox.Show("Не указано количество товара");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Укажите корректные данные");
                tx_xs.Text = "0";
                tx_s.Text = "0";
                tx_m.Text = "0";
                tx_l.Text = "0";
                tx_xl.Text = "0";
                tx_xxl.Text = "0";
            }
        }


    }
}
