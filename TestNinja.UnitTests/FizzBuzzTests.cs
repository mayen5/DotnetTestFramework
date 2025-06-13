using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(15, "FizzBuzz")]
        public void GetOutput_InputIsDivisibleBy3And5(int number, string output)
        {

        }

        [Test]
        [TestCase(3, "Fizz")]
        [TestCase(6, "Fizz")]
        public void GetOutput_InputIsDivisibleBy3(int number, string output)
        {
            // Act
            var result = FizzBuzz.GetOutput(number);
            // Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        [TestCase(5, "Buzz")]
        [TestCase(10, "Buzz")]
        public void GetOutput_InputIsDivisibleBy5(int number, string output)
        {
            // Act
            var result = FizzBuzz.GetOutput(number);
            // Assert
            Assert.That(result, Is.EqualTo(output));
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(4, "4")]
        public void GetOutput_InputIsNotDivisibleBy3Or5(int number, string output)
        {
            // Act
            var result = FizzBuzz.GetOutput(number);
            // Assert
            Assert.That(result, Is.EqualTo(output));

        }
    }
}
