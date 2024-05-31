using GameManager.net;
using GameManager.View;
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

namespace GameManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Username { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void ConnectButton(object sender, RoutedEventArgs e)
        {

            Client client = new Client(Username);
            client.ConnectToServer();


            SecondWindow newWindow = new SecondWindow(Username, client);
            this.Visibility = Visibility.Hidden;


            newWindow.Show(); //tutaj jeszcze serwer sie uruchamia 

            Application.Current.MainWindow = newWindow;
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}