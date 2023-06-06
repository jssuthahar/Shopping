using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billing.DA;
using Billing.Model;

namespace Billing.BL
{
    public class ProDisplay
    {
        List<Product> lstpro;
        Product product;

        public string Cid;
        public string Connection;
        public List<Product> Display(string Query)
        {
           Connection connection = new Connection();
           connection.ProQuery = Query;

            connection.ConnectionString = Connection;
            DataSet dataSet = new DataSet();
            connection.ProductQuery().Fill(dataSet);
            if (lstpro == null)
            {
                lstpro = new List<Product>();
            }
                lstpro.Clear();
             for (int i = 0; i <= dataSet.Tables[0].Rows.Count - 1; i++)
            {
                 product = new Product();
                DataRow dataRow = (DataRow)dataSet.Tables[0].Rows[i];
                product.productDescription = dataRow["description"].ToString();
                product.productName = dataRow["pname"].ToString();
                product.warranty = dataRow["warranty"].ToString();
                product.Cod = dataRow["cod_avaliablity"].ToString();
                product.image = dataRow["image_location"].ToString();
                product.Brand = dataRow["brand"].ToString();
                product.price = dataRow["selling_price"].ToString();
                product.stock = dataRow["stock"].ToString();
                lstpro.Add(product);
            }
            return lstpro;
        }
        public List<Product> Cart(string Query)
        {
            Connection connection = new Connection();
            connection.ConnectionString = Connection;
            connection.ProQuery = Query;
            DataSet dataSet = new DataSet();
            connection.ProductQuery().Fill(dataSet);
            if (lstpro == null)
            {
                lstpro = new List<Product>();
            }
            lstpro.Clear();
            for (int i = 0; i <= dataSet.Tables[0].Rows.Count - 1; i++)
            {
                product = new Product();
                DataRow dataRow = (DataRow)dataSet.Tables[0].Rows[i];
                product.productDescription = dataRow["description"].ToString();
                product.productName = dataRow["productName"].ToString();
                product.image = dataRow["imagelocation"].ToString();
                product.Brand = dataRow["Brand"].ToString();
                product.price = dataRow["price"].ToString();
                product.Totalprice = dataRow["Totalprice"].ToString();
                product.Quantity = dataRow["Quantity"].ToString();
                lstpro.Add(product);
            }
            return lstpro;
        }
           public int InsertQuery(Product product)
        {
            Decimal total = 0;
            total++;
            Decimal totalprice = Convert.ToDecimal(product.price) * total;
            String Query = $"Insert into Cart VALUES('{Cid}','{product.productid}','{product.productName}','{product.productDescription}','1',{product.price},{totalprice},'{product.Brand}','{product.image}')";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.ProductInsertQuery();
            return q;
        }

        public string Productid(Product product)
        {
            String Query = $"SELECT product_id from products WHERE pname = '{product.productName}'";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            string q = con.Getid();
            return q;
        }
        public int Updateadd(Product prop)
        {
            string Query = $"UPDATE Cart SET Quantity = Quantity + 1   WHERE product_id = '{prop.productid}' and Cid = '{Cid}'  ";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.updateQuery();
            return q;
        }
        public int Updatesub(Product prop)
        {
            string Query = $"UPDATE Cart SET Quantity = Quantity - 1 WHERE product_id = '{prop.productid}' and Cid = '{Cid}'  ";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.updateQuery();
            return q;

        }
        public int Total(Product prop)
        {
            Decimal total = Convert.ToDecimal(prop.price) * Convert.ToInt32(prop.Quantity);
            string Query = $"UPDATE Cart SET Totalprice ='{total}' WHERE product_id = '{prop.productid}' and Cid = '{Cid}'";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.updateQuery();
            return q;
        }
        public int Quantity(Product product)
        {
            string Query = $"SELECT Quantity FROM Cart WHERE product_id = '{product.productid}'";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.QuantityQuery();
            return q;
        }
        public int RemoveQuery(Product product)
        {
            string Query = $"DELETE  FROM CART WHERE  product_id = '{product.productid}' and Cid = '{Cid}' ";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.updateQuery();
            return q;
        }
        public int PriceTotaal()
        {
            string Query = $"SELECT SUM(Totalprice) from Cart WHERE Cid = '{Cid}'";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.TotalQuery();
            return q;

        }
        public int Count()
        {
            string Query = $"SELECT Count(*) from Cart WHERE Cid = '{Cid}'";
            Connection con = new Connection();
            con.ConnectionString = Connection;
            con.ProQuery = Query;
            int q = con.TotalQuery();
            return q;

        }

    }
}
