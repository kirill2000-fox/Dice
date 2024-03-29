﻿using Core;
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
            var expected = new Parameter(ParametersType.DiceWidth, 30, 60, 30);

            // Act
            var parametersList = new DiceParameters();
            var actual = parametersList[ParametersType.DiceWidth];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При установке значения с помощью индексатора, параметр записывается в коллекцию")]
        public void TestIndexerSet_GoodScenario()
        {
            // Arrange
            var expected = new Parameter(ParametersType.DiceWidth, 30, 60, 30);

            // Act
            var parametersList = new DiceParameters()
            {
                [ParametersType.DiceWidth] = expected
            };
            var actual = parametersList[ParametersType.DiceWidth];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "При установке значения с помощью индексатора, параметр записывается в коллекцию")]
        public void TestHasErrorsGet_OneError()
        {
            // Act
            var diceParameters = new DiceParameters();
            diceParameters.Errors[ParametersType.DiceThickness] = "Error";
            var actual = diceParameters.HasError;

            // Assert
            Assert.IsTrue(actual);
        }

        [TestCase(TestName =
            "Получение корректного значения параметра CubeDredging")]
        public void TestGetCubeDredging_CorrectValue()
        {
            // Arrange
            var diceParameters = new DiceParameters();
            var expected = false;

            // Act
            var actual = diceParameters.CubeDredging;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "Получение корректного значения параметра CubeEdge")]
        public void TestGetCubeEdge_CorrectValue()
        {
            // Arrange
            var diceParameters = new DiceParameters();
            var expected = false;

            // Act
            var actual = diceParameters.CubeEdge;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(TestName =
            "Установление корректного значения параметра CubeEdge")]
        public void TestSetCubeEdge_CorrectValue()
        {
            // Act
            var diceParameters = new DiceParameters();
            var value = true;

            // Assert
            Assert.DoesNotThrow(() => diceParameters.CubeEdge = value);
        }

        [TestCase(30, ParametersType.DiceWidth, TestName =
            "Получение корректного значения параметра DiceWidth")]
        [TestCase(60, ParametersType.DiceHeight, TestName =
            "Получение корректного значения параметра DiceHeight")]
        [TestCase(10, ParametersType.DiceThickness, TestName =
            "Получение корректного значения параметра DiceThickness")]
        [TestCase(8, ParametersType.DredgingDiameter, TestName =
            "Получение корректного значения параметра DredgingDiameter")]
        [TestCase(3, ParametersType.EdgeWidth, TestName =
            "Получение корректного значения параметра DiceWidth")]
        public void TestGetParameter_CorrectValue(double expected,
            ParametersType parameter)
        {
            // Act
            var diceParameters = new DiceParameters();
            var actual = diceParameters[parameter].Value;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}