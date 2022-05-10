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
        string mailr =
    "<html>" +
    "<tbody>" +
    "<tr>" +
    "<td>" +
    "<table width=\"660\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td height=\"30\"></td>" +
    "</tr>" +
    "<tr>" +
    "<td width=\"20\"></td>" +
    "<td width=\"620\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:24px;line-height:31px;color:#505050;font-weight:bold\">" +
    "Заказ № {Order number}: электронный чек</td>" +
    "<td width=\"20\"></td>" +
    "</tr>" +
    "<tr>" +
    "<td height=\"8\"></td>" +
    "</tr>" +
    "<tr>" +
    "<td height=\"30\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td>" +
    "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td width=\"660\">" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td width=\"130\"></td>" +
    "<td width=\"400\" bgcolor=\"#EFEFEF\">" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td width=\"20\"></td>" +
    "<td width=\"360\">" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"color:#505050\">" +
    "<tbody>" +
    "<tr>" +
    "<td height=\"14\"></td>" +
    "</tr>" +
    "<tr align=\"center\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:15px;font-weight:bold\">" +
    "<td height=\"15\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:20px;font-weight:bold;color:#505050\">" +
    "Cash receipt</td>" +
    "</tr>" +
    "<tr>" +
    "<td height=\"10\"></td>" +
    "</tr>" +
    "<tr align=\"center\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:15px\">" +
    "<td height=\"20\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:20px;color:#505050\">" +
    "\"King's Cloth\"</td>" +
    "</tr>" +
    "<tr align=\"center\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:15px\">" +
    "<tr align=\"center\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:15px\">" +
    "<td height=\"20\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:15px;line-height:20px;color:#505050\">" +
    "Online-Store <a href=\"King's Cloth\" target=\"_blank\">King's.Cloth.ru</a></td>" +
    "</tr>" +
    "<tr>" +
    "<td>" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Date of issue:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "{Date}</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Website of the Federal Tax Service:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<a href=\"http://nalog.ru\" target=\"_blank\" data-saferedirecturl=\"https://www.google.com/url?hl=ru&amp;q=http://nalog.ru&amp;source=gmail&amp;ust=1651323559361000&amp;usg=AOvVaw2BbJTSprF6g3kv1CLlEX33\">nalog.ru</a></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Buyer email address:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<a href=\"mailto:{recipient's mail}\" target=\"_blank\">{recipient's mail}</a></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Check sender's email address:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<a href=\"mailto:kings.cloth.dp@gmail.com\" target=\"_blank\">kings.cloth.dp@gmail.com</a></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td height=\"20\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "<td width=\"20\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "<td width=\"130\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td>" +
    "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td width=\"660\">" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td width=\"130\"></td>" +
    "<td width=\"400\" bgcolor=\"#EFEFEF\">" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr>" +
    "<td width=\"20\"></td>" +
    "<td width=\"360\">" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"color:#505050\">" +
    "<tbody>" +
    "<tr>" +
    "<td height=\"5\"></td>" +
    "</tr>" +
    "<tr>" +
    "<td>" +
    "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">" +
    "<tbody>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"31\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:24px;line-height:31px;color:#505050\">" +
    "TOTAL:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:24px;line-height:31px;color:#505050\">" +
    "{Cost}</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Prepayment (prepaid expense):</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "0.00</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Other form of payment:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "0.00</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Иная форма оплаты:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "0.00</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Cash:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "0.00</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Cashless:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "{Cost}</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>Including taxes</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "</td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>Price without VAT:</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>0.00</i></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>VAT amount 10/110:</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>0.00</i></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>VAT amount 20/120:</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>{NDS}</i></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>Amount including VAT 0%:</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>0.00</i></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>Amount including VAT 10%:</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>0.00</i></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>Amount including VAT 20%:</i></td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "<i>0.00</i></td>" +
    "</tr>" +
    "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
    "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "Taxation system:</td>" +
    "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
    "DOS</td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "<tr>" +
    "<td height=\"13\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "<td width=\"20\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "<td width=\"130\"></td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</tbody>" +
    "</table>" +
    "</td>" +
    "</tr>" +
    "</tbody>" +
    "</html>";

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
                basket.size = basket_data.dt_size.Columns[1].ColumnName.ToString();

                
                for (int y = 0; y < basket_data.dt_size.Rows.Count; y++)
                {
                    if (basket_data.dt_size.Rows[i][y] != DBNull.Value)
                    {
                        basket.count_size = (int)basket_data.dt_size.Rows[i][y];
                    }
                    
                }
                if (basket_data.dt_prod.Rows[i]["image"] != System.DBNull.Value)
                    basket.image = (BitmapSource)new ImageSourceConverter().ConvertFrom(basket_data.dt_prod.Rows[i]["image"]);

                basketList.Add(basket);
            }
            listview_basket.ItemsSource = basketList;
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            if ((listview_basket.SelectedItem as basket).count_size > (listview_basket.SelectedItem as basket).count)
            {
                (listview_basket.SelectedItem as basket).count = (listview_basket.SelectedItem as basket).count + 1;
            } 
            listview_basket.Items.Refresh();
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if ((listview_basket.SelectedItem as basket).count > 1)
            (listview_basket.SelectedItem as basket).count = (listview_basket.SelectedItem as basket).count - 1;
            listview_basket.Items.Refresh();
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
        }

        private void ButtonSendCheck_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress("kings.cloth.dp@gmail.com", "King's Cloth");
            //Куда отправлять
            MailAddress to = new MailAddress("nicken1898@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Check";
            m.Body = mailr;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("kings.cloth.dp@gmail.com", "KingsCloth");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
            SuccessfulDialog dialog = new SuccessfulDialog();
            dialog.Show();
        }
    }
}