
namespace DiceUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBoxEdgeType = new System.Windows.Forms.ComboBox();
            this.labelEdgeType = new System.Windows.Forms.Label();
            this.comboBoxDredgingForm = new System.Windows.Forms.ComboBox();
            this.labelDredgingForm = new System.Windows.Forms.Label();
            this.DiceEdgeMaxTextBox = new System.Windows.Forms.TextBox();
            this.DiceHeightMaxTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BuildObjectbutton = new System.Windows.Forms.Button();
            this.EdgeWidthTextbox = new System.Windows.Forms.TextBox();
            this.DredgingDiameterTextbox = new System.Windows.Forms.TextBox();
            this.DiceThicknessTextbox = new System.Windows.Forms.TextBox();
            this.DiceWidthTextbox = new System.Windows.Forms.TextBox();
            this.DiceHeightTextbox = new System.Windows.Forms.TextBox();
            this.EdgeWidthlabel = new System.Windows.Forms.Label();
            this.DredgingDiametrlabel = new System.Windows.Forms.Label();
            this.DiceThicknesslabel = new System.Windows.Forms.Label();
            this.DiceWidthlabel = new System.Windows.Forms.Label();
            this.DiceHeightlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxEdgeType);
            this.splitContainer1.Panel1.Controls.Add(this.labelEdgeType);
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxDredgingForm);
            this.splitContainer1.Panel1.Controls.Add(this.labelDredgingForm);
            this.splitContainer1.Panel1.Controls.Add(this.DiceEdgeMaxTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeightMaxTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.BuildObjectbutton);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeWidthTextbox);
            this.splitContainer1.Panel1.Controls.Add(this.DredgingDiameterTextbox);
            this.splitContainer1.Panel1.Controls.Add(this.DiceThicknessTextbox);
            this.splitContainer1.Panel1.Controls.Add(this.DiceWidthTextbox);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeightTextbox);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeWidthlabel);
            this.splitContainer1.Panel1.Controls.Add(this.DredgingDiametrlabel);
            this.splitContainer1.Panel1.Controls.Add(this.DiceThicknesslabel);
            this.splitContainer1.Panel1.Controls.Add(this.DiceWidthlabel);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeightlabel);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1136, 426);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboBoxEdgeType
            // 
            this.comboBoxEdgeType.AutoCompleteCustomSource.AddRange(new string[] {
            "Сфера",
            "Куб"});
            this.comboBoxEdgeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEdgeType.FormattingEnabled = true;
            this.comboBoxEdgeType.Items.AddRange(new object[] {
            "Цилиндрическая",
            "Кубическая"});
            this.comboBoxEdgeType.Location = new System.Drawing.Point(163, 331);
            this.comboBoxEdgeType.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxEdgeType.Name = "comboBoxEdgeType";
            this.comboBoxEdgeType.Size = new System.Drawing.Size(184, 24);
            this.comboBoxEdgeType.TabIndex = 25;
            this.comboBoxEdgeType.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdgeType_SelectedIndexChanged);
            // 
            // labelEdgeType
            // 
            this.labelEdgeType.AutoSize = true;
            this.labelEdgeType.Location = new System.Drawing.Point(12, 334);
            this.labelEdgeType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEdgeType.Name = "labelEdgeType";
            this.labelEdgeType.Size = new System.Drawing.Size(109, 17);
            this.labelEdgeType.TabIndex = 24;
            this.labelEdgeType.Text = "Форма каемки:";
            // 
            // comboBoxDredgingForm
            // 
            this.comboBoxDredgingForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDredgingForm.FormattingEnabled = true;
            this.comboBoxDredgingForm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxDredgingForm.ItemHeight = 16;
            this.comboBoxDredgingForm.Items.AddRange(new object[] {
            "Сферическая",
            "Кубическая"});
            this.comboBoxDredgingForm.Location = new System.Drawing.Point(163, 291);
            this.comboBoxDredgingForm.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxDredgingForm.MaxDropDownItems = 2;
            this.comboBoxDredgingForm.Name = "comboBoxDredgingForm";
            this.comboBoxDredgingForm.Size = new System.Drawing.Size(184, 24);
            this.comboBoxDredgingForm.TabIndex = 23;
            this.comboBoxDredgingForm.SelectedIndexChanged += new System.EventHandler(this.comboBoxDredgingForm_SelectedIndexChanged);
            // 
            // labelDredgingForm
            // 
            this.labelDredgingForm.AutoSize = true;
            this.labelDredgingForm.Location = new System.Drawing.Point(12, 294);
            this.labelDredgingForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDredgingForm.Name = "labelDredgingForm";
            this.labelDredgingForm.Size = new System.Drawing.Size(111, 17);
            this.labelDredgingForm.TabIndex = 22;
            this.labelDredgingForm.Text = "Форма выемок:";
            // 
            // DiceEdgeMaxTextBox
            // 
            this.DiceEdgeMaxTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.DiceEdgeMaxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiceEdgeMaxTextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.DiceEdgeMaxTextBox.Location = new System.Drawing.Point(92, 261);
            this.DiceEdgeMaxTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiceEdgeMaxTextBox.Name = "DiceEdgeMaxTextBox";
            this.DiceEdgeMaxTextBox.ReadOnly = true;
            this.DiceEdgeMaxTextBox.Size = new System.Drawing.Size(17, 15);
            this.DiceEdgeMaxTextBox.TabIndex = 21;
            // 
            // DiceHeightMaxTextBox
            // 
            this.DiceHeightMaxTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.DiceHeightMaxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DiceHeightMaxTextBox.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.DiceHeightMaxTextBox.Location = new System.Drawing.Point(92, 161);
            this.DiceHeightMaxTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiceHeightMaxTextBox.Name = "DiceHeightMaxTextBox";
            this.DiceHeightMaxTextBox.ReadOnly = true;
            this.DiceHeightMaxTextBox.Size = new System.Drawing.Size(17, 15);
            this.DiceHeightMaxTextBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label6.Location = new System.Drawing.Point(12, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "( от 10  до  30 )";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(13, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "( от 8   до  15 )";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(12, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "( от 3   до        )";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "( от 30  до       )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "( от 60  до 120 )";
            // 
            // BuildObjectbutton
            // 
            this.BuildObjectbutton.Location = new System.Drawing.Point(16, 369);
            this.BuildObjectbutton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BuildObjectbutton.Name = "BuildObjectbutton";
            this.BuildObjectbutton.Size = new System.Drawing.Size(335, 46);
            this.BuildObjectbutton.TabIndex = 12;
            this.BuildObjectbutton.Text = "Построить объект";
            this.BuildObjectbutton.UseVisualStyleBackColor = true;
            this.BuildObjectbutton.Click += new System.EventHandler(this.BuildObjectbutton_Click);
            // 
            // EdgeWidthTextbox
            // 
            this.EdgeWidthTextbox.Location = new System.Drawing.Point(163, 241);
            this.EdgeWidthTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EdgeWidthTextbox.Name = "EdgeWidthTextbox";
            this.EdgeWidthTextbox.Size = new System.Drawing.Size(184, 22);
            this.EdgeWidthTextbox.TabIndex = 10;
            this.EdgeWidthTextbox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.EdgeWidthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // DredgingDiameterTextbox
            // 
            this.DredgingDiameterTextbox.Location = new System.Drawing.Point(163, 188);
            this.DredgingDiameterTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DredgingDiameterTextbox.Name = "DredgingDiameterTextbox";
            this.DredgingDiameterTextbox.Size = new System.Drawing.Size(184, 22);
            this.DredgingDiameterTextbox.TabIndex = 9;
            this.DredgingDiameterTextbox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.DredgingDiameterTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // DiceThicknessTextbox
            // 
            this.DiceThicknessTextbox.Location = new System.Drawing.Point(163, 94);
            this.DiceThicknessTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiceThicknessTextbox.Name = "DiceThicknessTextbox";
            this.DiceThicknessTextbox.Size = new System.Drawing.Size(184, 22);
            this.DiceThicknessTextbox.TabIndex = 8;
            this.DiceThicknessTextbox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.DiceThicknessTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // DiceWidthTextbox
            // 
            this.DiceWidthTextbox.Location = new System.Drawing.Point(163, 138);
            this.DiceWidthTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiceWidthTextbox.Name = "DiceWidthTextbox";
            this.DiceWidthTextbox.Size = new System.Drawing.Size(184, 22);
            this.DiceWidthTextbox.TabIndex = 7;
            this.DiceWidthTextbox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.DiceWidthTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // DiceHeightTextbox
            // 
            this.DiceHeightTextbox.Location = new System.Drawing.Point(163, 44);
            this.DiceHeightTextbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiceHeightTextbox.Name = "DiceHeightTextbox";
            this.DiceHeightTextbox.Size = new System.Drawing.Size(184, 22);
            this.DiceHeightTextbox.TabIndex = 0;
            this.DiceHeightTextbox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.DiceHeightTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // EdgeWidthlabel
            // 
            this.EdgeWidthlabel.AutoSize = true;
            this.EdgeWidthlabel.Location = new System.Drawing.Point(12, 241);
            this.EdgeWidthlabel.Name = "EdgeWidthlabel";
            this.EdgeWidthlabel.Size = new System.Drawing.Size(133, 17);
            this.EdgeWidthlabel.TabIndex = 5;
            this.EdgeWidthlabel.Text = "Ширина каемки (E)";
            // 
            // DredgingDiametrlabel
            // 
            this.DredgingDiametrlabel.AutoSize = true;
            this.DredgingDiametrlabel.Location = new System.Drawing.Point(12, 191);
            this.DredgingDiametrlabel.Name = "DredgingDiametrlabel";
            this.DredgingDiametrlabel.Size = new System.Drawing.Size(144, 17);
            this.DredgingDiametrlabel.TabIndex = 4;
            this.DredgingDiametrlabel.Text = "Диаметр выемки (D)";
            // 
            // DiceThicknesslabel
            // 
            this.DiceThicknesslabel.AutoSize = true;
            this.DiceThicknesslabel.Location = new System.Drawing.Point(12, 96);
            this.DiceThicknesslabel.Name = "DiceThicknesslabel";
            this.DiceThicknesslabel.Size = new System.Drawing.Size(132, 17);
            this.DiceThicknesslabel.TabIndex = 3;
            this.DiceThicknesslabel.Text = "Толщина кости (B)";
            // 
            // DiceWidthlabel
            // 
            this.DiceWidthlabel.AutoSize = true;
            this.DiceWidthlabel.Location = new System.Drawing.Point(12, 142);
            this.DiceWidthlabel.Name = "DiceWidthlabel";
            this.DiceWidthlabel.Size = new System.Drawing.Size(123, 17);
            this.DiceWidthlabel.TabIndex = 2;
            this.DiceWidthlabel.Text = "Ширина кости (C)";
            // 
            // DiceHeightlabel
            // 
            this.DiceHeightlabel.AutoSize = true;
            this.DiceHeightlabel.Location = new System.Drawing.Point(12, 47);
            this.DiceHeightlabel.Name = "DiceHeightlabel";
            this.DiceHeightlabel.Size = new System.Drawing.Size(121, 17);
            this.DiceHeightlabel.TabIndex = 1;
            this.DiceHeightlabel.Text = "Высота кости (A)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметры объекта (в мм)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(579, 401);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 428);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button BuildObjectbutton;
        private System.Windows.Forms.TextBox EdgeWidthTextbox;
        private System.Windows.Forms.TextBox DredgingDiameterTextbox;
        private System.Windows.Forms.TextBox DiceThicknessTextbox;
        private System.Windows.Forms.TextBox DiceWidthTextbox;
        private System.Windows.Forms.TextBox DiceHeightTextbox;
        private System.Windows.Forms.Label EdgeWidthlabel;
        private System.Windows.Forms.Label DredgingDiametrlabel;
        private System.Windows.Forms.Label DiceThicknesslabel;
        private System.Windows.Forms.Label DiceWidthlabel;
        private System.Windows.Forms.Label DiceHeightlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox DiceHeightMaxTextBox;
        private System.Windows.Forms.TextBox DiceEdgeMaxTextBox;
		private System.Windows.Forms.ComboBox comboBoxDredgingForm;
		private System.Windows.Forms.Label labelDredgingForm;
		private System.Windows.Forms.Label labelEdgeType;
		private System.Windows.Forms.ComboBox comboBoxEdgeType;
	}
}