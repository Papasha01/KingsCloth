using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Media.Imaging;

namespace KingsCloth
{
    public static class basket_data
    {
        public static DataTable[] dt_prod = new DataTable[] {};
        public static DataTable[] dt_size = new DataTable[] {};
        //public static DataTable dt = new DataTable{};

        public static void insert(ref DataTable[] dataTables, DataTable dataTable)
        {
            DataTable[] datas = new DataTable[dataTables.Length + 1];
            for (int i = 0; i < dataTables.Length; i++)
                datas[i] = dataTables[i];
            datas[datas.Length-1] = dataTable;
            dataTables = datas;
        }
    }
}
