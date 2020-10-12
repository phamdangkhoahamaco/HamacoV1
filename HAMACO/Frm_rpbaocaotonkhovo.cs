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
    public partial class Frm_rpbaocaotonkhovo : DevExpress.XtraEditors.XtraForm
    {
        public Frm_rpbaocaotonkhovo()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Frm_rpbaocaotonkhovo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        string tsbt, ngaychungtu, kho, tenkho, tungay, denngay,userid;
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public string getuser(string a)
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

        private void Frm_rpbaocaotonkhovo_Load(object sender, EventArgs e)
        {
           
            if (tsbt == "tsbtbctkvlpgtt" || tsbt == "tsbtbctkvlpgtttdv" || tsbt == "tsbtbctkvlpgtttct")
            {
                rpbaocaotonkhovo rpbaocaotonkho = new rpbaocaotonkhovo();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG THÁNG " + thang + " NĂM " + nam, kho,userid,ngaychungtu,tsbt);
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "tsbtbctkvlpgttthekho")
            {
                rpthekhovo rp = new rpthekhovo();
                rp.gettieude(ngaychungtu, tenkho, kho, tungay, denngay);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtbctkttttthekho")
            {
                this.Text = "Báo cáo tồn kho thực tế";
                rpthekhothucte rp = new rpthekhothucte();
                rp.gettieude(ngaychungtu, tenkho, kho, tungay, denngay);
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else if (tsbt == "tsbtbctktttndntpxkthekho" || tsbt == "tsbtbctktttndntaidvthekho" || tsbt == "bchgkhthekho" || tsbt == "tsbtbctktttndntaidvhangguithekho")
            {
                this.Text = "Báo cáo thẻ kho thực tế";
                rpthekhothucte rp = new rpthekhothucte();
                rp.gettieude(ngaychungtu, tenkho, kho, tungay, "1");
                rp.BindData(dt);
                printControl1.PrintingSystem = rp.PrintingSystem;
                rp.CreateDocument();
            }
            else
            {
                rpbaocaotonkhovo rpbaocaotonkho = new rpbaocaotonkhovo();
                if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
                {
                    if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG QUÝ I NĂM " + DateTime.Parse(denngay).Year, kho,userid,denngay,tsbt);
                    else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG QUÝ II NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt);
                    else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG QUÝ III NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt);
                    else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG QUÝ IV NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt);
                    else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG NĂM " + DateTime.Parse(denngay).Year, kho, userid, denngay, tsbt);
                    else
                    {
                        tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                        denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, kho, userid, denngay, tsbt);
                    }
                }
                else
                {
                    tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                    denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO VỎ LPG TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, kho, userid, denngay, tsbt);
                }
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
          
        }
    }
}