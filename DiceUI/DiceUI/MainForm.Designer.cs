
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
            this.DedgingDepth = new System.Windows.Forms.TextBox();
            this.DedgingDepthlabel = new System.Windows.Forms.Label();
            this.BuildObjectbutton = new System.Windows.Forms.Button();
            this.EdgeDepth = new System.Windows.Forms.TextBox();
            this.EdgeWidth = new System.Windows.Forms.TextBox();
            this.DedgingDiametr = new System.Windows.Forms.TextBox();
            this.DiceThickness = new System.Windows.Forms.TextBox();
            this.DiceWidth = new System.Windows.Forms.TextBox();
            this.DiceHeight = new System.Windows.Forms.TextBox();
            this.EdgeDepthlabel = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDepth);
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDepthlabel);
            this.splitContainer1.Panel1.Controls.Add(this.BuildObjectbutton);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeDepth);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeWidth);
            this.splitContainer1.Panel1.Controls.Add(this.DedgingDiametr);
            this.splitContainer1.Panel1.Controls.Add(this.DiceThickness);
            this.splitContainer1.Panel1.Controls.Add(this.DiceWidth);
            this.splitContainer1.Panel1.Controls.Add(this.DiceHeight);
            this.splitContainer1.Panel1.Controls.Add(this.EdgeDepthlabel);
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
            this.splitContainer1.Size = new System.Drawing.Size(867, 502);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 0;
            // 
            // DedgingDepth
            // 
            this.DedgingDepth.Location = new System.Drawing.Point(139, 230);
            this.DedgingDepth.Name = "DedgingDepth";
            this.DedgingDepth.Size = new System.Drawing.Size(133, 22);
            this.DedgingDepth.TabIndex = 14;
            this.DedgingDepth.TextChanged += new System.EventHandler(this.DedgingDepth_TextChanged);
            // 
            // DedgingDepthlabel
            // 
            this.DedgingDepthlabel.AutoSize = true;
            this.DedgingDepthlabel.Location = new System.Drawing.Point(12, 229);
            this.DedgingDepthlabel.Name = "DedgingDepthlabel";
            this.DedgingDepthlabel.Size = new System.Drawing.Size(116, 17);
            this.DedgingDepthlabel.TabIndex = 13;
            this.DedgingDepthlabel.Text = "Глубина выемки";
            // 
            // BuildObjectbutton
            // 
            this.BuildObjectbutton.Location = new System.Drawing.Point(15, 461);
            this.BuildObjectbutton.Name = "BuildObjectbutton";
            this.BuildObjectbutton.Size = new System.Drawing.Size(163, 29);
            this.BuildObjectbutton.TabIndex = 12;
            this.BuildObjectbutton.Text = "Построить объект";
            this.BuildObjectbutton.UseVisualStyleBackColor = true;
            // 
            // EdgeDepth
            // 
            this.EdgeDepth.Location = new System.Drawing.Point(139, 201);
            this.EdgeDepth.Name = "EdgeDepth";
            this.EdgeDepth.Size = new System.Drawing.Size(133, 22);
            this.EdgeDepth.TabIndex = 11;
            this.EdgeDepth.TextChanged += new System.EventHandler(this.EdgeDepth_TextChanged);
            // 
            // EdgeWidth
            // 
            this.EdgeWidth.Location = new System.Drawing.Point(139, 174);
            this.EdgeWidth.Name = "EdgeWidth";
            this.EdgeWidth.Size = new System.Drawing.Size(133, 22);
            this.EdgeWidth.TabIndex = 10;
            this.EdgeWidth.TextChanged += new System.EventHandler(this.EdgeWidth_TextChanged);
            // 
            // DedgingDiametr
            // 
            this.DedgingDiametr.Location = new System.Drawing.Point(139, 145);
            this.DedgingDiametr.Name = "DedgingDiametr";
            this.DedgingDiametr.Size = new System.Drawing.Size(133, 22);
            this.DedgingDiametr.TabIndex = 9;
            this.DedgingDiametr.TextChanged += new System.EventHandler(this.DedgingDiametr_TextChanged);
            // 
            // DiceThickness
            // 
            this.DiceThickness.Location = new System.Drawing.Point(139, 113);
            this.DiceThickness.Name = "DiceThickness";
            this.DiceThickness.Size = new System.Drawing.Size(133, 22);
            this.DiceThickness.TabIndex = 8;
            this.DiceThickness.TextChanged += new System.EventHandler(this.DiceThickness_TextChanged);
            // 
            // DiceWidth
            // 
            this.DiceWidth.Location = new System.Drawing.Point(139, 83);
            this.DiceWidth.Name = "DiceWidth";
            this.DiceWidth.Size = new System.Drawing.Size(133, 22);
            this.DiceWidth.TabIndex = 7;
            this.DiceWidth.TextChanged += new System.EventHandler(this.DiceWidth_TextChanged);
            // 
            // DiceHeight
            // 
            this.DiceHeight.Location = new System.Drawing.Point(139, 57);
            this.DiceHeight.Name = "DiceHeight";
            this.DiceHeight.Size = new System.Drawing.Size(133, 22);
            this.DiceHeight.TabIndex = 0;
            this.DiceHeight.TextChanged += new System.EventHandler(this.DiceHeight_TextChanged);
            // 
            // EdgeDepthlabel
            // 
            this.EdgeDepthlabel.AutoSize = true;
            this.EdgeDepthlabel.Location = new System.Drawing.Point(12, 201);
            this.EdgeDepthlabel.Name = "EdgeDepthlabel";
            this.EdgeDepthlabel.Size = new System.Drawing.Size(114, 17);
            this.EdgeDepthlabel.TabIndex = 6;
            this.EdgeDepthlabel.Text = "Глубина каемки";
            // 
            // EdgeWidthlabel
            // 
            this.EdgeWidthlabel.AutoSize = true;
            this.EdgeWidthlabel.Location = new System.Drawing.Point(12, 173);
            this.EdgeWidthlabel.Name = "EdgeWidthlabel";
            this.EdgeWidthlabel.Size = new System.Drawing.Size(110, 17);
            this.EdgeWidthlabel.TabIndex = 5;
            this.EdgeWidthlabel.Text = "Ширина каемки";
            // 
            // DedgingDiametrlabel
            // 
            this.DedgingDiametrlabel.AutoSize = true;
            this.DedgingDiametrlabel.Location = new System.Drawing.Point(12, 145);
            this.DedgingDiametrlabel.Name = "DedgingDiametrlabel";
            this.DedgingDiametrlabel.Size = new System.Drawing.Size(120, 17);
            this.DedgingDiametrlabel.TabIndex = 4;
            this.DedgingDiametrlabel.Text = "Диаметр выемки";
            // 
            // DiceThicknesslabel
            // 
            this.DiceThicknesslabel.AutoSize = true;
            this.DiceThicknesslabel.Location = new System.Drawing.Point(12, 116);
            this.DiceThicknesslabel.Name = "DiceThicknesslabel";
            this.DiceThicknesslabel.Size = new System.Drawing.Size(109, 17);
            this.DiceThicknesslabel.TabIndex = 3;
            this.DiceThicknesslabel.Text = "Толщина кости";
            // 
            // DiceWidthlabel
            // 
            this.DiceWidthlabel.AutoSize = true;
            this.DiceWidthlabel.Location = new System.Drawing.Point(12, 86);
            this.DiceWidthlabel.Name = "DiceWidthlabel";
            this.DiceWidthlabel.Size = new System.Drawing.Size(100, 17);
            this.DiceWidthlabel.TabIndex = 2;
            this.DiceWidthlabel.Text = "Ширина кости";
            // 
            // DiceHeightlabel
            // 
            this.DiceHeightlabel.AutoSize = true;
            this.DiceHeightlabel.Location = new System.Drawing.Point(12, 60);
            this.DiceHeightlabel.Name = "DiceHeightlabel";
            this.DiceHeightlabel.Size = new System.Drawing.Size(98, 17);
            this.DiceHeightlabel.TabIndex = 1;
            this.DiceHeightlabel.Text = "Высота кости";
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(567, 487);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
        private System.Windows.Forms.Button BuildObjectbutton;
        private System.Windows.Forms.TextBox EdgeDepth;
        private System.Windows.Forms.TextBox EdgeWidth;
        private System.Windows.Forms.TextBox DedgingDiametr;
        private System.Windows.Forms.TextBox DiceThickness;
        private System.Windows.Forms.TextBox DiceWidth;
        private System.Windows.Forms.TextBox DiceHeight;
        private System.Windows.Forms.Label EdgeDepthlabel;
        private System.Windows.Forms.Label EdgeWidthlabel;
        private System.Windows.Forms.Label DedgingDiametrlabel;
        private System.Windows.Forms.Label DiceThicknesslabel;
        private System.Windows.Forms.Label DiceWidthlabel;
        private System.Windows.Forms.Label DiceHeightlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox DedgingDepth;
        private System.Windows.Forms.Label DedgingDepthlabel;
    }
}