using System;

namespace azimut
{
	class Program
	{
		static void Main(string[] args)
		{
			Point a = new Point(45, -32);
			Point b = new Point(50, 5);
			Console.WriteLine("Azimuth: " + Math.Round(Azimut.calculateAzimuth(a, b), 3) + " degrees");
			Console.WriteLine("Distance: " + Math.Round(Azimut.calculateDistance(a, b) / 1000000.0, 3) + " km");
		}
	}
}
