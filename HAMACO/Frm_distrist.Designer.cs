namespace HAMACO
{
    partial class Frm_distrist
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
            this.cbprovince = new System.Windows.Forms.ComboBox();
            this.txtdg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtsave = new System.Windows.Forms.ToolStripButton();
            this.tsbtcancel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbprovince
            // 
            this.cbprovince.FormattingEnabled = true;
            this.cbprovince.Location = new System.Drawing.Point(93, 118);
            this.cbprovince.Name = "cbprovince";
            this.cbprovince.Size = new System.Drawing.Size(143, 21);
            this.cbprovince.TabIndex = 2;
            // 
            // txtdg
            // 
            this.txtdg.Location = new System.Drawing.Point(93, 72);
            this.txtdg.Multiline = true;
            this.txtdg.Name = "txtdg";
            this.txtdg.Size = new System.Drawing.Size(255, 39);
            this.txtdg.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Diễn giải";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(93, 46);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(255, 21);
            this.txtname.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbprovince);
            this.groupBox1.Controls.Add(this.txtdg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 152);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Thông tin chung   ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên (*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tỉnh/Thành (*)";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(93, 20);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(143, 21);
            this.txtcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã (*)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtsave,
            this.tsbtcancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(388, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtsave
            // 
            this.tsbtsave.Image = global::HAMACO.Properties.Resources.Save;
            this.tsbtsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtsave.Name = "tsbtsave";
            this.tsbtsave.Size = new System.Drawing.Size(90, 37);
            this.tsbtsave.Text = "   Cất và Đóng   ";
            this.tsbtsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtsave.Click += new System.EventHandler(this.tsbtsave_Click);
            // 
            // tsbtcancel
            // 
            this.tsbtcancel.Image = global::HAMACO.Properties.Resources._1354680452_back;
            this.tsbtcancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtcancel.Name = "tsbtcancel";
            this.tsbtcancel.Size = new System.Drawing.Size(48, 37);
            this.tsbtcancel.Text = "   Hủy   ";
            this.tsbtcancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtcancel.Click += new System.EventHandler(this.tsbtcancel_Click);
            // 
            // Frm_distrist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 206);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_distrist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_distrist";
            this.Load += new System.EventHandler(this.Frm_distrist_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbprovince;
        private System.Windows.Forms.TextBox txtdg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbtsave;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtcancel;
    }
}