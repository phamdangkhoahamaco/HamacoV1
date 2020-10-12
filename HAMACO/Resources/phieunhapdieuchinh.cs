using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;


namespace HAMACO.Resources
{
    class phieunhapdieuchinh
    {
        gencon gen = new gencon();

        public void changetabpndc(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view, string tsbt)
        {
            try
            {
                lvinfo.Clear();
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 300);
                lvinfo.View = View.Details;
                if (tsbt == "tsbtpndc")
                    da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,StockName  from INAdjustment a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + info + "'");
                else if (tsbt == "tsbtptnhvt")
                    da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,StockName  from SUBADeposit a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + info + "'");
                else if (tsbt == "tsbtpctmvt")
                    da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,StockName  from SUCAPayment a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + info + "'");
                else if (tsbt == "tsbtpcnhvt")
                    da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,StockName  from SUBATransfer a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + info + "'");
                ListViewItem item1;
                item1 = new ListViewItem("Số chứng từ");
                item1.SubItems.Add(da.Rows[0][6].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Ngày chứng từ");
                string ng;
                DateTime ngay;
                ngay = DateTime.Parse(da.Rows[0][4].ToString());
                ng = String.Format("{0:dd/MM/yyyy}", ngay);
                item1.SubItems.Add(ng);
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Ngày hạch toán");
                ngay = DateTime.Parse(da.Rows[0][5].ToString());
                ng = String.Format("{0:dd/MM/yyyy}", ngay);
                item1.SubItems.Add(ng);
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Kho");
                item1.SubItems.Add(da.Rows[0][7].ToString() + " - " + da.Rows[0][11].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Đối tượng");
                item1.SubItems.Add(da.Rows[0][0].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Người nộp");
                item1.SubItems.Add(da.Rows[0][1].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Lý do nộp");
                item1.SubItems.Add(da.Rows[0][2].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Chứng từ gốc");
                item1.SubItems.Add(da.Rows[0][3].ToString());
                lvinfo.Items.Add(item1);
                item1 = new ListViewItem("Số tiền");
                item1.SubItems.Add(view.GetRowCellDisplayText(view.FocusedRowHandle, "Số tiền").ToString());
                lvinfo.Items.Add(item1);
                gen.ResizeListViewColumns(lvuser);

                lvuser.Clear();
                lvuser.Columns.Add("Tài khoản có", 180);
                lvuser.Columns.Add("Tài khoản nợ", 180);
                lvuser.Columns.Add("Mã hàng", 180);
                lvuser.Columns.Add("Số lượng ", 180);
                lvuser.Columns.Add("Đơn giá", 180);
                lvuser.Columns.Add("Thành tiền", 180);
                lvuser.View = View.Details;
                if (tsbt == "tsbtpndc")
                    da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,InventoryItemName,Quantity,a.SalePrice,InventoryItemCode from INAdjustmentDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + info + "' order by SortOrder");
                else if (tsbt == "tsbtptnhvt")
                    da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,InventoryItemName,Quantity,a.SalePrice,InventoryItemCode from SUBADepositDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + info + "' order by SortOrder");
                else if (tsbt == "tsbtpctmvt")
                    da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,InventoryItemName,Quantity,a.SalePrice,InventoryItemCode from SUCAPaymentDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + info + "' order by SortOrder");
                else if (tsbt == "tsbtpcnhvt")
                    da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,InventoryItemName,Quantity,a.SalePrice,InventoryItemCode from SUBATransferDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + info + "' order by SortOrder");
                ListViewItem item2;
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    item2 = new ListViewItem(da.Rows[i][2].ToString());
                    item2.SubItems.Add(da.Rows[i][1].ToString());
                    item2.SubItems.Add(da.Rows[i][7].ToString() + " - " + da.Rows[i][4].ToString());
                    item2.SubItems.Add(String.Format("{0:n0}", Double.Parse(da.Rows[i][5].ToString())));
                    item2.SubItems.Add(String.Format("{0:n0}", Double.Parse(da.Rows[i][6].ToString())));
                    item2.SubItems.Add(String.Format("{0:n0}", Double.Parse(da.Rows[i][3].ToString())));
                    lvuser.Items.Add(item2);
                }
                lvuser.Columns[3].TextAlign = HorizontalAlignment.Right;
                lvuser.Columns[4].TextAlign = HorizontalAlignment.Right;
                gen.ResizeListViewColumns(lvuser);
            }
            catch
            {
                lvinfo.Clear();
                lvuser.Clear();
            }
        }

        public void loadpndc(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hạch toán", Type.GetType("System.DateTime"));
            dt.Columns.Add("Đối tượng", Type.GetType("System.String"));
            dt.Columns.Add("Người nộp", Type.GetType("System.String"));
            dt.Columns.Add("Lý do nộp", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Hủy", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][4].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][6].ToString();
                dr[5] = temp.Rows[i][8].ToString();
                dr[6] = temp.Rows[i][9].ToString();

                if (temp.Rows[i][31].ToString() == "True")
                {
                    dr[7] = "0";
                    dr[8] = "True";
                }
                else
                {
                    if (temp.Rows[i][32].ToString() != "" && temp.Rows[i][32].ToString() != "0")
                    {
                        Double cth, thue, gtgt, tong;
                        cth = Double.Parse(temp.Rows[i][22].ToString());
                        thue = Double.Parse(temp.Rows[i][32].ToString());
                        gtgt = (cth / 100) * thue;
                        tong = cth + gtgt;
                        dr[7] = tong.ToString();
                    }
                    else
                    {
                        dr[7] = temp.Rows[i][22].ToString();
                    }
                    dr[8] = "False";
                }
                string makho = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][25].ToString() + "'");
                dr[9] = makho;

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
            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.OptionsView.ShowFooter = true;
            view.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Hủy"].Width = 100;

            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void tsbtpndc(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid,string subsys, string ngaychungtu, string userid,string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieudieuchinh u = new Frm_phieudieuchinh();
                u.myac = new Frm_phieudieuchinh.ac(F.refreshpndc);
                u.getactive(a);
                u.getsub(subsys);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getpt("pndc");
                u.getbranch(branchid);
                u.getuser(userid);
                u.getdate(ngaychungtu);
                
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
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập điều chỉnh trước khi sửa."); }
        }


        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, LookUpEdit ledv, DateEdit denct, DateEdit denht, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, DataTable dt, string tsbt,string userid,DataTable khach,DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi)
        {
           
            DataTable da = new DataTable();
            DataTable temp = new DataTable();
            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            temp.Columns.Add("Tên đơn vị");
            da = gen.GetTable("select StockCode, StockName,BranchName from Stock a, Branch b where a.BranchID=b.BranchID and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode,BranchName");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                dr[2] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 400;

           
            /*DataTable temp4 = new DataTable(); 
            temp4.Columns.Add("Mã đối tượng");
            temp4.Columns.Add("Tên đối tượng");
            if (tsbt == "pnhkm" || tsbt == "pxhkm")
            {
                da = gen.GetTable("select * from AccountingObject order by AccountingObjectCode");
            }
            else
            {
                da = gen.GetTable("select * from AccountingObject where IsEmployee='True' order by AccountingObjectCode");
            }
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp4.Rows.Add(dr);
            }
            ledt.Properties.DataSource = temp4;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;*/
            DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã đối tượng");
            temp4.Columns.Add("Tên đối tượng");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp4.Rows.Add(dr);
            }
            ledt.Properties.DataSource = temp4;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;

            da = gen.GetTable("select AccountNumber,AccountName from Account where AccountCategoryID<>131 order by AccountNumber");
            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã tài khoản");
            temp1.Columns.Add("Tên tài khoản");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp1.Rows.Add(dr);
            }

            da = gen.GetTable("select AccountNumber,AccountName from Account where AccountCategoryID=156 order by AccountNumber");
            DataTable temp2 = new DataTable();
            temp2.Columns.Add("Mã tài khoản");
            temp2.Columns.Add("Tên tài khoản");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp2.Rows.Add(dr);
            }

            if (tsbt == "pndc" || tsbt == "pnht" || tsbt == "pnhkm")
            {
                tkno.DataSource = temp1;
                tkno.DisplayMember = "Mã tài khoản";
                tkno.ValueMember = "Mã tài khoản";

                tkco.DataSource = temp2;
                tkco.DisplayMember = "Mã tài khoản";
                tkco.ValueMember = "Mã tài khoản";
            }
            else
            {
                tkco.DataSource = temp1;
                tkco.DisplayMember = "Mã tài khoản";
                tkco.ValueMember = "Mã tài khoản";

                tkno.DataSource = temp2;
                tkno.DisplayMember = "Mã tài khoản";
                tkno.ValueMember = "Mã tài khoản";
            }

            /*da = gen.GetTable("select InventoryItemCode,InventoryItemName from InventoryItem order by InventoryItemCode");
            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã hàng");
            temp3.Columns.Add("Tên hàng");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp3.Rows.Add(dr);
            }
            mahang.DataSource = temp3;
            mahang.DisplayMember = "Mã hàng";
            mahang.ValueMember = "Mã hàng";*/
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

            if (tsbt == "pndc" || tsbt == "pnht" || tsbt == "pnhkm")
            {
                dt.Columns.Add("Tài khoản có");
                dt.Columns.Add("Tài khoản nợ");
            }
            else
            {
                dt.Columns.Add("Tài khoản nợ");
                dt.Columns.Add("Tài khoản có");
            }


            DataTable temp5 = gen.GetTable("select InventoryCategoryCode as 'Mã ngành',InventoryCategoryName as 'Tên ngành' from InventoryItemCategory where IsParent=0 and Grade=3 and Inactive='False' order by InventoryCategoryCode");
            rpmanganh.DataSource = temp5;
            rpmanganh.DisplayMember = "Mã ngành";
            rpmanganh.ValueMember = "Mã ngành";
            rpmanganh.PopupWidth = 100;

            temp5 = gen.GetTable("select GroupCostID as 'Mã chi phí',GroupCost as 'Chi phí' from GroupCost Order by GroupCostID");
            rpmachiphi.DataSource = temp5;
            rpmachiphi.DisplayMember = "Chi phí";
            rpmachiphi.ValueMember = "Mã chi phí";
            rpmachiphi.PopupWidth = 200;

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã ngành");
            dt.Columns.Add("Nhóm chi phí");
            dt.Columns.Add("Ca");
            dt.Columns.Add("Tài xế");
            dt.Columns.Add("Số xe");
            dt.Columns.Add("Số KM", Type.GetType("System.Double"));

            gridControl1.DataSource = dt;

            tkno.PopupWidth = 400;
            tkco.PopupWidth = 400;
            mahang.PopupWidth = 400;

            gridView1.Columns["Tài khoản nợ"].ColumnEdit = tkco;
            gridView1.Columns["Tài khoản có"].ColumnEdit = tkno;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;
            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Thành tiền"].Width = 200;
            gridView1.Columns["Mã ngành"].ColumnEdit = rpmanganh;
            gridView1.Columns["Nhóm chi phí"].ColumnEdit = rpmachiphi;

            gridView1.Columns["Số KM"].ColumnEdit = soluong;
           
            gridView1.Columns["Mã ngành"].Width = 100;
            gridView1.Columns["Nhóm chi phí"].Width = 100;

            gridView1.Columns["Ca"].Width = 50;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Số KM"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số KM"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Ca"].Visible = false;
            gridView1.Columns["Tài xế"].Visible = false;
            gridView1.Columns["Số xe"].Visible = false;
            gridView1.Columns["Số KM"].Visible = false;

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
        }

        public void loadpndc(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieudieuchinh F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txtcth, string userid, string branchid, TextEdit txtms, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, userid, khach, hang, rpmanganh, rpmachiphi);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  DebitAccount,CreditAccount,Amount,InventoryItemCode,a.UnitPrice,Quantity,QuantityConvert,Description,CustomField5 from INAdjustmentDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][1].ToString();
                    dr[1] = da.Rows[i][0].ToString();
                    dr[2] = da.Rows[i][3].ToString();
                    dr[3] = da.Rows[i][5].ToString();
                    dr[4] = da.Rows[i][6].ToString();
                    dr[5] = da.Rows[i][4].ToString();
                    dr[6] = da.Rows[i][2].ToString();
                    dr[7] = da.Rows[i][7].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;

                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu nhập điều chỉnh";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,InvDate,InvSeries,InvNo,No  from INAdjustment a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.EditValue = da.Rows[0][6].ToString();
                txtshd.Text = da.Rows[0][14].ToString();
                txtms.Text = da.Rows[0][15].ToString();
                try
                {
                    txtnhd.EditValue = DateTime.Parse(da.Rows[0][12].ToString());
                }
                catch { txtnhd.Text = ""; }
                txtkhhd.Text = da.Rows[0][13].ToString();
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
                txtcth.Text = gridView1.Columns["Thành tiền"].SummaryText;
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                try
                {
                    F.Text = "Thêm phiếu nhập điều chỉnh";
                    if (role == null)
                        ledv.ItemIndex = 0;
                    else ledv.EditValue = role;
                    denct.EditValue = DateTime.Parse(ngaychungtu);
                    denht.EditValue = DateTime.Parse(ngaychungtu);
                    txtnhd.EditValue = DateTime.Parse(ngaychungtu);
                    txtcth.Text = gridView1.Columns["Thành tiền"].SummaryText;
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }
            }
        }
        //save//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void checkpndc(string active, string role, Frm_phieudieuchinh F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname,
            TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, string userid, string branchid, TextEdit txtms, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[100, 10];
                string check = "0";
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Tài khoản có").ToString() == "")
                        check = "1";
                    detail[i, 0] = gridView1.GetRowCellValue(i, "Tài khoản có").ToString();
                    if (gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString() == "")
                        check = "1";
                    detail[i, 1] = gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString();
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                    {
                        string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detail[i, 2] = mh;
                    }
                    if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 3] = "0";
                    else
                        detail[i, 3] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        detail[i, 4] = "0";
                    else
                        detail[i, 4] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",",".");

                    detail[i, 7] = gridView1.GetRowCellValue(i, "Mã ngành").ToString();
                    detail[i, 8] = gridView1.GetRowCellValue(i, "Nhóm chi phí").ToString();
                }
                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Tài khoản có> <Tài khoản nợ> <Mã hàng> <Số lượng> <Đơn giá> <Thành tiền> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string tong = gridView1.Columns["Thành tiền"].SummaryText.Replace(".", "");
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INAdjustment where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(),branchid,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into INAdjustment(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + tong + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','"+txtms.Text+"')");
                        string refid = gen.GetString("select * from INAdjustment where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INAdjustmentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert,Description,CustomField5) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Occupation,GroupCost) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                        }
                    }
                    else
                    {
                        gen.ExcuteNonquery("update INAdjustment set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',JournalMemo=N'" + txtldn.Text + "',StockID='" + dv + "',TotalAmount='" + tong + "',Posted='False',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='" + userid + "',No='"+txtms.Text+"'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  INAdjustmentDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INAdjustmentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert,Description,CustomField5) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Occupation,GroupCost) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                        }
                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu nhập điều chỉnh";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void tsbtdeletepndc(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from INAdjustment where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu nhập điều chỉnh " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INAdjustmentDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INAdjustment where RefID='" + name + "'");                    
                    gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update INAdjustment set Cancel='True', Posted='True' where RefID='" + name + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hủy"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số tiền"], "0");*/
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu nhập điều chỉnh trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieudieuchinh F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INAdjustment where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INAdjustment where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieudieuchinh F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INAdjustment where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INAdjustment where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string dv = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = dv+"-" + mk + "-PNDC";
           
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INAdjustment where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
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

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string mk, string sct, string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from INAdjustment where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INAdjustment where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
