namespace HAMACO
{
    partial class Frm_chonkho
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
            this.btok = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ledv = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.dedenngay = new DevExpress.XtraEditors.DateEdit();
            this.detungay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dedenngay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dedenngay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detungay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detungay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btcancel
            // 
            this.btcancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btcancel.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcancel.Location = new System.Drawing.Point(246, 123);
            this.btcancel.Margin = new System.Windows.Forms.Padding(6);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(150, 44);
            this.btcancel.TabIndex = 3;
            this.btcancel.Text = "Hủy";
            this.btcancel.UseVisualStyleBackColor = true;
            // 
            // btok
            // 
            this.btok.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btok.Location = new System.Drawing.Point(90, 123);
            this.btok.Margin = new System.Windows.Forms.Padding(6);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(150, 44);
            this.btok.TabIndex = 2;
            this.btok.Text = "Đồng ý";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.ledv);
            this.groupControl1.Controls.Add(this.btcancel);
            this.groupControl1.Controls.Add(this.btok);
            this.groupControl1.Location = new System.Drawing.Point(282, 33);
            this.groupControl1.LookAndFeel.SkinName = "Seven Classic";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Margin = new System.Windows.Forms.Padding(6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(422, 194);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Chọn kho";
            // 
            // ledv
            // 
            this.ledv.Location = new System.Drawing.Point(90, 65);
            this.ledv.Margin = new System.Windows.Forms.Padding(6);
            this.ledv.Name = "ledv";
            this.ledv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ledv.Size = new System.Drawing.Size(306, 32);
            this.ledv.TabIndex = 10;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.dedenngay);
            this.groupControl2.Controls.Add(this.detungay);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(24, 248);
            this.groupControl2.LookAndFeel.SkinName = "Seven Classic";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Margin = new System.Windows.Forms.Padding(6);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(680, 162);
            this.groupControl2.TabIndex = 11;
            this.groupControl2.Text = "Chọn ngày";
            // 
            // dedenngay
            // 
            this.dedenngay.EditValue = null;
            this.dedenngay.Location = new System.Drawing.Point(360, 94);
            this.dedenngay.Margin = new System.Windows.Forms.Padding(6);
            this.dedenngay.Name = "dedenngay";
            this.dedenngay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dedenngay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dedenngay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dedenngay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dedenngay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dedenngay.Size = new System.Drawing.Size(306, 32);
            this.dedenngay.TabIndex = 14;
            // 
            // detungay
            // 
            this.detungay.EditValue = null;
            this.detungay.Location = new System.Drawing.Point(36, 94);
            this.detungay.Margin = new System.Windows.Forms.Padding(6);
            this.detungay.Name = "detungay";
            this.detungay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.detungay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.detungay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.detungay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.detungay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.detungay.Size = new System.Drawing.Size(308, 32);
            this.detungay.TabIndex = 13;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(364, 58);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(97, 25);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Đến ngày:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 58);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 25);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Từ ngày:";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::HAMACO.Properties.Resources.kfm_home_altbig;
            this.pictureEdit1.Location = new System.Drawing.Point(22, -6);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(246, 252);
            this.pictureEdit1.TabIndex = 9;
            // 
            // Frm_chonkho
            // 
            this.AcceptButton = this.btok;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btcancel;
            this.ClientSize = new System.Drawing.Size(724, 425);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Frm_chonkho";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn kho";
            this.Load += new System.EventHandler(this.Frm_chonkho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ledv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dedenngay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dedenngay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detungay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detungay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btcancel;
        private System.Windows.Forms.Button btok;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit ledv;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dedenngay;
        private DevExpress.XtraEditors.DateEdit detungay;
    }
}