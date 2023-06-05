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


        string ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog = Demo; Data Source = LAPTOP-PJRIF9P6;encrypt = False";
      public  string ProQuery { get; set; }
        public SqlDataAdapter ProductQuery()
        {
            Product product = new Product();
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
