namespace SANPHAM
{
    partial class frmSize
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
            this.btnthem = new System.Windows.Forms.Button();
            this.btnchon = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flpSize = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnthem
            // 
            this.btnthem.Location = new System.Drawing.Point(343, 297);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(88, 38);
            this.btnthem.TabIndex = 0;
            this.btnthem.Text = "Thêm";
            this.btnthem.UseVisualStyleBackColor = true;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // btnchon
            // 
            this.btnchon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnchon.Location = new System.Drawing.Point(459, 297);
            this.btnchon.Name = "btnchon";
            this.btnchon.Size = new System.Drawing.Size(105, 39);
            this.btnchon.TabIndex = 1;
            this.btnchon.Text = "Chọn";
            this.btnchon.UseVisualStyleBackColor = true;
            this.btnchon.Click += new System.EventHandler(this.btnchon_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(163, 296);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 38);
            this.textBox1.TabIndex = 2;
            // 
            // flpSize
            // 
            this.flpSize.Location = new System.Drawing.Point(12, 29);
            this.flpSize.Name = "flpSize";
            this.flpSize.Size = new System.Drawing.Size(561, 245);
            this.flpSize.TabIndex = 3;
            this.flpSize.Paint += new System.Windows.Forms.PaintEventHandler(this.flpSize_Paint);
            // 
            // frmSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 356);
            this.Controls.Add(this.flpSize);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnchon);
            this.Controls.Add(this.btnthem);
            this.Name = "frmSize";
            this.Text = "frmSize";
            this.Load += new System.EventHandler(this.frmSize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Button btnchon;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flpSize;
    }
}