using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace HAMACO.Resources
{
    class phieuketoan
    {
        gencon gen = new gencon();
        public void loadpkt(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Người thực hiện", Type.GetType("System.String"));
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
            view.BestFitColumns();
        }

        public void tsbtpkt(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys,string ngaychungtu,string userid,DataTable khach)
        {
            try
            {
                Frm_phieuthu u = new Frm_phieuthu();
                u.myac = new Frm_phieuthu.ac(F.refreshpkt);
                u.getactive(a);
                u.getuser(userid);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.getsub(subsys);
                u.getdate(ngaychungtu);
                u.getpt("pkt");
                /*try
                {*/
                if(a=="1")
                    u.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                /*}
                catch { }*/
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu kế toán trước khi sửa."); }
        }


        public void loadpkt(CheckEdit cechd, string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
    DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpkh,
    DevExpress.XtraEditors.Repository.RepositoryItemDateEdit nphhd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit sotien, Frm_phieuthu F, LookUpEdit ledt, TextEdit txtnn, TextEdit txtldn, TextEdit txtctg,
    ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, ComboBoxEdit cbthue, TextEdit txthtt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, DataTable khach, string userid, ToolStripButton tsbtkc, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi,SearchLookUpEdit danhmuc)
        {
            DataTable dt = new DataTable();
            phieuchitm ctm = new phieuchitm();
            ctm.loadstart(cechd, gridControl1, gridView1, cbldt, ledv, denct, denht, repositoryItemLookUpEdit1, tkco, rpkh, nphhd, sotien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, cbthue, khach, userid, rpmanganh, rpmachiphi, danhmuc);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  a.Description,DebitAccount,CreditAccount,Amount,AccountingObjectCode,InvDate,InvSeries,InvNo,CustomField5,CustomField4 from GLVoucherDetail a,AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
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
                 tsbtkc.Enabled = false;
                F.Text = "Xem phiếu kế toán";

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,ExDate,a.PostVersion  from GLVoucher a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");
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
                danhmuc.EditValue = da.Rows[0][13].ToString();
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
                try
                {
                    txthtt.Text = da.Rows[0][12].ToString();
                }
                catch { }
                checktruocsau(tsbttruoc, tsbtsau, txtsct.Text, ngaychungtu,userid);
            }
            else
            {
                try
                {
                    F.Text = "Thêm phiếu kế toán";
                    themsct(ngaychungtu, txtsct,tsbttruoc,tsbtsau,userid);
                    denct.EditValue = DateTime.Parse(ngaychungtu);
                    denht.EditValue = DateTime.Parse(ngaychungtu);
                    cechd.Checked = true;
                    cechd.Checked = false;
                    txthtt.EditValue = 0;
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }
            }
        }

//save//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void checkpkt(string active, string role, Frm_phieuthu F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
            TextEdit txtnn, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, TextEdit txthtt, string userid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, ToolStripButton tsbtkc,SearchLookUpEdit danhmuc)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[100, 11];
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
                    detail[i, 5] = gridView1.GetRowCellValue(i, "Số tiền").ToString().Replace(".","");

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
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Tài khoản có> <Tài khoản nợ> <Số tiền> <Mã Khách> !", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {

                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
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
                            string ton = gen.GetString("select * from GLVoucher where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct,tsbttruoc,tsbtsau,userid);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        catch{}
                        if (txthtt.Text == "")
                            gen.ExcuteNonquery("insert into GLVoucher(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,PostVersion) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "','" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "','" + userid + "','" + danhmuc.EditValue.ToString() + "')");
                        else
                            gen.ExcuteNonquery("insert into GLVoucher(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,ExDate,UserID,PostVersion) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "','" + txtdc.Text + "',N'" + txtnn.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + tong + "','" + cbthue.Text + "'," + txthtt.Text + ",'" + userid + "','" + danhmuc.EditValue.ToString() + "')");
                        string refid = gen.GetString("select * from GLVoucher where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            /*if (detail[i, 2] == "")
                            {

                                gen.ExcuteNonquery("insert into GLVoucherDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,CustomField5) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 8] + "')");
                            }
                            else
                            {*/
                            gen.ExcuteNonquery("insert into GLVoucherDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,CustomField5,CustomField4) values(newid(),'" + refid + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + detail[i, 2] + ",'" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + ",'" + detail[i, 8] + "',N'" + detail[i, 9] + "')");
                            //}
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,ExDate,Occupation,GroupCost) values(newid(),'" + refid + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "'," + txthtt.Text + ",'" + detail[i, 7] + "',N'" + detail[i, 9] + "')");
                        }
                    }
                    else
                    {
                        if (txthtt.Text == "")
                            gen.ExcuteNonquery("update GLVoucher set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress='" + txtdc.Text + "',Contactname=N'" + txtnn.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tong + "',Posted='False',Tax='" + cbthue.Text + "',ExDate = Null,UserID='" + userid + "',PostVersion='" + danhmuc.EditValue.ToString() + "'  where RefID='" + role + "'");
                        else
                            gen.ExcuteNonquery("update GLVoucher set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress='" + txtdc.Text + "',Contactname=N'" + txtnn.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tong + "',Posted='False',Tax='" + cbthue.Text + "',ExDate = " + txthtt.Text + ",UserID='" + userid + "',PostVersion='" + danhmuc.EditValue.ToString() + "'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  GLVoucherDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            /*if (detail[i, 2] == "")
                            {
                                gen.ExcuteNonquery("insert into GLVoucherDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,SortOrder,CustomField5) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + i + ",'" + detail[i, 8] + "')");
                            }
                            else
                            {*/
                            gen.ExcuteNonquery("insert into GLVoucherDetail(RefDetailID,RefID,Description,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo,SortOrder,CustomField5,CustomField4) values(newid(),'" + role + "',N'" + detail[i, 7] + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "'," + detail[i, 2] + ",'" + detail[i, 3] + "','" + detail[i, 4] + "'," + i + ",'" + detail[i, 8] + "',N'" + detail[i, 9] + "')");
                            //}
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain,CABA,ExDate,Occupation,GroupCost) values(newid(),'" + role + "','" + txtsct.Text + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "','" + denct.EditValue.ToString() + "'," + txthtt.Text + ",'" + detail[i, 7] + "',N'" + detail[i, 9] + "')");
                        }
                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu kế toán";
                }
          }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void tsbtdeletepkt(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from GLVoucher where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu kế toán " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from GLVoucher where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from GLVoucherDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("insert into HACHTOANBK select *,GetDate() from HACHTOAN where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update GLVoucher set Cancel='True',Posted='True' where RefID='" + name + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Hủy"], "True");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số tiền"], "0");*/
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu thu ngân hàng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieuthu F, string ngay,string userid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from GLVoucher where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from GLVoucher where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo ASC");
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
                    id = gen.GetString("select Top 1 * from GLVoucher where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from GLVoucher where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo DESC");
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
            string sophieu = "08-08-PHKT";
           
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from GLVoucher where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'  order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;
                }
                catch { sophieu = sophieu + "00001" + nam; }
           
            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, sophieu, ngaychungtu,userid);
        }

        public void checktruocsau(ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, string sct, string ngaychungtu,string userid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id = gen.GetString("select Top 1 * from GLVoucher where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from GLVoucher where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "')");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void loaduser(string ngaychungtu, DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("STT", Type.GetType("System.String"));
            dt.Columns.Add("Tên người dùng", Type.GetType("System.String"));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            temp = gen.GetTable("select DISTINCT a.UserID, FullName from MSC_User a, GLVoucher b where a.UserID=b.UserID and Month(RefDate)='"+thang+"' and Year(RefDate)='"+nam+"'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = (i + 1).ToString();
                dr[2] = temp.Rows[i][1].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.Columns[0].Visible = false;            
            view.Columns["STT"].Width = 20;
            view.Columns["STT"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Tên người dùng"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            
        }

        public void loadchitiet(string ngaychungtu, string id,string loai,string ten,string tsbt,string congty)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
            dt.Columns.Add("Ngày", Type.GetType("System.DateTime"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Tài khoản nợ", Type.GetType("System.String"));
            dt.Columns.Add("Tài khoản có", Type.GetType("System.String"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Nhân viên", Type.GetType("System.String"));
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (loai == "1")
            {
                temp = gen.GetTable("select substring(RefNo,7,9),RefDate,JournalMemo,DebitAccount,CreditAccount,Amount from GLVoucher a, GLVoucherDetail b where a.RefID=b.RefID and Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' and UserID='" + id + "'");
                ten = "Nhân viên lập phiếu: " + ten;
            }
            else if (loai == "2") 
            {
                temp = gen.GetTable("select substring(RefNo,7,9),RefDate,JournalMemo,DebitAccount,CreditAccount,sum(Amount),FullName from GLVoucher a, GLVoucherDetail b, MSC_User c where a.UserID=c.UserID and a.RefID=b.RefID and Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' group by substring(RefNo,7,9),RefDate,JournalMemo,DebitAccount,CreditAccount,FullName");
                ten = "";
            }
            else
            {
                temp = gen.GetTable("select substring(RefNo,7,9),RefDate,JournalMemo,DebitAccount,CreditAccount,Amount,FullName from GLVoucher a, GLVoucherDetail b, MSC_User c where a.UserID=c.UserID and a.RefID=b.RefID and Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                ten = "";
            }
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dr[5] = temp.Rows[i][5].ToString();
                if (loai == "0")
                    dr[6] = temp.Rows[i][6].ToString();
                dt.Rows.Add(dr);
            }

            Frm_rpthuchi F = new Frm_rpthuchi();
            F.getcongty(congty);
            F.gettsbt(tsbt);
            F.getda(dt);
            F.getrole(ngaychungtu);
            F.gethoten(ten);
            F.Show();
        }


    }
}

    

