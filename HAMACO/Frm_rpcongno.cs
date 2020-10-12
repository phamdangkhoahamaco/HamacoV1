using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HAMACO.Resources;
using DevExpress.XtraEditors;

namespace HAMACO
{
    public partial class Frm_rpcongno : DevExpress.XtraEditors.XtraForm
    {
        public Frm_rpcongno()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public void loadbccntt(string tungay, string denngay, string tsbt, string donvi)
        {

            DataTable dt = new DataTable();
            DataTable temp = new DataTable();
            dt.Columns.Add("Mã khách", Type.GetType("System.String"));
            dt.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

            dt.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
            dt.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

            dt.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
            dt.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

            temp = gen.GetTable("baocaocongnothuctehangtieudung '" + donvi + "','" + tungay + "','" + denngay + "','" + DateTime.Parse(tungay).AddMonths(-1).Month + "','" + DateTime.Parse(tungay).AddMonths(-1).Year + "'");
           
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0].ToString();
                dr[1] = temp.Rows[i][1].ToString();
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                {
                    if (Double.Parse(temp.Rows[i][2].ToString()) > 0)
                        dr[2] = temp.Rows[i][2].ToString();
                    if (Double.Parse(temp.Rows[i][2].ToString()) < 0)
                        dr[3] = 0 - Double.Parse(temp.Rows[i][2].ToString());
                }

                if (Double.Parse(temp.Rows[i][3].ToString()) != 0)
                    dr[4] = temp.Rows[i][3].ToString();
                if (Double.Parse(temp.Rows[i][4].ToString()) != 0)
                    dr[5] = temp.Rows[i][4].ToString();

                if (Double.Parse(temp.Rows[i][5].ToString()) != 0)
                {
                    if (Double.Parse(temp.Rows[i][5].ToString()) > 0)
                        dr[6] = temp.Rows[i][5].ToString();
                    else if (Double.Parse(temp.Rows[i][5].ToString()) < 0)
                        dr[7] = 0 - Double.Parse(temp.Rows[i][5].ToString());
                }
                dt.Rows.Add(dr);
            }

            Frm_rpcongno rp = new Frm_rpcongno();
            rp.getdata(dt);
            rp.gettenkho(donvi);
            rp.getngaychungtu(tungay);
            rp.getdenngay(denngay);
            rp.gettsbt(tsbt+"hangtieudung");
            rp.Show();
        }

        private void Frm_rpcongno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DataTable temp = new DataTable();
                if (tsbt == "131tndn" || tsbt == "131tndnbh" || tsbt == "131tndntdv" || tsbt == "131tndntct" || tsbt == "331tndn" || tsbt == "331tndntdv" || tsbt == "331tndntct" || tsbt == "1313tndn" || tsbt == "1313tndntdv" || tsbt == "1313tndntct" || tsbt == "3313tndn" || tsbt == "3313tndntdv" || tsbt == "3313tndntct" || tsbt == "141tndntct" || tsbt == "1388tndn" || tsbt == "1388tndntct" || tsbt == "3388tndn" || tsbt == "3388tndntct")
                {
                    temp.Columns.Add("ID", Type.GetType("System.String"));
                    temp.Columns.Add("Mã khách", Type.GetType("System.String"));
                    temp.Columns.Add("Họ tên khách hàng", Type.GetType("System.String"));

                    temp.Columns.Add("Nợ đầu kỳ", Type.GetType("System.Double"));
                    temp.Columns.Add("Có đầu kỳ", Type.GetType("System.Double"));

                    temp.Columns.Add("Nợ phát sinh", Type.GetType("System.Double"));
                    temp.Columns.Add("Có phát sinh", Type.GetType("System.Double"));

                    temp.Columns.Add("Nợ lũy kế", Type.GetType("System.Double"));
                    temp.Columns.Add("Có lũy kế", Type.GetType("System.Double"));

                    temp.Columns.Add("Nợ cuối kỳ", Type.GetType("System.Double"));
                    temp.Columns.Add("Có cuối kỳ", Type.GetType("System.Double"));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][9].ToString() != "" || dt.Rows[i][10].ToString() != "")
                        {
                            DataRow dr = temp.NewRow();
                            dr[0] = dt.Rows[i][0].ToString();
                            dr[1] = dt.Rows[i][1].ToString();
                            dr[2] = dt.Rows[i][2].ToString();
                            dr[3] = dt.Rows[i][3];
                            dr[4] = dt.Rows[i][4];
                            dr[5] = dt.Rows[i][5];
                            dr[6] = dt.Rows[i][6];
                            dr[7] = dt.Rows[i][7];
                            dr[8] = dt.Rows[i][8];
                            dr[9] = dt.Rows[i][9];
                            dr[10] = dt.Rows[i][10];
                            temp.Rows.Add(dr);
                        }
                    }
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getdata(temp);
                    rp.gettenkho(tenkho);
                    rp.getngaychungtu(ngaychungtu);
                    rp.getdenngay(denngay);
                    rp.gettsbt(tsbt+"ngan");
                    rp.Show();
                }
                else if (tsbt == "tsbtbcdtk" || tsbt == "scth" || tsbt == "sktth")
                {
                    baocaothue bct = new baocaothue();
                    bct.loadbcdtkthtndn(ngaychungtu, tsbt+"tomtat", denngay);
                }
                else if (tsbt == "sctbhtkhvmh")
                {
                    tungay = String.Format("{0:dd-MM-yyy}", DateTime.Parse(ngaychungtu));
                    denngay = String.Format("{0:dd-MM-yyy}", DateTime.Parse(denngay));
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    gen.CreateExcel(ds, "Bangkekhachhangvamathang_"+tungay+"_"+denngay+".xlsx");
                }
                else if (tsbt == "sctbhtkhvhd")
                {
                    tungay = String.Format("{0:dd-MM-yyy}", DateTime.Parse(ngaychungtu));
                    denngay = String.Format("{0:dd-MM-yyy}", DateTime.Parse(denngay));
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    gen.CreateExcel(ds, "Bangkekhachhangvahoadon_" + tungay + "_" + denngay + ".xlsx");
                }
                else if (tsbt == "bkxktkhvmh")
                {
                    tungay = String.Format("{0:dd-MM-yyy}", DateTime.Parse(ngaychungtu));
                    denngay = String.Format("{0:dd-MM-yyy}", DateTime.Parse(denngay));
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    gen.CreateExcel(ds, "Bangkexuatkho_" + gen.GetString("select StockCode from Stock where StockID='" + kho + "'") + "_" + tungay + "_" + denngay + ".xlsx");
                }
                else if (tsbt == "tsbtbangkeluongsanluong")
                {
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getkho(kho);
                    rp.getuserid(userid);
                    rp.getngaychungtu(ngaychungtu);
                    rp.gettsbt(tsbt + "chitiet");
                    rp.Show();
                }
                else if (tsbt == "bkthbhtnvkdlqh")
                {
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getkho(kho);
                    rp.getuserid(userid);
                    rp.getngaychungtu(ngaychungtu);
                    rp.gettsbt(tsbt + "chitiet");
                    rp.Show();
                }
                else if (tsbt == "sktthchitiet" && kho == "")
                {
                    string[] strS = tenkh.Split('-');
                    string taikhoan = strS[0].ToString().Trim();
                    temp = gen.GetTable("baocaotonghopphieu '" + ngaychungtu + "','" + denngay + "','" + taikhoan + "'");
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Số phiếu", Type.GetType("System.String"));
                    dt.Columns.Add("Ngày lập", Type.GetType("System.DateTime"));
                    dt.Columns.Add("Tên khách hàng", Type.GetType("System.String"));
                    dt.Columns.Add("Lý do", Type.GetType("System.String"));
                    dt.Columns.Add("TK nợ", Type.GetType("System.String"));
                    dt.Columns.Add("TK có", Type.GetType("System.String"));
                    dt.Columns.Add("Số tiền nợ", Type.GetType("System.Double"));
                    dt.Columns.Add("Số tiền có", Type.GetType("System.Double"));
                    dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
                    dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
                    dt.Columns.Add("Hóa đơn", Type.GetType("System.String"));
                    dt.Columns.Add("Mã Kho", Type.GetType("System.String"));
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = temp.Rows[i][0];
                        dr[1] = temp.Rows[i][1];
                        dr[2] = temp.Rows[i][2];
                        dr[3] = temp.Rows[i][3];
                        if (temp.Rows[i][4].ToString() == taikhoan)
                        {
                            dr[5] = temp.Rows[i][5];
                            dr[6] = temp.Rows[i][6];
                        }
                        else
                        {
                            dr[4] = temp.Rows[i][4];
                            dr[7] = temp.Rows[i][6];
                        }
                        if (Double.Parse(temp.Rows[i][7].ToString()) != 0)
                            dr[8] = temp.Rows[i][7];
                        if (Double.Parse(temp.Rows[i][8].ToString()) != 0)
                            dr[9] = temp.Rows[i][8];
                        dr[10] = temp.Rows[i][9];
                        dr[11] = temp.Rows[i][10];
                        dt.Rows.Add(dr);
                    }
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getdata(dt);
                    rp.gettenkh(tenkh);
                    rp.getngaychungtu(ngaychungtu);
                    rp.getdenngay(denngay);
                    rp.getkho(kho);
                    rp.gettsbt(tsbt + "phieu");
                    rp.Show();
                }

                else if (tsbt == "131tndntdvchitiet" || tsbt == "331tndntdvchitiet" || tsbt == "1313tndntdvchitiet" || tsbt == "3313tndntdvchitiet")
                {
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getdata(dt);
                    rp.getngaychungtu(ngaychungtu);
                    rp.getluyke(luyke);
                    rp.gettenkho(tenkho);
                    rp.getkho(kho);
                    rp.gettsbt(tsbt + "phieu");
                    rp.gettungay(tungay);
                    rp.getdenngay(denngay);
                    rp.gettenkh(tenkh);
                    rp.Show();
                }
                else if (tsbt == "bkcnttct")
                {
                    loadbccntt(ngaychungtu, denngay, "bkcnttct", tenkho);
                }
                else if (tsbt == "bctqtdv")
                {
                    Frm_rpcongno F = new Frm_rpcongno();
                    F.gettsbt("bctqtdvthang");
                    F.getngaychungtu(ngaychungtu);
                    F.getkho(kho);
                    F.ShowDialog();
                }
                else if (tsbt == "bctqtkho")
                {
                    Frm_rpcongno F = new Frm_rpcongno();
                    F.gettsbt("bctqtkhothang");
                    F.getngaychungtu(ngaychungtu);
                    F.getkho(kho);
                    F.ShowDialog();
                }
                this.Close();
            }
        } 



        gencon gen = new gencon();
        DataTable dt = new DataTable();
        DataTable dtsum = new DataTable();
        string tsbt, ngaychungtu, kho, tenkho, tungay = null, denngay, tenkh, luyke, account, userid;
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
        public string gettenkh(string a)
        {
            tenkh = a;
            return tenkh;
        }
        public string getluyke(string a)
        {
            luyke = a;
            return luyke;
        }
        public DataTable getdata(DataTable a)
        {
            dt = a;
            return dt;
        }

        public DataTable getdatasum(DataTable a)
        {
            dtsum = a;
            return dtsum;
        }

        public string getaccount(string a)
        {
            account = a;
            return account;
        }

        public string getuserid(string a)
        {
            userid = a;
            return userid;
        }

        private void Frm_rpcongno_Load(object sender, EventArgs e)
        {
            if (tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tct" || tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tct" || tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn3388" || tsbt == "tsbtbccn1388tct" || tsbt == "tsbtbccn3388tct" || tsbt == "tsbtbccn3388tdv" || tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn1313tct" || tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3313tct")
            {
                this.Text = "Báo cáo công nợ khách hàng";
                rpcongno rpbaocaocongno = new rpcongno();
                rpbaocaocongno.getuserid(userid);
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                if(tsbt == "tsbtbccn131" || tsbt == "tsbtbccn131tct")
                    rpbaocaocongno.gettieude("TK: 131 THANH TOÁN VỚI NGƯỜI MUA - THÁNG " + thang + " NĂM " + nam, tenkho);
                else if (tsbt == "tsbtbccn331" || tsbt == "tsbtbccn331tct")
                    rpbaocaocongno.gettieude("TK: 331 THANH TOÁN VỚI NGƯỜI BÁN - THÁNG " + thang + " NĂM " + nam, tenkho);

                else if (tsbt == "tsbtbccn3313" || tsbt == "tsbtbccn3313tct")
                    rpbaocaocongno.gettieude("TK: 3313 THANH TOÁN VỚI NGƯỜI BÁN VỎ LPG - THÁNG " + thang + " NĂM " + nam, tenkho);
                else if (tsbt == "tsbtbccn1313" || tsbt == "tsbtbccn1313tct")
                    rpbaocaocongno.gettieude("TK: 1313 THANH TOÁN VỚI NGƯỜI MUA VỎ LPG - THÁNG " + thang + " NĂM " + nam, tenkho);

                else if (tsbt == "tsbtbccn1388" || tsbt == "tsbtbccn1388tct")
                    rpbaocaocongno.gettieude("TK: 1388 PHẢI THU KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho);
                else if ( tsbt == "tsbtbccn3388tdv")
                    rpbaocaocongno.gettieude("TK: 3388 PHẢI TRẢ, PHẢI NỘP KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho);
                else if (tsbt == "tsbtbccn3388" || tsbt == "tsbtbccn3388tct")
                    rpbaocaocongno.gettieudelai("TK: 3388 PHẢI TRẢ, PHẢI NỘP KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "131tndntcthmn")
            {
                this.Text = "Báo cáo hạn mức nợ khách hàng";
                rpcongnohanmucno thuchi = new rpcongnohanmucno();
                thuchi.BindData(dt);
                thuchi.gettieude(ngaychungtu, denngay, tsbt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbccn131tctkho")
            {
                this.Text = "Báo cáo công nợ khách hàng";
                rpcongno rpbaocaocongno = new rpcongno();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                if (tsbt == "tsbtbccn131tctkho")
                    rpbaocaocongno.gettieude("TK: 131 THANH TOÁN VỚI NGƯỜI MUA - THÁNG " + thang + " NĂM " + nam, tenkho);
                rpbaocaocongno.BindDatakho(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbcptcn131" || tsbt == "tsbtbcptcn131tdv" || tsbt == "tsbtbcptcn131tct")
            {
                this.Text = "Báo cáo phân tích công nợ khách hàng";
                rphantichnoquahan rpbaocaocongno = new rphantichnoquahan();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaocongno.gettieude("BÁO CÁO NỢ QUÁ HẠN ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)), tenkho);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbcptcn131tctkho")
            {
                this.Text = "Báo cáo phân tích công nợ khách hàng";
                rphantichnoquahan rpbaocaocongno = new rphantichnoquahan();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaocongno.gettieude("BÁO CÁO NỢ QUÁ HẠN ĐẾN NGÀY " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)), tenkho);
                rpbaocaocongno.BindDatagroup(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtchitietphantichcongno")
            {
                this.Text = "Báo cáo phân tích công nợ khách hàng";
                rpphantichcongnochitiet rpbaocaocongno = new rpphantichcongnochitiet();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaocongno.gettieude("BÁO CÁO PHÂN TÍCH NỢ QUÁ HẠN ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(ngaychungtu)), tenkho, tenkh, luyke);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtchitietphantichcongnotct")
            {
                this.Text = "Báo cáo phân tích công nợ khách hàng toàn công ty";
                rpphantichnoquahan131tct rpbaocaocongno = new rpphantichnoquahan131tct();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaocongno.gettieude("BÁO CÁO PHÂN TÍCH NỢ QUÁ HẠN ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(ngaychungtu)), tenkho, tenkh, luyke);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtchitietcongno131" || tsbt == "tsbtchitietcongno331" || tsbt == "tsbtchitietcongno3388" || tsbt == "tsbtchitietcongno33881" || tsbt == "tsbtchitietcongno33882" || tsbt == "tsbtchitietcongno1388" || tsbt == "tsbtchitietcongno341118" || tsbt == "tsbtchitietcongno341128")
            {
                this.Text = "Báo cáo chi tiết công nợ";
                rpchitietcongno rpbaocaocongno = new rpchitietcongno();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                if (tsbt == "tsbtchitietcongno131")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 131 THANH TOÁN VỚI NGƯỜI MUA - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno331")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 331 THANH TOÁN VỚI NGƯỜI BÁN - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno3388")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 3388 PHẢI TRẢ, PHẢI NỘP KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno33881")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 3388 PHẢI TRẢ CỔ TỨC NĂM TRƯỚC - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno33882")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 3388 PHẢI TRẢ CỔ TỨC NĂM NAY - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno1388")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 1388 PHẢI THU KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno341118")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 341118 VAY NGẮN HẠN KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno341128")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 341128 VAY DÀI HẠN KHÁC - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "131tndnchitiet" || tsbt == "131tndntdvchitiet" || tsbt == "131tndntctchitiet" || tsbt == "331tndnchitiet" || tsbt == "331tndntdvchitiet" || tsbt == "331tndntctchitiet" || tsbt == "1388tndnchitiet" || tsbt == "1388tndntctchitiet" || tsbt == "3388tndnchitiet" || tsbt == "3388tndntctchitiet" || tsbt == "341118tndntctchitiet" || tsbt == "341128tndntctchitiet")
            {
                this.Text = "Báo cáo chi tiết công nợ";
                rpchitietcongno rpbaocaocongno = new rpchitietcongno();

                if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "131")
                    rpbaocaocongno.gettieudetndn("131 CHI TIẾT THANH TOÁN VỚI NGƯỜI MUA - TỪ " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "331")
                    rpbaocaocongno.gettieudetndn("331 CHI TIẾT THANH TOÁN VỚI NGƯỜI BÁN - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "3388")
                    rpbaocaocongno.gettieudetndn("3388 CHI TIẾT PHẢI TRẢ, PHẢI NỘP KHÁC - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "341118")
                    rpbaocaocongno.gettieudetndn("341118 CHI TIẾT VAY NGẮN HẠN KHÁC - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "341128")
                    rpbaocaocongno.gettieudetndn("341128 CHI TIẾT VAY DÀI HẠN KHÁC - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "1388")
                    rpbaocaocongno.gettieudetndn("1388 CHI TIẾT PHẢI THU KHÁC - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "131tndntdvchitietphieu" || tsbt == "331tndntdvchitietphieu" || tsbt == "1313tndntdvchitietphieu" || tsbt == "3313tndntdvchitietphieu")
            {
                this.Text = "Báo cáo chi tiết công nợ";
                rpchitietcongnophieu rpbaocaocongno = new rpchitietcongnophieu();
                if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "").Replace("phieu", "") == "131")
                    rpbaocaocongno.gettieudetndn("131 CHI TIẾT THANH TOÁN VỚI NGƯỜI MUA - TỪ " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "").Replace("phieu", "") == "331")
                    rpbaocaocongno.gettieudetndn("331 CHI TIẾT THANH TOÁN VỚI NGƯỜI BÁN - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "").Replace("phieu", "") == "1313")
                    rpbaocaocongno.gettieudetndn("1313 CHI TIẾT THANH TOÁN VỚI NGƯỜI MUA VỎ BÌNH - TỪ " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "").Replace("phieu", "") == "3313")
                    rpbaocaocongno.gettieudetndn("3313 CHI TIẾT THANH TOÁN VỚI NGƯỜI BÁN VỎ BÌNH - TỪ " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "1313tndnchitiet" || tsbt == "1313tndntdvchitiet" || tsbt == "1313tndntctchitiet" || tsbt == "3313tndnchitiet" || tsbt == "3313tndntdvchitiet" || tsbt == "3313tndntctchitiet" || tsbt == "141tndntctchitiet")
            {
                this.Text = "Báo cáo chi tiết công nợ";
                rpchitietcongnotomtat rpbaocaocongno = new rpchitietcongnotomtat();
                if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "1313")
                    rpbaocaocongno.gettieudetndn("1313 CHI TIẾT THANH TOÁN VỚI NGƯỜI MUA VỎ BÌNH - TỪ " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "3313")
                    rpbaocaocongno.gettieudetndn("3313 CHI TIẾT THANH TOÁN VỚI NGƯỜI BÁN VỎ BÌNH - TỪ " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                else if (tsbt.Replace("tndn", "").Replace("chitiet", "").Replace("tdv", "").Replace("tct", "") == "141")
                    rpbaocaocongno.gettieudetndn("141 CHI TIẾT TẠM ỨNG - TỪ NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " ĐẾN NGÀY " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay)), tenkh, kho, tenkho, luyke, ngaychungtu);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbccnvncc" || tsbt == "tsbtbccnvkh" || tsbt == "tsbtbccnvkhth" || tsbt == "tsbtbccnvkhtk" || tsbt == "tsbtbccnvnccth")
            {
                this.Text = "Báo cáo chi tiết công nợ vỏ";
                rpbaocaocongnotongvo rpbaocaocongno = new rpbaocaocongnotongvo();
                rpbaocaocongno.gettieude(ngaychungtu, denngay, tsbt, tenkho);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbccnvnccchitietvo" || tsbt == "tsbtbccnvkhchitietvo" || tsbt == "tsbtbccnvkhthchitietvo" || tsbt == "tsbtbccnvkhtkchitietvo" || tsbt == "tsbtbccnvnccthchitietvo")
            {
                this.Text = "Báo cáo chi tiết công nợ vỏ";
                rpbaocaocongnovo rpbaocaocongno = new rpbaocaocongnovo();
                rpbaocaocongno.gettieude(ngaychungtu, denngay, tenkho, tenkh);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbccnvkhthbbxnchitietvo")
            {
                this.Text = "Biên bản xác nhận công nợ vỏ";
                rpbienbanxacnhanvo rpbaocaocongno = new rpbienbanxacnhanvo();
                rpbaocaocongno.gettieude(denngay, tenkh);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbccnvnccchitietvophatsinh" || tsbt == "tsbtbccnvkhchitietvophatsinh" || tsbt == "tsbtbccnvnccthchitietvophatsinh")
            {
                this.Text = "Báo cáo chi tiết công nợ vỏ phát sinh";
                rpbaocaocongnovophatsinh rpbaocaocongno = new rpbaocaocongnovophatsinh();
                rpbaocaocongno.gettieude(ngaychungtu, denngay, tenkho, tenkh);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "tsbtbccnvkhthchitietvophatsinh" || tsbt == "tsbtbccnvkhtkchitietvophatsinh")
            {
                this.Text = "Báo cáo chi tiết công nợ vỏ phát sinh tổng";
                rpbaocaocongnovophatsinhtong rpbaocaocongno = new rpbaocaocongnovophatsinhtong();
                rpbaocaocongno.gettieude(ngaychungtu, denngay, tenkho, tenkh);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "tsbtbccnvkhthphieuchitietvophatsinh")
            {
                this.Text = "Báo cáo chi tiết công nợ vỏ phát sinh tổng theo phiếu";
                rpbaocaocongnovophatsinhtong rpbaocaocongno = new rpbaocaocongnovophatsinhtong();
                rpbaocaocongno.gettieude(ngaychungtu, denngay, tenkho, tenkh);
                rpbaocaocongno.BindDataphieu(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }
            else if (tsbt == "bkthpsv")
            {
                this.Text = "Báo cáo tổng hợp phát sinh vỏ";
                rpbaocaocongnovotongphatsinh rpbaocaocongno = new rpbaocaocongnovotongphatsinh();
                rpbaocaocongno.gettieude(ngaychungtu, denngay, tenkho);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "tsbtchitietcongno1313" || tsbt == "tsbtchitietcongno3313" || tsbt == "tsbtchitietcongno141")
            {
                this.Text = "Báo cáo chi tiết công nợ khách hàng";
                rpchitietcongnotomtat rpbaocaocongno = new rpchitietcongnotomtat();
                string thang = String.Format("{0: MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                if (tsbt == "tsbtchitietcongno1313")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 1313 THANH TOÁN VỚI NGƯỜI MUA VỎ BÌNH - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno3313")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 3313 THANH TOÁN VỚI NGƯỜI BÁN VỎ BÌNH - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                else if (tsbt == "tsbtchitietcongno141")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 141 TẠM ỨNG - THÁNG " + thang + " NĂM " + nam, tenkho, tenkh, luyke, tungay, denngay, kho);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "tsbtbccn31188lai" || tsbt == "tsbtbccn31188ctthlai" || tsbt == "tsbtbccn3388lai" || tsbt == "tsbtbccn3388ctthlai")
            {
                this.Text = "Báo cáo chi tiết công nợ";
                rpchitietcongnolai rpbaocaocongno = new rpchitietcongnolai();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                if (tsbt == "tsbtbccn31188lai" || tsbt == "tsbtbccn31188ctthlai")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 31188 VAY NGẮN HẠN KHÁC - THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), luyke);
                else if (tsbt == "tsbtbccn3388lai" || tsbt == "tsbtbccn3388ctthlai")
                    rpbaocaocongno.gettieude("CHI TIẾT TK: 3388 PHẢI TRẢ, PHẢI NỘP KHÁC - THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), luyke);
                rpbaocaocongno.BindData(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "31188laitndn")
            {
                this.Text = "Báo cáo chi tiết công nợ 3388 tính lãi";
                rpchitietcongnolai rpbaocaocongno = new rpchitietcongnolai();
                string thangtruoc = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string thangsau = String.Format("{0:MM}", DateTime.Parse(denngay));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                rpbaocaocongno.gettieude("CHI TIẾT TK: 3388 PHẢI TRẢ, PHẢI NỘP KHÁC - TỪ THÁNG " + thangtruoc + " ĐẾN THÁNG " + thangsau + " NĂM " + nam, tenkh.ToUpper(), luyke);
                if (XtraMessageBox.Show("Nhấn 'Yes' để in bảng đầy đủ, 'No' để in bảng tóm tắt ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    rpbaocaocongno.BindData(dt);
                else
                    rpbaocaocongno.BindDataTong(dt);
                printControl1.PrintingSystem = rpbaocaocongno.PrintingSystem;
                rpbaocaocongno.CreateDocument();
            }

            else if (tsbt == "tsbtthtkskt" || tsbt == "tsbtthp" || tsbt == "sktthchitiet")
            {

                rptonghoptaikhoan rptonghoptaikhoan = new rptonghoptaikhoan();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string diachi = gen.GetString("select Top 1 Province from Center") + ", ngày ";
                try
                {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month).ToString();
                    diachi = diachi + ngay + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + nam;
                }
                catch
                {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
                    diachi = diachi + ngay + " tháng " + thang + " năm " + nam;
                }
                if (tsbt == "tsbtthtkskt")
                {
                    this.Text = "Sổ kế toán";
                    rptonghoptaikhoan.gettieude("SỔ KẾ TOÁN - THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), tenkho, diachi);
                }
                else if (tsbt == "tsbtthp")
                {
                    this.Text = "Chi tiết tài khoản phí";
                    if (tungay == null || tungay=="")
                        rptonghoptaikhoan.gettieude("TÀI KHOẢN PHÍ - THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), tenkho, diachi);
                    else
                    {
                        tenkho = "Từ ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(tungay)) +" đến ngày "+ String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
                        rptonghoptaikhoan.gettieude("NHÓM CHI PHÍ", tenkh.ToUpper(), tenkho, diachi);
                    }
                }
                else if (tsbt == "sktthchitiet")
                {
                    this.Text = "Sổ kế toán";
                    if (kho != "")
                        tenkho = gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
                    rptonghoptaikhoan.gettieude("SỔ KẾ TOÁN - TỪ THÁNG " + thang + " ĐẾN THÁNG " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " NĂM " + nam, tenkh.ToUpper(), tenkho, diachi);
                }
                rptonghoptaikhoan.BindData(dt);
                printControl1.PrintingSystem = rptonghoptaikhoan.PrintingSystem;
                rptonghoptaikhoan.CreateDocument();
            }

            else if (tsbt == "sktthchitietphieu")
            {
                rptonghoptaikhoanphieu rptonghoptaikhoan = new rptonghoptaikhoanphieu();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string diachi = gen.GetString("select Top 1 Province from Center") + ", ngày ";
                try
                {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month).ToString();
                    diachi = diachi + ngay + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + nam;
                }
                catch
                {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
                    diachi = diachi + ngay + " tháng " + thang + " năm " + nam;
                }
                this.Text = "Sổ chi tiết";
                rptonghoptaikhoan.gettieude("SỔ CHI TIẾT - TỪ THÁNG " + thang + " ĐẾN THÁNG " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " NĂM " + nam, tenkh.ToUpper(), tenkho, diachi);
                rptonghoptaikhoan.BindData(dt);
                printControl1.PrintingSystem = rptonghoptaikhoan.PrintingSystem;
                rptonghoptaikhoan.CreateDocument();
            }

            else if (tsbt == "tsbtthtkskttong")
            {
                this.Text = "Sổ kế toán";
                rptonghoptaikhoantong rptonghoptaikhoan = new rptonghoptaikhoantong();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string diachi = gen.GetString("select Top 1 Province from Center") + ", ngày ";
                string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
                diachi = diachi + ngay + " tháng " + thang + " năm " + nam;
                if (tsbt == "tsbtthtkskttong")
                    rptonghoptaikhoan.gettieude("SỔ KẾ TOÁN - THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), diachi);
                rptonghoptaikhoan.BindData(dt);
                rptonghoptaikhoan.BindDatasum(dtsum);
                printControl1.PrintingSystem = rptonghoptaikhoan.PrintingSystem;
                rptonghoptaikhoan.CreateDocument();
            }
            else if (tsbt == "tsbtthtksc" || tsbt == "scthchitiet")
            {
                this.Text = "Sổ cái";
                rpsocai socai = new rpsocai();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                string diachi = gen.GetString("select Top 1 Province from Center") + ", ngày ";
                try
                {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month).ToString();
                    diachi = diachi + ngay + " tháng " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " năm " + nam;
                }
                catch
                {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, DateTime.Parse(ngaychungtu).Month).ToString();
                    diachi = diachi + ngay + " tháng " + thang + " năm " + nam;
                }
                if (tsbt == "tsbtthtksc")
                    socai.gettieude("SỔ CÁI TÀI KHOẢN " + tenkh.ToUpper(), "THÁNG " + thang + " NĂM " + nam, diachi);
                else if (tsbt == "scthchitiet")
                    socai.gettieude("SỔ CÁI TÀI KHOẢN " + tenkh.ToUpper(), "TỪ THÁNG " + thang + " ĐẾN THÁNG " + String.Format("{0:MM}", DateTime.Parse(denngay)) + " NĂM " + nam, diachi);
                socai.BindData(dt);
                socai.BindDatasum(dtsum);
                printControl1.PrintingSystem = socai.PrintingSystem;
                socai.CreateDocument();
            }
            else if (tsbt == "tsbtthtktq" || tsbt == "tsbtthtktqtong")
            {
                this.Text = "Tồn quỹ các loại";
                rps07 tonquy = new rps07();
                string ngay = String.Format("{0:NGÀY dd-MM-yyyy}", DateTime.Parse(ngaychungtu));
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                int tong = 0;
                if (tsbt == "tsbtthtktqtong")
                {
                    ngay = "Tháng " + thang + " Năm " + nam;
                    tong = 1;
                }
                if (account == "1111")
                    tonquy.gettieude("SỔ QUỸ TIỀN MẶT", "TK: " + tenkh.ToUpper(), ngay, "TK: " + tenkh.ToUpper() + " " + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaychungtu)), tungay, denngay, "Mẫu số S07-DN", tong);
                else if (account.Substring(1, 3) == "112")
                    tonquy.gettieude("SỔ TIỀN GỬI NGÂN HÀNG", "TK: " + tenkh.ToUpper(), ngay, "TK: " + tenkh.ToUpper() + " " + ngay, tungay, denngay, "Mẫu số S08-DN", tong);
                else
                    tonquy.gettieude("SỔ CHI TIẾT", "TK: " + tenkh.ToUpper(), ngay, "TK: " + tenkh.ToUpper() + " " + ngay, tungay, denngay, "Mẫu số S34-DN", tong);
                if (tsbt == "tsbtthtktqtong")
                    tonquy.BindDatatong(dt);
                else
                    tonquy.BindData(dt);
                printControl1.PrintingSystem = tonquy.PrintingSystem;
                tonquy.CreateDocument();
            }
            else if (tsbt == "bctqtdv")
            {
                this.Text = "Tồn quỹ theo đơn vị";
                rps07 tonquy = new rps07();
                tonquy.gettieudetheodonvi(ngaychungtu, kho);
                printControl1.PrintingSystem = tonquy.PrintingSystem;
                tonquy.CreateDocument();
            }
            else if (tsbt == "bctqtkho")
            {
                this.Text = "Tồn quỹ";
                rps07 tonquy = new rps07();
                tonquy.gettieudetheokho(ngaychungtu, kho);
                printControl1.PrintingSystem = tonquy.PrintingSystem;
                tonquy.CreateDocument();
            }
            else if (tsbt == "bctqtkhothang")
            {
                this.Text = "Tồn quỹ theo kho";
                rps07 tonquy = new rps07();
                tonquy.gettieudetheokhothang(ngaychungtu, kho);
                printControl1.PrintingSystem = tonquy.PrintingSystem;
                tonquy.CreateDocument();
            }
            else if (tsbt == "bctqtdvthang")
            {
                this.Text = "Tồn quỹ theo đơn vị";
                rps07 tonquy = new rps07();
                tonquy.gettieudetheodonvithang(ngaychungtu, kho);
                printControl1.PrintingSystem = tonquy.PrintingSystem;
                tonquy.CreateDocument();
            }
            else if (tsbt == "tsbtbctcth")
            {
                this.Text = "Báo cáo thu chi tiền hàng";
                rpthuchitienhang thuchi = new rpthuchitienhang();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                thuchi.gettieude("BÁO CÁO THU CHI TIỀN HÀNG THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), "Báo cáo thu chi tiền hàng tháng " + thang + " năm " + nam + " " + tenkh);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbctcthtong")
            {
                this.Text = "Báo cáo thu chi tiền hàng theo ngày";
                rpthuchitienhangngay thuchi = new rpthuchitienhangngay();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                thuchi.gettieude("BÁO CÁO THU CHI TIỀN HÀNG THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), "Báo cáo thu chi tiền hàng tháng " + thang + " năm " + nam + " " + tenkh);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtctlv" ||tsbt == "tsbtctlvtn")
            {
                this.Text = "Chi tiết lãi vay";
                rplaivay thuchi = new rplaivay();
                string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                thuchi.gettieude("CHI TIẾT LÃI VAY THÁNG " + thang + " NĂM " + nam, tenkh.ToUpper(), "Chi tiết lãi vay tháng " + thang + " năm " + nam + " - " + tenkh, ngaychungtu, kho, tsbt);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtctkqkd" || tsbt == "tsbtctkqkdtt")
            {
                this.Text = "Chi tiết kết quả kinh doanh";
                rpbangkechitietkinhdoanh thuchi = new rpbangkechitietkinhdoanh();
                thuchi.BindData(dt);
                thuchi.gettieude(ngaychungtu, kho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtkqkdth")
            {
                this.Text = "Kết quả kinh doanh tổng hợp";
                rpketquakinhdoanhtonghop thuchi = new rpketquakinhdoanhtonghop();
                thuchi.gettieude(ngaychungtu, tungay);
                thuchi.BindData(dt, tungay, ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbcthmb")
            {
                this.Text = "Báo cáo tình hình mua bán";
                rpbaocaotinhhinhmuaban thuchi = new rpbaocaotinhhinhmuaban();
                thuchi.gettieude(ngaychungtu, tungay);
                thuchi.BindData(dt, tungay, ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbangkesanluong")
            {
                this.Text = "Bảng kê sản lượng và đơn giá lương";
                rpbangkesanluong thuchi = new rpbangkesanluong();
                thuchi.gettieude(ngaychungtu, kho, userid);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbangkeluongsanluong")
            {
                this.Text = "Bảng kê lương sản lượng";
                rpbangkeluongsanluong thuchi = new rpbangkeluongsanluong();
                thuchi.gettieude(ngaychungtu, kho, userid);
                thuchi.BindData(dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bkthbhtnvkdlqh")
            {
                this.Text = "Bảng kê laí quá hạn hóa đơn";
                rpbangkesanluongnew thuchi = new rpbangkesanluongnew();
                thuchi.gettieude(ngaychungtu, kho, userid);
                thuchi.BindData(ngaychungtu, kho, userid);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bkthbhtnvkdlqhchitiet")
            {
                this.Text = "Bảng kê lãi quá hạn chi tiết";
                rpbangkeluongsanluongchitiet thuchi = new rpbangkeluongsanluongchitiet();
                thuchi.gettieude(ngaychungtu, kho, userid);
                thuchi.Bindatanew(ngaychungtu, kho, userid);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbangkeluongsanluongchitiet")
            {
                this.Text = "Bảng kê chi tiết lương sản lượng";
                rpbangkeluongsanluongchitiet thuchi = new rpbangkeluongsanluongchitiet();
                thuchi.gettieude(ngaychungtu, kho, userid);
                thuchi.Bindata(ngaychungtu, kho, userid);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbangkeluongthanhtoan")
            {
                this.Text = "Bảng kê chi tiết thanh toán";
                rpbangkeluongsanluongchitiet thuchi = new rpbangkeluongsanluongchitiet();
                thuchi.gettieude(ngaychungtu, kho, tenkho);
                thuchi.Bindatatt(ngaychungtu, kho, userid, tenkho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbangkeluongthanhtoanlichsu")
            {
                this.Text = "Bảng kê chi tiết lịch sử thanh toán";
                rpbangkeluongsanluongchitiet thuchi = new rpbangkeluongsanluongchitiet();
                thuchi.gettieudedonvi(kho, tenkho);
                thuchi.Bindatalichsu(ngaychungtu, kho, userid, tenkho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtthuedaura" || tsbt == "tsbtthuedauvao")
            {
                string mst = "";
                string tinh = "";
                string noiky = "";
                tenkh = gen.GetString("select CompanyName from Center");
                if (tsbt == "tsbtthuedaura")
                    this.Text = "Báo cáo thuế GTGT đầu ra";
                else
                    this.Text = "Báo cáo thuế GTGT đầu vào";
                if (kho == "kho")
                {
                    mst = gen.GetString("select DISTINCT Code from Stock where StockID='" + tenkho + "'");
                    tinh = gen.GetString("select ' - ' +StockName from Stock where StockID='" + tenkho + "'");
                    noiky = gen.GetString("select ProvinceName from Province a, Stock b where a.ProvinceCode=b.Province and StockID='" + tenkho + "'");
                }
                else if (kho == "khuvuc")
                {
                    mst = gen.GetString("select DISTINCT Code from Stock where Province='" + tenkho + "'");
                    tinh = gen.GetString("select N' - KHU VỰC ' + ProvinceName from Province where ProvinceCode='" + tenkho + "'");
                    noiky = gen.GetString("select ProvinceName from Province where ProvinceCode='" + tenkho + "'");
                }
                else if (kho == "intonghop")
                {
                    mst = gen.GetString("select DISTINCT Code from Branch a, MSC_User b where a.BranchID=b.BranchID and UserID='" + account + "'");
                    noiky = gen.GetString("select ProvinceName from Province a, MSC_User b, Branch c where b.BranchID=c.BranchID and c.Province=a.ProvinceCode and UserID='" + account + "'");
                }
                if (kho == "intonghoptheokho")
                {
                    rpthuegtgttong thuchi = new rpthuegtgttong();
                    thuchi.gettieude(tenkh, tsbt, ngaychungtu);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
                else
                {
                    rpthuegtgt thuchi = new rpthuegtgt();
                    thuchi.gettieude(ngaychungtu, tenkh, mst, tsbt, tinh, noiky);
                    thuchi.BindData(dt);
                    printControl1.PrintingSystem = thuchi.PrintingSystem;
                    thuchi.CreateDocument();
                }
            }

            else if (tsbt == "sctbhtkhvmh" || tsbt == "sctmhtmh" || tsbt == "bkxktkhvmh" || tsbt == "bkcthdbh")
            {
                if (tsbt == "sctbhtkhvmh")
                    this.Text = "Sổ chi tiết bán hàng theo khách hàng và mặt hàng";
                else if (tsbt == "sctnhtmh")
                    this.Text = "Sổ chi tiết mua hàng theo mặt hàng";
                else if (tsbt == "sctnhtmh")
                    this.Text = "Bảng kê xuất kho theo khách hàng";
                else if (tsbt == "bkcthdbh")
                    this.Text = "Bảng kê chi tiết hóa đơn bán hàng";

                rpsoluonghangnhap thuchi = new rpsoluonghangnhap();
                thuchi.BindData(dt);
                thuchi.gettieudemain(kho, account, tsbt, ngaychungtu, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbthdbhchitiet" || tsbt == "tsbthdbhchitiettomtat")
            {
                if (tsbt == "tsbthdbhchitiet" || tsbt == "tsbthdbhchitiettomtat")
                    this.Text = "Bảng kê chi tiết hóa đơn bán hàng";
                rpsoluonghangnhap thuchi = new rpsoluonghangnhap();
                thuchi.BindDatahoadon(dt);
                thuchi.gettieudehoadon(kho, ngaychungtu, tenkh, tsbt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bkxktmhpx" || tsbt == "sctbhtkhvmhth")
            {
                if (tsbt == "bkxktmhpx")
                    this.Text = "Bảng kê xuất kho theo mặt hàng";
                else if (tsbt == "sctbhtkhvmhth")
                    this.Text = "Sổ chi tiết bán hàng theo khách hàng và mặt hàng";
                rpsoluonghangnhap thuchi = new rpsoluonghangnhap();
                thuchi.BindDatamh(dt);
                thuchi.gettieudemain(kho, account, tsbt, ngaychungtu, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "sctbhtkhvhd" || tsbt == "tsbtthbhtdtkh")
            {
                if (tsbt == "sctbhtkhvhd")
                    this.Text = "Sổ chi tiết bán hàng theo khách hàng và hóa đơn";
                else if (tsbt == "tsbtthbhtdtkh")
                    this.Text = "Tổng hợp bán hàng theo đối tượng khách hàng";
                rpsoluonghangnhap thuchi = new rpsoluonghangnhap();
                thuchi.BindDatahd(dt);
                thuchi.gettieudemain(kho, account, tsbt, ngaychungtu, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "snkmh" || tsbt == "snkbh")
            {
                if (tsbt == "snkmh")
                    this.Text = "Sổ nhật ký mua hàng";
                else if (tsbt == "snkbh")
                    this.Text = "Sổ nhật ký bán hàng";
                rpnhatkyhanghoa thuchi = new rpnhatkyhanghoa();
                thuchi.BindData(dt);
                thuchi.gettieude(kho, account, tsbt, ngaychungtu, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbcdtk" || tsbt == "scth" || tsbt == "sktth")
            {
                this.Text = "Bảng cân đối tài khoản";
                rpbangcandoitaikhoan thuchi = new rpbangcandoitaikhoan();
                thuchi.BindData(dt);
                thuchi.gettieude(tsbt, ngaychungtu, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbcdtktomtat" || tsbt == "scthtomtat" || tsbt == "sktthtomtat")
            {
                this.Text = "Bảng cân đối tài khoản";
                rpbangcandoitaikhoan thuchi = new rpbangcandoitaikhoan();
                thuchi.BindData(dt);
                thuchi.gettieude(tsbt, ngaychungtu, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "bkcntt" || tsbt == "bkcnttct" || tsbt == "bkcntttdv")
            {
                this.Text = "Bảng kê công nợ thực tế";
                rpcongnothucte thuchi = new rpcongnothucte();
                thuchi.getdata(dt);
                thuchi.BindData(dt);
                if (tsbt == "bkcntt")
                    thuchi.gettieude(ngaychungtu, denngay, tenkho, "khong");
                else if (tsbt == "bkcnttct")
                    thuchi.gettieude(ngaychungtu, denngay, tenkho, "thue");
                else if (tsbt == "bkcntttdv")
                    thuchi.gettieude(ngaychungtu, denngay, tenkho, "donvi");
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "bkcnttcthangtieudung")
            {
                this.Text = "Bảng kê công nợ thực tế";
                rpcongnothucte thuchi = new rpcongnothucte();
                thuchi.getdata(dt);
                thuchi.BindData(dt);
                thuchi.gettieude(ngaychungtu, denngay, tenkho, "thue");
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "131tndn" || tsbt == "131tndnbh" || tsbt == "331tndnbh" || tsbt == "131tndntdv" || tsbt == "131tndntdvth" || tsbt == "131tndntdvthtk" || tsbt == "131tndntct" || tsbt == "331tndn" || tsbt == "331tndntdv" || tsbt == "331tndntct" || tsbt == "1313tndn" || tsbt == "1313tndntdv" || tsbt == "1313tndntct" || tsbt == "3313tndn" || tsbt == "3313tndntdv" || tsbt == "3313tndntct" || tsbt == "141tndntct" || tsbt == "1388tndn" || tsbt == "1388tndntct" || tsbt == "3388tndn" || tsbt == "3388tndntct" || tsbt == "341118tndntct" || tsbt == "341128tndntct")
            {
                this.Text = "Bảng kê công nợ";
                rpcongnotndn thuchi = new rpcongnotndn();
                thuchi.getdata(dt);
                thuchi.BindData(dt);
                thuchi.gettieude(ngaychungtu, denngay, tenkho, tsbt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "131tndnngan" || tsbt == "131tndnbhngan" || tsbt == "131tndntdvngan" || tsbt == "131tndntctngan" || tsbt == "331tndnngan" || tsbt == "331tndntdvngan" || tsbt == "331tndntctngan" || tsbt == "1313tndnngan" || tsbt == "1313tndntdvngan" || tsbt == "1313tndntctngan" || tsbt == "3313tndnngan" || tsbt == "3313tndntdvngan" || tsbt == "3313tndntctngan" || tsbt == "141tndntctngan" || tsbt == "1388tndnngan" || tsbt == "1388tndntctngan" || tsbt == "3388tndnngan" || tsbt == "3388tndntctngan")
            {
                this.Text = "Bảng kê công nợ tóm tắt";
                rpcongnotndn thuchi = new rpcongnotndn();
                thuchi.getdata(dt);
                thuchi.BindData(dt);
                thuchi.gettieude(ngaychungtu, denngay, tenkho, tsbt.Replace("ngan", ""));
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtbcctcntt")
            {
                this.Text = "Bảng kê chi tiết công nợ thực tế";
                rpcongnothuctechitiet thuchi = new rpcongnothuctechitiet();
                thuchi.BindData(dt);
                thuchi.gettieude(ngaychungtu, denngay, tenkho, kho, luyke, tungay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "thsdhd")
            {
                this.Text = "Tình hình sử dụng hóa đơn";
                rptinhhinhhoadon thuchi = new rptinhhinhhoadon();
                thuchi.BindData(dt);
                thuchi.gettieude(denngay, tenkho, kho);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "kqtthhtt")
            {
                rpketquathuhanghanghoa thuchi = new rpketquathuhanghanghoa();
                if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                    thuchi.gettieude(denngay);
                else
                    thuchi.gettieudetuthang(tungay, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsblctt")
            {
                rpluuchuyentiente thuchi = new rpluuchuyentiente();
                thuchi.gettieude(tungay, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtttthnvvnn")
            {
                rptinhhinhthnv thuchi = new rptinhhinhthnv();
                thuchi.gettieude(tungay, denngay);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtthtktqtongtheothang")
            {
                this.Text = "Tổng hợp tồn quỹ";
                rptonghoptonquy thuchi = new rptonghoptonquy();
                thuchi.gettieude(account, tenkh, ngaychungtu, dt);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtbktdng")
            {
                this.Text = "Bảng kê theo dõi ngân hàng";
                rpbangketheodoinganhang thuchi = new rpbangketheodoinganhang();
                thuchi.gettieude(ngaychungtu);
                thuchi.BindData(ngaychungtu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "131tndnbhchitiet" || tsbt == "331tndnbhchitiet")
            {
                this.Text = "Chi tiết bảng kê hóa đơn và chứng từ đã thanh toán";
                rpbangkehoadonthanhtoan thuchi = new rpbangkehoadonthanhtoan();
                thuchi.gettieude(tenkh, kho, tungay, denngay, tsbt.Replace("tndnbhchitiet", ""));
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
        }

    }
}