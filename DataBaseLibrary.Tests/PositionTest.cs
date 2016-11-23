using NUnit.Framework;
using System;

namespace DataBaseLibrary.Tests
{
    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void ShouldThrowExceptionOnBoolValue()
        {
            IPosition<bool> position;
            Assert.That(() => position = new Position<bool>(true),
                Throws.TypeOf<WrongValueTypeException>());
        }

        [Test]
        public void ShouldThrowExceptionOnDataTimeValue()
        {
            IPosition<DateTime> position;
            Assert.That(() => position = new Position<DateTime>(new DateTime()),
                Throws.TypeOf<WrongValueTypeException>());
        }

        [Test]
        public void ShouldThrowExceptionOnCharValue()
        {
            IPosition<char> position;
            Assert.That(() => position = new Position<char>(new char()),
                Throws.TypeOf<WrongValueTypeException>());
        }

        [Test]
        public void ShouldAcceptNumericalValue()
        {
            IPosition<int> intPosition;
            IPosition<double> doublePosition;
            IPosition<decimal> decimalPosition;

            Assert.DoesNotThrow(() => intPosition = new Position<int>(5));
            Assert.DoesNotThrow(() => doublePosition = new Position<double>(5.0));
            Assert.DoesNotThrow(() => decimalPosition = new Position<decimal>(5m));
        }
    }
}
