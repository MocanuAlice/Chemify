using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chemify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            signUp w1 = new signUp();
            //Visibility = Visibility.Hidden;
            w1.Show();
        }

        private void signInBtn_Click(object sender, RoutedEventArgs e)
        {
            signIn w2 = new signIn();
            //Visibility = Visibility.Hidden;
            w2.Show();
        }
    }
}