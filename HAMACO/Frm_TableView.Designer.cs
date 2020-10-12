namespace HAMACO
{
    partial class Frm_TableView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TableView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContent = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.txtSQL = new DevExpress.XtraEditors.TextEdit();
            this.lblStatus = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lvpq = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtTableName = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblSum = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnContent);
            this.panel1.Controls.Add(this.btnDisplay);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 46);
            this.panel1.TabIndex = 96;
            // 
            // btnContent
            // 
            this.btnContent.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnContent.Appearance.Options.UseForeColor = true;
            this.btnContent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnContent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnContent.ImageOptions.Image")));
            this.btnContent.Location = new System.Drawing.Point(47, 13);
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
            this.btnDisplay.Location = new System.Drawing.Point(6, 14);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(23, 20);
            this.btnDisplay.TabIndex = 2;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(12, 573);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(1299, 20);
            this.txtSQL.TabIndex = 94;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(459, 652);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 13);
            this.lblStatus.TabIndex = 93;
            this.lblStatus.Text = "lblStatus";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 93);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 95;
            this.labelControl1.Text = "Table Name";
            // 
            // lvpq
            // 
            this.lvpq.Location = new System.Drawing.Point(12, 147);
            this.lvpq.MainView = this.view;
            this.lvpq.Name = "lvpq";
            this.lvpq.Size = new System.Drawing.Size(1235, 410);
            this.lvpq.TabIndex = 97;
            this.lvpq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.GridControl = this.lvpq;
            this.view.Name = "view";
            this.view.OptionsView.ShowGroupPanel = false;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(75, 89);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTableName.Properties.PopupView = this.searchLookUpEdit1View;
            this.txtTableName.Size = new System.Drawing.Size(171, 20);
            this.txtTableName.TabIndex = 98;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lblSum
            // 
            this.lblSum.AutoSize = true;
            this.lblSum.Location = new System.Drawing.Point(15, 122);
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(37, 13);
            this.lblSum.TabIndex = 99;
            this.lblSum.Text = "lblSum";
            // 
            // Frm_TableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 775);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lvpq);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.lblSum);
            this.Name = "Frm_TableView";
            this.Text = "Frm_TableView";
            this.Load += new System.EventHandler(this.Frm_TableView_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSQL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTableName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnContent;
        private DevExpress.XtraEditors.SimpleButton btnDisplay;
        private DevExpress.XtraEditors.TextEdit txtSQL;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraGrid.GridControl lvpq;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraEditors.SearchLookUpEdit txtTableName;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private System.Windows.Forms.Label lblSum;
    }
}