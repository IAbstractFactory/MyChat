
using ServerSharp;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            Console.Write("Введите имя: ");
            ClientObject client = new ClientObject(Console.ReadLine());
            var stream = tcpClient.GetStream();
            byte[] bufferName = Encoding.Unicode.GetBytes(client.Name + " подключился!");
            stream.Write(bufferName, 0, bufferName.Length);
            while (true)
            {
                var message = Console.ReadLine();
                var buffer = Encoding.Unicode.GetBytes(DateTime.Now.ToShortTimeString() + " " + client.Name + ": " + message);
                stream.Write(buffer, 0, buffer.Length);
            }
        }

    }
}
