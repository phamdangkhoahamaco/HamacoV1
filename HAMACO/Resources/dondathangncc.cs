using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace HAMACO.Resources
{
    class dondathangncc
    {
        gencon gen = new gencon();
        public void loadddh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string ngaychungtu, string userid)
        {
            //string sql = "select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,JournalMemo,StockCode,TotalAmount,TotalAmountOC,TotalAmount+TotalAmountOC,RefType,Cancel,IsImportPurchase,IsExport,CustomField2 from DDHNCC a, Stock b where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo";
            string sql = "select a.*,b.RefNo from (select RefID,RefNo,RefDate,PostedDate,AccountingObjectName,JournalMemo,StockCode,TotalAmount,TotalAmountOC,TotalAmount+TotalAmountOC as tien,RefType,Cancel,IsImportPurchase,IsExport,CustomField2 from DDHNCC a, Stock b where a.StockID=b.StockID and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')) a left join INOutward b on a.RefNo=b.CustomField5 order by a.RefNo";
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hạch toán", Type.GetType("System.DateTime"));
            dt.Columns.Add("Nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền thuế", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Loại hàng", Type.GetType("System.String"));
            dt.Columns.Add("Thanh toán", Type.GetType("System.String"));
            dt.Columns.Add("Duyệt", Type.GetType("System.Boolean"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.Boolean"));
            dt.Columns.Add("Phiếu xuất", Type.GetType("System.String"));
            dt.Columns.Add("Người duyệt", Type.GetType("System.String"));
            
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
                dr[8] = temp.Rows[i][8].ToString();
                dr[9] = temp.Rows[i][9].ToString();

                if (temp.Rows[i][10].ToString() == "0")
                    dr[10] = "Hàng gửi";
                else if (temp.Rows[i][10].ToString() == "1")
                    dr[10] = "Nhập kho";
                else if (temp.Rows[i][10].ToString() == "2")
                    dr[10] = "Giao thẳng";
                else if (temp.Rows[i][10].ToString() == "3")
                    dr[10] = "Cắt hàng";

                if (temp.Rows[i][11].ToString() == "True")
                    dr[11] = "Trả ngay";
                else
                    dr[11] = "Trả chậm";

                if (temp.Rows[i][12].ToString() == "True")
                    dr[12] = "True";
                else
                    dr[12] = "False";

                if (temp.Rows[i][13].ToString() == "True")
                    dr[13] = "True";
                else
                    dr[13] = "False";

                dr[14] = temp.Rows[i][15].ToString();
                dr[15] = temp.Rows[i][14].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày chứng từ"].Width = 100;
            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hạch toán"].Width = 100;
            view.Columns["Ngày hạch toán"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Tiền hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tiền hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tiền thuế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền thuế"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Tiền thuế"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền thuế"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Loại hàng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Thanh toán"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Ngày hạch toán"].Caption = "Dự kiến nhận";

            view.Columns["Số chứng từ"].Width = 150;
            view.Columns["Loại hàng"].Width = 100;
            view.Columns["Thanh toán"].Width = 100;
            view.Columns["Duyệt"].Width = 50;
            view.Columns["Hóa đơn"].Width = 100;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void tsbtddhncc(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_ddhncc u = new Frm_ddhncc();
                u.myac = new Frm_ddhncc.ac(F.refreshddhncc);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getpt("ddhncc");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.gethang(hang);
               
                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else
                {
                    try
                    {
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString());
                    }
                    catch
                    {
                        u.getrole(gen.GetString("select Top 1 StockCode from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode"));
                    }
                }
                
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi sửa."); }
        }

        public void tsbtddhnccchuyen(string a,string sochungtu,string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang, string phuongtien, string taixe,string cmnd)
        {
            try
            {
                Frm_ddhncc u = new Frm_ddhncc();
                u.getactive(a);
                u.getroleid(roleid);
                u.getphuongtien(phuongtien);
                u.getsub(subsys);
                u.getpt("ddhncc");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getkhach(khach);
                u.getphieu(sochungtu);
                u.gethang(hang);
                u.gettaixe(taixe);
                u.getcmnd(cmnd);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập kho trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, SearchLookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DataTable dtton, DevExpress.XtraGrid.GridControl ton, GridView viewton, ComboBoxEdit cbthue)
        {
            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            DataTable temp = new DataTable();

            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = dt.Rows[i].Field<string>("StockCode");                
                dr[1] = dt.Rows[i].Field<string>("StockName");
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;

           
            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã hàng");
            temp3.Columns.Add("Tên hàng");
            for (int i = 0; i < hang.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = hang.Rows[i][1].ToString();
                dr[1] = hang.Rows[i][2].ToString();
                temp3.Rows.Add(dr);
            }
            mahang.DataSource = temp3;
            mahang.DisplayMember = "Mã hàng";
            mahang.ValueMember = "Mã hàng";
            mahang.PopupWidth = 300;
            
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Bó", Type.GetType("System.Double"));

            dt.Columns.Add("Số lượng đặt", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng đặt", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));           
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("CK sản lượng", Type.GetType("System.Double"));
            dt.Columns.Add("CK thanh toán", Type.GetType("System.Double"));
            dt.Columns.Add("CK trực tiếp", Type.GetType("System.Double"));
            dt.Columns.Add("CK ngắn hạn", Type.GetType("System.Double"));
            dt.Columns.Add("CK vùng", Type.GetType("System.Double"));
            dt.Columns.Add("Hỗ trợ CT", Type.GetType("System.Double"));
            dt.Columns.Add("Hỗ trợ VC", Type.GetType("System.Double"));
            dt.Columns.Add("CK khác", Type.GetType("System.Double"));


            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Bó"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Trọng lượng"].ColumnEdit = soluongqd;

            gridView1.Columns["Số lượng đặt"].ColumnEdit = soluong;
            gridView1.Columns["Trọng lượng đặt"].ColumnEdit = soluongqd;

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;           
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;

            gridView1.Columns["CK sản lượng"].ColumnEdit = dongia;
            gridView1.Columns["CK thanh toán"].ColumnEdit = dongia;
            gridView1.Columns["CK trực tiếp"].ColumnEdit = dongia;
            gridView1.Columns["CK ngắn hạn"].ColumnEdit = dongia;
            gridView1.Columns["CK vùng"].ColumnEdit = dongia;
            gridView1.Columns["Hỗ trợ CT"].ColumnEdit = dongia;
            gridView1.Columns["Hỗ trợ VC"].ColumnEdit = dongia;
            gridView1.Columns["CK khác"].ColumnEdit = dongia;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng đặt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng đặt"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["CK sản lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["CK sản lượng"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["CK thanh toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["CK thanh toán"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["CK trực tiếp"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["CK trực tiếp"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["CK ngắn hạn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["CK ngắn hạn"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["CK vùng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["CK vùng"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Hỗ trợ CT"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Hỗ trợ CT"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Hỗ trợ VC"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Hỗ trợ VC"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["CK khác"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["CK khác"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Trọng lượng đặt"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Trọng lượng đặt"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Số lượng đặt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng đặt"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Trọng lượng đặt"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Trọng lượng đặt"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";


            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView1.Columns["Bó"].AppearanceCell.BackColor = System.Drawing.Color.SeaShell;
            gridView1.Columns["Số lượng đặt"].AppearanceCell.BackColor = System.Drawing.Color.SeaShell;
            gridView1.Columns["Trọng lượng đặt"].AppearanceCell.BackColor = System.Drawing.Color.SeaShell;


            dtton.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dtton.Columns.Add("Tên hàng");
            dtton.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dtton.Columns.Add("Trọng lượng", Type.GetType("System.Double"));            
            ton.DataSource = dtton;

            viewton.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewton.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            viewton.Columns["Trọng lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            viewton.Columns["Trọng lượng"].DisplayFormat.FormatString = "{0:n2}";

            viewton.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewton.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            viewton.Columns["Trọng lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            viewton.Columns["Trọng lượng"].SummaryItem.DisplayFormat = "{0:n2}";
            viewton.Columns["Tên hàng"].Width = 160;
            viewton.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            viewton.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
        }

        public void loadddh(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_ddhncc F, SearchLookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DevExpress.XtraGrid.GridControl ton, GridView viewton, ComboBoxEdit cbthue, TextEdit txtghichu, TextEdit txtptgh, TextEdit txthn, CheckEdit chduyet, RadioGroup hangnhap, RadioGroup tracham, TextEdit txtcth, TextEdit txtthue,LabelControl lbduyet,TextEdit txtcmnd)
        {
            DataTable dt = new DataTable();
            DataTable dtton = new DataTable();
            loadstart(gridControl1, gridView1, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, khach, hang, dongia, thanhtien, dtton, ton, viewton, cbthue);
            if (active == "1")
            {
                DataTable da = new DataTable();

                da = gen.GetTable("select  InventoryItemCode,InventoryItemName,a.ConvertRate,UnitPriceOC,UnitPriceConvertOC,Quantity,QuantityConvert,a.UnitPrice,Amount,a.UnitPriceConvert,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits from DDHNCCDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][1].ToString();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][3].ToString();                   
                    dr[4] = da.Rows[i][4].ToString();
                    dr[5] = da.Rows[i][5].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = da.Rows[i][7].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    try
                    {
                        dr[10] = da.Rows[i][10].ToString();
                        dr[11] = da.Rows[i][11].ToString();
                        dr[12] = da.Rows[i][12].ToString();
                        dr[13] = da.Rows[i][13].ToString();
                        dr[14] = da.Rows[i][14].ToString();
                        dr[15] = da.Rows[i][15].ToString();
                        dr[16] = da.Rows[i][16].ToString();
                    }
                    catch { }
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,CustomField9,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,RefType,CustomField2,CustomField3 from DDHNCC a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
               
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                cbthue.EditValue = da.Rows[0][12].ToString();
                try
                {
                    txtldn.Text = da.Rows[0][2].ToString();
                }
                catch { }
                txtctg.Text = da.Rows[0][3].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();
                txtptgh.Text = da.Rows[0][16].ToString();
                txtghichu.Text = da.Rows[0][17].ToString();
                txthn.EditValue = Double.Parse(da.Rows[0][18].ToString());
                txtcth.EditValue = Double.Parse(da.Rows[0][13].ToString());
                txtthue.EditValue = Double.Parse(da.Rows[0][14].ToString());

                if (da.Rows[0][19].ToString() == "True")
                    chduyet.Checked = true;
                else
                    chduyet.Checked = false;

                if (da.Rows[0][10].ToString() == "True")
                    tracham.SelectedIndex = 1;
                else
                    tracham.SelectedIndex = 0;

                hangnhap.SelectedIndex = Int32.Parse(da.Rows[0][20].ToString());
                lbduyet.Text = da.Rows[0][21].ToString();
                txtcmnd.Text = da.Rows[0][22].ToString();

                if (da.Rows[0][8].ToString() == "True")
                {
                    tsbtghiso.Visible = false;
                    tsbtboghi.Visible = true;
                    tsbtsua.Enabled = false;
                }
                else
                {
                    tsbtboghi.Visible = false;
                    tsbtghiso.Visible = true;
                }
                if (da.Rows[0][10].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    tsbtghiso.Enabled = false;
                }
                
               
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                F.Text = "Thêm đơn đặt hàng";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                cbthue.EditValue = "10";
                hangnhap.SelectedIndex = 1;
                tracham.SelectedIndex = 0;
                lbduyet.Text = "";
                denht.EditValue = DateTime.Parse(ngaychungtu);
                denct.EditValue = DateTime.Parse(ngaychungtu);
            }
        }

        public void checkpxk(string active, string role, Frm_ddhncc F, GridView gridView1, SearchLookUpEdit ledt, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ComboBoxEdit cbthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txttthue, TextEdit txtptgh, RadioGroup tracham, RadioGroup hangnhap, TextEdit ghichu, TextEdit hanno, CheckEdit duyet, TextEdit txtcmnd,SearchLookUpEdit lehg, string lbduyet)
        {
            
            try
            {
                string dt = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                
                string[,] detail = new string[100, 20];
                string check = "0";
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                    {
                        string mh = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detail[i, 0] = mh;
                    }
                    
                    if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 1] = "0";
                    else
                        detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Trọng lượng").ToString() == "")
                        check = "1";
                    detail[i, 2] = gridView1.GetRowCellValue(i, "Trọng lượng").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Bó").ToString() == "")
                        detail[i, 3] = "0";
                    else
                        detail[i, 3] = gridView1.GetRowCellValue(i, "Bó").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 4] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "CK sản lượng").ToString() == "")
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = gridView1.GetRowCellValue(i, "CK sản lượng").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 6] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");

                    if (gridView1.GetRowCellValue(i, "CK thanh toán").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = gridView1.GetRowCellValue(i, "CK thanh toán").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "CK trực tiếp").ToString() == "")
                        detail[i, 8] = "0";
                    else
                        detail[i, 8] = gridView1.GetRowCellValue(i, "CK trực tiếp").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "CK ngắn hạn").ToString() == "")
                        detail[i, 9] = "0";
                    else
                        detail[i, 9] = gridView1.GetRowCellValue(i, "CK ngắn hạn").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "CK vùng").ToString() == "")
                        detail[i, 10] = "0";
                    else
                        detail[i, 10] = gridView1.GetRowCellValue(i, "CK vùng").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Hỗ trợ CT").ToString() == "")
                        detail[i, 11] = "0";
                    else
                        detail[i, 11] = gridView1.GetRowCellValue(i, "Hỗ trợ CT").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Hỗ trợ VC").ToString() == "")
                        detail[i, 12] = "0";
                    else
                        detail[i, 12] = gridView1.GetRowCellValue(i, "Hỗ trợ VC").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "CK khác").ToString() == "")
                        detail[i, 13] = "0";
                    else
                        detail[i, 13] = gridView1.GetRowCellValue(i, "CK khác").ToString().Replace(".", "").Replace(",", ".");

                    if (gridView1.GetRowCellValue(i, "Số lượng đặt").ToString() == "")
                        detail[i, 14] = "0";
                    else
                        detail[i, 14] = gridView1.GetRowCellValue(i, "Số lượng đặt").ToString().Replace(".", "").Replace(",", ".");
                    
                    if (gridView1.GetRowCellValue(i, "Trọng lượng đặt").ToString() == "")
                        detail[i, 15] = "0";
                    else
                        detail[i, 15] = gridView1.GetRowCellValue(i, "Trọng lượng đặt").ToString().Replace(".", "").Replace(",", ".");
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.getloi("1");
                    return;
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");

                    string tongthanhtien = Math.Round(Double.Parse(gridView1.Columns["Thành tiền"].SummaryText)).ToString().Replace(".", "");                    
                    string thue = txttthue.EditValue.ToString().Replace(".", "");
                    
                    string nguoiduyet = null;
                    if (duyet.Checked == true && lbduyet == "")
                        nguoiduyet = gen.GetString("select FullName from MSC_User where UserID='" + userid + "'");
                    else if (duyet.Checked == true && lbduyet != "")
                        nguoiduyet = lbduyet;

                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from DDHNCC where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid, tsbttruoc, tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }

                        gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'" + hangnhap.SelectedIndex + "','" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "',N'" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tongthanhtien + "','" + thue + "','" + tracham.SelectedIndex + "',N'" + txtptgh.Text + "',N'" + ghichu.Text + "'," + hanno.EditValue.ToString() + ",'" + duyet.Checked + "',N'" + nguoiduyet + "','" + txtcmnd.Text + "')");
                        
                        string refid = gen.GetString("select * from DDHNCC where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 3] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 4] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "')");
                        }
                    }
                    else
                    {
                        gen.ExcuteNonquery("update DDHNCC set RefType='" + hangnhap.SelectedIndex + "',RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',Posted='False',ShippingNo=N'" + txtptvc.Text + "',CustomField9='" + cbthue.Text + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue + "',Cancel='" + tracham.SelectedIndex + "',CustomField6=N'" + txtptgh.Text + "',CustomField1=N'" + ghichu.Text + "',ExchangeRate=" + hanno.EditValue.ToString() + ",IsImportPurchase='" + duyet.Checked + "',CustomField2=N'" + nguoiduyet + "',CustomField3='" + txtcmnd.Text + "' where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  DDHNCCDetail where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 3] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 4] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "','" + detail[i, 9] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + detail[i, 13] + "','" + detail[i, 14] + "','" + detail[i, 15] + "')");
                        }
                    }
                    F.getactive("1");
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-DDHN";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from DDHNCC where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, mk, sophieu, ngaychungtu);
        }

        public void tsbtdeletepnk(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                
                if (view.GetRowCellValue(view.FocusedRowHandle, "Duyệt").ToString() == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được duyệt không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (view.GetRowCellValue(view.FocusedRowHandle, "Hóa đơn").ToString() == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được chuyển hóa đơn không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (gen.GetString("select Posted from DDHNCC where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn đặt hàng " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from DDHNCC where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from DDHNCCDetail where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }                 
              
            }
            catch { XtraMessageBox.Show("Vui lòng chọn đơn đặt hàng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_ddhncc F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from DDHNCC where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from DDHNCC where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_ddhncc F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from DDHNCC where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from DDHNCC where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from DDHNCC where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from DDHNCC where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
        
    }
}
