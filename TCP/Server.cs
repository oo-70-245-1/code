using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace tcpserverexample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);
                tcpListener.Start();

                Console.WriteLine("The server is running at port 8888...");
                Console.WriteLine("The local End point is :" + tcpListener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                Socket client = tcpListener.AcceptSocket();
                Console.WriteLine("Connection accepted from " + client.RemoteEndPoint);

                byte[] b = new byte[100];
                int k = client.Receive(b);

                Console.WriteLine("Received...");
                for (int i = 0; i < k; i++)
                {
                    Console.Write(Convert.ToChar(b[i]));
                }

                ASCIIEncoding asen = new ASCIIEncoding();
                client.Send(asen.GetBytes("The string was recieved by the server"));
                Console.WriteLine("Sent Acknolwedgement");
                client.Close();
                tcpListener.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.StackTrace);
            }
        }
    }
}
