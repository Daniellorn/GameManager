using GameManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameManager.net
{
    public class Client
    {
        private TcpClient client;
        private NetworkStream stream;
        private MsgClient msgclient;

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


        public List<DataClient> GetData()
        {
            List<DataClient> dataClients = new List<DataClient>();

            if (!client.Connected)
            {
                ConnectToServer();
            }

            byte[] requestMsg = Encoding.UTF8.GetBytes("GetData");
            stream.Write(requestMsg, 0, requestMsg.Length);
            stream.Flush();

            byte[] response = new byte[4096];
            int bytesRead = stream.Read(response, 0, response.Length);
            string json = Encoding.UTF8.GetString(response, 0, bytesRead);

            dataClients = JsonSerializer.Deserialize<List<DataClient>>(json);
            

            return dataClients;
        }


        public string DeleteFun(MsgClient message)
        {

            if (!client.Connected)
            {
                ConnectToServer();
            }

            string jsonMsg = JsonSerializer.Serialize(message);
            byte[] dataMsg = Encoding.UTF8.GetBytes(jsonMsg);
            stream.Write(dataMsg, 0, dataMsg.Length);
            stream.Flush();

            byte[] response = new byte[1024];
            int bytesRead = stream.Read(response, 0, response.Length);
            string result = Encoding.UTF8.GetString(response, 0, bytesRead);

            return result;
        }

    }
}
