namespace HAMACO
{
    partial class Frm_branch
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtsave = new System.Windows.Forms.ToolStripButton();
            this.tstbcancel = new System.Windows.Forms.ToolStripButton();
            this.xtraTabControl2 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttthue = new DevExpress.XtraEditors.TextEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.leprovince = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.lekho = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.ledv = new DevExpress.XtraEditors.LookUpEdit();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtdg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmst = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.DAT = new DevExpress.XtraGrid.GridControl();
            this.ViewDAT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSQL = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).BeginInit();
            this.xtraTabControl2.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttthue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leprovince.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lekho.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledv.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DAT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDAT)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtsave,
            this.tstbcancel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(453, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsbtsave
            // 
            this.tsbtsave.Image = global::HAMACO.Properties.Resources.Save;
            this.tsbtsave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtsave.Name = "tsbtsave";
            this.tsbtsave.Size = new System.Drawing.Size(94, 37);
            this.tsbtsave.Text = "   Cất và Đóng   ";
            this.tsbtsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtsave.Click += new System.EventHandler(this.tsbtsave_Click);
            // 
            // tstbcancel
            // 
            this.tstbcancel.Image = global::HAMACO.Properties.Resources._1354680452_back;
            this.tstbcancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstbcancel.Name = "tstbcancel";
            this.tstbcancel.Size = new System.Drawing.Size(51, 37);
            this.tstbcancel.Text = "   Hủy   ";
            this.tstbcancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tstbcancel.Click += new System.EventHandler(this.tstbcancel_Click);
            // 
            // xtraTabControl2
            // 
            this.xtraTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl2.Location = new System.Drawing.Point(0, 40);
            this.xtraTabControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraTabControl2.Name = "xtraTabControl2";
            this.xtraTabControl2.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl2.Size = new System.Drawing.Size(453, 331);
            this.xtraTabControl2.TabIndex = 30;
            this.xtraTabControl2.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            this.xtraTabControl2.TabStop = false;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupBox1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(447, 303);
            this.xtraTabPage1.Text = "Thông tin chung";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSQL);
            this.groupBox1.Controls.Add(this.txttthue);
            this.groupBox1.Controls.Add(this.labelControl16);
            this.groupBox1.Controls.Add(this.leprovince);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lekho);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ledv);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txtdg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtmst);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 303);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txttthue
            // 
            this.txttthue.Location = new System.Drawing.Point(84, 223);
            this.txttthue.Name = "txttthue";
            this.txttthue.Properties.AllowMouseWheel = false;
            this.txttthue.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttthue.Properties.Appearance.Options.UseFont = true;
            this.txttthue.Properties.DisplayFormat.FormatString = "n0";
            this.txttthue.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txttthue.Properties.EditFormat.FormatString = "n0";
            this.txttthue.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txttthue.Properties.Mask.EditMask = "n0";
            this.txttthue.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txttthue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txttthue.Size = new System.Drawing.Size(178, 20);
            this.txttthue.TabIndex = 82;
            this.txttthue.TabStop = false;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(18, 221);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Padding = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.labelControl16.Size = new System.Drawing.Size(45, 19);
            this.labelControl16.TabIndex = 81;
            this.labelControl16.Text = "Công nợ";
            // 
            // leprovince
            // 
            this.leprovince.Location = new System.Drawing.Point(84, 197);
            this.leprovince.Name = "leprovince";
            this.leprovince.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leprovince.Properties.NullText = "[Chọn để thay đổi]";
            this.leprovince.Size = new System.Drawing.Size(178, 20);
            this.leprovince.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tỉnh thành";
            // 
            // lekho
            // 
            this.lekho.Location = new System.Drawing.Point(84, 171);
            this.lekho.Name = "lekho";
            this.lekho.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lekho.Properties.NullText = "[Chọn để thay đổi]";
            this.lekho.Size = new System.Drawing.Size(177, 20);
            this.lekho.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kho ";
            // 
            // ledv
            // 
            this.ledv.Location = new System.Drawing.Point(84, 142);
            this.ledv.Name = "ledv";
            this.ledv.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ledv.Properties.NullText = "[Chọn để thay đổi]";
            this.ledv.Size = new System.Drawing.Size(177, 20);
            this.ledv.TabIndex = 6;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(290, 118);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(111, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Hạch toán độc lập";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(290, 143);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(125, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Hạch toán phụ thuộc";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtdg
            // 
            this.txtdg.Location = new System.Drawing.Point(84, 69);
            this.txtdg.Multiline = true;
            this.txtdg.Name = "txtdg";
            this.txtdg.Size = new System.Drawing.Size(328, 64);
            this.txtdg.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Đơn vị";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Địa chỉ";
            // 
            // txtmst
            // 
            this.txtmst.Location = new System.Drawing.Point(84, 115);
            this.txtmst.Name = "txtmst";
            this.txtmst.Size = new System.Drawing.Size(179, 21);
            this.txtmst.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã số thuế";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(84, 43);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(328, 21);
            this.txtname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên (*)";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(84, 17);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(177, 21);
            this.txtcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã (*)";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.DAT);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(437, 277);
            this.xtraTabPage2.Text = "Hạn mức tồn kho";
            // 
            // DAT
            // 
            this.DAT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DAT.Location = new System.Drawing.Point(0, 0);
            this.DAT.LookAndFeel.UseDefaultLookAndFeel = false;
            this.DAT.MainView = this.ViewDAT;
            this.DAT.Name = "DAT";
            this.DAT.Size = new System.Drawing.Size(437, 277);
            this.DAT.TabIndex = 4;
            this.DAT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.ViewDAT});
            // 
            // ViewDAT
            // 
            this.ViewDAT.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewDAT.Appearance.HeaderPanel.Options.UseFont = true;
            this.ViewDAT.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.ViewDAT.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ViewDAT.DetailHeight = 182;
            this.ViewDAT.FixedLineWidth = 1;
            this.ViewDAT.GridControl = this.DAT;
            this.ViewDAT.LevelIndent = 0;
            this.ViewDAT.Name = "ViewDAT";
            this.ViewDAT.OptionsView.ShowGroupPanel = false;
            this.ViewDAT.PreviewIndent = 0;
            // 
            // txtSQL
            // 
            this.txtSQL.Location = new System.Drawing.Point(21, 267);
            this.txtSQL.Name = "txtSQL";
            this.txtSQL.Size = new System.Drawing.Size(419, 21);
            this.txtSQL.TabIndex = 83;
            // 
            // Frm_branch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 371);
            this.Controls.Add(this.xtraTabControl2);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_branch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_branch";
            this.Load += new System.EventHandler(this.Frm_branch_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl2)).EndInit();
            this.xtraTabControl2.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txttthue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leprovince.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lekho.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledv.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DAT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ViewDAT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtsave;
        private System.Windows.Forms.ToolStripButton tstbcancel;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LookUpEdit leprovince;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit lekho;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit ledv;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtdg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmst;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraGrid.GridControl DAT;
        private DevExpress.XtraGrid.Views.Grid.GridView ViewDAT;
        private DevExpress.XtraEditors.TextEdit txttthue;
        private System.Windows.Forms.TextBox txtSQL;
    }
}