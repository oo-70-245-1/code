using System;

class P2 {
	static void Main()
	{
		cDog ob2 = new cDog();
		cMammal ob1 = (cMammal)ob2;
		//Notice that "Grunt" is still outputted EVEN though it is a dog?
		ob1.speak();
		ob2.speak();
	}
}

class cMammal {
	public void speak()
	{
		Console.WriteLine("Grunt");
	}
}

class cDog : cMammal {
	public new void speak()
	{
		Console.WriteLine("woof woof");
	}
}