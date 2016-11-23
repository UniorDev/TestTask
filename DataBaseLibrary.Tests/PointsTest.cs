using NUnit.Framework;

namespace DataBaseLibrary.Tests
{
    [TestFixture]
    public class PointsTest
    {
        [Test]
        public void ShouldAcceptPositiveValue()
        {
            IPoint d1Point;
            IPoint d2Point;
            IPoint d3Point;

            Assert.DoesNotThrow(() => d1Point = new D1Point(5));
            Assert.DoesNotThrow(() => d2Point = new D2Point(5, 6));
            Assert.DoesNotThrow(() => d3Point = new D3Point(5, 6, 7));
        }

        [Test]
        public void ShouldThrowExceptionOnNegativeValue()
        {
            IPoint d1Point;
            IPoint d2Point;
            IPoint d3Point;

            Assert.That(() => d1Point = new D1Point(-5), Throws.TypeOf<InvalidPointException>());
            Assert.That(() => d2Point = new D2Point(-6, 5), Throws.TypeOf<InvalidPointException>());
            Assert.That(() => d3Point = new D3Point(-7, -2, 1), Throws.TypeOf<InvalidPointException>());
        }
    }
}
