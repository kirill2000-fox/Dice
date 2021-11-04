
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BuildObjectbutton = new System.Windows.Forms.Button();
            this.EdgeWidth = new System.Windows.Forms.TextBox();
            this.DedgingDiametr = new System.Windows.Forms.TextBox();
            this.DiceThickness = new System.Windows.Forms.TextBox();
            this.DiceWidth = new System.Windows.Forms.TextBox();
            this.DiceHeight = new System.Windows.Forms.TextBox();
            this.EdgeWidthlabel = new System.Windows.Forms.Label();
            this.DedgingDiametrlabel = new System.Windows.Forms.Label();
            this.DiceThicknesslabel = new System.Windows.Forms.Label();
            this.DiceWidthlabel = new System.Windows.Forms.Label();
            this.DiceHeightlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.BuildObjectbutton);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeWidth);
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDiametr);
            this.splitContainer1.Panel1.Controls.Add(this.DiceThickness);
            this.splitContainer1.Panel1.Controls.Add(this.DiceWidth);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeight);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeWidthlabel);
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDiametrlabel);
            this.splitContainer1.Panel1.Controls.Add(this.DiceThicknesslabel);
            this.splitContainer1.Panel1.Controls.Add(this.DiceWidthlabel);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeightlabel);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(943, 541);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.TabIndex = 0;
            // 
            // BuildObjectbutton
            // 
            this.BuildObjectbutton.Location = new System.Drawing.Point(15, 500);
            this.BuildObjectbutton.Name = "BuildObjectbutton";
            this.BuildObjectbutton.Size = new System.Drawing.Size(163, 29);
            this.BuildObjectbutton.TabIndex = 12;
            this.BuildObjectbutton.Text = "Построить объект";
            this.BuildObjectbutton.UseVisualStyleBackColor = true;
            // 
            // EdgeWidth
            // 
            this.EdgeWidth.Location = new System.Drawing.Point(162, 174);
            this.EdgeWidth.Name = "EdgeWidth";
            this.EdgeWidth.Size = new System.Drawing.Size(141, 22);
            this.EdgeWidth.TabIndex = 10;
            this.EdgeWidth.TextChanged += new System.EventHandler(this.EdgeWidth_TextChanged);
            // 
            // DedgingDiametr
            // 
            this.DedgingDiametr.Location = new System.Drawing.Point(162, 142);
            this.DedgingDiametr.Name = "DedgingDiametr";
            this.DedgingDiametr.Size = new System.Drawing.Size(141, 22);
            this.DedgingDiametr.TabIndex = 9;
            this.DedgingDiametr.TextChanged += new System.EventHandler(this.DedgingDiametr_TextChanged);
            // 
            // DiceThickness
            // 
            this.DiceThickness.Location = new System.Drawing.Point(162, 113);
            this.DiceThickness.Name = "DiceThickness";
            this.DiceThickness.Size = new System.Drawing.Size(141, 22);
            this.DiceThickness.TabIndex = 8;
            this.DiceThickness.TextChanged += new System.EventHandler(this.DiceThickness_TextChanged);
            // 
            // DiceWidth
            // 
            this.DiceWidth.Location = new System.Drawing.Point(162, 83);
            this.DiceWidth.Name = "DiceWidth";
            this.DiceWidth.Size = new System.Drawing.Size(141, 22);
            this.DiceWidth.TabIndex = 7;
            this.DiceWidth.TextChanged += new System.EventHandler(this.DiceWidth_TextChanged);
            // 
            // DiceHeight
            // 
            this.DiceHeight.Location = new System.Drawing.Point(162, 57);
            this.DiceHeight.Name = "DiceHeight";
            this.DiceHeight.Size = new System.Drawing.Size(141, 22);
            this.DiceHeight.TabIndex = 0;
            this.DiceHeight.TextChanged += new System.EventHandler(this.DiceHeight_TextChanged);
            // 
            // EdgeWidthlabel
            // 
            this.EdgeWidthlabel.AutoSize = true;
            this.EdgeWidthlabel.Location = new System.Drawing.Point(12, 174);
            this.EdgeWidthlabel.Name = "EdgeWidthlabel";
            this.EdgeWidthlabel.Size = new System.Drawing.Size(133, 17);
            this.EdgeWidthlabel.TabIndex = 5;
            this.EdgeWidthlabel.Text = "Ширина каемки (E)";
            // 
            // DedgingDiametrlabel
            // 
            this.DedgingDiametrlabel.AutoSize = true;
            this.DedgingDiametrlabel.Location = new System.Drawing.Point(12, 145);
            this.DedgingDiametrlabel.Name = "DedgingDiametrlabel";
            this.DedgingDiametrlabel.Size = new System.Drawing.Size(144, 17);
            this.DedgingDiametrlabel.TabIndex = 4;
            this.DedgingDiametrlabel.Text = "Диаметр выемки (D)";
            // 
            // DiceThicknesslabel
            // 
            this.DiceThicknesslabel.AutoSize = true;
            this.DiceThicknesslabel.Location = new System.Drawing.Point(12, 116);
            this.DiceThicknesslabel.Name = "DiceThicknesslabel";
            this.DiceThicknesslabel.Size = new System.Drawing.Size(132, 17);
            this.DiceThicknesslabel.TabIndex = 3;
            this.DiceThicknesslabel.Text = "Толщина кости (B)";
            // 
            // DiceWidthlabel
            // 
            this.DiceWidthlabel.AutoSize = true;
            this.DiceWidthlabel.Location = new System.Drawing.Point(12, 86);
            this.DiceWidthlabel.Name = "DiceWidthlabel";
            this.DiceWidthlabel.Size = new System.Drawing.Size(123, 17);
            this.DiceWidthlabel.TabIndex = 2;
            this.DiceWidthlabel.Text = "Ширина кости (C)";
            // 
            // DiceHeightlabel
            // 
            this.DiceHeightlabel.AutoSize = true;
            this.DiceHeightlabel.Location = new System.Drawing.Point(12, 60);
            this.DiceHeightlabel.Name = "DiceHeightlabel";
            this.DiceHeightlabel.Size = new System.Drawing.Size(121, 17);
            this.DiceHeightlabel.TabIndex = 1;
            this.DiceHeightlabel.Text = "Высота кости (A)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметры объекта (в мм)";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(549, 501);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 541);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.TextBox EdgeWidth;
        private System.Windows.Forms.TextBox DedgingDiametr;
        private System.Windows.Forms.TextBox DiceThickness;
        private System.Windows.Forms.TextBox DiceWidth;
        private System.Windows.Forms.TextBox DiceHeight;
        private System.Windows.Forms.Label EdgeWidthlabel;
        private System.Windows.Forms.Label DedgingDiametrlabel;
        private System.Windows.Forms.Label DiceThicknesslabel;
        private System.Windows.Forms.Label DiceWidthlabel;
        private System.Windows.Forms.Label DiceHeightlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}