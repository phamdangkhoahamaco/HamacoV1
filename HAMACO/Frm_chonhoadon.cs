using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_chonhoadon : DevExpress.XtraEditors.XtraForm
    {
        public Frm_chonhoadon()
        {
            InitializeComponent();
        }

        gencon gen = new gencon();
        Frm_phieunhaphangbantralai F;
        Frm_phieuthu PT = new Frm_phieuthu();
        Frm_chuyenkhonb CNB = new Frm_chuyenkhonb();
        Frm_chuyenkhonblpg CNBLPG = new Frm_chuyenkhonblpg();
        Frm_hdbanhang HDBH = new Frm_hdbanhang();
        Frm_hdmuahang HDMH = new Frm_hdmuahang();
        Frm_hoadonxhgb HDGB = new Frm_hoadonxhgb();
        Frm_phieudieuchinh PDC = new Frm_phieudieuchinh();
        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        Frm_phieunhapgas PNG = new Frm_phieunhapgas();
        Frm_phieunhaphangbantralai PNHBTL = new Frm_phieunhaphangbantralai();
        Frm_phieunhapkho PNK = new Frm_phieunhapkho();
        Frm_phieunhapvo PNV = new Frm_phieunhapvo();
        Frm_phieuthuvt PTVT = new Frm_phieuthuvt();
        Frm_hdbhkpx KPX = new Frm_hdbhkpx();

        Frm_ddh ddh = new Frm_ddh(); 

        public delegate void ac();
        public ac myac;
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }
        public Form getform(Frm_phieunhaphangbantralai a)
        {
            F = a;
            return F;
        }

        public Form getformddh(Frm_ddh a)
        {
            ddh = a;
            return ddh;
        }

        public Form getKPX(Frm_hdbhkpx a)
        {
            KPX = a;
            return KPX;
        }

        public Form getphieuthu(Frm_phieuthu a)
        {
            PT = a;
            return PT;
        }
        public Form getCNB(Frm_chuyenkhonb a)
        {
            CNB = a;
            return CNB;
        }
        public Form getCNBLPG(Frm_chuyenkhonblpg a)
        {
            CNBLPG = a;
            return CNBLPG;
        }
        public Form getHDBH(Frm_hdbanhang a)
        {
            HDBH = a;
            return HDBH;
        }
        public Form getHDMH(Frm_hdmuahang a)
        {
            HDMH = a;
            return HDMH;
        }
        public Form getHDGB(Frm_hoadonxhgb a)
        {
            HDGB = a;
            return HDGB;
        }
        public Form getPDC(Frm_phieudieuchinh a)
        {
            PDC = a;
            return PDC;
        }
        public Form getPNG(Frm_phieunhapgas a)
        {
            PNG = a;
            return PNG;
        }
        public Form getPNHBTL(Frm_phieunhaphangbantralai a)
        {
            PNHBTL = a;
            return PNHBTL;
        }
        public Form getPNK(Frm_phieunhapkho a)
        {
            PNK = a;
            return PNK;
        }
        public Form getPNV(Frm_phieunhapvo a)
        {
            PNV = a;
            return PNV;
        }
        public Form getPTVT(Frm_phieuthuvt a)
        {
            PTVT = a;
            return PTVT;
        }
        string ngaychungtu,mk,branchid,tsbt=null;
        public string getdate(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getmk(string a)
        {
            mk = a;
            return mk;
        }
        public string getbranch(string a)
        {
            branchid = a;
            return branchid;
        }
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public void layhoadon(string ngaychungtu,string mk,string branchid)
        {
            string sql = "select * from SSInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + branchid + "' and AccountingObjectID='"+mk+"' order by RefNo";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày chứng từ", Type.GetType("System.DateTime"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));
            dt.Columns.Add("Số tiền", Type.GetType("System.Double"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][5].ToString();
                dr[2] = temp.Rows[i][69].ToString();
                dr[3] = temp.Rows[i][2].ToString();
                dr[4] = temp.Rows[i][14].ToString();
                Double cth, khautru, gtgt, tong, ck, chiphi;
                cth = Double.Parse(temp.Rows[i][38].ToString());
                ck = Double.Parse(temp.Rows[i][46].ToString());
                chiphi = Double.Parse(temp.Rows[i][73].ToString());
                khautru = Double.Parse(temp.Rows[i][44].ToString());
                cth = cth - ck - khautru + chiphi;
                gtgt = Double.Parse(temp.Rows[i][42].ToString());
                tong = cth + gtgt;
                dr[5] = tong;
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.BestFitColumns();
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
            view.Columns["Hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Số tiền"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            view.Columns["Số tiền"].DisplayFormat.FormatString = "{0:n0}";

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.Columns["Số chứng từ"].Width = 160;
            view.Columns["Số tiền"].Width = 120;
        }

        public void layhoadon(string ngaychungtu, string branchid)
        {
            string sql = "select RefID,RefNo,AccountingObjectName,InvNo,CABARefDate from PUInvoice where Month(PURefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PURefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and BranchID='" + branchid + "' order by AccountingObjectName,CABARefDate";
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            temp = gen.GetTable(sql);
            dt.Columns.Add("ID", Type.GetType("System.String"));
            dt.Columns.Add("Số chứng từ", Type.GetType("System.String"));
            dt.Columns.Add("Nhà cung cấp", Type.GetType("System.String"));
            dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
            dt.Columns.Add("Ngày hóa đơn", Type.GetType("System.DateTime"));
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                dr[2] = temp.Rows[i][2].ToString();
                dr[3] = temp.Rows[i][3].ToString();
                dr[4] = temp.Rows[i][4].ToString();
                dt.Rows.Add(dr);
            }
            lvpq.DataSource = dt;
            view.BestFitColumns();
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;

            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            view.Columns["Ngày hóa đơn"].DisplayFormat.FormatString = "dd/MM/yyyy";
            view.Columns["Ngày hóa đơn"].Width = 100;
            view.Columns["Ngày hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            view.Columns["Hóa đơn"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;        

            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
        }

        public void loadcuspro(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            view.OptionsView.ColumnAutoWidth = true;
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            
                lvpq.DataSource = khach;
            /*
                temp = gen.GetTable("select * from AccountingObject order by AccountingObjectCode");             
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Mã khách hàng", Type.GetType("System.String"));
                dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
                dt.Columns.Add("Địa chỉ", Type.GetType("System.String"));
                dt.Columns.Add("Mã số thuế", Type.GetType("System.String"));
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = temp.Rows[i][7].ToString();
                    dr[4] = temp.Rows[i][14].ToString();
                    dt.Rows.Add(dr);
                }
                lvpq.DataSource = dt;
           */
            view.BestFitColumns();
            view.OptionsBehavior.Editable = false;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            view.Columns[0].Visible = false;
            view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
            view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
            view.ShowFindPanel();
            panelControl1.Visible = false;
        }
        public void loadii(DevExpress.XtraGrid.GridControl lvpq, DevExpress.XtraGrid.Views.Grid.GridView view)
        {
            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            view.Columns.Clear();
            
                lvpq.DataSource = hang;
          /*
                temp = gen.GetTable("select * from InventoryItem order by InventoryItemCode");
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Mã hàng hóa", Type.GetType("System.String"));
                dt.Columns.Add("Tên hàng hóa", Type.GetType("System.String"));
                dt.Columns.Add("Đơn vị tính", Type.GetType("System.String"));
                dt.Columns.Add("Đơn vị quy đổi", Type.GetType("System.String"));
                dt.Columns.Add("Tỷ lệ", Type.GetType("System.Double"));
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][2].ToString();
                    dr[2] = temp.Rows[i][4].ToString();
                    dr[3] = temp.Rows[i][6].ToString();
                    dr[4] = temp.Rows[i][7].ToString();
                    if (temp.Rows[i][8].ToString() == "")
                        dr[5] = 1;
                    else
                        dr[5] = temp.Rows[i][8].ToString();
                    dt.Rows.Add(dr);
                }
                lvpq.DataSource = dt;
            */
                view.BestFitColumns();
                view.OptionsBehavior.Editable = false;
                view.OptionsSelection.EnableAppearanceFocusedCell = false;
                view.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                view.Columns[0].Visible = false;
                view.BestFitColumns();
                view.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                view.Columns[1].SummaryItem.DisplayFormat = "Số dòng:   {0}";
                view.ShowFindPanel();
                panelControl1.Visible = false;
        }

        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (tsbt == "khachhang")
            {
                if (mk == "pt")
                    PT.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "cnb")
                    CNB.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "cnblpg")
                    CNBLPG.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "hdbh")
                    HDBH.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "hdmh")
                    HDMH.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "hdgb")
                    HDGB.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "pdc")
                    PDC.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "pnk")
                    PNK.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "pnhbtl")
                    PNHBTL.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "png")
                    PNG.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "pnv")
                    PNV.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "ptvt")
                    PTVT.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                else if (mk == "kpx")
                    KPX.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "1");
                this.Close();
            }
            else if (tsbt == "hanghoa")
            {
                    if (mk == "pt")
                        PT.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "cnb")
                        CNB.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "cnblpg")
                        CNBLPG.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "hdbh")
                        HDBH.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "hdmh")
                        HDMH.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "hdgb")
                        HDGB.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "pdc")
                        PDC.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "pnk")
                        PNK.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "pnhbtl")
                        PNHBTL.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "png")
                        PNG.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "pnv")
                        PNV.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "ptvt")
                        PTVT.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    else if (mk == "kpx")
                        KPX.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã hàng hóa").ToString(), "2");
                    this.Close();
            }
            else if (tsbt == "khachhangct")
            {
                PT.getdoituong(view.GetRowCellValue(view.FocusedRowHandle, "Mã khách hàng").ToString(), "3");
                this.Close();
            }
        }
        private void Frm_chonhoadon_Load(object sender, EventArgs e)
        {
            view.ShowFindPanel();
            if (tsbt == "khachhang" || tsbt == "khachhangct")
            {
                this.Text = " Tìm kiếm khách hàng";
                this.WindowState = FormWindowState.Maximized;
                loadcuspro(lvpq, view);
            }
            else if (tsbt == "hanghoa")
            {
                this.Text = " Tìm kiếm hàng hóa";
                this.WindowState = FormWindowState.Maximized;
                loadii(lvpq, view);             
            }
            else if (tsbt == "ddh")
            {
                back.Visible = false;
                next.Visible = false;
                dehd.Visible = false;
                layhoadon(ngaychungtu, branchid);
            }
            else
            {
                dehd.EditValue = DateTime.Parse(ngaychungtu);
                layhoadon(ngaychungtu, mk, branchid);
            }
        }

        private void dehd_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                ngaychungtu = dehd.EditValue.ToString();
                layhoadon(ngaychungtu, mk, branchid);
            }
            catch { XtraMessageBox.Show("Bạn vui lòng chọn lại tháng năm", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void next_Click(object sender, EventArgs e)
        {
            dehd.EditValue = dehd.DateTime.AddMonths(1);
        }

        private void back_Click(object sender, EventArgs e)
        {
            dehd.EditValue = dehd.DateTime.AddMonths(-1);
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (tsbt == "ddh")
                ddh.gethoadondieu(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
            else
                F.gethd(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
            myac();
            this.Close();
        }
    }
}