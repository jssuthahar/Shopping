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
using System.Data.SqlClient;
namespace Billing
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
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

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            if (txtbox_email.Text != null && txtbox_name.Text != null && txtbox_phnum.Text!=null && passwordTxtBox.Text!=null)
            {
                SqlConnection sql = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Leecart;Data Source=NANDHU");
                sql.Open();
                string query = $"INSERT INTO CUSTOMERS VALUES('{txtbox_name.Text}','{txtbox_email.Text}','{passwordTxtBox.Text}',{txtbox_phnum.Text})";
                SqlCommand command = new SqlCommand(query, sql);
                command.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Your registration successfully completed", "Signup", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();
        }

        private void chkbox_password_Checked(object sender, RoutedEventArgs e)
        {
            passwordTxtBox.Text = passwordBox.Password;
            passwordBox.Visibility = Visibility.Hidden;
            passwordTxtBox.Visibility = Visibility.Visible;
        }

        private void chkbox_password_Unchecked(object sender, RoutedEventArgs e)
        {
            passwordBox.Password = passwordTxtBox.Text;
            passwordTxtBox.Visibility = Visibility.Hidden;
            passwordBox.Visibility = Visibility.Visible;
        }
    }
}
