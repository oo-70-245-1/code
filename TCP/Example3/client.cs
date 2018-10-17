using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerExample11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Loopback, 5000);

                Console.WriteLine("Connected to server {0} on port 5000", IPAddress.Loopback);
                Console.WriteLine("Sending data...");
                Console.WriteLine("Enter the string to send:");
                string input = Console.ReadLine();

                byte[] msg = Encoding.ASCII.GetBytes(input);
                byte[] buffer = new byte[1024];
                NetworkStream stream = client.GetStream();
                stream.Write(msg, 0, msg.Length);

                int k = stream.Read(buffer, 0, 1024);
                Console.WriteLine("Received from server: {0}", Encoding.ASCII.GetString(buffer, 0, k));
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
