using System;

class P3 {
	static void Main()
	{
		int x = 0;
		int whilei = 0;
		Console.WriteLine("Starting looping");
		Console.WriteLine();
		if (x > 5)
			Console.WriteLine("x is greator than 5");
		else
			Console.WriteLine("x is less than  5");
		Console.WriteLine();
		for(int i = 0; i < 4; i++)
		{
			Console.WriteLine("For loop...");
		}
		Console.WriteLine();
		while(whilei < 5)
		{
			Console.WriteLine("While loop...");
			whilei++;
		}
		whilei = 0;
		Console.WriteLine();
		do {
			Console.WriteLine("do-while loop...");
			whilei++;
		} while (whilei < 5);
	}
}