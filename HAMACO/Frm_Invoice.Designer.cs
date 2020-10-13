namespace HAMACO
{
    partial class Frm_Invoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Invoice));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.export2 = new System.Windows.Forms.Button();
            this.deTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.deDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.CreateInvoice = new System.Windows.Forms.Button();
            this.load1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.grid1 = new DevExpress.XtraGrid.GridControl();
            this.view1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.export2);
            this.panelControl1.Controls.Add(this.deTuNgay);
            this.panelControl1.Controls.Add(this.deDenNgay);
            this.panelControl1.Controls.Add(this.CreateInvoice);
            this.panelControl1.Controls.Add(this.load1);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.label76);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1031, 49);
            this.panelControl1.TabIndex = 1;
            // 
            // export2
            // 
            this.export2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.export2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.export2.Image = ((System.Drawing.Image)(resources.GetObject("export2.Image")));
            this.export2.Location = new System.Drawing.Point(407, 10);
            this.export2.Name = "export2";
            this.export2.Size = new System.Drawing.Size(84, 25);
            this.export2.TabIndex = 152;
            this.export2.Text = "Xuất Excel";
            this.export2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.export2.UseVisualStyleBackColor = false;
            this.export2.Click += new System.EventHandler(this.export2_Click);
            // 
            // deTuNgay
            // 
            this.deTuNgay.EditValue = null;
            this.deTuNgay.Location = new System.Drawing.Point(68, 13);
            this.deTuNgay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deTuNgay.Name = "deTuNgay";
            this.deTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deTuNgay.Properties.Appearance.Options.UseFont = true;
            this.deTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deTuNgay.Size = new System.Drawing.Size(99, 20);
            this.deTuNgay.TabIndex = 150;
            // 
            // deDenNgay
            // 
            this.deDenNgay.EditValue = null;
            this.deDenNgay.Location = new System.Drawing.Point(211, 13);
            this.deDenNgay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deDenNgay.Name = "deDenNgay";
            this.deDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deDenNgay.Properties.Appearance.Options.UseFont = true;
            this.deDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.deDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.deDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.deDenNgay.Size = new System.Drawing.Size(99, 20);
            this.deDenNgay.TabIndex = 151;
            // 
            // CreateInvoice
            // 
            this.CreateInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateInvoice.Image = ((System.Drawing.Image)(resources.GetObject("CreateInvoice.Image")));
            this.CreateInvoice.Location = new System.Drawing.Point(920, 10);
            this.CreateInvoice.Name = "CreateInvoice";
            this.CreateInvoice.Size = new System.Drawing.Size(99, 25);
            this.CreateInvoice.TabIndex = 149;
            this.CreateInvoice.Text = "Lập hóa đơn";
            this.CreateInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CreateInvoice.UseVisualStyleBackColor = false;
            this.CreateInvoice.Click += new System.EventHandler(this.CreateInvoice_Click);
            // 
            // load1
            // 
            this.load1.Image = ((System.Drawing.Image)(resources.GetObject("load1.Image")));
            this.load1.Location = new System.Drawing.Point(317, 10);
            this.load1.Name = "load1";
            this.load1.Size = new System.Drawing.Size(84, 25);
            this.load1.TabIndex = 149;
            this.load1.Text = "Tải dữ liệu";
            this.load1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.load1.UseVisualStyleBackColor = false;
            this.load1.Click += new System.EventHandler(this.load1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 147;
            this.label1.Text = "Đến";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.Location = new System.Drawing.Point(8, 16);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(53, 13);
            this.label76.TabIndex = 148;
            this.label76.Text = "Từ ngày";
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.Location = new System.Drawing.Point(0, 49);
            this.grid1.MainView = this.view1;
            this.grid1.Margin = new System.Windows.Forms.Padding(0);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(1031, 539);
            this.grid1.TabIndex = 19;
            this.grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view1});
            // 
            // view1
            // 
            this.view1.Appearance.GroupRow.Font = new System.Drawing.Font("Verdana", 8F);
            this.view1.Appearance.GroupRow.Options.UseFont = true;
            this.view1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.view1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.view1.Appearance.HeaderPanel.Options.UseFont = true;
            this.view1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.view1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.view1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.view1.Appearance.Row.Font = new System.Drawing.Font("Verdana", 8F);
            this.view1.Appearance.Row.Options.UseFont = true;
            this.view1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.view1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.view1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn14});
            this.view1.GridControl = this.grid1;
            this.view1.Name = "view1";
            this.view1.OptionsBehavior.ReadOnly = true;
            this.view1.OptionsView.ColumnAutoWidth = false;
            this.view1.OptionsView.ShowAutoFilterRow = true;
            this.view1.OptionsView.ShowGroupPanel = false;
            this.view1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn10, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Ngày";
            this.gridColumn10.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn10.FieldName = "RefDate";
            this.gridColumn10.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 84;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Đơn vị";
            this.gridColumn11.FieldName = "AccountingObjectName";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 294;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "MST";
            this.gridColumn12.FieldName = "CompanyTaxCode";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 3;
            this.gridColumn12.Width = 111;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Số";
            this.gridColumn13.FieldName = "MMDoc";
            this.gridColumn13.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 1;
            this.gridColumn13.Width = 173;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Địa chỉ";
            this.gridColumn1.FieldName = "AccountingObjectAddress";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 4;
            this.gridColumn1.Width = 159;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Điện thoại";
            this.gridColumn2.FieldName = "Dienthoai";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            this.gridColumn2.Width = 110;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Email";
            this.gridColumn3.FieldName = "ContactEmail";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 106;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "STK";
            this.gridColumn4.FieldName = "BankAccount";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 106;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ngân hàng";
            this.gridColumn5.FieldName = "BankName";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 8;
            this.gridColumn5.Width = 112;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Hình thức";
            this.gridColumn6.FieldName = "PayNo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            this.gridColumn6.Width = 74;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tiền tệ";
            this.gridColumn7.FieldName = "Tiente";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 88;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Ghi chú";
            this.gridColumn8.FieldName = "MMHeader";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 11;
            this.gridColumn8.Width = 211;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gridColumn9.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn9.Caption = "Tổng tiền (VAT)";
            this.gridColumn9.DisplayFormat.FormatString = "n0";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "TotalAmount";
            this.gridColumn9.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 12;
            this.gridColumn9.Width = 116;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "gridColumn14";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // Frm_Invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 588);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_Invoice";
            this.Text = "Frm_Invoice";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button export2;
        private DevExpress.XtraEditors.DateEdit deTuNgay;
        private DevExpress.XtraEditors.DateEdit deDenNgay;
        public System.Windows.Forms.Button CreateInvoice;
        public System.Windows.Forms.Button load1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label76;
        private DevExpress.XtraGrid.GridControl grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView view1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}