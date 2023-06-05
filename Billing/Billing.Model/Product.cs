using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing.Model
{
    public class Product
    {
       
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string image { get; set; }

        public string price { get; set; }

        public string stock { get; set; }

        public string warranty { get; set; }

        public string Cod { get; set; }

        public string Brand { get; set; }

        public string Quantity { get; set; }

        public string Totalprice { get; set; }

        public string productid { get; set; }
        public string Search { get; set; }
    }
}
