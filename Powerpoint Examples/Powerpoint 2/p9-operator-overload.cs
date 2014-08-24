using System;

class P9 {
	static void Main()
	{
		bigint n1 = new bigint(5);
		bigint n2 = new bigint(2); 
		bigint n3;
		n3 = n1 + n2;
		Console.WriteLine("Value of n3 = {0}", n3.val);
	}
}

class bigint {
	int num;
	public static bigint operator +(bigint c1, bigint c2)
	{
		return new bigint(c1.val + c2.val);
	}
	
	public bigint()
	{
		this.num = 0;
	}
	public bigint(int i)
	{
		this.num = i;
	}
	public int val {
		get { return this.num; }
		set { this.num = val; }
	}
}