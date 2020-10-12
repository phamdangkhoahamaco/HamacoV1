namespace HAMACO
{
    partial class FRM_MSCROLE
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmscname = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtmscdg = new System.Windows.Forms.TextBox();
            this.txtmsccode = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tssave = new System.Windows.Forms.ToolStripLabel();
            this.tscancel = new System.Windows.Forms.ToolStripLabel();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Diễn giải";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên vai trò (*)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã vai trò (*)";
            // 
            // txtmscname
            // 
            this.txtmscname.Location = new System.Drawing.Point(79, 45);
            this.txtmscname.Name = "txtmscname";
            this.txtmscname.Size = new System.Drawing.Size(270, 21);
            this.txtmscname.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtmscdg);
            this.groupBox1.Controls.Add(this.txtmscname);
            this.groupBox1.Controls.Add(this.txtmsccode);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txtmscdg
            // 
            this.txtmscdg.Location = new System.Drawing.Point(79, 71);
            this.txtmscdg.Multiline = true;
            this.txtmscdg.Name = "txtmscdg";
            this.txtmscdg.Size = new System.Drawing.Size(270, 54);
            this.txtmscdg.TabIndex = 0;
            // 
            // txtmsccode
            // 
            this.txtmsccode.Location = new System.Drawing.Point(79, 19);
            this.txtmsccode.Name = "txtmsccode";
            this.txtmsccode.Size = new System.Drawing.Size(270, 21);
            this.txtmsccode.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssave,
            this.tscancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(383, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tssave
            // 
            this.tssave.AutoSize = false;
            this.tssave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssave.ForeColor = System.Drawing.Color.Black;
            this.tssave.Image = global::HAMACO.Properties.Resources.Save;
            this.tssave.Name = "tssave";
            this.tssave.Size = new System.Drawing.Size(80, 37);
            this.tssave.Text = "Cất và Đóng";
            this.tssave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tssave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tssave.Click += new System.EventHandler(this.tssave_Click);
            // 
            // tscancel
            // 
            this.tscancel.AutoSize = false;
            this.tscancel.Image = global::HAMACO.Properties.Resources._1354680452_back;
            this.tscancel.Name = "tscancel";
            this.tscancel.Size = new System.Drawing.Size(57, 37);
            this.tscancel.Text = "Hủy bỏ";
            this.tscancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tscancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tscancel.Click += new System.EventHandler(this.tscancel_Click);
            // 
            // FRM_MSCROLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 196);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_MSCROLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_MSCROLE";
            this.Load += new System.EventHandler(this.FRM_MSCROLE_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmscname;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtmscdg;
        private System.Windows.Forms.TextBox txtmsccode;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tssave;
        private System.Windows.Forms.ToolStripLabel tscancel;
    }
}