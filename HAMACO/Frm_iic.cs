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
    public partial class Frm_iic : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        InventoryItemCategory iic = new InventoryItemCategory();
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
        public Frm_iic()
        {
            InitializeComponent();
        }

        private void Frm_iic_Load(object sender, EventArgs e)
        {
            DataTable da = new DataTable();
            DataTable da1 = new DataTable();
            da1.Columns.Add("ID", typeof(String));
            da1.Columns.Add("Name", typeof(String));
            DataTable data = new DataTable();
            data = gen.GetTable("select * from InventoryItemCategory");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                da1.Rows.Add(new String[] { data.Rows[i][5].ToString(), data.Rows[i][6].ToString() });
            }
            cbloai.DataSource = da1;
            cbloai.DisplayMember = "Name";
            cbloai.ValueMember = "ID";
            cbloai.SelectedIndex = -1;
            if (role != "")
            {
                da = gen.GetTable("select * from InventoryItemCategory where InventoryCategoryID='" + role + "'");
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (active == "1")
                    {
                        if (da.Rows[0][1].ToString() == data.Rows[i][0].ToString())
                            cbloai.SelectedIndex = i;
                    }
                    else
                    {
                        if (da.Rows[0][0].ToString() == data.Rows[i][0].ToString())
                            cbloai.SelectedIndex = i;
                    }
                }
            }

            if (active == "1")
            {
                this.Text = "Sửa loại vật tư hàng hóa, công cụ dụng cụ";
                txtcode.ReadOnly = true;
                txtcode.Text = da.Rows[0][5].ToString();
                txtname.Text = da.Rows[0][6].ToString();
                checkBox1.Checked = (bool)da.Rows[0][9];
            }
            else this.Text = "Thêm loại vật tư hàng hóa, công cụ dụng cụ";
        }

        private void tsbtsave_Click(object sender, EventArgs e)
        {
            string pid = "NULL";
            int gr = 1;
            if (cbloai.Text != "")
            {
                pid = gen.GetString("select InventoryCategoryID from InventoryItemCategory where InventoryCategoryCode='" + cbloai.SelectedValue.ToString() + "'");
                string t = gen.GetString("select Grade from InventoryItemCategory where InventoryCategoryCode='" + cbloai.SelectedValue.ToString() + "'");
                gr = int.Parse(t) + 1;
            }
            if (active == "1")
            {
                string sql;
                if (pid == "NULL")
                {
                    sql = "update InventoryItemCategory set InventoryCategoryName=N'" + txtname.Text + "',Inactive='" + checkBox1.Checked.ToString() + "',Grade='" + gr + "' where InventoryCategoryID='" + role + "'";
                }
                else
                {
                    sql = "update InventoryItemCategory set InventoryCategoryName=N'" + txtname.Text + "',Inactive='" + checkBox1.Checked.ToString() + "',ParentID='" + pid + "',Grade='" + gr + "' where InventoryCategoryID='" + role + "'";
                    gen.ExcuteNonquery("update InventoryItemCategory set IsParent='True' where  InventoryCategoryID='" + pid + "'");
                }
               // iic.checkiic(active, txtcode, txtname, sql, this, pid, role);
            }
            else
            {
                string sql = "insert into InventoryItemCategory(InventoryCategoryID,InventoryCategoryCode,InventoryCategoryName,Inactive,ParentID,Grade) values(newid(),'" + txtcode.Text + "',N'" + txtname.Text + "','" + checkBox1.Checked.ToString() + "','" + pid + "','" + gr + "')";
                if (pid != "NULL")
                {
                    gen.ExcuteNonquery("update InventoryItemCategory set IsParent='True' where  InventoryCategoryID='" + pid + "'");
                }
               // iic.checkiic(active, txtcode, txtname, sql, this, pid, role);
            }
        }

        private void tsbtcancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}