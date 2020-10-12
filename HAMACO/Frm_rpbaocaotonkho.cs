using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_rpbaocaotonkho : DevExpress.XtraEditors.XtraForm
    {
        public Frm_rpbaocaotonkho()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Frm_rpbaocaotonkho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        DataTable hang = new DataTable();
        DataTable khach = new DataTable();
        string tsbt, ngaychungtu,kho,tenkho,tungay,denngay,userid,an;
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public string getan(string a)
        {
            an = a;
            return an;
        }
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public string gettinh(string a)
        {
            userid = a;
            return userid;
        }
        public string getngaychungtu(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }

        public string gettungay(string a)
        {
            tungay = a;
            return tungay;
        }
        public string getdenngay(string a)
        {
            denngay = a;
            return denngay;
        }
        public string getkho(string a)
        {
            kho = a;
            return kho;
        }
        public string gettenkho(string a)
        {
            tenkho = a;
            return tenkho;
        }
        public DataTable getdata(DataTable a)
        {
            dt = a;
            return dt;
        }
        private void Frm_rpbaocaotonkho_Load(object sender, EventArgs e)
        {
            if (tsbt == "tsbtbctktsl" || tsbt == "tsbtbctktslcu" || tsbt == "tsbtbctktttdv" || tsbt == "tsbtbctkthtct")
            {
                rpbaocaotonkho rpbaocaotonkho = new rpbaocaotonkho();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THÁNG " + thang + " NĂM " + nam, kho,userid,ngaychungtu,tsbt,an);
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "tsbtbctkthtcttong")
            {
                rpbaocaotonkhotong rp = new rpbaocaotonkhotong();
                rp.gettieude(ngaychungtu,kho);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtbctkbcn")
            {
                rpbaocaotonkhobcn rp = new rpbaocaotonkhobcn();
                rp.gettieude(kho, userid, ngaychungtu, tungay);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "bctkhtd")
            {
                rpbaocaotonkhobcn rp = new rpbaocaotonkhobcn();
                rp.gettieudehangtieudung(kho, ngaychungtu);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "bctkhhtn" || tsbt == "bctkhhtnlpg" || tsbt == "bctkhhtnvo")
            {
                rpbaocaotonkhotonghop rp = new rpbaocaotonkhotonghop();
                rp.gettieude(kho, userid, ngaychungtu, tungay);
                if (tsbt == "bctkhhtn")
                    rp.BindData(dt);
                else if (tsbt == "bctkhhtnlpg")
                    rp.BindDataLPG(dt);
                else if (tsbt == "bctkhhtnvo")
                    rp.BindDataVO(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtbctktslthekho" || tsbt == "tsbtbctktslcuthekho" || tsbt == "tsbtbctktttdvthekho" || tsbt == "tsbtbkclgdgvthekho")
            {
                rpthekho rp = new rpthekho();
                rp.gettieude(ngaychungtu, tenkho, kho, tungay, denngay);
                rp.BindData(dt);
                rp.gethang(hang);
                rp.getkhach(khach);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtthkqkd" || tsbt == "tsbtthkqkdtdv" || tsbt == "tsbtthkqkdtct" || tsbt == "tsbtthkqkdcuahang" || tsbt == "tsbtthkqkdloaihang" || tsbt == "tsbtthkqkdkhuvuc")
            {
                rpketquakinhdoanh rp = new rpketquakinhdoanh();
                rp.gettieude(ngaychungtu, kho, tungay,tsbt,denngay);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtlaigopkinhdoanh")
            {
                rpketquakinhdoanhlaigop rp = new rpketquakinhdoanhlaigop();
                rp.gettieude(ngaychungtu, kho, tsbt, tungay);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtlaigopkinhdoanhchitiet" || tsbt == "tsbtbcthlthhchitiet")
            {
                rpthekholaigop rp = new rpthekholaigop();
                rp.gettieude(ngaychungtu, tenkho, kho);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else
            {
                rpbaocaotonkho rpbaocaotonkho = new rpbaocaotonkho();
                if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
                {
                    if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA QUÝ I NĂM " + DateTime.Parse(denngay).Year, kho,userid,denngay,tsbt,an);
                    else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA QUÝ II NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt,an);
                    else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA QUÝ III NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt,an);
                    else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA QUÝ IV NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt,an);
                    else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt,an);
                    else
                    {
                        tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                        denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, kho, userid, denngay, tsbt,an);
                    }
                }
                else
                {
                    tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                    denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, kho, userid, denngay, tsbt,an);
                }
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            
        }
    }
}