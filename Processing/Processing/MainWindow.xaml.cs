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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Processing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            List<OrderProcess> processs = new List<OrderProcess>()
            {
                new OrderProcess {Number=1,OrderID=1,Name="BAT",Unit=200,Quantaty=2,Total=500},
                 new OrderProcess {Number=2,OrderID=2,Name="BALL",Unit=300,Quantaty=3,Total=600},
                  new OrderProcess {Number=3,OrderID=3,Name="KIT",Unit=400,Quantaty=4,Total=700}
            };
            lstname.ItemsSource=processs;

        }
    }
}
