using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using HAMACO.Resources;
using DevExpress.Utils;
using DevExpress.XtraNavBar;
namespace HAMACO
{
    public partial class Frm_rpbaocaotonkhothucte : DevExpress.XtraEditors.XtraForm
    {
        public Frm_rpbaocaotonkhothucte()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        private void Frm_rpbaocaotonkhothucte_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (gen.GetString("select CompanyTaxCode from Center") == "" && tsbt=="tsbtbctktttndn")
                {
                    DataTable temp = new DataTable();
                    temp.Columns.Add("tenhang", Type.GetType("System.String"));
                    temp.Columns.Add("slbbkmtd", Type.GetType("System.Double"));
                    temp.Columns.Add("slkmtd", Type.GetType("System.Double"));
                    temp.Columns.Add("slbbnhapkm", Type.GetType("System.Double"));
                    temp.Columns.Add("slnhapkm", Type.GetType("System.Double"));
                    temp.Columns.Add("slbbxuatkm", Type.GetType("System.Double"));
                    temp.Columns.Add("slxuatkm", Type.GetType("System.Double"));
                    temp.Columns.Add("slbbtonkm", Type.GetType("System.Double"));
                    temp.Columns.Add("sltonkm", Type.GetType("System.Double"));
                    temp.Columns.Add("nhomhang", Type.GetType("System.String"));
                    temp.Columns.Add("tennhom", Type.GetType("System.String"));
                    temp.Columns.Add("mahang", Type.GetType("System.String"));
                    DialogResult dr1 = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho hàng gửi, 'No' để in tồn kho hàng công ty.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr1 == DialogResult.Yes)
                    {                        
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = temp.NewRow();
                            if (dt.Rows[i][31].ToString() != "" || dt.Rows[i][32].ToString() != "")
                            {
                                dr[0] = dt.Rows[i][0].ToString();
                                dr[9] = dt.Rows[i][13].ToString();
                                dr[10] = dt.Rows[i][14].ToString();
                                dr[11] = dt.Rows[i][15].ToString();
                                if (dt.Rows[i][25].ToString() != "")
                                    dr[1] = dt.Rows[i][25];
                                if (dt.Rows[i][26].ToString() != "")
                                    dr[2] = dt.Rows[i][26];
                                if (dt.Rows[i][27].ToString() != "")
                                    dr[3] = dt.Rows[i][27];
                                if (dt.Rows[i][28].ToString() != "")
                                    dr[4] = dt.Rows[i][28];
                                if (dt.Rows[i][29].ToString() != "")
                                    dr[5] = dt.Rows[i][29];
                                if (dt.Rows[i][30].ToString() != "")
                                    dr[6] = dt.Rows[i][30];
                                if (dt.Rows[i][31].ToString() != "")
                                    dr[7] = dt.Rows[i][31];
                                if (dt.Rows[i][32].ToString() != "")
                                    dr[8] = dt.Rows[i][32];
                                temp.Rows.Add(dr);
                            }
                        }
                        Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
                        rp.gettenkho(tenkho);
                        rp.getdata(temp);
                        rp.gettungay(tungay);
                        rp.getdenngay(denngay);
                        rp.gettsbt(tsbt + "hg");
                        rp.Show();                       
                    }
                    else if (dr1 == DialogResult.No)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dr = temp.NewRow();
                            if (dt.Rows[i][22].ToString() != "" || dt.Rows[i][23].ToString() != "")
                            {
                                dr[0] = dt.Rows[i][0].ToString();
                                dr[9] = dt.Rows[i][13].ToString();
                                dr[10] = dt.Rows[i][14].ToString();
                                dr[11] = dt.Rows[i][15].ToString();
                                if (dt.Rows[i][16].ToString() != "")
                                    dr[1] = dt.Rows[i][16];
                                if (dt.Rows[i][17].ToString() != "")
                                    dr[2] = dt.Rows[i][17];
                                if (dt.Rows[i][18].ToString() != "")
                                    dr[3] = dt.Rows[i][18];
                                if (dt.Rows[i][19].ToString() != "")
                                    dr[4] = dt.Rows[i][19];
                                if (dt.Rows[i][20].ToString() != "")
                                    dr[5] = dt.Rows[i][20];
                                if (dt.Rows[i][21].ToString() != "")
                                    dr[6] = dt.Rows[i][21];
                                if (dt.Rows[i][22].ToString() != "")
                                    dr[7] = dt.Rows[i][22];
                                if (dt.Rows[i][23].ToString() != "")
                                    dr[8] = dt.Rows[i][23];
                                temp.Rows.Add(dr);
                            }
                        }
                        Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
                        rp.gettenkho(tenkho);
                        rp.getdata(temp);
                        rp.gettungay(tungay);
                        rp.getdenngay(denngay);
                        rp.gettsbt(tsbt + "hctg");
                        rp.Show();
                    }                   
                }
                else if (gen.GetString("select CompanyTaxCode from Center") == "" && tsbt=="tsbtbctktttndntdv")
                {
                    string tungay1=tungay.Substring(3,2)+"/"+tungay.Substring(0,2)+"/"+tungay.Substring(6,4);
                    string denngay1 = denngay.Substring(3, 2) + "/" + denngay.Substring(0, 2) + "/" + denngay.Substring(6, 4);
                    
                    string thang = DateTime.Parse(tungay1).Month.ToString();
                    string nam = DateTime.Parse(tungay1).Year.ToString();

                    string thangtruoc = DateTime.Parse(tungay1).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(tungay1).AddMonths(-1).Year.ToString();

                    string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
                    string denngaydau = DateTime.Parse(DateTime.Parse(tungay1).ToShortDateString()).AddSeconds(-1).ToString();

                    string tungaycuoi = DateTime.Parse(DateTime.Parse(tungay1).ToShortDateString()).ToString();     
                    string denngaycuoi = DateTime.Parse(DateTime.Parse(denngay1).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
                    dt1.Columns.Add("Tên hàng", Type.GetType("System.String"));
                    dt1.Columns.Add("Công ty", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL Công ty", Type.GetType("System.Double"));
                    dt1.Columns.Add("Hàng gửi", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL hàng gửi", Type.GetType("System.Double"));
                    dt1.Columns.Add("Tồn cuối", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL tồn cuối", Type.GetType("System.Double"));
                    dt1.Columns.Add("Mã kho", Type.GetType("System.String"));
                    dt1.Columns.Add("Tên kho", Type.GetType("System.String"));
                    DataTable temp = new DataTable();
                    string loai = "0";
                    DialogResult dr1 = XtraMessageBox.Show("Nhấn 'Yes' để in tồn theo kho, 'No' để in tồn theo mặt hàng, 'Cancel để in theo tồn kho thực tế'", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr1 == DialogResult.Yes)
                        temp = gen.GetTable("baocaotonkhotheothangthuctetuthangtheodonvichitiet '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','1'");
                    else if (dr1 == DialogResult.No)
                        temp = gen.GetTable("baocaotonkhotheothangthuctetuthangtheodonvichitiet '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','0'");
                    else if (dr1 == DialogResult.Cancel)
                    {
                        temp = gen.GetTable("baocaotonkhotheothangthuctetuthangtheodonvichitiet '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','3'");
                        loai = "3";
                    }
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dt1.NewRow();
                        dr[0] = temp.Rows[i][0];
                        dr[1] = temp.Rows[i][1];
                        if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                            dr[2] = temp.Rows[i][2];
                        if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                            dr[3] = temp.Rows[i][3];
                        if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                            dr[4] = temp.Rows[i][4];
                        if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                            dr[5] = temp.Rows[i][5];
                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                            dr[6] = temp.Rows[i][6];
                        if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                            dr[7] = temp.Rows[i][7];
                        dr[8] = temp.Rows[i][8];
                        dr[9] = temp.Rows[i][9];
                        dt1.Rows.Add(dr);
                    }
                    Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
                    rp.gettenkho(tenkho);
                    rp.getdata(dt1);
                    rp.gettungay(tungay);
                    rp.getdenngay(denngay);
                    rp.gettsbt(tsbt+"hanggui");
                    rp.getkho(loai);
                    rp.Show();
                }

                else if (tsbt == "tsbtbctktttndntaidv")
                {
                    string tungay1 = tungay.Substring(3, 2) + "/" + tungay.Substring(0, 2) + "/" + tungay.Substring(6, 4);
                    string denngay1 = denngay.Substring(3, 2) + "/" + denngay.Substring(0, 2) + "/" + denngay.Substring(6, 4);

                    string thang = DateTime.Parse(tungay1).Month.ToString();
                    string nam = DateTime.Parse(tungay1).Year.ToString();

                    string thangtruoc = DateTime.Parse(tungay1).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(tungay1).AddMonths(-1).Year.ToString();

                    string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
                    string denngaydau = DateTime.Parse(DateTime.Parse(tungay1).ToShortDateString()).AddSeconds(-1).ToString();

                    string tungaycuoi = DateTime.Parse(DateTime.Parse(tungay1).ToShortDateString()).ToString();
                    string denngaycuoi = DateTime.Parse(DateTime.Parse(denngay1).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
                    dt1.Columns.Add("Tên hàng", Type.GetType("System.String"));
                    dt1.Columns.Add("Công ty", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL Công ty", Type.GetType("System.Double"));
                    dt1.Columns.Add("Hàng gửi", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL hàng gửi", Type.GetType("System.Double"));
                    dt1.Columns.Add("Tồn cuối", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL tồn cuối", Type.GetType("System.Double"));
                    dt1.Columns.Add("Mã kho", Type.GetType("System.String"));
                    dt1.Columns.Add("Tên kho", Type.GetType("System.String"));
                    
                    DataTable temp = new DataTable();
                    DialogResult dr1 = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho tổng hợp, 'No' để in tồn kho hàng gửi, 'Cancel để in tồn kho thực tế'.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr1 == DialogResult.Yes)
                        temp = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','1'");
                    else if (dr1 == DialogResult.No)
                        temp = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','2'");
                    else if (dr1 == DialogResult.Cancel)
                        temp = gen.GetTable("baocaotonkhotungaydenngaythuctetaidv '" + kho + "','" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','3'");
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dt1.NewRow();
                        dr[0] = temp.Rows[i][0];
                        dr[1] = temp.Rows[i][1];
                        if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                            dr[2] = temp.Rows[i][2];
                        if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                            dr[3] = temp.Rows[i][3];
                        if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                            dr[4] = temp.Rows[i][4];
                        if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                            dr[5] = temp.Rows[i][5];
                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                            dr[6] = temp.Rows[i][6];
                        if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                            dr[7] = temp.Rows[i][7];
                        dr[8] = temp.Rows[i][8];
                        dr[9] = temp.Rows[i][9];
                        dt1.Rows.Add(dr);
                    }
                    Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
                    rp.gettenkho(tenkho);
                    rp.getdata(dt1);
                    rp.gettungay(tungay);
                    rp.getdenngay(denngay);
                    rp.gettsbt(tsbt + "hanggui");
                    rp.getkho(kho);
                    rp.Show();
                }

                else if (gen.GetString("select CompanyTaxCode from Center") == "" && tsbt == "tsbtbctktttndnhgtct")
                {
                    string tungay1 = tungay.Substring(3, 2) + "/" + tungay.Substring(0, 2) + "/" + tungay.Substring(6, 4);
                    string denngay1 = denngay.Substring(3, 2) + "/" + denngay.Substring(0, 2) + "/" + denngay.Substring(6, 4);

                    string thang = DateTime.Parse(tungay1).Month.ToString();
                    string nam = DateTime.Parse(tungay1).Year.ToString();

                    string thangtruoc = DateTime.Parse(tungay1).AddMonths(-1).Month.ToString();
                    string namtruoc = DateTime.Parse(tungay1).AddMonths(-1).Year.ToString();

                    string tungaydau = DateTime.Parse(thang + "/1/" + nam).ToString();
                    string denngaydau = DateTime.Parse(DateTime.Parse(tungay1).ToShortDateString()).AddSeconds(-1).ToString();

                    string tungaycuoi = DateTime.Parse(DateTime.Parse(tungay1).ToShortDateString()).ToString();
                    string denngaycuoi = DateTime.Parse(DateTime.Parse(denngay1).AddDays(1).ToShortDateString()).AddSeconds(-1).ToString();

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Mã hàng", Type.GetType("System.String"));
                    dt1.Columns.Add("Tên hàng", Type.GetType("System.String"));
                    dt1.Columns.Add("Công ty", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL Công ty", Type.GetType("System.Double"));
                    dt1.Columns.Add("Hàng gửi", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL hàng gửi", Type.GetType("System.Double"));
                    dt1.Columns.Add("Tồn cuối", Type.GetType("System.Double"));
                    dt1.Columns.Add("TL tồn cuối", Type.GetType("System.Double"));
                    dt1.Columns.Add("Mã kho", Type.GetType("System.String"));
                    dt1.Columns.Add("Tên kho", Type.GetType("System.String"));
                    DataTable temp = new DataTable();
                    DialogResult dr1 = XtraMessageBox.Show("Nhấn 'Yes' để in tồn theo kho, 'No' để in tồn theo mặt hàng.","Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr1 == DialogResult.Yes)
                        temp = gen.GetTable("baocaotonkhotheothangthuctetuthangtoancongtychitiet '" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','1'");
                    else if (dr1 == DialogResult.No)
                        temp = gen.GetTable("baocaotonkhotheothangthuctetuthangtoancongtychitiet '" + thangtruoc + "','" + namtruoc + "','" + tungaydau + "','" + denngaydau + "','" + tungaycuoi + "','" + denngaycuoi + "','0'");
                    else
                        return;
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dt1.NewRow();
                        dr[0] = temp.Rows[i][0];
                        dr[1] = temp.Rows[i][1];
                        if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                            dr[2] = temp.Rows[i][2];
                        if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                            dr[3] = temp.Rows[i][3];
                        if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                            dr[4] = temp.Rows[i][4];
                        if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                            dr[5] = temp.Rows[i][5];
                        if (Double.Parse(temp.Rows[i][6].ToString()) != 0)
                            dr[6] = temp.Rows[i][6];
                        if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                            dr[7] = temp.Rows[i][7];
                        dr[8] = temp.Rows[i][8];
                        dr[9] = temp.Rows[i][9];
                        dt1.Rows.Add(dr);
                    }
                    Frm_rpbaocaotonkhothucte rp = new Frm_rpbaocaotonkhothucte();
                    rp.gettenkho(tenkho);
                    rp.getdata(dt1);
                    rp.gettungay(tungay);
                    rp.getdenngay(denngay);
                    rp.gettsbt(tsbt + "hanggui");
                    rp.Show();
                }
            }
        }
        gencon gen = new gencon();
        DataTable dt = new DataTable();
        string tsbt, ngaychungtu, kho, tenkho, tungay, denngay;
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
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

        private void Frm_rpbaocaotonkhothucte_Load(object sender, EventArgs e)
        {
            if (tsbt == "tsbtbctktttt" || tsbt == "tsbtbctktttttdv"|| tsbt=="tsbtbctktttct")
            {
                rpbaocaotonkhothucte rpbaocaotonkho = new rpbaocaotonkhothucte();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ THÁNG " + thang + " NĂM " + nam, tenkho,tungay,denngay,tsbt,kho);
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "tsbtbctkttttkm" || tsbt == "tsbtbctktttttdvkm" || tsbt == "tsbtbctktttctkm" || tsbt== "tsbtbctktttthgkm")
            {
                rpbaocaotonkhokm rpbaocaotonkho = new rpbaocaotonkhokm();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                if (tsbt == "tsbtbctktttthgkm")
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA HÀNG GỬI THÁNG " + thang + " NĂM " + nam, tenkho);
                else if (gen.GetString("select CompanyTaxCode from Center") == "")
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA HÀNG CÔNG TY THÁNG " + thang + " NĂM " + nam, tenkho);
                else
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA KHUYẾN MÃI THÁNG " + thang + " NĂM " + nam, tenkho);                
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "tsbtbctktttndnhg" || tsbt == "tsbtbctktttndnhctg")
            {
                this.Text = "Báo cáo tồn kho hàng hóa hàng gửi";
                rpbaocaotonkhokm rpbaocaotonkho = new rpbaocaotonkhokm();
                if (tsbt == "tsbtbctktttndnhg")
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA HÀNG GỬI TỪ NGÀY " + tungay+ " ĐẾN NGÀY " + denngay, tenkho);
                else if (tsbt == "tsbtbctktttndnhctg")
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA HÀNG CÔNG TY TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho);
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "tsbtbctktttttdvhanggui" || tsbt == "tsbtbctktttttdvloaihanggui")
            {
                rpbaocaotonkhohanggui rpbaocaotonkho = new rpbaocaotonkhohanggui();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THÁNG " + thang + " NĂM " + nam, tenkho);
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "bctknxtt")
            {
                rpbaocaotonkhohanggui rpbaocaotonkho = new rpbaocaotonkhohanggui();
                rpbaocaotonkho.gettieude("BẢNG KÊ NHẬP XUẤT THỰC TẾ TỪ NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay)), tenkho);
                rpbaocaotonkho.Bindxuatnhap(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else if (tsbt == "tsbtbctktttndntdvhanggui" || tsbt == "tsbtbctktttndntdvloaihanggui" || tsbt == "tsbtbctktttndnhgtcthanggui" || tsbt=="tsbtbctktttndntaidvhanggui")
            {
                rpbaocaotonkhohanggui rpbaocaotonkho = new rpbaocaotonkhohanggui();
                if (tsbt == "tsbtbctktttndnhgtcthanggui")
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG GỬI TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho);
                else if (tsbt == "tsbtbctktttndntaidvhanggui")
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho);
                else
                {
                    if(kho=="3")
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THEO PHIẾU XUẤT TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho);
                    else
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho);

                }

                if (tsbt == "tsbtbctktttndntaidvhanggui")
                    rpbaocaotonkho.BindData(dt, "4"+ngaychungtu, kho);
                else
                    rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }
            else
            {
                rpbaocaotonkhothucte rpbaocaotonkho = new rpbaocaotonkhothucte();
                if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
                {
                    if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ QUÝ I NĂM " + DateTime.Parse(denngay).Year, tenkho,tungay,denngay,tsbt,kho);
                    else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ QUÝ II NĂM " + DateTime.Parse(denngay).Year, tenkho,tungay,denngay,tsbt,kho);
                    else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ QUÝ III NĂM " + DateTime.Parse(denngay).Year, tenkho,tungay,denngay,tsbt,kho);
                    else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ QUÝ IV NĂM " + DateTime.Parse(denngay).Year, tenkho, tungay, denngay, tsbt,kho);
                    else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ NĂM " + DateTime.Parse(denngay).Year, tenkho, tungay, denngay, tsbt,kho);
                    else
                    {
                        tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                        denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                        rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho, tungay, denngay, tsbt,kho);
                    }
                }               

                else
                {
                    tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                    denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                    rpbaocaotonkho.gettieude("BÁO CÁO TỒN KHO HÀNG HÓA THỰC TẾ TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay, tenkho, tungay, denngay, tsbt,kho);
                }
                rpbaocaotonkho.BindData(dt);
                printControl1.PrintingSystem = rpbaocaotonkho.PrintingSystem;
                rpbaocaotonkho.CreateDocument();
            }

            
        }
    }
}