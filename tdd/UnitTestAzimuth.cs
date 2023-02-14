using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using azimut;

namespace tdd
{
	[TestClass]
	public class UnitTestAzimuth
	{
		Point firstPoint;
		Point secondPoint;

		Point firstPointPassingThroughCenter;
		Point secondPointPassingThroughCenter;

		Point firstPointMatch;
		Point secondPointMatch;

		Point firstPointAtTheNorthPole;
		Point secontPointAtTheNorthPole;

		[TestInitialize]
		public void Initialize()
		{
			firstPoint = new Point(32, -12);
			secondPoint = new Point(32, -12);

			firstPointPassingThroughCenter = new Point(-30, -180);
			secondPointPassingThroughCenter = new Point(30, 0);

			firstPointMatch = new Point(1, 1);
			secondPointMatch = new Point(1, 1);

			firstPointAtTheNorthPole = new Point(90, 15);
			secontPointAtTheNorthPole = new Point(15, 15);
		}

		[TestMethod]
		public void TestPassingThroughCenter()
		{

		}

		[TestMethod]
		public void TestMatchingPoint()
		{

		}

		[TestMethod]
		public void TestOnePointAtTheNorthPole()
		{

		}

		[TestMethod]
		public void TestValidConstructorParametrs()
		{
		}

		[TestMethod, ExpectedException(typeof(ArgumentNullException))]
		public void TestInvalidConstructorParametrs()
		{
		}

		[TestMethod]
		public void TestPointToRadian()
		{

		}

		[TestMethod]
		public void TestConvertRadiansToDegrees()
		{

		}
	}
}
