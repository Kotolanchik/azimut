using System;

namespace azimut
{
	public class Point
	{
		private double lat;
		private double lon;

		public Point()
		{
		}

		public Point(double lat, double lon)
		{
			if (lat > 90 || lat < -90)
			{
				throw new ArgumentException("Invalid width " + lat);
			}

			if (lon > 180 || lon < -180)
			{
				throw new ArgumentException("Invalid longitude " + lon);
			}

			this.lat = lat;
			this.lon = lon;
		}

		public double getLat()
		{
			return lat;
		}

		public double getLon()
		{
			return lon;
		}
	}
}
