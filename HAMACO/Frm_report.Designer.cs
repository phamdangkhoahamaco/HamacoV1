namespace HAMACO
{
    partial class Frm_report
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
            this.printControl1 = new DevExpress.XtraPrinting.Control.PrintControl();
            this.SuspendLayout();
            // 
            // printControl1
            // 
            this.printControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printControl1.IsMetric = false;
            this.printControl1.Location = new System.Drawing.Point(0, 0);
            this.printControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.printControl1.Name = "printControl1";
            this.printControl1.Size = new System.Drawing.Size(1275, 776);
            this.printControl1.TabIndex = 9;
            // 
            // Frm_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 776);
            this.Controls.Add(this.printControl1);
            this.Name = "Frm_report";
            this.Text = "Frm_report";
            this.Load += new System.EventHandler(this.Frm_report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraPrinting.Control.PrintControl printControl1;
    }
}