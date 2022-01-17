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
            
            [TestCase(ParametersEnum.DiceHeight,
            60,
            TestName = "Проверка корректного значения DiceHeight")]
            [TestCase(ParametersEnum.DiceWidth,
            30,
            TestName = "Проверка корректного значения DiceWidth")]
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

                var actual = parameters[parameterEnum].Value;

                Assert.AreEqual(expected, actual,
                "Не вернулось ожидаемое значение!");
            }

            [TestCase(ParametersEnum.DiceHeight,
                100,
                TestName = "Проверка правильного значения DiceHeight")]
            [TestCase(ParametersEnum.DiceWidth,
                50,
                TestName = "Проверка правильного значения DiceWidth")]
            [TestCase(ParametersEnum.DiceThickness,
                20,
                TestName = "Проверка правильного значения DiceThickness")]
            [TestCase(ParametersEnum.DredgingDiameter,
                10,
                TestName = "Проверка правильного значения DredgingDiameter")]
            [TestCase(ParametersEnum.EdgeWidth,
                10,
                TestName = "Проверка правильного значения EdgeWidth")]
            public void TestSetValueParameter_CorrectValue(ParametersEnum parameterEnum, int value)
            {
                var parameters = Parameters;

                parameters[parameterEnum].Value = value;

                var expected = value;

                var actual = parameters[parameterEnum].Value;

                Assert.AreEqual(expected, actual,
                "Не присвоилось значение!");
            }
        }
    }
}

