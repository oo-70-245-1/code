using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton
{
    class Log
    {
        private static Log instance;
        private static object syncRoot = new Object();

        public static Log GetInstance()
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new Log();
            }
            return instance;
        }

        public void WriteLog(string msg)
        {
            if (instance == null)
                throw new Exception("Exception: Log not initilized!");
            Console.WriteLine("Writting out to log....");
        }

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Log.GetInstance().WriteLog("test");
        }
    }
}
