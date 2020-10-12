namespace HAMACO
{
    partial class Frm_Login2
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btcancel = new DevExpress.XtraEditors.SimpleButton();
            this.btlogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtmk = new DevExpress.XtraEditors.TextEdit();
            this.txtten = new DevExpress.XtraEditors.TextEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(81, 317);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Username";
            // 
            // btcancel
            // 
            this.btcancel.Appearance.BackColor = System.Drawing.Color.White;
            this.btcancel.Appearance.Options.UseBackColor = true;
            this.btcancel.Appearance.Options.UseTextOptions = true;
            this.btcancel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btcancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btcancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btcancel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btcancel.Location = new System.Drawing.Point(260, 401);
            this.btcancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btcancel.Name = "btcancel";
            this.btcancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btcancel.Size = new System.Drawing.Size(93, 28);
            this.btcancel.TabIndex = 16;
            this.btcancel.Text = "Thoát";
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // btlogin
            // 
            this.btlogin.Appearance.BackColor = System.Drawing.Color.White;
            this.btlogin.Appearance.Options.UseBackColor = true;
            this.btlogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btlogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btlogin.Location = new System.Drawing.Point(159, 401);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(95, 28);
            this.btlogin.TabIndex = 15;
            this.btlogin.Text = "Đăng nhập";
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
            // 
            // txtmk
            // 
            this.txtmk.EditValue = "123456";
            this.txtmk.Location = new System.Drawing.Point(159, 316);
            this.txtmk.Name = "txtmk";
            this.txtmk.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmk.Properties.Appearance.Options.UseFont = true;
            this.txtmk.Properties.NullText = "Mật khẩu";
            this.txtmk.Properties.PasswordChar = '•';
            this.txtmk.Size = new System.Drawing.Size(194, 20);
            this.txtmk.TabIndex = 14;
            // 
            // txtten
            // 
            this.txtten.EditValue = "PHAMKHOA";
            this.txtten.Location = new System.Drawing.Point(159, 290);
            this.txtten.Name = "txtten";
            this.txtten.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtten.Properties.Appearance.Options.UseFont = true;
            this.txtten.Properties.NullText = "Tên đăng nhập";
            this.txtten.Size = new System.Drawing.Size(194, 20);
            this.txtten.TabIndex = 13;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::HAMACO.Properties.Resources.options_icon;
            this.pictureEdit1.Location = new System.Drawing.Point(135, 90);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(237, 179);
            this.pictureEdit1.TabIndex = 12;
            // 
            // Frm_Login2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 520);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btcancel);
            this.Controls.Add(this.btlogin);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "Frm_Login2";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Frm_Login2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtmk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btcancel;
        private DevExpress.XtraEditors.SimpleButton btlogin;
        private DevExpress.XtraEditors.TextEdit txtmk;
        private DevExpress.XtraEditors.TextEdit txtten;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}