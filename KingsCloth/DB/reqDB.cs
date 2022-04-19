using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KingsCloth
{
    public class reqDB
    {
        DB db = new DB();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public DataTable select_access(string log, string pas)
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` where login = @log and password = @pas", db.getConn());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pas;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
    }
}