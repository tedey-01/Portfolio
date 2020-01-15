namespace Simplex_prog
{
    partial class CalculationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationForm));
			this.ButtCalculate = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.ButtClose = new System.Windows.Forms.Button();
			this.HeadLable = new System.Windows.Forms.Label();
			this.SourceCountLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ButtCalculate
			// 
			this.ButtCalculate.BackColor = System.Drawing.Color.Goldenrod;
			this.ButtCalculate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtCalculate.FlatAppearance.BorderSize = 0;
			this.ButtCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
			this.ButtCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
			this.ButtCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtCalculate.Location = new System.Drawing.Point(585, 636);
			this.ButtCalculate.Margin = new System.Windows.Forms.Padding(4);
			this.ButtCalculate.Name = "ButtCalculate";
			this.ButtCalculate.Size = new System.Drawing.Size(239, 53);
			this.ButtCalculate.TabIndex = 4;
			this.ButtCalculate.Text = "calculate";
			this.ButtCalculate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.ButtCalculate.UseVisualStyleBackColor = false;
			this.ButtCalculate.Click += new System.EventHandler(this.ButtCalculate_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gold;
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.ButtClose);
			this.panel1.Controls.Add(this.HeadLable);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1545, 195);
			this.panel1.TabIndex = 3;
			// 
			// ButtClose
			// 
			this.ButtClose.BackColor = System.Drawing.Color.Brown;
			this.ButtClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtClose.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.ButtClose.Location = new System.Drawing.Point(1501, 0);
			this.ButtClose.Margin = new System.Windows.Forms.Padding(4);
			this.ButtClose.Name = "ButtClose";
			this.ButtClose.Size = new System.Drawing.Size(40, 26);
			this.ButtClose.TabIndex = 2;
			this.ButtClose.Text = "X";
			this.ButtClose.UseVisualStyleBackColor = false;
			this.ButtClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// HeadLable
			// 
			this.HeadLable.BackColor = System.Drawing.Color.Transparent;
			this.HeadLable.Dock = System.Windows.Forms.DockStyle.Top;
			this.HeadLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadLable.ForeColor = System.Drawing.Color.Gold;
			this.HeadLable.Location = new System.Drawing.Point(0, 0);
			this.HeadLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.HeadLable.Name = "HeadLable";
			this.HeadLable.Size = new System.Drawing.Size(1541, 172);
			this.HeadLable.TabIndex = 0;
			this.HeadLable.Text = "Simplex method";
			this.HeadLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// SourceCountLabel
			// 
			this.SourceCountLabel.AutoSize = true;
			this.SourceCountLabel.BackColor = System.Drawing.Color.Transparent;
			this.SourceCountLabel.Font = new System.Drawing.Font("Leelawadee", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SourceCountLabel.ForeColor = System.Drawing.Color.Black;
			this.SourceCountLabel.Location = new System.Drawing.Point(8, 266);
			this.SourceCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SourceCountLabel.Name = "SourceCountLabel";
			this.SourceCountLabel.Size = new System.Drawing.Size(484, 120);
			this.SourceCountLabel.TabIndex = 6;
			this.SourceCountLabel.Text = "Технологическая матрица A \r\nзатрат любого ресурса на \r\nединицу каждой продукции";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Leelawadee", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(656, 304);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(326, 82);
			this.label1.TabIndex = 7;
			this.label1.Text = "Вектор B \r\nобъемов ресурсов";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Leelawadee", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(1172, 304);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(330, 82);
			this.label2.TabIndex = 8;
			this.label2.Text = "Вектор C \r\nудельной прибыли";
			// 
			// CalculationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(1545, 722);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.SourceCountLabel);
			this.Controls.Add(this.ButtCalculate);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CalculationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CalculationForm";
			this.Load += new System.EventHandler(this.CalculationForm_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtCalculate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label HeadLable;
        private System.Windows.Forms.Button ButtClose;
        private System.Windows.Forms.Label SourceCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}