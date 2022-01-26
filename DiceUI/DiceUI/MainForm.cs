using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Core;
using Microsoft.VisualBasic.Devices;

namespace DiceUI
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры кости
        /// </summary>
        private readonly DiceParameters _parameters = new DiceParameters();

        //TODO: XML
        private readonly KompasConnector.KompasConnector _kompasConnector = new KompasConnector.KompasConnector();

        /// <summary>
        /// Конструктор класса MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            TextBoxDictionary = new Dictionary<ParametersEnum, TextBox>()
            {
                {ParametersEnum.DiceHeight, DiceHeightTextbox },
                {ParametersEnum.DiceWidth, DiceWidthTextbox },
                {ParametersEnum.DiceThickness, DiceThicknessTextbox},
                {ParametersEnum.DredgingDiameter, DredgingDiameterTextbox},
                {ParametersEnum.EdgeWidth, EdgeWidthTextbox}
            };

            SetStartValue();
        }

        /// <summary>
        /// Метод для установки начальных значений параметров
        /// </summary>
        private void SetStartValue()
        {
            DiceHeightTextbox.Text = _parameters[ParametersEnum.DiceHeight]
	            .Value.ToString();
            DiceWidthTextbox.Text = _parameters[ParametersEnum.DiceWidth]
	            .Value.ToString();
            DiceThicknessTextbox.Text = _parameters[ParametersEnum.DiceThickness]
	            .Value.ToString();
            DredgingDiameterTextbox.Text = _parameters[ParametersEnum.DredgingDiameter]
	            .Value.ToString();
            EdgeWidthTextbox.Text = _parameters[ParametersEnum.EdgeWidth]
	            .Value.ToString();
            comboBoxDredgingForm.SelectedIndex = 0;
            comboBoxEdgeType.SelectedIndex = 0;
        }
        /// <summary>
        /// Словарь текстобкса и параметра
        /// </summary>
        public Dictionary<ParametersEnum, TextBox> TextBoxDictionary { get; set; } =
            new Dictionary<ParametersEnum, TextBox>();

        /// <summary>
        /// Метод для проверки условий
        /// </summary>
        private void CheckValue(TextBox textBox, ParametersEnum nameParameters)
        {
            textBox.BackColor = Color.White;
            _parameters.Errors.Remove(nameParameters);

            if (textBox.Text == "" || !double.TryParse(textBox.Text, out var value))
            {
                textBox.BackColor = Color.Crimson;
                _parameters.Errors.Add(nameParameters,
                    "Введено не числовое значение");
                return;
            }

            try
            {
                _parameters[nameParameters].Value = value;

                //TODO: должно быть в модели
                if (nameParameters == ParametersEnum.DiceHeight)
                {
                    var widthMax = value / 2.0;
                    DiceHeightMaxTextBox.Text = widthMax.ToString();
                    
                    var width = _parameters[ParametersEnum.DiceWidth];
                    _parameters[ParametersEnum.DiceWidth] = new Parameter
                        (width.Name, width.Min, widthMax, width.Value);

                    var edgeMax = value / 5.0;
                    DiceEdgeMaxTextBox.Text = edgeMax.ToString();
                    
                    var edge = _parameters[ParametersEnum.EdgeWidth];
                    _parameters[ParametersEnum.EdgeWidth] = new Parameter
                        (edge.Name, edge.Min, edgeMax, edge.Value);
                }
            }
            catch (ArgumentException e)
            {
                textBox.BackColor = Color.Crimson;
                _parameters.Errors.Add(nameParameters, e.Message);
            }
        }
        
        /// <summary>
        /// Метод показывающий значение текстового поля
        /// </summary>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var parameter = TextBoxDictionary.FirstOrDefault(keyValue =>
                keyValue.Value == textBox).Key;
            var message = string.Empty;

            switch (parameter)
            {
                //TODO: в модель данных
                case ParametersEnum.DiceHeight:
                {
                    message = "Значение должно быть от 60 мм до 120 мм";
                    break;
                }
                case ParametersEnum.DiceWidth:
                {
                    message = "Значение должно быть от 30 мм до 0.5*А мм";
                    break;
                }
                case ParametersEnum.DiceThickness:
                {
                    message = "Значение должно быть от 10 мм до 30 мм";
                    break;
                }
                case ParametersEnum.DredgingDiameter:
                {
                    message = "Значение должно быть от 8 мм до 15 мм";
                    break;
                }
                case ParametersEnum.EdgeWidth:
                {
                    message = "Значение должно быть от 3 мм до 1.5*А мм";
                    break;
                }
            }

            toolTip1.SetToolTip(textBox, message);
            CheckValue(textBox, parameter);
        }


        /// <summary>
        /// Метод ограничивающий ввод определнных символов
        /// </summary>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(".") || txt.Text.Contains("."))
                {
                    e.Handled = true;
                }

                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки "Построить".
        /// Запуск построение модели
        /// Предупреждение о построении
        /// </summary>
        private void BuildObjectbutton_Click(object sender, EventArgs e)
        {
            if (_parameters.HasError)
            {
                const string message =
                    "Один из параметров выходит за пределы допустимого значения!";
                const string caption = "Ошибка!";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            var builder = new DiceBuilder.DiceBuilder(_kompasConnector, _parameters);
            
            _kompasConnector.OpenKompas();
            builder.BuildDice();
               
        }

        //TODO: RSDN
        /// <summary>
        /// Метод показывающий значение поля комбобокс
        /// </summary>
		private void comboBoxDredgingForm_SelectedIndexChanged(object sender, EventArgs e)
		{
			_parameters.CubeDredging = comboBoxDredgingForm.SelectedIndex == 1;
		}

        //TODO: RSDN
        /// <summary>
        /// Метод показывающий значение поля комбобокс
        /// </summary>
		private void comboBoxEdgeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_parameters.CubeEdge = comboBoxEdgeType.SelectedIndex == 1;
		}
	}
}
