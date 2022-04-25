using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace KingsCloth
{
    public class reqDB
    {
        db_con db_con = new db_con();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public DataTable select_access(string log, string pas)
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` where login = @log and password = aes_encrypt(@pas,'potato6')", db_con.getConn());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pas;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_user()
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user`", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public void insert_user(string log, string name, string surname, string pass, int id_access)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `user` (`id`, `login`, `name`, `surname`, `password`, `id_access`) " +
                "VALUES (NULL, @log, @name, @surname, aes_encrypt(@pas,'potato6'), '1')", db_con.getConn());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@id_access", MySqlDbType.Int32).Value = id_access;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }
    }
}