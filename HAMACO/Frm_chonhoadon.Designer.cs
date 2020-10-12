namespace HAMACO
{
    partial class Frm_chonhoadon
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dehd = new DevExpress.XtraEditors.DateEdit();
            this.back = new DevExpress.XtraEditors.SimpleButton();
            this.next = new DevExpress.XtraEditors.SimpleButton();
            this.cancel = new DevExpress.XtraEditors.SimpleButton();
            this.ok = new DevExpress.XtraEditors.SimpleButton();
            this.lvpq = new DevExpress.XtraGrid.GridControl();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dehd.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dehd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.dehd);
            this.panelControl1.Controls.Add(this.back);
            this.panelControl1.Controls.Add(this.next);
            this.panelControl1.Controls.Add(this.cancel);
            this.panelControl1.Controls.Add(this.ok);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 863);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1355, 84);
            this.panelControl1.TabIndex = 5;
            // 
            // dehd
            // 
            this.dehd.EditValue = null;
            this.dehd.Location = new System.Drawing.Point(84, 17);
            this.dehd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dehd.Name = "dehd";
            this.dehd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dehd.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dehd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dehd.Properties.Mask.EditMask = "MM/yyyy";
            this.dehd.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dehd.Size = new System.Drawing.Size(276, 32);
            this.dehd.TabIndex = 9;
            this.dehd.EditValueChanged += new System.EventHandler(this.dehd_EditValueChanged);
            // 
            // back
            // 
            this.back.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::HAMACO.Properties.Resources._1354680452_back;
            this.back.Location = new System.Drawing.Point(4, 17);
            this.back.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(50, 38);
            this.back.TabIndex = 8;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // next
            // 
            this.next.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.Image = global::HAMACO.Properties.Resources._1354680452_come;
            this.next.Location = new System.Drawing.Point(358, 17);
            this.next.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(56, 38);
            this.next.TabIndex = 7;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // cancel
            // 
            this.cancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(1105, 13);
            this.cancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(202, 44);
            this.cancel.TabIndex = 6;
            this.cancel.Text = "Hủy";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ok
            // 
            this.ok.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.ok.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ok.Location = new System.Drawing.Point(891, 13);
            this.ok.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(202, 44);
            this.ok.TabIndex = 5;
            this.ok.Text = "Đồng ý";
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // lvpq
            // 
            this.lvpq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvpq.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvpq.Location = new System.Drawing.Point(0, 0);
            this.lvpq.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lvpq.MainView = this.view;
            this.lvpq.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lvpq.Name = "lvpq";
            this.lvpq.Size = new System.Drawing.Size(1355, 863);
            this.lvpq.TabIndex = 9;
            this.lvpq.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.view.Appearance.FooterPanel.Options.UseFont = true;
            this.view.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.view.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view.Appearance.GroupFooter.Options.UseFont = true;
            this.view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.view.Appearance.HeaderPanel.Options.UseFont = true;
            this.view.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.view.Appearance.ViewCaption.Options.UseFont = true;
            this.view.Appearance.ViewCaption.Options.UseTextOptions = true;
            this.view.Appearance.ViewCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.view.GridControl = this.lvpq;
            this.view.Name = "view";
            this.view.OptionsView.ShowFooter = true;
            this.view.OptionsView.ShowGroupPanel = false;
            this.view.ViewCaptionHeight = 20;
            this.view.DoubleClick += new System.EventHandler(this.view_DoubleClick);
            // 
            // Frm_chonhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(1355, 947);
            this.Controls.Add(this.lvpq);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Frm_chonhoadon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn hóa đơn";
            this.Load += new System.EventHandler(this.Frm_chonhoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dehd.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dehd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lvpq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton back;
        private DevExpress.XtraEditors.SimpleButton next;
        private DevExpress.XtraEditors.SimpleButton cancel;
        private DevExpress.XtraEditors.SimpleButton ok;
        private DevExpress.XtraGrid.GridControl lvpq;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraEditors.DateEdit dehd;

    }
}