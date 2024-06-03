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
    /// Interaction logic for DeleteGameWindow.xaml
    /// </summary>
    public partial class DeleteGameWindow : Window
    {
        private Client _client;
        public DeleteGameWindow(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string sID = IDBox.Text;
            int ID = int.Parse(sID);

            MsgClient msg = new MsgClient()
            {
                msg = "Delete",
                id = ID
            };

            string result = _client.DeleteFun(msg);

            MessageBox.Show(result);

            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
