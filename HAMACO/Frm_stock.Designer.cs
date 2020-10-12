namespace HAMACO
{
    partial class Frm_stock
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
            this.chbntd = new System.Windows.Forms.CheckBox();
            this.txtdg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtnote = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txttcn = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.leprovince = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lekho = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.LPG = new DevExpress.XtraEditors.CheckEdit();
            this.txtmst = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtsave = new System.Windows.Forms.ToolStripButton();
            this.tsbtcancel = new System.Windows.Forms.ToolStripButton();
            this.cbbranch = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leprovince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lekho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LPG.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbranch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chbntd
            // 
            this.chbntd.AutoSize = true;
            this.chbntd.Location = new System.Drawing.Point(179, 281);
            this.chbntd.Name = "chbntd";
            this.chbntd.Size = new System.Drawing.Size(100, 17);
            this.chbntd.TabIndex = 4;
            this.chbntd.Text = "Ngừng theo dõi";
            this.chbntd.UseVisualStyleBackColor = true;
            // 
            // txtdg
            // 
            this.txtdg.Location = new System.Drawing.Point(95, 97);
            this.txtdg.Multiline = true;
            this.txtdg.Name = "txtdg";
            this.txtdg.Size = new System.Drawing.Size(268, 39);
            this.txtdg.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Địa chỉ ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Đơn vị (*)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSQL);
            this.groupBox1.Controls.Add(this.cbbranch);
            this.groupBox1.Controls.Add(this.txtnote);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txttcn);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.leprovince);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lekho);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LPG);
            this.groupBox1.Controls.Add(this.chbntd);
            this.groupBox1.Controls.Add(this.txtdg);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtmst);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 329);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "  Thông tin chung  ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtnote
            // 
            this.txtnote.Location = new System.Drawing.Point(95, 141);
            this.txtnote.Name = "txtnote";
            this.txtnote.Size = new System.Drawing.Size(268, 21);
            this.txtnote.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Ghi chú";
            // 
            // txttcn
            // 
            this.txttcn.Location = new System.Drawing.Point(95, 71);
            this.txttcn.Name = "txttcn";
            this.txttcn.Size = new System.Drawing.Size(268, 21);
            this.txttcn.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tên chi nhánh";
            // 
            // leprovince
            // 
            this.leprovince.Location = new System.Drawing.Point(95, 250);
            this.leprovince.Name = "leprovince";
            this.leprovince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leprovince.Size = new System.Drawing.Size(182, 20);
            this.leprovince.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Khu vực (*)";
            // 
            // lekho
            // 
            this.lekho.Location = new System.Drawing.Point(95, 224);
            this.lekho.Name = "lekho";
            this.lekho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lekho.Size = new System.Drawing.Size(182, 20);
            this.lekho.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mã kho (*)";
            // 
            // LPG
            // 
            this.LPG.Location = new System.Drawing.Point(93, 279);
            this.LPG.Name = "LPG";
            this.LPG.Properties.Caption = "Là kho LPG";
            this.LPG.Size = new System.Drawing.Size(80, 19);
            this.LPG.TabIndex = 6;
            // 
            // txtmst
            // 
            this.txtmst.Location = new System.Drawing.Point(95, 167);
            this.txtmst.Name = "txtmst";
            this.txtmst.Size = new System.Drawing.Size(268, 21);
            this.txtmst.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mã số thuế";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(95, 45);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(268, 21);
            this.txtname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên (*)";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(95, 19);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(182, 21);
            this.txtcode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã (*)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtsave,
            this.tsbtcancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(408, 40);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtsave
            // 
            this.tsbtsave.Image = global::HAMACO.Properties.Resources.Save;
            this.tsbtsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtsave.Name = "tsbtsave";
            this.tsbtsave.Size = new System.Drawing.Size(94, 37);
            this.tsbtsave.Text = "   Cất và Đóng   ";
            this.tsbtsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtsave.Click += new System.EventHandler(this.tsbtsave_Click);
            // 
            // tsbtcancel
            // 
            this.tsbtcancel.Image = global::HAMACO.Properties.Resources._1354680452_back;
            this.tsbtcancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtcancel.Name = "tsbtcancel";
            this.tsbtcancel.Size = new System.Drawing.Size(51, 37);
            this.tsbtcancel.Text = "   Hủy   ";
            this.tsbtcancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtcancel.Click += new System.EventHandler(this.tsbtcancel_Click);
            // 
            // cbbranch
            // 
            this.cbbranch.Location = new System.Drawing.Point(93, 196);
            this.cbbranch.Name = "cbbranch";
            this.cbbranch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbbranch.Size = new System.Drawing.Size(182, 20);
            this.cbbranch.TabIndex = 15;
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(7, 303);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(377, 21);
            this.txtSQL.TabIndex = 16;
            // 
            // Frm_stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_stock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho";
            this.Load += new System.EventHandler(this.Frm_stock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leprovince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lekho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LPG.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbbranch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbntd;
        private System.Windows.Forms.TextBox txtdg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbtsave;
        private System.Windows.Forms.ToolStripButton tsbtcancel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraEditors.CheckEdit LPG;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lekho;
        private DevExpress.XtraEditors.LookUpEdit leprovince;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttcn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtnote;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.LookUpEdit cbbranch;
        private System.Windows.Forms.TextBox txtSQL;
    }
}