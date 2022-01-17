using Core;
using NUnit.Framework;

namespace CoreTest
{
    public class Tests
    {
        /// <summary>
        /// ����� ������������ <see cref="Core.DiceParameters"/>
        /// </summary>
        [TestFixture]
        public class ParametersTest
        {
            /// <summary>
            /// ���������� ����� ��������� ������ <see cref="Core.Parameters"/>
            /// </summary>
            private DiceParameters Parameters => new DiceParameters();
            
            [TestCase(ParametersEnum.DiceHeight,
            60,
            TestName = "�������� ����������� �������� DiceHeight")]
            [TestCase(ParametersEnum.DiceWidth,
            30,
            TestName = "�������� ����������� �������� DiceWidth")]
            [TestCase(ParametersEnum.DiceThickness,
            10,
            TestName = "�������� ����������� �������� DiceThickness")]
            [TestCase(ParametersEnum.DredgingDiameter,
            8,
            TestName = "�������� ����������� �������� DredgingDiameter")]
            [TestCase(ParametersEnum.EdgeWidth,
            3,
            TestName = "�������� ����������� �������� EdgeWidth")]
            
            public void TestGetValueParameter_CorrectValue(ParametersEnum parameterEnum, int expected)
            {
                var parameters = Parameters;

                var actual = parameters[parameterEnum].Value;

                Assert.AreEqual(expected, actual,
                "�� ��������� ��������� ��������!");
            }

            [TestCase(ParametersEnum.DiceHeight,
                100,
                TestName = "�������� ����������� �������� DiceHeight")]
            [TestCase(ParametersEnum.DiceWidth,
                50,
                TestName = "�������� ����������� �������� DiceWidth")]
            [TestCase(ParametersEnum.DiceThickness,
                20,
                TestName = "�������� ����������� �������� DiceThickness")]
            [TestCase(ParametersEnum.DredgingDiameter,
                10,
                TestName = "�������� ����������� �������� DredgingDiameter")]
            [TestCase(ParametersEnum.EdgeWidth,
                10,
                TestName = "�������� ����������� �������� EdgeWidth")]
            public void TestSetValueParameter_CorrectValue(ParametersEnum parameterEnum, int value)
            {
                var parameters = Parameters;

                parameters[parameterEnum].Value = value;

                var expected = value;

                var actual = parameters[parameterEnum].Value;

                Assert.AreEqual(expected, actual,
                "�� ����������� ��������!");
            }
        }
    }
}

