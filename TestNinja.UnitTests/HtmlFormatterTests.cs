using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatter;

        [SetUp]
        public void SetUp()
        {
            _htmlFormatter = new HtmlFormatter();
        }

        [TearDown]
        public void TearDown()
        {
            _htmlFormatter = null;
        }

        [Test]
        public void FormatAsBold_ReturnsStrongTag()
        {
            // Act
            var result = _htmlFormatter.FormatAsBold("Hello");

            // Assert
            Assert.That(result, Is.EqualTo("<strong>Hello</strong>").IgnoreCase);

            // More general assertion
            Assert.That(result, Does.StartWith("<strong>")
                .And.EndsWith("</strong>")
                .And.Contains("Hello"));
        }
    }
}
