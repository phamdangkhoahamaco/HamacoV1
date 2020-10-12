namespace HAMACO
{
    partial class Frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_login));
            this.txtten = new DevExpress.XtraEditors.TextEdit();
            this.txtmk = new DevExpress.XtraEditors.TextEdit();
            this.btlogin = new DevExpress.XtraEditors.SimpleButton();
            this.btcancel = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.txtClient = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmk.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtten
            // 
            this.txtten.EditValue = "PHAMKHOA";
            this.txtten.Location = new System.Drawing.Point(90, 218);
            this.txtten.Name = "txtten";
            this.txtten.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtten.Properties.Appearance.Options.UseFont = true;
            this.txtten.Properties.NullText = "Tên đăng nhập";
            this.txtten.Size = new System.Drawing.Size(194, 20);
            this.txtten.TabIndex = 3;
            this.txtten.EditValueChanged += new System.EventHandler(this.txtten_EditValueChanged);
            // 
            // txtmk
            // 
            this.txtmk.EditValue = "123456";
            this.txtmk.Location = new System.Drawing.Point(90, 244);
            this.txtmk.Name = "txtmk";
            this.txtmk.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmk.Properties.Appearance.Options.UseFont = true;
            this.txtmk.Properties.NullText = "Mật khẩu";
            this.txtmk.Properties.PasswordChar = '•';
            this.txtmk.Size = new System.Drawing.Size(194, 20);
            this.txtmk.TabIndex = 4;
            // 
            // btlogin
            // 
            this.btlogin.Appearance.BackColor = System.Drawing.Color.White;
            this.btlogin.Appearance.Options.UseBackColor = true;
            this.btlogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btlogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btlogin.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btlogin.Location = new System.Drawing.Point(90, 329);
            this.btlogin.Name = "btlogin";
            this.btlogin.Size = new System.Drawing.Size(95, 28);
            this.btlogin.TabIndex = 5;
            this.btlogin.Text = "Đăng nhập";
            this.btlogin.Click += new System.EventHandler(this.btlogin_Click);
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
            this.btcancel.Location = new System.Drawing.Point(191, 329);
            this.btcancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btcancel.Name = "btcancel";
            this.btcancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btcancel.Size = new System.Drawing.Size(93, 28);
            this.btcancel.TabIndex = 6;
            this.btcancel.Text = "Thoát";
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Client";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::HAMACO.Properties.Resources.options_icon;
            this.pictureEdit1.Location = new System.Drawing.Point(66, 18);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(237, 179);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged_1);
            // 
            // txtClient
            // 
            this.txtClient.EditValue = "300";
            this.txtClient.Location = new System.Drawing.Point(90, 276);
            this.txtClient.Name = "txtClient";
            this.txtClient.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClient.Properties.Appearance.Options.UseFont = true;
            this.txtClient.Properties.NullText = "Tên đăng nhập";
            this.txtClient.Size = new System.Drawing.Size(194, 20);
            this.txtClient.TabIndex = 11;
            // 
            // Frm_login
            // 
            this.AcceptButton = this.btlogin;
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(58)))), ((int)(((byte)(61)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btcancel;
            this.ClientSize = new System.Drawing.Size(366, 369);
            this.Controls.Add(this.txtClient);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btcancel);
            this.Controls.Add(this.btlogin);
            this.Controls.Add(this.txtmk);
            this.Controls.Add(this.txtten);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.Frm_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtmk.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtClient.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.TextEdit txtten;
        private DevExpress.XtraEditors.TextEdit txtmk;
        private DevExpress.XtraEditors.SimpleButton btlogin;
        private DevExpress.XtraEditors.SimpleButton btcancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtClient;
    }
}