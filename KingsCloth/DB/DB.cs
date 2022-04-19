using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingsCloth
{
    class DB
    {
        MySqlConnection conn = new MySqlConnection("Database=kingscloth;Server=194.87.215.89;User=monty;Password=some_pass");

        public void openConn()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }
        public void closeConn()
        {
            
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public MySqlConnection getConn()
        {
            return conn;
        }
    }
}
