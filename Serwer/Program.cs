﻿using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Serwer.Data;
using System.Text.Json;


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
            }


        }


        static void HandleClient(TcpClient client) 
        {

            byte[] buffer = new byte[1024];
            int bytesRead;

            NetworkStream stream = client.GetStream();

            bytesRead = stream.Read(buffer, 0, buffer.Length);
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Odebrano: {0}", dataReceived);    

            bytesRead = stream.Read(buffer, 0, dataReceived.Length);
            string jsonData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Server received gamedata");

            Console.WriteLine(jsonData);

            DataServer dataServer = JsonSerializer.Deserialize<DataServer>(jsonData);

            Console.WriteLine($"{ dataServer.Title }" );

        }



    }

}
