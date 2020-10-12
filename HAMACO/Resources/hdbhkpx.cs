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
    class hdbhkpx
    {
        gencon gen = new gencon();
        public void tsbtpxk(string a, Form1 F, DevExpress.XtraGrid.Views.Grid.GridView view, string roleid, string subsys, string ngaychungtu, string userid, string branchid,DataTable khach,DataTable hang)
        {
            try
            {
                Frm_hdbhkpx u = new Frm_hdbhkpx();
                u.myac = new Frm_hdbhkpx.ac(F.refreshhdbhkpx);
                u.getactive(a);
                u.getroleid(roleid);
                u.getkhach(khach);
                u.gethang(hang);
                u.getsub(subsys);
                u.getpt("pxk");
                u.getdate(ngaychungtu);
                u.getuser(userid);
                u.getbranch(branchid);

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

                u.ShowDialog();
            }
            catch { MessageBox.Show("Vui lòng chọn phiếu trước khi sửa."); }
        }


        public void loadstart(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, LookUpEdit ledt, ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat,
            ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, string active, DataTable dt, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, ComboBoxEdit cbthue, LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau,
            TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, LookUpEdit leprovince, ComboBoxEdit cbban, DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2, DataTable dt1, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco,DataTable khach,DataTable hang)
        {
           
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

            temp.Columns.Add("Mã kho");
            temp.Columns.Add("Tên kho");
            da = gen.GetTable("select * from Stock where StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by StockCode");
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
            mahang.ValueMember = "Mã hàng";
            mahang.PopupWidth = 300;*/
           
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
           
            /*da = gen.GetTable("select AccountingObjectCode,AccountingObjectName from AccountingObject a, Branch b where a.BranchID=b.BranchID and b.BranchID='" + branchid + "' and IsEmployee='True' order by AccountingObjectCode");
            DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã nhân viên");
            temp4.Columns.Add("Tên nhân viên");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp4.Rows.Add(dr);
            }
            lenv.Properties.DataSource = temp4;
            lenv.Properties.DisplayMember = "Mã nhân viên";
            lenv.Properties.ValueMember = "Mã nhân viên";
            lenv.Properties.PopupWidth = 300;*/
            DataTable temp4 = new DataTable();
            temp4.Columns.Add("Mã nhân viên");
            temp4.Columns.Add("Tên nhân viên");
            for (int i = 0; i < khach.Rows.Count; i++)
            {
                DataRow dr = temp4.NewRow();
                dr[0] = khach.Rows[i][1].ToString();
                dr[1] = khach.Rows[i][2].ToString();
                temp4.Rows.Add(dr);
            }
            lenv.Properties.DataSource = temp4;
            lenv.Properties.DisplayMember = "Mã nhân viên";
            lenv.Properties.ValueMember = "Mã nhân viên";
            lenv.Properties.PopupWidth = 300;

            dt.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng");
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Thành tiền", Type.GetType("System.Double"));
            dt.Columns.Add("Chi phí", Type.GetType("System.Double"));
            dt.Columns.Add("Chiết khấu", Type.GetType("System.Double"));
            dt.Columns.Add("Tiền CK", Type.GetType("System.Double"));

            gridControl1.DataSource = dt;
            gridView1.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView1.Columns["Số lượng"].ColumnEdit = soluong;
            gridView1.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;

            gridView1.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";

            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Số lượng quy đổi"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Số lượng"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng"].SummaryItem.DisplayFormat = "{0:n0}";
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Số lượng quy đổi"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Đơn giá"].ColumnEdit = dongia;
            gridView1.Columns["Thành tiền"].ColumnEdit = thanhtien;
            gridView1.Columns["Chi phí"].ColumnEdit = chiphi;
            gridView1.Columns["Chiết khấu"].ColumnEdit = chietkhau;

            gridView1.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            gridView1.Columns["Đơn giá"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Average;
            gridView1.Columns["Đơn giá"].SummaryItem.DisplayFormat = "{0:n2}";

            gridView1.Columns["Thành tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Thành tiền"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Thành tiền"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Thành tiền"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Chi phí"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chi phí"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Chi phí"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Chi phí"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            gridView1.Columns[0].SummaryItem.DisplayFormat = "Số dòng = {0}";

            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Chiết khấu"].DisplayFormat.FormatString = "{0:n2}";

            gridView1.Columns["Tiền CK"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            gridView1.Columns["Tiền CK"].DisplayFormat.FormatString = "{0:n0}";
            gridView1.Columns["Tiền CK"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridView1.Columns["Tiền CK"].SummaryItem.DisplayFormat = "{0:n0}";

            gridView1.Columns["Tiền CK"].OptionsColumn.AllowEdit = false;

            DataTable temp5 = new DataTable();
            da = gen.GetTable("select AccountNumber,AccountName from Account order by AccountNumber");
            temp5.Columns.Add("Mã tài khoản");
            temp5.Columns.Add("Tên tài khoản");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                DataRow dr = temp5.NewRow();
                dr[0] = da.Rows[i][0].ToString();
                dr[1] = da.Rows[i][1].ToString();
                temp5.Rows.Add(dr);
            }

            da = gen.GetTable("select AccountNumber,AccountName from Account where AccountCategoryID=156 order by AccountNumber");
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

            tkno.DataSource = temp5;
            tkno.DisplayMember = "Mã tài khoản";
            tkno.ValueMember = "Mã tài khoản";

            tkco.DataSource = temp2;
            tkco.DisplayMember = "Mã tài khoản";
            tkco.ValueMember = "Mã tài khoản";


            dt1.Columns.Add("Tài khoản nợ", Type.GetType("System.String"));
            dt1.Columns.Add("Tài khoản có", Type.GetType("System.String"));
            dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt1.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt1.Columns.Add("Số lượng quy đổi", Type.GetType("System.Double"));
            gridControl2.DataSource = dt1;
            gridView2.Columns["Mã hàng"].ColumnEdit = mahang;
            gridView2.Columns["Số lượng"].ColumnEdit = soluong;
            gridView2.Columns["Số lượng quy đổi"].ColumnEdit = soluongqd;
            gridView2.Columns["Tài khoản có"].ColumnEdit = tkco;
            gridView2.Columns["Tài khoản nợ"].ColumnEdit = tkno;

        }

        public void loadpxk(string active, string role, DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, TextEdit txtsct, ComboBoxEdit cbldt, LookUpEdit ledv, DateEdit denct, DateEdit denht,
            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit mahang, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluong, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit soluongqd, Frm_hdbhkpx F, LookUpEdit ledt, TextEdit txtldn, TextEdit txtctg,
            ToolStripButton tsbtsua, ToolStripButton tsbtxoa, ToolStripButton tsbtcat, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtnap, ToolStripSplitButton tsbtin, string ngaychungtu, string userid, string branchid, TextEdit txtngh, TextEdit txtptvc, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit dongia, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit thanhtien, TextEdit txtcth, ComboBoxEdit cbthue
            , LookUpEdit lenv, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chiphi, DevExpress.XtraEditors.Repository.RepositoryItemTextEdit chietkhau, TextEdit ttck, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, LookUpEdit leprovince, ComboBoxEdit cbban,TextEdit txtquyen,DevExpress.XtraGrid.GridControl gridControl2, GridView gridView2,TextEdit txtms,
            TextEdit txtkhhd, TextEdit txtshd, TextEdit txtldkt, TextEdit txttdd, TextEdit txtdc, TextEdit txtkt, CheckEdit chemoney, CheckEdit chepayphone, TextEdit txttthue, TextEdit txtspx, TextEdit txtspkm, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkno, DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit tkco,TextEdit txtck,DataTable khach,DataTable hang, TextEdit txtname,TextEdit txtmst,TextEdit txtghichu)
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            txtspkm.Text = "";
            loadstart(gridControl1, gridView1, cbldt, ledv, denct, denht, mahang, soluong, soluongqd, ledt, tsbtsua, tsbtxoa, tsbtcat, tsbtboghi, tsbtghiso, tsbtnap, tsbtin, ngaychungtu, userid, branchid, active, dt, dongia, thanhtien, cbthue, lenv, chiphi, chietkhau,txtnhd,txthtt,txthttt,leprovince,cbban,gridControl2,gridView2,dt1,tkno,tkco,khach,hang);
            if (active == "1")
            {
                DataTable da = new DataTable();
                da = gen.GetTable("select InventoryItemCode,InventoryItemName,Quantity,QuantityConvert,a.UnitPrice,a.TotalAmount,Cost,DiscountRate,DiscountAmount,INOutwardID from SSInvoiceINOutward a,InventoryItem b where a.InventoryItemID=b.InventoryItemID and SSInvoiceID='" + role + "' order by SortOrder");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = da.Rows[i][0].ToString();
                    dr[1] = da.Rows[i][1].ToString();
                    dr[2] = da.Rows[i][2].ToString();
                    dr[3] = da.Rows[i][3].ToString();
                    dr[4] = da.Rows[i][4].ToString();
                    dr[5] = da.Rows[i][5].ToString();
                    dr[6] = da.Rows[i][6].ToString();
                    dr[7] = da.Rows[i][7].ToString();
                    dr[8] = da.Rows[i][8].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                tsbtcat.Enabled = false;
             
                F.Text = "Xem hóa đơn bán hàng kiêm phiếu xuất";



                da = gen.GetTable("select AccountingObjectCode,RefNo,Posted,AccountingObjectType,Cancel,PUPostedDate,PURefDate,CABARefDate,PUJournalMemo,TotalAmount,DueDateTime,AccountingObjectID1562,Tax,No,InvSeries,InvNo,PayNo,DocumentIncluded,TotalDiscountAmount,TotalVATAmount,MoneyPay,Reconciled,a.Province,StockCode,a.IssueBy,ParalellRefNo,CABAContactName,a.AccountingObjectAddress,TotalFreightAmount,a.AccountingObjectName,a.CustomField5,CustomField4,ShippingMethodID,IsExport  from SSInvoice a, AccountingObject b,Stock c where a.BranchID=c.StockID and a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                ledv.EditValue = da.Rows[0][23].ToString();
                try
                {
                    cbldt.SelectedIndex = Int32.Parse(da.Rows[0][3].ToString());
                }
                catch { }
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
                txtldkt.Text = da.Rows[0][17].ToString();
                leprovince.EditValue = da.Rows[0][22].ToString();
                cbban.EditValue = da.Rows[0][24].ToString();
                txtquyen.Text = da.Rows[0][25].ToString();
                txttdd.Text = da.Rows[0][26].ToString();
                txtdc.Text = da.Rows[0][27].ToString();
                txtck.EditValue = string.Format("{0:n0}",Double.Parse(da.Rows[0][28].ToString()));
                txtname.Text = da.Rows[0][29].ToString();
                txtmst.Text = da.Rows[0][30].ToString();
                txtghichu.Text = da.Rows[0][31].ToString();
                try
                {
                    txtkt.EditValue = Double.Parse(da.Rows[0][18].ToString());
                }
                catch { }
                Double tienthue = 0;
                try
                {
                    tienthue = Double.Parse(da.Rows[0][19].ToString());
                }
                catch { }
                try
                {
                    string n1562 = gen.GetString("select AccountingObjectCode from AccountingObject where AccountingObjectID='" + da.Rows[0][11].ToString() + "'");
                    lenv.EditValue = n1562;
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
                

                if (da.Rows[0][20].ToString() == "True")
                    chemoney.EditValue = true;
                if (da.Rows[0][21].ToString() == "True")
                    chepayphone.EditValue = true;
                txtcth.Text = String.Format("{0:n0}", Double.Parse(gridView1.Columns["Thành tiền"].SummaryText) + Double.Parse(gridView1.Columns["Chi phí"].SummaryText));
                txttthue.EditValue = tienthue;
                try
                { 
                    txtspkm.Text = gen.GetString("select RefNo from INOutwardFree where RefPUID='" + role + "'");
                }
                catch { }
                checktruocsau(tsbttruoc, tsbtsau, ledv.EditValue.ToString(), txtsct.Text, ngaychungtu);

                da = gen.GetTable("select AccountingObjectCode,a.Contactname,JournalMemo,DocumentIncluded,RefDate,PostedDate,RefNo,StockCode,Posted,AccountingObjectType,Cancel,ShippingNo,Tax,EmployeeIDSA  from INOutward a, AccountingObject b,Stock c where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and RefID='" + da.Rows[0][32].ToString() + "'");

                txtctg.Text = da.Rows[0][3].ToString();
                txtspx.Text = da.Rows[0][6].ToString();
                txtngh.Text = da.Rows[0][1].ToString();
                txtptvc.Text = da.Rows[0][11].ToString();

            }
            else
            {
                F.Text = "Thêm hóa đơn bán hàng kiêm phiếu xuất";
                cbldt.SelectedIndex = 0;
                cbthue.EditValue = "10";
                cbban.EditValue = "Bán lẻ";
                if (role == null)
                    ledv.ItemIndex = 0;
                else ledv.EditValue = role;
                F.Text = "Thêm hóa đơn bán hàng";
                txthttt.Text = "TM/CK";
                txthtt.Text = "0";
                denct.EditValue = DateTime.Parse(ngaychungtu);
                denht.EditValue = DateTime.Parse(ngaychungtu);
                txtnhd.EditValue = DateTime.Parse(ngaychungtu);
                leprovince.EditValue = "CT";
            }
        }

        public void themsct(string ngaychungtu, TextEdit txtsct, string kho, string branchid, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, TextEdit txtquyen, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd,string check)
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

            try
            {
                string id = gen.GetString("select Top 1 RefNo from SSInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");

                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;

                if (check == "0")
                {
                    DataTable temp = gen.GetTable("select Top 1 ParalellRefNo,No,InvSeries,InvNo from SSInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + makho + "'  order by RefNo DESC");
                    txtquyen.EditValue = temp.Rows[0][0].ToString();
                    txtms.EditValue = temp.Rows[0][1].ToString();
                    txtkhhd.EditValue = temp.Rows[0][2].ToString();

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

            }
            catch
            {
                sophieu = sophieu + "00001" + nam;
            }

            txtsct.Text = sophieu;
            checktruocsau(tsbttruoc, tsbtsau, kho, sophieu, ngaychungtu);
        }

        public void themsctpx(string ngaychungtu, TextEdit txtsct, string mk, string branchid)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            txtsct.Text = sophieu;
        }
        public void checktruoc(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdbhkpx F, string ngay, string branchid)
        {
            try
            {
                tsbtsau.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and IsExport='True' order by RefNo DESC");
                else
                {
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and IsExport='True' order by RefNo ASC");
                    tsbttruoc.Enabled = false;
                }
                F.getrole(id);
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }

        public void checksau(string sct, int vt, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau, Frm_hdbhkpx F, string ngay, string branchid)
        {
            try
            {
                tsbttruoc.Enabled = true;
                string id;
                if (vt == 0)
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and IsExport='True'  order by RefNo ASC");
                else
                {
                    id = gen.GetString("select Top 1 * from SSInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngay).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngay).Year.ToString() + "' and BranchID='" + branchid + "' and IsExport='True' order by RefNo DESC");
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
                string id = gen.GetString("select Top 1 * from SSInvoice where RefNo > '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "' and IsExport='True'");
            }
            catch
            {
                tsbtsau.Enabled = false;
            }
            try
            {
                tsbttruoc.Enabled = true;
                string id = gen.GetString("select Top 1 * from SSInvoice where RefNo < '" + sct + "' and Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + idkho + "' and IsExport='True'");
            }
            catch
            {
                tsbttruoc.Enabled = false;
            }
        }


        public void checkpxk(string active, string role, Frm_hdbhkpx F, GridView gridView1, LookUpEdit ledt, LookUpEdit ledv, ComboBoxEdit cbldt, TextEdit txtsct, TextEdit txtname, TextEdit txtdc,
           TextEdit txtngh, TextEdit txtctg, TextEdit txtldn, DateEdit denct, DateEdit denht, ToolStripButton tsbtboghi, ToolStripButton tsbtghiso, ToolStripButton tsbtxoa,
           ToolStripButton tsbtcat, ToolStripSplitButton tsbtin, ToolStripButton tsbtsua, ToolStripButton tsbtnap, string ngaychungtu, TextEdit txtmst, TextEdit txtptvc, string userid, string branchid, ComboBoxEdit cbthue, LookUpEdit lenv, ToolStripSplitButton tsbttruoc, ToolStripSplitButton tsbtsau,
            TextEdit txtquyen, TextEdit txtms, TextEdit txtkhhd, TextEdit txtshd, TextEdit txtnhd, TextEdit txthtt, TextEdit txthttt, CheckEdit chmoney, CheckEdit chpayphone, LookUpEdit leprovince, ComboBoxEdit cbban, TextEdit txtkt, TextEdit txtspx, TextEdit txtpkm, TextEdit txtldkt, TextEdit txttdd, TextEdit txttthue, GridView gridView2, CheckEdit chton,TextEdit txtghichu, DataTable hangton)
        {
            try
            {
                if (gridView2.RowCount + gridView1.RowCount > 13)
                {
                    XtraMessageBox.Show("Hóa đơn không được xuất quá 11 dòng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int dem = 0;
                Double phantram, khautru, thue;
                try { phantram = Double.Parse(txtkt.Text); khautru = Double.Parse(txtkt.Text); }
                catch { phantram = 0; khautru = 0; }
                Double tientong = Double.Parse(gridView1.Columns["Thành tiền"].SummaryText.Replace(".", ""));

                string dt = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + ledt.EditValue.ToString() + "'");
                string[,] detail = new string[20, 20];
                string check = "0";
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == "")
                        check = "1";
                    else
                    {
                        string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView1.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        detail[i, 0] = mh;
                    }
                    if (gridView1.GetRowCellValue(i, "Số lượng").ToString() == "")
                        detail[i, 1] = "0";
                    else
                        detail[i, 1] = gridView1.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                        check = "1";
                    detail[i, 2] = gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Đơn giá").ToString() == "")
                        check = "1";
                    detail[i, 4] = gridView1.GetRowCellValue(i, "Đơn giá").ToString().Replace(".", "").Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Thành tiền").ToString() == "")
                        check = "1";
                    detail[i, 5] = gridView1.GetRowCellValue(i, "Thành tiền").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Chi phí").ToString() == "")
                        detail[i, 6] = "0";
                    else
                        detail[i, 6] = gridView1.GetRowCellValue(i, "Chi phí").ToString().Replace(".", "");
                    if (gridView1.GetRowCellValue(i, "Chiết khấu").ToString() == "")
                        detail[i, 3] = "0";
                    else
                        detail[i, 3] = gridView1.GetRowCellValue(i, "Chiết khấu").ToString().Replace(",", ".");
                    if (gridView1.GetRowCellValue(i, "Tiền CK").ToString() == "")
                        detail[i, 7] = "0";
                    else
                        detail[i, 7] = gridView1.GetRowCellValue(i, "Tiền CK").ToString();


                    dem = dem + 1;
                    if (phantram != 0)
                    {
                        Double tien = Double.Parse(gridView1.GetRowCellValue(i, "Thành tiền").ToString());
                       
                        detail[i, 8] = (tien / tientong).ToString();
                    }
                    else detail[i, 8] = "0";

                    Double tienc = Double.Parse(detail[i, 5]) + Double.Parse(detail[i, 6]) - Double.Parse(detail[i, 7]);
                    Double slqd = Double.Parse(gridView1.GetRowCellValue(i, "Số lượng quy đổi").ToString());
                    detail[i, 9] = tienc.ToString();
                    detail[i, 10] = Math.Round((tienc / slqd), 2).ToString().Replace(",", ".");
                }

                if (phantram != 0)
                {
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        if (dem > 0)
                        {
                            try
                            {
                                Double tien = Double.Parse(detail[i, 8]);
                                if (dem == 1)
                                    detail[i, 8] = Math.Round(phantram, 0).ToString();
                                else
                                {
                                    detail[i, 8] = Math.Round(khautru * tien, 0).ToString();
                                    phantram = phantram - Math.Round(khautru * tien, 0);
                                }
                            }
                            catch { }
                            dem = dem - 1;
                        }
                    }
                }

                string[,] detail1 = new string[20, 8];


                if (gridView2.RowCount > 1)
                {
                    for (int i = 0; i < gridView2.RowCount - 1; i++)
                    {
                        if (gridView2.GetRowCellValue(i, "Tài khoản có").ToString() == "")
                            check = "1";
                        detail1[i, 0] = gridView2.GetRowCellValue(i, "Tài khoản có").ToString();
                        if (gridView2.GetRowCellValue(i, "Tài khoản nợ").ToString() == "")
                            check = "1";
                        detail1[i, 1] = gridView2.GetRowCellValue(i, "Tài khoản nợ").ToString();
                        if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == "")
                            check = "1";
                        else
                        {
                            string mh = gen.GetString("select * from InventoryItem where InventoryItemCode='" + gridView2.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                            detail1[i, 2] = mh;
                        }
                        if (gridView2.GetRowCellValue(i, "Số lượng").ToString() == "")
                            detail1[i, 3] = "0";
                        else
                            detail1[i, 3] = gridView2.GetRowCellValue(i, "Số lượng").ToString().Replace(".", "");
                        detail1[i, 4] = "0";
                        detail1[i, 5] = "0";
                        if (gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString() == "")
                            detail1[i, 6] = "0";
                        else
                            detail1[i, 6] = gridView2.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(".", "").Replace(",", ".");
                    }
                }

                if (check == "1")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu <Mã hàng> <Số lượng quy đổi> !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    string dv = gen.GetString("select * from Stock where StockCode='" + ledv.EditValue.ToString() + "'");

                    string tongthanhtien = Math.Round(Double.Parse(gridView1.Columns["Thành tiền"].SummaryText),0).ToString();
                    string tongchiphi = gridView1.Columns["Tiền CK"].SummaryText;
                    tongthanhtien = tongthanhtien.Replace(".", "");
                    tongchiphi = tongchiphi.Replace(".", "");

                    //Double chiphi = Double.Parse(gridView2.Columns["Thành tiền"].SummaryText.Replace(".", "")) + Double.Parse(gridView1.Columns["Tiền CK"].SummaryText.Replace(".", "")) - Double.Parse(gridView1.Columns["Thành tiền"].SummaryText.Replace(".", ""));
                    Double chiphi = Double.Parse(gridView1.Columns["Chi phí"].SummaryText.Replace(".", ""));
                    string tongphi = chiphi.ToString();
                    Double tongcong = Double.Parse(tongthanhtien) + chiphi - Double.Parse(tongchiphi) - khautru;

                    try
                    {
                        thue = Double.Parse(txttthue.Text);
                    }
                    catch { thue = 0; }

                    if (cbban.EditValue.ToString() != "Bán lẻ" && cbban.EditValue.ToString() != "Công trình" && cbban.EditValue.ToString() != "Bán sỉ")
                        cbban.EditValue = "Bán lẻ";

                    string nv = "";
                    try
                    {
                        nv = gen.GetString("select * from AccountingObject where AccountingObjectCode='" + lenv.EditValue.ToString() + "'");
                    }
                    catch { }


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



                    if (active == "0")
                    {
                        try
                        {
                            string ton = gen.GetString("select * from INOutward where RefNo='" + txtspx.Text + "'");
                            themsctpx(ngaychungtu, txtspx, ledv.EditValue.ToString(), branchid);
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtspx.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }

                        try
                        {
                            string ton = gen.GetString("select * from SSInvoice where RefNo='" + txtsct.Text + "'");
                            themsct(ngaychungtu, txtsct, branchid, ledv.EditValue.ToString(), tsbttruoc, tsbtsau, txtquyen, txtms, txtkhhd, txtshd,"1");
                            XtraMessageBox.Show("Số phiếu trùng, hệ thống tự động chỉnh số phiếu của bạn thành " + txtsct.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                        
                        try
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,IsExport,TotalAmountOC) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtspx.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + nv + "','" + tongchiphi + "','" + tongthanhtien + "','True','" + thue.ToString().ToString().Replace(".", "") + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,TotalFreightAmount,TotalAmount,IsExport,TotalAmountOC) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtspx.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtngh.Text + "',N'" + txtldn.Text + "',N'" + txtctg.Text + "','False','" + dv + "','" + ldt + "','" + txtptvc.Text + "','" + cbthue.Text + "','" + userid + "','" + tongchiphi + "','" + tongthanhtien + "','True','" + thue.ToString().ToString().Replace(".", "") + "')");
                        }
                        string refidpx = gen.GetString("select * from INOutward where RefNo='" + txtspx.Text + "'");
                        try
                        {
                            gen.ExcuteNonquery("insert into SSInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,AccountingObjectID1562,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalCost,TotalVATAmount,TotalDiscountAmount,DocumentIncluded,MoneyPay,Reconciled,Province,IssueBy,ParalellRefNo,CABAContactName,IsExport,ShippingMethodID,CustomField5,CustomField4) values(newid(),'" + dv + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "','" + nv + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + tongphi + "','" + thue.ToString() + "','" + khautru.ToString() + "',N'" + txtldkt.Text + "','" + chmoney.EditValue.ToString() + "','" + chpayphone.EditValue.ToString() + "','" + leprovince.EditValue.ToString() + "',N'" + cbban.EditValue.ToString() + "','" + txtquyen.Text + "',N'" + txttdd.Text + "','True','" + refidpx + "','" + txtmst.Text + "',N'"+txtghichu.Text+"')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into SSInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalCost,TotalVATAmount,TotalDiscountAmount,DocumentIncluded,MoneyPay,Reconciled,Province,IssueBy,ParalellRefNo,CABAContactName,IsExport,ShippingMethodID,CustomField5,CustomField4) values(newid(),'" + dv + "',101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtsct.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtdc.Text + "',N'" + txtldn.Text + "','False','" + ldt + "','" + tongthanhtien + "','" + cbthue.Text + "','" + txtkhhd.Text + "','" + txtshd.Text + "'," + txthtt.Text + ",'" + tongchiphi + "','" + userid + "','" + txtnhd.EditValue.ToString() + "','" + txtms.Text + "',N'" + txthttt.Text + "','" + tongphi + "','" + thue.ToString() + "','" + khautru.ToString() + "',N'" + txtldkt.Text + "','" + chmoney.EditValue.ToString() + "','" + chpayphone.EditValue.ToString() + "','" + leprovince.EditValue.ToString() + "',N'" + cbban.EditValue.ToString() + "','" + txtquyen.Text + "',N'" + txttdd.Text + "','True','" + refidpx + "','" + txtmst.Text + "',N'"+txtghichu.Text+"')");
                        }

                        string refid = gen.GetString("select * from SSInvoice where RefNo='" + txtsct.Text + "'");
                        if (cbthue.Text == "")
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + refid + "','" + txtsct.Text + "','131','51113','" + tongcong.ToString() + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "')");
                        }
                        else
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + refid + "','" + txtsct.Text + "','131','5111','" + tongcong.ToString() + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + refid + "','" + txtsct.Text + "','131','33311','" + thue.ToString().Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "')");
                        }
                            F.getrole(refid);

                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            try
                            {
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values(newid(),'" + refidpx + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "',N'" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 6] + "','" + detail[i, 7] + "')");
                            }
                            catch { }
                            try
                            {
                                gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "','" + detail[i, 9] + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 10] + "','" + refidpx + "')");
                            }
                            catch { }
                            try
                            {
                                gen.ExcuteNonquery("insert into SSInvoiceINOutward values(newid(),'" + refid + "','" + refidpx + "','" + dv + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','131','" + detail[i, 3] + "','" + detail[i, 7] + "','" + detail[i, 6] + "','" + detail[i, 8] + "','" + i + "',NULL)");
                            }
                            catch { }

                            for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                    break;
                                }
                            }

                        }
                        if (gridView2.RowCount > 1)
                        {
                            themsctkm(ngaychungtu, txtpkm, ledv.EditValue.ToString(), branchid);
                            gen.ExcuteNonquery("insert into INOutwardFree(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,IsExport,ExitsStore,RefPUID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtpkm.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "',0,'" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','" + txtms.Text + "','True','"+chton.Checked+"','"+refid+"')");
                            string refidkm = gen.GetString("select * from INOutwardFree where RefNo='" + txtpkm.Text + "'");
                            for (int i = 0; i < gridView2.RowCount - 1; i++)
                            {
                                gen.ExcuteNonquery("insert into INOutwardFreeDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert) values(newid(),'" + refidkm + "','" + detail1[i, 1] + "','" + detail1[i, 0] + "','" + detail1[i, 5] + "','" + detail1[i, 3] + "'," + i + ",'" + detail1[i, 2] + "','" + detail1[i, 4] + "','" + detail[i, 6] + "')");
                                try
                                {
                                    gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "',0,'" + detail1[i, 3] + "','" + detail1[i, 6] + "'," + (gridView1.RowCount+i).ToString() + ",'" + detail1[i, 2] + "','0','" + refidkm + "')");
                                }
                                catch { }
                                for (int j = 0; j < hangton.Rows.Count; j++)
                                {
                                    if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                    {
                                        hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail1[i, 3]);
                                        hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail1[i, 6]);
                                        break;
                                    }
                                }
                            }
                           
                        }
                    }
                    else
                    {
                        string refid = role;
                        string refidpx = gen.GetString("select * from INOutward where RefNo='" + txtspx.Text + "'");
                        try
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA='" + nv + "',TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue.ToString().ToString().Replace(".", "") + "'  where RefID='" + refidpx + "'");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update INOutward set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',AccountingObjectAddress=N'" + txtdc.Text + "',Contactname=N'" + txtngh.Text + "',JournalMemo=N'" + txtldn.Text + "',DocumentIncluded=N'" + txtctg.Text + "',StockID='" + dv + "',AccountingObjectType='" + ldt + "',Posted='False',ShippingNo='" + txtptvc.Text + "',Tax='" + cbthue.Text + "',EmployeeID='" + userid + "',EmployeeIDSA = Null,TotalFreightAmount='" + tongchiphi + "',TotalAmount='" + tongthanhtien + "',TotalAmountOC='" + thue.ToString().ToString().Replace(".", "") + "'  where RefID='" + refidpx + "'");
                        }
                        try
                        {
                            gen.ExcuteNonquery("update SSInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',AccountingObjectID1562='" + nv + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalCost='" + tongphi + "',TotalVATAmount='" + thue.ToString().Replace(".", "") + "',TotalDiscountAmount='" + khautru.ToString() + "',DocumentIncluded=N'" + txtldkt.Text + "',MoneyPay='" + chmoney.EditValue.ToString() + "',Reconciled='" + chpayphone.EditValue.ToString() + "',Province='" + leprovince.EditValue.ToString() + "',IssueBy=N'" + cbban.EditValue.ToString() + "',ParalellRefNo='" + txtquyen.Text + "',CABAContactName=N'" + txttdd.Text + "',CustomField5='" + txtmst.Text + "',CustomField4=N'"+txtghichu.Text+"' where RefID='" + role + "'");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("update SSInvoice set PURefDate='" + denct.EditValue.ToString() + "',PUPostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "', AccountingObjectAddress=N'" + txtdc.Text + "',PUJournalMemo=N'" + txtldn.Text + "',AccountingObjectType='" + ldt + "',TotalAmount='" + tongthanhtien + "',Tax='" + cbthue.Text + "',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',DueDateTime=" + txthtt.Text + ",TotalFreightAmount='" + tongchiphi + "',UserID='" + userid + "',CABARefDate='" + txtnhd.EditValue.ToString() + "',No='" + txtms.Text + "',PayNo=N'" + txthttt.Text + "',TotalCost='" + tongphi + "',TotalVATAmount='" + thue.ToString().Replace(".", "") + "',TotalDiscountAmount='" + khautru.ToString() + "',DocumentIncluded=N'" + txtldkt.Text + "',MoneyPay='" + chmoney.EditValue.ToString() + "',Reconciled='" + chpayphone.EditValue.ToString() + "',Province='" + leprovince.EditValue.ToString() + "',IssueBy=N'" + cbban.EditValue.ToString() + "',ParalellRefNo='" + txtquyen.Text + "',CABAContactName=N'" + txttdd.Text + "',CustomField5='" + txtmst.Text + "',CustomField4=N'"+txtghichu.Text+"' where RefID='" + role + "'");
                        }

                        gen.ExcuteNonquery("delete HACHTOAN where RefID='" + role + "'");
                        if (cbthue.Text == "")
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + role + "','" + txtsct.Text + "','131','51113','" + tongcong.ToString() + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "')");
                        }
                        else
                        {
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + role + "','" + txtsct.Text + "','131','5111','" + tongcong.ToString() + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "')");
                            gen.ExcuteNonquery("insert into HACHTOAN(RefDeteail,RefID,RefNo,DebitAccount,CreditAccount,Amount,AccountingObjectID,StockID,JournalMemo,RefDate,InvNo,ExDate,CABA,AccountingObjectIDMain,MoneyPay) values(newid(),'" + role + "','" + txtsct.Text + "','131','33311','" + thue.ToString().Replace(".", "") + "','" + dt + "','" + dv + "',N'" + txtldn.Text + "','" + denct.EditValue.ToString() + "','" + txtshd.Text + "','" + txthtt.Text + "','" + txtnhd.EditValue.ToString() + "','" + dt + "','" + chmoney.EditValue.ToString() + "')");
                        }

                        DataTable hangchuyen = gen.GetTable("select InventoryItemID,Quantity,QuantityConvert from INOutwardDetail where RefID='" + refidpx + "' ");
                        for (int z = 0; z < hangchuyen.Rows.Count; z++)
                        {
                            for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (hangchuyen.Rows[z][0].ToString().ToLower() == hangton.Rows[j][0].ToString().ToLower())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) + Double.Parse(hangchuyen.Rows[z][1].ToString());
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) + Double.Parse(hangchuyen.Rows[z][2].ToString());
                                    break;
                                }
                            }
                        }

                        gen.ExcuteNonquery("delete  from  INOutwardDetail where RefID='" + refidpx + "'");
                        gen.ExcuteNonquery("delete  from  SSInvoiceDetail where RefID='" + role + "'");
                        gen.ExcuteNonquery("delete  from  SSInvoiceINOutward where SSInvoiceID='" + role + "'");

                        for (int i = 0; i < gridView1.RowCount - 1; i++)
                        {
                            try
                            {
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount) values(newid(),'" + refidpx + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 3] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 6] + "','" + detail[i, 7] + "')");
                            }
                            catch { }
                            try
                            {
                                gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "','" + detail[i, 9] + "','" + detail[i, 1] + "','" + detail[i, 2] + "'," + i + ",'" + detail[i, 0] + "','" + detail[i, 10] + "','" + refidpx + "')");
                            }
                            catch { }
                            try
                            {
                                gen.ExcuteNonquery("insert into SSInvoiceINOutward values(newid(),'" + role + "','" + refidpx + "','" + dv + "','" + detail[i, 0] + "','" + detail[i, 1] + "','" + detail[i, 2] + "','" + detail[i, 4] + "','" + detail[i, 5] + "','131','" + detail[i, 3] + "','" + detail[i, 7] + "','" + detail[i, 6] + "','" + detail[i, 8] + "','" + i + "',NULL)");
                            }
                            catch { }

                            for (int j = 0; j < hangton.Rows.Count; j++)
                            {
                                if (gridView1.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                {
                                    hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail[i, 1]);
                                    hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail[i, 2]);
                                    break;
                                }
                            }

                        }
                        if (txtpkm.Text == "")
                        {
                            if (gridView2.RowCount > 1)
                            {
                                themsctkm(ngaychungtu, txtpkm, ledv.EditValue.ToString(), branchid);
                                gen.ExcuteNonquery("insert into INOutwardFree(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,IsExport,ExitsStore,RefPUID) values(newid(),101,'" + denct.EditValue.ToString() + "','" + denht.EditValue.ToString() + "','" + txtpkm.Text + "','" + dt + "',N'" + txtname.Text + "',N'" + txtldn.Text + "','False','" + dv + "',0,'" + txtkhhd.Text + "','" + txtshd.Text + "','" + txtnhd.EditValue.ToString() + "','" + userid + "','" + txtms.Text + "','True','" + chton.Checked + "','" + refid + "')");
                                string refidkm = gen.GetString("select RefID from INOutwardFree where RefNo='" + txtpkm.Text + "'");
                                for (int i = 0; i < gridView2.RowCount - 1; i++)
                                {
                                    gen.ExcuteNonquery("insert into INOutwardFreeDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert) values(newid(),'" + refidkm + "','" + detail1[i, 1] + "','" + detail1[i, 0] + "','" + detail1[i, 5] + "','" + detail1[i, 3] + "'," + i + ",'" + detail1[i, 2] + "','" + detail1[i, 4] + "','" + detail1[i, 6] + "')");
                                    try
                                    {
                                        gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "',0,'" + detail1[i, 3] + "','" + detail1[i, 6] + "'," + (gridView1.RowCount + i - 1).ToString() + ",'" + detail1[i, 2] + "','0','" + refidkm + "')");
                                    }
                                    catch { }
                                    for (int j = 0; j < hangton.Rows.Count; j++)
                                    {
                                        if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                        {
                                            hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail1[i, 3]);
                                            hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail1[i, 6]);
                                            break;
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            string refidkm = gen.GetString("select * from INOutwardFree where RefNo='" + txtpkm.Text + "'");
                            gen.ExcuteNonquery("update INOutwardFree set RefDate='" + denct.EditValue.ToString() + "',PostedDate='" + denht.EditValue.ToString() + "',AccountingObjectID='" + dt + "',AccountingObjectName=N'" + txtname.Text + "',JournalMemo=N'" + txtldn.Text + "',StockID='" + dv + "',TotalAmount=0,Posted='False',InvSeries='" + txtkhhd.Text + "',InvNo='" + txtshd.Text + "',InvDate='" + txtnhd.EditValue.ToString() + "',EmployeeID='" + userid + "',No='" + txtms.Text + "',ExitsStore='"+chton.Checked+"'  where RefID='" + refidkm + "'");

                            hangchuyen = gen.GetTable("select InventoryItemID,Quantity,QuantityConvert from INOutwardFreeDetail where RefID='" + refidkm + "' ");
                            for (int z = 0; z < hangchuyen.Rows.Count; z++)
                            {
                                for (int j = 0; j < hangton.Rows.Count; j++)
                                {
                                    if (hangchuyen.Rows[z][0].ToString().ToLower() == hangton.Rows[j][0].ToString().ToLower())
                                    {
                                        hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) + Double.Parse(hangchuyen.Rows[z][1].ToString());
                                        hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) + Double.Parse(hangchuyen.Rows[z][2].ToString());
                                        break;
                                    }
                                }
                            }

                            gen.ExcuteNonquery("delete  from  INOutwardFreeDetail where RefID='" + refidkm + "'");
                            for (int i = 0; i < gridView2.RowCount - 1; i++)
                            {
                                gen.ExcuteNonquery("insert into INOutwardFreeDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,SortOrder,InventoryItemID,UnitPrice,QuantityConvert) values(newid(),'" + refidkm + "','" + detail1[i, 1] + "','" + detail1[i, 0] + "','" + detail1[i, 5] + "','" + detail1[i, 3] + "'," + i + ",'" + detail1[i, 2] + "','" + detail1[i, 4] + "','" + detail1[i, 6] + "')");
                                try
                                {
                                    gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice,RefIDFree) values(newid(),'" + refid + "',0,'" + detail1[i, 3] + "','" + detail1[i, 6] + "'," + (gridView1.RowCount + i - 1).ToString() + ",'" + detail1[i, 2] + "',0,'" + refidkm + "')");
                                }
                                catch { }
                                for (int j = 0; j < hangton.Rows.Count; j++)
                                {
                                    if (gridView2.GetRowCellValue(i, "Mã hàng").ToString() == hangton.Rows[j][3].ToString())
                                    {
                                        hangton.Rows[j][1] = Double.Parse(hangton.Rows[j][1].ToString()) - Double.Parse(detail1[i, 3]);
                                        hangton.Rows[j][2] = Double.Parse(hangton.Rows[j][2].ToString()) - Double.Parse(detail1[i, 6]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    F.gethangton(hangton);
                    F.getactive("1");
                    F.Text = "Xem hóa đơn bán hàng kiêm phiếu xuất";
                }
            }
            catch
            {
                XtraMessageBox.Show("Vui lòng chọn đối tượng trước khi lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void themsctkm(string ngaychungtu, TextEdit txtsct, string mk, string branchid)
        {
            DataTable da = new DataTable();
            int dai = 5;
            string idkho = gen.GetString("select * from Stock where StockCode='" + mk + "'");
            string dv = gen.GetString("select BranchCode from Branch where BranchID='" + branchid + "'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = dv + "-" + mk + "-PXKM";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutwardFree where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }

            txtsct.Text = sophieu;
        }

        public void tsbtdelete(DevExpress.XtraGrid.Views.Grid.GridView view, Form1 F)
        {
            try
            {
                string name = view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString();
                if (gen.GetString("select Posted from SSInvoice where RefID='" + name + "'") == "True")
                {
                    XtraMessageBox.Show("Hóa đơn đã được ghi sổ không thể xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string px = gen.GetString("select ShippingMethodID from SSInvoice where RefID='" + name + "'");

                if (XtraMessageBox.Show("Bạn có chắc muốn xóa phiếu " + view.GetRowCellValue(view.FocusedRowHandle, "Số chứng từ").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete from SSInvoiceDetail where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete from SSInvoiceINOutward where SSInvoiceID='" + name + "'");

                    gen.ExcuteNonquery("delete from SSInvoice where RefID='" + name + "'");
                    gen.ExcuteNonquery("delete HACHTOAN where RefID='" + name + "'");
                        
                        gen.ExcuteNonquery("delete from INOutward where RefID='" + px + "'");
                        gen.ExcuteNonquery("delete from INOutwardDetail where RefID='" + px + "'");
                        

                    try
                    {
                        string pxkm = gen.GetString("select RefID from INOutwardFree where RefPUID='" + name + "'");
                        gen.ExcuteNonquery("delete from INOutwardFreeDetail where RefID='" + pxkm + "'");
                        gen.ExcuteNonquery("delete from INOutwardFree where RefID='" + pxkm + "'");
                    }
                    catch { }
                    
                    

                    view.DeleteRow(view.FocusedRowHandle);
                   
                }
            }
            catch { XtraMessageBox.Show("Vui lòng chọn hóa đơn trước khi xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
             
        }

    }
}
