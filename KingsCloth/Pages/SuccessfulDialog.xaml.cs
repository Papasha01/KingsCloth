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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Net.Mail;
using System.Net;


namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuccessfulDialog.xaml
    /// </summary>
    public partial class SuccessfulDialog : Window
    {

        const int MaxTimerCounter = 100;
        const int MinTimerCounter = 0;

        DispatcherTimer _dispTimer;
        int _dispTimerCounter;

        string date;
        string cost;
        string email;
        string NDS;
        Random Random;
        string OrderNumber;

        string mailr;

        public SuccessfulDialog()
        {
            InitializeComponent();

            date = DateTime.Now.ToString();
            cost = Convert.ToString(total.cost);
            email = total.email.ToString();
            NDS = Math.Round((Convert.ToDouble(cost) / 120 * 20), 2).ToString();
            Random = new Random();
            OrderNumber = Random.Next(1000, 100000).ToString();

            mailr =
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
        "Order № " + OrderNumber + ": electronic check</td>" +
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
        "" + date + "</td>" +
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
        "<a href=\"mailto:{recipient's mail}\" target=\"_blank\">" + email + "</a></td>" +
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
        "" + cost + "$" + "</td>" +
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
        "Cash:</td>" +
        "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
        "0.00</td>" +
        "</tr>" +
        "<tr style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px\">" +
        "<td height=\"20\" width=\"220\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
        "Cashless:</td>" +
        "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
        "" + cost + "$" + "</td>" +
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
        "<i>VAT amount 20/120:</i></td>" +
        "<td align=\"right\" style=\"font-family:Arial,Helvetica,sans-serif;font-size:13px;line-height:20px;color:#505050\">" +
        "<i>" + NDS + "$" + "</i></td>" +
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
            System.Timers.Timer timer = new System.Timers.Timer();



            _dispTimerCounter = MinTimerCounter;
            _dispTimer = new DispatcherTimer();
            _dispTimer.Interval = TimeSpan.FromMilliseconds(10);
            _dispTimer.Tick += new EventHandler(dispTimer_Tick);
            _dispTimer.Start();
        }
        private void mailsend(string mailr)
        {
            MailAddress from = new MailAddress("kings.cloth.dp@gmail.com", "King's Cloth");
            //Куда отправлять
            MailAddress to = new MailAddress(total.email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Check";
            m.Body = mailr;
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("kings.cloth.dp@gmail.com", "KingsCloth");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
        }
        void dispTimer_Tick(object sender, EventArgs e)
        {
            //сначала выводится значение, потом инкрементируется (не для всех очевидно)
            _dispTimerCounter++.ToString();
            PrBar.Value = _dispTimerCounter;
            if (_dispTimerCounter > MaxTimerCounter)
            {

                TogButt.Background = new SolidColorBrush(Colors.Green);
                PrBar.Background = new SolidColorBrush(Colors.Green);
                PrBar.Foreground = new SolidColorBrush(Colors.Green);
                TogButt.IsChecked = true;
                _dispTimer.Stop();
                mailsend(mailr);
                Order.Text = OrderNumber;
                OK.Visibility = Visibility.Visible;
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _dispTimer.Stop();
        }
    }
}
