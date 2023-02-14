using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using azimut;

namespace tdd
{
    [TestClass]
    public class UnitTestPointt
    {
        [TestMethod]
        public void TestMethodConstructor()
        {
            Point point = new Point();
        }

        [TestMethod]
        public void TestMethodConstructorWithParametrs()
        {
            Point point = new Point(10, -10);
        }

        [TestMethod]
        public void TestGetterLongitude()
        {
            Point point = new Point(10, -10);

            Assert.AreEqual(-10, point.getLon());
        }

        [TestMethod]
        public void TestGetterLatitude()
        {
            Point point = new Point(10, -10);

            Assert.AreEqual(10, point.getLat());
        }


        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void TestConstructorInvalidParametrs()
        {
            Point point = new Point(99, 191);
        }
    }
}
