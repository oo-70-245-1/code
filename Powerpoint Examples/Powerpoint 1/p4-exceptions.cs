using System;
using System.Diagnostics;
using System.Text;

class P4 {
	static public void fail()
	{
		throw(new System.Exception("fail"));
	}
	static void Main(string[] args)
	{
		bool debug = false;
		if (args.Length == 0)
			Console.WriteLine("Possible parameters are -d");
		for(int i = 0; i < args.Length; i++)
		{
			if (args[i] == "-d")
				debug = true;
			Console.WriteLine("args at {0} is {1}", i, args[i]);
		}
		if (debug)
		{
			Console.WriteLine("DEBUGGED!!!");
		}
	}
}