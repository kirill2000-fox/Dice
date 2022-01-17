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

            [TestCase(ParametersEnum.DiceWidth,
            60,
            TestName = "�������� ����������� �������� DiceWidth")]
            [TestCase(ParametersEnum.DiceHeight,
            30,
            TestName = "�������� ����������� �������� DiceHeight")]
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

                var actual = parameters.GetValueParameter(parameterEnum);

                Assert.AreEqual(expected, actual,
                "�� ��������� ��������� ��������!");
            }

            [TestCase(ParametersEnum.DiceWidth,
                100,
                TestName = "�������� ����������� �������� DiceWidth")]
            [TestCase(ParametersEnum.DiceHeight,
                50,
                TestName = "�������� ����������� �������� DiceHeight")]
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

                parameters.SetValueParameter(parameterEnum, value);

                var expected = value;

                var actual = parameters.GetValueParameter(parameterEnum);

                Assert.AreEqual(expected, actual,
                "�� ����������� ��������!");
            }

            //[TestCase(ParametersEnum.BoxWidth,
            //500,
            //TestName = "�������� ������������� ����������" +
            //" �������� ��������� BoxWidth." +
            //"������ ���� HasError ���� � true �" +
            //" ErrorStrung �� ������ ���� �����")]
            public void TestSetValueParameter_IncorrectValue(ParametersEnum parameterEnum, int value)
            {
                var parameters = Parameters;

                parameters.SetValueParameter(parameterEnum, value);

                Assert.IsTrue(parameters.HasError,
                "��� ������������ �������� �� ������ ������");
                Assert.IsTrue(!string.IsNullOrEmpty(parameters.ErrorString),
                "������ ������ �����");
            }
        }
    }
}

