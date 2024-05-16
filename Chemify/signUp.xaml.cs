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
    /// Interaction logic for signUp.xaml
    /// </summary>
    public partial class signUp : Window
    {
        public signUp()
        {
            InitializeComponent();
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            string _connectionString = SQLDataAccess.GetConnectionString();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                string cmdText = "INSERT into UserData (Email, Username, Password) values (@Email, @Username, @Password)";
                SqlCommand sqlCmd = new SqlCommand(cmdText, con);
                sqlCmd.Parameters.AddWithValue("@Username", nameBox.Text);
                sqlCmd.Parameters.AddWithValue("@Email", emailBox.Text);
                if (passBox.Password == confPassBox.Password)
                {
                    sqlCmd.Parameters.AddWithValue("@Password", passBox.Password);
                }
                sqlCmd.ExecuteNonQuery();
                signUp.Close();
                LessonsMenu lessonsMenu = new LessonsMenu();
                lessonsMenu.Show();
            }
            
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
