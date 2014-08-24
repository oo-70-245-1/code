using System;

class P5 {
	static void Main()
	{
		Point p1 = new Point();
		p1.X = 10;
	}
}

class Point {
	Int32 x;
	Int32 y;
	public Int32 X {
		get { return x; }
		set { x = value; }
	}
}