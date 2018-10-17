using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PongExample1
{
    public static class ByteExtension
    {
        public static string GetString(this byte[] arr, int k)
        {
            return Encoding.ASCII.GetString(arr, 0, k);
        }
    }
    public static class StringExtension
    {
        public static byte[] ToByteArray(this string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }
    }
    class Server
    {
        TcpListener server;
        Socket s;
        int count = 0;
        public Server(IPAddress ip, int port = 5000)
        {
            server = new TcpListener(ip, port);
            server.Start();
            Console.WriteLine("Listening on {0} on port {1}", ip.ToString(), port);
            s = server.AcceptSocket();
        }

        public Server(int port = 5000) : this(IPAddress.Loopback, port) { }
        public Server () : this(IPAddress.Loopback, 5000) { }

        public bool Respond()
        {
            byte[] buffer = new byte[1024];
            byte[] pong = "pong".ToByteArray();
            
            int k = s.Receive(buffer);
            Console.WriteLine("Client sent - {0} - {1}", buffer.GetString(k), count);
            Thread.Sleep(2000);
            s.Send(pong);
            Console.WriteLine("Sent to client - {0} - {1}", pong.GetString(pong.Length), count);
            count++;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server();
            while (s.Respond()) ;
        }
    }
}
