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
            SuccessfulDialog dialog = new SuccessfulDialog();
            dialog.Show();
        }
    }
}
