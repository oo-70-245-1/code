using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proxyexample
{
    public interface IClient
    {
        string GetData();
    }

    public class RealClient : IClient
    {
        string Data;
        public RealClient()
        {
            Console.WriteLine("Real Client: initilizalized");
            Data = "realclient test";
        }

        public string GetData()
        {
            return Data;
        }
    }

    public class ProxyClient : IClient
    {
        RealClient client = new RealClient();

        public ProxyClient()
        {
            Console.WriteLine("ProxyClient: Intilizied");
        }

        public string GetData()
        {
            return "X-Header1: test\n" + client.GetData();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProxyClient proxy = new ProxyClient();
            Console.WriteLine("Data from proxy client = {0}", proxy.GetData());
        }
    }
}
