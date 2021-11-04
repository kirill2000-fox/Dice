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
            else tb.BackColor = Color.Red;//иначе делаем красным.
        }
        private void DiceHeight_TextChanged(object sender, EventArgs e)
        {
            CheckValue(sender,e);
        }

        private void DiceWidth_TextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, e);
        }

        private void DiceThickness_TextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, e);
        }

        private void DedgingDiametr_TextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, e);
        }

        private void EdgeWidth_TextChanged(object sender, EventArgs e)
        {
            CheckValue(sender, e);
        }
        
    }
}
