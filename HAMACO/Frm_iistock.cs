using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HAMACO.Resources;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System.Data.OleDb;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_iistock : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        public Frm_iistock()
        {
            InitializeComponent();
        }
        string userid,tsbt,ngaychungtu;
        string chon = "0";
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public string getngay(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        private void Frm_iistock_Load(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            DataTable da = new DataTable();
            if (tsbt == "")
            {
                temp.Columns.Add("Mã kho");
                temp.Columns.Add("Tên kho");
                da = gen.GetTable("select a.StocKID,StockCode,StockName from Stock a, MSC_UserJoinStock b where a.StockID=b.StockID and UserID='" + userid + "' order by StockCode ");
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
                ledv.ItemIndex = 0;
                ledv.Properties.PopupWidth = 300;
                this.barnct.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else if (tsbt == "barbgdh")
            {
                labelControl7.Visible = false;
                ledv.Visible = false;
                this.barButtonItem44.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                getnct();
                if (gen.GetString("select IsBranchManager from MSC_User where UserID='" + userid + "'") == "True")
                {
                    this.bartaitaptin.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    this.batai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
            }
            else if (tsbt == "barbglpg")
            {
                labelControl7.Visible = false;
                ledv.Visible = false;
                this.barButtonItem44.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                getnctbglpg();
                this.bartaitaptin.Caption = "Cập nhật    ";
                if (gen.GetString("select IsBranchManager from MSC_User where UserID='" + userid + "'") == "True")
                {
                    this.batai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    this.batai.Caption = "Duyệt giá    ";
                }
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            view.ShowFindPanel();
        }

        private void ledv_EditValueChanged(object sender, EventArgs e)
        {
            loadii(lvpq, view,ledv.EditValue.ToString());
        }

        private void loadii(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view,string kho)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            kho = gen.GetString("select StockID from Stock where StockCode='" + kho + "'");
            temp = gen.GetTable("select * from (select a.InventoryItemID,a.InventoryItemCode,a.InventoryItemName,Unit,ConvertUnit,ConvertRate,UnitPrice,SalePrice,b.InventoryCategoryName from InventoryItem a, InventoryItemCategory b where a.InventoryCategoryID=b.InventoryCategoryID) a left join (select * from StockII where StockID='"+kho+"')b on a.InventoryItemID=b.InventoryItemID order by a.InventoryItemCode,a.InventoryCategoryName");
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Mã hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Tên hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
            dt.Columns.Add("Đơn vị quy đổi", Type.GetType("System.String"));
            dt.Columns.Add("Tỷ lệ", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
            dt.Columns.Add("Đơn giá bán", Type.GetType("System.Double"));
            dt.Columns.Add("Loại hàng hóa", Type.GetType("System.String"));
            dt.Columns.Add("Kho", Type.GetType("System.Boolean"));
            dt.Columns.Add("Chọn", Type.GetType("System.Boolean"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                if (temp.Rows[i][9].ToString() == "")
                {
                    if (temp.Rows[i][5].ToString() != "")
                        dr[5] = temp.Rows[i][5].ToString();
                    else
                        dr[5] = 0;
                    if (temp.Rows[i][6].ToString() != "")
                        dr[6] = temp.Rows[i][6].ToString();
                    else
                        dr[6] = 0;
                    if (temp.Rows[i][7].ToString() != "")
                        dr[7] = temp.Rows[i][7].ToString();
                    else
                        dr[7] = 0;
                    dr[10] = "False";
                    dr[9] = "False";
                }
                else
                {
                    if (temp.Rows[i][14].ToString() != "")
                        dr[5] = temp.Rows[i][14].ToString();
                    else
                        dr[5] = 0;
                    if (temp.Rows[i][15].ToString() != "")
                        dr[6] = temp.Rows[i][15].ToString();
                    else
                        dr[6] = 0;
                    if (temp.Rows[i][16].ToString() != "")
                        dr[7] = temp.Rows[i][16].ToString();
                    else
                        dr[7] = 0;
                    dr[10] = "True";
                    dr[9] = "True";
                }
                dr[8] = temp.Rows[i][8].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;

            view.Columns["Tỷ lệ"].ColumnEdit = tyle;
            view.Columns["Đơn giá"].ColumnEdit = dongia;
            view.Columns["Đơn giá bán"].ColumnEdit = dongiaban;

            view.Columns["Tỷ lệ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tỷ lệ"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n2}";
            view.Columns["Đơn giá bán"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Đơn giá bán"].DisplayFormat.FormatString = "{0:n2}";

            view.BestFitColumns();
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[9].Visible = false;
            view.Columns["Mã hàng hóa"].OptionsColumn.AllowEdit = false;
            view.Columns["Tên hàng hóa"].OptionsColumn.AllowEdit = false;
            view.Columns["Đơn vị tính"].OptionsColumn.AllowEdit = false;
            view.Columns["Đơn vị quy đổi"].OptionsColumn.AllowEdit = false;
            view.Columns["Loại hàng hóa"].OptionsColumn.AllowEdit = false;
            view.Columns["Kho"].OptionsColumn.AllowEdit = false;

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

        }

        private void batai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(tsbt=="")
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn cập nhật vật tư hàng hóa theo kho ?", gen.GetString("select Top 1 CompanyName from Center"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    string kho = gen.GetString("select StockID from Stock where StockCode='" + ledv.EditValue.ToString() + "'");
                    for (int i = 0; i < view.RowCount; i++)
                    {
                        if (view.GetRowCellValue(i, "Chọn").ToString() == "True")
                        {
                            string ma = view.GetRowCellValue(i, "ID").ToString();
                            string mahang = view.GetRowCellValue(i, "Mã hàng hóa").ToString();
                            string ten = view.GetRowCellValue(i, "Tên hàng hóa").ToString().Replace("'", "''");
                            string tyle = view.GetRowCellValue(i, "Tỷ lệ").ToString().Replace(",", ".");
                            string dongia = view.GetRowCellValue(i, "Đơn giá").ToString().Replace(",", ".");
                            string dongiaban = view.GetRowCellValue(i, "Đơn giá bán").ToString().Replace(",", ".");
                            string dvt = view.GetRowCellValue(i, "Đơn vị tính").ToString();
                            string dvqd = view.GetRowCellValue(i, "Đơn vị quy đổi").ToString().Replace("'", "''");
                            string sql;
                            try
                            {
                                string id = gen.GetString("select * from StockII where InventoryItemID='" + ma + "' and StockID='" + kho + "'");
                                sql = "update StockII set InventoryItemName=N'" + ten + "',Unit=N'" + dvt + "',ConvertUnit=N'" + dvqd + "',ConvertRate='" + tyle + "',UnitPrice='" + dongia + "',SalePrice='" + dongiaban + "'  where InventoryItemID='" + ma + "' and StockID='" + kho + "'";
                            }
                            catch
                            {
                                sql = "insert into StockII values(newid(),'" + ma + "',N'" + ten + "',N'" + dvt + "',N'" + dvqd + "','" + tyle + "','" + dongia + "','" + dongiaban + "','" + kho + "','" + mahang + "')";
                            }
                            gen.ExcuteNonquery(sql);
                        }

                        if (view.GetRowCellValue(i, "Kho").ToString() == "True" && view.GetRowCellValue(i, "Chọn").ToString() == "False")
                        {
                            string ma = view.GetRowCellValue(i, "ID").ToString();
                            gen.ExcuteNonquery("delete StockII where InventoryItemID='" + ma + "' and StockID='" + kho + "'");
                        }
                    }
                    loadii(lvpq, view, ledv.EditValue.ToString());
                    SplashScreenManager.CloseForm();
                }
            }
            else if (tsbt == "barbgdh")
            {
                if (XtraMessageBox.Show("Dữ liệu ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + " sẽ bị xóa, bạn có chắc muốn cập nhật?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    ngaychungtu = DateTime.Parse(ngaychungtu).ToShortDateString();
                    gen.ExcuteNonquery("delete StockIIGD where PostedDate='" + ngaychungtu + "'");
                    for (int i = 0; i < view.RowCount; i++)
                    {
                        if (view.GetRowCellValue(i, "Mã hàng").ToString() != "")
                        {
                            string mahang = view.GetRowCellValue(i, "Mã hàng").ToString();
                            string nhamaycantho, khotranoc, kho22lhp, khorachgia, nhamayhcm, thuduc, bienhoa, binhduong, nhabe, kcnphumy, ltsh, baivong = null;
                            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("10/01/2019"))
                            {
                                nhamaycantho = view.GetRowCellValue(i, "Nhà máy Cần Thơ").ToString();
                                if (nhamaycantho == "") nhamaycantho = "0";
                                else nhamaycantho = nhamaycantho.Replace(".", "").Replace(",", ".");

                                khotranoc = view.GetRowCellValue(i, "Kho Trà Nóc").ToString();
                                if (khotranoc == "") khotranoc = "0";
                                else khotranoc = khotranoc.Replace(".", "").Replace(",", ".");

                                kho22lhp = view.GetRowCellValue(i, "Kho C22 LHP").ToString();
                                if (kho22lhp == "") kho22lhp = "0";
                                else kho22lhp = kho22lhp.Replace(".", "").Replace(",", ".");

                                khorachgia = view.GetRowCellValue(i, "Kho Rạch Giá").ToString();
                                if (khorachgia == "") khorachgia = "0";
                                else khorachgia = khorachgia.Replace(".", "").Replace(",", ".");

                                nhamayhcm = view.GetRowCellValue(i, "Nhà máy HCM").ToString();
                                if (nhamayhcm == "") nhamayhcm = "0";
                                else nhamayhcm = nhamayhcm.Replace(".", "").Replace(",", ".");

                                thuduc = view.GetRowCellValue(i, "Thủ Đức").ToString();
                                if (thuduc == "") thuduc = "0";
                                else thuduc = thuduc.Replace(".", "").Replace(",", ".");

                                bienhoa = view.GetRowCellValue(i, "Biên Hòa").ToString();
                                if (bienhoa == "") bienhoa = "0";
                                else bienhoa = bienhoa.Replace(".", "").Replace(",", ".");

                                binhduong = view.GetRowCellValue(i, "Bình Dương").ToString();
                                if (binhduong == "") binhduong = "0";
                                else binhduong = binhduong.Replace(".", "").Replace(",", ".");

                                nhabe = view.GetRowCellValue(i, "Nhà Bè").ToString();
                                if (nhabe == "") nhabe = "0";
                                else nhabe = nhabe.Replace(".", "").Replace(",", ".");

                                kcnphumy = view.GetRowCellValue(i, "KCN Phú Mỹ").ToString();
                                if (kcnphumy == "") kcnphumy = "0";
                                else kcnphumy = kcnphumy.Replace(".", "").Replace(",", ".");

                                ltsh = view.GetRowCellValue(i, "LTSH-Xe XMTD-PT Thủy 200 tấn").ToString();
                                if (ltsh == "") ltsh = "0";
                                else ltsh = ltsh.Replace(".", "").Replace(",", ".");

                                baivong = view.GetRowCellValue(i, "Kho Phú Quốc - Bãi Vòng").ToString();
                                if (baivong == "") baivong = "0";
                                else baivong = baivong.Replace(".", "").Replace(",", ".");
                            }
                            else
                            {
                                nhamaycantho = view.GetRowCellValue(i, "Nhà máy CT (TĐ, Pomina)").ToString();
                                if (nhamaycantho == "") nhamaycantho = "0";
                                else nhamaycantho = nhamaycantho.Replace(".", "").Replace(",", ".");

                                khotranoc = view.GetRowCellValue(i, "Kho Trà Nóc").ToString();
                                if (khotranoc == "") khotranoc = "0";
                                else khotranoc = khotranoc.Replace(".", "").Replace(",", ".");

                                kho22lhp = view.GetRowCellValue(i, "Kho C22 LHP").ToString();
                                if (kho22lhp == "") kho22lhp = "0";
                                else kho22lhp = kho22lhp.Replace(".", "").Replace(",", ".");

                                khorachgia = view.GetRowCellValue(i, "Kho Rạch Giá").ToString();
                                if (khorachgia == "") khorachgia = "0";
                                else khorachgia = khorachgia.Replace(".", "").Replace(",", ".");

                                nhamayhcm = view.GetRowCellValue(i, "Hòa Phát ( salan-PQ)").ToString();
                                if (nhamayhcm == "") nhamayhcm = "0";
                                else nhamayhcm = nhamayhcm.Replace(".", "").Replace(",", ".");

                                thuduc = view.GetRowCellValue(i, "TĐ, BH, NB (Đường thủy)").ToString();
                                if (thuduc == "") thuduc = "0";
                                else thuduc = thuduc.Replace(".", "").Replace(",", ".");

                                bienhoa = view.GetRowCellValue(i, "TĐ, BH (Đường bộ)").ToString();
                                if (bienhoa == "") bienhoa = "0";
                                else bienhoa = bienhoa.Replace(".", "").Replace(",", ".");

                                binhduong = view.GetRowCellValue(i, "Bình Dương (Đường bộ)").ToString();
                                if (binhduong == "") binhduong = "0";
                                else binhduong = binhduong.Replace(".", "").Replace(",", ".");

                                nhabe = view.GetRowCellValue(i, "Nhà Bè (Đường bộ)").ToString();
                                if (nhabe == "") nhabe = "0";
                                else nhabe = nhabe.Replace(".", "").Replace(",", ".");

                                kcnphumy = view.GetRowCellValue(i, "KCN Phú Mỹ (Đường Bộ +Thủy)").ToString();
                                if (kcnphumy == "") kcnphumy = "0";
                                else kcnphumy = kcnphumy.Replace(".", "").Replace(",", ".");

                                ltsh = view.GetRowCellValue(i, "LTSH-Xe XMTD-PT Thủy 200 tấn").ToString();
                                if (ltsh == "") ltsh = "0";
                                else ltsh = ltsh.Replace(".", "").Replace(",", ".");

                                baivong = view.GetRowCellValue(i, "Kho Phú Quốc - Bãi Vòng").ToString();
                                if (baivong == "") baivong = "0";
                                else baivong = baivong.Replace(".", "").Replace(",", ".");
                            }
                            gen.ExcuteNonquery("insert into StockIIGD(ID,PostedDate,InventoryItemCode,NhamayCT,KhoTN,KhoC22,KhoRG,NhamayHCM,KhoTD,KhoBH,KhoBD,KhoNB,KhoPM,KhoLTSH,KhoBV) values(newid(),'" + ngaychungtu + "','" + mahang + "','" + nhamaycantho + "','" + khotranoc + "','" + kho22lhp + "','" + khorachgia + "','" + nhamayhcm + "','" + thuduc + "','" + bienhoa + "','" + binhduong + "','" + nhabe + "','" + kcnphumy + "','" + ltsh + "','" + baivong + "')");
                        }
                    }
                    SplashScreenManager.CloseForm();
                    XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else if (tsbt == "barbglpg")
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn duyệt vật giá bán này?", gen.GetString("select Top 1 CompanyName from Center"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    gen.ExcuteNonquery("delete InventoryItemAD where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year + "'");
                    for (int i = 0; i < view.RowCount; i++)
                    {
                        string mahang = view.GetRowCellValue(i, "ID").ToString();
                        string gia = view.GetRowCellValue(i, "Tăng giảm giá").ToString();
                        if (gia == "") gia = "0";
                        else gia = gia.Replace(".", "").Replace(",", ".");
                        gen.ExcuteNonquery("insert InventoryItemAD values(newid(),'" + mahang + "'," + gia + ",'" + ngaychungtu + "','True')");
                    }
                    gen.ExcuteNonquery("duyetgiabanlpg '" + ngaychungtu + "'");
                    SplashScreenManager.CloseForm();
                    XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            if (chon == "0")
            {
                for (int i = view.RowCount - 1; i >= 0; i--)
                {
                    view.SetRowCellValue(i, view.Columns["Chọn"], "True");
                }
                chon = "1";
                barButtonItem44.Caption = "Bỏ chọn tất cả";
            }
            else
            {
                for (int i = view.RowCount - 1; i >= 0; i--)
                {
                    view.SetRowCellValue(i, view.Columns["Chọn"], "False");
                }
                chon = "0";
                barButtonItem44.Caption = "Chọn tất cả";
            }
            SplashScreenManager.CloseForm();
        }

        private void bartaitaptin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "barbglpg") 
            {
                if (XtraMessageBox.Show("Bạn có chắc muốn cập nhật vật giá bán này?", gen.GetString("select Top 1 CompanyName from Center"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("delete InventoryItemAD where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year + "'");
                    for (int i = 0; i < view.RowCount; i++)
                    {
                        string mahang = view.GetRowCellValue(i, "ID").ToString();
                        string gia = view.GetRowCellValue(i, "Tăng giảm giá").ToString();
                        if (gia == "") gia = "0";
                        else gia = gia.Replace(".", "").Replace(",", ".");
                        gen.ExcuteNonquery("insert InventoryItemAD values(newid(),'" + mahang + "'," + gia + ",'" + ngaychungtu + "','False')");
                    }
                    XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                OpenFileDialog F = new OpenFileDialog();
                F.ShowDialog();
                string name = F.FileName;
                if (name != "")
                {
                    String sheet = "Sheet";
                    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + name + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection con = new OleDbConnection(constr);
                    OleDbCommand oconn = new OleDbCommand("Select * From [" + sheet + "$]", con);
                    try
                    {
                        SplashScreenManager.ShowForm(typeof(Frm_wait));
                        con.Open();
                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        view.OptionsView.ColumnAutoWidth = true;
                        view.Columns.Clear();
                        lvpq.DataSource = data;
                        con.Close();
                        con.Dispose();
                        SplashScreenManager.CloseForm();
                        if (DateTime.Parse(ngaychungtu) < DateTime.Parse("10/01/2019"))
                        {
                            view.Columns["Nhà máy Cần Thơ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Nhà máy Cần Thơ"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho Trà Nóc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho Trà Nóc"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho C22 LHP"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho C22 LHP"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho Rạch Giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho Rạch Giá"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Nhà máy HCM"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Nhà máy HCM"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Thủ Đức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Thủ Đức"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Biên Hòa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Biên Hòa"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Bình Dương"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Bình Dương"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Nhà Bè"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Nhà Bè"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["KCN Phú Mỹ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["KCN Phú Mỹ"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatString = "{0:n0}";
                        }
                        else
                        {
                            view.Columns["Nhà máy CT (TĐ, Pomina)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Nhà máy CT (TĐ, Pomina)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho Trà Nóc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho Trà Nóc"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho C22 LHP"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho C22 LHP"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho Rạch Giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho Rạch Giá"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Hòa Phát ( salan-PQ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Hòa Phát ( salan-PQ)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["TĐ, BH, NB (Đường thủy)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["TĐ, BH, NB (Đường thủy)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["TĐ, BH (Đường bộ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["TĐ, BH (Đường bộ)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Bình Dương (Đường bộ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Bình Dương (Đường bộ)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Nhà Bè (Đường bộ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Nhà Bè (Đường bộ)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["KCN Phú Mỹ (Đường Bộ +Thủy)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["KCN Phú Mỹ (Đường Bộ +Thủy)"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatString = "{0:n0}";

                            view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatString = "{0:n0}";
                        }
                        view.Columns[0].Visible = false;

                        view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                        view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";

                    }
                    catch
                    {
                        if (name != "")
                            XtraMessageBox.Show("File " + name + " không đúng định dạng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                        con.Dispose();
                        SplashScreenManager.CloseForm();
                    }
                }
            }
        }

        public void getnct()
        {
            barnct.Caption = "Giá điều ngày: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();
            
            if (DateTime.Parse(ngaychungtu) < DateTime.Parse("10/01/2019"))
            {
                lvpq.DataSource = gen.GetTable("select a.InventoryItemCode as 'Mã hàng', InventoryItemName as 'Tên hàng',NhamayCT as 'Nhà máy Cần Thơ',KhoTN as 'Kho Trà Nóc',KhoC22 as 'Kho C22 LHP',KhoRG as 'Kho Rạch Giá',NhamayHCM as 'Nhà máy HCM', KhoTD as 'Thủ Đức',KhoBH as 'Biên Hòa', KhoBD as 'Bình Dương', KhoNB as 'Nhà Bè',KhoPM as 'KCN Phú Mỹ', KhoLTSH as 'LTSH-Xe XMTD-PT Thủy 200 tấn', KhoBV as 'Kho Phú Quốc - Bãi Vòng' from StockIIGD a, InventoryItem b where a.InventoryItemCode=b.InventoryItemCode and PostedDate = (select MAX(PostedDate) from StockIIGD where PostedDate<='" + ngaychungtu + "')");
                
                view.Columns["Nhà máy Cần Thơ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Nhà máy Cần Thơ"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho Trà Nóc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho Trà Nóc"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho C22 LHP"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho C22 LHP"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho Rạch Giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho Rạch Giá"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Nhà máy HCM"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Nhà máy HCM"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Thủ Đức"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Thủ Đức"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Biên Hòa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Biên Hòa"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Bình Dương"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Bình Dương"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Nhà Bè"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Nhà Bè"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["KCN Phú Mỹ"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["KCN Phú Mỹ"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatString = "{0:n0}";
            }
            else
            {
                lvpq.DataSource = gen.GetTable("select a.InventoryItemCode as 'Mã hàng', InventoryItemName as 'Tên hàng',NhamayCT as 'Nhà máy CT (TĐ, Pomina)',KhoTN as 'Kho Trà Nóc',KhoC22 as 'Kho C22 LHP',KhoRG as 'Kho Rạch Giá',NhamayHCM as 'Hòa Phát ( salan-PQ)', KhoTD as 'TĐ, BH, NB (Đường thủy)',KhoBH as 'TĐ, BH (Đường bộ)', KhoBD as 'Bình Dương (Đường bộ)', KhoNB as 'Nhà Bè (Đường bộ)',KhoPM as 'KCN Phú Mỹ (Đường Bộ +Thủy)', KhoLTSH as 'LTSH-Xe XMTD-PT Thủy 200 tấn', KhoBV as 'Kho Phú Quốc - Bãi Vòng' from StockIIGD a, InventoryItem b where a.InventoryItemCode=b.InventoryItemCode and PostedDate = (select MAX(PostedDate) from StockIIGD where PostedDate<='" + ngaychungtu + "')");
                
                view.Columns["Nhà máy CT (TĐ, Pomina)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Nhà máy CT (TĐ, Pomina)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho Trà Nóc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho Trà Nóc"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho C22 LHP"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho C22 LHP"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho Rạch Giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho Rạch Giá"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Hòa Phát ( salan-PQ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Hòa Phát ( salan-PQ)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["TĐ, BH, NB (Đường thủy)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["TĐ, BH, NB (Đường thủy)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["TĐ, BH (Đường bộ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["TĐ, BH (Đường bộ)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Bình Dương (Đường bộ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Bình Dương (Đường bộ)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Nhà Bè (Đường bộ)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Nhà Bè (Đường bộ)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["KCN Phú Mỹ (Đường Bộ +Thủy)"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["KCN Phú Mỹ (Đường Bộ +Thủy)"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["LTSH-Xe XMTD-PT Thủy 200 tấn"].DisplayFormat.FormatString = "{0:n0}";

                view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Kho Phú Quốc - Bãi Vòng"].DisplayFormat.FormatString = "{0:n0}";
            }
            view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        public void getnctbglpg()
        {
            barnct.Caption = "Giá tăng giảm ngày: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            view.OptionsView.ColumnAutoWidth = true;
            view.Columns.Clear();

            view.OptionsBehavior.Editable = true;
            this.bartaitaptin.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            DataTable temp = gen.GetTable("select a.InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng', ASCDESC as 'Tăng giảm giá', Checked as 'Duyệt' from InventoryItemAD a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year + "' order by InventoryItemCode ");
            if (temp.Rows.Count == 0)
                temp = gen.GetTable("select distinct a.InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng',InventoryItemName as 'Tên hàng', 0 as 'Tăng giảm giá', 'False' as 'Duyệt' from AccountingObjectInventoryItem a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and Month(PostedDate)='" + DateTime.Parse(ngaychungtu).AddMonths(-1).Month + "' and Year(PostedDate)='" + DateTime.Parse(ngaychungtu).AddMonths(-1).Year + "' order by InventoryItemCode ");
            else if (temp.Rows[0][4].ToString() == "True")
                this.bartaitaptin.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            lvpq.DataSource = temp;            

            view.Columns["Mã hàng"].OptionsColumn.AllowEdit = false;
            view.Columns["Duyệt"].OptionsColumn.AllowEdit = false;
            view.Columns["Tên hàng"].OptionsColumn.AllowEdit = false;
            view.Columns["Tăng giảm giá"].OptionsColumn.AllowEdit = true;

            view.Columns["Tăng giảm giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Tăng giảm giá"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns["Duyệt"].Width = 100;

            view.Columns[0].Visible = false;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        private void barnct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tsbt == "barbgdh")
            {
                Frm_nht u = new Frm_nht();
                u.myac = new Frm_nht.ac(getnct);
                u.getformiistock(this);
                u.gettsbt("barbgdh");
                u.getdate(ngaychungtu);
                u.ShowDialog();
            }
            else if (tsbt == "barbglpg")
            {
                Frm_nht u = new Frm_nht();
                u.myac = new Frm_nht.ac(getnctbglpg);
                u.getformiistock(this);
                u.gettsbt("barbglpg");
                u.getdate(ngaychungtu);
                u.ShowDialog();
            }
        }
    }
}