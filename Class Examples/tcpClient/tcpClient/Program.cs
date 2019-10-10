using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcpClient
{
    class Program
    {
        static void ReadData(object socket)
        {
            TcpClient client = (TcpClient)socket;
            while (true)
            {
                byte[] buffer = new byte[1024];
                int k = client.GetStream().Read(buffer, 0, buffer.Length);
                Console.WriteLine("Received from server {0}", Encoding.ASCII.GetString(buffer, 0, k));
            }
        }
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect(IPAddress.Loopback, 5000);
            Thread t = new Thread(ReadData);
            t.Start(client);
            while (true)
            {
                Console.WriteLine("Please input a string to send");
                string input = Console.ReadLine();
                byte[] msg = Encoding.ASCII.GetBytes(input);
                client.GetStream().Write(msg, 0, msg.Length);
            }
        }
    }
}
