using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseQueries
{
    public class Queries
    {
        SqlConnection conn;
        SqlCommand cmd;

        public Queries(SqlConnection connectionString)
        {
            conn = connectionString;
        }

        public void Connect()
        {
            conn.Open();
        }

        public void Disconnect()
        {
            conn.Close();
        }

        public void SetSqlCommand(string query)
        {
            cmd = new SqlCommand(query,conn);
        }

        public DataTable RunSelectQuery()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public void AddQueryParameters(string query, object parameter)
        {
            cmd.Parameters.AddWithValue(query, parameter);
        }

    }
}
