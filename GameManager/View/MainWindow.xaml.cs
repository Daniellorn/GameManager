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
            SecondWindow newWindow = new SecondWindow(Username);
            this.Visibility = Visibility.Hidden;


            newWindow.Show();

            Application.Current.MainWindow = newWindow;
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

    }
}