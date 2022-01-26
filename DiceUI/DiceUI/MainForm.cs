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
        
        /// <summary>
        /// Коннектор для Компаса
        /// </summary>
        private readonly KompasConnector.KompasConnector _kompasConnector = new KompasConnector.KompasConnector();

        /// <summary>
        /// Конструктор класса MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            TextBoxDictionary = new Dictionary<ParametersType, TextBox>()
            {
                {ParametersType.DiceHeight, DiceHeightTextbox },
                {ParametersType.DiceWidth, DiceWidthTextbox },
                {ParametersType.DiceThickness, DiceThicknessTextbox},
                {ParametersType.DredgingDiameter, DredgingDiameterTextbox},
                {ParametersType.EdgeWidth, EdgeWidthTextbox}
            };

            SetStartValue();
        }

        /// <summary>
        /// Метод для установки начальных значений параметров
        /// </summary>
        private void SetStartValue()
        {
            DiceHeightTextbox.Text = _parameters[ParametersType.DiceHeight]
	            .Value.ToString();
            DiceWidthTextbox.Text = _parameters[ParametersType.DiceWidth]
	            .Value.ToString();
            DiceThicknessTextbox.Text = _parameters[ParametersType.DiceThickness]
	            .Value.ToString();
            DredgingDiameterTextbox.Text = _parameters[ParametersType.DredgingDiameter]
	            .Value.ToString();
            EdgeWidthTextbox.Text = _parameters[ParametersType.EdgeWidth]
	            .Value.ToString();
            comboBoxDredgingForm.SelectedIndex = 0;
            comboBoxEdgeType.SelectedIndex = 0;
        }
        /// <summary>
        /// Словарь текстобкса и параметра
        /// </summary>
        public Dictionary<ParametersType, TextBox> TextBoxDictionary { get; set; } =
            new Dictionary<ParametersType, TextBox>();

        /// <summary>
        /// Метод для проверки условий
        /// </summary>
        private void CheckValue(TextBox textBox, ParametersType nameParameters)
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
                
                _parameters.CheckDependentParameters(nameParameters, value);
                DiceWidthMaxTextBox.Text = _parameters[ParametersType.DiceWidth].Max.ToString();
                DiceEdgeMaxTextBox.Text = _parameters[ParametersType.EdgeWidth].Max.ToString();
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
            var nameParameters = TextBoxDictionary.FirstOrDefault(keyValue =>
                keyValue.Value == textBox).Key;
            var parameter = _parameters[nameParameters];
            var message = parameter.Limits;

            toolTip1.SetToolTip(textBox, message);
            CheckValue(textBox, nameParameters);
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
        
        /// <summary>
        /// Метод показывающий значение поля комбобокс
        /// </summary>
		private void ComboBoxDredgingForm_SelectedIndexChanged(object sender, EventArgs e)
		{
			_parameters.CubeDredging = comboBoxDredgingForm.SelectedIndex == 1;
		}
        
        /// <summary>
        /// Метод показывающий значение поля комбобокс
        /// </summary>
		private void ComboBoxEdgeType_SelectedIndexChanged(object sender, EventArgs e)
		{
			_parameters.CubeEdge = comboBoxEdgeType.SelectedIndex == 1;
		}
	}
}
