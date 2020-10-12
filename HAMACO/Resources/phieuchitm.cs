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
    class phieuchitm
    {
        gencon gen = new gencon();
        public void loadpctm(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Người nhận", Type.GetType("System.String"));
            dt.Columns.Add("Lý do chi", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Duyệt", Type.GetType("System.Boolean"));
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
                if (temp.Rows[i][9].ToString() == "1")
                    dr[9] = true;
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
            view.Columns["Duyệt"].Width = 80;

            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void tsbtpctm(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys, string ngaychungtu,string userid,DataTable khach)
        {
            try
            {
                Frm_phieuthu u = new Frm_phieuthu();
                u.myac = new Frm_phieuthu.ac(F.refreshpctm);
                u.getactive(a);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.getsub(subsys);
                u.getpt("pctm");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                /*try
                {*/
                    if (a == "1")
                        u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                /*}
                catch { }*/
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu chi tiền mặt trước khi sửa."); }
        }
        public void loadstart(CheckEdit cechd, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpkh,
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit nphhd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sotien, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, DataTable dt, string tsbt, ComboBoxEdit cbthue, DataTable khach, string userid, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi, SearchLookUpEdit danhmuc)
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

            temp.Columns.Add("Mã đơn vị");
            temp.Columns.Add("Tên đơn vị");
            //da = gen.GetTable("select * from Stock order by StockCode");
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

            if (DateTime.Parse(ngaychungtu).Year >= 2015)
                da = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            else
                da = gen.GetTable("select AccountNumber,AccountName from Account2014 order by AccountNumber");

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
  
            if(tsbt=="pttm"||tsbt=="pctm")

                da = gen.GetTable("select AccountNumber,AccountName from Account where AccountCategoryID=111 and AccountNumber<>111 order by AccountNumber");
           
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
            if (tsbt == "pttm" || tsbt == "ptnh")
            {
                repositoryItemLookUpEdit1.DataSource = temp1;
                repositoryItemLookUpEdit1.DisplayMember = "Mã tài khoản";
                repositoryItemLookUpEdit1.ValueMember = "Mã tài khoản";
                tkco.DataSource = temp2;
                tkco.DisplayMember = "Mã tài khoản";
                tkco.ValueMember = "Mã tài khoản";
            }
            else
            {       
                tkco.DataSource = temp1;
                tkco.DisplayMember = "Mã tài khoản";
                tkco.ValueMember = "Mã tài khoản";

                repositoryItemLookUpEdit1.DataSource = temp2;
                repositoryItemLookUpEdit1.DisplayMember = "Mã tài khoản";
                repositoryItemLookUpEdit1.ValueMember = "Mã tài khoản";        
            }
            repositoryItemLookUpEdit1.PopupWidth = 200;
            
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


            rpmanganh.DataSource = gen.GetTable("select InventoryCategoryCode as 'Mã ngành',InventoryCategoryName as 'Tên ngành' from InventoryItemCategory where IsParent=0 and Grade=3 and Inactive='False' order by InventoryCategoryCode");
            rpmanganh.DisplayMember = "Mã ngành";
            rpmanganh.ValueMember = "Mã ngành";
            rpmanganh.PopupWidth = 100;

            rpmachiphi.DataSource = gen.GetTable("select GroupCostID as 'Mã chi phí',GroupCost as 'Chi phí' from GroupCost Order by GroupCostID");
            rpmachiphi.DisplayMember = "Chi phí";
            rpmachiphi.ValueMember = "Mã chi phí";
            rpmachiphi.PopupWidth = 200;

            danhmuc.Properties.DataSource = gen.GetTable("SELECT STT,DanhMuc as 'Danh mục',STUFF((SELECT Distinct ' ' + DebitAmout FROM (select * from danhmuc where Phieu='" + tsbt + "') T WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') as 'Tài khoản nợ',STUFF((SELECT Distinct ' ' + CreditAmount FROM (select * from danhmuc where Phieu='" + tsbt + "') T WHERE (STT = S.STT) FOR XML PATH ('')),1,1,'') AS 'Tài khoản có' FROM (select * from danhmuc where Phieu='" + tsbt + "') S GROUP BY STT,DanhMuc");
            danhmuc.Properties.DisplayMember = "Danh mục";
            danhmuc.Properties.ValueMember = "STT";            
           
            danhmuc.Properties.View.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            danhmuc.Properties.View.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            danhmuc.Properties.PopupFormSize = new Size(700, 500);
            danhmuc.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
           
            if (tsbt == "pttm" || tsbt == "ptnh")
            {
                dt.Columns.Add("Tài khoản có");
                dt.Columns.Add("Tài khoản nợ");
            }
            else
            {
                dt.Columns.Add("Tài khoản nợ");
                dt.Columns.Add("Tài khoản có");
            }
            dt.Columns.Add("Ngày phát hành HĐ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số hóa đơn");
            dt.Columns.Add("Loại hóa đơn");
            dt.Columns.Add("Ký hiệu hóa đơn");
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã khách");
            dt.Columns.Add("Diễn giải");
            dt.Columns.Add("Nhóm chi phí");
            dt.Columns.Add("Ghi chú");
            gridControl1.DataSource = dt;     
            gridView1.Columns["Tài khoản nợ"].ColumnEdit = tkco;
            gridView1.Columns["Tài khoản có"].ColumnEdit = repositoryItemLookUpEdit1;
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
          
            cechd.Checked = false;
        }

        public void loadctm(CheckEdit cechd, string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpkh,
            DevExpress.XtraEditors.Repository.RepositoryItemDateEdit nphhd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sotien, Frm_phieuthu F, LookUpEdit ledt, TextEdit txtnn, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, ComboBoxEdit cbthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, string userid, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi, SearchLookUpEdit danhmuc, ToolStripButton toolduyet, LookUpEdit letq,TextEdit txtspt)
            {
                DataTable dt = new DataTable();

                letq.Properties.DataSource = gen.GetTable("select StockCode as 'Mã đơn vị',StockName as 'Tên đơn vị' from Stock order by StockCode ");
                letq.Properties.DisplayMember = "Mã đơn vị";
                letq.Properties.ValueMember = "Mã đơn vị";
                letq.Properties.PopupWidth = 300;    

            loadstart(cechd, gridControl1, gridView1, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, cbthue, khach, userid, rpmanganh, rpmachiphi, danhmuc);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,AccountingObjectCode,InvDate,InvNo,InvSeries,CustomField5,CustomField4 from CAPaymentDetail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
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
                    dr[3] = da.Rows[i][6].ToString();
                    dr[4] = da.Rows[i][7].ToString();
                    dr[5] = da.Rows[i][8].ToString();
                    dr[6] = da.Rows[i][3].ToString();
                    dr[7] = da.Rows[i][4].ToString();
                    dr[8] = da.Rows[i][0].ToString();
                    dr[9] = da.Rows[i][9].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;
                toolduyet.Enabled = false;

                F.Text = "Xem phiếu chi tiền mặt";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,a.RefOrder,ShippingMethodID,EditVersion,a.CustomField5  from CAPayment a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");

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
                txtsct.Text = da.Rows[0][6].ToString();
                cbthue.Text = da.Rows[0][11].ToString();
                danhmuc.EditValue = da.Rows[0][12].ToString();
                if (da.Rows[0][13].ToString() != "")
                    letq.EditValue = gen.GetString("select StockCode from Stock where StockID='" + da.Rows[0][13].ToString() + "'");
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

                if (da.Rows[0][14].ToString() == "1")
                    tsbtcat.Visible = false;

                txtspt.Text = da.Rows[0][15].ToString();

                checktruocsau(tsbttruoc, tsbtsau, txtsct.Text, ngaychungtu, userid);
            }
            else
            {
                /*try
                {*/
                F.Text = "Thêm phiếu chi tiền mặt";
                //themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid,ledv.EditValue.ToString());
                denct.EditValue = DateTime.Parse(ngaychungtu);
                denht.EditValue = DateTime.Parse(ngaychungtu);
                cechd.Checked = true;
                cechd.Checked = false;
                /*}
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }*/
            }
        }
        //save//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void checkpctm(string active, string role, Frm_phieuthu F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
            TextEdit txtnn, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, string userid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, SearchLookUpEdit danhmuc, string duyet, LookUpEdit letq)
            {
                try
                {
                    string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                    string[,] detail = new string[20, 15];
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
                            try
                            {
                                DataTable mk = gen.GetTable("select AccountingObjectID,BranchID from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                                detail[i, 6] = mk.Rows[0][0].ToString();
                                if (gridView1.GetRowCellValue(i, "Tài khoản nợ").ToString() == "141")
                                    detail[i, 8] = "'" + mk.Rows[0][1].ToString() + "'";
                                else detail[i, 8] = "NULL";
                            }
                            catch
                            {
                                detail[i, 6] = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + gridView1.GetRowCellValue(i, "Mã khách").ToString() + "'");
                                detail[i, 8] = "NULL";
                            }
                        }
                        detail[i, 7] = gridView1.GetRowCellValue(i, "Diễn giải").ToString();
                        detail[i, 9] = gridView1.GetRowCellValue(i, "Ký hiệu hóa đơn").ToString();
                        detail[i, 10] = gridView1.GetRowCellValue(i, "Nhóm chi phí").ToString();
                    }
                    if (check == "1")
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Tài khoản có> <Tài khoản nợ> <Số tiền> <Mã Khách> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string dv = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                        string dvtq = gen.GetString("select StockID from Stock where StockCode='" + letq.EditValue.ToString() + "'");
                        string tong = gridView1.Columns["Số tiền"].SummaryText;
                        tong = tong.Replace("Tổng tiền =", "").Trim();
                        tong = tong.Replace(".", "");
                        string ldt;
                        if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                        else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                        else ldt = "2";
                        if (active == "0")
                        {
                            try
                            {
                                string ton = gen.GetString("select * from CAPayment where RefNo='" + txtsct.Text + "'");
                                themsct(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                            }
                            catch { }

                            gen.ExcuteNonquery("insert into CAPayment(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,RefOrder,EditVersion,ShippingMethodID,CustomField5) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "','" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "','" + userid + "','" + danhmuc.EditValue.ToString() + "','" + duyet + "','" + dvtq + "','" + txtsct.Text + "')");
                            string refid = gen.GetString("select * from CAPayment where RefNo='" + txtsct.Text + "'");
                            F.getrole(refid);
                            for (int i = 0; i < gridView1.RowCount - 1; i++)
                            {
                                /*if (detail[i, 2] == "")
                                {
                                    if (detail[i, 8] != "")
                                    {
                                        gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,StockID,CustomField5) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 8] + "','" + detail[i, 9] + "')");
                                    }
                                    else
                                    {
                                        gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,CustomField5) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 9] + "')");
                                    }
                                }
                                else
                                {
                                    if (detail[i, 8] != "")
                                    {*/
                                gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,StockID,CustomField5,CustomField4) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + detail[i, 2] + ",'" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + "," + detail[i, 8] + ",'" + detail[i, 9] + "',N'" + detail[i, 10] + "')");
                                /*}
                                else
                                {
                                    gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,CustomField5) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + ",'" + detail[i, 9] + "')");
                                }
                            }*/
                                if (duyet == "0")
                                    gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,Occupation,GroupCost,Goods) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','113','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "','" + detail[i, 7] + "',N'" + detail[i, 10] + "','" + dvtq + "')");
                                else
                                    gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,Occupation,GroupCost,Goods) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "','" + detail[i, 7] + "',N'" + detail[i, 10] + "','" + dvtq + "')");
                            }
                        }
                        else
                        {
                            if (duyet == "1")
                            {
                                if (gen.GetString("select EditVersion from CAPayment where RefID='" + role + "'") != "1")
                                    themsctmoi(ngaychungtu, txtsct, tsbttruoc, tsbtsau, userid, ledv.EditValue.ToString());
                                tsbtcat.Visible = false;
                            }

                            gen.ExcuteNonquery("update CAPayment set RefNo='" + txtsct.Text + "', RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress='" + txtdc.Text + "',Contactname=N'" + txtnn.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tong + "',Posted='False',Tax='" + cbthue.Text + "',UserID='" + userid + "',RefOrder='" + danhmuc.EditValue.ToString() + "',EditVersion='" + duyet + "',ShippingMethodID='" + dvtq + "'  where RefID='" + role + "'");
                            gen.ExcuteNonquery("delete  from  CAPaymentDetail where RefID='" + role + "'");
                            gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + role + "'");
                            gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                            for (int i = 0; i < gridView1.RowCount - 1; i++)
                            {
                                /*if (detail[i, 2] == "")
                                {
                                    if (detail[i, 8] != "")
                                    {
                                        gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,StockID,CustomField5) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 8] + "','" + detail[i, 9] + "')");
                                    }
                                    else
                                    {
                                        gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,CustomField5) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 9] + "')");
                                    }
                                }
                                else
                                {
                                    if (detail[i, 8] != "")
                                    {*/
                                gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,StockID,CustomField5,CustomField4) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + detail[i, 2] + ",'" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + "," + detail[i, 8] + ",'" + detail[i, 9] + "',N'" + detail[i, 10] + "')");
                                /*}
                                else
                                {
                                    gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,CustomField5) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + ",'" + detail[i, 9] + "')");
                                }
                            }*/
                                if (duyet == "0")
                                    gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,Occupation,GroupCost,Goods) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','113','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "','" + detail[i, 7] + "',N'" + detail[i, 10] + "','" + dvtq + "')");
                                else                                   
                                    gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,Occupation,GroupCost,Goods) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "','" + detail[i, 7] + "',N'" + detail[i, 10] + "','" + dvtq + "')");
                            }
                        }
                        F.myac();
                        F.getactive("1");
                        F.Text = "Xem phiếu chi tiền mặt";
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


        public void tsbtdeletepctm(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from CAPayment where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn hủy phiếu chi tiền mặt " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from CAPayment where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from CAPaymentDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu chi tiền mặt trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieuthu F, string ngay,string userid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from CAPayment where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from CAPayment where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieuthu F, string ngay,string userid)
        {
            try
            {
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from CAPayment where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from CAPayment where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string userid,string kho)
        {
            int dai = 5;
            DataTable da = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string sophieu = null;

            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("05/01/2019"))
            {
                string donvi = gen.GetString("select BranchCode from MSC_User a, Branch b where a.BranchID=b.BranchID and a.UserID='" + userid + "'");
                string nam = "-" + thang + "-" + year.Substring(2, 2);
                sophieu = donvi + "-" + donvi + "-PCTM";

                try
                {
                    string id = gen.GetString("select Top 1 RefNo from CAPayment where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and SUBSTRING(RefNo,1,2)='" + donvi + "' order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;
                }
                catch { sophieu = sophieu + "00001" + nam; }
            }
            else if (DateTime.Parse(ngaychungtu) < DateTime.Parse("06/01/2019"))
            {
                string donvi = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and a.StockCode='" + kho + "'");
                string nam = "-" + thang + "-" + year.Substring(2, 2);
                sophieu = donvi + "-" + kho + "-PTAM";
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from CAPayment where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + gen.GetString("select StockID from Stock where StockCode='" + kho + "'") + "' and substring(RefNo,7,4)='PTAM' order by RefNo DESC");
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
                string donvi = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and a.StockCode='" + kho + "'");
                string nam = "-" + thang + "-" + year.Substring(2, 2);
                sophieu = donvi + "-" + kho + "-PTAM";
                try
                {
                    string id = gen.GetString("select Top 1 CustomField5 from CAPayment where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + gen.GetString("select StockID from Stock where StockCode='" + kho + "'") + "' and substring(RefNo,1,10)='" + sophieu + "' order by CustomField5 DESC");
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
            checktruocsau(tsbttruoc, tsbtsau, sophieu, ngaychungtu,userid);
        }


        public void themsctmoi(string ngaychungtu, TextEdit txtsct, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string userid, string kho)
        {
            int dai = 5;
            DataTable da = new DataTable();
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string sophieu = null;

            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("06/01/2019"))
            {       
                string donvi = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and a.StockCode='" + kho + "'");
                string nam = "-" + thang + "-" + year.Substring(2, 2);
                sophieu = donvi + "-" + kho + "-PCTM";
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from CAPayment where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + gen.GetString("select StockID from Stock where StockCode='" + kho + "'") + "' and substring(RefNo,7,4)='PCTM' order by RefNo DESC");
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
                string donvi = gen.GetString("select BranchCode from MSC_User a, Branch b where a.BranchID=b.BranchID and a.UserID='" + userid + "'");
                string nam = "-" + thang + "-" + year.Substring(2, 2);
                sophieu = donvi + "-" + donvi + "-PCTM";
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from CAPayment where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and EditVersion='1'  order by RefNo DESC");
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

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string sct, string ngaychungtu,string userid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from CAPayment where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from CAPayment where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
