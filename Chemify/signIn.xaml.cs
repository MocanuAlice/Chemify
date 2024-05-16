using Chemify.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Chemify
{
    /// <summary>
    /// Interaction logic for signIn.xaml
    /// </summary>
    public partial class signIn : Window
    {
        public signIn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string mail, password;
            mail=txtUser.Text;
            password=txtPass.Password;
            try
            {
                string querry = "SELECT* FROM User Data WHERE Email='" + txtUser.Text + "'AND password= '" + txtPass.Password + "'";
                //SqlDataAdapter sda=new SqlDataAdapter(querry,);
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {

            }
            

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Visibility = Visibility.Visible;
        }
    }
}
