

using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;

        // Setup method to initialize the ErrorLogger instance before each test
        [SetUp]
        public void SetUp()
        {
            _errorLogger = new ErrorLogger();
        }

        // Test to verify that the LastError property is initially null
        [TearDown]
        public void TearDown()
        {
            _errorLogger = null;
        }

        [Test]
        public void Log_WhenCalled_ShouldSetLastErrorProperty()
        {
            // Arrange
            var error = "Error message";
            // Act
            _errorLogger.Log(error);
            // Assert
            Assert.That(_errorLogger.LastError, Is.EqualTo(error));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ShouldThrowArgumentNullException(string error)
        {
            // Arrange
            // Act & Assert
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_ShouldRaiseErrorLoggedEvent()
        {
            // Arrange
            var id = Guid.Empty;
            _errorLogger.ErrorLogged += (sender, args) => { id = args; };
            // Act
            _errorLogger.Log("Error message");
            // Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty)); // Ensure that the event was raised with a non-empty Guid
        }
    }
}
