namespace HAMACO
{
    partial class Frm_TableView_Display
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_TableView_Display));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnContent = new DevExpress.XtraEditors.SimpleButton();
            this.btnDisplay = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1470, 46);
            this.panel1.TabIndex = 94;
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(18, 596);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(1464, 21);
            this.txtSQL.TabIndex = 93;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(13, 75);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 25);
            this.lblStatus.TabIndex = 92;
            this.lblStatus.Text = "lblStatus";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(449, 88);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1041, 489);
            this.gridControl1.TabIndex = 95;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            // 
            // Frm_TableView_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 723);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gridControl1);
            this.Name = "Frm_TableView_Display";
            this.Text = "Frm_TableView_Display";
            this.Load += new System.EventHandler(this.Frm_TableView_Display_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnContent;
        private DevExpress.XtraEditors.SimpleButton btnDisplay;
        private System.Windows.Forms.TextBox txtSQL;
        private System.Windows.Forms.Label lblStatus;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}