using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Billing.Model;

namespace Billing.DA
{
    public class Connection
    {

       Product product = new Product();
        public  string ProQuery { get; set; }

        public string ConnectionString { get; set; }
        public SqlDataAdapter ProductQuery()
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery,sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlConnection.Close();
            return sqlDataAdapter;
 }
        public int ProductInsertQuery()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery, sqlConnection);
            int q = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return q;
        }

       public string Getid()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery, sqlConnection);
            object value = sqlCommand.ExecuteScalar();
            return value.ToString();
        }

        public int updateQuery()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery,sqlConnection);
            int q = sqlCommand.ExecuteNonQuery();
            return q;
        }
        public int QuantityQuery()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery, sqlConnection);
            object q = sqlCommand.ExecuteScalar();
            return Convert.ToInt32(q);
        }
        public int TotalQuery()
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(ProQuery, sqlConnection);
            object q = sqlCommand.ExecuteScalar();
            return Convert.ToInt32(q);
        }

    }
}
