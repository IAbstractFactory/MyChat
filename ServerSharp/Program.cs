using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 8080);
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                byte[] name = new byte[256];
                int length = client.GetStream().Read(name);
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()} {Encoding.Unicode.GetString(name).Substring(0, length)}");
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        var stream = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int lenght = stream.Read(buffer);

                        Console.WriteLine(Encoding.Unicode.GetString(buffer).Substring(0, lenght));
                    }
                }));
                thread.Start();
            }
        }
    }
}

