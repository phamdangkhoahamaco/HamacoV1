namespace HAMACO
{
    partial class Frm_Demo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Demo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExecute = new DevExpress.XtraEditors.SimpleButton();
            this.txtSQL = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDocType = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTypeName = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CotInventoryItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_mahang = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColInventoryItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColInventoryItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotInventoryItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotUnitPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtQuantity = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.CotQuantityConvert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mahang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(-4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1770, 46);
            this.panel1.TabIndex = 103;
            // 
            // btnExecute
            // 
            this.btnExecute.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Appearance.Options.UseForeColor = true;
            this.btnExecute.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnExecute.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExecute.ImageOptions.Image")));
            this.btnExecute.Location = new System.Drawing.Point(9, 11);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(23, 20);
            this.btnExecute.TabIndex = 0;
            this.btnExecute.Text = "Create";
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(5, 607);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(1254, 20);
            this.txtSQL.TabIndex = 107;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 151;
            this.labelControl2.Text = "Type";
            // 
            // txtDocType
            // 
            this.txtDocType.Location = new System.Drawing.Point(77, 80);
            this.txtDocType.Name = "txtDocType";
            this.txtDocType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDocType.Properties.PopupView = this.gridView2;
            this.txtDocType.Size = new System.Drawing.Size(153, 20);
            this.txtDocType.TabIndex = 152;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // lblTypeName
            // 
            this.lblTypeName.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lblTypeName.Location = new System.Drawing.Point(249, 83);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(51, 13);
            this.lblTypeName.TabIndex = 153;
            this.lblTypeName.Text = "TypeName";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 132);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_mahang,
            this.repositoryItemSearchLookUpEdit2,
            this.txtQuantity});
            this.gridControl1.Size = new System.Drawing.Size(1247, 442);
            this.gridControl1.TabIndex = 154;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CotInventoryItemCode,
            this.CotInventoryItemName,
            this.CotUnit,
            this.CotUnitPrice,
            this.CotQuantity,
            this.CotQuantityConvert,
            this.CotAmount});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // CotInventoryItemCode
            // 
            this.CotInventoryItemCode.Caption = "Ma hang";
            this.CotInventoryItemCode.ColumnEdit = this.rep_mahang;
            this.CotInventoryItemCode.FieldName = "InventoryItemCode";
            this.CotInventoryItemCode.Name = "CotInventoryItemCode";
            this.CotInventoryItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "InventoryItemCode", "Số dòng = {0}")});
            this.CotInventoryItemCode.Visible = true;
            this.CotInventoryItemCode.VisibleIndex = 0;
            this.CotInventoryItemCode.Width = 85;
            // 
            // rep_mahang
            // 
            this.rep_mahang.AutoHeight = false;
            this.rep_mahang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep_mahang.Name = "rep_mahang";
            this.rep_mahang.PopupView = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColInventoryItemCode,
            this.ColInventoryItemName});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // ColInventoryItemCode
            // 
            this.ColInventoryItemCode.Caption = "MaHH";
            this.ColInventoryItemCode.FieldName = "InventoryItemCode";
            this.ColInventoryItemCode.Name = "ColInventoryItemCode";
            this.ColInventoryItemCode.Visible = true;
            this.ColInventoryItemCode.VisibleIndex = 0;
            // 
            // ColInventoryItemName
            // 
            this.ColInventoryItemName.Caption = "Ten HH";
            this.ColInventoryItemName.FieldName = "InventoryItemName";
            this.ColInventoryItemName.Name = "ColInventoryItemName";
            this.ColInventoryItemName.Visible = true;
            this.ColInventoryItemName.VisibleIndex = 1;
            // 
            // CotInventoryItemName
            // 
            this.CotInventoryItemName.Caption = "Ten HH";
            this.CotInventoryItemName.FieldName = "InventoryItemName";
            this.CotInventoryItemName.Name = "CotInventoryItemName";
            this.CotInventoryItemName.Visible = true;
            this.CotInventoryItemName.VisibleIndex = 1;
            this.CotInventoryItemName.Width = 182;
            // 
            // CotUnit
            // 
            this.CotUnit.Caption = "DVT";
            this.CotUnit.FieldName = "Unit";
            this.CotUnit.Name = "CotUnit";
            this.CotUnit.Visible = true;
            this.CotUnit.VisibleIndex = 2;
            // 
            // CotUnitPrice
            // 
            this.CotUnitPrice.Caption = "Don gia";
            this.CotUnitPrice.DisplayFormat.FormatString = "#,#";
            this.CotUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CotUnitPrice.FieldName = "UnitPrice";
            this.CotUnitPrice.Name = "CotUnitPrice";
            this.CotUnitPrice.Visible = true;
            this.CotUnitPrice.VisibleIndex = 4;
            this.CotUnitPrice.Width = 90;
            // 
            // CotQuantity
            // 
            this.CotQuantity.Caption = "So luong";
            this.CotQuantity.ColumnEdit = this.txtQuantity;
            this.CotQuantity.FieldName = "Quantity";
            this.CotQuantity.Name = "CotQuantity";
            this.CotQuantity.Visible = true;
            this.CotQuantity.VisibleIndex = 5;
            this.CotQuantity.Width = 135;
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoHeight = false;
            this.txtQuantity.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtQuantity.Name = "txtQuantity";
            // 
            // CotQuantityConvert
            // 
            this.CotQuantityConvert.Caption = "DV quy doi";
            this.CotQuantityConvert.FieldName = "QuantityConvert";
            this.CotQuantityConvert.Name = "CotQuantityConvert";
            this.CotQuantityConvert.Visible = true;
            this.CotQuantityConvert.VisibleIndex = 3;
            this.CotQuantityConvert.Width = 83;
            // 
            // CotAmount
            // 
            this.CotAmount.Caption = "Thanh Tien";
            this.CotAmount.DisplayFormat.FormatString = "#,#";
            this.CotAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.CotAmount.FieldName = "Amount";
            this.CotAmount.Name = "CotAmount";
            this.CotAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "SUM={0:#,#}")});
            this.CotAmount.Visible = true;
            this.CotAmount.VisibleIndex = 6;
            this.CotAmount.Width = 166;
            // 
            // repositoryItemSearchLookUpEdit2
            // 
            this.repositoryItemSearchLookUpEdit2.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit2.Name = "repositoryItemSearchLookUpEdit2";
            this.repositoryItemSearchLookUpEdit2.PopupView = this.repositoryItemSearchLookUpEdit2View;
            // 
            // repositoryItemSearchLookUpEdit2View
            // 
            this.repositoryItemSearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit2View.Name = "repositoryItemSearchLookUpEdit2View";
            this.repositoryItemSearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // Frm_Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1798, 629);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtDocType);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_Demo";
            this.Text = "Frm_Demo2";
            this.Load += new System.EventHandler(this.Frm_Demo2_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_mahang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnExecute;
        private DevExpress.XtraEditors.TextEdit txtSQL;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit txtDocType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl lblTypeName;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CotInventoryItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn CotInventoryItemName;
        private DevExpress.XtraGrid.Columns.GridColumn CotUnit;
        private DevExpress.XtraGrid.Columns.GridColumn CotQuantityConvert;
        private DevExpress.XtraGrid.Columns.GridColumn CotUnitPrice;
        private DevExpress.XtraGrid.Columns.GridColumn CotQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn CotAmount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rep_mahang;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn ColInventoryItemCode;
        private DevExpress.XtraGrid.Columns.GridColumn ColInventoryItemName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit2View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtQuantity;
    }
}