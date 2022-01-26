using System;
using Core;
using NUnit.Framework;

namespace CoreTest
{
    [TestFixture]
    public class ParameterTest
    {
        private readonly Parameter _testParameter =
            new Parameter(ParametersEnum.DiceHeight, 30, 60, 30);
        
        [TestCase(TestName = "Позитивный тест геттера Name")]
        public void TestNameGet_GoodScenario()
        {
            // Arrange
            var expected = ParametersEnum.DiceHeight;

            // Act
            var actual = _testParameter.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера Min")]
        public void TestMinGet_GoodScenario()
        {
            // Arrange
            var expected = 30;

            // Act
            var actual = _testParameter.Min;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера Max")]
        public void TestMaxGet_GoodScenario()
        {
            // Arrange
            var expected = 60;

            // Act
            var actual = _testParameter.Max;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Позитивный тест геттера и сеттера Value")]
        public void TestValueGetSet_GoodScenario()
        {
            // Arrange
            var expected = 50;

            // Act
            var parameter = new Parameter(ParametersEnum.DiceHeight, 30, 60, 30);
            parameter.Value = expected;
            var actual = parameter.Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, TestName = "При установке значения меньше минимума выбрасывает исключение")]
        [TestCase(70, TestName = "При установке значения больше максимума выбрасывает исключение")]
        public void TestValueSet_ThrownExceptions(int value)
        {
            // Act
            var parameter = new Parameter(ParametersEnum.DiceHeight, 30, 60, 30);

            // Assert
            Assert.Throws<ArgumentException>(() => parameter.Value = value);
        }

        [TestCase(TestName = "При сравнении одинаковых объектов возращается истина")]
        public void TestEqualsAndClone_GoodScenario_ReturnTrue()
        {
            // Arrange
            var expected = _testParameter;

            // Act
            var actual = _testParameter.Clone() as Parameter;
            var isEqual = actual.Equals(expected);

            // Assert
            Assert.IsTrue(isEqual);
        }

        [TestCase(TestName = "При сравнении различных объектов возращается ложь")]
        public void TestEquals_DifferentValues_ReturnFalse()
        {
            // Arrange
            var expected = _testParameter;

            // Act
            var actual = _testParameter.Clone() as Parameter;
            actual.Value = 50;
            var isEqual = actual.Equals(expected);

            // Assert
            Assert.IsFalse(isEqual);
        }

        [TestCase(TestName = "При сравнении с нулевым объектом возращается ложь")]
        public void TestEquals_NullValue_ReturnFalse()
        {
            // Act
            var actual = _testParameter;
            var isEqual = actual.Equals(null);

            // Assert
            Assert.IsFalse(isEqual);
        }
    }
}

