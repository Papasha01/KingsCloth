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

namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для CatalogDialog.xaml
    /// </summary>
    public partial class CatalogDialog : Window
    {
        public CatalogDialog()
        {
            InitializeComponent();

            Load();
        }

        private void Load()
        {
            tx_name.Text = total.name;
            tx_cost.Text = total.price.ToString();
            pic_product.Source = total.image;
            tx_left.Text = total.left.ToString();
            listbox.SelectedValue.ToString();
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
