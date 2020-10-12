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
    class phieunhaphangbantralai
    {
        gencon gen = new gencon();

        public void changetabpndc(ListView lvinfo, ListView lvuser, DevExpress.XtraGrid.Views.Grid.GridView view, string tsbt)
        {
            try
            {
                view.OptionsView.ColumnAutoWidth = true;
                lvinfo.Clear();
                DataTable da = new DataTable();
                string info = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                lvinfo.Columns.Add("", 180);
                lvinfo.Columns.Add("", 300);
                lvinfo.View = View.Details;
                if (tsbt == "tsbtpndc")
                    da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,StockName  from INReInward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + info + "'");
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
                    da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,InventoryItemName,Quantity,a.SalePrice,InventoryItemCode from INReInwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + info + "' order by SortOrder");
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

        public void loadpnhbtl(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
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
                        dr[7] = Double.Parse(temp.Rows[i][22].ToString()) + Double.Parse(temp.Rows[i][24].ToString());
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

        public void tsbtpnhbtl(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieunhaphangbantralai u = new Frm_phieunhaphangbantralai();
                u.myac = new Frm_phieunhaphangbantralai.ac(F.refreshpnhbtl);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.gethang(hang);
                u.getkhach(khach);
                u.getpt("pntl");
                u.getbranch(branchid);
                u.getuser(userid);
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
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập hàng bán trả lại trước khi sửa."); }
        }

        public void tsbtchonhd(Frm_phieunhaphangbantralai F, LookUpEdit ledt, string ngaychungtu, string branchid)
        {
            try
            {
                Frm_chonhoadon u = new Frm_chonhoadon();
                u.myac = new Frm_chonhoadon.ac(F.gethoadon);
                u.getdate(ngaychungtu);
                string mk = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                u.getmk(mk);
                u.getbranch(branchid);
                u.getform(F);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn đối tượng trước khi chọn hóa đơn."); }
        }


        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, LookUpEdit ledv, DateEdit denct, DateEdit denht, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, DataTable dt, string tsbt, string userid, ComboBoxEdit cbthue,DataTable khach,DataTable hang)
        {
            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            DataTable temp = new DataTable();
            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            temp.Columns.Add("Tên đơn vị");
            da = gen.GetTable("select StockCode, StockName,BranchName from Stock a, Branch b where a.BranchID=b.BranchID and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by BranchName,StockCode");
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


           /* DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã đối tượng");
            temp4.Columns.Add("Tên đối tượng");
            da = gen.GetTable("select * from AccountingObject order by AccountingObjectCode");
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
   
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá phí", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            gridControl1.DataSource = dt;

            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Đơn giá phí"].ColumnEdit = chiphi;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;
            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Thành tiền"].Width = 200;

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

            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá phí"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Đơn giá phí"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
            gridView1.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;

            gridView1.Columns[5].Visible = false;
        }

        public void loadpnhbtl(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieunhaphangbantralai F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txtcth, TextEdit txtthue,string userid, string branchid, TextEdit txtms, ComboBoxEdit cbthue, ButtonEdit bthd, CheckEdit ckhd, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,DataTable khach,DataTable hang)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, ledv, denct, denht, mahang, soluong, soluongqd, dongia,chiphi, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, userid,cbthue,khach,hang);
            if (active == "1")
            {
                tsbtcat.Enabled = false;
                DataTable da = new DataTable();
               
                F.Text = "Xem phiếu nhập hàng bán trả lại";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,InvDate,InvSeries,InvNo,No,RefIn,CheckIn,TotalVATAmount  from INReInward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");

                
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                F.gethd(da.Rows[0][16].ToString());
                txtldn.Text = da.Rows[0][2].ToString();                
                bthd.EditValue = da.Rows[0][16].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.EditValue = da.Rows[0][6].ToString();
                cbthue.EditValue = da.Rows[0][11].ToString();
                Double Tienthue = Double.Parse(da.Rows[0][18].ToString());
                
                if (da.Rows[0][17].ToString() == "True")
                {
                    ckhd.Checked = true;
                    try
                    {
                        txtnhd.EditValue = DateTime.Parse(da.Rows[0][12].ToString());
                    }
                    catch { txtnhd.Text = ""; }
                    txtshd.Text = da.Rows[0][14].ToString();
                    txtms.Text = da.Rows[0][15].ToString();
                    txtkhhd.Text = da.Rows[0][13].ToString();
                }
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
                
                da = gen.GetTable("select  Amount,InventoryItemCode,a.UnitPrice,a.UnitPriceCost,Quantity,QuantityConvert from INReInwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    for (int j = 0; j < gridView1.RowCount; j++)
                    {
                        if (gridView1.GetRowCellValue(j, "Mã hàng").ToString() == da.Rows[i][1].ToString())
                        {
                            gridView1.SetRowCellValue(j, gridView1.Columns["Thành tiền"], da.Rows[i][0].ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Số lượng"], da.Rows[i][4].ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Số lượng quy đổi"], da.Rows[i][5].ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Đơn giá"], da.Rows[i][2].ToString());
                            gridView1.SetRowCellValue(j, gridView1.Columns["Đơn giá phí"], da.Rows[i][3].ToString());
                        }
                    }
                }

                txtcth.Text = gridView1.Columns["Thành tiền"].SummaryText;
                txtthue.Text = String.Format("{0:n0}", Tienthue);
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                try
                {
                    F.Text = "Thêm phiếu nhập hàng bán trả lại";
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
        public void checkpndc(string active, string role, Frm_phieunhaphangbantralai F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname,
            TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, string userid, string branchid, TextEdit txtms, ComboBoxEdit cbthue, CheckEdit ckhd, string hoadon, TextEdit txtthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 8];
 
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() != "")
                    {
                        detail[i, 0] = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                            detail[i, 1] = "0";
                        else
                            detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                        if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                            detail[i, 2] = "0";
                        else
                            detail[i, 2] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                        if (gridView1.GetRowCellValue(i, "Đơn giá phí").ToString() == "")
                            detail[i, 3] = "0";
                        else
                            detail[i, 3] = gridView1.GetRowCellValue(i, "Đơn giá phí").ToString().Replace(".", "").Replace(",", ".");
                        if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                            detail[i, 4] = "0";
                        else
                            detail[i, 4] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                        if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                            detail[i, 5] = "0";
                        else
                            detail[i, 5] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                    }
                }
               
                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    string tong = gridView1.Columns["Thành tiền"].SummaryText.Replace(".", "");
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INReInward where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into INReInward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,Tax,CheckIn,RefIn,TotalVATAmount) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + tong + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','" + txtms.Text + "','" + cbthue.EditValue.ToString() + "','" + ckhd.Checked.ToString() + "','" + hoadon + "','"+txtthue.Text.Replace(".","")+"')");
                        string refid = gen.GetString("select * from INReInward where RefNo='" + txtsct.Text + "'");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1561','632','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','"+dt+"')");
                        /*gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate) values(newid(),'" + refid + "','" + txtsct.Text + "','531','131','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate) values(newid(),'" + refid + "','" + txtsct.Text + "','33311','131','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "')");*/
                        F.getrole(refid);
                        if (ckhd.Checked == true)
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                try
                                {
                                    gen.ExcuteNonquery("insert into INReInwardDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,UnitPriceCost,QuantityConvert) values(newid(),'" + refid + "',1561,632,'" + detail[i, 4] + "','" + detail[i, 1] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 5] + "')");
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                try
                                {
                                    gen.ExcuteNonquery("insert into INReInwardDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,UnitPriceCost,QuantityConvert,DebitAccountIn,CreditAccountIn) values(newid(),'" + refid + "',1561,632,'" + detail[i, 4] + "','" + detail[i, 1] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 5] + "',531,632)");
                                }
                                catch{}
                            }
                        }

                    }
                    else
                    {
                        gen.ExcuteNonquery("update INReInward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',JournalMemo=N'" + txtldn.Text + "',StockID='" + dv + "',TotalAmount='" + tong + "',Posted='False',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='" + userid + "',No='" + txtms.Text + "',Tax='" + cbthue.EditValue.ToString() + "',CheckIn='" + ckhd.Checked.ToString() + "',RefIn='" + hoadon + "',TotalVATAmount='"+txtthue.Text.Replace(".","")+"'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  INReInwardDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','156','632','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','"+dt+"')");
                        /*gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate) values(newid(),'" + role + "','" + txtsct.Text + "','531','131','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate) values(newid(),'" + role + "','" + txtsct.Text + "','33311','131','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "')");*/
                        if (ckhd.Checked == true)
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                try
                                {
                                    gen.ExcuteNonquery("insert into INReInwardDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,UnitPriceCost,QuantityConvert) values(newid(),'" + role + "',1561,632,'" + detail[i, 4] + "','" + detail[i, 1] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 5] + "')");
                                }
                                catch { }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                try
                                {
                                    gen.ExcuteNonquery("insert into INReInwardDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,UnitPriceCost,QuantityConvert,DebitAccountIn,CreditAccountIn) values(newid(),'" + role + "',1561,632,'" + detail[i, 4] + "','" + detail[i, 1] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 5] + "',531,632)");
                                }
                                catch { }
                            }
                        }
                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu nhập hàng bán trả lại";
                
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
                if (gen.GetString("select Posted from INReInward where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu hàng bán trả lại" + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INReInward where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INReInwardDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update INReInward set Cancel='True', Posted='True' where RefID='" + name + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hủy"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số tiền"], "0");*/
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu thu tiền mặt bán vật tư trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhaphangbantralai F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INReInward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INReInward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhaphangbantralai F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INReInward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INReInward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
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
            string sophieu = dv + "-" + mk + "-HBTL";
           
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INReInward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from INReInward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INReInward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
