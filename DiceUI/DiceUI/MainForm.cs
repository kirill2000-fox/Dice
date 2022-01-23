using System;
using System.Drawing;
using System.Windows.Forms;
using Core;

namespace DiceUI
{
    //TODO: XML
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Параметры кости
        /// </summary>
        private readonly DiceParameters _parameters = new DiceParameters();
        private readonly KompasConnector.KompasConnector _kompasConnector = new KompasConnector.KompasConnector();

        /// <summary>
        /// Конструктор класса MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            DefaultValue();
        }
        
        /// <summary>
        /// Метод для установки дефолтных данных
        /// </summary>
        private void DefaultValue()
        {
            DiceHeightTextbox.Text = "60";
            DiceWidthTextbox.Text = "30";
            DiceThicknessTextbox.Text = "10";
            DredgingDiametrTextbox.Text = "8";
            EdgeWidthTextbox.Text = "3";
        }

        /// <summary>
        /// Метод для проверки условий
        /// </summary>
        private void CheckValue(TextBox textBox, ParametersEnum nameParameters)
        {
            textBox.BackColor = Color.White;
            _parameters.Errors.Remove(nameParameters);

            if (textBox.Text == "")
            {
                //TODO: дубль
                textBox.BackColor = Color.Crimson;
                _parameters.Errors.Add(nameParameters,
                    "Введено не числовое значение");
                return;
            }

            if (!double.TryParse(textBox.Text, out var value))
            {
                textBox.BackColor = Color.Crimson;
                _parameters.Errors.Add(nameParameters,
                    "Введено не числовое значение");
                return;
            }

            try
            {
                _parameters[nameParameters].Value = value;

                if (nameParameters == ParametersEnum.DiceHeight)
                {
                    var widthMax = value / 2.0;
                    DiceHeightMaxTextBox.Text = widthMax.ToString();

                    //TODO: RSDN (ИСПРАВЛЕНО)
                    var width = _parameters[ParametersEnum.DiceWidth];
                    _parameters[ParametersEnum.DiceWidth] = new Parameter
                        (width.Name, width.Min, widthMax, width.Value);

                    var edgeMax = value / 5.0;
                    DiceEdgeMaxTextBox.Text = edgeMax.ToString();

                    //TODO: RSDN (ИСПРАВЛЕНО)
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

        //TODO: дубль
        /// <summary>
        /// Метод вызывающий показывающий значение диапазона высоты
        /// </summary>
        private void DiceHeight_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceHeightTextbox, "Значение должно быть " +
                                                   "от 60 мм до 120 мм");
            CheckValue(DiceHeightTextbox, ParametersEnum.DiceHeight);
        }

        /// <summary>
        /// Метод вызывающий показывающий значение диапазона ширины
        /// </summary>
        private void DiceWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceWidthTextbox, "Значение должно быть " +
                                                  "от 30 мм до 0.5*А мм");
            CheckValue(DiceWidthTextbox, ParametersEnum.DiceWidth);
        }

        /// <summary>
        /// Метод вызывающий показывающий значение диапазона толщины
        /// </summary>
        private void DiceThickness_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceThicknessTextbox, "Значение должно быть " +
                                                      "от 10 мм до 30 мм");
            CheckValue(DiceThicknessTextbox, ParametersEnum.DiceThickness);
        }

        /// <summary>
        /// Метод вызывающий показывающий значение диапазона диаметра выемки
        /// </summary>
        private void DredgingDiametr_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DredgingDiametrTextbox, "Значение должно быть " +
                                                        "от 8 мм до 15 мм");
            CheckValue(DredgingDiametrTextbox, ParametersEnum.DredgingDiameter);

        }

        /// <summary>
        /// Метод вызывающий показывающий значение диапазона размера каемкии
        /// </summary>
        private void EdgeWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(EdgeWidthTextbox, "Значение должно быть " +
                                                  "от 3 мм до 1.5*А мм");
            CheckValue(EdgeWidthTextbox, ParametersEnum.EdgeWidth);
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
                //TODO: Единообразно.(ИСПРАВЛЕНО)
                const string caption = "Ошибка!";
                MessageBox.Show(message, caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _kompasConnector.OpenKompas();
            var builder = new DiceBuilder.DiceBuilder(_kompasConnector, _parameters);
            builder.BuildDice();
        }
    }
}
