namespace HAMACO
{
    partial class Frm_Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Users));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnContent = new DevExpress.XtraEditors.SimpleButton();
            this.btnChangePW = new DevExpress.XtraEditors.SimpleButton();
            this.btnLock = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblUsername = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 83);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "User";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.btnContent);
            this.panel1.Controls.Add(this.btnChangePW);
            this.panel1.Controls.Add(this.btnLock);
            this.panel1.Controls.Add(this.btnCopy);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1235, 46);
            this.panel1.TabIndex = 3;
            // 
            // btnContent
            // 
            this.btnContent.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnContent.Appearance.Options.UseForeColor = true;
            this.btnContent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnContent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnContent.ImageOptions.Image")));
            this.btnContent.Location = new System.Drawing.Point(78, 12);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(23, 20);
            this.btnContent.TabIndex = 56;
            this.btnContent.Text = "Content";
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // btnChangePW
            // 
            this.btnChangePW.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnChangePW.Appearance.Options.UseForeColor = true;
            this.btnChangePW.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnChangePW.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePW.ImageOptions.Image")));
            this.btnChangePW.Location = new System.Drawing.Point(216, 12);
            this.btnChangePW.Name = "btnChangePW";
            this.btnChangePW.Size = new System.Drawing.Size(23, 20);
            this.btnChangePW.TabIndex = 5;
            this.btnChangePW.Click += new System.EventHandler(this.btnChangePW_Click);
            // 
            // btnLock
            // 
            this.btnLock.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLock.Appearance.Options.UseForeColor = true;
            this.btnLock.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnLock.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLock.ImageOptions.Image")));
            this.btnLock.Location = new System.Drawing.Point(170, 12);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(23, 20);
            this.btnLock.TabIndex = 4;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCopy.Appearance.Options.UseForeColor = true;
            this.btnCopy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCopy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.ImageOptions.Image")));
            this.btnCopy.Location = new System.Drawing.Point(130, 11);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 20);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
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
            this.btnNew.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(934, 572);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(147, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Client: 300; Transaction: SU01";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(231, 83);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(35, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "label1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(3, 130);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1235, 415);
            this.gridControl1.TabIndex = 118;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(3, 551);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(1207, 21);
            this.txtSQL.TabIndex = 119;
            this.txtSQL.Text = "txtSQL";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(53, 80);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(153, 20);
            this.txtUser.TabIndex = 120;
            this.txtUser.EditValueChanged += new System.EventHandler(this.txtUser_EditValueChanged_1);
            // 
            // Frm_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 597);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtSQL);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelControl1);
            this.Name = "Frm_Users";
            this.ShowIcon = false;
            this.Text = "Users Maintenance";
            this.Load += new System.EventHandler(this.Frm_Users_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.SimpleButton btnLock;
        private DevExpress.XtraEditors.SimpleButton btnChangePW;
        private System.Windows.Forms.Label lblUsername;
        private DevExpress.XtraEditors.SimpleButton btnContent;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox txtSQL;
        private DevExpress.XtraEditors.TextEdit txtUser;
    }
}