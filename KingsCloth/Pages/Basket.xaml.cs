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
        }

        private void ButtonPlus_Click (object sender, RoutedEventArgs e)
        {
            i++;
            CountTextBox.Text = Convert.ToString(i);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[1-9]+[0-9]*$");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonMinus_Click (object sender, RoutedEventArgs e)
        {
            if (i>0)
            i--;
            CountTextBox.Text = Convert.ToString(i);
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSendCheck_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress("kings.cloth.dp@gmail.com", "Rinat");
            //Куда отправлять
            MailAddress to = new MailAddress("nicken1898@gmail.com");
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Тест";
            m.Body = "<h2>Письмо-тест работы smtp-клиента</h2>";
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
