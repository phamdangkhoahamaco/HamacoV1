﻿using System;
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
    class phieunhaphangthua
    {
        gencon gen = new gencon();

        public void loadpnht(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Thuế", Type.GetType("System.String"));

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

                dr[10] = temp.Rows[i][32].ToString();

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
            view.Columns["Hủy"].Visible = false;
            view.Columns["Thuế"].Width = 100;
            view.Columns["Thuế"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void tsbtpnht(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieudieuchinh u = new Frm_phieudieuchinh();
                u.myac = new Frm_phieudieuchinh.ac(F.refreshpnht);
                u.getactive(a);
                u.getsub(subsys);
                u.gethang(hang);
                u.getkhach(khach);
                u.getroleid(roleid);
                u.getpt("pnht");
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
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập hàng thừa trước khi sửa."); }
        }

        public void tsbtpnhtchuyen(string a, string ma ,string roleid, string subsys, string ngaychungtu, string userid, string branchid, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_phieudieuchinh u = new Frm_phieudieuchinh();
                u.getactive(a);
                u.getsub(subsys);
                u.gethang(hang);
                u.getkhach(khach);
                u.getroleid(roleid);
                u.getpt("pnht");
                u.getbranch(branchid);
                u.getuser(userid);
                u.getdate(ngaychungtu);
                u.getphieu(ma);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập hàng thừa trước khi sửa."); }
        }

        public void loadpnht(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieudieuchinh F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txtcth, string userid, string branchid, TextEdit txtms, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi, TextEdit txtthuesuat)
        {
            DataTable dt = new DataTable();
            phieunhapdieuchinh pndc = new phieunhapdieuchinh();
            pndc.loadstart(gridControl1, gridView1, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, userid, khach, hang, rpmanganh, rpmachiphi);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  DebitAccount,CreditAccount,Amount,InventoryItemCode,a.UnitPrice,Quantity,QuantityConvert,a.Description,a.CustomField5 from INSurplusDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
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

                F.Text = "Xem phiếu nhập hàng thừa";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,InvDate,InvSeries,InvNo,No  from INSurplus a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");

                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.EditValue = da.Rows[0][6].ToString();
                txtshd.Text = da.Rows[0][14].ToString();
                txtms.Text = da.Rows[0][15].ToString();

                txtthuesuat.Text = da.Rows[0][11].ToString();

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
                    F.Text = "Thêm phiếu nhập hàng thừa";
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
        public void checkpnht(string active, string role, Frm_phieudieuchinh F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname,
            TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, string userid, string branchid, TextEdit txtms, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtthuesuat )
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[50, 10];
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
                        detail[i, 6] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");

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
                    Double thue = 0;
                    if (txtthuesuat.Text != "")
                        thue = Double.Parse(txtthuesuat.Text);
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INSurplus where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into INSurplus(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,Tax,TotalVATAmount) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + tong + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','" + txtms.Text + "','" + txtthuesuat.Text + "','" + Math.Round(Double.Parse(tong) * thue / 100, 0) + "')");
                        string refid = gen.GetString("select * from INSurplus where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INSurplusDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert,Description,CustomField5) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Occupation,GroupCost) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                        }
                        if (txtthuesuat.Text != "")
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Occupation,GroupCost) values(newid(),'" + refid + "','" + txtsct.Text + "','1331','331','" + Math.Round(Double.Parse(tong) * thue / 100, 0) + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','','')");
                    }
                    else
                    {
                        gen.ExcuteNonquery("update INSurplus set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',JournalMemo=N'" + txtldn.Text + "',StockID='" + dv + "',TotalAmount='" + tong + "',Posted='False',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='" + userid + "',No='" + txtms.Text + "', Tax='" + txtthuesuat.Text + "',TotalVATAmount='" + Math.Round(Double.Parse(tong) * thue / 100, 0) + "'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  INSurplusDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INSurplusDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert,Description,CustomField5) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 6] + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Occupation,GroupCost) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + detail[i, 7] + "','" + detail[i, 8] + "')");
                        }
                        if (txtthuesuat.Text != "")
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,Occupation,GroupCost) values(newid(),'" + role + "','" + txtsct.Text + "','1331','331','" + Math.Round(Double.Parse(tong) * thue / 100, 0) + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','','')");
                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu nhập hàng thừa";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void tsbtdeletepnht(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from INSurplus where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu nhập hàng thừa " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INSurplusDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INSurplus where RefID='" + name + "'");                 
                    gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update INSurplus set Cancel='True', Posted='True' where RefID='" + name + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hủy"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số tiền"], "0");*/
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu nhập hàng thừa trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieudieuchinh F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INSurplus where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INSurplus where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
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
                    id = gen.GetString("select Top 1 * from INSurplus where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INSurplus where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
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
            string sophieu = dv + "-" + mk + "-PNHT";
           
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INSurplus where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from INSurplus where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INSurplus where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }


        public void loadstock(DevExpress.XtraGrid.GridControl lvpq, GridView view,string ngaychungtu, string userid,string tsbt)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt=new DataTable();
            DataTable temp= new DataTable();

            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));

                temp = gen.GetTable("tonghopphieuxuatnhap '"+thang+"','"+nam+"','"+tsbt+"','"+userid+"'");

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0];
                    dr[1] = temp.Rows[i][1];
                    dr[2] = temp.Rows[i][2];
                    dt.Rows.Add(dr);
                }
                lvpq.DataSource = dt;
                view.OptionsBehavior.Editable = false;
                view.OptionsSelection.EnableAppearanceFocusedCell = false;
                view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                view.Columns[0].Visible = false;
                view.Columns["Mã kho"].Width = 40;
                view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        public void loadchitiet(string ngaychungtu, string userid, string tsbt,string loai,string kho,string congty)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            
            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Nợ", Type.GetType("System.String"));
            dt.Columns.Add("Có", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt.Columns.Add("Khách hàng", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));

            temp = gen.GetTable("tonghopphieuxuatnhapchitiet '" + thang + "','" + nam + "','" + tsbt + "','" + userid + "'," + loai + ",'" + kho + "'");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                dr[1] = temp.Rows[i][1];
                dr[2] = temp.Rows[i][9];
                dr[3] = temp.Rows[i][2];
                dr[4] = temp.Rows[i][3];
                dr[5] = temp.Rows[i][8];
                if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                    dr[10] = temp.Rows[i][6];
                if (temp.Rows[i][12].ToString() == "0")
                {
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                        dr[6] = temp.Rows[i][5];
                    if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                        dr[7] = temp.Rows[i][7];
                }
                else
                {
                    if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                        dr[8] = temp.Rows[i][5];
                    if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                        dr[9] = temp.Rows[i][7];
                }
                dr[11] = (temp.Rows[i][10].ToString() + " - " + temp.Rows[i][11].ToString()).ToUpper();
                dr[12] = temp.Rows[i][13];
                dr[13] = "HĐ: "+temp.Rows[i][14];
                dt.Rows.Add(dr);
            }
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.gettsbt(tsbt);
            F.getrole(ngaychungtu);
            F.getcongty(congty);
            F.getda(dt);
            F.gethoten(kho);
            F.Show();
        }

        public void loadtong(string ngaychungtu, string userid, string tsbt, string congty)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();

            dt.Columns.Add("Tên kho", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền nhập", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng xuất", Type.GetType("System.Double"));
            dt.Columns.Add("Số tiền xuất", Type.GetType("System.Double"));

            temp = gen.GetTable("tonghopphieuxuatnhapchitiet '" + thang + "','" + nam + "','" + tsbt + "','" + userid + "',2,''");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString() + " - " + temp.Rows[i][1].ToString();
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[1] = temp.Rows[i][2];
                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[2] = temp.Rows[i][3];
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[3] = temp.Rows[i][4];
                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                    dr[4] = temp.Rows[i][5];
               
                dt.Rows.Add(dr);
            }
            Frm_rpthuchi F = new Frm_rpthuchi();
            F.gettsbt(tsbt+"tong");
            F.getrole(ngaychungtu);
            F.getcongty(congty);
            F.getda(dt);
            F.Show();
        }

    }
}
