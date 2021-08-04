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
    }
    
}