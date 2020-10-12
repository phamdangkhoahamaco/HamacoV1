namespace HAMACO
{
    partial class Frm_choicerole
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
            this.lvpq = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btcancel
            // 
            this.btcancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btcancel.Location = new System.Drawing.Point(512, 7);
            this.btcancel.Name = "btcancel";
            this.btcancel.Size = new System.Drawing.Size(82, 25);
            this.btcancel.TabIndex = 1;
            this.btcancel.Text = "Hủy";
            this.btcancel.UseVisualStyleBackColor = true;
            this.btcancel.Click += new System.EventHandler(this.btcancel_Click);
            // 
            // lvpq
            // 
            this.lvpq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvpq.Location = new System.Drawing.Point(0, 0);
            this.lvpq.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lvpq.MainView = this.view;
            this.lvpq.Name = "lvpq";
            this.lvpq.Size = new System.Drawing.Size(605, 334);
            this.lvpq.TabIndex = 4;
            this.lvpq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.view.Appearance.FooterPanel.Options.UseFont = true;
            this.view.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.view.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.view.Appearance.HeaderPanel.Options.UseFont = true;
            this.view.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view.GridControl = this.lvpq;
            this.view.Name = "view";
            this.view.OptionsView.ShowFooter = true;
            this.view.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btcancel);
            this.panel1.Controls.Add(this.btok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 36);
            this.panel1.TabIndex = 3;
            // 
            // btok
            // 
            this.btok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btok.Location = new System.Drawing.Point(418, 7);
            this.btok.Name = "btok";
            this.btok.Size = new System.Drawing.Size(88, 25);
            this.btok.TabIndex = 0;
            this.btok.Text = "Đồng ý";
            this.btok.UseVisualStyleBackColor = true;
            this.btok.Click += new System.EventHandler(this.btok_Click);
            // 
            // Frm_choicerole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 370);
            this.Controls.Add(this.lvpq);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_choicerole";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_choicerole";
            this.Load += new System.EventHandler(this.Frm_choicerole_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btcancel;
        private DevExpress.XtraGrid.GridControl lvpq;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btok;
    }
}