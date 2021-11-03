
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DiceHeight = new System.Windows.Forms.TextBox();
            this.DiceWidth = new System.Windows.Forms.TextBox();
            this.DiceThickness = new System.Windows.Forms.TextBox();
            this.DedgingDiametr = new System.Windows.Forms.TextBox();
            this.EdgeWidth = new System.Windows.Forms.TextBox();
            this.EdgeDepth = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DedgingDepth = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDepth);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeDepth);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeWidth);
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDiametr);
            this.splitContainer1.Panel1.Controls.Add(this.DiceThickness);
            this.splitContainer1.Panel1.Controls.Add(this.DiceWidth);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeight);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(867, 502);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметры объекта";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Высота кости";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ширина кости";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Толщина кости";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Диаметр выемки";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ширина каемки";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Глубина каемки";
            // 
            // DiceHeight
            // 
            this.DiceHeight.Location = new System.Drawing.Point(139, 57);
            this.DiceHeight.Name = "DiceHeight";
            this.DiceHeight.Size = new System.Drawing.Size(133, 22);
            this.DiceHeight.TabIndex = 0;
            this.DiceHeight.TextChanged += new System.EventHandler(this.DiceHeight_TextChanged);
            // 
            // DiceWidth
            // 
            this.DiceWidth.Location = new System.Drawing.Point(139, 83);
            this.DiceWidth.Name = "DiceWidth";
            this.DiceWidth.Size = new System.Drawing.Size(133, 22);
            this.DiceWidth.TabIndex = 7;
            this.DiceWidth.TextChanged += new System.EventHandler(this.DiceWidth_TextChanged);
            // 
            // DiceThickness
            // 
            this.DiceThickness.Location = new System.Drawing.Point(139, 113);
            this.DiceThickness.Name = "DiceThickness";
            this.DiceThickness.Size = new System.Drawing.Size(133, 22);
            this.DiceThickness.TabIndex = 8;
            this.DiceThickness.TextChanged += new System.EventHandler(this.DiceThickness_TextChanged);
            // 
            // DedgingDiametr
            // 
            this.DedgingDiametr.Location = new System.Drawing.Point(139, 145);
            this.DedgingDiametr.Name = "DedgingDiametr";
            this.DedgingDiametr.Size = new System.Drawing.Size(133, 22);
            this.DedgingDiametr.TabIndex = 9;
            this.DedgingDiametr.TextChanged += new System.EventHandler(this.DedgingDiametr_TextChanged);
            // 
            // EdgeWidth
            // 
            this.EdgeWidth.Location = new System.Drawing.Point(139, 174);
            this.EdgeWidth.Name = "EdgeWidth";
            this.EdgeWidth.Size = new System.Drawing.Size(133, 22);
            this.EdgeWidth.TabIndex = 10;
            this.EdgeWidth.TextChanged += new System.EventHandler(this.EdgeWidth_TextChanged);
            // 
            // EdgeDepth
            // 
            this.EdgeDepth.Location = new System.Drawing.Point(139, 201);
            this.EdgeDepth.Name = "EdgeDepth";
            this.EdgeDepth.Size = new System.Drawing.Size(133, 22);
            this.EdgeDepth.TabIndex = 11;
            this.EdgeDepth.TextChanged += new System.EventHandler(this.EdgeDepth_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Построить объект";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(567, 487);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Глубина выемки";
            // 
            // DedgingDepth
            // 
            this.DedgingDepth.Location = new System.Drawing.Point(139, 230);
            this.DedgingDepth.Name = "DedgingDepth";
            this.DedgingDepth.Size = new System.Drawing.Size(133, 22);
            this.DedgingDepth.TabIndex = 14;
            this.DedgingDepth.TextChanged += new System.EventHandler(this.DedgingDepth_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 502);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox EdgeDepth;
        private System.Windows.Forms.TextBox EdgeWidth;
        private System.Windows.Forms.TextBox DedgingDiametr;
        private System.Windows.Forms.TextBox DiceThickness;
        private System.Windows.Forms.TextBox DiceWidth;
        private System.Windows.Forms.TextBox DiceHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox DedgingDepth;
        private System.Windows.Forms.Label label8;
    }
}