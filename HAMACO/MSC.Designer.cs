namespace HAMACO
{
    partial class MSC
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
            this.crollall = new System.Windows.Forms.Button();
            this.checkall = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvmsc = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exall = new System.Windows.Forms.Button();
            this.uncheckall = new System.Windows.Forms.Button();
            this.lvmsc = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.huy = new System.Windows.Forms.Button();
            this.luu = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // crollall
            // 
            this.crollall.BackColor = System.Drawing.SystemColors.Control;
            this.crollall.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.crollall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.crollall.Location = new System.Drawing.Point(124, 7);
            this.crollall.Name = "crollall";
            this.crollall.Size = new System.Drawing.Size(118, 25);
            this.crollall.TabIndex = 1;
            this.crollall.Text = "Đóng tất cả";
            this.crollall.UseVisualStyleBackColor = false;
            this.crollall.Click += new System.EventHandler(this.crollall_Click);
            // 
            // checkall
            // 
            this.checkall.BackColor = System.Drawing.SystemColors.Control;
            this.checkall.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.checkall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkall.Location = new System.Drawing.Point(1, 7);
            this.checkall.Name = "checkall";
            this.checkall.Size = new System.Drawing.Size(87, 25);
            this.checkall.TabIndex = 2;
            this.checkall.Text = "Chọn tất cả";
            this.checkall.UseVisualStyleBackColor = false;
            this.checkall.Click += new System.EventHandler(this.checkall_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvmsc);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(667, 503);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // tvmsc
            // 
            this.tvmsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvmsc.Location = new System.Drawing.Point(5, 19);
            this.tvmsc.Name = "tvmsc";
            this.tvmsc.Size = new System.Drawing.Size(657, 441);
            this.tvmsc.TabIndex = 1;
            this.tvmsc.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvmsc_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.crollall);
            this.panel2.Controls.Add(this.exall);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(5, 460);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 38);
            this.panel2.TabIndex = 0;
            // 
            // exall
            // 
            this.exall.BackColor = System.Drawing.SystemColors.Control;
            this.exall.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.exall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exall.Location = new System.Drawing.Point(0, 7);
            this.exall.Name = "exall";
            this.exall.Size = new System.Drawing.Size(118, 25);
            this.exall.TabIndex = 0;
            this.exall.Text = "Mở rộng tất cả";
            this.exall.UseVisualStyleBackColor = false;
            this.exall.Click += new System.EventHandler(this.exall_Click);
            // 
            // uncheckall
            // 
            this.uncheckall.BackColor = System.Drawing.SystemColors.Control;
            this.uncheckall.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.uncheckall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.uncheckall.Location = new System.Drawing.Point(94, 7);
            this.uncheckall.Name = "uncheckall";
            this.uncheckall.Size = new System.Drawing.Size(87, 25);
            this.uncheckall.TabIndex = 3;
            this.uncheckall.Text = "Loại bỏ tất cả";
            this.uncheckall.UseVisualStyleBackColor = false;
            this.uncheckall.Click += new System.EventHandler(this.uncheckall_Click);
            // 
            // lvmsc
            // 
            this.lvmsc.CheckBoxes = true;
            this.lvmsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvmsc.GridLines = true;
            this.lvmsc.Location = new System.Drawing.Point(5, 19);
            this.lvmsc.MultiSelect = false;
            this.lvmsc.Name = "lvmsc";
            this.lvmsc.Size = new System.Drawing.Size(251, 487);
            this.lvmsc.TabIndex = 1;
            this.lvmsc.UseCompatibleStateImageBehavior = false;
            this.lvmsc.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvmsc_ItemCheck);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.uncheckall);
            this.panel3.Controls.Add(this.checkall);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(5, 506);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(251, 38);
            this.panel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.huy);
            this.panel1.Controls.Add(this.luu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 503);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 46);
            this.panel1.TabIndex = 4;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.Control;
            this.button5.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Location = new System.Drawing.Point(129, 9);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 25);
            this.button5.TabIndex = 3;
            this.button5.Text = "Hủy";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // huy
            // 
            this.huy.BackColor = System.Drawing.SystemColors.Control;
            this.huy.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.huy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.huy.Location = new System.Drawing.Point(129, 9);
            this.huy.Name = "huy";
            this.huy.Size = new System.Drawing.Size(118, 25);
            this.huy.TabIndex = 3;
            this.huy.Text = "Hủy";
            this.huy.UseVisualStyleBackColor = false;
            // 
            // luu
            // 
            this.luu.BackColor = System.Drawing.SystemColors.Control;
            this.luu.FlatAppearance.BorderColor = System.Drawing.SystemColors.Desktop;
            this.luu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.luu.Location = new System.Drawing.Point(5, 9);
            this.luu.Name = "luu";
            this.luu.Size = new System.Drawing.Size(118, 25);
            this.luu.TabIndex = 2;
            this.luu.Text = "Lưu lại";
            this.luu.UseVisualStyleBackColor = false;
            this.luu.Click += new System.EventHandler(this.luu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lvmsc);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(667, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(261, 549);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hoạt động";
            // 
            // MSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 549);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.LookAndFeel.SkinName = "Metropolis";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MinimizeBox = false;
            this.Name = "MSC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MSC_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button crollall;
        private System.Windows.Forms.Button checkall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView tvmsc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exall;
        private System.Windows.Forms.Button uncheckall;
        private System.Windows.Forms.ListView lvmsc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button huy;
        private System.Windows.Forms.Button luu;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}