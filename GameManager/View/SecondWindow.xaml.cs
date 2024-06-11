using GameManager.Model;
using GameManager.net;
using GameManager.ViewModel;
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
        private GameViewModel _viewModel;
        public SecondWindow(string username)
        {
            InitializeComponent();
            Username.Text = username;
            _tcpClient = new Client();  
            _tcpClient.ConnectToServer();
            _viewModel = new GameViewModel();
            DataContext = _viewModel;
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

        private void Load_games_button_Click(object sender, RoutedEventArgs e)
        {
            List<DataClient> games = _tcpClient.GetData();
            _viewModel.Games.Clear();

            foreach (var game in games)
            {
                _viewModel.Games.Add(game);
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteGameWindow deleteGameWindow = new DeleteGameWindow(_tcpClient);
            deleteGameWindow.Show();
        }

        private void Border2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Edit_Button_Click(object sender, RoutedEventArgs e)
        {
            EditGameWindow editGameWindow = new EditGameWindow(_tcpClient);
            editGameWindow.Show();
        }
    }
}
