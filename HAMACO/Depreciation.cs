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
    public partial class Depreciation : DevExpress.XtraEditors.XtraForm
    {
        public Depreciation()
        {
            InitializeComponent();
        }
        DataTable temp = new DataTable();
        string active, role, ngay;
        gencon gen = new gencon();
        public delegate void ac();
        public ac myac;
        public string getngay(string a)
        {
            ngay = a;
            return ngay;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getactive(string a)
        {
            active = a;
            return active;
        }

        public void loadstock()
        {
            DataTable kho = new DataTable();
            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            kho = gen.GetTable("select StockCode,StockName from Stock a order by StockCode");
            for (int i = 0; i < kho.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = kho.Rows[i][0].ToString();
                dr[1] = kho.Rows[i][1].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;
        }

        private void Depreciation_Load(object sender, EventArgs e)
        {
            loadstock();
            if (active == "1")
            {
                DataTable da = gen.GetTable("select * from Depreciation where DepreciationID='" + role + "'");
                txtname.EditValue = da.Rows[0][2].ToString();
                if (da.Rows[0][3].ToString() != "")
                    txtdvsd.EditValue = DateTime.Parse(da.Rows[0][3].ToString());
                if (da.Rows[0][4].ToString() != "")
                    txttgkh.EditValue = da.Rows[0][4];
                if (da.Rows[0][5].ToString() != "")
                    txttghkh.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                if (da.Rows[0][6].ToString() != "")
                    txtng.EditValue = da.Rows[0][6];

                if (da.Rows[0][8].ToString() != "")
                {
                    txttontruoc.EditValue = Double.Parse(da.Rows[0][8].ToString());
                }
                
                if (da.Rows[0][7].ToString() != "")
                    txtkhbq.EditValue = da.Rows[0][7];
                if (da.Rows[0][8].ToString() != "")
                    txtgtcl.EditValue = da.Rows[0][8];                    
                if (da.Rows[0][9].ToString() != "")
                    txttgcl.EditValue = da.Rows[0][9];
                if (da.Rows[0][10].ToString() != "")
                    txtts.EditValue = da.Rows[0][10];
                if (da.Rows[0][11].ToString() != "")
                    txtlv.EditValue = da.Rows[0][11];
                if (da.Rows[0][14].ToString() == "1")
                {
                    chkhcd.Checked = true;
                }
                ledv.EditValue = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][12].ToString() + "'");
            }
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                if (temp.Rows[i][0].ToString() == ledv.EditValue.ToString())
                {
                    textEdit9.Text = temp.Rows[i][1].ToString();
                    return;
                }
            }
        }
      
        private void chkhcd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkhcd.Checked == true)
            {
                txtdvsd.Enabled = false;
                txttgkh.Enabled = false;
                txttghkh.Enabled = false;
                txtts.Enabled = false;
                txtgtcl.Enabled = false;
                txttgcl.Enabled = false;
                txtlv.Enabled = false;
            }
            else
            {
                txtdvsd.Enabled = true;
                txttgkh.Enabled = true;
                txttghkh.Enabled = true;
                txtts.Enabled = true;
                txtgtcl.Enabled = true;
                txttgcl.Enabled = true;
                txtlv.Enabled = true;
            }
        }

        private void basave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (chkhcd.Checked == true)
                {
                    string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue + "'");
                    string nguyengia = txtng.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    string khauhao = txtkhbq.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    if (active == "1")
                        gen.ExcuteNonquery("update Depreciation set DepreciationName=N'" + txtname.EditValue + "', OriginalPrice='" + nguyengia + "', Price='" + khauhao + "', StockID='" + makho + "',Fixed=1 where DepreciationID='" + role + "' ");
                    else
                    {
                        Double so = Double.Parse(gen.GetString("select Max(DepreciationCode) from Depreciation")) + 1;
                        gen.ExcuteNonquery("insert into Depreciation(DepreciationID,DepreciationCode,DepreciationName,OriginalPrice,Price,StockID,PostDate,Fixed) values(newid(),'" + so + "',N'" + txtname.EditValue + "','" + nguyengia + "','" + khauhao + "','" + makho + "','" + ngay + "',1) ");
                    }
                }
                else
                {
                    string makho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue + "'");
                    string nguyengia = txtng.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    string khauhao = txtkhbq.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    string thuesuat = txtts.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    string giatriconlai = txttontruoc.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    string laivay = txtlv.EditValue.ToString().Replace(".", "").Replace(",", ".");
                    if (active == "1")
                        gen.ExcuteNonquery("update Depreciation set DepreciationName=N'" + txtname.EditValue + "',StartTime='" + txtdvsd.EditValue + "',DepreciationTime='" + txttgkh.EditValue + "',EndTime='" + txttghkh.EditValue + "', OriginalPrice='" + nguyengia + "', Price='" + khauhao + "',ExitsPrice='" + giatriconlai + "',ExitsTime='" + txttgcl.EditValue + "',Tax='" + thuesuat + "',TaxPrice='" + laivay + "', StockID='" + makho + "',PostDate='" + ngay + "',Fixed=0 where DepreciationID='" + role + "'");
                    else
                    {
                        Double so = Double.Parse(gen.GetString("select Max(DepreciationCode) from Depreciation"));
                        so = so + 1;
                        gen.ExcuteNonquery("insert into Depreciation values(newid(),'" + so + "',N'" + txtname.EditValue + "','" + txtdvsd.EditValue + "','" + txttgkh.EditValue + "','"+txttghkh.EditValue+"','" + nguyengia + "','" + khauhao + "','" + giatriconlai + "','" + txttgcl.EditValue + "','" + thuesuat + "','" + laivay + "','" + makho + "','" + ngay + "',0,0) ");
                    }
                }
                XtraMessageBox.Show("Dữ liệu của bạn đã được lưu.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.myac();
                this.Close();
            }
            catch { XtraMessageBox.Show("Vui lòng kiểm tra lại thông tin trước khi lưu.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            }

        private void txttgkh_EditValueChanged(object sender, EventArgs e)
        {
            if (txtdvsd.EditValue != null)
            {
                txttghkh.EditValue = DateTime.Parse(txtdvsd.EditValue.ToString()).AddMonths(Int32.Parse(txttgkh.EditValue.ToString()));
                txttgcl.EditValue = (DateTime.Parse(txttghkh.EditValue.ToString()).Year - DateTime.Parse(ngay).Year) * 12 + DateTime.Parse(txttghkh.EditValue.ToString()).Month - DateTime.Parse(ngay).Month;
            }
        
        }
        private void txtnhd_EditValueChanged(object sender, EventArgs e)
        {
            if (txttgkh.EditValue != null)
            {
                txttghkh.EditValue = DateTime.Parse(txtdvsd.EditValue.ToString()).AddMonths(Int32.Parse(txttgkh.EditValue.ToString()));
                txttgcl.EditValue = (DateTime.Parse(txttghkh.EditValue.ToString()).Year - DateTime.Parse(ngay).Year) * 12 + DateTime.Parse(txttghkh.EditValue.ToString()).Month - DateTime.Parse(ngay).Month;
            }
        }

        private void txtng_EditValueChanged(object sender, EventArgs e)
        {
                if (active == "0")
                {
                    if (txttgkh.EditValue != null)
                    {
                        txtkhbq.EditValue = Math.Round(Double.Parse(txtng.EditValue.ToString()) / Double.Parse(txttgkh.EditValue.ToString()), 0);
                        txttontruoc.EditValue = Math.Round((Double.Parse(txtng.EditValue.ToString()) / Double.Parse(txttgkh.EditValue.ToString()))*(Double.Parse(txttgcl.EditValue.ToString())), 0);
                    }
                }
                if (chkhcd.Checked == true)
                    txtkhbq.EditValue = txtng.EditValue;
        }

      
        private void txtts_EditValueChanged(object sender, EventArgs e)
        {
            if (txttontruoc.EditValue != null)
                txtlv.EditValue = Math.Round(Double.Parse(txtts.EditValue.ToString()) * Double.Parse(txttontruoc.EditValue.ToString()) / 1200, 0);
        }

  
        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string check = "";
            string kho = "";
            try
            {
                check = ledv.EditValue.ToString();
                check = "Kho " + check + " - ";
                kho = gen.GetString("select StockID from Stock Where StockCode='" + ledv.EditValue + "'");
            }
            catch { }
            if (XtraMessageBox.Show(check+"Thao tác này sẽ làm mất những dữ liệu bạn đã chỉnh, bạn có muốn tiếp tục?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string thang = DateTime.Parse(ngay).Month.ToString();
                string nam = DateTime.Parse(ngay).Year.ToString();
                string thangtruoc = DateTime.Parse(ngay).AddMonths(-1).Month.ToString();
                string namtruoc = DateTime.Parse(ngay).AddMonths(-1).Year.ToString();
                gen.ExcuteNonquery("bangketudongkhauhao '" + thangtruoc + "','" + namtruoc + "','" + thang + "','" + nam + "','" + ngay + "','" + kho + "'");
                XtraMessageBox.Show(check+"Dữ liệu đã được tạo.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.myac();
                this.Close();                
            }
        }

        private void txtkhbq_EditValueChanged(object sender, EventArgs e)
        {
            if (txttontruoc.EditValue != null)
                txtgtcl.EditValue = Double.Parse(txttontruoc.EditValue.ToString()) - Double.Parse(txtkhbq.EditValue.ToString());
        }

        private void txttontruoc_EditValueChanged(object sender, EventArgs e)
        {
            if (txtts.EditValue != null)
                txtlv.EditValue = Math.Round(Double.Parse(txtts.EditValue.ToString()) * Double.Parse(txttontruoc.EditValue.ToString()) / 1200, 0);
            if (txtkhbq.EditValue != null)
                txtgtcl.EditValue = Double.Parse(txttontruoc.EditValue.ToString()) - Double.Parse(txtkhbq.EditValue.ToString());
        }

    }
}