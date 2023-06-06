using Processing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Processing.DAL
{
    public class Access
    {
      //public int store()
      //  {
      //      OrderProcess order=new OrderProcess();
      //      string value = "";
      //      SqlConnection sqlConnection = new SqlConnection(Processing.Property.Settings1.Default.Conn);
      //      sqlConnection.Open();
      //      string query = "INSERT INTO PROD(NUMBER,ORDERID,ITEMNAME,UNITPRICE,QUANTATY,TOTAL) VALUES(@NUMBER,@ORDERID,@ITEMNAME,@UNITPRICE,@QUANTATY,@TOTAL)";
      //      SqlCommand cmd = new SqlCommand(query, sqlConnection);
      //      cmd.Parameters.AddWithValue("@NUMBER", order.Number);
      //      cmd.Parameters.AddWithValue("@ORDERID", order.OrderID);
      //      cmd.Parameters.AddWithValue("@ITEMNAME", order.Name);
      //      cmd.Parameters.AddWithValue("@UNITPRICE", order.Unit);
      //      cmd.Parameters.AddWithValue("@QUANTATY", order.Quantaty);
      //      cmd.Parameters.AddWithValue("@TOTAL", order.Total);
      //      cmd.Connection = sqlConnection;
      //      cmd.CommandText = value;
      //      sqlConnection.Close();
      //  }
    }
}
