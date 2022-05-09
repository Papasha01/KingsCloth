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

namespace KingsCloth.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void ThemeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Colors/LightTheme.xaml", UriKind.RelativeOrAbsolute) });
        }

        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            App.Current.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("Colors/DarkTheme.xaml", UriKind.RelativeOrAbsolute) });
        }
    }
}

