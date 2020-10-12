namespace HAMACO
{
    partial class Frm_UserSetPW
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtmk2 = new DevExpress.XtraEditors.TextEdit();
            this.txtten = new DevExpress.XtraEditors.TextEdit();
            this.txtmk = new DevExpress.XtraEditors.TextEdit();
            this.btlogin = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtmk2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmk.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.White;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.simpleButton1.Location = new System.Drawing.Point(112, 158);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(95, 28);
            this.simpleButton1.TabIndex = 32;
            this.simpleButton1.Text = "Hủy";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(16, 113);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(108, 13);
            this.labelControl4.TabIndex = 36;
            this.labelControl4.Text = "Nhập lại mật khẩu mới:";
            this.labelControl4.Click += new System.EventHandler(this.labelControl4_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 27;
            this.labelControl3.Text = "Mật khẩu mới:";
            this.labelControl3.Click += new System.EventHandler(this.labelControl3_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Tên đăng nhập:";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // txtmk2
            // 
            this.txtmk2.EditValue = "";
            this.txtmk2.Location = new System.Drawing.Point(13, 128);
            this.txtmk2.Name = "txtmk2";
            this.txtmk2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmk2.Properties.Appearance.Options.UseFont = true;
            this.txtmk2.Properties.NullText = "Mật khẩu";
            this.txtmk2.Properties.PasswordChar = '•';
            this.txtmk2.Size = new System.Drawing.Size(194, 20);
            this.txtmk2.TabIndex = 30;
            this.txtmk2.EditValueChanged += new System.EventHandler(this.txtmk2_EditValueChanged);
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(12, 38);
            this.txtten.Name = "txtten";
            this.txtten.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtten.Properties.Appearance.Options.UseFont = true;
            this.txtten.Properties.NullText = "Tên đăng nhập";
            this.txtten.Properties.ReadOnly = true;
            this.txtten.Size = new System.Drawing.Size(194, 20);
            this.txtten.TabIndex = 26;
            this.txtten.TabStop = false;
            this.txtten.EditValueChanged += new System.EventHandler(this.txtten_EditValueChanged);
            // 
            // txtmk
            // 
            this.txtmk.EditValue = "";
            this.txtmk.Location = new System.Drawing.Point(14, 91);
            this.txtmk.Name = "txtmk";
            this.txtmk.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmk.Properties.Appearance.Options.UseFont = true;
            this.txtmk.Properties.NullText = "Mật khẩu";
            this.txtmk.Properties.PasswordChar = '•';
            this.txtmk.Size = new System.Drawing.Size(194, 20);
            this.txtmk.TabIndex = 29;
            this.txtmk.EditValueChanged += new System.EventHandler(this.txtmk_EditValueChanged);
            // 
            // btlogin
            // 
            this.btlogin.Appearance.BackColor = System.Drawing.Color.White;
            this.btlogin.Appearance.Options.UseBackColor = true;
            this.btlogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btlogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btlogin.Location = new System.Drawing.Point(14, 158);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(95, 28);
            this.btlogin.TabIndex = 31;
            this.btlogin.Text = "Đồng ý";
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // Frm_UserSetPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 219);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtmk2);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.btlogin);
            this.Name = "Frm_UserSetPW";
            this.Text = "Frm_UserSetPW";
            this.Load += new System.EventHandler(this.Frm_UserSetPW_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtmk2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmk.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtmk2;
        private DevExpress.XtraEditors.TextEdit txtten;
        private DevExpress.XtraEditors.TextEdit txtmk;
        private DevExpress.XtraEditors.SimpleButton btlogin;
    }
}