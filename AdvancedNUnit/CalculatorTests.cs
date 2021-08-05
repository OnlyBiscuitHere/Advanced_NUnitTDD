using NUnit.Framework;
using System.Collections.Generic;

namespace AdvancedNUnit
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Add_Always_ReturnsExpectedResult()
        {
            // Arrange
            var expectedResult = 6;
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            // Act
            var result = subject.Add();
            // Assert
            Assert.That(result, Is.EqualTo(expectedResult), "optional failure message");
        }
        [Test]
        public void SomeConstraints()
        {
            var subject = new Calculator {Num1 = 6 };
            Assert.That(subject.DivisibleBy3());
            subject.Num1 = 7;
            Assert.That(subject.DivisibleBy3(), Is.False);
            Assert.That(subject.ToString(), Does.Contain("Calculator"));
        }
        [Test]
        public void StringConstraints()
        {
            var subject = new Calculator { Num1 = 2, Num2 = 4 };
            var strResult = subject.ToString();
            Assert.That(strResult, Does.Contain("Calculator"));
            Assert.That(strResult, Does.Not.Contain("Alex"));
            Assert.That(strResult, Is.EqualTo("advancedNUnit.Calculator").IgnoreCase);
            Assert.That(strResult, Is.Not.Empty);
            Assert.That(strResult, Is.Not.Null);
            Assert.That(strResult, Does.StartWith("A"));
        }
        [Test]
        public void TestArrayOfStrings()
        {
            var fruit = new List<string>
            {
                "Apple", "Pear", "Banana", "Peach"
            };
            Assert.That(fruit, Does.Contain("Pear"));
            Assert.That(fruit, Has.Count.EqualTo(4));
            Assert.That(fruit, Has.Exactly(2).StartsWith("Pea"));
        }
        [Test]
        public void TestRange()
        {
            Assert.That(8, Is.InRange(1, 10));
            List<int> nums = new List<int> { 4, 2, 7, 5, 9 };
            Assert.That(nums, Is.All.InRange(1, 10));
            Assert.That(nums, Has.Exactly(3).InRange(1, 5));
        }
        [TestCaseSource("AddCases")]
        public void Add_Always_ReturnsResult_WithDataProvider(int x, int y, int ExceptionResult)
        {
            var subject = new Calculator { Num1 = x, Num2 = y };
            Assert.That(subject.Add(), Is.EqualTo(ExceptionResult));
        }
        private static object[] AddCases =
        {
            new int[] {2, 4, 6},
            new int[] {-2, 3, 1},
            new int[] {3, 3, 6},
            new int[] {33, 3, 36}
        };
    }
    
}