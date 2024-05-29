using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.net
{
    class Client
    {
        private string username;

        public Client(string _username)
        {
            username = _username;
        }


        TcpClient client = new TcpClient();

        public void ConnectToServer()
        {
            if (!client.Connected)
            {
                client.Connect("127.0.0.1", 12345);
            }


            byte[] DataToSend = Encoding.ASCII.GetBytes(username);
            NetworkStream stream = client.GetStream();

            stream.Write(DataToSend, 0, DataToSend.Length);

        }

    }
}
