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
    public partial class Frm_accountgroup : DevExpress.XtraEditors.XtraForm
    {

        gencon gen = new gencon();
        accountgroup accountgroup = new accountgroup();
        public delegate void ac();
        public ac myac;
        string role;
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public Frm_accountgroup()
        {
            InitializeComponent();
        }

        private void cbct_CheckedChanged(object sender, EventArgs e)
        {
            if (cbct.Checked == false)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
                cbdt.Enabled = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
                if (radioButton1.Checked == true) cbdt.Enabled = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) cbdt.Enabled = true;
            else
            {
                cbdt.SelectedIndex = 0;
                cbdt.Enabled = false;
            }
        }

        private void Frm_accountgroup_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            txtcode.ReadOnly = true;
            DataTable da = new DataTable();
            da = gen.GetTable("select * from AccountCategory where AccountCategoryID='" + role + "' ");
            txtcode.Text = da.Rows[0][0].ToString();
            txtname.Text = da.Rows[0][1].ToString();
            clsItem cls;
            cls = new clsItem("0", "Dư nợ");
            cbtc.Items.Add(cls);
            cls = new clsItem("1", "Dư có");
            cbtc.Items.Add(cls);
            cls = new clsItem("2", "Lưỡng tính");
            cbtc.Items.Add(cls);
            cls = new clsItem("3", "Không có số dư");
            cbtc.Items.Add(cls);
            cbtc.DisplayMember = "PstrName";
            cbtc.ValueMember = "PstrValue";
            cbtc.SelectedIndex = (int)da.Rows[0][2];

            clsItem cls1;
            cls1 = new clsItem("0", "Nhà cung cấp");
            cbdt.Items.Add(cls1);
            cls1 = new clsItem("1", "Khách hàng");
            cbdt.Items.Add(cls1);
            cls1 = new clsItem("2", "Nhân viên");
            cbdt.Items.Add(cls1);
            cbdt.DisplayMember = "PstrName";
            cbdt.ValueMember = "PstrValue";
            cbdt.SelectedIndex = (int)da.Rows[0][7];
            int ch = 0;
            for (int i = 1; i < 9; i++)
            {
                if (da.Rows[0][i].ToString() == "True") ch = 1;
            }
            if (ch == 0)
            {
                cbct.Checked = true;
                cbct.Checked = false;
            }
            else cbct.Checked = true;
            radioButton1.Checked = (bool)da.Rows[0][3];
            radioButton2.Checked = (bool)da.Rows[0][5];
            radioButton3.Checked = (bool)da.Rows[0][6];
            radioButton4.Checked = (bool)da.Rows[0][4];
            radioButton5.Checked = (bool)da.Rows[0][8];
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string dtkt = radioButton1.Checked.ToString();
            string hd = radioButton2.Checked.ToString();
            string vthh = radioButton3.Checked.ToString();
            string cp = radioButton4.Checked.ToString();
            string nh = radioButton5.Checked.ToString();
            clsItem cls = (clsItem)cbdt.SelectedItem;
            string dt = cls.PstrValue;
            clsItem cls1 = (clsItem)cbtc.SelectedItem;
            string tc = cls1.PstrValue;
            string sql = "update AccountCategory set AccountCategoryName=N'" + txtname.Text + "',AccountCategoryKind='" + tc + "',DetailByAccountingObject='" + dtkt + "',DetailByInventoryItem='" + cp + "', DetailByJob='" + hd + "',DetailByContract='" + vthh + "',AccountingObjectType='" + dt + "',DetailByBankAccount='" + nh + "' where AccountCategoryID='" + txtcode.Text + "' ";
            accountgroup.checkaccountgroup(txtname.Text, sql, this);
        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}