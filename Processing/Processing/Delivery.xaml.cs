using Processing.Model;
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

namespace Processing
{
    /// <summary>
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Window
    {
        MainWindow main = new MainWindow();
        public Delivery()
        {
            InitializeComponent();
            //OrderProcess order =(OrderProcess)lstname.SelectedItem;
            //MainWindow main = new MainWindow();
            //main.lstname.SelectedItem = order.Name = txtame.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderProcess order =new OrderProcess();
            MainWindow main=new MainWindow();
            main.lstname.SelectedItem = order.Name = txtame.Text;
            
        }
    }
}
