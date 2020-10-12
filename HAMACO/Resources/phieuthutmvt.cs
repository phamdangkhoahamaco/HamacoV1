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
    class phieuthutmvt
    {
        gencon gen = new gencon();

        public void changetabpttmvt(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view, string tsbt)
        {
            try
            {
                lvinfo.Clear();
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();               
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 300);
                lvinfo.View = View.Details;
                if (tsbt == "tsbtpttmvt")
                    da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,StockName  from SUCAReceipt a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + info + "'");
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
                if (tsbt == "tsbtpttmvt")
                    da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,InventoryItemName,Quantity,a.SalePrice,InventoryItemCode from SUCAReceiptDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + info + "' order by SortOrder");
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
                    item2.SubItems.Add(da.Rows[i][7].ToString()+" - "+da.Rows[i][4].ToString());
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

        public void loadpttmvt(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
                        Double cth, thue=0, gtgt, tong;
                        cth = Double.Parse(temp.Rows[i][22].ToString());
                        try
                        {
                            thue = Double.Parse(temp.Rows[i][32].ToString());
                        }
                        catch { }
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

                string makho = gen.GetString("select StockCode from Stock where StockID='"+temp.Rows[i][25].ToString()+"'");
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

        public void tsbtpttmvt(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid,string subsys,string ngaychungtu,string userid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieuthuvt u = new Frm_phieuthuvt();
                u.myac = new Frm_phieuthuvt.ac(F.refreshpttmvt);
                u.getactive(a);
                u.getsub(subsys);
                u.getkhach(khach);
                u.gethang(hang);
                u.getuser(userid);
                u.getroleid(roleid);
                u.getpt("pttmvt");
                u.getdate(ngaychungtu);
                /*try
                {*/
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
                /*}
                catch { }*/
                u.ShowDialog();
           }
            catch { MessageBox.Show("Vui lòng chọn phiếu thu tiền mặt bán vật tư trước khi sửa."); }
        }


        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, DataTable dt, string tsbt, ComboBoxEdit cbthue,DataTable khach,DataTable hang)
        {
            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
            cbldt.SelectedIndex = 0;

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            DataTable temp = new DataTable();

            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            

            da = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
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
            if (tsbt == "pttmvt" || tsbt == "pctmvt")
                da = gen.GetTable("select AccountNumber,AccountName from Account where (AccountCategoryID=111 or AccountCategoryID=331) and AccountNumber<>111 order by AccountNumber");
            else if (tsbt == "ptnhvt" || tsbt == "pcnhvt")
                da = gen.GetTable("select AccountNumber,AccountName from Account where AccountCategoryID=112 and AccountNumber<>112 order by AccountNumber");
            else
                da = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
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
            if (tsbt == "pttmvt" || tsbt == "ptnhvt")
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

            if (tsbt == "pttmvt" || tsbt == "ptnhvt")
            {
                dt.Columns.Add("Tài khoản có");
                dt.Columns.Add("Tài khoản nợ");
            }
            else
            {
                dt.Columns.Add("Tài khoản nợ");
                dt.Columns.Add("Tài khoản có");
            }
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            gridControl1.DataSource = dt;

            gridView1.Columns["Tài khoản nợ"].ColumnEdit = tkco;
            gridView1.Columns["Tài khoản có"].ColumnEdit = tkno;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Thành tiền"].Width = 200;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
        }

        public void loadtmvt(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieuthuvt F, LookUpEdit ledt, TextEdit txtnn, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, ComboBoxEdit cbthue, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txtcth, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,DataTable khach,DataTable hang)
            {
            DataTable dt = new DataTable();          
            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, tkno, tkco, mahang, soluong,dongia, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, cbthue,khach,hang);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  DebitAccount,CreditAccount,Amount,InventoryItemCode,a.SalePrice,Quantity from SUCAReceiptDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][1].ToString();
                    dr[1] = da.Rows[i][0].ToString();
                    dr[2] = da.Rows[i][3].ToString();
                    dr[3] = da.Rows[i][5].ToString();
                    dr[4] = da.Rows[i][4].ToString();
                    dr[5] = da.Rows[i][2].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu thu tiền mặt bán vật tư";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,InvDate,InvSeries,InvNo  from SUCAReceipt a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][9].ToString());
                }
                catch { }
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtnn.Text = da.Rows[0][1].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                txtctg.Text = da.Rows[0][3].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.EditValue = da.Rows[0][6].ToString();
                txtshd.Text = da.Rows[0][14].ToString();
                try
                {
                    txtnhd.EditValue = DateTime.Parse(da.Rows[0][12].ToString());
                }
                catch { txtnhd.Text = ""; }
                txtkhhd.Text = da.Rows[0][13].ToString();
                try
                {
                    cbthue.Text = da.Rows[0][11].ToString();
                }
                catch { }
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
                    F.Text = "Thêm phiếu thu tiền mặt bán vật tư";
                    if (role==null)
                        ledv.ItemIndex = 0;
                    else ledv.EditValue = role;
                    denct.EditValue = DateTime.Parse(ngaychungtu);
                    denht.EditValue = DateTime.Parse(ngaychungtu);
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
        public void checkpttmvt(string active, string role, Frm_phieuthuvt F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
            TextEdit txtnn, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, string userid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 8];
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
                        check = "1";
                    detail[i,5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                }
                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Tài khoản có> <Tài khoản nợ> <Mã hàng> <Số lượng> <Đơn giá> <Thành tiền> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string tong = gridView1.Columns["Thành tiền"].SummaryText;
                    tong = tong.Replace(".", "");
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";
                    string nhd=txtnhd.Text;
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from SUCAReceipt where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct,ledv.EditValue.ToString(),tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch {}
                        if (nhd == "")
                        {
                            gen.ExcuteNonquery("insert into SUCAReceipt(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,EmployeeID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "','" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "','"+userid+"')");
                            
                        }
                        else
                        {
                            gen.ExcuteNonquery("insert into SUCAReceipt(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,InvDate,InvSeries,InvNo,EmployeeID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "','" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "','" + txtnhd.EditValue.ToString() + "','" + txtkhhd.Text + "','" + txtshd.Text + "','"+userid+"')");
                        }
                        string refid = gen.GetString("select * from SUCAReceipt where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {                         
                            gen.ExcuteNonquery("insert into SUCAReceiptDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,SalePrice) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Goods) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + dv + "')");
                        }
                    }
                    else
                    {
                       
                        if (nhd == "")
                        {
                            gen.ExcuteNonquery("update SUCAReceipt set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress='" + txtdc.Text + "',Contactname=N'" + txtnn.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tong + "',Posted='False',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',EmployeeID='"+userid+"'  where RefID='" + role + "'");
                        }
                        else
                        {
                            gen.ExcuteNonquery("update SUCAReceipt set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress='" + txtdc.Text + "',Contactname=N'" + txtnn.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tong + "',Posted='False',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='"+userid+"'  where RefID='" + role + "'");
                        }
                        gen.ExcuteNonquery("delete  from  SUCAReceiptDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into SUCAReceiptDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,SalePrice) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Goods) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + dv + "')");
                        }
                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu thu tiền mặt bán vật tư";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void tsbtdeletepttmvt(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from SUCAReceipt where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu thu tiền mặt bán vật tư " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                     gen.ExcuteNonquery("delete from SUCAReceipt where RefID='" + name + "'");
                     gen.ExcuteNonquery("delete from SUCAReceiptDetail where RefID='" + name + "'");
                     gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                     view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update SUCAReceipt set Cancel='True', Posted='True' where RefID='" + name + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hủy"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số tiền"], "0");*/
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu thu tiền mặt bán vật tư trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieuthuvt F, string ngay,string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SUCAReceipt where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='"+idkho+"' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from SUCAReceipt where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieuthuvt F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SUCAReceipt where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from SUCAReceipt where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct,string mk,ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='"+mk+"'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2,2);
            string sophieu = "08-"+mk+"-PTVT";
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from SUCAReceipt where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='"+idkho+"'  order by RefNo DESC");
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

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,string mk,string sct,string ngaychungtu)
        {
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            try
            {          
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from SUCAReceipt where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from SUCAReceipt where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
