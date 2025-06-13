using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<object> _stack;
        
        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<object>();
        }

        [TearDown]
        public void TearDown()
        {
            _stack = null;
        }

        [Test]
        public void Push_ObjectIsNull_ShouldThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ObjectIsNotNull_ShouldAddObjectToStack()
        {
            var obj = new object();
            _stack.Push(obj);
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_StackIsEmpty_ShouldThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            var obj1 = new object();
            var obj2 = new object();
            _stack.Push(obj1);
            _stack.Push(obj2);
            
            var result = _stack.Pop();
            
            Assert.That(result, Is.EqualTo(obj2));
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_StackHasObjects_ShouldRemoveAndReturnLastObject()
        {
            var obj = new object();
            _stack.Push(obj);
            var result = _stack.Pop();
            
            Assert.That(result, Is.EqualTo(obj));
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_StackIsEmpty_ShouldThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasObjects_ShouldReturnLastObjectWithoutRemovingIt()
        {
            var obj = new object();
            _stack.Push(obj);
            var result = _stack.Peek();
            
            Assert.That(result, Is.EqualTo(obj));
            Assert.That(_stack.Count, Is.EqualTo(1));
        }
    }
}
