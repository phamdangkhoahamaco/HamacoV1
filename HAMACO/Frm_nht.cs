using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAMACO
{
    public partial class Frm_nht : DevExpress.XtraEditors.XtraForm
    {
        public delegate void ac();
        public ac myac;
        Form1 F;
        public Form getform(Form1 a)
        {
            F = a;
            return F;
        }

        Frm_iistock Fii;
        public Frm_iistock getformiistock(Frm_iistock a)
        {
            Fii = a;
            return Fii;
        }

        string ngaychungtu,tsbt=null;

        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }

        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public Frm_nht()
        {
            InitializeComponent();
        }

        private void Frm_nht_Load(object sender, EventArgs e)
        {
            denct.EditValue = DateTime.Parse(ngaychungtu);
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ngaychungtu = denct.EditValue.ToString();
            }
            catch { }
        }

        private void btok_Click(object sender, EventArgs e)
        {
            try
            {
                string a = denct.EditValue.ToString();
                if (DateTime.Parse(a).Year.ToString() != "2012")
                {
                    if (tsbt == "barbgdh" || tsbt == "barbglpg")
                        Fii.getngay(ngaychungtu);
                    else
                        F.getdate(ngaychungtu);

                    myac();
                    this.Close();
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Năm 2012 không khả dụng vui lòng chọn thời gian khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Bạn không được bỏ trống ngày chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}