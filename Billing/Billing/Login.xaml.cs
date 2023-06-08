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
namespace Billing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_signin_Click(object sender, RoutedEventArgs e)
        {
            checkbox_password.IsChecked = false;
            SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Leecart;Data Source=NANDHU");
            sql.Open();
            string email= txtbox_email.Text,password=passwordBox.Password;
            string query = $"SELECT COUNT(*) FROM CUSTOMERS WHERE EMAIL='{email}' AND PASSWORD='{password}'";
            SqlCommand command = new SqlCommand(query, sql);
            //command.ExecuteScalar();
            object val = command.ExecuteScalar();
            int check = Convert.ToInt32(val);
            if(check == 0)
            {
                MessageBox.Show("Invalid Credentials","Login",MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Successfully Logged In", "Login", MessageBoxButton.OKCancel, MessageBoxImage.Information);    
            }
        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.RightButton == MouseButtonState.Pressed)
            {
                Close();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Hidden;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Visible;
        }
    }
}
