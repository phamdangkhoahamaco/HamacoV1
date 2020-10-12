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
    class uynhiemchi
    {
        gencon gen = new gencon();
        public void loadunc(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Từ", Type.GetType("System.String"));
            dt.Columns.Add("Đến", Type.GetType("System.String"));
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
                dr[10] = temp.Rows[i][10].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[5].Visible = false;

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
            view.Columns["Mã kho"].Width = 100;
            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void tsbtunc(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, DataTable khach)
        {
            try
            {
                Frm_uynhiemchi u = new Frm_uynhiemchi();
                u.myac = new Frm_uynhiemchi.ac(F.refreshunc);
                u.getactive(a);
                u.getsub(subsys);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.getuser(userid);
                u.getdate(ngaychungtu);
                try
                {
                if (a == "1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                catch { }
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn ủy nhiệm chi trước khi sửa."); }
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, LookUpEdit letk, LookUpEdit ledv, DateEdit denct, DateEdit denht, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpkh,
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit nphhd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sotien, LookUpEdit ledt, DataTable dt, ComboBoxEdit cbthue, DataTable khach, string userid, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi, SearchLookUpEdit danhmuc)
        {
            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
            DataTable temp = new DataTable();

            temp.Columns.Add("Mã đơn vị");
            temp.Columns.Add("Tên đơn vị");
           
            da = gen.GetTable("select a.StocKID,StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode ");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp;
            ledv.Properties.DisplayMember = "Mã đơn vị";
            ledv.Properties.ValueMember = "Mã đơn vị";
            ledv.ItemIndex = 0;
            ledv.Properties.PopupWidth = 300;

            DataTable taikhoan = new DataTable();
            da = gen.GetTable("select Description,AccountNameEnglish from Account where DetailByBankAccount=1 and Description<>'' order by AccountNameEnglish,Description");
            taikhoan.Columns.Add("Tài khoản");
            taikhoan.Columns.Add("Ngân hàng");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = taikhoan.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                taikhoan.Rows.Add(dr);
            }
            letk.Properties.DataSource = taikhoan;
            letk.Properties.DisplayMember = "Tài khoản";
            letk.Properties.ValueMember = "Tài khoản";
            letk.Properties.PopupWidth = 300;

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
            tkno.DataSource = temp1;
            tkno.DisplayMember = "Mã tài khoản";
            tkno.ValueMember = "Mã tài khoản";
            tkno.PopupWidth = 300;

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
            tkco.DataSource = temp2;
            tkco.DisplayMember = "Mã tài khoản";
            tkco.ValueMember = "Mã tài khoản";
            tkno.PopupWidth = 300;
          
            DataTable temp3 = new DataTable();
            temp3.Columns.Add("Mã đối tượng");
            temp3.Columns.Add("Tên đối tượng");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp3.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp3.Rows.Add(dr);
            }
            rpkh.DataSource = temp3;
            rpkh.DisplayMember = "Mã đối tượng";
            rpkh.ValueMember = "Mã đối tượng";
            rpkh.PopupWidth = 400;

            ledt.Properties.DataSource = temp3;
            ledt.Properties.DisplayMember = "Mã đối tượng";
            ledt.Properties.ValueMember = "Mã đối tượng";
            ledt.Properties.PopupWidth = 400;


            DataTable temp4 = gen.GetTable("select InventoryCategoryCode as 'Mã ngành',InventoryCategoryName as 'Tên ngành' from InventoryItemCategory where IsParent=0 and Grade=3 order by InventoryCategoryCode");
            rpmanganh.DataSource = temp4;
            rpmanganh.DisplayMember = "Tên ngành";
            rpmanganh.ValueMember = "Mã ngành";
            rpmanganh.PopupWidth = 100;

            temp4 = gen.GetTable("select GroupCostID as 'Mã chi phí',GroupCost as 'Chi phí' from GroupCost Order by GroupCostID");
            rpmachiphi.DataSource = temp4;
            rpmachiphi.DisplayMember = "Chi phí";
            rpmachiphi.ValueMember = "Mã chi phí";
            rpmachiphi.PopupWidth = 200;


            dt.Columns.Add("Tài khoản nợ");
            dt.Columns.Add("Tài khoản có");
            dt.Columns.Add("Ngày phát hành HĐ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số hóa đơn");
            dt.Columns.Add("Loại hóa đơn");
            dt.Columns.Add("Ký hiệu hóa đơn");
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã khách");
            dt.Columns.Add("Diễn giải");
            dt.Columns.Add("Nhóm chi phí");
            gridControl1.DataSource = dt;

            danhmuc.Properties.DataSource = gen.GetTable("SELECT STT,DanhMuc as 'Danh mục',STUFF((SELECT Distinct ' ' + DebitAmout FROM (select * from danhmuc where Phieu='pcnh') T WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') as 'Tài khoản nợ',STUFF((SELECT Distinct ' ' + CreditAmount FROM (select * from danhmuc where Phieu='pcnh') T WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') AS 'Tài khoản có' FROM (select * from danhmuc where Phieu='pcnh') S GROUP BY STT,DanhMuc");
            danhmuc.Properties.DisplayMember = "Danh mục";
            danhmuc.Properties.ValueMember = "STT";

            danhmuc.Properties.View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            danhmuc.Properties.View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            danhmuc.Properties.PopupFormSize = new Size(700, 500);
            danhmuc.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;

            gridView1.Columns["Tài khoản nợ"].ColumnEdit = tkno;
            gridView1.Columns["Tài khoản có"].ColumnEdit = tkco;
            gridView1.Columns["Mã khách"].ColumnEdit = rpkh;
            gridView1.Columns["Ngày phát hành HĐ"].ColumnEdit = nphhd;
            gridView1.Columns["Số tiền"].ColumnEdit = sotien;
            gridView1.Columns["Diễn giải"].ColumnEdit = rpmanganh;
            gridView1.Columns["Nhóm chi phí"].ColumnEdit = rpmachiphi;

            gridView1.Columns["Diễn giải"].Width = 100;
            gridView1.Columns["Diễn giải"].Caption = "Mã ngành";
            gridView1.Columns["Loại hóa đơn"].Caption = "Mẫu số";

            gridView1.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số tiền"].SummaryItem.DisplayFormat = "Tổng tiền = {0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";
        }

     public void loadunc(CheckEdit chvay,CheckEdit cechd, string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit letk, LookUpEdit leth, LookUpEdit ledv, DateEdit denct, DateEdit denht,
     DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpkh,
     DevExpress.XtraEditors.Repository.RepositoryItemDateEdit nphhd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sotien, Frm_uynhiemchi F, LookUpEdit ledt, TextEdit txtnn, TextEdit txtldn, TextEdit txtctg,
     ToolStripButton tsbtsua, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, ComboBoxEdit cbthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, string userid, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi,TextEdit txtunc, SearchLookUpEdit danhmuc)
        {
            chvay.Checked = false;
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, letk, ledv, denct, denht, tkno, tkco, rpkh, nphhd, sotien, ledt, dt, cbthue, khach, userid, rpmanganh, rpmachiphi, danhmuc);
            cechd.Checked = true;
            cechd.Checked = false;  
         if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,AccountingObjectCode,InvDate,InvSeries,InvNo,CustomField5,CustomField4 from BAAccreditativeDetail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][1].ToString();
                    dr[1] = da.Rows[i][2].ToString();
                    if (da.Rows[i][5].ToString() != "")
                    {
                        dr[2] = DateTime.Parse(da.Rows[i][5].ToString());
                        cechd.Checked = true;
                    }
                    dr[3] = da.Rows[i][7].ToString();
                    dr[4] = da.Rows[i][6].ToString();
                    dr[5] = da.Rows[i][8].ToString();
                    dr[6] = da.Rows[i][3].ToString();
                    dr[7] = da.Rows[i][4].ToString();
                    dr[8] = da.Rows[i][0].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,AccountingObjectBankAccount,AccountingObjectBankName,a.CustomField5,EditVersion  from BAAccreditative a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                letk.EditValue = da.Rows[0][12].ToString();
                leth.EditValue = da.Rows[0][1].ToString();
                txtnn.Text = da.Rows[0][13].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                txtctg.Text = da.Rows[0][3].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][6].ToString();
                cbthue.EditValue = da.Rows[0][11].ToString();
                if (da.Rows[0][10].ToString() == "True")
                    chvay.Checked = true;
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
                txtunc.Text = da.Rows[0][14].ToString();
                if (da.Rows[0][15].ToString() == "1")
                    tsbtcat.Visible = false;
                checktruocsau(tsbttruoc, tsbtsau, txtsct.Text, ngaychungtu, userid);
            }
            else
            {
                try
                {
                    themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                    denct.EditValue = DateTime.Parse(ngaychungtu);
                    denht.EditValue = DateTime.Parse(ngaychungtu);
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }
            }
        }



     public void checkunc(string active, string role, Frm_uynhiemchi F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, LookUpEdit letk, LookUpEdit leth, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
         TextEdit txtnn, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, CheckEdit chvay,
         ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, string userid, TextEdit txtthuhuong, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string duyet)
     {
         try
         {
             string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
             if (txtthuhuong.Text == "")
                 txtthuhuong.Text = leth.Text;
             string[,] detail = new string[50, 15];
             string check = "0";
             for (int i = 0; i < gridView1.RowCount - 1; i++)
             {
                 if (gridView1.GetRowCellValue(i, "Tài khoản có").ToString() == "")
                     check = "1";
                 detail[i, 0] = gridView1.GetRowCellValue(i, "Tài khoản có").ToString();
                 if (gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString() == "")
                     check = "1";
                 detail[i, 1] = gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString();

                 detail[i, 2] = "NULL";
                 if (gridView1.GetRowCellValue(i, "Ngày phát hành HĐ").ToString() != "")
                     detail[i, 2] = "'" + gridView1.GetRowCellValue(i, "Ngày phát hành HĐ").ToString() + "'";

                 detail[i, 3] = gridView1.GetRowCellValue(i, "Loại hóa đơn").ToString();
                 detail[i, 4] = gridView1.GetRowCellValue(i, "Số hóa đơn").ToString();
                 if (gridView1.GetRowCellValue(i, "Số tiền").ToString() == "")
                     check = "1";
                 detail[i, 5] = gridView1.GetRowCellValue(i, "Số tiền").ToString().Replace(".", "");

                 if (gridView1.GetRowCellValue(i, "Mã khách").ToString() == "")
                     check = "1";
                 else
                 {
                     string mk = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                     detail[i, 6] = mk;
                 }
                 detail[i, 7] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();
                 detail[i, 8] = gridView1.GetRowCellValue(i, "Ký hiệu hóa đơn").ToString();
                 detail[i, 9] = gridView1.GetRowCellValue(i, "Nhóm chi phí").ToString();
             }
             if (check == "1")
             {
                 DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Tài khoản có> <Tài khoản nợ> <Số tiền> <Mã Khách> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
             else
             {
                 string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                 string tong = gridView1.Columns["Số tiền"].SummaryText;
                 tong = tong.Replace("Tổng tiền =", "").Trim();
                 tong = tong.Replace(".", "");

                 if (active == "0")
                 {
                     try
                     {
                         string ton = gen.GetString("select * from BAAccreditative where RefNo='" + txtsct.Text + "'");
                         themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);
                         XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                     catch { }
                     gen.ExcuteNonquery("insert into BAAccreditative(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectBankAccount,AccountingObjectBankName,TotalAmount,Tax,UserID,Cancel,CustomField5,EditVersion) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtthuhuong.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "',N'" + letk.Text + "',N'" + txtnn.Text + "','" + tong + "','" + cbthue.Text + "','" + userid + "','" + chvay.Checked + "','" + txtsct.Text + "','" + duyet + "')");
                     string refid = gen.GetString("select * from BAAccreditative where RefNo='" + txtsct.Text + "'");
                     F.getrole(refid);
                     for (int i = 0; i < gridView1.RowCount - 1; i++)
                     {
                         /*if (detail[i, 2] == "")
                         {
                             gen.ExcuteNonquery("insert into BAAccreditativeDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,CustomField5) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 8] + "')");
                         }
                         else
                         {*/
                         gen.ExcuteNonquery("insert into BAAccreditativeDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,CustomField5,CustomField4) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + detail[i, 2] + ",'" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + ",'" + detail[i, 8] + "',N'" + detail[i, 9] + "')");
                         //}
                         gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,Occupation,GroupCost) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "',N'" + detail[i, 7] + "',N'" + detail[i, 9] + "')");
                     }
                 }
                 else
                 {
                     if (duyet == "1")
                         if (gen.GetString("select EditVersion from BAAccreditative where RefID='" + role + "'") != "1")
                             themsctmoi(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid);

                     gen.ExcuteNonquery("update BAAccreditative set RefNo='" + txtsct.Text + "', RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtthuhuong.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectBankAccount=N'" + letk.Text + "',AccountingObjectBankName=N'" + txtnn.Text + "',TotalAmount='" + tong + "',Posted='False', Tax='" + cbthue.Text + "',UserID='" + userid + "', Cancel='" + chvay.Checked + "',EditVersion=" + duyet + "  where RefID='" + role + "'");
                     gen.ExcuteNonquery("delete  from  BAAccreditativeDetail where RefID='" + role + "'");
                     gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + role + "'");
                     gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                     for (int i = 0; i < gridView1.RowCount - 1; i++)
                     {
                         /*if (detail[i, 2] == "")
                         {
                             gen.ExcuteNonquery("insert into BAAccreditativeDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,CustomField5) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 8] + "')");
                         }
                         else
                         {*/
                         gen.ExcuteNonquery("insert into BAAccreditativeDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,CustomField5,CustomField4) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + detail[i, 2] + ",'" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + ",'" + detail[i, 8] + "',N'" + detail[i, 9] + "')");
                         //}
                         gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,Occupation,GroupCost) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "',N'" + detail[i, 7] + "',N'" + detail[i, 9] + "')");
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

     public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_uynhiemchi F, string ngay, string userid)
     {
         try
         {
             tsbtsau.Enabled = true;
             string id;
             if (vt == 0)
                 id = gen.GetString("select Top 1 * from BAAccreditative where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo DESC");
             else
             {
                 id = gen.GetString("select Top 1 * from BAAccreditative where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo ASC");
                 tsbttruoc.Enabled = false;
             }
             F.getrole(id);
         }
         catch
         {
             tsbttruoc.Enabled = false;
         }
     }

     public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_uynhiemchi F, string ngay, string userid)
     {
         try
         {
             tsbttruoc.Enabled = true;
             string id;
             if (vt == 0)
                 id = gen.GetString("select Top 1 * from BAAccreditative where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')  order by RefNo ASC");
             else
             {
                 id = gen.GetString("select Top 1 * from BAAccreditative where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo DESC");
                 tsbtsau.Enabled = false;
             }
             F.getrole(id);
         }
         catch
         {
             tsbtsau.Enabled = false;
         }
     }

     public void themsct(string ngaychungtu, TextEdit txtsct, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string userid)
     {
         int dai = 5;
         DataTable da = new DataTable();
         string thang = DateTime.Parse(ngaychungtu).Month.ToString();
         if (thang.Length < 2) thang = "0" + thang;
         string year = DateTime.Parse(ngaychungtu).Year.ToString();
         string nam = "-" + thang + "-" + year.Substring(2, 2);
         string sophieu = null;
         if (DateTime.Parse(ngaychungtu) < DateTime.Parse("06/01/2019"))
         {
             sophieu = "08-08-UNCH";
             try
             {
                 string id = gen.GetString("select Top 1 RefNo from BAAccreditative where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'  order by RefNo DESC");
                 int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                 for (int i = 0; i < dai - ct.ToString().Length; i++)
                 {
                     sophieu = sophieu + "0";
                 }
                 sophieu = sophieu + ct.ToString() + nam;
             }
             catch { sophieu = sophieu + "00001" + nam; }
         }
         else
         {
             sophieu = "08-08-UTAM";
             try
             {
                 string id = gen.GetString("select Top 1 CustomField5 from BAAccreditative where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'  order by CustomField5 DESC");
                 int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                 for (int i = 0; i < dai - ct.ToString().Length; i++)
                 {
                     sophieu = sophieu + "0";
                 }
                 sophieu = sophieu + ct.ToString() + nam;
             }
             catch { sophieu = sophieu + "00001" + nam; }
         }
         txtsct.Text = sophieu;
         checktruocsau(tsbttruoc, tsbtsau, sophieu, ngaychungtu, userid);
     }


     public void themsctmoi(string ngaychungtu, TextEdit txtsct, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string userid)
     {
         int dai = 5;
         DataTable da = new DataTable();
         string thang = DateTime.Parse(ngaychungtu).Month.ToString();
         if (thang.Length < 2) thang = "0" + thang;
         string year = DateTime.Parse(ngaychungtu).Year.ToString();
         string nam = "-" + thang + "-" + year.Substring(2, 2);
         string sophieu = "08-08-UNCH";
         try
         {
             string id = gen.GetString("select Top 1 RefNo from BAAccreditative where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and EditVersion='1'  order by RefNo DESC");
             int ct = Int32.Parse(id.Substring(10, dai)) + 1;
             for (int i = 0; i < dai - ct.ToString().Length; i++)
             {
                 sophieu = sophieu + "0";
             }
             sophieu = sophieu + ct.ToString() + nam;
         }
         catch { sophieu = sophieu + "00001" + nam; }     
         txtsct.Text = sophieu;
         checktruocsau(tsbttruoc, tsbtsau, sophieu, ngaychungtu, userid);
     }

     public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string sct, string ngaychungtu, string userid)
     {
         try
         {
             tsbtsau.Enabled = true;
             string id = gen.GetString("select Top 1 * from BAAccreditative where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')");
         }
         catch
         {
             tsbtsau.Enabled = false;
         }
         try
         {
             tsbttruoc.Enabled = true;
             string id = gen.GetString("select Top 1 * from BAAccreditative where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')");
         }
         catch
         {
             tsbttruoc.Enabled = false;
         }
     }

     public void tsbtdeleteunc(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
     {
         try
         {
             string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
             if (gen.GetString("select Posted from BAAccreditative where RefID='" + name + "'") == "True")
             {
                 XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
             }
             if (XtraMessageBox.Show("Bạn có chắc muốn hủy ủy nhiệm chi " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
             {
                 gen.ExcuteNonquery("delete from BAAccreditativeDetail where RefID='" + name + "'");
                 gen.ExcuteNonquery("delete from BAAccreditative where RefID='" + name + "'");
                 gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + name + "'");
                 gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                 view.DeleteRow(view.FocusedRowHandle);
             }
         }
         catch { XtraMessageBox.Show("Vui lòng chọn ủy nhiệm chi trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
     }

    }
}
