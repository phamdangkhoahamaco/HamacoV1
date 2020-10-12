namespace HAMACO
{
    partial class Frm_UserLock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UserLock));
            this.lblLock = new System.Windows.Forms.Label();
            this.btnLock = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUnlock = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lblLock
            // 
            this.lblLock.AutoSize = true;
            this.lblLock.Location = new System.Drawing.Point(13, 25);
            this.lblLock.Name = "lblLock";
            this.lblLock.Size = new System.Drawing.Size(38, 13);
            this.lblLock.TabIndex = 0;
            this.lblLock.Text = "lblLock";
            // 
            // btnLock
            // 
            this.btnLock.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLock.Appearance.Options.UseForeColor = true;
            this.btnLock.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnLock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.ImageOptions.Image")));
            this.btnLock.Location = new System.Drawing.Point(182, 83);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(23, 20);
            this.btnLock.TabIndex = 5;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUnlock.Appearance.Options.UseForeColor = true;
            this.btnUnlock.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnUnlock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnUnlock.Location = new System.Drawing.Point(211, 81);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(23, 20);
            this.btnUnlock.TabIndex = 6;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            // 
            // Frm_UserLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 114);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.lblLock);
            this.Name = "Frm_UserLock";
            this.Text = "Frm_UserLock";
            this.Load += new System.EventHandler(this.Frm_UserLock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLock;
        private DevExpress.XtraEditors.SimpleButton btnLock;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.SimpleButton btnUnlock;
    }
}