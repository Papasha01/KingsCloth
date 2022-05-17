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
        public DataTable select_access(string log, string pas)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` where login = @log and password = aes_encrypt(@pas,'potato6')", db_con.getConn());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = log;
            command.Parameters.Add("@pas", MySqlDbType.VarChar).Value = pas;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_user()
        {
            DataTable table = new DataTable();
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

        public void insert_product(string name, int price, int id_category, string material, string color, string description, byte[] image, int id_storage, int id_size)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`product` (`id`, `name`, `image`, `price`, `id_category`, `material`, `color`, `description`, id_storage, id_size) " +
                "VALUES (NULL, @name, @image, @price, @id_category, @material, @color, @description, @id_storage, @id_size)", db_con.getConn());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", MySqlDbType.Int32).Value = price;
            command.Parameters.Add("@id_category", MySqlDbType.Int32).Value = id_category + 1;
            command.Parameters.Add("@material", MySqlDbType.VarChar).Value = material;
            command.Parameters.Add("@color", MySqlDbType.VarChar).Value = color;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
            command.Parameters.Add("@id_storage", MySqlDbType.Blob).Value = id_storage;
            command.Parameters.Add("@id_size", MySqlDbType.Blob).Value = id_size;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }

        public DataTable select_max_id_size()
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT max(id) FROM size", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public void insert_size(int xs, int s, int m, int l, int xl, int xxl)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`size` (`id`, `xs`, `s`, `m`, `l`, `xl`, `xxl`) " +
                "VALUES (NULL, @xs, @s, @m, @l, @xl, @xxl)", db_con.getConn());
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
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT photo FROM product where id = @id_product", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            byte[] img = (byte[])table.Rows[0]["image"];
            return img;
        }

        public DataTable select_product()
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `product`", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_product_by_id(int id)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `product` where id = @id", db_con.getConn());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_storage()
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `storage`", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_storage_address()
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT id, address FROM `storage`", db_con.getConn());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_size(int id_prod)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT id, xs, s, m, l, xl, xxl FROM `size` where id = @id_prod", db_con.getConn());
            command.Parameters.Add("@id_prod", MySqlDbType.Int32).Value = id_prod;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable select_size_by_size(int id_prod, string size)
        {
            DataTable table = new DataTable();
            MySqlCommand command = new MySqlCommand("SELECT id, " + size + " FROM `size` where id = @id_prod", db_con.getConn());
            command.Parameters.Add("@id_prod", MySqlDbType.Int32).Value = id_prod;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public void insert_storage(byte[] image)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`storage` (`image`, `id`, `address`, `capacity`, `phone`) " +
                "VALUES (@image, NULL, '136155, Московская область, город Кашира, пер. Космонавтов, 05', '984', '+78917199917')", db_con.getConn());

            command.Parameters.Add("@image", MySqlDbType.Blob).Value = image;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }

        public void insert_history(Int64 cost, string name, string fio, Int64 phone, string email, string address, string date, double discount, int count_prod)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `kingscloth`.`history` (`id_orders`, `cost`, `product`, `fio`, `phone`, `email`, `address`, `date`, `discount`, `count_product`) " +
                "VALUES (NULL, @cost, @name, @fio, @phone, @email, @address, @date, @discount, @count_prod)", db_con.getConn());
            command.Parameters.Add("@cost", MySqlDbType.Int64).Value = cost;
            command.Parameters.Add("@name", MySqlDbType.String).Value = name;
            command.Parameters.Add("@fio", MySqlDbType.String).Value = fio;
            command.Parameters.Add("@phone", MySqlDbType.Int64).Value = phone;
            command.Parameters.Add("@email", MySqlDbType.String).Value = email;
            command.Parameters.Add("@address", MySqlDbType.String).Value = address;
            command.Parameters.Add("@date", MySqlDbType.String).Value = date;
            command.Parameters.Add("@discount", MySqlDbType.Double).Value = discount;
            command.Parameters.Add("@count_prod", MySqlDbType.Int16).Value = count_prod;
            db_con.openConn();
            command.ExecuteNonQuery();
            db_con.closeConn();
        }

        public long select_all_cost()
        {

            MySqlCommand command = new MySqlCommand("SELECT SUM(cost) FROM `history`", db_con.getConn());
            object r1 = command.ExecuteScalar();
            return (long)r1;
        }
    }
}