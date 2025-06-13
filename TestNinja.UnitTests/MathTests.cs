using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        // The SetUp method is called before each test method is run, allowing for initialization of common objects.
        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        // The TearDown method is called after each test method is run, allowing for cleanup of resources if necessary.
        [TearDown]
        public void TearDown()
        {
            _math = null;
        }

        [Test]
        //[Ignore("This test is ignored for demonstration purposes.")]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Act
            var result = _math.Add(1, 2);

            // Assert
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(2, 2, 2)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            // Act
            var result = _math.Max(a, b);
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnsOddNumbersUpToLimit()
        {
            // Act
            var result = _math.GetOddNumbers(5);
            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<IEnumerable<int>>());
            Assert.That(result.Count(), Is.EqualTo(3));

            // More specific assertion to check the actual odd numbers returned
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));    
            Assert.That(result, Is.Ordered); // Ensures the numbers are in ascending order
            Assert.That(result, Is.Unique); // Ensures all numbers are unique
        }
    }
}
