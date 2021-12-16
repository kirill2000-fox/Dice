using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiceUI
{
    public partial class MainForm : Form
    {
        private readonly Parameters _parameter = new Parameters();
        public MainForm()
        {
            InitializeComponent();
            DefaultValue();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {

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
        private void CheckValue(TextBox textBox, NameParameters nameParameters)
        {
            textBox.BackColor = Color.White;

            if (textBox.Text == "")
                return;

            double value;
            if (!double.TryParse(textBox.Text, out value))
            {
                textBox.BackColor = Color.Crimson;
                return;
            }

            try
            {
                _parameter.SetValue(nameParameters, value);
            }
            catch (ArgumentException)
            {
                textBox.BackColor = Color.Crimson;
            }
        }
        private void DiceHeight_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceHeightTextbox, "Значение должно быть от 60 мм до 120 мм");
            CheckValue(DiceHeightTextbox, NameParameters.DiceHeight);
        }

        private void DiceWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceWidthTextbox, "Значение должно быть от 30 мм до 0.5*А мм");
            CheckValue(DiceWidthTextbox, NameParameters.DiceWidth);
        }

        private void DiceThickness_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceThicknessTextbox, "Значение должно быть от 10 мм до 30 мм");
            CheckValue(DiceThicknessTextbox, NameParameters.DiceThickness);
        }

        private void DredgingDiametr_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DredgingDiametrTextbox, "Значение должно быть от 8 мм до 15 мм");
            CheckValue(DredgingDiametrTextbox, NameParameters.DredgingDiametr);

        }

        private void EdgeWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(EdgeWidthTextbox, "Значение должно быть от 3 мм до 1.5*А мм");
            CheckValue(EdgeWidthTextbox, NameParameters.EdgeWidth);
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(".") || txt.Text.Contains("."))
                {
                    e.Handled = true;
                }

                return;
            }

            if (!(Char.IsDigit(e.KeyChar)))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    e.Handled = true;
                }
            }
        }

        private void BuildObjectbutton_Click(object sender, EventArgs e)
        {
            KompasConnector connector = new KompasConnector(_parameter);
        }
    }
}
