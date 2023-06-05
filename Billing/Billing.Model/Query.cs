using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Model
{
    public static class Query
    {
        public  static int Delivery = 40;

        public static string promo = "HURRY20";

        public static string proQuery = "SELECT pname,description,brand,stock,selling_price,warranty,cod_avaliablity,image_location from products";

        public static string CartQuery = "SELECT productName,description,Brand,Quantity,price,Totalprice,imagelocation from Cart";

        public static string HighQuery = "select * from products  ORDER BY selling_price DESC";

        public static string LowQuery = "select * from products  ORDER BY selling_price ASC";

        public static string Range500 = "select * from products  WHERE selling_price <= 500 ";

        public static string Range1000 = "select * from products  WHERE selling_price Between 500 and 1000 ";

        public static string Range1500 = "select * from products  WHERE selling_price Between 1500 and 2500 ";

        public static string Range2500 = "select * from products  WHERE selling_price Between 2500 and 4000 ";

        public static string Range4000 = "select * from products  WHERE selling_price >=4000 ";

        

        public static string searchQuery(Product prop)
        {

            Product product = new Product();
            string para = prop.Search;

            string Query = $"SELECT * FROM products WHERE pname  Like '%{para}%' OR brand  Like '%{para}%' ";

            return Query;


        }

    }
}
