using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            _demeritPointsCalculator = null;
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            // Assert
            Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedIsLessThanOrEqualToSpeedLimit_ReturnZero(int speed, int expected)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(50, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(100, 7)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_SpeedIsGreaterThanSpeedLimit_ReturnDemeritPoints(int speed, int expected)
        {
            // Act
            var result = _demeritPointsCalculator.CalculateDemeritPoints(speed);
            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
