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
    class phieunhaphangkhuyenmai
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

        public void tsbtpnht(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid,string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieudieuchinh u = new Frm_phieudieuchinh();
                u.myac = new Frm_phieudieuchinh.ac(F.refreshpnhkm);
                u.getactive(a);
                u.getsub(subsys);
                u.getroleid(roleid);
                u.gethang(hang);
                u.getkhach(khach);
                u.getpt("pnhkm");
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

        public void loadpnht(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieudieuchinh F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txtcth, string userid, string branchid, TextEdit txtms,DataTable khach,DataTable hang, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmanganh, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rpmachiphi)
        {
            DataTable dt = new DataTable();
            phieunhapdieuchinh pndc = new phieunhapdieuchinh();
            pndc.loadstart(gridControl1, gridView1, ledv, denct, denht, tkno, tkco, mahang, soluong, soluongqd, dongia, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, userid, khach, hang, rpmanganh, rpmachiphi);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select  DebitAccount,CreditAccount,Amount,InventoryItemCode,a.UnitPrice,Quantity,QuantityConvert from INInwardFreeDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
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
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;

                F.Text = "Xem phiếu nhập hàng khuyên mãi";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,InvDate,InvSeries,InvNo,No  from INInwardFree a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");

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
            }
            else
            {
                try
                {
                    F.Text = "Thêm phiếu nhập hàng khuyến mãi";
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
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, string userid, string branchid, TextEdit txtms)
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
                        detail[i, 5] = "0";
                    else
                        detail[i, 5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
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
                            string ton = gen.GetString("select * from INInwardFree where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into INInwardFree(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + tong + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','" + txtms.Text + "')");
                        string refid = gen.GetString("select * from INInwardFree where RefNo='" + txtsct.Text + "'");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INInwardFreeDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert) values(newid(),'" + refid + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 6] + "')");
                        }
                    }
                    else
                    {
                        gen.ExcuteNonquery("update INInwardFree set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',JournalMemo=N'" + txtldn.Text + "',StockID='" + dv + "',TotalAmount='" + tong + "',Posted='False',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='" + userid + "',No='" + txtms.Text + "'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  INInwardFreeDetail where RefID='" + role + "'");
                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            gen.ExcuteNonquery("insert into INInwardFreeDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert) values(newid(),'" + role + "','" + detail[i, 1] + "','" + detail[i, 0] + "','" + detail[i, 5] + "','" + detail[i, 3] + "'," + i + ",'" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 6] + "')");
                        }
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
                if (gen.GetString("select Posted from INInwardFree where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu nhập hàng khuyến mãi " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INInwardFree where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INInwardFreeDetail where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                    /*gen.ExcuteNonquery("update INInwardFree set Cancel='True', Posted='True' where RefID='" + name + "'");
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
                    id = gen.GetString("select Top 1 * from INInwardFree where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardFree where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
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
                    id = gen.GetString("select Top 1 * from INInwardFree where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INInwardFree where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                    tsbtsau.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string mk, string branchid)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string dv = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = dv + "-" + mk + "-PNKM";
            /*if (DateTime.Parse(ngaychungtu).Month == DateTime.Now.Month && DateTime.Parse(ngaychungtu).Year == DateTime.Now.Year)
            {*/
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INInwardFree where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;
                }
                catch { sophieu = sophieu + "00001" + nam; }
            /*}
            else
            {
                string id = gen.GetString("select Top 1 RefNo from INInwardFree where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }*/
            txtsct.Text = sophieu;
        }
    }
}
