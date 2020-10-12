namespace HAMACO
{
    partial class Frm_nht
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
            this.btcancel = new System.Windows.Forms.Button();
            this.denct = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btok = new System.Windows.Forms.Button();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.denct.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.denct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btcancel
            // 
            this.btcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcancel.Location = new System.Drawing.Point(108, 64);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(90, 23);
            this.btcancel.TabIndex = 3;
            this.btcancel.Text = "Hủy";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // denct
            // 
            this.denct.EditValue = null;
            this.denct.Location = new System.Drawing.Point(15, 33);
            this.denct.Name = "denct";
            this.denct.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.denct.Properties.Appearance.Options.UseFont = true;
            this.denct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.denct.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.denct.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.denct.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.denct.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.denct.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.denct.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.denct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.denct.Size = new System.Drawing.Size(183, 22);
            this.denct.TabIndex = 1;
            this.denct.EditValueChanged += new System.EventHandler(this.denct_EditValueChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btcancel);
            this.groupControl1.Controls.Add(this.btok);
            this.groupControl1.Controls.Add(this.denct);
            this.groupControl1.Location = new System.Drawing.Point(150, 17);
            this.groupControl1.LookAndFeel.SkinName = "Seven Classic";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(211, 101);
            this.groupControl1.TabIndex = 8;
            this.groupControl1.Text = "Ngày chứng từ";
            // 
            // btok
            // 
            this.btok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btok.Location = new System.Drawing.Point(15, 64);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(90, 23);
            this.btok.TabIndex = 2;
            this.btok.Text = "Đồng ý";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::HAMACO.Properties.Resources.calendar_empty1;
            this.pictureEdit1.Location = new System.Drawing.Point(4, -7);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(136, 150);
            this.pictureEdit1.TabIndex = 7;
            // 
            // Frm_nht
            // 
            this.AcceptButton = this.btok;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btcancel;
            this.ClientSize = new System.Drawing.Size(371, 138);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pictureEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_nht";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ngày chứng từ";
            this.Load += new System.EventHandler(this.Frm_nht_Load);
            ((System.ComponentModel.ISupportInitialize)(this.denct.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.denct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btcancel;
        private DevExpress.XtraEditors.DateEdit denct;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Button btok;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}