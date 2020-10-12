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
    public partial class Frm_distrist : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        distrist distrist = new distrist();
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
        public Frm_distrist()
        {
            InitializeComponent();
        }

        private void Frm_distrist_Load(object sender, EventArgs e)
        {
            clsItem cls;
            DataTable da = new DataTable();
            da = gen.GetTable("select * from Province order by ProvinceName");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                cls = new clsItem(da.Rows[i][0].ToString(), da.Rows[i][2].ToString());
                cbprovince.Items.Add(cls);
            }
            cbprovince.DisplayMember = "PstrName";
            cbprovince.ValueMember = "PstrValue";
            cbprovince.SelectedIndex = 0;
            if (active == "1")
            {
                DataTable data = new DataTable();
                data = gen.GetTable("select * from Distrist where DistristID='" + role + "'");
                txtcode.Text = data.Rows[0][1].ToString();
                txtname.Text = data.Rows[0][2].ToString();
                txtdg.Text = data.Rows[0][3].ToString();
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    if (data.Rows[0][4].ToString() == da.Rows[i][0].ToString())
                        cbprovince.SelectedIndex = i;
                }
            }
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            clsItem cls1 = (clsItem)cbprovince.SelectedItem;
            string tt = cls1.PstrValue;
            if (active == "1")
            {
                string sql = "update Distrist set DistristName=N'" + txtname.Text + "',Description=N'" + txtdg.Text + "',ProvinceID='" + tt + "' where DistristID='" + role + "'";
                distrist.checkdistrist(active, txtcode, txtname, sql, this);
            }
            else
            {
                string sql = "insert into Distrist values(newid(),'" + txtcode.Text + "',N'" + txtname.Text + "',N'" + txtdg.Text + "','" + tt + "')";
                distrist.checkdistrist(active, txtcode, txtname, sql, this);
            }
        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}