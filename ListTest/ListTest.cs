using LinkedList;
using NUnit.Framework;

namespace ListTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTestValid()
        {
            // Arrange
            var list = new SingleLinkedList<string>();
            list.Add("Bread");
            var expected = "Bred";

            // Act
            var actual = list.Tail.Data;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}