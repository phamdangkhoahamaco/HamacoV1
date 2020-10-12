using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_Descasc : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Descasc()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string active, role, ngay, check;
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
        public void loadstarttanggiam( DataTable dt)
        {
           
            DataTable da = new DataTable();
            DataTable temp = new DataTable();
            da.Columns.Add("Mã kho");
            da.Columns.Add("Tên kho");
            temp = gen.GetTable("select StockCode,StockName from Stock order by StockCode");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = da.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                da.Rows.Add(dr);
            }
            makho.DataSource = da;
            makho.DisplayMember = "Mã kho";
            makho.ValueMember = "Mã kho";
            

            DataTable da2 = new DataTable();
            DataTable temp2 = new DataTable();
            da2.Columns.Add("Mã ngành");
            da2.Columns.Add("Tên ngành");
            temp2 = gen.GetTable("select InventoryCategoryCode as 'Mã ngành',InventoryCategoryName as 'Tên ngành' from InventoryItemCategory where IsParent=0 and Grade=3 and Inactive='False' order by InventoryCategoryCode");
            for (int i = 0; i < temp2.Rows.Count; i++)
            {
                DataRow dr = da2.NewRow();
                dr[0] = temp2.Rows[i][0].ToString();
                dr[1] = temp2.Rows[i][1].ToString();
                da2.Rows.Add(dr);
            }
            manganhhang.DataSource = da2;
            manganhhang.DisplayMember = "Mã ngành";
            manganhhang.ValueMember = "Mã ngành";

            DataTable da1 = new DataTable();
            da1.Columns.Add("Tài khoản");
            da1.Columns.Add("Tên tài khoản");
            temp = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = da1.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                da1.Rows.Add(dr);
            }
            ledv.Properties.DataSource = da1;
            ledv.Properties.DisplayMember = "Tài khoản";
            ledv.Properties.ValueMember = "Tài khoản";
            ledv.Properties.PopupWidth = 485;

            
            dt.Columns.Add("Mã kho");
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Diễn giải");
            dt.Columns.Add("Mã ngành");

            gridControl1.DataSource = dt;
            gridView1.Columns["Mã kho"].ColumnEdit = makho;
            gridView1.Columns["Số tiền"].ColumnEdit = sotien;
            gridView1.Columns["Mã ngành"].ColumnEdit = manganhhang;

            gridView1.Columns["Số tiền"].Width = 50;
            gridView1.Columns["Mã kho"].Width = 50;
            gridView1.Columns["Mã ngành"].Width = 50;

            gridView1.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số tiền"].SummaryItem.DisplayFormat = "Tổng tiền = {0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            txtdvsd.EditValue = DateTime.Parse(ngay);                        
        }

        private void Frm_Descasc_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            loadstarttanggiam(dt);
            if (active == "1")
            {
                DataTable temp = gen.GetTable("select * from Descasc where DescascID='" + role + "'");
                txtname.EditValue = temp.Rows[0][2].ToString();
                ledv.EditValue = temp.Rows[0][3].ToString();
                if (temp.Rows[0][7].ToString() == "1")
                    rbcpn.Checked = true;
                else if (temp.Rows[0][7].ToString() == "2")
                    rbltu.Checked = true;
                else if (temp.Rows[0][7].ToString() == "3")
                    rbtnn.Checked = true;
                else if (temp.Rows[0][7].ToString() == "4")
                    rbgvn.Checked = true;
                txtdvsd.EditValue = DateTime.Parse(temp.Rows[0][8].ToString());
                temp = gen.GetTable("select StockCode,Amount,JournalMemo,Manganh from Descasc a, Stock b where a.StockID=b.StockID and DescascCode='" + temp.Rows[0][1].ToString() + "'");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = temp.Rows[i][3].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
            }
            txtname.Focus();
        }

        private void basave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtname.Focus();
            if (rbcpn.Checked == true)
                check = "1";
            else if (rbltu.Checked == true)
                check = "2";
            else if (rbtnn.Checked == true)
                check = "3";
            else if (rbgvn.Checked == true)
                check = "4";
            else check = "0";

            if (active == "1")
            {
                gen.ExcuteNonquery("delete Descasc where DescascCode=(select DescascCode from Descasc where DescascID='" + role + "')");
            }

            Double so = 0;
            try
            {
                so = Double.Parse(gen.GetString("select Max(DescascCode) from Descasc")) + 1;
            }
            catch { }
            for (int i = 0; i < gridView1.RowCount - 1; i++)
            {
                string makho = gridView1.GetRowCellValue(i, "Mã kho").ToString();
                makho = gen.GetString("select StockID from Stock where StockCode='" + makho + "'");
                string sotien = gridView1.GetRowCellValue(i, "Số tiền").ToString().Replace(".", "");
                string diengiai = gridView1.GetRowCellValue(i, "Diễn giải").ToString();
                string manganh = gridView1.GetRowCellValue(i, "Mã ngành").ToString();
                gen.ExcuteNonquery("insert into Descasc values(newid(),'" + so + "',N'" + txtname.EditValue + "','" + ledv.EditValue + "','" + makho + "','" + sotien + "',N'" + diengiai + "','" + check + "','" + txtdvsd.EditValue + "','" + manganh + "')");
            }

            XtraMessageBox.Show("Dữ liệu của bạn đã được lưu.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.myac();
            this.Close();
        }
    }
}