﻿using Processing.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Processing.DAL;

namespace Processing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // OrderProcess orderProcess = new OrderProcess();
        public MainWindow()
        {
            InitializeComponent();
            OrderProcess orderProcess = new OrderProcess();
            List<OrderProcess> processs = new List<OrderProcess>()
            {
                new OrderProcess {Number=1,OrderID=1,Name="BAT",Unit=200,Quantaty=2,Total=500},
                 new OrderProcess {Number=2,OrderID=2,Name="BALL",Unit=300,Quantaty=3,Total=600},
                  new OrderProcess {Number=3,OrderID=3,Name="KIT",Unit=400,Quantaty=4,Total=700}
            };
            lstname.ItemsSource = processs;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void lstname_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string value = "";
            //OrderProcess order = (OrderProcess)lstname.SelectedItem;
            //SqlConnection sqlConnection = new SqlConnection(Processing.Property.Settings1.Default.Conn);
            //sqlConnection.Open();
            //string query = "INSERT INTO PROD(NUMBER,ORDERID,ITEMNAME,UNITPRICE,QUANTATY,TOTAL) VALUES(@NUMBER,@ORDERID,@ITEMNAME,@UNITPRICE,@QUANTATY,@TOTAL)";
            //SqlCommand cmd = new SqlCommand(query, sqlConnection);
            //cmd.Parameters.AddWithValue("@NUMBER", order.Number);
            //cmd.Parameters.AddWithValue("@ORDERID", order.OrderID);
            //cmd.Parameters.AddWithValue("@ITEMNAME", order.Name);
            //cmd.Parameters.AddWithValue("@UNITPRICE", order.Unit);
            //cmd.Parameters.AddWithValue("@QUANTATY", order.Quantaty);
            //cmd.Parameters.AddWithValue("@TOTAL", order.Total);
            //cmd.Connection = sqlConnection;
            //cmd.CommandText = value;
            //sqlConnection.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
                lstdata.Visibility = Visibility.Visible;
                OrderProcess order = (OrderProcess)lstname.SelectedItem;
                List<OrderProcess> processs = new List<OrderProcess>()
            {
                new OrderProcess {Number=1,OrderID=order.OrderID,Name=order.Name,Unit=order.Unit,Quantaty=order.Quantaty,Total=order.Total},
            };
                lstdata.ItemsSource = processs;
            
            
            

        }

        private void lstdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBoxResult result=MessageBox.Show("CONTINUE SHIPPING","INFORMATION",MessageBoxButton.YesNoCancel,MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

            }
            if(result == MessageBoxResult.No) 
            {
                
            }
            if (result == MessageBoxResult.Cancel) 
            { 

            }
           
        }
    }
}
