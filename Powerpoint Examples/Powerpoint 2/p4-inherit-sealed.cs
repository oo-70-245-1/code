using System;

class P2 {
	static void Main()
	{
		cDog ob2 = new cDog();
		cMammal ob1 = (cMammal)ob2;
		ob1.speak();
		ob2.speak();
	}
}

class cMammal {
	public virtual void speak()
	{
		Console.WriteLine("Grunt");
	}
}

class cDog : cMammal {
	public sealed override void speak()
	{
		Console.WriteLine("woof woof");
	}
}

/*
	Uncomment this section to see the compile complain that you are
	trying to implment a function labeled as "sealed"
*/
/*class cMutatedDog : cDog {
	public override void speak()
	{
		Console.WriteLine("wriggle wriggle");
	}
}*/