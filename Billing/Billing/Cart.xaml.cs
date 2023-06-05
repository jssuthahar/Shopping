using Billing.BL;
using Billing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Billing.DA;
using Billing.Model;
using System.Data.SqlClient;
using Billing.BL;

namespace Billing
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        List<Product> Products = new List<Product>();
        ProDisplay proDisplay = new ProDisplay();
        Product product = new Product();

        int total;
        public Cart()
        {
            InitializeComponent();
            datagrid.ItemsSource = proDisplay.Cart(Query.CartQuery);
            datagrid.Items.Refresh();
            txtitems.Text = datagrid.Items.Count.ToString();
            txtitemcost.Text = proDisplay.PriceTotaal().ToString();
            total = proDisplay.PriceTotaal() + Query.Delivery;
            txttotalcost.Text = total.ToString();
        }

        private void btnsub_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);
            Product prodata = (Product)dataGridRow.DataContext;
            product.productName = prodata.productName;
            prodata.productid = proDisplay.Productid(product);
            int value = proDisplay.Updatesub(prodata);
            int Quantity = proDisplay.Quantity(prodata);
            product.productid = proDisplay.Productid(product);
            product.Quantity = Quantity.ToString();
            product.price = prodata.price;
            int value1 = proDisplay.Total(product);
            datagrid.ItemsSource = proDisplay.Cart(Query.CartQuery);
            datagrid.Items.Refresh();
            txtitemcost.Text = proDisplay.PriceTotaal().ToString();
            total = proDisplay.PriceTotaal() + Query.Delivery;
            txttotalcost.Text = total.ToString();
        }

        private void btnadd_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);
            Product prodata = (Product)dataGridRow.DataContext;
            product.productName = prodata.productName;
            prodata.productid = proDisplay.Productid(product);
            int value = proDisplay.Updateadd(prodata);
           int Quantity = proDisplay.Quantity(prodata);
            product.productid = proDisplay.Productid(product);
            product.Quantity = Quantity.ToString();
            product.price = prodata.price;
            int value1 = proDisplay.Total(product);
            datagrid.ItemsSource = proDisplay.Cart(Query.CartQuery);
            datagrid.Items.Refresh();
            txtitemcost.Text = proDisplay.PriceTotaal().ToString();
            total = proDisplay.PriceTotaal() + Query.Delivery;
            txttotalcost.Text = total.ToString();
        }

        private T FindVisualParent<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                if (obj is T parent)
                {
                    return parent;
                }
                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductsD products1 = new ProductsD();
            products1.ShowDialog();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);
            Product prodata = (Product)dataGridRow.DataContext;
            product.productName = prodata.productName;
            prodata.productid = proDisplay.Productid(product);
            MessageBoxResult boxResult =  MessageBox.Show($"Do you want to remove {product.productName} from your Cart ?", "Cart", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (boxResult == MessageBoxResult.Yes)
            {
                int value = proDisplay.RemoveQuery(prodata);
                if (value > 0)
                {
                    MessageBox.Show("Sucessfully Removed From Cart", "Cart", MessageBoxButton.OK, MessageBoxImage.None);
                    txtitemcost.Text = proDisplay.PriceTotaal().ToString();
                    total = proDisplay.PriceTotaal() + Query.Delivery;
                    txttotalcost.Text = total.ToString();
                }
                datagrid.ItemsSource = proDisplay.Cart(Query.CartQuery);
                datagrid.Items.Refresh();
            }
     }
        int count = 0;
        private void btnPromo_Click(object sender, RoutedEventArgs e)
        {
            count++;
            if(!string.IsNullOrEmpty(txtpromocode.Text) && count == 1)
            {
                if(txtpromocode.Text == Query.promo)
                {
                    promovalid.Visibility= Visibility.Visible;
                    int total =Convert.ToInt32(txttotalcost.Text);
                    double discount = 20;

                    double offer = total * (discount / 100);
                    int discountprice = total - (int) offer;
                    txttotalcost.Text = discountprice.ToString();
                    
                }
                else
                {
                    promoinvalid.Visibility= Visibility.Visible;
                }
            }
        }

        private void btncheckout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
   

