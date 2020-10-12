namespace HAMACO
{
    partial class Frm_RolePermissionMapping
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
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblRole = new DevExpress.XtraEditors.LabelControl();
            this.txtTransactionCode = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.btnAddTransaction = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtRoleCode = new DevExpress.XtraEditors.TextEdit();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblRoleName = new DevExpress.XtraEditors.LabelControl();
            this.lblTransactionName = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPermission = new System.Windows.Forms.ComboBox();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(73, 525);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(636, 21);
            this.txtSQL.TabIndex = 38;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(32, 144);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(733, 206);
            this.gridControl1.TabIndex = 36;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(264, 67);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(0, 13);
            this.lblRole.TabIndex = 34;
            // 
            // txtTransactionCode
            // 
            this.txtTransactionCode.Location = new System.Drawing.Point(121, 60);
            this.txtTransactionCode.Name = "txtTransactionCode";
            this.txtTransactionCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTransactionCode.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtTransactionCode.Size = new System.Drawing.Size(153, 20);
            this.txtTransactionCode.TabIndex = 33;
            this.txtTransactionCode.EditValueChanged += new System.EventHandler(this.txtTransactionCode_EditValueChanged);
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.Location = new System.Drawing.Point(32, 370);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(124, 23);
            this.btnAddTransaction.TabIndex = 31;
            this.btnAddTransaction.Text = "Add new transaction";
            this.btnAddTransaction.Click += new System.EventHandler(this.btnAddTransaction_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 125);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(111, 13);
            this.labelControl2.TabIndex = 30;
            this.labelControl2.Text = "RolePermissionMapping";
            // 
            // txtRoleCode
            // 
            this.txtRoleCode.Enabled = false;
            this.txtRoleCode.Location = new System.Drawing.Point(121, 22);
            this.txtRoleCode.Name = "txtRoleCode";
            this.txtRoleCode.Size = new System.Drawing.Size(153, 20);
            this.txtRoleCode.TabIndex = 29;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(1103, 576);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(147, 13);
            this.lblStatus.TabIndex = 28;
            this.lblStatus.Text = "Client: 300; Transaction: SU02";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(49, 13);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Role Code";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 64);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 13);
            this.labelControl3.TabIndex = 32;
            this.labelControl3.Text = "Transaction Code";
            // 
            // lblRoleName
            // 
            this.lblRoleName.Location = new System.Drawing.Point(280, 25);
            this.lblRoleName.Name = "lblRoleName";
            this.lblRoleName.Size = new System.Drawing.Size(51, 13);
            this.lblRoleName.TabIndex = 39;
            this.lblRoleName.Text = "Role Name";
            // 
            // lblTransactionName
            // 
            this.lblTransactionName.Location = new System.Drawing.Point(281, 62);
            this.lblTransactionName.Name = "lblTransactionName";
            this.lblTransactionName.Size = new System.Drawing.Size(0, 13);
            this.lblTransactionName.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Permission";
            // 
            // txtPermission
            // 
            this.txtPermission.FormattingEnabled = true;
            this.txtPermission.Location = new System.Drawing.Point(121, 94);
            this.txtPermission.Name = "txtPermission";
            this.txtPermission.Size = new System.Drawing.Size(153, 21);
            this.txtPermission.TabIndex = 42;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(175, 370);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(156, 23);
            this.btnDelete.TabIndex = 43;
            this.btnDelete.Text = "delete Transaction";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Frm_RolePermissionMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 593);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtPermission);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTransactionName);
            this.Controls.Add(this.lblRoleName);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtTransactionCode);
            this.Controls.Add(this.btnAddTransaction);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtRoleCode);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Name = "Frm_RolePermissionMapping";
            this.Text = "Frm_RolePermissionMapping";
            this.Load += new System.EventHandler(this.Frm_RolePermissionMapping_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTransactionCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoleCode.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSQL;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl lblRole;
        private DevExpress.XtraEditors.SearchLookUpEdit txtTransactionCode;
        private DevExpress.XtraEditors.SimpleButton btnAddTransaction;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtRoleCode;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblRoleName;
        private DevExpress.XtraEditors.LabelControl lblTransactionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtPermission;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}