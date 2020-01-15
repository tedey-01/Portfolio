namespace Simplex_prog
{
    partial class Result
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Result));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ButtClose = new System.Windows.Forms.Button();
            this.HeadLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ButtCalculate = new System.Windows.Forms.Button();
            this.answer = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.ButtClose);
            this.panel1.Controls.Add(this.HeadLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 159);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Brown;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(905, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 21);
            this.button1.TabIndex = 4;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtClose
            // 
            this.ButtClose.BackColor = System.Drawing.Color.Brown;
            this.ButtClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ButtClose.Location = new System.Drawing.Point(1015, -2);
            this.ButtClose.Name = "ButtClose";
            this.ButtClose.Size = new System.Drawing.Size(30, 21);
            this.ButtClose.TabIndex = 1;
            this.ButtClose.Text = "X";
            this.ButtClose.UseVisualStyleBackColor = false;
            // 
            // HeadLabel
            // 
            this.HeadLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeadLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadLabel.Font = new System.Drawing.Font("Lucida Handwriting", 32F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeadLabel.ForeColor = System.Drawing.Color.Gold;
            this.HeadLabel.Location = new System.Drawing.Point(0, 0);
            this.HeadLabel.Name = "HeadLabel";
            this.HeadLabel.Size = new System.Drawing.Size(933, 132);
            this.HeadLabel.TabIndex = 0;
            this.HeadLabel.Text = "Result";
            this.HeadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ButtCalculate
            // 
            this.ButtCalculate.BackColor = System.Drawing.Color.Goldenrod;
            this.ButtCalculate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ButtCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Firebrick;
            this.ButtCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.ButtCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtCalculate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtCalculate.Location = new System.Drawing.Point(390, 420);
            this.ButtCalculate.Name = "ButtCalculate";
            this.ButtCalculate.Size = new System.Drawing.Size(179, 43);
            this.ButtCalculate.TabIndex = 5;
            this.ButtCalculate.Text = "repeat";
            this.ButtCalculate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ButtCalculate.UseVisualStyleBackColor = false;
            this.ButtCalculate.Click += new System.EventHandler(this.ButtCalculate_Click);
            // 
            // answer
            // 
            this.answer.BackColor = System.Drawing.Color.Transparent;
            this.answer.Font = new System.Drawing.Font("Lucida Handwriting", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer.ForeColor = System.Drawing.Color.Black;
            this.answer.Location = new System.Drawing.Point(2, 209);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(933, 132);
            this.answer.TabIndex = 6;
            this.answer.Text = "Result";
            this.answer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(937, 519);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.ButtCalculate);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Result";
            this.Text = "Result";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ButtClose;
        private System.Windows.Forms.Label HeadLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button ButtCalculate;
        private System.Windows.Forms.Label answer;
    }
}