using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcpMultiConnections
{
    class Program
    {
        //static List<Socket> sockets = new List<Socket>();
        static Dictionary<string, Socket> sockets = new Dictionary<string, Socket>();
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 5000);
            server.Start();

            Console.WriteLine("Waiting for a connection...");
            while(true)
            {
                Thread t = new Thread(handleConnections);
                Socket client = server.AcceptSocket();
                t.Start(client);
            }

            server.Stop();
        }

        static void handleConnections(object socket)
        {
            Socket client = (Socket)socket;

            Console.WriteLine($"Connection accepted from {client.RemoteEndPoint}");
            byte[] buffer = new byte[1024];
            int k = client.Receive(buffer);
            string username = Encoding.ASCII.GetString(buffer, 0, k);
            sockets[username] = client;
            while (true)
            {
                try
                {
                    k = client.Receive(buffer);
                    foreach (KeyValuePair<string, Socket> otherClient in sockets)
                    {
                        if (otherClient.Value != client)
                        {
                            string clientData = $"[{username}] - " + Encoding.ASCII.GetString(buffer, 0, k);
                            otherClient.Value.Send(Encoding.ASCII.GetBytes(clientData));
                        }
                            //otherClient.Value.Send(buffer, 0, k, SocketFlags.None);
                    }
                    Console.WriteLine("Data received from client: {0}", Encoding.ASCII.GetString(buffer, 0, k));
                } catch (Exception e)
                {
                    sockets.Remove(username);
                    break;
                }
                //client.Send(Encoding.ASCII.GetBytes("Received!"));
            }
            client.Close();
        }
    }
}
