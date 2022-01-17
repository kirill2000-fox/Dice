using Core;
using NUnit.Framework;

namespace CoreTest
{
    public class Tests
    {
        /// <summary>
        /// Класс тестирования <see cref="Core.DiceParameters"/>
        /// </summary>
        [TestFixture]
        public class ParametersTest
        {
            /// <summary>
            /// Возвращает новый экземпляр класса <see cref="Core.Parameters"/>
            /// </summary>
            private DiceParameters Parameters => new DiceParameters();

            [TestCase(ParametersEnum.DiceWidth,
            60,
            TestName = "Проверка корректного значения DiceWidth")]
            [TestCase(ParametersEnum.DiceHeight,
            30,
            TestName = "Проверка корректного значения DiceHeight")]
            [TestCase(ParametersEnum.DiceThickness,
            10,
            TestName = "Проверка корректного значения DiceThickness")]
            [TestCase(ParametersEnum.DredgingDiameter,
            8,
            TestName = "Проверка корректного значения DredgingDiameter")]
            [TestCase(ParametersEnum.EdgeWidth,
            3,
            TestName = "Проверка корректного значения EdgeWidth")]
            
            public void TestGetValueParameter_CorrectValue(ParametersEnum parameterEnum, int expected)
            {
                var parameters = Parameters;

                var actual = parameters.GetValueParameter(parameterEnum);

                Assert.AreEqual(expected, actual,
                "Не вернулось ожидаемое значение!");
            }

            [TestCase(ParametersEnum.DiceWidth,
                100,
                TestName = "Проверка корректного значения DiceWidth")]
            [TestCase(ParametersEnum.DiceHeight,
                50,
                TestName = "Проверка корректного значения DiceHeight")]
            [TestCase(ParametersEnum.DiceThickness,
                20,
                TestName = "Проверка корректного значения DiceThickness")]
            [TestCase(ParametersEnum.DredgingDiameter,
                10,
                TestName = "Проверка корректного значения DredgingDiameter")]
            [TestCase(ParametersEnum.EdgeWidth,
                10,
                TestName = "Проверка корректного значения EdgeWidth")]
            public void TestSetValueParameter_CorrectValue(ParametersEnum parameterEnum, int value)
            {
                var parameters = Parameters;

                parameters.SetValueParameter(parameterEnum, value);

                var expected = value;

                var actual = parameters.GetValueParameter(parameterEnum);

                Assert.AreEqual(expected, actual,
                "Не присвоилось значение!");
            }

            //[TestCase(ParametersEnum.BoxWidth,
            //500,
            //TestName = "Проверка некорректного присвоения" +
            //" значения параметра BoxWidth." +
            //"Должен флаг HasError быть в true и" +
            //" ErrorStrung не должна быть пуста")]
            public void TestSetValueParameter_IncorrectValue(ParametersEnum parameterEnum, int value)
            {
                var parameters = Parameters;

                parameters.SetValueParameter(parameterEnum, value);

                Assert.IsTrue(parameters.HasError,
                "При некорректном значении не выдает ошибку");
                Assert.IsTrue(!string.IsNullOrEmpty(parameters.ErrorString),
                "Строка ошибки пуста");
            }
        }
    }
}

