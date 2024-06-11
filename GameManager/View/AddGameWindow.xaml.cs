using GameManager.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GameManager.Model;

namespace GameManager.View
{
    public partial class AddGameWindow : Window
    {
        private Client _client;

        public AddGameWindow(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            DataClient gameData = new DataClient()
            {
                Title = TitleBox.Text,
                Developer = DeveloperBox.Text,
                Rating = RatingBox.Text,
                Review = ReviewBox.Text
            };

            _client.SendGameData(gameData);
            this.Close();
        }

        private void Border4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Close_Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
