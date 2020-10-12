using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_province : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        province province = new province();
        string active, role,userid;
        public delegate void ac();
        public ac myac;
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getuserid(string a)
        {
            userid = a;
            return userid;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public Frm_province()
        {
            InitializeComponent();
        }

        private void Frm_province_Load(object sender, EventArgs e)
        {
            if (active == "1")
            {
                this.Text = "Sửa tỉnh/thành";
                txtcode.ReadOnly = true;
                DataTable da = new DataTable();
                da = gen.GetTable("select * from Province where ProvinceID='" + role + "'");
                txtcode.Text = da.Rows[0][1].ToString();
                txtname.Text = da.Rows[0][2].ToString();
                txtdg.Text = da.Rows[0][3].ToString();
            }
            else this.Text = "Thêm tỉnh/thành";
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            if (active == "1")
            {
                string sql = "update Province set ProvinceName=N'" + txtname.Text + "',Description=N'" + txtdg.Text + "' where ProvinceID='" + role + "'";
                province.checkprovince(active, txtcode, txtname, sql, this);
            }
            else
            {
                string sql = "insert into Province values(newid(),'" + txtcode.Text + "',N'" + txtname.Text + "',N'" + txtdg.Text + "')";
                province.checkprovince(active, txtcode, txtname, sql, this);
            }
        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}