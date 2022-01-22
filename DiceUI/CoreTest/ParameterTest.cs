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

        //TODO: кодировка
        [TestCase(TestName = "Ïîçèòèâíûé òåñò ãåòòåðà Name")]
        public void TestNameGet_GoodScenario()
        {
            // Arrange
            var expected = ParametersEnum.DiceHeight;

            // Act
            var actual = _testParameter.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Ïîçèòèâíûé òåñò ãåòòåðà Min")]
        public void TestMinGet_GoodScenario()
        {
            // Arrange
            var expected = 30;

            // Act
            var actual = _testParameter.Min;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Ïîçèòèâíûé òåñò ãåòòåðà Max")]
        public void TestMaxGet_GoodScenario()
        {
            // Arrange
            var expected = 60;

            // Act
            var actual = _testParameter.Max;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName = "Ïîçèòèâíûé òåñò ãåòòåðà è ñåòòåðà Value")]
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

        [TestCase(10, TestName = "Ïðè óñòàíîâêå çíà÷åíèÿ ìåíüøå ìèíèìóìà âûáðàñûâàåò èñêëþ÷åíèå")]
        [TestCase(70, TestName = "Ïðè óñòàíîâêå çíà÷åíèÿ áîëüøå ìàêñèìóìà âûáðàñûâàåò èñêëþ÷åíèå")]
        public void TestValueSet_ThrownExceptions(int value)
        {
            // Act
            var parameter = new Parameter(ParametersEnum.DiceHeight, 30, 60, 30);

            // Assert
            Assert.Throws<ArgumentException>(() => parameter.Value = value);
        }

        [TestCase(TestName = "Ïðè ñðàâíåíèè îäèíàêîâûõ îáúåêòîâ âîçðàùàåòñÿ èñòèíà")]
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

        [TestCase(TestName = "Ïðè ñðàâíåíèè ðàçëè÷íûõ îáúåêòîâ âîçðàùàåòñÿ ëîæü")]
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

        [TestCase(TestName = "Ïðè ñðàâíåíèè ñ íóëåâûì îáúåêòîì âîçðàùàåòñÿ ëîæü")]
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

