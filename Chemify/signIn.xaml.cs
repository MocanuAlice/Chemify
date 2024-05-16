using Chemify.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

            if(UserExist(txtUser.Text, txtPass.Password)) 
            {
                this.Close();
                LessonsMenu lessonsMenu = new LessonsMenu();    
                lessonsMenu.Show();
            }
            else
            {
                MessageBox.Show("Date incorecte!");
               
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            signIn.Close();
            //Visibility = Visibility.Visible;
        }
        public bool UserExist(string email, string password)
        {
            string _connectionString = SQLDataAccess.GetConnectionString();
            using (SqlConnection con=new SqlConnection(_connectionString))
            {
                con.Open();
                string cmdText = "Select Email,Password from UserData where Email=@email and Password=password";
                using(SqlCommand cmd=new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("Email",email);
                    cmd.Parameters.AddWithValue("Password",password);
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
