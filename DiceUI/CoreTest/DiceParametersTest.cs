using Core;
using NUnit.Framework;

namespace CoreTest
{
    public class DiceParametersTest
    {
        private DiceParameters _testParameters => new DiceParameters();

        [TestCase(TestName = "Позитивный тест геттера ParametersList")]
        public void TestParametersListGet_GoodScenario()
        {
            // Arrange
            var expected = _testParameters.ParametersList;

            // Act
            var diceParameters = new DiceParameters();
            var actual = diceParameters.ParametersList;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При получении значения с помощью индексатора возвращается соответствующий параметр")]
        public void TestIndexerGet_ReturnValue()
        {
            // Arrange
            var expected = new Parameter(ParametersEnum.DiceWidth, 30, 60, 30);

            // Act
            var parametersList = new DiceParameters();
            var actual = parametersList[ParametersEnum.DiceWidth];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При установке значения с помощью индексатора, параметр записывается в коллекцию")]
        public void TestIndexerSet_GoodScenario()
        {
            // Arrange
            var expected = new Parameter(ParametersEnum.DiceWidth, 30, 60, 30);

            // Act
            var parametersList = new DiceParameters()
            {
                [ParametersEnum.DiceWidth] = expected
            };
            var actual = parametersList[ParametersEnum.DiceWidth];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При установке значения с помощью индексатора, параметр записывается в коллекцию")]
        public void TestHasErrorsGet_OneError()
        {
            // Act
            var diceParameters = new DiceParameters();
            diceParameters.Errors[ParametersEnum.DiceThickness] = "Error";
            var actual = diceParameters.HasError;

            // Assert
            Assert.IsTrue(actual);
        }
    }
}