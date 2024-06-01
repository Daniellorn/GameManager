using GameManager.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace GameManager.View
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private Client _tcpClient;
        public SecondWindow(string username)
        {
            InitializeComponent();
            Username.Text = username;
            _tcpClient = new Client();
            _tcpClient.ConnectToServer();
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            _tcpClient.Disconnect();
            Application.Current.Shutdown();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddGameWindow addGameWindow = new AddGameWindow(_tcpClient);
            addGameWindow.Show();
        }
    }
}
