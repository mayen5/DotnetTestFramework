using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;

        [SetUp]
        public void SetUp()
        {
            _controller = new CustomerController();
        }

        [TearDown]
        public void TearDown()
        {
            _controller = null;
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            // Act
            var result = _controller.GetCustomer(0);

            // Assert
            Assert.That(result, Is.TypeOf<NotFound>());

            // Alternative assertion using Is.InstanceOf
            Assert.That(result, Is.InstanceOf<NotFound>());
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            // Act
            var result = _controller.GetCustomer(1);
            
            // Assert
            Assert.That(result, Is.TypeOf<Ok>());

            // Alternative assertion using Is.InstanceOf
            Assert.That(result, Is.InstanceOf<Ok>());
        }
    }
}
