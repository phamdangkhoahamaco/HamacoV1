using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HAMACO.Resources;

namespace HAMACO.Resources
{
    class hdbanhang
    {
        gencon gen = new gencon();

        public void loadhdbh(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Hạn nợ", Type.GetType("System.Double"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Thuế", Type.GetType("System.String"));
            dt.Columns.Add("Cộng tiền hàng", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền thuế", Type.GetType("System.Double"));            
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Phiếu xuất", Type.GetType("System.Boolean"));            
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Ngày hạch toán", Type.GetType("System.DateTime"));
            dt.Columns.Add("Diễn giải", Type.GetType("System.String"));

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
                dr[9] = Double.Parse(temp.Rows[i][7].ToString());

                dr[7] = temp.Rows[i][8].ToString()+"%";

                Double cth, khautru, gtgt, tong, ck, chiphi;
                cth = Double.Parse(temp.Rows[i][9].ToString());
                ck = Double.Parse(temp.Rows[i][10].ToString());
                chiphi = Double.Parse(temp.Rows[i][11].ToString());
                khautru = Double.Parse(temp.Rows[i][12].ToString());
                cth = cth - ck - khautru + chiphi;
                dr[8] = cth;
                gtgt = Double.Parse(temp.Rows[i][7].ToString());
                tong = cth + gtgt;
                dr[10] = tong;
                dr[12] = "False";
                if (temp.Rows[i][13].ToString() == "True")
                {
                    dr[12] = "True";
                }
                dr[13] = temp.Rows[i][14].ToString();
                dr[11] = Double.Parse(temp.Rows[i][15].ToString());
                dr[14] = temp.Rows[i][16].ToString();
                dr[15] = temp.Rows[i][17].ToString();
                dr[16] = temp.Rows[i][18].ToString();
                dr[17] = temp.Rows[i][19].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[12].Visible = false;

            view.Columns["Ngày chứng từ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày chứng từ"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày chứng từ"].Width = 100;
            view.Columns["Ngày chứng từ"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            view.Columns["Ngày hạch toán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hạch toán"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hạch toán"].Width = 100;
            view.Columns["Ngày hạch toán"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

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
            view.Columns["Mã khách"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Mã khách"].Width = 70;
            view.OptionsView.ShowFooter = true;
            view.Columns["Tiền thuế"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền thuế"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Tiền thuế"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền thuế"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Chiết khấu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chiết khấu"].SummaryItem.DisplayFormat = "{0:n0}";
            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Hạn nợ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Hạn nợ"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Hạn nợ"].Width = 50;

            view.Columns["Thuế"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Đối tượng"].Width = 250;
            view.Columns["Thuế"].Width = 50;
            view.Columns["Phiếu xuất"].Width = 60;  

            view.Columns["Cộng tiền hàng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Cộng tiền hàng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Cộng tiền hàng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Cộng tiền hàng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
            view.Columns["Số chứng từ"].BestFit();
        }

        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1,DevExpress.XtraGrid.GridControl gridControl2, GridView gridView1, GridView gridView2, GridView gridView3, GridView gridView5, ComboBoxEdit cbldt, ComboBoxEdit cbthue, DateEdit denct, DateEdit denht,
            LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid,
            string active, LookUpEdit le1562, Frm_hdbanhang F, TextEdit txtsct, string role, TextEdit txtldn, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, TextEdit txtcth, TextEdit txtttthue, TextEdit txtkt, TextEdit txtldkt, CheckEdit chemoney, CheckEdit chepayphone, LookUpEdit leprovince, LookUpEdit ledv, ComboBoxEdit cbban, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtquyen, TextEdit txttdd, TextEdit txtdc, DataTable khach, DataTable hang, TextEdit txtname, TextEdit txtghichu, CheckEdit chth,TextEdit txtmst,SearchLookUpEdit searchncc, CheckEdit chphieu)
        {
            txtcth.EditValue = 0;
            while (gridView5.RowCount > 0)
            {
                gridView5.DeleteRow(0);
            }
            txthtt.EditValue = 0;
            txtquyen.EditValue = 0;
            chemoney.EditValue = false;
            chepayphone.EditValue = false;
            chth.EditValue = false;
            ledt.EditValue = null;
            cbldt.Properties.Items.Clear();
            cbldt.Properties.Items.Add("Tiền mặt/chuyển khoản");
            cbldt.Properties.Items.Add("Tiền mặt");
            cbldt.Properties.Items.Add("Chuyển khoản");

            cbban.Properties.Items.Clear();
            cbban.Properties.Items.Add("Bán lẻ");
            cbban.Properties.Items.Add("Công trình");
            cbban.Properties.Items.Add("Bán sỉ");
            

            cbthue.Properties.Items.Clear();
            cbthue.Properties.Items.Add("0");
            cbthue.Properties.Items.Add("5");
            cbthue.Properties.Items.Add("10");

            DataTable da = new DataTable();
          
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


            DataTable temp2 = new DataTable();
            temp2.Columns.Add("Mã kho");
            temp2.Columns.Add("Tên kho");
            da = gen.GetTable("select StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp2.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp2.Rows.Add(dr);
            }
            ledv.Properties.DataSource = temp2;
            ledv.Properties.DisplayMember = "Mã kho";
            ledv.Properties.ValueMember = "Mã kho";
            ledv.Properties.PopupWidth = 300;

            DataTable temp1 = new DataTable();
            temp1.Columns.Add("Mã tỉnh");
            temp1.Columns.Add("Tên tỉnh");
            da = gen.GetTable("select * from Province order by ProvinceName");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp1.NewRow();
                dr[0] = da.Rows[i][1].ToString();
                dr[1] = da.Rows[i][2].ToString();
                temp1.Rows.Add(dr);
            }
            leprovince.Properties.DataSource = temp1;
            leprovince.Properties.DisplayMember = "Tên tỉnh";
            leprovince.Properties.ValueMember = "Mã tỉnh";
            leprovince.Properties.PopupWidth = 200;

            denht.EditValue = DateTime.Parse(ngaychungtu);
            if (active == "1")
            {
                tsbtcat.Enabled = false;

                F.Text = "Xem hóa đơn bán hàng";
                da = gen.GetTable("select AccountingObjectCode,RefNo,Posted,AccountingObjectType,Cancel,PUPostedDate,PURefDate,CABARefDate,PUJournalMemo,TotalAmount,DueDateTime,AccountingObjectID1562,Tax,No,InvSeries,InvNo,PayNo,DocumentIncluded,TotalDiscountAmount,TotalVATAmount,MoneyPay,Reconciled,a.Province,StockCode,a.IssueBy,ParalellRefNo,CABAContactName,a.AccountingObjectAddress,a.AccountingObjectName,IsExport,CustomField4,BillReceived,a.CustomField5,PUContactName  from SSInvoice a, AccountingObject b,Stock c where a.BranchID=c.StockID and a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                ledv.EditValue = da.Rows[0][23].ToString();
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][3].ToString());
                }
                catch { }
                ledt.EditValue = da.Rows[0][0].ToString();
                if (da.Rows[0][32].ToString() != "")
                    txtmst.Text = da.Rows[0][32].ToString();
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
                txtldkt.Text = da.Rows[0][17].ToString();
                leprovince.EditValue = da.Rows[0][22].ToString();
                cbban.EditValue = da.Rows[0][24].ToString();
                txtquyen.Text = da.Rows[0][25].ToString();
                txttdd.Text = da.Rows[0][26].ToString();
                txtdc.Text = da.Rows[0][27].ToString();
                txtname.Text = da.Rows[0][28].ToString();
                try
                {
                    txtkt.EditValue=Double.Parse(da.Rows[0][18].ToString());
                }
                catch { }
                Double tienthue = 0;
                try
                {
                    tienthue =Double.Parse(da.Rows[0][19].ToString());
                }
                catch { }
                try
                {
                     le1562.EditValue = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][11].ToString() + "'");
                }
                catch { }
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
                if (da.Rows[0][29].ToString() == "True")
                {
                    tsbtboghi.Enabled = false;
                    tsbtsua.Enabled = false;
                }
                txtghichu.Text = da.Rows[0][30].ToString();
                searchncc.EditValue = da.Rows[0][33].ToString();
                if (da.Rows[0][31].ToString() == "True")
                    chth.EditValue = true;
                if (da.Rows[0][20].ToString() == "True")
                    chemoney.EditValue = true;
                if (da.Rows[0][21].ToString() == "True")
                    chepayphone.EditValue = true;
                while (gridView1.RowCount > 0)
                {
                    gridView1.DeleteRow(0);
                }
                da = gen.GetTable("select distinct RefID,RefDate,PostedDate,RefNo,AccountingObjectName,JournalMemo,StockCode,a.TotalAmountOC+a.TotalAmount-(a.TotalFreightAmount/(1+Cast(a.Tax as money)/100)),a.TotalFreightAmount/(1+Cast(a.Tax as money)/100) from INOutward a, Stock b,SSInvoiceINOutward c where c.StockID=b.StockID and RefID=INOutwardID and SSInvoiceID='" + role + "'");
                
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    for (int j = 0; j < gridView3.RowCount; j++)
                    {
                        try
                        {
                            if (gridView3.GetRowCellValue(j, "ID").ToString() == da.Rows[i][0].ToString())
                                gridView3.DeleteRow(j);
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
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Thành tiền"], da.Rows[i][7].ToString());
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chiết khấu"], Double.Parse(da.Rows[i][8].ToString()));
                    gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Chọn"], "True");
                    //gridView3.SetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Mã kho"], da.Rows[i][6].ToString());                  
                    //loadcthd(gridView1, da.Rows[i][0].ToString());
                }
                gridView3.UpdateCurrentRow();
                loadcthdmain(gridView1, role, gridControl1);
                gridView3.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                da = gen.GetTable("select b.RefNo,InventoryItemCode,a.Quantity,a.QuantityConvert,a.UnitPrice,a.TotalAmount,a.DiscountRate,a.DiscountAmount,Cost,RefIDD  from SSInvoiceINOutward a,INOutward b,InventoryItem c  where a.INOutwardID=b.RefID and a.InventoryItemID=c.InventoryItemID and SSInvoiceID='" + role + "'");

                for (int j = 0; j < da.Rows.Count; j++)
                {
                 
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (da.Rows[j][9].ToString() != "")
                        {
                            if (gridView1.GetRowCellValue(i, "IDD").ToString() == da.Rows[j][9].ToString())
                            {
                                Double slton = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng tồn").ToString()) + Double.Parse(da.Rows[j][2].ToString());
                                gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng tồn"], slton.ToString());
                                Double sltonqd = Double.Parse(gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString()) + Double.Parse(da.Rows[j][3].ToString());
                                gridView1.SetRowCellValue(i, gridView1.Columns["SL tồn quy đổi"], sltonqd.ToString());
                                gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng"], Double.Parse(da.Rows[j][2].ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng quy đổi"], Double.Parse(da.Rows[j][3].ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns["Đơn giá"], Double.Parse(da.Rows[j][4].ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns["Thành tiền"], Double.Parse(da.Rows[j][5].ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns["Chiết khấu"], Double.Parse(da.Rows[j][6].ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns["Tiền CK"], Double.Parse(da.Rows[j][7].ToString()));
                                gridView1.SetRowCellValue(i, gridView1.Columns["Chi phí"], Double.Parse(da.Rows[j][8].ToString()));
                            }
                        }
                        else if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == da.Rows[j][1].ToString() && gridView1.GetRowCellValue(i, "Số chứng từ").ToString() == da.Rows[j][0].ToString())
                        {
                            Double slton = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng tồn").ToString()) + Double.Parse(da.Rows[j][2].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng tồn"], slton.ToString());
                            Double sltonqd = Double.Parse(gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString()) + Double.Parse(da.Rows[j][3].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["SL tồn quy đổi"], sltonqd.ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng"], da.Rows[j][2].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Số lượng quy đổi"], da.Rows[j][3].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Đơn giá"], da.Rows[j][4].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Thành tiền"], da.Rows[j][5].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Chiết khấu"], da.Rows[j][6].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Tiền CK"], da.Rows[j][7].ToString());
                            gridView1.SetRowCellValue(i, gridView1.Columns["Chi phí"], da.Rows[j][8].ToString());
                        }
                    }
                }
                gridView1.UpdateCurrentRow();

                da = gen.GetTable("select InventoryItemCode as 'Mã hàng',a.Quantity as 'Số lượng',a.QuantityConvert as 'Số lượng quy đổi',a.UnitPrice as 'Đơn giá',a.Amount as 'Thành tiền',RefIDFree as 'Số chứng từ',a.InventoryItemID as 'Mã ID hàng' from SSInvoiceDetail a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder ");
                while (gridView2.RowCount > 0)
                {
                    gridView2.DeleteRow(0);
                }
                
                /*for (int i = 0; i < da.Rows.Count; i++)
                {
                    gridView2.AddNewRow();
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], da.Rows[i][0].ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng"], da.Rows[i][1].ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số lượng quy đổi"], da.Rows[i][2].ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], da.Rows[i][3].ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], da.Rows[i][4].ToString());
                    gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số chứng từ"], da.Rows[i][5].ToString());
                }*/
                gridControl2.DataSource = da;
                gridView2.UpdateCurrentRow();
                
               
                da = gen.GetTable("select RefID,RefDate,PostedDate,RefNo,AccountingObjectName,JournalMemo,StockCode,ExitsStore from INOutwardFree a,Stock b where a.StockID=b.StockID and RefPUID='"+ role + "'");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    gridView5.AddNewRow();
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["ID"], da.Rows[i][0].ToString());
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Số chứng từ"], da.Rows[i][3].ToString());
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Ngày chứng từ"], da.Rows[i][1].ToString());
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Ngày hạch toán"], da.Rows[i][2].ToString());
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Nhà cung cấp"], da.Rows[i][4].ToString());
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Lý do"], da.Rows[i][5].ToString());
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Chọn"], "True");
                    try
                    {
                        gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Tính giá vốn"], da.Rows[i][7].ToString());
                    }
                    catch { }
                    gridView5.SetRowCellValue(gridView5.FocusedRowHandle, gridView5.Columns["Mã kho"], da.Rows[i][6].ToString());

                    loadcthd(gridView1, da.Rows[i][0].ToString(), chphieu);
                }
                gridView5.UpdateCurrentRow();
                gridView5.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Tiền CK"].SummaryText) + Double.Parse(gridView2.Columns["Thành tiền"].SummaryText));
                txtttthue.EditValue =  tienthue;
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);
            }
            else
            {
                try
                {
                    cbldt.SelectedIndex = 0;
                    cbthue.EditValue = "10";
                    cbban.EditValue = "Bán lẻ";
                    
                    if (role == null)
                        ledv.ItemIndex = 0;
                    else ledv.EditValue = role;
                    F.Text = "Thêm hóa đơn bán hàng";
                    txthttt.Text = "TM/CK";
                    denct.EditValue = DateTime.Parse(ngaychungtu);
                    denht.EditValue = DateTime.Parse(ngaychungtu);
                    txtnhd.EditValue = DateTime.Parse(ngaychungtu);
                    leprovince.EditValue = "CT";
                }
                catch
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại < Ngày chứng từ >.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    F.Close();
                }
            }
        }

        public void tsbthdbh(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view,string roleid,string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            /*try
            {*/
                Frm_hdbanhang u = new Frm_hdbanhang();
                u.myac = new Frm_hdbanhang.ac(F.refreshhdbh);
                u.getactive(a);
                u.getpt("hdbh");
                u.getroleid(roleid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getsub(subsys);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
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
            /*}
            catch { MessageBox.Show("Vui lòng chọn hóa đơn bán hàng trước khi sửa."); }*/
        }

        public void tsbthdbhchuyen(string a, string ma, string roleid, string subsys, string ngaychungtu, string userid, string branchid, string makhach, string kho, DataTable khach, DataTable hang, string nhanvien,string chietkhau)
        {
            try
            {
                Frm_hdbanhang u = new Frm_hdbanhang();
                u.getactive(a);
                u.getpt("hdbh");
                u.getroleid(roleid);
                u.getsub(subsys);
                u.getkhach(khach);
                u.gethang(hang);
                u.getkho(kho);
                u.getphieu(ma);
                u.getdoituong(makhach);
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);
                u.getnhanvien(nhanvien);
                if (Double.Parse(chietkhau) != 0)
                    u.getck(chietkhau.Replace(".", ""));
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
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
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
                dr[6] = Double.Parse(temp.Rows[i][20].ToString())-Math.Round((Double.Parse(temp.Rows[i][48].ToString())/(1+Double.Parse(temp.Rows[i][45].ToString())/100)),0) + Double.Parse(temp.Rows[i][21].ToString());
                dr[7] = Math.Round(Double.Parse(temp.Rows[i][48].ToString()) / (1 + Double.Parse(temp.Rows[i][45].ToString()) / 100),0);
                dr[8] = "False";
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

            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Chiết khấu"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chiết khấu"].SummaryItem.DisplayFormat = "{0:n0}";


            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Chọn"].Width = 100;
            
        }

        public void loadpxkm(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, string sql)
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
            dt.Columns.Add("Tính giá vốn", Type.GetType("System.Boolean"));
            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));
            dt.Columns.Add("Mã kho", Type.GetType("System.String"));

           
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
                dr[7] = "False";
                dr[8] = gen.GetString("select StockCode from Stock where StockID='" + temp.Rows[i][25].ToString() + "'");
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.Columns["Số chứng từ"].OptionsColumn.AllowEdit = false;
            view.Columns["Ngày chứng từ"].OptionsColumn.AllowEdit = false;
            view.Columns["Ngày hạch toán"].OptionsColumn.AllowEdit = false;
            view.Columns["Nhà cung cấp"].OptionsColumn.AllowEdit = false;
            view.Columns["Lý do"].OptionsColumn.AllowEdit = false;
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
            view.Columns["Tính giá vốn"].Width = 100;
            view.Columns["Mã kho"].GroupIndex = 0;
            view.ExpandAllGroups();
        }

        public void loadbox(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongquydoi,
            DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit tienck)
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
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền CK", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền tạm", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng tạm", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí tạm", Type.GetType("System.Double"));
            dt.Columns.Add("IDD", Type.GetType("System.String"));
            dt.Columns.Add("Mã ID hàng", Type.GetType("System.String"));
            lvpq.DataSource = dt;

            view.OptionsView.ShowFooter = true;
            view.Columns["Số chứng từ"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns["Số chứng từ"].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns["Số lượng tồn"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng tồn"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["SL tồn quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["SL tồn quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
            view.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Chi phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["Chi phí"].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số chứng từ"].Width = 90;
            view.Columns["Mã kho"].Width = 30;
            view.Columns["Mã kho"].Visible = false;
            view.Columns["Mã hàng"].Width = 60;
            view.Columns["Số lượng tồn"].Width = 60;
            view.Columns["SL tồn quy đổi"].Width = 70;
            view.Columns["Mã kho"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Số lượng tồn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng tồn"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["SL tồn quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["SL tồn quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Số lượng tạm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng tạm"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Chi phí tạm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí tạm"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Thành tiền tạm"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền tạm"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n0}";

           
            view.Columns[0].Visible = false;
            view.Columns[13].Visible = false;
            view.Columns[14].Visible = false;
            view.Columns[15].Visible = false;
            view.Columns[16].Visible = false;
            view.Columns[17].Visible = false;

            view.Columns["Số chứng từ"].OptionsColumn.AllowEdit = false;
            view.Columns["Mã kho"].OptionsColumn.AllowEdit = false;
            view.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            view.Columns["Số lượng tồn"].OptionsColumn.AllowEdit = false;
            view.Columns["SL tồn quy đổi"].OptionsColumn.AllowEdit = false;
            view.Columns["Đơn giá"].OptionsColumn.AllowEdit = false;
            //view.Columns["Thành tiền"].OptionsColumn.AllowEdit = false;
            view.Columns["Chi phí"].OptionsColumn.AllowEdit = false;
            view.Columns["Chiết khấu"].OptionsColumn.AllowEdit = false;
            view.Columns["Tiền CK"].OptionsColumn.AllowEdit = false;

            view.Columns["Số lượng"].ColumnEdit = soluong;
            view.Columns["Số lượng quy đổi"].ColumnEdit = soluongquydoi;
            view.Columns["Thành tiền"].ColumnEdit = thanhtien;
            
        }

        public void loadboxhd(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Mã ID hàng", Type.GetType("System.String"));
            lvpq.DataSource = dt;

            view.OptionsView.ShowFooter = true;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

            view.Columns[2].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[2].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns[3].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[3].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[4].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[4].SummaryItem.DisplayFormat = "{0:n2}";

            view.Columns[5].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns[5].SummaryItem.DisplayFormat = "{0:n0}";

            view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns[0].Visible = false;
            view.Columns[6].Visible = false;
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
        }

        public void loadcthd(DevExpress.XtraGrid.Views.Grid.GridView view, string pnkid, CheckEdit chphieu)
        {
            DataTable temp = new DataTable();
            temp = gen.GetTable("select a.RefDetailID,b.RefNo, StockCode,InventoryItemCode,(a.Quantity-a.QuantityExits) as Q ,(a.QuantityConvert-a.QuantityConvertExits) as P, a.UnitPrice,Cost,DiscountRate,Amount,a.QuantityConvert,a.RefID,a.InventoryItemID from INOutwardDetail a, INOutward b, InventoryItem c,Stock d where a.RefID=b.RefID and a.InventoryItemID=c.InventoryItemID and b.StockID=d.StockID and a.RefID='" + pnkid + "' order by SortOrder");

            for (int i = 0; i < temp.Rows.Count; i++)
            {
                view.AddNewRow();
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["ID"], temp.Rows[i][11].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số chứng từ"], temp.Rows[i][1].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã kho"], temp.Rows[i][2].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã hàng"], temp.Rows[i][3].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng tồn"], temp.Rows[i][4].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SL tồn quy đổi"], temp.Rows[i][5].ToString());

                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Đơn giá"], temp.Rows[i][6].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chi phí"], "0");
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chiết khấu"], temp.Rows[i][8].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Thành tiền tạm"], temp.Rows[i][9].ToString());

                if (chphieu.Checked == true)
                {
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng"], temp.Rows[i][4].ToString());
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng quy đổi"], temp.Rows[i][5].ToString());
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Thành tiền"], temp.Rows[i][9].ToString());
                }

                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng tạm"], temp.Rows[i][10].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chi phí tạm"], temp.Rows[i][7].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["IDD"], temp.Rows[i][0].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã ID hàng"], temp.Rows[i][12].ToString());
            }
            view.UpdateCurrentRow();
            view.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        public void loadcthdmain(DevExpress.XtraGrid.Views.Grid.GridView view, string hoadon, DevExpress.XtraGrid.GridControl lvpq)
        {

            DataTable temp = gen.GetTable("select a.RefDetailID as 'ID',b.RefNo as 'Số chứng từ', StockCode as 'Mã kho',InventoryItemCode as 'Mã hàng',(a.Quantity-a.QuantityExits) as 'Số lượng tồn',(a.QuantityConvert-a.QuantityConvertExits) as 'SL tồn quy đổi', a.UnitPrice,Cost,DiscountRate,Amount,a.QuantityConvert,a.RefID,a.InventoryItemID from INOutwardDetail a, INOutward b, InventoryItem c,Stock d where a.RefID=b.RefID and a.InventoryItemID=c.InventoryItemID and b.StockID=d.StockID and a.RefID in (select distinct INOutwardID from SSInvoiceINOutward where SSInvoiceID='" + hoadon + "') order by b.RefNo,SortOrder");
            //temp = gen.GetTable("select a.RefID as 'ID',b.RefNo as 'Số chứng từ', StockCode as 'Mã kho',InventoryItemCode as 'Mã hàng',(a.Quantity-a.QuantityExits) as 'Số lượng tồn',(a.QuantityConvert-a.QuantityConvertExits) as 'SL tồn quy đổi',NULL as 'Số lượng',NULL as 'Số lượng quy đổi', a.UnitPrice as 'Đơn giá',0 as 'Chi phí',DiscountRate as 'Chiết khấu',0 as 'Tiền CK',Amount as 'Thành tiền tạm',NULL as 'Thành tiền',a.QuantityConvert as 'Số lượng tạm',Cost as 'Chi phí tạm',a.RefDetailID as 'IDD' from INOutwardDetail a, INOutward b, InventoryItem c,Stock d where a.RefID=b.RefID and a.InventoryItemID=c.InventoryItemID and b.StockID=d.StockID and a.RefID in (select INOutwardID from SSInvoiceINOutward where SSInvoiceID='" + hoadon + "') order by b.RefNo,SortOrder");
            
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                view.AddNewRow();
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["ID"], temp.Rows[i][11].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số chứng từ"], temp.Rows[i][1].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã kho"], temp.Rows[i][2].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã hàng"], temp.Rows[i][3].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng tồn"], temp.Rows[i][4].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["SL tồn quy đổi"], temp.Rows[i][5].ToString());
                
                //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng"], temp.Rows[i][4].ToString());
                //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng quy đổi"], temp.Rows[i][5].ToString());
                
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Đơn giá"], temp.Rows[i][6].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chi phí"], "0");
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chiết khấu"], temp.Rows[i][8].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Thành tiền tạm"], temp.Rows[i][9].ToString());

                //view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Thành tiền"], temp.Rows[i][9].ToString());

                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Số lượng tạm"], temp.Rows[i][10].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Chi phí tạm"], temp.Rows[i][7].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["IDD"], temp.Rows[i][0].ToString());
                view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Mã ID hàng"], temp.Rows[i][12].ToString());
            }
            //lvpq.DataSource = temp;
            view.UpdateCurrentRow();
            view.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        public void loadthhdmain(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1,TextEdit txtcth,string thhd)
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
                Double chiphi = 0;
                Double chietkhau = 0;
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
                            chiphi = Double.Parse(gridView1.GetRowCellValue(i, "Chi phí").ToString());
                        }
                        catch { }
                        try
                        {
                            chietkhau = Double.Parse(gridView1.GetRowCellValue(i, "Tiền CK").ToString());
                        }
                        catch { }
                        thanhtien = thanhtien + chiphi - chietkhau;
                        dongiaban = Math.Round(thanhtien / soluongqd, 2);

                        if (gridView2.RowCount > 0)
                        {
                            for (int j = 0; j < gridView2.RowCount; j++)
                            {
                                dongia = Double.Parse(gridView2.GetRowCellValue(j, "Đơn giá").ToString());
                                if (thhd == "False")
                                {
                                    /*if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == gridView2.GetRowCellValue(j, "Mã hàng").ToString() && dongia == dongiaban && gridView1.GetRowCellValue(i, "Số chứng từ").ToString() == gridView2.GetRowCellValue(j, "Số chứng từ").ToString())
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
                                    }*/
                                }
                                else
                                {
                                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == gridView2.GetRowCellValue(j, "Mã hàng").ToString())
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
                            }

                            if (check == 0)
                            {         
                                gridView2.AddNewRow();
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số chứng từ"], gridView1.GetRowCellValue(i, "Số chứng từ").ToString());
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                                gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã ID hàng"], gridView1.GetRowCellValue(i, "Mã ID hàng").ToString());
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
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Số chứng từ"], gridView1.GetRowCellValue(i, "Số chứng từ").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã hàng"], gridView1.GetRowCellValue(i, "Mã hàng").ToString());
                            gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Mã ID hàng"], gridView1.GetRowCellValue(i, "Mã ID hàng").ToString());
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
            txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView1.Columns["Chi phí"].SummaryText));            
        }

        public void loadthhsl(DevExpress.XtraGrid.Views.Grid.GridView gridView1, TextEdit txtghichu)
        {
            string[,] detail = new string[500, 2];
            int k = 0,kiemtra=0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == detail[j, 0].ToString())
                        kiemtra = 1;
                }
                if (kiemtra == 0)
                {
                    detail[k, 0] = gridView1.GetRowCellValue(i, "Mã hàng").ToString();
                    k++;
                }
                else
                    kiemtra = 0;
            }
            txtghichu.Text = k.ToString();
        }

        public void loadthhd(DevExpress.XtraGrid.Views.Grid.GridView gridView2, DevExpress.XtraGrid.Views.Grid.GridView gridView1, string kt,string add)
        {
            if (add == "0")
            {
                if (gridView1.RowCount > 0)
                {
                    int check = 0;
                    Double soluong = 0;
                    Double soluongqd = 0;
                    Double dongia = 0;
                    Double thanhtien = 0;
                    Double chiphi = 0;
                    Double chietkhau = 0;
                    Double dongiaban = 0;
                    int j = 0;
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString()
                            && gridView1.GetRowCellValue(i, "Đơn giá").ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Đơn giá").ToString())
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
                                dongia = dongia+ sl;
                                j++;
                            }
                            catch { }

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
                            try
                            {
                                Double sl = Double.Parse(gridView1.GetRowCellValue(i, "Tiền CK").ToString());
                                chietkhau = chietkhau + sl;
                            }
                            catch { }
                            if (soluongqd > 0)
                            {
                                dongiaban = Math.Round(dongia / j, 2) - Math.Round((chietkhau / soluongqd), 2) + Math.Round((chiphi / soluongqd), 2);
                                thanhtien = thanhtien + chiphi - chietkhau;
                            }
                            
                        }
                    }

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {

                        if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã hàng").ToString() && gridView2.GetRowCellValue(i, "Số chứng từ").ToString() == "" && (dongiaban.ToString() == gridView2.GetRowCellValue(i, "Đơn giá").ToString() || Double.Parse(gridView2.GetRowCellValue(i, "Đơn giá").ToString())==0))
                        {
                            gridView2.SetRowCellValue(i, gridView2.Columns["Số lượng"], soluong);
                            gridView2.SetRowCellValue(i, gridView2.Columns["Số lượng quy đổi"], soluongqd);
                            gridView2.SetRowCellValue(i, gridView2.Columns["Đơn giá"], dongiaban);
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
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Đơn giá"], dongiaban);
                        gridView2.SetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Thành tiền"], thanhtien);
                    }
                    gridView2.UpdateCurrentRow();
                    gridView2.Columns["Số chứng từ"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
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


        public void themsct(string ngaychungtu, TextEdit txtsct, string branchid, string kho, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtquyen, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string makho = gen.GetString("select StockID from Stock where StockCode='" + kho + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + kho + "-HDBH";

            /*try
            {*/
                //string id = gen.GetString("select Top 1 RefNo from SSInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                
                DataTable temp = gen.GetTable("select Top 1 ParalellRefNo,No,InvSeries,InvNo,RefNo from SSInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                if (temp.Rows.Count > 0)
                {
                    if (txtquyen.Text != "")
                        txtquyen.EditValue = temp.Rows[0][0].ToString();
                    txtms.EditValue = temp.Rows[0][1].ToString();
                    txtkhhd.EditValue = temp.Rows[0][2].ToString();
                    string id = temp.Rows[0][4].ToString();

                    int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                    for (int i = 0; i < dai - ct.ToString().Length; i++)
                    {
                        sophieu = sophieu + "0";
                    }
                    sophieu = sophieu + ct.ToString() + nam;
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
                else
                { sophieu = sophieu + "00001" + nam; }
            /*
            }catch
            {
                sophieu = sophieu + "00001" + nam;
            }*/
            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, kho, sophieu, ngaychungtu);
        }



        public void checkhdbh(string active, string role, Frm_hdbanhang F, GridView gridView1, GridView gridView2, GridView gridView3, GridView gridView5,LookUpEdit ledt, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
            TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
            ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, ComboBoxEdit cbthue, TextEdit txtshd, TextEdit txtkhhd, TextEdit txtnhd, TextEdit txthtt,
            TextEdit txthttt, TextEdit txtms, LookUpEdit le1562, string branchid, string userid, TextEdit txtkt, TextEdit txttthue, TextEdit txtldkt, CheckEdit chmoney, CheckEdit chpayphone, LookUpEdit leprovince, LookUpEdit ledv, ComboBoxEdit cbban, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtquyen, TextEdit txttdd, TextEdit txtghichu, CheckEdit chth, TextEdit txtmst, SearchLookUpEdit searchncc)
        {

            /*try
            {*/
                if (gridView2.RowCount > 11)
                    XtraMessageBox.Show("Hóa đơn không được xuất quá 11 dòng hoặc phải lập bảng kê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                int dem = 0;
                Double phantram, khautru, thue;
                try { phantram = Double.Parse(txtkt.Text); khautru = Double.Parse(txtkt.Text); }
                catch { phantram = 0; khautru = 0; }
                Double tientong = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText.Replace(".", ""));
                string dt = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");

                if (txtnhd.Text == "" || txthtt.Text == "")
                    XtraMessageBox.Show("Bạn không được bỏ trống < Ngày hóa đơn > hoặc < Hạn thanh toán >", "Thông báo");
                else
                {
                    string[,] detail = new string[1500, 20];
                    string n1562 = "NULL";
                    if (le1562.EditValue.ToString() != "")
                        n1562 = "'" + gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + le1562.EditValue.ToString() + "'") + "'";
                   
                    string mk = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        Double soluongquydoi = 0;
                        try
                        {
                            soluongquydoi = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                        }
                        catch { }
                        if (soluongquydoi != 0)
                        {
                            detail[i, 0] = gridView1.GetRowCellValue(i, "ID").ToString();
                            detail[i, 15] = gridView1.GetRowCellValue(i, "IDD").ToString();
                            detail[i, 1] = mk;

                            //string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");

                            detail[i, 2] = gridView1.GetRowCellValue(i, "Mã ID hàng").ToString();

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
                            if (gridView1.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                                detail[i, 7] = "0";
                            else
                                detail[i, 7] = gridView1.GetRowCellValue(i, "Chiết khấu").ToString().Replace(",", ".").Replace(",", ".");
                            if (gridView1.GetRowCellValue(i, "Số lượng tồn").ToString() == "")
                                detail[i, 8] = "0";
                            else
                                detail[i, 8] = gridView1.GetRowCellValue(i, "Số lượng tồn").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString() == "")
                                detail[i, 9] = "0";
                            else
                                detail[i, 9] = gridView1.GetRowCellValue(i, "SL tồn quy đổi").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "Tiền CK").ToString() == "")
                                detail[i, 10] = "0";
                            else
                                detail[i, 10] = gridView1.GetRowCellValue(i, "Tiền CK").ToString().Replace(".", "");
                            if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                                detail[i, 11] = "0";
                            else
                                detail[i, 11] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "");
                            dem = dem + 1;
                            if (phantram != 0)
                            {
                                Double tien = Double.Parse(gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                                detail[i, 12] = (tien / tientong).ToString();
                            }
                            else detail[i, 12] = "0";
                        }
                    }

                    if (phantram != 0)
                    {
                        for (int i = 0; i < gridView1.RowCount; i++)
                        {
                            Double soluongquydoi = 0;
                            try
                            {
                                soluongquydoi = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                            }
                            catch { }
                            if (soluongquydoi != 0)
                            {
                                if (dem > 0)
                                {
                                    try
                                    {
                                        Double tien = Double.Parse(detail[i, 12]);
                                        if (dem == 1)
                                            detail[i, 12] = Math.Round(phantram, 0).ToString();
                                        else
                                        {
                                            detail[i, 12] = Math.Round(khautru * tien, 0).ToString();
                                            phantram = phantram - Math.Round(khautru * tien, 0);
                                        }
                                    }
                                    catch { }
                                    dem = dem - 1;
                                }
                            }
                        }
                    }

                    string[,] detailPU = new string[600, 8];

                    for (int i = 0; i < gridView2.RowCount; i++)
                    {
                        if (Double.Parse(gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString()) != 0)
                        {
                            detailPU[i, 0] = gridView2.GetRowCellValue(i, "Mã ID hàng").ToString();
                            detailPU[i, 1] = Double.Parse(gridView2.GetRowCellValue(i, "Số lượng").ToString()).ToString().Replace(".", "");
                            detailPU[i, 2] = Double.Parse(gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString()).ToString().Replace(".", "").Replace(",", ".");
                            detailPU[i, 3] = Double.Parse(gridView2.GetRowCellValue(i, "Đơn giá").ToString()).ToString().Replace(".", "").Replace(",", ".");
                            detailPU[i, 4] = Double.Parse(gridView2.GetRowCellValue(i, "Thành tiền").ToString()).ToString().Replace(".", "");
                            detailPU[i, 5] = gridView2.GetRowCellValue(i, "Số chứng từ").ToString();
                        }
                    }

                    string tongthanhtien = gridView1.Columns["Thành tiền"].SummaryText.Replace(".", "");
                    tongthanhtien = Math.Round(Double.Parse(tongthanhtien), 0).ToString();

                    string tongchietkhau = gridView1.Columns["Tiền CK"].SummaryText.Replace(".", "");

                    Double chiphi = Double.Parse(gridView2.Columns["Thành tiền"].SummaryText.Replace(".", "")) + Double.Parse(gridView1.Columns["Tiền CK"].SummaryText.Replace(".", "")) - Double.Parse(gridView1.Columns["Thành tiền"].SummaryText.Replace(".", ""));
                    string tongphi = chiphi.ToString();
                    Double tongcong = Double.Parse(tongthanhtien) + chiphi - Double.Parse(tongchietkhau) - khautru;
                    try
                    {
                        thue = Double.Parse(txttthue.Text);
                    }
                    catch { thue = 0; }
                    string ldt;
                    if (cbldt.EditValue.ToString() == "Tiền mặt/chuyển khoản") ldt = "0";
                    else if (cbldt.EditValue.ToString() == "Tiền mặt")
                    {
                        ldt = "1";
                        Double hanmuc = 20000000;
                        Double tongxuat = 0;

                        string Time = String.Format("{0:yyyy/MM/dd}", txtnhd.EditValue);

                        if (active == "0")
                            tongxuat = Double.Parse(gen.GetString("select COALESCE(Sum(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount),0) from SSInvoice where Convert(varchar, CABARefDate,111)='" + Time + "' and AccountingObjectID='" + dt + "' and AccountingObjectType='" + ldt + "' "));
                        else
                            tongxuat = Double.Parse(gen.GetString("select COALESCE(Sum(TotalAmount+TotalCost-TotalDiscountAmount-TotalFreightAmount+TotalVATAmount),0) from SSInvoice where Convert(varchar, CABARefDate,111)='" + Time + "' and AccountingObjectID='" + dt + "' and AccountingObjectType='" + ldt + "' and RefID<>'" + role + "' "));

                        if (tongxuat + tongcong + thue > hanmuc)
                        {
                            string thongbao = "Tổng số tiền mặt trong ngày vượt quá 20 triệu. Các đơn vị liên quan < " + ledv.EditValue.ToString() + " >";
                            DataTable donvi = gen.GetTable("select Distinct StockCode from SSInvoice a, Stock b where a.BranchID=b.StockID and Convert(varchar, CABARefDate,111)='" + Time + "' and AccountingObjectID='" + dt + "' and AccountingObjectType='" + ldt + "' order by StockCode");
                            for (int i = 0; i < donvi.Rows.Count; i++)
                            {
                                if (donvi.Rows[i][0].ToString() != ledv.EditValue.ToString())
                                    thongbao = thongbao + " < " + donvi.Rows[i][0].ToString() + " > ";
                            }
                            XtraMessageBox.Show(thongbao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else ldt = "2";
                    string makho = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    if (cbban.EditValue.ToString() != "Bán lẻ" && cbban.EditValue.ToString() != "Công trình" && cbban.EditValue.ToString() != "Bán sỉ")
                        cbban.EditValue = "Bán lẻ";
                    if (active == "0")
                    {
                        
                            //string ton = gen.GetString("select * from SSInvoice where RefNo='" + txtsct.Text + "'");
                        themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtquyen, txtms, txtkhhd, txtshd);
                            //XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        /*try
                        {*/
                        gen.ExcuteNonquery("insert into SSInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,AccountingObjectID1562,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalCost,TotalVATAmount,TotalDiscountAmount,DocumentIncluded,MoneyPay,Reconciled,Province,IssueBy,ParalellRefNo,CABAContactName,CustomField4,BillReceived,CustomField5,PUContactName) values(newid(),'" + makho + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text.Replace("'", "''") + "'," + n1562 + ",N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchietkhau + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + tongphi + "','" + thue.ToString() + "','" + khautru.ToString() + "',N'" + txtldkt.Text + "','" + chmoney.EditValue.ToString() + "','" + chpayphone.EditValue.ToString() + "','" + leprovince.EditValue.ToString() + "',N'" + cbban.EditValue.ToString() + "','" + txtquyen.Text + "',N'" + txttdd.Text + "',N'" + txtghichu.Text + "','" + chth.EditValue.ToString() + "','" + txtmst.Text + "','" + searchncc.EditValue.ToString() + "')");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("insert into SSInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalCost,TotalVATAmount,TotalDiscountAmount,DocumentIncluded,MoneyPay,Reconciled,Province,IssueBy,ParalellRefNo,CABAContactName,CustomField4,BillReceived,CustomField5) values(newid(),'" + makho + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchietkhau + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + tongphi + "','" + thue.ToString() + "','" + khautru.ToString() + "',N'" + txtldkt.Text + "','" + chmoney.EditValue.ToString() + "','" + chpayphone.EditValue.ToString() + "','" + leprovince.EditValue.ToString() + "',N'" + cbban.EditValue.ToString() + "','" + txtquyen.Text + "',N'" + txttdd.Text + "',N'" + txtghichu.Text + "','" + chth.EditValue.ToString() + "','"+txtmst.Text+"')");
                        }*/

                        string refid = gen.GetString("select * from SSInvoice where RefNo='" + txtsct.Text + "'");
                        if (cbthue.Text == "")
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay,Soluong) values(newid(),'" + 
                                refid + "','" + txtsct.Text + "','131','51113','" + tongcong.ToString() + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "'," + n1562 + ")");
                        }
                        else
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay,Soluong) values(newid(),'" +
                                refid + "','" + txtsct.Text + "','131','5111','" + tongcong.ToString() + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "'," + n1562 + ")");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay,Soluong) values(newid(),'" 
                                + refid + "','" + txtsct.Text + "','131','33311','" + thue.ToString().Replace(".", "") + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "'," + n1562 + ")");
                            if (searchncc.EditValue.ToString() != "")
                            {
                                string dt1388 = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + searchncc.EditValue.ToString() + "'");
                                gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + 
                                    refid + "','" + txtsct.Text + "','1388','5111','" + khautru.ToString() + "','" + dt1388 + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt1388 + "','" + chmoney.EditValue.ToString() + "')");
                            }
                        }
                        F.getrole(refid);
                        addhd(refid, gridView1, gridView2, gridView3, detail, detailPU);
                        updatekm(gridView5, refid);
                    }
                    else
                    {
                        /*try
                        {*/
                        gen.ExcuteNonquery("update SSInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text.Replace("'", "''") + "',AccountingObjectID1562=" + n1562 + ",PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchietkhau + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalCost='" + tongphi + "',TotalVATAmount='" + thue.ToString().Replace(".", "") + "',TotalDiscountAmount='" + khautru.ToString() + "',DocumentIncluded=N'" + txtldkt.Text + "',MoneyPay='" + chmoney.EditValue.ToString() + "',Reconciled='" + chpayphone.EditValue.ToString() + "',Province='" + leprovince.EditValue.ToString() + "',IssueBy=N'" + cbban.EditValue.ToString() + "',ParalellRefNo='" + txtquyen.Text + "',CABAContactName=N'" + txttdd.Text + "',CustomField4=N'" + txtghichu.Text + "',BillReceived='" + chth.EditValue.ToString() + "',CustomField5='" + txtmst.Text + "',PUContactName='" + searchncc.EditValue.ToString() + "' where RefID='" + role + "'");
                        /*}
                        catch
                        {
                            gen.ExcuteNonquery("update SSInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchietkhau + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalCost='" + tongphi + "',TotalVATAmount='" + thue.ToString().Replace(".", "") + "',TotalDiscountAmount='" + khautru.ToString() + "',DocumentIncluded=N'" + txtldkt.Text + "',MoneyPay='" + chmoney.EditValue.ToString() + "',Reconciled='" + chpayphone.EditValue.ToString() + "',Province='" + leprovince.EditValue.ToString() + "',IssueBy=N'" + cbban.EditValue.ToString() + "',ParalellRefNo='" + txtquyen.Text + "',CABAContactName=N'" + txttdd.Text + "',CustomField4=N'" + txtghichu.Text + "',BillReceived='" + chth.EditValue.ToString() + "',CustomField5='"+txtmst.Text+"' where RefID='" + role + "'");
                        }*/
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        if (cbthue.Text == "")
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay,Soluong) values(newid(),'" + role + "','" + txtsct.Text + "','131','51113','" + tongcong.ToString() + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "'," + n1562 + ")");
                        }
                        else
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay,Soluong) values(newid(),'" + role + "','" + txtsct.Text + "','131','5111','" + tongcong.ToString() + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "'," + n1562 + ")");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay,Soluong) values(newid(),'" + role + "','" + txtsct.Text + "','131','33311','" + thue.ToString().Replace(".", "") + "','" + dt + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "'," + n1562 + ")");
                            if (searchncc.EditValue.ToString() != "")
                            {
                                string dt1388 = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + searchncc.EditValue.ToString() + "'");
                                gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + role + "','" + txtsct.Text + "','1388','5111','" + khautru.ToString() + "','" + dt1388 + "','" + makho + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt1388 + "','" + chmoney.EditValue.ToString() + "')");
                            }
                        }
                        deletehd(role);
                        addhd(role, gridView1, gridView2, gridView3, detail, detailPU);
                        updatekm(gridView5, role);
                    }
                    /*try
                    {
                        F.myac();
                    }
                    catch { }*/
                    F.getactive("1");
                    F.Text = "Xem hóa đơn bán hàng";
                }
            /*}
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        public void deletehd(string hdid)
        {
            try
            {
                string check = gen.GetString("select Top 1 RefIDD from SSInvoiceINOutward where RefIDD is not NULL and SSInvoiceID='" + hdid + "'");
                gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=QuantityExits-b.Quantity,QuantityConvertExits=QuantityConvertExits-b.QuantityConvert from INOutwardDetail a, SSInvoiceINOutward b where a.RefDetailID=b.RefIDD and  SSInvoiceID='" + hdid + "' ");
            }
            catch
            {
                gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=QuantityExits-b.Quantity,QuantityConvertExits=QuantityConvertExits-b.QuantityConvert from INOutwardDetail a, SSInvoiceINOutward b where a.RefID=b.INOutwardID and a.InventoryItemID=b.InventoryItemID and  SSInvoiceID='" + hdid + "' ");
            }
            updatepn(hdid);
            gen.ExcuteNonquery("delete from SSInvoiceDetail where RefID='" + hdid + "'");
            gen.ExcuteNonquery("delete from SSInvoiceINOutward where SSInvoiceID='" + hdid + "'");
            gen.ExcuteNonquery("update INOutwardFree set IsExport='False',ExitsStore='False',RefPUID=NULL where RefPUID='"+hdid+"'");
        }
        public void updatepn(string hdid)
        {
            /*DataTable da = new DataTable();
            da = gen.GetTable("select distinct(INOutwardID) from SSInvoiceINOutward where SSInvoiceID='" + hdid + "'");
            
            for (int i = 0; i < da.Rows.Count; i++)
            {
                Double ton = 0;
                try
                {
                    ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INOutwardDetail where RefID='" + da.Rows[i][0].ToString() + "'"));
                }
                catch { }
                if (ton == 0)
                {
                    gen.ExcuteNonquery("update INOutward set IsExport='True' where RefID='" + da.Rows[i][0].ToString() + "'");
                    try
                    {
                        gen.ExcuteNonquery("update hamaco_tn.dbo.INOutwardLPG set IsExport='True' where RefID='" + gen.GetString("select INOutwardRefID from INOutward where RefID='" + da.Rows[i][0].ToString() + "'") + "'");
                    }
                    catch { }
                }
                else
                {
                    gen.ExcuteNonquery("update INOutward set IsExport='False' where RefID='" + da.Rows[i][0].ToString() + "'");
                    try
                    {
                        gen.ExcuteNonquery("update hamaco_tn.dbo.INOutwardLPG set IsExport='False' where RefID='" + gen.GetString("select INOutwardRefID from INOutward where RefID='" + da.Rows[i][0].ToString() + "'") + "'");
                    }
                    catch { }
                }
            }*/
            gen.ExcuteNonquery("update B set IsExport = case when soton=0 then 'True' else 'False' end from (select A.RefID,SUM(QuantityConvert-QuantityConvertExits) as soton from (select RefID,IsExport from INOutward with (nolock) where RefID in (select distinct INOutwardID from SSInvoiceINOutward with (nolock) where SSInvoiceID='"+ hdid+"')) A, INOutwardDetail B with (nolock) where A.RefID=B.RefID group by A.RefID) A, INOutward B where A.RefID=B.RefID");
            if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                gen.ExcuteNonquery("update B set B.IsExport=A.IsExport from (select RefID,IsExport,INOutwardRefID from INOutward with (nolock) where RefID in (select distinct INOutwardID from SSInvoiceINOutward with (nolock) where SSInvoiceID='" + hdid + "')) A, INOutwardLPG B where A.INOutwardRefID=B.RefID");
        }

        public void updatekm(GridView gridView5,string role)
        {
            for (int i = 0; i < gridView5.RowCount; i++)
            {
                try
                {
                    string chon = gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "Chọn").ToString();
                    string ton = gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "Tính giá vốn").ToString();
                    string id = gridView5.GetRowCellValue(gridView5.FocusedRowHandle, "ID").ToString();
                    if (chon == "True")
                        gen.ExcuteNonquery("update INOutwardFree set IsExport='" + chon + "',ExitsStore='" + ton + "',RefPUID='" + role + "' where RefID='" + id + "'");
                    else
                        gen.ExcuteNonquery("update INOutwardFree set IsExport='" + chon + "',ExitsStore='False',RefPUID=Null where RefID='" + id + "'");
                }
                catch { }
            }
        }

        public void addhd(string refid, GridView gridView1, GridView gridView2, GridView gridView3, string[,] detail, string[,] detailPU)
        {
            string sql = "", sql1 = "";
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                try
                {
                    //gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "','" + detailPU[i, 4] + "','" + detailPU[i, 1] + "','" + detailPU[i, 2] + "'," + i + ",'" + detailPU[i, 0] + "','" + detailPU[i, 3] + "','" + detailPU[i, 5] + "')");
                sql = sql + "insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "','" + detailPU[i, 4] + "','" + detailPU[i, 1] + "','" + detailPU[i, 2] + "'," + i + ",'" + detailPU[i, 0] + "','" + detailPU[i, 3] + "','" + detailPU[i, 5] + "');";
                }
                catch { }
            }
            if (sql != "")
                gen.ExcuteNonquery(sql);
            
            sql = "";
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (detail[i, 0] != null)
                {
                    //gen.ExcuteNonquery("insert into SSInvoiceINOutward values(newid(),'" + refid + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','131','" + detail[i, 7] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','"+i+"','"+detail[i, 15]+"')");
                    sql = sql + "insert into SSInvoiceINOutward values(newid(),'" + refid + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 6] + "','131','" + detail[i, 7] + "','" + detail[i, 10] + "','" + detail[i, 11] + "','" + detail[i, 12] + "','" + i + "','" + detail[i, 15] + "');";
                    ///////gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=QuantityExits  + '" + detail[i, 3] + "',QuantityConvertExits=QuantityConvertExits +'" + detail[i, 4] + "' where RefID='" + detail[i, 0] + "' and InventoryItemID='" + detail[i, 2] + "' and UnitPrice='" + detail[i, 5] + "'");
                    //gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=QuantityExits  + '" + detail[i, 3] + "',QuantityConvertExits=QuantityConvertExits +'" + detail[i, 4] + "' where RefDetailID='" + detail[i, 15] + "'");
                    sql1 = sql1 + "update INOutwardDetail set QuantityExits=QuantityExits  + '" + detail[i, 3] + "',QuantityConvertExits=QuantityConvertExits +'" + detail[i, 4] + "' where RefDetailID='" + detail[i, 15] + "';";
                }
            }
            if (sql != "")
            {
                gen.ExcuteNonquery(sql);
                gen.ExcuteNonquery(sql1);
            }

            sql = null;
            sql1 = null;
            
            /*
            string congty = gen.GetString("select Top 1 CompanyTaxCode from Center");
            for (int i = 0; i < gridView3.RowCount; i++)
            {
                try
                {
                    if (gridView3.GetRowCellValue(i, "Chọn").ToString() == "True")
                    {
                        Double ton = Double.Parse(gen.GetString("select sum(QuantityConvert-QuantityConvertExits) from INOutwardDetail where RefID='" + gridView3.GetRowCellValue(i, "ID").ToString() + "'"));
                        if (ton == 0)
                        {
                            //gen.ExcuteNonquery("update INOutward set IsExport='True' where RefID='" + gridView3.GetRowCellValue(i, "ID").ToString() + "'");
                            sql = sql + "update INOutward set IsExport='True' where RefID='" + gridView3.GetRowCellValue(i, "ID").ToString() + "';";
                            if (congty == "1801115004")
                                try
                                {
                                    gen.ExcuteNonquery("update INOutwardLPG set IsExport='True' where RefID='" + gen.GetString("select INOutwardRefID from INOutward where RefID='" + gridView3.GetRowCellValue(i, "ID").ToString() + "'") + "'");
                                }
                                catch { }
                        }
                    }
                }
                catch { }
            }
            if (sql != "")
                gen.ExcuteNonquery(sql);
            */
            gen.ExcuteNonquery("update B set IsExport='True' from (select A.RefID,SUM(QuantityConvert-QuantityConvertExits) as soton from (select RefID,IsExport from INOutward with (nolock) where RefID in (select distinct INOutwardID from SSInvoiceINOutward with (nolock) where SSInvoiceID='" + refid + "')) A, INOutwardDetail B with (nolock) where A.RefID=B.RefID group by A.RefID) A, INOutward B where soton=0 and A.RefID=B.RefID");
            if (gen.GetString("select Top 1 CompanyTaxCode from Center") == "1801115004")
                gen.ExcuteNonquery("update B set IsExport='True' from (select RefID,IsExport,INOutwardRefID from INOutward with (nolock) where RefID in (select distinct INOutwardID from SSInvoiceINOutward with (nolock) where SSInvoiceID='" + refid + "')) A, INOutwardLPG B where A.INOutwardRefID=B.RefID and A.IsExport='True'");
        }

        public void tsbtdeletehdbh(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from SSInvoice where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (view.GetRowCellValue(view.FocusedRowHandle, "Phiếu xuất").ToString() == "False")
                {
                    if (XtraMessageBox.Show("Bạn có chắc muốn xoá hóa đơn bán hàng " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        deletehd(name);
                        gen.ExcuteNonquery("delete from SSInvoice where RefID='" + name + "'");
                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                        view.DeleteRow(view.FocusedRowHandle);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Đây là Hóa đơn có kèm phiếu xuất vui lòng chuyển sang mục < Hóa đơn kiêm phiếu xuất > để xóa phiếu này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn hóa đơn bán hàng trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }


        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdbanhang F, string ngay, string branchid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdbanhang F, string ngay, string branchid)
        {
            try
            {
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from SSInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from SSInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

    }
}
