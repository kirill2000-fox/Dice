using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiceUI
{
    public partial class MainForm : Form
    {
        private readonly NameParameters _parameter = new NameParameters();
        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Метод для проверки условий
        /// </summary>
        private void CheckValue(TextBox textBox, Parameters parameter)
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
                _parameter.SetValue(parameter, value);
            }
            catch (ArgumentException)
            {
                textBox.BackColor = Color.Crimson;
            }
        }
        private void DiceHeight_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceHeight, "Значение должно быть от 60 мм до 120 мм");
            CheckValue(DiceHeight, Parameters.DiceHeight);
        }

        private void DiceWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceWidth, "Значение должно быть от 30 мм до 0.5*А мм");
            CheckValue(DiceWidth, Parameters.DiceWidth);
        }

        private void DiceThickness_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceThickness, "Значение должно быть от 10 мм до 30 мм");
            CheckValue(DiceThickness, Parameters.DiceThickness);
        }

        private void DredgingDiametr_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DredgingDiametr, "Значение должно быть от 8 мм до 15 мм");
            CheckValue(DredgingDiametr, Parameters.DredgingDiametr);

        }

        private void EdgeWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(EdgeWidth, "Значение должно быть от 3 мм до 1.5*А мм");
            CheckValue(EdgeWidth, Parameters.EdgeWidth);
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
    }
}
