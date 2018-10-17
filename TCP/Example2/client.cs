using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PongExample1Client
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
    class Client
    {
        TcpClient client;
        int count = 0;
        public Client(IPAddress ip, int port = 5000)
        {
            client = new TcpClient();
            client.Connect(ip, port);
        }

        public Client(int port = 5000) : this(IPAddress.Loopback, port) { }
        public Client() : this(IPAddress.Loopback, 5000) { }

        public bool Respond()
        {
            byte[] buffer = new byte[1024];
            byte[] pong = "ping".ToByteArray();

            NetworkStream clientStream = client.GetStream();
            clientStream.Write(pong, 0, pong.Length);
            Console.WriteLine("Sent {0} to the server - {1}", pong.GetString(pong.Length), count);
            Thread.Sleep(2000);
            int k = clientStream.Read(buffer, 0, 1024);
            Console.WriteLine("Received {0} from the server - {1}", buffer.GetString(k), count);
            count++;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();

            while (c.Respond()) ;
        }
    }
}
