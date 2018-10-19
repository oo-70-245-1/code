using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientExample11
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpListener server = new TcpListener(IPAddress.Loopback, 5000);
                server.Start();

                Console.WriteLine("Server is listening on port 5000...");
                Console.WriteLine("The local End point is: {0}", server.LocalEndpoint);
                Console.WriteLine("Waiting for a connection....");

                while (true)
                {
                    Thread t = new Thread(handleConnection);
                    Socket client = server.AcceptSocket();
					// Send the socket to the thread 
					// let the thread deal with incoming messages
					// loop and accept the next connection and repeat
                    t.Start(client);

                }


                server.Stop();
            } catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void handleConnection(object socket)
        {
			// unbox/cast socket object type to a Socket type
            Socket client = (Socket)socket;

            Console.WriteLine("Connection accepted from {0}", client.RemoteEndPoint);
            byte[] buffer = new byte[1024];

            int k = client.Receive(buffer);
            Console.WriteLine("Received....");
            Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, k));
            client.Send(Encoding.ASCII.GetBytes("The string was received by the server."));
            Console.WriteLine("\nSent Acknowledgement");

            client.Close();
        }
    }
}
