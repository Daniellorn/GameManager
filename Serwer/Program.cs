using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Serwer.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations.Operations;


namespace TcpServer
{
    class Program
    {
        static TcpListener listener;

        static void Main(string[] args)
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 12345);
            listener.Start();

            Console.WriteLine("Server is listening...");

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Client has connected");

                HandleClient(client);

                Console.WriteLine("Client has disconnected");
            }


        }


        static void HandleClient(TcpClient client) 
        {

            byte[] buffer = new byte[4096];
            int bytesRead;

            NetworkStream stream = client.GetStream();    

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string jsonData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Server received data");
                Console.WriteLine(jsonData);

                MsgServer msgServer;

                if (jsonData == "GetData")
                {
                    UsingDB usingDB = new UsingDB();
                    var data = usingDB.GetAllData();

                    string Response = JsonSerializer.Serialize(data);
                    byte[] ResponseBytes = Encoding.UTF8.GetBytes(Response);
                    stream.Write(ResponseBytes, 0, ResponseBytes.Length);
                    stream.Flush();

                    Console.WriteLine(Response);
                }
                else if ((msgServer = JsonSerializer.Deserialize<MsgServer>(jsonData)).msg == "Delete")
                {
                    UsingDB usingDB = new UsingDB();

                    Console.WriteLine(msgServer.id);
                    bool result = usingDB.DeleteData(msgServer.id);

                    Console.WriteLine(result);

                    if (!result)
                    {
                        byte[] requestMsg = Encoding.UTF8.GetBytes("Element does not exist.");
                        stream.Write(requestMsg, 0, requestMsg.Length);
                        stream.Flush();
                    }
                    else
                    {
                        byte[] requestMsg = Encoding.UTF8.GetBytes("Element removed");
                        stream.Write(requestMsg, 0, requestMsg.Length);
                        stream.Flush();
                    }

                }
                else
                {
                    DataServer dataServer = JsonSerializer.Deserialize<DataServer>(jsonData);

                    if (dataServer.GameId != 0)
                    {
                        UsingDB data = new UsingDB();
                        Console.WriteLine("edit");
                        data.EditData(dataServer, dataServer.GameId);
                    }
                    else
                    {
                        Console.WriteLine($"{dataServer.Title}");
                        UsingDB SaveToDB = new UsingDB();
                        SaveToDB.SaveData(dataServer);

                    }

                }

            }
        }



    }

}
