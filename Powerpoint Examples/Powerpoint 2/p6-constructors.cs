using System;

class P6 {
	static void Main()
	{
		Point p = new Point(5,5);
		Console.WriteLine("x = {0}", p.X);
	}
}

class Point {
	int x, y;
	public Point()
	{
		this.x = 0;
		this.y = 0;
	}
	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
	public int X{
	  get{return x;}
	  set{x = value;}
	}

}