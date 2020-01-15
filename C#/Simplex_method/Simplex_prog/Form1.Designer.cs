namespace Simplex_prog
{
    partial class StartForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.ButtClose = new System.Windows.Forms.Button();
			this.HeadLabel = new System.Windows.Forms.Label();
			this.BodyLabel = new System.Windows.Forms.Label();
			this.ButtNext = new System.Windows.Forms.Button();
			this.ResourseField = new System.Windows.Forms.TextBox();
			this.SourceCountLabel = new System.Windows.Forms.Label();
			this.ResurseCountLabel = new System.Windows.Forms.Label();
			this.ProductField = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Gold;
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.ButtClose);
			this.panel1.Controls.Add(this.HeadLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1399, 174);
			this.panel1.TabIndex = 0;
			// 
			// ButtClose
			// 
			this.ButtClose.BackColor = System.Drawing.Color.Brown;
			this.ButtClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ButtClose.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.ButtClose.Location = new System.Drawing.Point(1353, -2);
			this.ButtClose.Margin = new System.Windows.Forms.Padding(4);
			this.ButtClose.Name = "ButtClose";
			this.ButtClose.Size = new System.Drawing.Size(40, 26);
			this.ButtClose.TabIndex = 1;
			this.ButtClose.Text = "X";
			this.ButtClose.UseVisualStyleBackColor = false;
			this.ButtClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// HeadLabel
			// 
			this.HeadLabel.BackColor = System.Drawing.Color.Transparent;
			this.HeadLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.HeadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.HeadLabel.ForeColor = System.Drawing.Color.Gold;
			this.HeadLabel.Location = new System.Drawing.Point(0, 0);
			this.HeadLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.HeadLabel.Name = "HeadLabel";
			this.HeadLabel.Size = new System.Drawing.Size(1395, 170);
			this.HeadLabel.TabIndex = 0;
			this.HeadLabel.Text = "Simplex method";
			this.HeadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// BodyLabel
			// 
			this.BodyLabel.BackColor = System.Drawing.Color.Transparent;
			this.BodyLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.BodyLabel.Font = new System.Drawing.Font("Leelawadee", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BodyLabel.ForeColor = System.Drawing.Color.Black;
			this.BodyLabel.Location = new System.Drawing.Point(0, 174);
			this.BodyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.BodyLabel.Name = "BodyLabel";
			this.BodyLabel.Size = new System.Drawing.Size(1399, 230);
			this.BodyLabel.TabIndex = 1;
			this.BodyLabel.Text = resources.GetString("BodyLabel.Text");
			this.BodyLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// ButtNext
			// 
			this.ButtNext.BackColor = System.Drawing.Color.Goldenrod;
			this.ButtNext.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.ButtNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
			this.ButtNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
			this.ButtNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ButtNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtNext.Location = new System.Drawing.Point(612, 717);
			this.ButtNext.Margin = new System.Windows.Forms.Padding(4);
			this.ButtNext.Name = "ButtNext";
			this.ButtNext.Size = new System.Drawing.Size(221, 47);
			this.ButtNext.TabIndex = 2;
			this.ButtNext.Text = "next";
			this.ButtNext.UseVisualStyleBackColor = false;
			this.ButtNext.Click += new System.EventHandler(this.ButtNext_Click);
			// 
			// ResourseField
			// 
			this.ResourseField.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ResourseField.Location = new System.Drawing.Point(1160, 453);
			this.ResourseField.Margin = new System.Windows.Forms.Padding(4);
			this.ResourseField.Name = "ResourseField";
			this.ResourseField.Size = new System.Drawing.Size(55, 38);
			this.ResourseField.TabIndex = 3;
			this.ResourseField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SourceCountLabel
			// 
			this.SourceCountLabel.AutoSize = true;
			this.SourceCountLabel.BackColor = System.Drawing.Color.Transparent;
			this.SourceCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.SourceCountLabel.ForeColor = System.Drawing.Color.Maroon;
			this.SourceCountLabel.Location = new System.Drawing.Point(159, 453);
			this.SourceCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.SourceCountLabel.Name = "SourceCountLabel";
			this.SourceCountLabel.Size = new System.Drawing.Size(928, 42);
			this.SourceCountLabel.TabIndex = 5;
			this.SourceCountLabel.Text = "Введите количество используемых ресурсов (m):";
			// 
			// ResurseCountLabel
			// 
			this.ResurseCountLabel.AutoSize = true;
			this.ResurseCountLabel.BackColor = System.Drawing.Color.Transparent;
			this.ResurseCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ResurseCountLabel.ForeColor = System.Drawing.Color.Maroon;
			this.ResurseCountLabel.Location = new System.Drawing.Point(159, 597);
			this.ResurseCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.ResurseCountLabel.Name = "ResurseCountLabel";
			this.ResurseCountLabel.Size = new System.Drawing.Size(957, 42);
			this.ResurseCountLabel.TabIndex = 6;
			this.ResurseCountLabel.Text = "Введите количество производимых продуктов (n) :";
			// 
			// ProductField
			// 
			this.ProductField.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ProductField.Location = new System.Drawing.Point(1160, 597);
			this.ProductField.Margin = new System.Windows.Forms.Padding(4);
			this.ProductField.Name = "ProductField";
			this.ProductField.Size = new System.Drawing.Size(55, 38);
			this.ProductField.TabIndex = 7;
			this.ProductField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// StartForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1399, 972);
			this.Controls.Add(this.ProductField);
			this.Controls.Add(this.ResurseCountLabel);
			this.Controls.Add(this.SourceCountLabel);
			this.Controls.Add(this.ResourseField);
			this.Controls.Add(this.ButtNext);
			this.Controls.Add(this.BodyLabel);
			this.Controls.Add(this.panel1);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "StartForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Label BodyLabel;
        private System.Windows.Forms.Button ButtNext;
        private System.Windows.Forms.TextBox ResourseField;
        private System.Windows.Forms.Label SourceCountLabel;
        private System.Windows.Forms.Label ResurseCountLabel;
        private System.Windows.Forms.TextBox ProductField;
        private System.Windows.Forms.Button ButtClose;
    }
}

