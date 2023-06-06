using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Billing.DA;
using Billing.Model;
using System.Data.SqlClient;
using Billing.BL;

namespace Billing

{
    /// <summary>
    /// Interaction logic for ProductsD.xaml
    /// </summary>
    public partial class ProductsD : Window
    {
        List<Product> Products = new List<Product>();
        ProDisplay proDisplay = new ProDisplay();
        Product product = new Product();
        Connection connection = new Connection();
        public ProductsD()
        {
            InitializeComponent();
          
            product.Connection = Settings1.Default.Connection;
            proDisplay.Connection = product.Connection;
            product.Cid = Settings1.Default.Cid;
            proDisplay.Cid = Settings1.Default.Cid; 
            datagridProduct.ItemsSource = proDisplay.Display(Query.proQuery);
            datagridProduct.Items.Refresh();
            txtcart.Text = proDisplay.Count().ToString();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          Button button= (Button)sender;
            DataGridRow dataGridRow = FindVisualParent<DataGridRow>(button);
            Product prodata = (Product)dataGridRow.DataContext;
            product.productName = prodata.productName;
            prodata.productid = proDisplay.Productid(product);
           int value = proDisplay.InsertQuery(prodata);

            if (value > 0)
            {
                MessageBox.Show("Succesfully Added","CART",MessageBoxButton.OK, MessageBoxImage.Information);
                txtcart.Text = proDisplay.Count().ToString();
            }
         }

        private void btnsearch_Click(object sender, RoutedEventArgs e)
        {
         
            product.Search = txtsearch.Text;
            datagridProduct.ItemsSource = proDisplay.Display(Query.searchQuery(product));
            datagridProduct.Items.Refresh();
        }

        private void comboprice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(comboprice.SelectedIndex == 0)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.HighQuery);
                datagridProduct.Items.Refresh();
            }
            if (comboprice.SelectedIndex == 1)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.LowQuery);
                datagridProduct.Items.Refresh();
            }
        }

        private void comborange_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comborange.SelectedIndex == 0)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.Range500);
                datagridProduct.Items.Refresh();
            }
            if (comborange.SelectedIndex == 1)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.Range1000);
                datagridProduct.Items.Refresh();
            }
            if (comborange.SelectedIndex == 2)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.Range1500);
                datagridProduct.Items.Refresh();
            }
            if (comborange.SelectedIndex == 3)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.Range2500);
                datagridProduct.Items.Refresh();
            }
            if (comborange.SelectedIndex == 4)
            {
                datagridProduct.ItemsSource = proDisplay.Display(Query.Range4000);
                datagridProduct.Items.Refresh();
            }
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart();
            cart.ShowDialog();
            this.Close();
        }
    }
    }

