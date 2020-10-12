using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HAMACO.Resources;

namespace HAMACO
{
    class hdmuahang
    {
        gencon gen = new gencon();

        public void loadhdmh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Đối tượng", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Lý do", Type.GetType("System.String"));
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Thuế", Type.GetType("System.String"));
            dt.Columns.Add("Cộng tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Vận chuyển", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền thuế", Type.GetType("System.Double"));            
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn đặt hàng", Type.GetType("System.String"));
            dt.Columns.Add("Phiếu nhập", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Phương tiện", Type.GetType("System.String"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                try
                {
                    dr[5] = temp.Rows[i][13].ToString();
                }
                catch { }
                dr[6] = temp.Rows[i][5].ToString();
                dr[7] = temp.Rows[i][6].ToString();
                

                dr[8] = Double.Parse(temp.Rows[i][8].ToString())+"%";

                dr[9] = Double.Parse(temp.Rows[i][9].ToString());

                dr[10] = Double.Parse(temp.Rows[i][10].ToString());

                dr[11] = Double.Parse(temp.Rows[i][7].ToString());

                dr[12] = Double.Parse(temp.Rows[i][9].ToString()) + Double.Parse(temp.Rows[i][10].ToString()) + Double.Parse(temp.Rows[i][7].ToString());
                dr[13] = temp.Rows[i][14].ToString();
                dr[14] = "False";
                if (temp.Rows[i][11].ToString() == "True")
                {
                    dr[14] = "True";
                }
                dr[15] = temp.Rows[i][12].ToString();
                dr[16] = temp.Rows[i][15].ToString();
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
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hóa đơn"].Width = 100;
            view.Columns["Ngày hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hóa đơn"].Width = 100;
            view.OptionsView.ShowFooter = true;
            view.Columns["Tiền thuế"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền thuế"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Tiền thuế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền thuế"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;

            view.Columns["Thuế"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Đối tượng"].Width = 250;
            view.Columns["Thuế"].Width = 50;
            view.Columns["Phiếu nhập"].Width = 60;  

            view.Columns["Cộng tiền hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Cộng tiền hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Cộng tiền hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Cộng tiền hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Vận chuyển"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Vận chuyển"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Vận chuyển"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Vận chuyển"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Mã kho"].GroupIndex = 0;          
            view.ExpandAllGroups();
            view.Columns["Số chứng từ"].BestFit();
            view.Columns["Đơn đặt hàng"].BestFit();
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1,GridView gridView2, GridView gridView3, ComboBoxEdit cbldt, ComboBoxEdit cbthue, DateEdit denct, DateEdit denht,
            LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripButton tsbtin, string ngaychungtu, string userid, string branchid,
            string active, LookUpEdit le1562, Frm_hdmuahang F, TextEdit txtsct, string role, TextEdit txtldn, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, TextEdit txtcth, TextEdit txttthue, LookUpEdit ledv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,DataTable khach,DataTable hang,TextEdit txtmst)
        {
            txtcth.EditValue = 0;
            txthtt.EditValue = 0;
            tsbtboghi.Visible = true;
            tsbtghiso.Visible = true;
            tsbtboghi.Enabled = true;
            tsbtghiso.Enabled = true;
            tsbtnap.Enabled = true;
            tsbtxoa.Enabled = true;
            tsbtsua.Enabled = true;
            tsbtin.Enabled = true;
            txthttt.Text = "TM/CK";
            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Khách hàng");
            cbldt.Properties.Items.Add("Nhà cung cấp");
            cbldt.Properties.Items.Add("Nhân viên");
           

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");
            

            DataTable da = new DataTable();
            /*DataTable temp = new DataTable();
            temp.Columns.Add("Mã đối tượng");
            temp.Columns.Add("Tên đối tượng");
            da = gen.GetTable("select * from AccountingObject where IsEmployee='True' order by AccountingObjectCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            le1562.Properties.DataSource = temp;
            le1562.Properties.DisplayMember = "Mã đối tượng";
            le1562.Properties.ValueMember = "Mã đối tượng";
            le1562.Properties.PopupWidth = 400;*/

            DataTable temp = new DataTable();
            temp.Columns.Add("Mã đối tượng");
            temp.Columns.Add("Tên đối tượng");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp.Rows.Add(dr);
            }
            le1562.Properties.DataSource = temp;
            le1562.Properties.DisplayMember = "Mã đối tượng";
            le1562.Properties.ValueMember = "Mã đối tượng";
            le1562.Properties.PopupWidth = 400;

            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã kho");
            temp1.Columns.Add("Tên kho");
            da = gen.GetTable("select StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='"+userid+"' order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp1.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp1;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;

            denht.EditValue = DateTime.Now;
            if (active == "1")
            {
                tsbtcat.Enabled = false;

                F.Text = "Xem hóa đơn mua hàng";
                da = gen.GetTable("select AccountingObjectCode,RefNo,Posted,AccountingObjectType,Cancel,PUPostedDate,PURefDate,CABARefDate,PUJournalMemo,TotalAmount,DueDateTime,AccountingObjectID1562,Tax,No,InvSeries,InvNo,PayNo,TotalVatAmount,StockCode,a.CustomField4  from PUInvoice a, AccountingObject b,Stock c where a.BranchID=c.StockID and a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][3].ToString());
                }
                catch { }
                ledv.EditValue=da.Rows[0][18].ToString();
                txtmst.EditValue = da.Rows[0][19].ToString();
                ledt.EditValue = da.Rows[0][0].ToString();
                txtldn.Text = da.Rows[0][8].ToString();
                denct.EditValue = DateTime.Parse(da.Rows[0][6].ToString());
                denht.EditValue = DateTime.Parse(da.Rows[0][5].ToString());
                txtsct.Text = da.Rows[0][1].ToString();
                txtms.Text = da.Rows[0][13].ToString();
                txtkhhd.Text = da.Rows[0][14].ToString();
                txtshd.Text = da.Rows[0][15].ToString();
                txtnhd.EditValue = DateTime.Parse(da.Rows[0][7].ToString());
                txthtt.Text = da.Rows[0][10].ToString();
                txthttt.Text = da.Rows[0][16].ToString();
                cbthue.Text = da.Rows[0][12].ToString();
                Double tienthue = 0;
                try
                {
                    tienthue = Double.Parse(da.Rows[0][17].ToString());
                }
                catch { }
                try
                {
                    string n1562 = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][11].ToString() + "'");
                    le1562.EditValue = n1562;
                }
                catch { le1562.EditValue = null; }
                if (da.Rows[0][2].ToString() == "True")
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
                if (da.Rows[0][4].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    tsbtghiso.Enabled = false;
                }
                while (gridView3.RowCount > 0)
                {
                    gridView3.DeleteRow(0);
                }
                while (gridView1.RowCount > 0)
                {
                    gridView1.DeleteRow(0);
                }
                da = gen.GetTable("select distinct RefID,RefDate,PostedDate,RefNo,AccountingObjectName,JournalMemo,StockCode from INInward a,Stock b, PUInvoiceINInward c where c.StockID=b.StockID and RefID=INInwardID and PUInvoiceID='" + role + "'");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    for (int j = 0; j < gridView3.RowCount; j++)
                    {
                        try
                        {
                            if (gridView3.GetRowCellValue(j, "ID").ToString() == da.Rows[i][0].ToString())
                            {
                                gridView3.DeleteRow(j);
                            }
                        }
                        catch { }
                    }
                    gridView3.AddNewRow();
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["ID"], da.Rows[i][0].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Số chứng từ"], da.Rows[i][3].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Ngày chứng từ"], da.Rows[i][1].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Ngày hạch toán"], da.Rows[i][2].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Nhà cung cấp"], da.Rows[i][4].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Lý do"], da.Rows[i][5].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "True");
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Mã kho"], da.Rows[i][6].ToString());

                    loadcthd(gridView1, da.Rows[i][0].ToString());
                }
                gridView3.UpdateCurrentRow();
                gridView3.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                da = gen.GetTable("select b.RefNo,InventoryItemCode,a.Quantity,a.QuantityConvert,a.UnitPrice,a.TotalAmount,a.N1562  from PUInvoiceINInward a,INInward b,InventoryItem c  where a.INInwardID=b.RefID and a.InventoryItemID=c.InventoryItemID and PUInvoiceID='" + role + "'");
                
                for (int j = 0; j < da.Rows.Count; j++)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == da.Rows[j][1].ToString() && gridView1.GetRowCellValue(i, "Số chứng từ").ToString() == da.Rows[j][0].ToString())
                        { 
                            Double slton= Double.Parse(gridView1.GetRowCellValue(i, "Số lượng tồn").ToString())+Double.Parse(da.Rows[j][2].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng tồn"], slton.ToString());
                            Double sltonqd = Double.Parse(gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString()) + Double.Parse(da.Rows[j][3].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["SL tồn quy đổi"], sltonqd.ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng"], da.Rows[j][2].ToString());                  
                            gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng quy đổi"], da.Rows[j][3].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Đơn giá"], da.Rows[j][4].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Thành tiền"], da.Rows[j][5].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Chi phí"], da.Rows[j][6].ToString());
                        }
                    }
                }
                gridView1.UpdateCurrentRow();

                da = gen.GetTable("select InventoryItemCode,a.Quantity,a.QuantityConvert,a.UnitPrice,a.Amount from PUInvoiceDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder ");
                while (gridView2.RowCount > 0)
                {
                    gridView2.DeleteRow(0);
                }
                    for (int i = 0; i < da.Rows.Count; i++)
                    {
                        gridView2.AddNewRow();
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], da.Rows[i][0].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], da.Rows[i][1].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], da.Rows[i][2].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], da.Rows[i][3].ToString());
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], da.Rows[i][4].ToString());
                    }
                gridView2.UpdateCurrentRow();
                txtcth.EditValue = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Thành tiền"].SummaryText));
                txttthue.EditValue = tienthue;
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                try
                {
                    F.Text = "Thêm hóa đơn mua hàng";
                    cbldt.SelectedIndex = 0;
                    cbthue.EditValue = "10";
                    if (role == null)
                        ledv.ItemIndex = 0;
                    else 
                        ledv.EditValue = role;    

                    denct.EditValue = DateTime.Parse(ngaychungtu);
                    denht.EditValue = DateTime.Parse(ngaychungtu);
                    txtnhd.EditValue = DateTime.Parse(ngaychungtu);
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }
            }
        }

        public void tsbthdmh(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid,string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_hdmuahang u = new Frm_hdmuahang();
                u.myac = new Frm_hdmuahang.ac(F.refreshhdmh);
                u.getactive(a);
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getkhach(khach);
                u.gethang(hang);
                u.getpt("hdmh");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
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
            catch { MessageBox.Show("Vui lòng chọn hóa đơn mua hàng trước khi sửa."); }
        }

        public void tsbthdbhchuyen(string a, string ma, string roleid, string subsys, string ngaychungtu, string userid, string branchid, string makhach, string kho, DataTable khach, DataTable hang)
        {
            try
            {
                Frm_hdmuahang u = new Frm_hdmuahang();
                u.getactive(a);
                u.getpt("hdmh");
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getkho(kho);
                u.getkhach(khach);
                u.gethang(hang);
                u.getphieu(ma);
                u.getdoituong(makhach);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn hóa đơn bán hàng trước khi sửa."); }
        }

        public void loadpnk(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
        {
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
            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][4].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][6].ToString();
                dr[5] = temp.Rows[i][9].ToString();
                dr[6] = "False";
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

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Chọn"].Width = 100;


        }
        public void loadbox(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongquydoi,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng tồn", Type.GetType("System.Double"));
            dt.Columns.Add("SL tồn quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            lvpq.DataSource = dt;

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[4].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[5].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[5].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[6].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[6].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[7].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[7].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[8].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[8].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[9].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[9].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[10].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[10].SummaryItem.DisplayFormat = "{0:n0}";


            view.Columns["Số chứng từ"].Width = 90;
            view.Columns["Mã kho"].Width = 30;
            view.Columns["Mã hàng"].Width = 80;
            view.Columns["Số lượng tồn"].Width = 80;
            view.Columns["SL tồn quy đổi"].Width = 80;
            
            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Số lượng tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng tồn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["SL tồn quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["SL tồn quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns[0].Visible = false;

            view.Columns["Số chứng từ"].OptionsColumn.AllowEdit = false;
            view.Columns["Mã kho"].OptionsColumn.AllowEdit = false;
            view.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            view.Columns["Số lượng tồn"].OptionsColumn.AllowEdit = false;
            view.Columns["SL tồn quy đổi"].OptionsColumn.AllowEdit = false;

            view.Columns["Số lượng"].ColumnEdit = soluong;
            view.Columns["Số lượng quy đổi"].ColumnEdit = soluongquydoi;
            view.Columns["Đơn giá"].ColumnEdit = dongia;
            view.Columns["Thành tiền"].ColumnEdit = thanhtien;
            view.Columns["Chi phí"].ColumnEdit = chiphi;

            /*view.Columns["Số chứng từ"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Mã kho"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Mã hàng"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["Số lượng tồn"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            view.Columns["SL tồn quy đổi"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;*/
        }

        public void loadboxhd(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            lvpq.DataSource = dt;

            view.OptionsView.ShowFooter = true;
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[1].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[2].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[3].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[4].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        public void loadcthd(DevExpress.XtraGrid.Views.Grid.GridView view, string pnkid)
        {

            DataTable temp = new DataTable();
            temp = gen.GetTable("select a.RefDetailID,b.RefNo, StockCode,InventoryItemCode,(a.Quantity-a.QuantityExits) as Q ,(a.QuantityConvert-a.QuantityConvertExits) as P from INInwardDetail a, INInward b, InventoryItem c,Stock d where a.RefID=b.RefID and a.InventoryItemID=c.InventoryItemID and b.StockID=d.StockID and a.RefID='" + pnkid + "' order by SortOrder");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                view.AddNewRow();
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số chứng từ"], temp.Rows[i][1].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã kho"], temp.Rows[i][2].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã hàng"], temp.Rows[i][3].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng tồn"], temp.Rows[i][4].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SL tồn quy đổi"], temp.Rows[i][5].ToString());
            }
            view.UpdateCurrentRow();
            view.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }


        public void loadthhdmain(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1, TextEdit txtcth)
        {

            while (gridView2.RowCount > 0)
            {
                gridView2.DeleteRow(0);
            }

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Double soluong = 0;
                Double soluongqd = 0;
                Double thanhtien = 0;
                Double dongia = 0;
                Double dongiaban = 0;
                Double check = 0;

                try
                {
                    soluongqd = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                    if (soluongqd != 0)
                    {
                        try
                        {
                            soluong = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng").ToString());
                        }
                        catch { }
                        try
                        {
                            thanhtien = Double.Parse(gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                        }
                        catch { }
                        try
                        {
                            dongiaban = Double.Parse(gridView1.GetRowCellValue(i, "Đơn giá").ToString());
                        }
                        catch { }

                        if (gridView2.RowCount > 0)
                        {
                            for (int j = 0; j < gridView2.RowCount; j++)
                            {
                                dongia = Double.Parse(gridView2.GetRowCellValue(j, "Đơn giá").ToString());
                                if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == gridView2.GetRowCellValue(j, "Mã hàng").ToString() && dongia == dongiaban)
                                {
                                    soluong = Double.Parse(gridView2.GetRowCellValue(j, "Số lượng").ToString()) + soluong;
                                    soluongqd = Double.Parse(gridView2.GetRowCellValue(j, "Số lượng quy đổi").ToString()) + soluongqd;
                                    thanhtien = Double.Parse(gridView2.GetRowCellValue(j, "Thành tiền").ToString()) + thanhtien;
                                    dongiaban = Math.Round(thanhtien / soluongqd, 2);
                                    gridView2.SetRowCellValue(j, gridView2.Columns["Số lượng"], soluong);
                                    gridView2.SetRowCellValue(j, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                                    gridView2.SetRowCellValue(j, gridView2.Columns["Đơn giá"], dongiaban);
                                    gridView2.SetRowCellValue(j, gridView2.Columns["Thành tiền"], thanhtien);
                                    gridView2.UpdateCurrentRow();
                                    check = 1;
                                }
                            }

                            if (check == 0)
                            {
                                gridView2.AddNewRow();
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                                gridView2.UpdateCurrentRow();
                            }
                        }
                        else
                        {
                            gridView2.AddNewRow();
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                            gridView2.UpdateCurrentRow();
                        }
                    }
                }
                catch { }
            }
            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));   

        }

        public void loadthhd(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1, string kt)
        {
            if (gridView1.RowCount > 0)
            {
                int check = 0;
                Double soluong = 0;
                Double soluongqd = 0;
                Double dongia = 0;
                Double thanhtien = 0;
                Double chiphi = 0;
                int j = 0;
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString())
                    {
                        try
                        {
                            Double sl = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng").ToString());
                            soluong = soluong + sl;
                        }
                        catch { }
                        try
                        {
                            Double sl = Double.Parse(gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                            thanhtien = thanhtien + sl;
                        }
                        catch { }
                        try
                        {
                            Double sl = Double.Parse(gridView1.GetRowCellValue(i, "Đơn giá").ToString());
                            dongia = dongia+sl;
                            j++;
                        }
                        catch {}
                        try
                        {
                            Double sl = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                            soluongqd = soluongqd + sl;
                        }
                        catch { }
                        try
                        {
                            Double sl = Double.Parse(gridView1.GetRowCellValue(i, "Chi phí").ToString());
                            chiphi = chiphi + sl;
                        }
                        catch { }
                    }
                }
                dongia = Math.Round(dongia / j,2) + Math.Round(chiphi/soluongqd,2);
                thanhtien = thanhtien + chiphi;
                if (dongia.ToString() == "NaN")
                    dongia = 0;
                for (int i = 0; i < gridView2.RowCount; i++)
                {
                    if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString())
                    {
                        gridView2.SetRowCellValue(i, gridView2.Columns["Số lượng"], soluong);
                        gridView2.SetRowCellValue(i, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                        gridView2.SetRowCellValue(i, gridView2.Columns["Đơn giá"], dongia);
                        gridView2.SetRowCellValue(i, gridView2.Columns["Thành tiền"], thanhtien);
                        check = 1;
                    }
                }

                if (check == 0 && kt == "1")
                {
                    gridView2.AddNewRow();
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], soluong);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongia);
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                }
                gridView2.UpdateCurrentRow();
            }
        }

        public void deletesct(DevExpress.XtraGrid.Views.Grid.GridView view, string sct)
        {
            for (int i = view.RowCount - 1; i >= 0; i--)
            {
                if (view.GetRowCellValue(i, "Số chứng từ").ToString() == sct)
                    view.DeleteRow(i);
            }
            view.UpdateCurrentRow();
        }

        public void delete(DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            for (int i = view.RowCount - 1; i >= 0; i--)
            {
                view.DeleteRow(i);
            }
            view.UpdateCurrentRow();
        }

        public void deletethhd(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1)
        {
            for (int i = gridView2.RowCount - 1; i >= 0; i--)
            {
                int check = 0;
                for (int j = 0; j < gridView1.RowCount; j++)
                {
                    if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == gridView1.GetRowCellValue(j, "Mã hàng").ToString())
                        check = 1;
                }
                if (check == 0)
                    gridView2.DeleteRow(i);
            }
            gridView2.UpdateCurrentRow();
        }


        public void themsct(string ngaychungtu, TextEdit txtsct, string branchid, string kho, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,TextEdit txtms,TextEdit txtkhhd,TextEdit txtshd)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string makho = gen.GetString("select StockID from Stock where StockCode='" + kho + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + kho + "-HDMH";
            
                try
                {
                    string id = gen.GetString("select Top 1 RefNo from PUInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;


                    DataTable temp = gen.GetTable("select Top 1 No,No,InvSeries,InvNo from PUInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                    txtms.Text = temp.Rows[0][1].ToString();
                    txtkhhd.Text = temp.Rows[0][2].ToString();

                    try
                    {
                    int daihd = temp.Rows[0][3].ToString().ToString().Length;
                    int hd = Int32.Parse(temp.Rows[0][3].ToString()) + 1;

                    txtshd.Text = hd.ToString();
                    for (int i = 0; i < daihd - hd.ToString().Length; i++)
                    {
                        txtshd.Text = "0" + txtshd.Text;
                    }
                    }
                    catch { }

                }
                catch { sophieu = sophieu + "00001" + nam; }
                txtsct.Text = sophieu;           
            checktruocsau(tsbttruoc, tsbtsau, kho, sophieu, ngaychungtu);
        }



        public void checkhdmh(string active, string role, Frm_hdmuahang F, GridView gridView1,GridView gridView2,GridView gridView3, LookUpEdit ledt, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
            TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txthtt,
            TextEdit txthttt, TextEdit txtms, LookUpEdit le1562, string branchid, string userid, TextEdit txtthue, string kho, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,TextEdit txtmst)
        {
            try
            {
                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");          

                if (txtnhd.Text == "" || txthtt.Text=="")
                    XtraMessageBox.Show("Bạn không được bỏ trống < Ngày hóa đơn > hoặc < Hạn thanh toán >", "Thông báo");
                else
                {
                    string[,] detail = new string[100, 10];
                    string n1562 = "";
                    try
                    {
                        n1562 = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + le1562.EditValue.ToString() + "'");
                    }
                    catch { }
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        Double soluongquydoi = 0;
                        try
                        {
                            soluongquydoi = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                        }
                        catch { }
                        if (soluongquydoi!=0)
                        {
                            string sct = gen.GetString("select * from INInward where RefNo='" + gridView1.GetRowCellValue(i, "Số chứng từ").ToString() + "'");
                            detail[i, 0] = sct;
                            string mk = gen.GetString("select * from Stock where StockCode='" + gridView1.GetRowCellValue(i, "Mã kho").ToString() + "'");
                            detail[i, 1] = mk;
                            string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                            detail[i, 2] = mh;
                            if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                                detail[i, 3] = "0";
                            else
                                detail[i, 3] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                                detail[i, 4] = "0";
                            else
                                detail[i, 4] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                            if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                                detail[i, 5] = "0";
                            else
                                detail[i, 5] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                            if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                                detail[i, 6] = "0";
                            else
                                detail[i, 6] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                                detail[i, 7] = "0";
                            else
                                detail[i, 7] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "Số lượng tồn").ToString() == "")
                                detail[i, 8] = "0";
                            else
                                detail[i, 8] = gridView1.GetRowCellValue(i, "Số lượng tồn").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString() == "")
                                detail[i, 9] = "0";
                            else
                                detail[i, 9] = gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString().Replace(".", "");
                        }
                    }
                    string[,] detailPU = new string[100, 8];
                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView2.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detailPU[i, 0] = mh;
                            detailPU[i, 1] = gridView2.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                            detailPU[i, 2] = gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",",".");
                            detailPU[i, 3] = gridView2.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                            detailPU[i, 4] = gridView2.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    }
                    string tongthanhtien = gridView1.Columns["Thành tiền"].SummaryText;
                    string tongchiphi = gridView1.Columns["Chi phí"].SummaryText;
                    if (Double.Parse(tongchiphi) != 0 && le1562.EditValue == null)
                    {
                        XtraMessageBox.Show("Vui lòng chọn đối tượng 1562", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    tongthanhtien = tongthanhtien.Replace(".", "");
                    tongchiphi = tongchiphi.Replace(".", "");
                    tongthanhtien = Math.Round(Double.Parse(tongthanhtien), 0).ToString();
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Khách hàng") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Nhà cung cấp") ldt = "1";
                    else ldt = "2";
                    string makho = gen.GetString("select * from Stock where StockCode='"+kho+"'");
                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from PUInvoice where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, branchid, kho, tsbttruoc, tsbtsau, txtms, txtkhhd, txtshd);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        try
                        {
                            gen.ExcuteNonquery("insert into PUInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,AccountingObjectID1562,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount,CustomField4) values(newid(),'" + makho + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "','" + n1562 + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + txtthue.Text.Replace(".", "") + "','"+txtmst.Text+"')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into PUInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount,CustomField4) values(newid(),'" + makho + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + txtthue.Text.Replace(".", "") + "','"+txtmst.Text+"')");
                        }
                        string refid = gen.GetString("select * from PUInvoice where RefNo='" + txtsct.Text + "'");

                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1561','331','" + tongthanhtien + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        try
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1562','331','" + tongchiphi + "','" + n1562 + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + n1562 + "')");
                        }
                        catch { }
                        gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + refid + "','" + txtsct.Text + "','1331','331','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        F.getrole(refid);
                        addhd(refid, gridView1, gridView2, gridView3, detail, detailPU);
                    }
                    else
                    {
                        try
                        {
                            gen.ExcuteNonquery("update PUInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',AccountingObjectID1562='" + n1562 + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalVatAmount='" + txtthue.Text.Replace(".", "") + "',CustomField4='"+txtmst.Text+"' where RefID='" + role + "'");
                            gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1561','331','" + tongthanhtien + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1562','331','" + tongchiphi + "','" + n1562 + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + n1562 + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1331','331','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update PUInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalVatAmount='" + txtthue.Text.Replace(".", "") + "',CustomField4='"+txtmst.Text+"' where RefID='" + role + "'");
                            gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1561','331','" + tongthanhtien + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain) values(newid(),'" + role + "','" + txtsct.Text + "','1331','331','" + txtthue.Text.Replace(".", "") + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "')");
                        }
                        
                        deletehd(role);
                        addhd(role, gridView1, gridView2, gridView3, detail, detailPU);
                    }
                    try
                    {
                        //F.myac();
                    }
                    catch { }
                    F.getactive("1");
                    F.Text = "Xem hóa đơn mua hàng";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deletehd(string hdid)
        {
            gen.ExcuteNonquery("update INInwardDetail set QuantityExits=QuantityExits-b.Quantity,QuantityConvertExits=QuantityConvertExits-b.QuantityConvert from INInwardDetail a, PUInvoiceINInward b where a.RefID=b.INInwardID and a.InventoryItemID=b.InventoryItemID and PUInvoiceID='" + hdid + "' ");
            updatepn(hdid);
            gen.ExcuteNonquery("delete from PUInvoiceDetail where RefID='"+hdid+"'");
            gen.ExcuteNonquery("delete from PUInvoiceINInward where PUInvoiceID='" + hdid + "'");
        }
        public void updatepn(string hdid)
        {
            DataTable da = new DataTable();
            da = gen.GetTable("select distinct(INInwardID) from PUInvoiceINInward where PUInvoiceID='" + hdid + "'");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                Double ton = 0;
                try
                {
                    ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INInwardDetail where RefID='" + da.Rows[i][0].ToString() + "'"));
                }
                catch { }
                if (ton == 0)
                    gen.ExcuteNonquery("update INInward set IsExport='True' where RefID='" + da.Rows[i][0].ToString() + "'");
                else
                    gen.ExcuteNonquery("update INInward set IsExport='False' where RefID='" + da.Rows[i][0].ToString() + "'");
            }
        }

        public void addhd(string refid, GridView gridView1, GridView gridView2, GridView gridView3, string[,] detail, string[,] detailPU)
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                gen.ExcuteNonquery("insert into PUInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice) values(newid(),'" + refid + "','" + detailPU[i, 4] + "','" + detailPU[i, 1] + "','" + detailPU[i, 2] + "'," + i + ",'" + detailPU[i, 0] + "','" + detailPU[i, 3] + "')");
            }
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                try
                {
                    gen.ExcuteNonquery("insert into PUInvoiceINInward values(newid(),'" + refid + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','331','" + detail[i, 7] + "','"+i+"')");
                    gen.ExcuteNonquery("update INInwardDetail set QuantityExits=QuantityExits  + '" + detail[i, 3] + "',QuantityConvertExits=QuantityConvertExits +'" + detail[i, 4] + "' where RefID='" + detail[i, 0] + "' and InventoryItemID='" + detail[i, 2] + "'");
                }
                catch { }
            }
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                try
                {
                    if (gridView3.GetRowCellValue(i, "Chọn").ToString() == "True")
                    {
                        Double ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INInwardDetail where RefID='" + gridView3.GetRowCellValue(i, "ID").ToString() + "'"));
                        if (ton == 0)
                            gen.ExcuteNonquery("update INInward set IsExport='True' where RefID='" + gridView3.GetRowCellValue(i, "ID").ToString() + "'");
                    }
                }
                catch { }
            }
        }

        public void tsbtdeletehdmh(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                string ghiso = gen.GetString("select Posted from PUInvoice where RefID='" + name + "'");
                if (ghiso == "False")
                {
                    if (view.GetRowCellValue(view.FocusedRowHandle, "Phiếu nhập").ToString() == "False")
                    {
                        if (XtraMessageBox.Show("Bạn có chắc muốn xóa hóa đơn mua hàng " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            deletehd(name);
                            gen.ExcuteNonquery("delete from PUInvoice where RefID='" + name + "'");
                            gen.ExcuteNonquery("delete from HACHTOAN where RefID='" + name + "'");
                            view.DeleteRow(view.FocusedRowHandle);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Đây là Hóa đơn có kèm phiếu nhập vui lòng chuyển sang mục < Hóa đơn kiêm phiếu nhập > để xóa phiếu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { XtraMessageBox.Show("Vui lòng chọn hóa đơn mua hàng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdmuahang F, string ngay,string branchid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdmuahang F, string ngay, string branchid)
        {
            try
            {
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from PUInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from PUInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from PUInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }
    }
}
