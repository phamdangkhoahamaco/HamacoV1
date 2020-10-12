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
    class phieuxuathangmuatralai
    {
        gencon gen = new gencon();

        public void tsbtpxhmtl(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_phieuxuathangmuatralai u = new Frm_phieuxuathangmuatralai();
                u.myac = new Frm_phieuxuathangmuatralai.ac(F.refreshpxhmtl);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.gethang(hang);
                u.getkhach(khach);
                u.getpt("pxtl");
                u.getbranch(branchid);
                u.getuser(userid);
                u.getdate(ngaychungtu);
                try
                {
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
                }
                catch { }
                u.ShowDialog();
           }
            catch { MessageBox.Show("Vui lòng chọn phiếu nhập hàng bán trả lại trước khi sửa."); }
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

            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
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
            gridView1.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;

            gridView1.Columns[5].Visible = false;
        }

        public void loadpxhmtl(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia,DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, Frm_phieuxuathangmuatralai F, LookUpEdit ledt, TextEdit txtldn,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string tsbt, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txtcth, string userid, string branchid, TextEdit txtms, ComboBoxEdit cbthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,DataTable khach,DataTable hang)
        {
            DataTable dt = new DataTable();
            loadstart(gridControl1, gridView1, ledv, denct, denht, mahang, soluong, soluongqd, dongia,chiphi, thanhtien, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, dt, tsbt, userid,cbthue,khach,hang);
            if (active == "1")
            {
                
                DataTable da = new DataTable();
                da = gen.GetTable("select  Amount,InventoryItemCode,a.UnitPrice,a.UnitPriceCost,Quantity,QuantityConvert,InventoryItemName from INReOutwardDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][1].ToString();
                    dr[1] = da.Rows[i][6].ToString();
                    dr[2] = da.Rows[i][4].ToString();
                    dr[3] = da.Rows[i][5].ToString();
                    dr[4] = da.Rows[i][2].ToString();
                    dr[6] = da.Rows[i][0].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;
               
                F.Text = "Xem phiếu xuất hàng mua trả lại";
                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,Tax,InvDate,InvSeries,InvNo,No,RefIn,CheckIn  from INReOutward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + role + "'");

                ledv.EditValue = da.Rows[0][7].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][2].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][4].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.EditValue = da.Rows[0][6].ToString();
                cbthue.EditValue = da.Rows[0][11].ToString();
                txtnhd.EditValue = DateTime.Parse(da.Rows[0][12].ToString());
                txtshd.Text = da.Rows[0][14].ToString();
                txtms.Text = da.Rows[0][15].ToString();
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
                    F.Text = "Thêm phiếu nhập hàng bán trả lại";
                    if (role == null)
                        ledv.ItemIndex = 0;
                    else ledv.EditValue = role;
                    cbthue.SelectedIndex = 2;
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
        public void checkpndc(string active, string role, Frm_phieuxuathangmuatralai F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, TextEdit txtsct, TextEdit txtname,
            TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, string userid, string branchid, TextEdit txtms, ComboBoxEdit cbthue, TextEdit txtthue, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 8];
 
                for (int i = 0; i < gridView1.RowCount-1; i++)
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
                            string ton = gen.GetString("select * from INReOutward where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, ledv.EditValue.ToString(), branchid,tsbttruoc,tsbtsau);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into INReOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,Tax,TotalVATAmount) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "','" + tong + "','" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','" + txtms.Text + "','" + cbthue.EditValue.ToString() + "','"+txtthue.Text.Replace(".","")+"')");
                        string refid = gen.GetString("select * from INReOutward where RefNo='" + txtsct.Text + "'");
                        //gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1561','632','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','"+dt+"')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','331','1561','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','331','1331','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        F.getrole(refid);
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            try
                            {
                                gen.ExcuteNonquery("insert into INReOutwardDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,UnitPriceCost,QuantityConvert) values(newid(),'" + refid + "',1561,632,'" + detail[i, 4] + "','" + detail[i, 1] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 5] + "')");
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        gen.ExcuteNonquery("update INReOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',JournalMemo=N'" + txtldn.Text + "',StockID='" + dv + "',TotalAmount='" + tong + "',Posted='False',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='" + userid + "',No='" + txtms.Text + "',Tax='" + cbthue.EditValue.ToString() + "',TotalVATAmount='"+txtthue.Text.Replace(".","")+"'  where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  INReOutwardDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        //gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','156','632','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','"+dt+"')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','331','1561','" + tong + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','331','1331','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + dt + "')");

                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            try
                            {
                                gen.ExcuteNonquery("insert into INReOutwardDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,UnitPriceCost,QuantityConvert) values(newid(),'" + role + "',1561,632,'" + detail[i, 4] + "','" + detail[i, 1] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 5] + "')");
                            }
                            catch { }
                        }
                    }
                    F.myac();
                    F.getactive("1");
                    F.Text = "Xem phiếu xuất hàng mua trả lại";
                
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
                if (gen.GetString("select Posted from INReOutward where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Phiếu đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu hàng bán trả lại " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from INReOutward where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from INReOutwardDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from HACHTOAN where RefID='" + name + "'");
                    view.DeleteRow(view.FocusedRowHandle);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn phiếu xuất hàng trả lại trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_phieunhaphangbantralai F, string ngay, string mk)
        {
            try
            {
                string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from INReOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from INReOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
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
                    id = gen.GetString("select Top 1 * from INReOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from INReOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and StockID='" + idkho + "' order by RefNo DESC");
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
            string sophieu = dv + "-" + mk + "-HMTL";
           
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from INReOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from INReOutward where RefNo > '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from INReOutward where RefNo < '" + sct + "' and Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
