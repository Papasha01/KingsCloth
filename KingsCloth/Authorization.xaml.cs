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
using MySql.Data.MySqlClient;

namespace KingsCloth
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {

        public Authorization()
        {
            InitializeComponent();
        }
        reqDB req = new reqDB();
        public void btnSignIn(object sender, RoutedEventArgs e)
        {
            string log, pas;
            log = txLogin.Text;
            pas = txPas.Password;
            var data = req.select_access(log, pas);

            if (data.Rows.Count > 0)
            {
                switch (data.Rows[0]["id_access"])
                {
                    case 1:
                        MainWindow mw = new MainWindow();
                        Hide();
                        mw.ShowDialog();
                        Close();
                        break;
                    case 2:
                        MessageBox.Show("2");
                        break;
                    case 3:
                        MessageBox.Show("3");
                        break;
                }

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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
