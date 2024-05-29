using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;


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
            var client = listener.AcceptTcpClient();
            Console.WriteLine("Client has connected");


            byte[] buffer = new byte[1024];
            int bytesRead;

            NetworkStream stream = client.GetStream();

            bytesRead = stream.Read(buffer, 0, buffer.Length);
            // Konwersja danych na string
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Odebrano: {0}", dataReceived);    

        }
    }

}
