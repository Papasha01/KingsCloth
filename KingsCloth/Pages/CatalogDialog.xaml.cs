﻿using System;
using System.Collections.Generic;
using System.Data;
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
            tx_cost.Text = "Price: " + total.price.ToString() + "$";
            pic_product.Source = total.image;
            for (int i = 0; i <= 5; i++)
            {
                enable_btn(i);
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

        reqDB req = new reqDB();

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt_prod = req.select_product_by_id(total.id_product);
            DataTable dt_size = req.select_size(total.id_product);
            basket_data.insert(ref basket_data.dt_prod, dt_prod);
            basket_data.insert(ref basket_data.dt_size, dt_size);

        }

        public void enable_btn(int index)
        {
            
            switch (index)
            {
                case 0:
                    {
                        if (total.left.Rows[0]["xs"] != DBNull.Value && total.left.Rows[0]["xs"].ToString() != "0")
                            tx_left.Text = "Left: " + total.left.Rows[0]["xs"].ToString();
                        else
                            btn_xs.IsEnabled = false;
                            btn_xs.IsSelected = false;
                    }
                    break;
                case 1:
                    {
                        if (total.left.Rows[0]["s"] != DBNull.Value && total.left.Rows[0]["s"].ToString() != "0")
                            tx_left.Text = "Left: " + total.left.Rows[0]["s"].ToString();
                        else
                            btn_s.IsEnabled = false;
                    }
                    break;
                case 2:
                    {
                        if (total.left.Rows[0]["m"] != DBNull.Value && total.left.Rows[0]["m"].ToString() != "0")
                            tx_left.Text = "Left: " + total.left.Rows[0]["m"].ToString();
                        else
                            btn_m.IsEnabled = false;
                    }
                    break;
                case 3:
                    {
                        if (total.left.Rows[0]["l"] != DBNull.Value && total.left.Rows[0]["l"].ToString() != "0")
                            tx_left.Text = "Left: " + total.left.Rows[0]["l"].ToString();
                        else
                            btn_l.IsEnabled = false;
                    }
                    break;
                case 4:
                    {
                        if (total.left.Rows[0]["xl"] != DBNull.Value && total.left.Rows[0]["xl"].ToString() != "0")
                            tx_left.Text = "Left: " + total.left.Rows[0]["xl"].ToString();
                        else
                            btn_xl.IsEnabled = false;
                    }
                    break;
                case 5:
                    {
                        if (total.left.Rows[0]["xxl"] != DBNull.Value && total.left.Rows[0]["xxl"].ToString() != "0")
                            tx_left.Text = "Left: " + total.left.Rows[0]["xxl"].ToString();
                        else
                            btn_xxl.IsEnabled = false;
                    }
                    break;
            }
        }

        public void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enable_btn(listbox.SelectedIndex);
        }
    }
}
