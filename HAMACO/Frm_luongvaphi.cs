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
    public partial class Frm_luongvaphi : DevExpress.XtraEditors.XtraForm
    {
        public Frm_luongvaphi()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string userid, ngaychungtu, nhanvien, kho, tenkho, tennhanvien, idnhanvien;
        string[,] detail = new string[100, 5];
        string caseup=null;
        DataTable khach = new DataTable();
 
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }

        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string getngay(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }

        public string gettenkho(string a)
        {
            tenkho = a;
            return tenkho;
        }
        public string getkho(string a)
        {
            kho = a;
            return kho;
        }

        public void getnhanvien()
        {
            searchLookUpEdit1.Properties.View.Columns.Clear();
            DataTable temp = new DataTable();
            temp.Columns.Add("Mã nhân viên");
            temp.Columns.Add("Tên nhân viên");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            searchLookUpEdit1.Properties.DataSource = temp;
            searchLookUpEdit1.Properties.DisplayMember = "Mã nhân viên";
            searchLookUpEdit1.Properties.ValueMember = "Mã nhân viên";
            searchLookUpEdit1.Focus();
        }

        public void getkhachhang()
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();

            view.Columns.Clear();
            temp = gen.GetTable("select b.AccountingObjectID,b.AccountingObjectCode,b.AccountingObjectName,EmployeeCode,EmployeeName,EmployeeID from ((select * from (select distinct AccountingObjectID from HACHTOAN where MONTH(CABA)='" + thang + "' and YEAR(CABA)='" + nam + "' and StockID='" + kho + "' and (DebitAccount='131' or CreditAccount='131')) a left join (select AccountingObjectID as AccountingObject ,EmployeeCode,EmployeeName,EmployeeID from SalaryList where StockID='" + kho + "' and Months='" + thang + "' and Years='" + nam + "') b on a.AccountingObjectID=b.AccountingObject)) a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID order by b.AccountingObjectCode");
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Mã nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Tên nhân viên", Type.GetType("System.String"));
            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));
            dt.Columns.Add("ID nhân viên", Type.GetType("System.String"));
  
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = "False";
                if (temp.Rows[i][3].ToString() != "")
                {
                    dr[5] = "True";
                }
                dr[6] = temp.Rows[i][5].ToString();
                dt.Rows.Add(dr);
            }
            gridControl1.DataSource = dt;

            view.Columns["Mã khách hàng"].OptionsColumn.AllowEdit = false;
            view.Columns["Tên khách hàng"].OptionsColumn.AllowEdit = false;
            view.Columns["Mã nhân viên"].OptionsColumn.AllowEdit = false;
            view.Columns["Tên nhân viên"].OptionsColumn.AllowEdit = false;
            view.Columns["Chọn"].OptionsColumn.AllowEdit = false;

            view.Columns[0].Visible = false;
            view.Columns[6].Visible = false;

            view.Columns["Chọn"].Width = 100;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

        }


        private void Frm_luongvaphi_Load(object sender, EventArgs e)
        {
            getnhanvien();
            panelControl2.Visible = false;
            labelControl4.Text = tenkho;
            labelControl6.Text = String.Format("{0: MM-yyyy}", DateTime.Parse(ngaychungtu));
            getkhachhang();
        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            nhanvien = searchLookUpEdit1.EditValue.ToString();
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                if (nhanvien == khach.Rows[i][1].ToString())
                {
                    idnhanvien = khach.Rows[i][0].ToString();
                    tennhanvien = khach.Rows[i][2].ToString();
                    return;
                }
            }
           
        }

        private void view_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chọn")
            {
                if (view.GetRowCellValue(view.FocusedRowHandle, "Chọn").ToString() == "False")
                {
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chọn"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Tên nhân viên"], tennhanvien);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã nhân viên"], nhanvien);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["ID nhân viên"], idnhanvien);
                }
                else
                {
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chọn"], "False");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Tên nhân viên"], null);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã nhân viên"], null);
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["ID nhân viên"], null);
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            view.ShowFindPanel();
        }

        private void baedit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            view.Columns["Chọn"].OptionsColumn.AllowEdit = true;
            baadd.Enabled = true;
            barPrint.Enabled = false;
            baedit.Enabled = false;
            barBaocaosanluong.Enabled = false;
        }

        private void baxem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            view.Columns["Chọn"].OptionsColumn.AllowEdit = false;
            baadd.Enabled = false;
            barPrint.Enabled = true;
            baedit.Enabled = true;
            barBaocaosanluong.Enabled = true;
            getkhachhang();
        }

        private void view_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                if (nhanvien == null)
                {
                    XtraMessageBox.Show("Vui lòng chọn nhân viên trước khi tách hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                panelControl2.Visible = true;
                gridControl1.Enabled = false;
                gridView2.Focus();

                DataTable dt = new DataTable();
                DataTable temp = new DataTable();

                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string makhach = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();

                gridView2.Columns.Clear();
                temp = gen.GetTable("select InventoryItemID,InvNo,CABARefDate,InventoryItemCode,InventoryItemName,a.Quantity-COALESCE(b.Quantity,0),a.QuantityConvert-COALESCE(b.QuantityConvert,0),a.RefDetailID,Quantityb,QuantityConvertb from (select InventoryItemID,InvNo,CABARefDate,InventoryItemCode,InventoryItemName,a.Quantity,a.QuantityConvert,a.RefDetailID,b.Quantity as Quantityb,b.QuantityConvert as QuantityConvertb from (select a.InventoryItemID,a.InvNo,a.CABARefDate,b.InventoryItemCode,b.InventoryItemName,Quantity,a.QuantityConvert,RefDetailID from (select a.InvNo,CABARefDate,InventoryItemID,Quantity,QuantityConvert,RefDetailID from SSInvoice a,SSInvoiceDetail b where a.RefID=b.RefID and a.AccountingObjectID='" + makhach + "' and MONTH(PURefDate)='" + thang + "' and YEAR(PURefDate)='" + nam + "' and BranchID='" + kho + "') a, InventoryItem b where a.InventoryItemID=b.InventoryItemID) a left join "+
                        "(select Quantity,QuantityConvert,Amount,RefDetailID from SalarySS where StockID='" + kho + "' and MonthS='" + thang + "' and YearS='" + nam + "' and EmployeeCode='" + nhanvien + "' and AccountingObjectID='" + makhach + "') b on a.RefDetailID=b.RefDetailID) a left join (select sum(Quantity) as Quantity,sum(QuantityConvert) as QuantityConvert,RefDetailID from SalarySS where StockID='" + kho + "' and MonthS='" + thang + "' and YearS='" + nam + "' and AccountingObjectID='" + makhach + "' and EmployeeCode<>'" + nhanvien + "' group by RefDetailID) b on a.RefDetailID=b.RefDetailID  order by CABARefDate,InvNo,InventoryItemCode");
                    
                    //"select * from (select a.InventoryItemID,a.InvNo,a.CABARefDate,b.InventoryItemCode,b.InventoryItemName,Quantity,a.QuantityConvert,RefDetailID from (select a.InvNo,CABARefDate,InventoryItemID,Quantity,QuantityConvert,RefDetailID from SSInvoice a,SSInvoiceDetail b where a.RefID=b.RefID and a.AccountingObjectID='" + makhach + "' and MONTH(PURefDate)='" + thang + "' and YEAR(PURefDate)='" + nam + "' and BranchID='" + kho + "') a, InventoryItem b where a.InventoryItemID=b.InventoryItemID) a left join"+
                                   // "(select Quantity,QuantityConvert,Amount,RefDetailID from SalarySS where StockID='" + kho + "' and MonthS='" + thang + "' and YearS='" + nam + "' and EmployeeCode='" + nhanvien + "' and AccountingObjectID='" + makhach + "') b on a.RefDetailID=b.RefDetailID order by CABARefDate,InvNo,InventoryItemCode");
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Số hóa đơn", Type.GetType("System.String"));
                dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));
                dt.Columns.Add("Mã hàng hóa", Type.GetType("System.String"));
                dt.Columns.Add("Tên hàng hóa", Type.GetType("System.String"));
                dt.Columns.Add("Số lượng gốc", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng quy đổi gốc", Type.GetType("System.Double"));
                dt.Columns.Add("RefID", Type.GetType("System.String"));
                dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = temp.Rows[i][3].ToString();
                    dr[4] = temp.Rows[i][4].ToString();
                    dr[5] = temp.Rows[i][5].ToString();
                    dr[6] = temp.Rows[i][6].ToString();
                    dr[7] = temp.Rows[i][7].ToString();
                    if(temp.Rows[i][8].ToString()!= "")
                        dr[8] = temp.Rows[i][8].ToString();
                    if (temp.Rows[i][9].ToString() != "")
                        dr[9] = temp.Rows[i][9].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl2.DataSource = dt;

                gridView2.Columns["Số hóa đơn"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["Tên hàng hóa"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["Mã hàng hóa"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["Số lượng gốc"].OptionsColumn.AllowEdit = false;
                gridView2.Columns["Số lượng quy đổi gốc"].OptionsColumn.AllowEdit = false;


                gridView2.Columns["Số lượng quy đổi gốc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                gridView2.Columns["Số lượng quy đổi gốc"].DisplayFormat.FormatString = "{0:n2}";
                gridView2.Columns["Số lượng gốc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                gridView2.Columns["Số lượng gốc"].DisplayFormat.FormatString = "{0:n0}";

                gridView2.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                gridView2.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";
                gridView2.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                gridView2.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
                
                gridView2.Columns["Ngày hóa đơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                gridView2.Columns["Ngày hóa đơn"].DisplayFormat.FormatString = "dd/MM/yyyy";
                gridView2.Columns["Ngày hóa đơn"].Width = 100;
                gridView2.Columns["Ngày hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gridView2.Columns[0].Visible = false;
                gridView2.Columns[7].Visible = false;

                gridView2.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView2.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

                gridView2.Columns["Số lượng"].ColumnEdit = soluong;
                gridView2.Columns["Số lượng quy đổi"].ColumnEdit = soluongquydoi;
            }
        }
        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Số lượng")
            {
                try
                {
                    if (Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString()) > Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng gốc").ToString()))
                    {
                        XtraMessageBox.Show("Số lượng không được lớn hơn số lượng gốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng gốc").ToString());
                    }
                    if (caseup == "1")
                    {
                        Double sl = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng").ToString());
                        Double slqdg = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng quy đổi gốc").ToString());
                        Double slg = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng gốc").ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], Math.Round((slqdg / slg) * sl, 0));
                    }
                }
                catch { }
            }
            else if (e.Column.FieldName == "Số lượng quy đổi")
            {
                try
                {
                    if (Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng quy đổi").ToString()) > Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng quy đổi gốc").ToString()))
                    {
                        XtraMessageBox.Show("Số lượng quy đổi không được lớn hơn số lượng quy đổi gốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng quy đổi gốc").ToString());
                    }
                    if (caseup == "2")
                    {
                        Double slqd = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng quy đổi").ToString());
                        Double slqdg = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng quy đổi gốc").ToString());
                        Double slg = Double.Parse(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "Số lượng gốc").ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], Math.Round((slqd * slg) / slqdg, 0));
                    }
                }
                catch { }
            }
        }

        private void soluongquydoi_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "2";
        }
        private void soluong_EditValueChanged(object sender, EventArgs e)
        {
            caseup = "1";
        }
        private void view2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn lưu thông tin đã thay đổi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    string idkhach = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                    string makhach = view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString();
                    string tenkhach = view.GetRowCellValue(view.FocusedRowHandle, "Tên khách hàng").ToString();
                    gen.ExcuteNonquery("delete SalarySS where StockID='" + kho + "' and MonthS='" + thang + "' and YearS='" + nam + "' and AccountingObjectID='" + idkhach + "' and EmployeeID='" + idnhanvien + "' ");
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (gridView2.GetRowCellValue(i, "Số lượng").ToString() != "" && gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString() != "")
                        {
                            string idhang = gridView2.GetRowCellValue(i, "ID").ToString();
                            string hoadon = gridView2.GetRowCellValue(i, "Số hóa đơn").ToString();
                            string RefID = gridView2.GetRowCellValue(i, "RefID").ToString();
                            string mahang = gridView2.GetRowCellValue(i, "Mã hàng hóa").ToString();
                            string soluong = gridView2.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                            string soluongqd = gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                            if (Double.Parse(soluongqd) != 0)
                                gen.ExcuteNonquery("insert into SalarySS values(newid(),'" + kho + "','" + thang + "','" + nam + "','" + idkhach + "','" + makhach + "',N'" + tenkhach + "','" + idnhanvien + "','" + nhanvien + "',N'" + tennhanvien + "','" + userid + "','" + soluong + "','" + soluongqd + "',0,'" + RefID + "','" + idhang + "','" + mahang + "','"+hoadon+"')");
                        }
                    }

                    gridControl1.Enabled = true;
                    panelControl2.Visible = false;
                }
            }
            else if (e.KeyCode == Keys.H && e.Modifiers == Keys.Control)
            {
                if (XtraMessageBox.Show("Bạn có chắc không muốn lưu thông tin này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gridControl1.Enabled = true;
                    panelControl2.Visible = false;
                }
            }
        }

        private void baadd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            gen.ExcuteNonquery("delete SalaryList where StockID='" + kho + "' and MonthS='" + thang + "' and YearS='" + nam + "' ");
            for (int i = 0; i < view.RowCount; i++)
            {
                if (view.GetRowCellValue(i, "Chọn").ToString() == "True")
                {
                    string idkhach = view.GetRowCellValue(i, "ID").ToString();
                    string makhach = view.GetRowCellValue(i, "Mã khách hàng").ToString();
                    string tenkhach = view.GetRowCellValue(i, "Tên khách hàng").ToString();
                    string idnhanvien = view.GetRowCellValue(i, "ID nhân viên").ToString();
                    string manhanvien = view.GetRowCellValue(i, "Mã nhân viên").ToString();
                    string tennhanvien = view.GetRowCellValue(i, "Tên nhân viên").ToString();
                    gen.ExcuteNonquery("insert into SalaryList values(newid(),'" + kho + "','" + thang + "','" + nam + "','" + idkhach + "','" + makhach + "',N'" + tenkhach + "','" + idnhanvien + "','" + manhanvien + "',N'" + tennhanvien + "','" + userid + "')");
                }
            }
            baadd.Enabled = false;
            baedit.Enabled = true;
            barPrint.Enabled = true;
            view.Columns["Chọn"].OptionsColumn.AllowEdit = false;
            barBaocaosanluong.Enabled = true;
        }

        private void barBaocaosanluong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(kho);
            F.gettsbt("tsbtbaocaosanluong");
            F.ShowDialog();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_reportmain F = new Frm_reportmain();
            F.getngaychungtu(ngaychungtu);
            F.getuser(kho);
            F.gettsbt("tsbtbaocaoluongsanluong");
            F.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getngaychungtu(ngaychungtu);
            rp.getkho(kho);
            rp.getuserid(userid);
            rp.gettenkho(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
            rp.gettsbt("tsbtbangkeluongthanhtoan");
            rp.Show();
        }

    }
}