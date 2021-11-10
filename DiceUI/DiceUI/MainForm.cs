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

            //double DiceHeightValue = double.Parse(DiceHeight.Text);
            //double DiceWidthValue = double.Parse(DiceWidth.Text);
            //double DiceThicknessValue = double.Parse(DiceThickness.Text);
            //double DedgingDiametrValue = double.Parse(DedgingDiametr.Text);
            //double EdgeWidthValue = double.Parse(EdgeWidth.Text);

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

     //       try
     //       {
     //           if ((DiceHeightValue > 60) || (DiceHeightValue < 120))
     //           {
     //               DiceHeight.BackColor = Color.Crimson;
     //           }


     //           if ((DiceWidthValue > 30) || (DiceWidthValue < 60))
     //           {
     //               DiceWidth.BackColor = Color.Crimson;
     //           }

     //           if ((DiceThicknessValue > 10) || (DiceThicknessValue < 30))
     //           {
     //               DiceThickness.BackColor = Color.Crimson;
     //           }

     //           if ((DedgingDiametrValue > 8) || (DedgingDiametrValue < 15))
     //           {
     //               DedgingDiametr.BackColor = Color.Crimson;
     //           }

     //           if ((EdgeWidthValue > 3) || (EdgeWidthValue < 24))
     //           {
     //               EdgeWidth.BackColor = Color.Crimson;
     //           }
     //       }
     //       catch (Exception ex)
     //       {
     //           MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, 
					//MessageBoxIcon.Error);
     //       }
            
        }
        private void DiceHeight_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceHeight, "Значение должно быть от 60 мм до 120 мм");
            CheckValue(sender,e);
        }

        private void DiceWidth_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(DiceWidth, "Значение должно быть от 30 мм до 0.5*А мм");
            CheckValue(sender, e);
            //double DiceWidthValue = double.Parse(DiceWidth.Text);
            //if ((DiceWidthValue > 30) || (DiceWidthValue < 60))
            //{
            //    DiceWidth.BackColor = Color.Crimson;
            //}
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
        
    }
}
