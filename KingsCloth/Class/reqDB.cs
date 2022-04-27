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

        public void insert_product(string name, int price, int id_category, string material, string color, string description, byte[] image)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`product` (`id`, `name`, `image`, `price`, `id_category`, `material`, `color`, `description`) " +
                "VALUES (NULL, @name, @image, @price, @id_category, @material, @color, @description)", db_con.getConn());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@id_category", MySqlDbType.Int32).Value = id_category + 1;
            command.Parameters.Add("@material", MySqlDbType.VarChar).Value = material;
            command.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }
        
        public DataTable select_max_id_product()
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT max(id) FROM product", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public void insert_size(int id_product, int xs, int s, int m, int l, int xl, int xxl)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`size` (`id`, `id_product`, `xs`, `s`, `m`, `l`, `xl`, `xxl`) " +
                "VALUES (NULL, @id_product, @xs, @s, @m, @l, @xl, @xxl)", db_con.getConn());
            command.Parameters.Add("@id_product", MySqlDbType.Int32).Value = id_product;
            command.Parameters.Add("@xs", MySqlDbType.Int32).Value = xs;
            command.Parameters.Add("@s", MySqlDbType.Int32).Value = s;
            command.Parameters.Add("@m", MySqlDbType.Int32).Value = m;
            command.Parameters.Add("@l", MySqlDbType.Int32).Value = l;
            command.Parameters.Add("@xl", MySqlDbType.Int32).Value = xl;
            command.Parameters.Add("@xxl", MySqlDbType.Int32).Value = xxl;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }

        public byte[] select_picture_product(int id_product)
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT photo FROM product where id = @id_product", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            byte[] img = (byte[])table.Rows[0]["image"];
            return img;
        }

        public DataTable select_product()
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `product`", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_storage()
        {
            table.Clear();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `warehouse`", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public void insert_storage(byte[] image)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`warehouse` (`image`, `id`, `address`, `capacity`, `phone`) " +
                "VALUES (@image, NULL, '136155, Московская область, город Кашира, пер. Космонавтов, 05', '984', '+78917199917')", db_con.getConn());

            command.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }
    }
}