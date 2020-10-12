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
            this.lblBranchName = new DevExpress.XtraEditors.LabelControl();
            this.ledv = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lvpq = new DevExpress.XtraGrid.GridControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelaa = new System.Windows.Forms.Panel();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnActivate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnContent = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblAccountName = new DevExpress.XtraEditors.LabelControl();
            this.txtAccountNumber = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.groupBox2.Location = new System.Drawing.Point(50, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 46);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(6, 20);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 133;
            this.labelControl4.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.EditValue = "";
            this.txtYear.Location = new System.Drawing.Point(56, 17);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(45, 20);
            this.txtYear.TabIndex = 134;
            // 
            // txtMonth
            // 
            this.txtMonth.EditValue = "";
            this.txtMonth.Location = new System.Drawing.Point(173, 17);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(45, 20);
            this.txtMonth.TabIndex = 136;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(123, 20);
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
            this.labelControl6.Location = new System.Drawing.Point(56, 11);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(81, 13);
            this.labelControl6.TabIndex = 140;
            this.labelControl6.Text = "Chi nhánh/đơn vị";
            // 
            // lblBranchName
            // 
            this.lblBranchName.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lblBranchName.Location = new System.Drawing.Point(302, 11);
            this.lblBranchName.Name = "lblBranchName";
            this.lblBranchName.Size = new System.Drawing.Size(60, 13);
            this.lblBranchName.TabIndex = 142;
            this.lblBranchName.Text = "BranchName";
            // 
            // ledv
            // 
            this.ledv.Location = new System.Drawing.Point(143, 8);
            this.ledv.Name = "ledv";
            this.ledv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ledv.Properties.PopupView = this.gridView3;
            this.ledv.Size = new System.Drawing.Size(153, 20);
            this.ledv.TabIndex = 141;
            this.ledv.EditValueChanged += new System.EventHandler(this.ledv_EditValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.lblBranchName);
            this.groupBox1.Controls.Add(this.ledv);
            this.groupBox1.Location = new System.Drawing.Point(50, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 31);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer";
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
            this.view.GridControl = this.lvpq;
            this.view.Name = "view";
            this.view.OptionsMenu.EnableFooterMenu = false;
            this.view.OptionsView.ShowFooter = true;
            this.view.OptionsView.ShowGroupPanel = false;
            this.view.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.view_RowCellStyle);
            this.view.DoubleClick += new System.EventHandler(this.view_DoubleClick);
            // 
            // lvpq
            // 
            this.lvpq.Location = new System.Drawing.Point(2, 151);
            this.lvpq.MainView = this.view;
            this.lvpq.Name = "lvpq";
            this.lvpq.Size = new System.Drawing.Size(1750, 502);
            this.lvpq.TabIndex = 147;
            this.lvpq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            this.lvpq.Click += new System.EventHandler(this.lvpq_Click);
            // 
            // labelaa
            // 
            this.labelaa.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelaa.Controls.Add(this.btnCopy);
            this.labelaa.Controls.Add(this.btnActivate);
            this.labelaa.Controls.Add(this.btnDelete);
            this.labelaa.Controls.Add(this.btnContent);
            this.labelaa.Controls.Add(this.btnDisplay);
            this.labelaa.Controls.Add(this.btnEdit);
            this.labelaa.Controls.Add(this.btnNew);
            this.labelaa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelaa.Location = new System.Drawing.Point(3, 12);
            this.labelaa.Name = "labelaa";
            this.labelaa.Size = new System.Drawing.Size(1750, 46);
            this.labelaa.TabIndex = 146;
            this.labelaa.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCopy
            // 
            this.btnCopy.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Appearance.Options.UseForeColor = true;
            this.btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.ImageOptions.Image")));
            this.btnCopy.Location = new System.Drawing.Point(224, 12);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 20);
            this.btnCopy.TabIndex = 58;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnActivate.Appearance.Options.UseForeColor = true;
            this.btnActivate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnActivate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnActivate.ImageOptions.Image")));
            this.btnActivate.Location = new System.Drawing.Point(195, 11);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(23, 20);
            this.btnActivate.TabIndex = 57;
            this.btnActivate.Text = "Content";
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(157, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 20);
            this.btnDelete.TabIndex = 56;
            this.btnDelete.Text = "Content";
            // 
            // btnContent
            // 
            this.btnContent.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnContent.Appearance.Options.UseForeColor = true;
            this.btnContent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnContent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnContent.ImageOptions.Image")));
            this.btnContent.Location = new System.Drawing.Point(113, 11);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(23, 20);
            this.btnContent.TabIndex = 55;
            this.btnContent.Text = "Content";
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDisplay.Appearance.Options.UseForeColor = true;
            this.btnDisplay.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDisplay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDisplay.ImageOptions.Image")));
            this.btnDisplay.Location = new System.Drawing.Point(72, 12);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(23, 20);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Appearance.Options.UseForeColor = true;
            this.btnEdit.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.Location = new System.Drawing.Point(36, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(23, 20);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnNew.Appearance.Options.UseForeColor = true;
            this.btnNew.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.Location = new System.Drawing.Point(9, 11);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(23, 20);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Create";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelControl1);
            this.groupBox3.Controls.Add(this.lblAccountName);
            this.groupBox3.Controls.Add(this.txtAccountNumber);
            this.groupBox3.Location = new System.Drawing.Point(770, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(703, 31);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Account";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(39, 13);
            this.labelControl1.TabIndex = 140;
            this.labelControl1.Text = "Account";
            // 
            // lblAccountName
            // 
            this.lblAccountName.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lblAccountName.Location = new System.Drawing.Point(302, 11);
            this.lblAccountName.Name = "lblAccountName";
            this.lblAccountName.Size = new System.Drawing.Size(66, 13);
            this.lblAccountName.TabIndex = 142;
            this.lblAccountName.Text = "AccountName";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(143, 8);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtAccountNumber.Properties.PopupView = this.gridView1;
            this.txtAccountNumber.Size = new System.Drawing.Size(153, 20);
            this.txtAccountNumber.TabIndex = 141;
            this.txtAccountNumber.EditValueChanged += new System.EventHandler(this.txtAccountNumber_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Frm_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1783, 773);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
        private DevExpress.XtraEditors.LabelControl lblBranchName;
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
        private DevExpress.XtraEditors.LabelControl lblAccountName;
        private DevExpress.XtraEditors.SearchLookUpEdit txtAccountNumber;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}