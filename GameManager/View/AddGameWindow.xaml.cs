using GameManager.Model;
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

namespace GameManager.View
{
    /// <summary>
    /// Interaction logic for AddGameWindow.xaml
    /// </summary>
    public partial class AddGameWindow : Window
    {
        private readonly Client _client;
        static int _gameId = 1;
        public AddGameWindow(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void AddGame_Click(object sender, RoutedEventArgs e)
        {
            DataClient gameData = new DataClient();

            gameData.GameId = _gameId;  
            gameData.Title = TitleBox.Text;
            gameData.Developer = DeveloperBox.Text;
            gameData.Raiting = RaitingBox.Text;
            gameData.Review = ReviewBox.Text;


            string jsonString = JsonSerializer.Serialize(gameData);

            string directoryPath = @"C:\json";
            string filename = "gamedata.json";

            string filepath = System.IO.Path.Combine(directoryPath, filename);

            File.WriteAllText(filepath, jsonString);

            //MessageBox.Show($"GameID: {gameData.GameId}, Title: {gameData.Title}, Dev: {gameData.Developer}, Raiting: {gameData.Raiting}, Review: {gameData.Review}");
           // MessageBox.Show(gameData.ToString());

            //_client.SendGameData(gameData);
            _gameId++;
            this.Close();
        }
    }
}
