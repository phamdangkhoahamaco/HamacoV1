namespace HAMACO
{
    partial class Frm_BCTK_Copy
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
            this.btn_Copy = new System.Windows.Forms.Button();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtYear = new DevExpress.XtraEditors.TextEdit();
            this.txtMonth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtYear2 = new DevExpress.XtraEditors.TextEdit();
            this.txtMonth2 = new DevExpress.XtraEditors.TextEdit();
            this.txtStockCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(29, 189);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 23);
            this.btn_Copy.TabIndex = 0;
            this.btn_Copy.Text = "Copy";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(27, 28);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 137;
            this.labelControl4.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.EditValue = "";
            this.txtYear.Location = new System.Drawing.Point(74, 26);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(45, 20);
            this.txtYear.TabIndex = 138;
            // 
            // txtMonth
            // 
            this.txtMonth.EditValue = "";
            this.txtMonth.Location = new System.Drawing.Point(191, 26);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(45, 20);
            this.txtMonth.TabIndex = 139;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(140, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 140;
            this.labelControl3.Text = "Month";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(27, -3);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 141;
            this.labelControl5.Text = "Copy From";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(27, 69);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(40, 13);
            this.labelControl6.TabIndex = 146;
            this.labelControl6.Text = "Copy To";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(140, 101);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(30, 13);
            this.labelControl7.TabIndex = 145;
            this.labelControl7.Text = "Month";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(27, 100);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(22, 13);
            this.labelControl8.TabIndex = 142;
            this.labelControl8.Text = "Year";
            // 
            // txtYear2
            // 
            this.txtYear2.EditValue = "";
            this.txtYear2.Location = new System.Drawing.Point(74, 98);
            this.txtYear2.Name = "txtYear2";
            this.txtYear2.Size = new System.Drawing.Size(45, 20);
            this.txtYear2.TabIndex = 143;
            // 
            // txtMonth2
            // 
            this.txtMonth2.EditValue = "";
            this.txtMonth2.Location = new System.Drawing.Point(191, 98);
            this.txtMonth2.Name = "txtMonth2";
            this.txtMonth2.Size = new System.Drawing.Size(45, 20);
            this.txtMonth2.TabIndex = 144;
            // 
            // txtStockCode
            // 
            this.txtStockCode.Location = new System.Drawing.Point(74, 141);
            this.txtStockCode.Name = "txtStockCode";
            this.txtStockCode.ReadOnly = true;
            this.txtStockCode.Size = new System.Drawing.Size(138, 21);
            this.txtStockCode.TabIndex = 148;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 147;
            this.label1.Text = "Mã kho";
            // 
            // Frm_BCTK_Copy
            // 
            this.ClientSize = new System.Drawing.Size(281, 247);
            this.Controls.Add(this.txtStockCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtYear2);
            this.Controls.Add(this.txtMonth2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.btn_Copy);
            this.Name = "Frm_BCTK_Copy";
            this.Text = "Copy số liệu tồn kho";
            this.Load += new System.EventHandler(this.Frm_BCTK_Copy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.TextBox txtUsernameFrom;
        private System.Windows.Forms.TextBox txtUsernameTo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btn_Copy;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtYear;
        private DevExpress.XtraEditors.TextEdit txtMonth;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtYear2;
        private DevExpress.XtraEditors.TextEdit txtMonth2;
        private System.Windows.Forms.TextBox txtStockCode;
        private System.Windows.Forms.Label label1;
    }
}