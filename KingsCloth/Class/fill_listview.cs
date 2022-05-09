using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Media.Imaging;

namespace KingsCloth
{
    public class users
    {
        public int id { get; set; }
        public string login { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string id_access { get; set; }
    }

    public class storages
    {
        public byte[] image { get; set; }
        public int id { get; set; }
        public string address { get; set; }
        public string capacity { get; set; }
        public string phone { get; set; }
    }

    public class products
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public BitmapSource image { get; set; }
        public int id_size { get; set; }

        //public string material { get; set; }
    }

    public class basket
    {
        public int id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public int price { get; set; }
        public BitmapSource image { get; set; }
        public int id_size { get; set; }
        public int xs { get; set; }
        public int s { get; set; }
        public int m { get; set; }
        public int l { get; set; }
        public int xl { get; set; }
        public int xxl { get; set; }
    }

    public class size
    {


    }
}
