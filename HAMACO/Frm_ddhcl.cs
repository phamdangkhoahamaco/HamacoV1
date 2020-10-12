using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraGrid.Views.Base;

namespace HAMACO
{
    public partial class Frm_ddhcl : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        string userid = null, role = null, ngaychungtu = null, active = null, branchid = null, roleid = null, subsys = null;
        DataTable hang = new DataTable();
        DataTable khach = new DataTable();

        public delegate void ac();
        public ac myac;

        public string getroleid(string a)
        {
            roleid = a;
            return roleid;
        }
        public string getsub(string a)
        {
            subsys = a;
            return subsys;
        }

        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }
        public string getbranch(string a)
        {
            branchid = a;
            return branchid;
        }
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }

        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }

        public string getrole(string a)
        {
            role = a;
            return role;
        }

        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public Frm_ddhcl()
        {
            InitializeComponent();
        }

        private void Frm_ddhcl_Load(object sender, EventArgs e)
        {
            DataTable da = gen.GetTable("select StockCode as 'Mã kho',StockName as 'Tên kho' from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode");
            sedv.Properties.DataSource = da;
            sedv.Properties.DisplayMember = "Mã kho";
            sedv.Properties.ValueMember = "Mã kho";
            sedv.EditValue = da.Rows[0][0].ToString();

            DataTable temp = new DataTable();
            temp.Columns.Add("Mã hàng");
            temp.Columns.Add("Tên hàng");
            for (int i = 0; i < hang.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = hang.Rows[i][1].ToString();
                dr[1] = hang.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            semh.Properties.DataSource = temp;
            semh.Properties.DisplayMember = "Mã hàng";
            semh.Properties.ValueMember = "Mã hàng";

            denad.EditValue = DateTime.Parse(ngaychungtu);
            degd.EditValue = DateTime.Parse(ngaychungtu);
            txttl.EditValue = 0;
            txtdsd.EditValue = 0;

            if (Double.Parse(gen.GetString("select AuthenticationType from MSC_User where UserID='" + userid + "'")) > 1)
                chenqv.Enabled = true;

            if (active == "0")
            {
                sedv.Enabled=true;
            }
            else
            {
                sedv.Enabled = false;
                da = gen.GetTable("select RefNo,RefDate,PostedDate,StockCode,AccountingObjectCode,AccountingObjectName,TotalAmount,TotalTransport,IsExport,Contactname,Cancel from DDHCL a, Stock b where a.InStockID=b.StockID and RefID='" + role + "'");
                txtsct.Text = da.Rows[0][0].ToString();
                denad.EditValue = DateTime.Parse(da.Rows[0][1].ToString());
                degd.EditValue = DateTime.Parse(da.Rows[0][2].ToString());
                sedv.EditValue = da.Rows[0][3].ToString();
                semh.EditValue = da.Rows[0][4].ToString();
                txttl.EditValue = Double.Parse(da.Rows[0][6].ToString());
                try
                {
                    txtdsd.EditValue = Double.Parse(da.Rows[0][7].ToString());
                }
                catch { }
                chenqv.Checked = bool.Parse(da.Rows[0][8].ToString());
                lbduyet.Text = da.Rows[0][9].ToString();
                if (da.Rows[0][8].ToString() == "True")
                {
                    denad.Properties.ReadOnly=true;
                    degd.Properties.ReadOnly = true;
                    semh.Properties.ReadOnly = true;
                    txttl.Properties.ReadOnly = true;
                    txtdsd.Properties.ReadOnly = true;
                    barcsddh.Enabled = true;
                }
                if (da.Rows[0][10].ToString() == "True")
                    barcsddh.Enabled = false;
            }

        }

        private void sedv_EditValueChanged(object sender, EventArgs e)
        {
            if (active == "0")
                themsct();
        }

        public void themsct()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + sedv.EditValue.ToString() + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + sedv.EditValue.ToString() + "-DHCL";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from DDHCL where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and InStockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
        }

        private void semh_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < hang.Rows.Count; i++)
            {
                if (semh.EditValue.ToString() == hang.Rows[i][1].ToString())
                {
                    txtth.EditValue = hang.Rows[i][2].ToString();
                    return;
                }
            }
        }

        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (semh.Text == "")
            {
                XtraMessageBox.Show("Bạn không được bỏ trống mặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (denad.Text == "")
            {
                XtraMessageBox.Show("Bạn không được bỏ trống ngày áp dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (degd.Text == "")
            {
                XtraMessageBox.Show("Bạn không được bỏ trống giá điều ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (active == "0")
            {
                gen.ExcuteNonquery("insert into DDHCL(RefID,RefNo,RefDate,PostedDate,InStockID,AccountingObjectCode,AccountingObjectName,TotalAmount,TotalTransport,Contactname,IsExport) values(newid(),'" + txtsct.Text + "','" + denad.EditValue.ToString() + "','" + degd.EditValue.ToString() + "','" + gen.GetString("select StockID from Stock where StockCode='" + sedv.EditValue.ToString() + "'") + "','" + semh.EditValue.ToString() + "',N'" + txtth.Text + "'," + txttl.EditValue.ToString() + ",'" + txtdsd.EditValue.ToString() + "',N'" + lbduyet.Text + "','" + chenqv.Checked + "')");
                XtraMessageBox.Show("Dữ liệu đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myac();
                this.Close();
            }
            else
            {
                gen.ExcuteNonquery("update DDHCL set RefDate='" + denad.EditValue.ToString() + "',PostedDate='" + degd.EditValue.ToString() + "',AccountingObjectCode='" + semh.EditValue.ToString() + "',AccountingObjectName=N'" + txtth.Text + "',TotalAmount=" + txttl.EditValue.ToString() + ",TotalTransport='" + txtdsd.EditValue.ToString() + "',Contactname=N'" + lbduyet.Text + "',IsExport='" + chenqv.Checked + "' where RefID='" + role + "'");
                XtraMessageBox.Show("Dữ liệu đã được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myac();
                this.Close();
            }
        }

        private void chenqv_CheckedChanged(object sender, EventArgs e)
        {
            if (chenqv.Checked == true)
                lbduyet.Text = gen.GetString("select Fullname from MSC_User where Userid='" + userid + "'");
            else
                lbduyet.Text = null;
        }

        private void barcsddh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Double.Parse(txtdsd.EditValue.ToString()) > Double.Parse(txttl.EditValue.ToString()) || Double.Parse(txtdsd.EditValue.ToString()) * 1.01 > Double.Parse(txttl.EditValue.ToString()))
            {
                XtraMessageBox.Show("Bạn đã sử dụng hết lượng được chia.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Frm_ddh u = new Frm_ddh();
            u.getactive("0");
            u.getroleid(roleid);
            u.getsub(subsys);
            u.getpt("tsbtddh");
            u.getdate(DateTime.Now.ToString());
            u.getuser(userid);
            u.getbranch(branchid);
            u.getkhach(khach);
            u.gethang(hang);
            u.getdategiadieu(degd.EditValue.ToString());
            u.getphieucl(txtsct.Text);
            u.getrole(sedv.EditValue.ToString());
            u.getmahang(semh.EditValue.ToString());
            u.ShowDialog();
        }
    }
}