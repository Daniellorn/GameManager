using GameManager.Model;
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
    /// Interaction logic for EditGameWindow.xaml
    /// </summary>
    public partial class EditGameWindow : Window
    {
        private Client _client;

        public EditGameWindow(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void Border5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void EditGame_Click(object sender, RoutedEventArgs e)
        {

            DataClient EditgameData = new DataClient()
            {
                GameId = int.Parse(IDBox.Text),
                Title = EditTitleBox.Text,
                Developer = EditDeveloperBox.Text,
                Rating = EditRatingBox.Text,
                Review = EditReviewBox.Text
            };

            _client.SendGameData(EditgameData);
            this.Close();

        }

        private void EditClose_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
