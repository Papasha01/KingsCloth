using System;
using System.Collections.Generic;
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

namespace KingsCloth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            GridBackground.Visibility = Visibility.Visible;

        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            GridBackground.Visibility = Visibility.Hidden;
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Home.xaml", UriKind.RelativeOrAbsolute));
            Title.Text = "Home";
            Title.Visibility = Visibility.Visible;
        }

        private void ButtonOpenSettings_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void ButtonStorage_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Storage.xaml", UriKind.RelativeOrAbsolute));
            Title.Text = "Storage";
            Title.Visibility = Visibility.Visible;
        }

        private void ButtonOpenHelp_Click(object sender, RoutedEventArgs e)
        {

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

        private void ButtonAddUser_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/AddUser.xaml", UriKind.RelativeOrAbsolute));
            Title.Text = "Add User";
            Title.Visibility = Visibility.Visible;

        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/AddProduct.xaml", UriKind.RelativeOrAbsolute));
            Title.Text = "Add Product";
            Title.Visibility = Visibility.Visible;
        }

        private void ButtonStats_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Stats.xaml", UriKind.RelativeOrAbsolute));
            Title.Text = "Stats";
            Title.Visibility = Visibility.Visible;

        }
    }
}
