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

namespace HAMACO
{
    public partial class Frm_hangtieudung : DevExpress.XtraEditors.XtraForm
    {
        hangtieudung htd = new hangtieudung();
        DataTable hang = new DataTable();
        gencon gen = new gencon();

        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }

        public Frm_hangtieudung()
        {
            InitializeComponent();
        }
        int nut = 0;
        string ngaychungtu = DateTime.Now.ToString(), userid = null;
        public string getngay(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        private void Frm_hangtieudung_Load(object sender, EventArgs e)
        {
            denct.EditValue = DateTime.Parse(ngaychungtu);
            if (userid == null)
                hang = gen.GetTable("select InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng hóa',InventoryItemName as 'Tên hàng',Unit as 'Đơn vị tính', ConvertUnit as 'Đơn vị quy đổi',convert(decimal(22,2),ConvertRate) as 'Tỷ lệ quy đổi',SalePrice as 'Đơn giá tham khảo',GuarantyPeriod as 'Công ty' from InventoryItem order by InventoryItemCode");
            else
                htd.loadstart(ledv, userid);
        }

        private void btnk_Click(object sender, EventArgs e)
        {
            nut = 1;
            doimau();
        }
        private void doimau()
        {
            sbok.Enabled = false;
            sbin.Enabled = false;
            sbintong.Enabled = false;

            btnk.Appearance.ForeColor = System.Drawing.Color.Black;
            btxk.Appearance.ForeColor = System.Drawing.Color.Black;
            bttk.Appearance.ForeColor = System.Drawing.Color.Black;
            btktmv.Appearance.ForeColor = System.Drawing.Color.Black;
            if (nut == 1)
                btnk.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            else if (nut == 2)
            {
                btxk.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
                sbok.Enabled = true;
                sbin.Enabled = true;
                sbintong.Enabled = true;
            }
            else if (nut == 3)
                bttk.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            else if (nut == 4)
                btktmv.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
        }

        private void btxk_Click(object sender, EventArgs e)
        {
            nut = 2;
            doimau();
            string ngaydau = DateTime.Parse(denct.EditValue.ToString()).ToShortDateString();
            string ngaycuoi = DateTime.Parse(ngaydau).AddDays(1).AddSeconds(-1).ToString();           
            htd.loadStockmain(gridControl1, gridView1, ngaydau, ngaycuoi, ledv.Text, "bkthbhtnvkd");
        }

        private void sbok_Click(object sender, EventArgs e)
        {
            if (nut == 2)
            {
                groupControl2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã kho").ToString() + " - " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên kho").ToString();
                string ngaydau = DateTime.Parse(denct.EditValue.ToString()).ToShortDateString();
                string ngaycuoi = DateTime.Parse(ngaydau).AddDays(1).AddSeconds(-1).ToString();                
                htd.loadbangkehangtheongay(ngaydau, ngaycuoi, "bkthbhtnvkd", gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), DAT, ViewDAT);
            }            
        }

        private void denct_EditValueChanged(object sender, EventArgs e)
        {
            if (nut == 2)
            {
                string ngaydau = DateTime.Parse(denct.EditValue.ToString()).ToShortDateString();
                string ngaycuoi = DateTime.Parse(ngaydau).AddDays(1).AddSeconds(-1).ToString();               
                htd.loadStockmain(gridControl1, gridView1, ngaydau, ngaycuoi, ledv.Text, "bkthbhtnvkd");
                ViewDAT.Columns.Clear();
                groupControl2.Text = "Nội dung";
            }
        }

        private void sbin_Click(object sender, EventArgs e)
        {
            if (nut == 2)
            {
                string ngaydau = DateTime.Parse(denct.EditValue.ToString()).ToShortDateString();
                string ngaycuoi = DateTime.Parse(ngaydau).AddDays(1).AddSeconds(-1).ToString();                
                htd.loadbangkebanhangtheongay(ngaydau, ngaycuoi, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
            }     
        }

        private void sbintong_Click(object sender, EventArgs e)
        {
            if (nut == 2)
            {
                groupControl2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Mã kho").ToString() + " - " + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tên kho").ToString();
                string ngaydau = DateTime.Parse(denct.EditValue.ToString()).ToShortDateString();
                string ngaycuoi = DateTime.Parse(ngaydau).AddDays(1).AddSeconds(-1).ToString();                
                htd.loadbangkehangtheongayin(ngaydau, ngaycuoi, gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString());
            }   
        }

        private void btktmv_Click(object sender, EventArgs e)
        {
            nut = 4;
            doimau();
            groupControl1.Visible = false;
            btback.Text = "Kiểm tra mã vạch";
            htd.loadbanghanghoa(DAT, ViewDAT, hang);
            txtcmnd.Focus();
        }

        private void btback_Click(object sender, EventArgs e)
        {
            groupControl1.Visible = true;
        }

        private void txtcmnd_EditValueChanged(object sender, EventArgs e)
        {
            if (nut == 4)
            {
                //if (txtcmnd.Text.Length == 13)
            }
        }
    }
}