using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для Storage.xaml
    /// </summary>
    public partial class Storage : Page
    {
        public Storage()
        {
            InitializeComponent();
            update_listView();
        }

        DataTable table = new DataTable();


        private void update_listView()
        {
            listviewUsers.Items.Clear();

            reqDB db = new reqDB();
            table = db.select_storage();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                this.listviewUsers.Items.Add(new storages
                {
                    image = (byte[])table.Rows[i][0],
                    id = (int)table.Rows[i][1],
                    address = table.Rows[i][2].ToString(),
                    capacity = table.Rows[i][3].ToString(),
                    phone = table.Rows[i][4].ToString(),
                });

            }
        }
    }
}
