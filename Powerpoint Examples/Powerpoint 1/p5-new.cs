using System;

class P5 {
	static void Main()
	{
		P5 Me = new P5();
		int n = Me.doublenum(2);
	}
	virtual int doublenum(int num)
	{
		return num*2;
	}
}