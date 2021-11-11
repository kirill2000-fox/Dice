using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceUI
{
    public partial class MainForm : Form
    {
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
        private void CheckValue(object sender, EventArgs e)
        {

            /// <summary>
            /// переменная для преобразования текста
            /// </summary>
            double preob;

            /// <summary>
            /// textBox, который вызвал событие изменения текста
            /// </summary>
            TextBox tb = sender as TextBox;

            // Если возможно преобразовать или поле пустое
            if (double.TryParse(tb.Text, out preob) || string.IsNullOrEmpty(tb.Text))
                tb.BackColor = SystemColors.Window;//оставляем поле чистым
            else tb.BackColor = Color.Crimson;//иначе делаем красным.
            
        }
        private void DiceHeight_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceHeight, "Значение должно быть от 60 мм до 120 мм");

        }

        private void DiceWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceWidth, "Значение должно быть от 30 мм до 0.5*А мм");
            CheckValue(sender, e);
        }

        private void DiceThickness_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceThickness, "Значение должно быть от 10 мм до 30 мм");
            CheckValue(sender, e);
        }

        private void DredgingDiametr_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DredgingDiametr, "Значение должно быть от 8 мм до 15 мм");
            CheckValue(sender, e);
            
        }

        private void EdgeWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(EdgeWidth, "Значение должно быть от 3 мм до 1.5*А мм");
            CheckValue(sender, e);
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
