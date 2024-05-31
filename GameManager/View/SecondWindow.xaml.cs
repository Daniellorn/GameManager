using GameManager.net;
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

namespace GameManager.View
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private readonly Client _client;
        public SecondWindow(string username, Client client)
        {
            InitializeComponent();
            Username.Text = username;
            _client = client;
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            _client.Disconnect();
            Application.Current.Shutdown();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddGameWindow addGameWindow = new AddGameWindow(_client);
            addGameWindow.Show();
        }
    }
}
