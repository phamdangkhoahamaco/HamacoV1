namespace HAMACO
{
    partial class Frm_BaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BaoCao));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtYear = new DevExpress.XtraEditors.TextEdit();
            this.txtMonth = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.ledv = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lvpq = new DevExpress.XtraGrid.GridControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelaa = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountNumber = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.btnActivate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnContent = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledv.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).BeginInit();
            this.labelaa.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelControl4);
            this.groupBox2.Controls.Add(this.txtYear);
            this.groupBox2.Controls.Add(this.txtMonth);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(693, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 31);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 11);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 133;
            this.labelControl4.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.EditValue = "";
            this.txtYear.Location = new System.Drawing.Point(33, 8);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(45, 20);
            this.txtYear.TabIndex = 134;
            // 
            // txtMonth
            // 
            this.txtMonth.EditValue = "";
            this.txtMonth.Location = new System.Drawing.Point(136, 8);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(45, 20);
            this.txtMonth.TabIndex = 136;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(100, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 135;
            this.labelControl3.Text = "Month";
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(4, 11);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 13);
            this.labelControl6.TabIndex = 140;
            this.labelControl6.Text = "Chi nhánh/đơn vị";
            // 
            // ledv
            // 
            this.ledv.Location = new System.Drawing.Point(91, 8);
            this.ledv.Name = "ledv";
            this.ledv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ledv.Properties.NullText = "";
            this.ledv.Properties.PopupView = this.gridView3;
            this.ledv.Size = new System.Drawing.Size(258, 20);
            this.ledv.TabIndex = 141;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.ledv);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(9, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 31);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(38, 687);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(1207, 21);
            this.txtSQL.TabIndex = 151;
            this.txtSQL.Text = "txtSQL";
            // 
            // view
            // 
            this.view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view.Appearance.HeaderPanel.Options.UseFont = true;
            this.view.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.view.GridControl = this.lvpq;
            this.view.Name = "view";
            this.view.OptionsMenu.EnableFooterMenu = false;
            this.view.OptionsView.ShowAutoFilterRow = true;
            this.view.OptionsView.ShowFooter = true;
            this.view.OptionsView.ShowGroupPanel = false;
            this.view.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.view_RowCellStyle);
            this.view.DoubleClick += new System.EventHandler(this.view_DoubleClick);
            // 
            // lvpq
            // 
            this.lvpq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvpq.Location = new System.Drawing.Point(0, 80);
            this.lvpq.MainView = this.view;
            this.lvpq.Name = "lvpq";
            this.lvpq.Size = new System.Drawing.Size(1376, 676);
            this.lvpq.TabIndex = 147;
            this.lvpq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            this.lvpq.Click += new System.EventHandler(this.lvpq_Click);
            // 
            // labelaa
            // 
            this.labelaa.Controls.Add(this.groupBox3);
            this.labelaa.Controls.Add(this.btnExcel);
            this.labelaa.Controls.Add(this.btnCopy);
            this.labelaa.Controls.Add(this.btnDisplay);
            this.labelaa.Controls.Add(this.groupBox2);
            this.labelaa.Controls.Add(this.btnActivate);
            this.labelaa.Controls.Add(this.groupBox1);
            this.labelaa.Controls.Add(this.btnDelete);
            this.labelaa.Controls.Add(this.btnContent);
            this.labelaa.Controls.Add(this.btnEdit);
            this.labelaa.Controls.Add(this.btnNew);
            this.labelaa.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelaa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelaa.Location = new System.Drawing.Point(0, 0);
            this.labelaa.Name = "labelaa";
            this.labelaa.Size = new System.Drawing.Size(1376, 80);
            this.labelaa.TabIndex = 146;
            this.labelaa.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelControl1);
            this.groupBox3.Controls.Add(this.txtAccountNumber);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(381, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(306, 31);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 140;
            this.labelControl1.Text = "Account";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(93, 8);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAccountNumber.Properties.NullText = "";
            this.txtAccountNumber.Properties.PopupView = this.gridView1;
            this.txtAccountNumber.Size = new System.Drawing.Size(207, 20);
            this.txtAccountNumber.TabIndex = 141;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnExcel
            // 
            this.btnExcel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.Image")));
            this.btnExcel.Location = new System.Drawing.Point(582, 12);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(86, 20);
            this.btnExcel.TabIndex = 58;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.ImageOptions.Image")));
            this.btnCopy.Location = new System.Drawing.Point(502, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(74, 20);
            this.btnCopy.TabIndex = 58;
            this.btnCopy.Text = "Sao chép";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDisplay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplay.ImageOptions.Image")));
            this.btnDisplay.Location = new System.Drawing.Point(262, 11);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(74, 20);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "Chi tiết";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnActivate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActivate.ImageOptions.Image")));
            this.btnActivate.Location = new System.Drawing.Point(342, 11);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(74, 20);
            this.btnActivate.TabIndex = 57;
            this.btnActivate.Text = "Duyệt";
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(182, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(74, 20);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "Xóa";
            // 
            // btnContent
            // 
            this.btnContent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnContent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnContent.ImageOptions.Image")));
            this.btnContent.Location = new System.Drawing.Point(422, 11);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(74, 20);
            this.btnContent.TabIndex = 55;
            this.btnContent.Text = "Tải lại";
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(89, 11);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 20);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Chỉnh sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(9, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(74, 20);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Thêm mới";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(842, 656);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 13);
            this.lblStatus.TabIndex = 145;
            this.lblStatus.Text = "lblStatus";
            // 
            // Frm_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 756);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.lvpq);
            this.Controls.Add(this.labelaa);
            this.Controls.Add(this.lblStatus);
            this.Name = "Frm_BaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_BaoCao";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_BaoCao_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledv.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).EndInit();
            this.labelaa.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtYear;
        private DevExpress.XtraEditors.TextEdit txtMonth;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SearchLookUpEdit ledv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSQL;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraGrid.GridControl lvpq;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel labelaa;
        private DevExpress.XtraEditors.SimpleButton btnActivate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnContent;
        private DevExpress.XtraEditors.SimpleButton btnDisplay;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SearchLookUpEdit txtAccountNumber;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
    }
}