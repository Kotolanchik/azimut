using System;

namespace azimut
{
	public class Azimut
	{
		public const long EARTH_RADIUS = 6372795;

		public Azimut()
		{
		}

		public static double toRadians(double degree)
		{
			return degree * Math.PI / 180.0;
		}

		public static double ConvertRadiansToDegrees(double radians)
		{
			return (180 / Math.PI) * radians;
		}

		public static double calculateAzimuth(Point firstPoint, Point secondPoint)
		{
			State state = validateAzimuthPoint(firstPoint, secondPoint);
			switch (state)
			{
				case State.NONE: return (double)State.NONE;
				case State.ANY: return (double)State.ANY;
				case State.ACCEPT_0: return (double)State.ACCEPT_0;
				case State.ACCEPT_180: return (double)State.ACCEPT_180;
				default:
					{
						double azimuth = ConvertRadiansToDegrees(Math.Atan2(Math.Sin(toRadians(secondPoint.getLon() - firstPoint.getLon())) * Math.Cos(toRadians(secondPoint.getLat())),
							Math.Cos(toRadians(firstPoint.getLat())) * Math.Sin(toRadians(secondPoint.getLat())) -
							Math.Sin(toRadians(firstPoint.getLat())) * Math.Cos(toRadians(secondPoint.getLat())) *
							Math.Cos(toRadians(secondPoint.getLon() - firstPoint.getLon()))));
						return azimuth < 0 ? azimuth += 360 : azimuth;
					}
			}
		}

		public static double calculateDistance(Point firstPoint, Point secondPoint)
		{
			return EARTH_RADIUS * Math.Acos(Math.Sin(toRadians(firstPoint.getLat())) * Math.Sin(toRadians(secondPoint.getLat())) +
					   Math.Cos(toRadians(firstPoint.getLat())) * Math.Cos(toRadians(secondPoint.getLat())) *
					   Math.Cos(toRadians(secondPoint.getLon() - firstPoint.getLon())));
		}

		private static State validateAzimuthPoint(Point firstPoint, Point secondPoint)
		{
			if (Math.Abs(secondPoint.getLon() - firstPoint.getLon()) == 180
				&& firstPoint.getLat() + secondPoint.getLat() == 0
				|| Math.Abs(secondPoint.getLat() - firstPoint.getLat()) == 180)
			{
				return State.ANY;
			}

			if (firstPoint.getLon() == secondPoint.getLon() && firstPoint.getLat() == secondPoint.getLat()
				|| Math.Abs(firstPoint.getLat()) == 90 && firstPoint.getLat() == secondPoint.getLat())
			{
				return State.NONE;
			}

			if (Math.Abs(firstPoint.getLat()) == 90 || Math.Abs(secondPoint.getLat()) == 90)
			{
				return State.ACCEPT_180;
			}

			if (firstPoint.getLon() == secondPoint.getLon())
			{
				if (firstPoint.getLat() - secondPoint.getLat() > 0)
				{
					return State.ACCEPT_0;
				}
				if (firstPoint.getLat() - secondPoint.getLat() < 0)
				{
					return State.ACCEPT_180;
				}
			}

			return State.ACCEPT;
		}

		public enum State
		{
			ACCEPT = 1,
			ACCEPT_180 = 180,
			ACCEPT_0 = 0,
			ANY = -2,
			NONE = -1
		}
	}
}