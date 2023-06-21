using ATM;
using System;
using System.Data;
using System.Configuration;
using System.Windows;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace ATM
{
    class SQL
    {
        private MySqlConnection _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public DataSet GetDataSet(string Sql)
        {
            DataSet dataset = new DataSet();

            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand(Sql, _connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dataset, "LoadDataBinding");
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

            return dataset;
        }

        public DataTable GetDataTable(string sql)
        {
            DataTable datatable = new DataTable();

            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql, _connection);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(datatable);
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

            return datatable;
        }
        public long ExecuteNonQuery(string Sql)
        {
            long ID = 0;
            try
            {
                _connection.Open();
                MySqlCommand cmd = new MySqlCommand(Sql, _connection);

                cmd.ExecuteNonQuery();
                ID = cmd.LastInsertedId;
                _connection.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            return ID;
        }
    }

}
