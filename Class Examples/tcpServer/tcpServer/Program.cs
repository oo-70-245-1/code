using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace tcpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener server = new TcpListener(IPAddress.Loopback, 5000);
                server.Start();

                Socket client = server.AcceptSocket();
                Console.WriteLine($"Connection accepted from {client.RemoteEndPoint}");

                byte[] buffer = new byte[1024];
                int k = client.Receive(buffer);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, k));
                client.Send(Encoding.ASCII.GetBytes("Message received!"));
                //client.NoDelay = true;
                client.Close();
                server.Stop();
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
