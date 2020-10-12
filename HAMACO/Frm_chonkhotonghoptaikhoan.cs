using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;
namespace HAMACO
{
    public partial class Frm_chonkhotonghoptaikhoan : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        phieunhaphangthua pnht = new phieunhaphangthua();
        tonghoptaikhoan thtk = new tonghoptaikhoan();
        phieuketoan pkt = new phieuketoan();
        baocaothue bc = new baocaothue();
        string ngaychungtu, tsbt, account,accountname,lkco,lkno,cuoico,cuoino,userid,ngaycuoi;
        GridView viewsum = new GridView();
        public string getngaychungtu(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getngaycuoi(string a)
        {
            ngaycuoi = a;
            return ngaycuoi;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public GridView getview(GridView a)
        {
            viewsum = a;
            return viewsum;
        }

        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
       
        public Frm_chonkhotonghoptaikhoan()
        {
            InitializeComponent();
        }

        private void Frm_chonkhotonghoptaikhoan_Load(object sender, EventArgs e)
        {
            if (tsbt == "tsbtbctcth")
            {
                checkEdit1.Text="In bảng kê tổng hợp";
                thtk.loadStock(gridControl1, view, ngaychungtu, userid,tsbt);
            }
            else if (tsbt == "tsbtctlv")
            {
                checkEdit1.Visible = false;
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtctlvtn")
            {
                this.Text = "Chọn ngành";
                checkEdit1.Visible = false;
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtctkqkd" || tsbt == "tsbtctkqkdtt")
            {
                checkEdit1.Visible = false;
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtpnht")
            {
                checkEdit1.Visible = false;
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            
            else if (tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd")
            {
                checkEdit1.Text = "In bảng kê tổng hợp ngày";
                checkEdit2.Visible = true;
                checkEdit2.Text = "In bảng kê tổng hợp";
                thtk.loadStockbkhh(gridControl1, view, ngaychungtu,ngaycuoi, tsbt, userid);
            }
            else if (tsbt == "tsbtpkt")
            {
                this.Text = "Chọn người dùng";
                checkEdit1.Text = "In bảng kê phiếu";
                checkEdit2.Visible = true;
                checkEdit2.Text = "In bảng kê tổng hợp";
                pkt.loaduser(ngaychungtu,gridControl1, view);
            }
            else if (tsbt == "tsbtthpnxtt" || tsbt == "tsbtthpnxdc")
            {
                checkEdit1.Text = "In bảng kê tổng hợp chi tiết";
                checkEdit2.Visible = true;
                pnht.loadstock( gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtthkqkd")
            {
                checkEdit1.Text = "In theo đơn vị";
                checkEdit2.Visible = true;
                checkEdit2.Text = "In bảng kê tổng hợp";
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtghiso")
            {
                checkEdit1.Text = "Ghi sổ toàn bộ dữ liệu.";
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtboghi")
            {
                checkEdit1.Text = "Bỏ ghi toàn bộ dữ liệu.";
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
            }
            else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
            {
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
                checkEdit1.Text ="In theo khu vực.";
                checkEdit2.Visible = true;
                checkEdit3.Visible = true;
                panelControl1.Height = 80;
            }
            else if (tsbt == "sktth" || tsbt == "sktthtomtat")
            {
                thtk.loadStockmain(gridControl1, view, ngaychungtu,ngaycuoi,userid, tsbt);
            }
            else if (tsbt == "thhhkdm")
            {
                this.Text = "Tổng hợp hàng hóa khách hàng: "+ngaychungtu;
                checkEdit1.Visible = false;
                checkEdit2.Visible = false;
                checkEdit3.Visible = false;
                sbok.Visible = false;

                view.OptionsBehavior.Editable = false;
                view.OptionsSelection.EnableAppearanceFocusedCell = false;

                DataTable dt = new DataTable();                
                dt.Columns.Add("Mặt hàng", Type.GetType("System.String"));
                dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dt.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dt.Columns.Add("Ngày mua", Type.GetType("System.DateTime"));
                DataTable temp = gen.GetTable("select InventoryItemName,sum(a.Quantity),a.UnitPriceConvert,RefDate  from INOutwardLPGDetail a, InventoryItem b, (select * from INOutwardLPG where CustomField8='" + ngaychungtu + "') c where a.RefID=c.RefID and a.InventoryItemID=b.InventoryItemID and a.Quantity<>0 group by InventoryItemName,a.UnitPriceConvert,RefDate order by RefDate DESC");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = temp.Rows[i][3].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;
                view.Columns["Ngày mua"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                view.Columns["Ngày mua"].DisplayFormat.FormatString = "dd/MM/yyyy";
                view.Columns["Ngày mua"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                view.Columns["Ngày mua"].Width = 50;

                view.Columns["Số lượng"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Số lượng"].DisplayFormat.FormatString = "{0:n0}";
                view.Columns["Số lượng"].Width = 40;

                view.Columns["Đơn giá"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                view.Columns["Đơn giá"].DisplayFormat.FormatString = "{0:n0}";
                view.Columns["Đơn giá"].Width = 50;
                
            }
            else if (tsbt == "bkthbhtnvkdlqh")
            {
                this.Text = "Danh sách nhân viên bán hàng";
                checkEdit1.Visible = false;
                checkEdit2.Visible = false;
                checkEdit3.Visible = false;

                view.OptionsBehavior.Editable = false;
                view.OptionsSelection.EnableAppearanceFocusedCell = false;

                DataTable dt = new DataTable();
                dt.Columns.Add("ID", Type.GetType("System.String"));
                dt.Columns.Add("Mã nhân viên", Type.GetType("System.String"));
                dt.Columns.Add("Tên nhân viên", Type.GetType("System.String"));
                DataTable temp = gen.GetTable("select DISTINCT b.AccountingObjectID,AccountingObjectCode,b.AccountingObjectName from INOutward a, AccountingObject b where RefDate>='" + ngaychungtu + "' and RefDate <='" + ngaycuoi + "' and a.StockID ='" + userid + "' and EmployeeIDSA=b.AccountingObjectID order by AccountingObjectCode");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dt.Rows.Add(dr);
                }
                gridControl1.DataSource = dt;               
                view.Columns["Mã nhân viên"].Width = 50;
                view.Columns["ID"].Visible = false;
            }
            else
            {
                account = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Tài khoản").ToString();
                accountname = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Tên tài khoản").ToString();
                lkno = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Lũy kế nợ").ToString();
                lkco = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Lũy kế có").ToString();
                cuoino = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Nợ cuối kỳ").ToString();
                cuoico = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Có cuối kỳ").ToString();
                thtk.loadStock(gridControl1, view, ngaychungtu, account, tsbt);
            }
        }

        private void sbok_Click(object sender, EventArgs e)
        {

            if (checkEdit2.EditValue.ToString() == "True")
            {
                if (tsbt == "tsbtthpnxtt" || tsbt == "tsbtthpnxdc")
                    pnht.loadtong(ngaychungtu, userid, tsbt, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    bc.loadthuetong(ngaychungtu, tsbt, "intonghoptheokho", userid);
                else if (tsbt == "tsbtthkqkd")
                    thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), ngaychungtu,ngaycuoi, tsbt + "tct", userid);
                else if (tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd")
                    thtk.loadbangkehanghoatong(ngaychungtu, ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "IDS").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Kho nhập").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Kho xuất").ToString(), "2");
                else if (tsbt == "tsbtpkt")
                    pkt.loadchitiet(ngaychungtu, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "2", view.GetRowCellValue(view.FocusedRowHandle, "Tên người dùng").ToString(), tsbt+"tong", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
            }

            else if (checkEdit1.EditValue.ToString() == "True")
            {
                if (tsbt == "tsbtbctcth")
                {
                    if (tsbt == "tsbtbctcth")
                        thtk.loadbaocaothuchingay(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString());
                }
                else if (tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd")
                    thtk.loadbangkehanghoatong(ngaychungtu, ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "IDS").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Kho nhập").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Kho xuất").ToString(), "1");
                else if (tsbt == "tsbtthpnxtt" || tsbt == "tsbtthpnxdc")
                    pnht.loadchitiet(ngaychungtu, userid, tsbt, "1", "", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                else if (tsbt == "tsbtpkt")
                    pkt.loadchitiet(ngaychungtu, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "0", view.GetRowCellValue(view.FocusedRowHandle, "Tên người dùng").ToString(), tsbt, "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                else if (tsbt == "tsbtthkqkd")
                    thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), ngaychungtu, ngaycuoi, tsbt + "tdv", userid);
                else if (tsbt == "tsbtghiso")
                {
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    if (XtraMessageBox.Show("Bạn có chắc ghi sổ toàn bộ dữ liệu tháng " + thang + " năm " + nam + " ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SplashScreenManager.ShowForm(typeof(Frm_wait));
                        gen.ExcuteNonquery("tonghopghiso '" + thang + "','" + nam + "','',1");
                        SplashScreenManager.CloseForm();
                    }
                }
                else if (tsbt == "tsbtboghi")
                {
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    if (XtraMessageBox.Show("Bạn có chắc bỏ ghi toàn bộ dữ liệu tháng " + thang + " năm " + nam + " ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SplashScreenManager.ShowForm(typeof(Frm_wait));
                        gen.ExcuteNonquery("tonghopghiso '" + thang + "','" + nam + "','',0");
                        SplashScreenManager.CloseForm();
                    }
                }

                else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    bc.loadthue(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "Mã khu vực").ToString(), "khuvuc", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG", userid);
                else if (tsbt == "sktth" || tsbt=="sktthtomtat")
                {
                    string name = gen.GetString("select AccountName from Account where AccountNumber='" + userid + "'");
                    thtk.loadchitietsktth(ngaychungtu, ngaycuoi, tsbt, userid, name,"");
                }
                else
                    thtk.loadchitietskttong(ngaychungtu, tsbt, account, accountname, lkno, lkco, cuoino, cuoico);
            }
            else if (checkEdit3.EditValue.ToString() == "True")
            {
                if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    bc.loadthue(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "intonghop", "",userid);
            }
            else
            {
                if (tsbt == "tsbtbctcth")
                        thtk.loadbaocaothuchi(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString());
                else if (tsbt == "tsbtbkhhnd" || tsbt == "tsbtbkhhxd")
                        thtk.loadbangkehanghoa(ngaychungtu, ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "IDS").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Kho nhập").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Kho xuất").ToString(),"0");
                else if (tsbt == "tsbtpkt")
                        pkt.loadchitiet(ngaychungtu, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(),"1", view.GetRowCellValue(view.FocusedRowHandle, "Tên người dùng").ToString(),tsbt,"CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                else if (tsbt == "tsbtthpnxtt" || tsbt == "tsbtthpnxdc")
                    pnht.loadchitiet(ngaychungtu, userid, tsbt,"0", view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG");
                else if (tsbt == "tsbtthkqkd")
                    thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), ngaychungtu,ngaycuoi,tsbt,userid);
                else if (tsbt == "tsbtghiso")
                {
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    if (XtraMessageBox.Show("Bạn có chắc ghi sổ dữ liệu kho " + view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString() + " tháng " + thang + " năm " + nam + " ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SplashScreenManager.ShowForm(typeof(Frm_wait));    
                        gen.ExcuteNonquery("tonghopghiso '" + thang + "','" + nam + "','" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "',1");
                        SplashScreenManager.CloseForm();
                    }
                }
                else if (tsbt == "tsbtboghi")
                {
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    if (XtraMessageBox.Show("Bạn có chắc bỏ ghi dữ liệu kho " + view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString() + " tháng " + thang + " năm " + nam + " ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        SplashScreenManager.ShowForm(typeof(Frm_wait));  
                        gen.ExcuteNonquery("tonghopghiso '" + thang + "','" + nam + "','" + view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString() + "',0");
                        SplashScreenManager.CloseForm();
                    }
                }
                else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    bc.loadthue(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "kho", "CÔNG TY CỔ PHẦN VẬT TƯ HẬU GIANG",userid);
                else if (tsbt == "sktth" || tsbt=="sktthtomtat")
                {
                    string name = gen.GetString("select AccountName from Account where AccountNumber='" + userid + "'");
                    thtk.loadchitietsktth(ngaychungtu, ngaycuoi, tsbt, userid, name, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                }
                else if (tsbt == "tsbtctlv")
                    thtk.loadchitietlaivay(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString());

                else if (tsbt == "tsbtctlvtn")
                    thtk.loadchitietlaivaytheonganh(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString());

                else if (tsbt == "tsbtctkqkd" || tsbt == "tsbtctkqkdtt")
                    thtk.loadchitietkinhdoanh(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                else if (tsbt == "bkthbhtnvkdlqh")
                {
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getngaychungtu(ngaycuoi);
                    rp.getkho(userid);
                    rp.getuserid(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    rp.gettsbt(tsbt);
                    rp.Show();
                }
                else
                    thtk.loadchitietskt(ngaychungtu, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString() + " - " + view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString(), account, accountname);
                
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void checkEdit1_Clicked(object sender, EventArgs e)
        {
            checkEdit2.Checked = false;
            checkEdit3.Checked = false;
            if (checkEdit1.Checked == false)
            {
                if (tsbt == "tsbtthkqkd")
                    thtk.loadStocktdv(gridControl1, view, ngaychungtu, userid, tsbt);
                else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    thtk.loadStocktkv(gridControl1, view, ngaychungtu, userid, tsbt);
                else if (tsbt != "tsbthdbh")
                    gridControl1.Enabled = false;
            }
            else
            {
                if (tsbt == "tsbtthkqkd")
                    thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
                else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
                else if (tsbt != "tsbthdbh")
                    gridControl1.Enabled = true;
            }
        }

        private void checkEdit2_Clicked(object sender, EventArgs e)
        {
                checkEdit1.Checked = false;
                checkEdit3.Checked = false;
                if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
                    thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
                if (tsbt == "tsbtthkqkd")
                {
                    thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
                }
                else
                {
                    if (checkEdit2.Checked == false)
                        gridControl1.Enabled = false;
                    else
                        gridControl1.Enabled = true;
                }
        }

        private void checkEdit3_Clicked(object sender, EventArgs e)
        {
            checkEdit2.Checked = false;
            if ((tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao") && checkEdit1.Checked == true)
            {
                thtk.loadStock(gridControl1, view, ngaychungtu, userid, tsbt);
                checkEdit1.Checked = false;
            }
            else
            {
                if (checkEdit3.Checked == false)
                    gridControl1.Enabled = false;
                else
                    gridControl1.Enabled = true;
            }
        }
    }
}