using GameManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameManager.net
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;

        public Client()
        {
            client = new TcpClient();
        }



        public void ConnectToServer()
        {
            if (!client.Connected)
            {
                client.Connect("127.0.0.1", 12345);
                stream = client.GetStream();
            }
        }


        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }


        public void SendGameData(DataClient data)
        {
            try
            {

                if (!client.Connected)
                {
                    ConnectToServer();

                }

                string jsonString = JsonSerializer.Serialize(data);
                byte[] dataToSend = Encoding.UTF8.GetBytes(jsonString);
                stream.Write(dataToSend, 0, dataToSend.Length);
                stream.Flush();
                
            }
            catch (JsonException e)
            {
                Console.WriteLine($"JSON Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error sending msg: {e.Message}");
            }
        }

    }
}
