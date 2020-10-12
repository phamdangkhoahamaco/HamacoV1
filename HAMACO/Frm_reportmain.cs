using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_reportmain : DevExpress.XtraEditors.XtraForm
    {
        tonghoptaikhoan thtk = new tonghoptaikhoan();
        gencon gen = new gencon();
        baocaothue bct = new baocaothue();
        baocaocongno131 bccn = new baocaocongno131();
        DataTable khach = new DataTable();

        public delegate void ac();
        public ac myac;

        Form1 F;
        public Form getform(Form1 a)
        {
            F = a;
            return F;
        }

        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }

        public Frm_reportmain()
        {
            InitializeComponent();
        }
        string userid, ngaychungtu, tsbt, test;

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
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }

        private void Frm_reportmain_Load(object sender, EventArgs e)
        {          
            test = "0";
            this.Height = 168;
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            gen.Position(this);
            if (tsbt == "lvphtbhtnvvsl" || tsbt == "thsdhd" || tsbt == "tsbtbaocaosanluong" || tsbt == "tsbtbaocaoluongsanluong" || tsbt == "tsbtbcthmb" || tsbt == "131tndntcthmn" || tsbt == "tsbtlaigopkinhdoanh" || tsbt == "tsbtbcslbhtt" || tsbt == "tsbtbcslbhtq" || tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcdtlnct" || tsbt == "tsbtbcdtlntq" || tsbt == "tsbtbcthlthh" || tsbt == "bccntnh" || tsbt == "bkcthddtt" || tsbt == "tsbtbctkhtd" || tsbt == "bctqtkho" || tsbt == "barthkqkdhtd" || tsbt == "barbctct")
            {
                if (tsbt == "lvphtbhtnvvsl")
                    this.Text = "Lương và phí hỗ trợ bán hàng theo nhân viên và sản lượng";
                else if (tsbt == "tsbtbaocaosanluong")
                {
                    this.Text = "Báo cáo sản lượng";
                    comboBoxEdit1.Enabled = false;
                }
                else if (tsbt == "tsbtbaocaoluongsanluong")
                {
                    this.Text = "Báo cáo lương sản lượng";
                    comboBoxEdit1.Enabled = false;
                }
                else if (tsbt == "thsdhd")
                    this.Text = "Tình hình sử dụng hóa đơn";
                else if (tsbt == "tsbtbcthmb")
                    this.Text = "Báo cáo tình hình mua bán";
                else if (tsbt == "131tndntcthmn")
                    this.Text = "Công nợ quá hạn và hạn mức hợp đồng";
                else if (tsbt == "tsbtlaigopkinhdoanh")
                    this.Text = "Tình hình kết quả kinh doanh";
                else if (tsbt == "tsbtbcslbhtt")
                    this.Text = "Báo cáo sản lượng bán hàng theo tháng";
                else if (tsbt == "tsbtbcslbhtq")
                    this.Text = "Báo cáo sản lượng bán hàng theo quý";
                else if (tsbt == "tsbtbcdtlntt")
                    this.Text = "Báo cáo doanh thu lợi nhuận theo tháng";
                else if (tsbt == "tsbtbcdtlnct")
                    this.Text = "Báo cáo doanh thu lợi nhuận chi tiết";
                else if (tsbt == "tsbtbcdtlntq")
                    this.Text = "Báo cáo doanh thu lợi nhuận theo quý";
                else if (tsbt == "tsbtbcthlthh")
                    this.Text = "Báo cáo tình hình lưu trữ hàng hóa";
                else if (tsbt == "bccntnh")
                    this.Text = "Báo cáo công nợ quá hạn chi tiết";
                else if (tsbt == "bkcthddtt")
                    this.Text = "Bảng kê chi tiết hóa đơn được thanh toán";
                else if (tsbt == "tsbtbctkhtd")
                    this.Text = "Báo cáo tồn kho";

                else if (tsbt == "bctqtkho")
                {
                    this.Text = "Báo cáo tồn quỹ";
                    comboBoxEdit1.Enabled = false;
                }
                else if (tsbt == "barthkqkdhtd")
                {
                    this.Text = "Báo cáo doanh thu sản lượng";
                    comboBoxEdit1.Enabled = false;
                }
                else if (tsbt == "barbctct")
                    this.Text = "Báo cáo thu chi tiền";
 
                comboBoxEdit1.Properties.Items.Add("Tháng 01");
                comboBoxEdit1.Properties.Items.Add("Tháng 02");
                comboBoxEdit1.Properties.Items.Add("Tháng 03");
                comboBoxEdit1.Properties.Items.Add("Tháng 04");
                comboBoxEdit1.Properties.Items.Add("Tháng 05");
                comboBoxEdit1.Properties.Items.Add("Tháng 06");
                comboBoxEdit1.Properties.Items.Add("Tháng 07");
                comboBoxEdit1.Properties.Items.Add("Tháng 08");
                comboBoxEdit1.Properties.Items.Add("Tháng 09");
                comboBoxEdit1.Properties.Items.Add("Tháng 10");
                comboBoxEdit1.Properties.Items.Add("Tháng 11");
                comboBoxEdit1.Properties.Items.Add("Tháng 12");
                comboBoxEdit1.SelectedIndex = Int32.Parse(thang) - 1 ;
                detungay.Properties.ReadOnly = true;
                dedenngay.Properties.ReadOnly = true;
            }
            else if (tsbt == "tsbtbcdtsl" || tsbt == "tsbtdskhm" || tsbt == "tsbtdskhkpsdt")
            {
                if (tsbt == "tsbtbcdtsl")
                    this.Text = "Báo cáo doanh thu khách hàng";
                else if (tsbt == "tsbtdskhm")
                    this.Text = "Danh sách khách hàng mới";
                else if (tsbt == "tsbtdskhkpsdt")
                    this.Text = "Danh sách khách hàng không phát sinh doanh thu";

                comboBoxEdit1.Properties.Items.Add("Năm " + DateTime.Parse(ngaychungtu).Year);
                comboBoxEdit1.Properties.Items.Add("Quý I");
                comboBoxEdit1.Properties.Items.Add("Quý II");
                comboBoxEdit1.Properties.Items.Add("Quý III");
                comboBoxEdit1.Properties.Items.Add("Quý IV");
                comboBoxEdit1.SelectedIndex = Int32.Parse(Math.Round((Double.Parse(thang)+ 1) / 3, 0).ToString());
                detungay.Properties.ReadOnly = true;
                dedenngay.Properties.ReadOnly = true;
            }
            else
            {
                comboBoxEdit1.Properties.Items.Add("Năm " + DateTime.Parse(ngaychungtu).Year);
                comboBoxEdit1.Properties.Items.Add("Quý I");
                comboBoxEdit1.Properties.Items.Add("Quý II");
                comboBoxEdit1.Properties.Items.Add("Quý III");
                comboBoxEdit1.Properties.Items.Add("Quý IV");
                comboBoxEdit1.Properties.Items.Add("Tháng 01");
                comboBoxEdit1.Properties.Items.Add("Tháng 02");
                comboBoxEdit1.Properties.Items.Add("Tháng 03");
                comboBoxEdit1.Properties.Items.Add("Tháng 04");
                comboBoxEdit1.Properties.Items.Add("Tháng 05");
                comboBoxEdit1.Properties.Items.Add("Tháng 06");
                comboBoxEdit1.Properties.Items.Add("Tháng 07");
                comboBoxEdit1.Properties.Items.Add("Tháng 08");
                comboBoxEdit1.Properties.Items.Add("Tháng 09");
                comboBoxEdit1.Properties.Items.Add("Tháng 10");
                comboBoxEdit1.Properties.Items.Add("Tháng 11");
                comboBoxEdit1.Properties.Items.Add("Tháng 12");
                comboBoxEdit1.SelectedIndex = Int32.Parse(thang) + 4;
                if (tsbt == "sctbhtkhvhd")
                    this.Text = "Sổ chi tiết bán hàng theo khách hàng và hóa đơn";
                else if (tsbt == "bcslmb")
                    this.Text = "Báo cáo sản lượng mua bán";
                else if (tsbt == "tsbtthbhtdtkh")
                    this.Text = "Tổng hợp bán hàng theo đối tượng khách hàng";
                else if (tsbt == "sctbhtkhvmh")
                    this.Text = "Sổ chi tiết bán hàng theo khách hàng và mặt hàng";
                else if (tsbt == "sctbhtkhvmhth")
                    this.Text = "Báo cáo sản lượng";
                else if (tsbt == "bkcthdbh")
                    this.Text = "Bảng kê chi tiết hóa đơn bán hàng";
                else if (tsbt == "sctmhtmh")
                    this.Text = "Sổ chi tiết mua hàng theo mặt hàng";
                else if (tsbt == "bkcpbxnh")
                    this.Text = "Bảng kê chi phí bốc xếp nhập kho";
                else if (tsbt == "bkcpbxnhv")
                    this.Text = "Bảng kê chi phí bốc xếp nhập kho vỏ";
                else if (tsbt == "snkmh")
                    this.Text = "Sổ nhật ký mua hàng";
                else if (tsbt == "snkbh")
                    this.Text = "Sổ nhật ký bán hàng";
                else if (tsbt == "snknk")
                    this.Text = "Sổ nhật ký nhập kho";
                else if (tsbt == "snkxk")
                    this.Text = "Sổ nhật ký xuất kho";
                else if (tsbt == "snkxktx")
                    this.Text = "Sổ nhật ký xuất kho";
                else if (tsbt == "snkxkct")
                    this.Text = "Sổ nhật ký xuất kho dạng đơn giá có thuế";
                else if (tsbt == "bkxktkhvmh")
                    this.Text = "Bảng kê xuất kho theo khách hàng";
                else if (tsbt == "bkxktmhpx")
                    this.Text = "Bảng kê xuất kho theo mặt hàng";
                else if (tsbt == "bkcpbh")
                    this.Text = "Bảng kê chi phí bán hàng";
                else if (tsbt == "bkcntt")
                    this.Text = "Bảng kê công nợ thực tế";
                else if (tsbt == "bkcntttdv")
                    this.Text = "Bảng kê công nợ phải thu thực tế";
                else if (tsbt == "bkcnttct")
                    this.Text = "Bảng kê công nợ thực tế dạng đơn giá có thuế";
                else if (tsbt == "snkxcnb")
                    this.Text = "Sổ nhật ký xuất chuyển nội bộ từ kho đến kho";
                else if (tsbt == "snkncnb")
                    this.Text = "Sổ nhật ký nhập chuyển nội bộ từ kho đến kho";
                else if (tsbt == "snkxcnbtc")
                    this.Text = "Sổ nhật ký xuất chuyển nội bộ";
                else if (tsbt == "bkhdbvt")
                    this.Text = "Bảng kê hóa đơn bán vỏ LPG";
                else if (tsbt == "bknmvt")
                    this.Text = "Bảng kê nhập chuyển kho vỏ LPG";
                else if (tsbt == "bkxckvlpg")
                    this.Text = "Bảng kê xuất chuyển kho vỏ LPG";
                else if (tsbt == "bknckvlpg")
                    this.Text = "Bảng kê nhập chuyển kho vỏ LPG";
                else if (tsbt == "bkcpbx")
                    this.Text = "Bảng kê chi phí bốc xếp bán hàng";
                else if (tsbt == "bkcpk")
                    this.Text = "Bảng kê chi phí khác";
                else if (tsbt == "bkcpbxthhh")
                    this.Text = "Bảng kê chi phí bốc xếp tổng hợp";
                else if (tsbt == "bkcpbxv")
                    this.Text = "Bảng kê chi phí bốc xếp xuất kho vỏ";
                else if (tsbt == "bkcpvcbh")
                    this.Text = "Bảng kê chi phí vận chuyển bán hàng";
                else if (tsbt == "bkcpbxth")
                    this.Text = "Bảng kê sản lượng bán hàng theo giao nhận";
                else if (tsbt == "bkcpbxthnv")
                    this.Text = "Bảng kê sản lượng bán hàng theo tài xế";
                else if (tsbt == "bkthbhtnvkd")
                    this.Text = "Bảng kê tổng hợp bán hàng theo nhân viên kinh doanh";
                else if (tsbt == "bkthbhtnvkdlqh")
                    this.Text = "Bảng kê lãi hóa đơn quá hạn theo nhân viên kinh doanh";
                else if (tsbt == "bkthhkm")
                    this.Text = "Bảng kê tổng hợp hàng khuyến mãi";
                else if (tsbt == "bkthhhtx")
                    this.Text = "Bảng kê tổng hợp hàng hóa theo xe";
                else if (tsbt == "tsbtpnkvtddh")
                    this.Text = "Bảng kê tổng hợp vỏ theo xe";
                else if (tsbt == "bctkhhtn")
                    this.Text = "Báo cáo tồn kho hàng hóa theo ngày";
                else if (tsbt == "bctkhhtnlpg")
                    this.Text = "Báo cáo tồn kho LPG";
                else if (tsbt == "bctkhhtnvo")
                    this.Text = "Báo cáo tồn kho vỏ";
                else if (tsbt == "bkcpbxxck")
                    this.Text = "Bảng kê chi phí bốc xếp xuất chuyển kho";
                else if (tsbt == "bkcpbxxckv")
                    this.Text = "Bảng kê chi phí bốc xếp xuất chuyển kho vỏ";
                else if (tsbt == "bkcpbxnck")
                    this.Text = "Bảng kê chi phí bốc xếp nhập chuyển kho";
                else if (tsbt == "bkcpbxnckv")
                    this.Text = "Bảng kê chi phí bốc xếp nhập chuyển kho vỏ";
                else if (tsbt == "bkcpvcnck")
                    this.Text = "Bảng kê chi phí vận chuyển nhập chuyển kho";
                else if (tsbt == "bkcpvcxck")
                    this.Text = "Bảng kê chi phí vận chuyển xuất chuyển kho";
                else if (tsbt == "kqtthhtt")
                    this.Text = "Kết quả tiêu thụ hàng hóa";
                else if (tsbt == "tsbtbctkbcn")
                    this.Text = "Báo cáo tồn kho báo cáo nhanh";
                else if (tsbt == "tsbtbctkbcnvo")
                    this.Text = "Báo cáo tồn kho vỏ LPG báo cáo nhanh";
                else if (tsbt == "tsbtbctkbcnvotndn")
                    this.Text = "Báo cáo tồn kho vỏ LPG từ ngày đến ngày báo cáo nhanh";
                else if (tsbt == "131tndn")
                    this.Text = "131 - Thanh toán với người mua";
                else if (tsbt == "131tndnbh")
                    this.Text = "Bảng kê hóa đơn bán hàng và chứng từ đã thanh toán";
                else if (tsbt == "331tndnbh")
                    this.Text = "Bảng kê hóa đơn mua hàng và chứng từ đã thanh toán";
                else if (tsbt == "131tndntdv")
                    this.Text = "131 - Thanh toán với người mua theo đơn vị";
                else if (tsbt == "131tndntdvth")
                    this.Text = "Báo cáo công nợ phải thu khách hàng";
                else if (tsbt == "131tndntdvthtk")
                    this.Text = "Báo cáo công nợ phải thu khách hàng theo kho";
                else if (tsbt == "131tndntct")
                    this.Text = "131 - Thanh toán với người mua toàn công ty";

                else if (tsbt == "bctknxtt")
                    this.Text = "Bảng kê nhập xuất thực tế";

                else if (tsbt == "bkcpbxnhtdv")
                    this.Text = "Bảng kê chi phí bốc xếp nhập kho tại đơn vị";

                else if (tsbt == "331tndn")
                    this.Text = "331 - Thanh toán với người bán";
                else if (tsbt == "331tndntdv")
                    this.Text = "331 - Thanh toán với người bán theo đơn vị";
                else if (tsbt == "331tndntct")
                    this.Text = "331 - Thanh toán với người bán toàn công ty";

                else if (tsbt == "1313tndn")
                    this.Text = "1313 - Thanh toán với người mua vỏ bình";
                else if (tsbt == "1313tndntdv")
                    this.Text = "1313 - Thanh toán với người mua vỏ bình theo đơn vị";
                else if (tsbt == "1313tndnbccnv")
                    this.Text = "Báo cáo công nợ vỏ";
                else if (tsbt == "tsbtbccnvkh")
                    this.Text = "Báo cáo công nợ vỏ khách hàng";
                else if (tsbt == "tsbtbccnvkhth")
                    this.Text = "Báo cáo công nợ vỏ khách hàng tổng hợp";
                else if (tsbt == "tsbtbccnvkhtk")
                    this.Text = "Báo cáo công nợ vỏ khách hàng theo kho";
                else if (tsbt == "bkthpsv")
                    this.Text = "Bảng kê tổng hợp phát sinh vỏ";
                else if (tsbt == "tsbtbccnvncc")
                    this.Text = "Báo cáo công nợ vỏ nhà cung cấp";
                else if (tsbt == "tsbtbccnvnccth")
                    this.Text = "Báo cáo công nợ vỏ nhà cung cấp tổng hợp";
                else if (tsbt == "1313tndntct")
                    this.Text = "1313 - Thanh toán với người mua vỏ bình toàn công ty";

                else if (tsbt == "3313tndn")
                    this.Text = "3313 - Thanh toán với người bán vỏ bình";
                else if (tsbt == "3313tndntdv")
                    this.Text = "3313 - Thanh toán với người bán vỏ bình theo đơn vị";
                else if (tsbt == "3313tndntct")
                    this.Text = "3313 - Thanh toán với người bán vỏ bình toàn công ty";

                else if (tsbt == "bardckmckunilever")
                    this.Text = "Đối chiếu khuyến mãi chiết khấu Unilever";
                else if (tsbt == "bardckmckgaudo")
                    this.Text = "Đối chiếu khuyến mãi chiết khấu Gấu Đỏ";

                else if (tsbt == "141tndntct")
                    this.Text = "141 - Tạm ứng";
                else if (tsbt == "1388tndn")
                    this.Text = "1388 - Phải thu khác";
                else if (tsbt == "1388tndntct")
                    this.Text = "1388 - Phải thu khác toàn công ty";
                else if (tsbt == "3388tndn")
                    this.Text = "3388 - Phải nộp, phải trả khác";
                else if (tsbt == "3388tndntct")
                    this.Text = "3388 - Phải nộp, phải trả khác toàn công ty";
                else if (tsbt == "341118tndntct")
                    this.Text = "341118 - Vay ngắn hạn khác";
                else if (tsbt == "341128tndntct")
                    this.Text = "341128 - Vay dài hạn khác";
                else if (tsbt == "3388tndntcttl")
                    this.Text = "3388 - Phải nộp, phải trả khác toàn công ty tính lãi";
                else if (tsbt == "tsbtbkthcp")
                    this.Text = "Bảng kê tổng hợp chi phí";
                else if (tsbt == "tsbtbkthcptn")
                    this.Text = "Bảng kê tổng hợp chi phí theo ngành";
                else if (tsbt == "tsbtbkthcptnrg")
                    this.Text = "Bảng kê tổng hợp chi phí";
                else if (tsbt == "tsbtbkthtncp")
                    this.Text = "Bảng kê tổng hợp theo nhóm chi phí";
                else if (tsbt == "tsbtbkthcptheokho")
                    this.Text = "Bảng kê tổng hợp chi phí theo kho";
                else if (tsbt == "chitiettaikhoan")
                    this.Text = "Chi tiết tài khoản";
                else if (tsbt == "tsbtbkthcpthuan")
                    this.Text = "Bảng kê tổng hợp chi phí thuần";
                else if (tsbt == "bchgkh" || tsbt == "bchgkhkhach")
                    this.Text = "Báo cáo hàng gửi khách hàng";
                else if (tsbt == "tsbtbctkhtd")
                    this.Text = "Báo cáo tồn kho hàng hóa";

                else if (tsbt == "tsbtthkqkd")
                {
                    this.Text = "Tình hình hoạt động kinh doanh";
                    this.Height = 290;
                    thtk.loadbcthhdkd(gridControl1, view, tsbt);
                    gridControl1.Visible = true;
                    gen.Position(this);
                }
                else if (tsbt == "tsbtbctctt")
                {
                    this.Text = "Báo cáo tài chính";
                    this.Height = 288;
                    thtk.loadbcthhdkd(gridControl1, view, tsbt);
                    gridControl1.Visible = true;
                    gen.Position(this);
                    groupControl2.Enabled = false;
                }
                else if (tsbt == "tsbtthdtvcp")
                    this.Text = "Doanh thu và chi phí";
                else if (tsbt == "scth")
                    this.Text = "Sổ cái tổng hợp";
                else if (tsbt == "sktth")
                    this.Text = "Sổ kế toán tổng hợp";
                else if (tsbt == "bkpxbhttm")
                    this.Text = "Bảng kê phiếu xuất bán hàng trả tiền mặt";
                else if (tsbt == "bkpxhtdnb")
                    this.Text = "Bảng kê phiếu xuất hàng tiêu dùng nội bộ";
                else if (tsbt == "bkpxhtdnbdc")
                    this.Text = "Bảng kê đối chiếu xuất hàng tiêu dùng nội bộ";
                else if (tsbt == "bkcpbxhgncc")
                    this.Text = "Bảng kê chi phí bốc xếp hàng gửi nhà cung cấp";
                else if (tsbt == "bkptttkh")
                    this.Text = "Bảng kê phiếu thu thu tiền khách hàng";
                else if (tsbt == "bkpsnkh")
                    this.Text = "Bảng kê phát sinh nợ khách hàng";
                else if (tsbt == "tsbtkqkdth")
                    this.Text = "Kết quả kinh doanh tổng hợp";
                else if (tsbt == "bangkehoadondenhan")
                    this.Text = "Bảng kê hóa đơn mua vào đến hạn thanh toán";
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            test = "0";
            if (tsbt != "tsbtthkqkd" && tsbt != "tsbtbctctt")
            {
                this.Height = 168;
                gen.Position(this);
                gridControl1.Visible = false;
                gridControl2.Visible = false;
            }
            detungay.EditValue = null;
            if (tsbt == "lvphtbhtnvvsl" || tsbt == "thsdhd" || tsbt == "bccntnh" || tsbt == "bkcthddtt" || tsbt == "tsbtbaocaosanluong" || tsbt == "tsbtbaocaoluongsanluong" || tsbt == "tsbtbcthmb" || tsbt == "131tndntcthmn" || tsbt == "tsbtlaigopkinhdoanh" || tsbt == "tsbtbcslbhtt" || tsbt == "tsbtbcslbhtq" || tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcdtlnct" || tsbt == "tsbtbcdtlntq" || tsbt == "tsbtbcthlthh" || tsbt == "tsbtbctkhtd" || tsbt == "barbctct")
            {
                    string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, comboBoxEdit1.SelectedIndex + 1).ToString();
                    dedenngay.EditValue = DateTime.Parse((comboBoxEdit1.SelectedIndex + 1).ToString() + "/" + ngay + "/" + DateTime.Parse(ngaychungtu).Year);
                    detungay.EditValue = DateTime.Parse((comboBoxEdit1.SelectedIndex + 1).ToString() + "/" + "1" + "/" + DateTime.Parse(ngaychungtu).Year);
            }
            else if (tsbt == "bctqtkho" || tsbt == "barthkqkdhtd")
            {
                //string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, comboBoxEdit1.SelectedIndex + 1).ToString();
                dedenngay.EditValue = DateTime.Parse(ngaychungtu);
                detungay.EditValue = DateTime.Parse(ngaychungtu);

            }
            else if (comboBoxEdit1.SelectedIndex > 4 && comboBoxEdit1.SelectedIndex < 17)
            {
                string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, comboBoxEdit1.SelectedIndex - 4).ToString();
                dedenngay.EditValue = DateTime.Parse((comboBoxEdit1.SelectedIndex - 4).ToString() + "/" + ngay + "/" + DateTime.Parse(ngaychungtu).Year);
                detungay.EditValue = DateTime.Parse((comboBoxEdit1.SelectedIndex-4).ToString() + "/" + "1" + "/" + DateTime.Parse(ngaychungtu).Year);
            }
            else if (comboBoxEdit1.SelectedIndex > 0 && comboBoxEdit1.SelectedIndex < 5)
            {
                string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, comboBoxEdit1.SelectedIndex * 3).ToString();
                dedenngay.EditValue = DateTime.Parse((comboBoxEdit1.SelectedIndex * 3).ToString() + "/" + ngay + "/" + DateTime.Parse(ngaychungtu).Year);
                detungay.EditValue = DateTime.Parse(((comboBoxEdit1.SelectedIndex-1) * 3 + 1).ToString() + "/" + "1" + "/" + DateTime.Parse(ngaychungtu).Year);
            }
            else if (comboBoxEdit1.SelectedIndex == 0)
            {
                string ngay = DateTime.DaysInMonth(DateTime.Parse(ngaychungtu).Year, 12).ToString();
                dedenngay.EditValue = DateTime.Parse("12" + "/" + ngay + "/" + DateTime.Parse(ngaychungtu).Year);
                detungay.EditValue = DateTime.Parse("1" + "/" + "1" + "/" + DateTime.Parse(ngaychungtu).Year);
            }
        }

        private void detungay_EditValueChanged(object sender, EventArgs e)
        {
            test = "0";

            if (tsbt == "tsbtkqkdth")
                try
                {
                    if (DateTime.Parse(detungay.EditValue.ToString()) < DateTime.Parse("05/01/2016"))
                    {
                        dedenngay.EditValue = DateTime.Parse("05/31/2016");
                        detungay.EditValue = DateTime.Parse("05/01/2016");
                    }
                }
                catch { }

            if (tsbt != "tsbtthkqkd" && tsbt != "tsbtbctctt")
            {
                this.Height = 168;
                gen.Position(this);
                gridControl1.Visible = false;
                gridControl2.Visible = false;
            }
            try
            {
                if ((DateTime.Parse(detungay.EditValue.ToString()) > DateTime.Parse(dedenngay.EditValue.ToString()) && dedenngay.EditValue != null) || DateTime.Parse(detungay.EditValue.ToString()).Year != DateTime.Parse(dedenngay.EditValue.ToString()).Year)
                    detungay.EditValue = dedenngay.EditValue;
            }
            catch { }
        }

        private void dedenngay_EditValueChanged(object sender, EventArgs e)
        {
            test = "0";
            if (tsbt != "tsbtthkqkd" && tsbt != "tsbtbctctt")
            {
                this.Height = 168;
                gen.Position(this);
                gridControl1.Visible = false;
                gridControl2.Visible = false;
            }
            try
            {
                if (tsbt == "chitiettaikhoan")
                {
                    if ((DateTime.Parse(detungay.EditValue.ToString()) > DateTime.Parse(dedenngay.EditValue.ToString()) && detungay.EditValue != null))
                        dedenngay.EditValue = detungay.EditValue;
                }
                else
                {
                    if ((DateTime.Parse(detungay.EditValue.ToString()) > DateTime.Parse(dedenngay.EditValue.ToString()) && detungay.EditValue != null) || DateTime.Parse(detungay.EditValue.ToString()).Year != DateTime.Parse(dedenngay.EditValue.ToString()).Year)
                        dedenngay.EditValue = detungay.EditValue;
                }
            }
            catch { }
        }

        private void sbok_Click(object sender, EventArgs e)
        {
            try
            {
                if (test == "0")
                {
                    if (tsbt == "tsbtthkqkd")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "1")
                        {
                            Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
                            F.getngaychungtu(ngaycuoi);
                            F.getngaycuoi(ngaydau);
                            F.gettsbt(tsbt);
                            F.getuser(userid);
                            F.ShowDialog();
                        }
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "2")
                            thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString(), ngaycuoi, ngaydau, tsbt + "tct", userid);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "3")
                            thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString(), ngaycuoi, ngaydau, tsbt + "khuvuc", userid);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "4")
                            thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString(), ngaycuoi, ngaydau, tsbt + "cuahang", userid);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "5")
                        {
                            thtk.loadketquakinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString(), ngaycuoi, ngaydau, tsbt + "loaihang", userid);
                        }
                    }
                    else if (tsbt == "tsbtbctctt")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "1")
                            bct.loadbcdtkth(ngaycuoi, "tsbtbthhdkd", ngaydau);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "2")
                            bct.loadbangcandoiketoan(ngaycuoi, "tsbtbcdkt", userid, ngaydau);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "3")
                            bct.loadtinhhinhhoatdongkinhdoanh(ngaycuoi, "tsbtbthhdkd", userid, ngaydau);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "5")
                            bct.tinhhinhnghiavu(ngaydau, ngaycuoi);
                        else if (view.GetRowCellValue(view.FocusedRowHandle, "STT").ToString() == "4")
                            bct.luuchuyentiente(ngaydau, ngaycuoi);
                    }
                    else if (tsbt == "thsdhd")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadsdhd(detungay.EditValue.ToString(), ngaycuoi, "0", userid);
                    }
                    else if (tsbt == "tsbtthdtvcp")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        string ngaydau = detungay.EditValue.ToString();
                        bct.loaddoanhthuvachiphi(ngaycuoi, ngaydau, userid);
                    }
                    else if (tsbt == "tsbtbkthcp")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        string ngaydau = detungay.EditValue.ToString();
                        if (DateTime.Parse(dedenngay.EditValue.ToString()).Month == DateTime.Parse(detungay.EditValue.ToString()).Month)
                            bct.loadbkthphi(ngaycuoi, "tsbtbkthcp", ngaydau, userid);
                        else
                            bct.loadbkthphi(ngaycuoi, "tsbtbkthcptndn", ngaydau, userid);
                    }
                    else if (tsbt == "tsbtbkthcptn")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        string ngaydau = detungay.EditValue.ToString();
                        bct.loadbkthphi(ngaycuoi, "tsbtbkthcptn", ngaydau, userid);
                    }
                    else if (tsbt == "tsbtbkthcptnrg")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        string ngaydau = detungay.EditValue.ToString();
                        bct.loadbkthphi(ngaycuoi, "tsbtbkthcptnrg", ngaydau, userid);
                    }
                    else if (tsbt == "tsbtbkthtncp")
                    {
                        /*string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        string ngaydau = detungay.EditValue.ToString();
                        bct.loadbkthphi(ngaycuoi, "tsbtbkthtncp", ngaydau, userid);*/
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        F.gettsbt(tsbt);
                        F.gettungay(detungay.EditValue.ToString());
                        F.getdenngay(ngaycuoi);
                        myac();
                        this.Close();
                    }

                    else if (tsbt == "tsbtbkthcptheokho" || tsbt == "tsbtbkthcpthuan")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        string ngaydau = detungay.EditValue.ToString();
                        if (DateTime.Parse(dedenngay.EditValue.ToString()).Month == DateTime.Parse(detungay.EditValue.ToString()).Month)
                            bct.loadbkthphi(ngaycuoi, tsbt, ngaydau, userid);
                        else
                            bct.loadbkthphi(ngaycuoi, tsbt + "tndn", ngaydau, userid);
                    }
                    else if (tsbt == "kqtthhtt")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        Frm_rpcongno F = new Frm_rpcongno();
                        F.gettungay(detungay.EditValue.ToString());
                        F.getdenngay(ngaycuoi);
                        F.gettsbt("kqtthhtt");
                        F.Show();
                    }
                    else if (tsbt == "131tndntct" || tsbt == "331tndntct" || tsbt == "1313tndntct" || tsbt == "3313tndntct" || tsbt == "141tndntct" || tsbt == "1388tndntct" || tsbt == "3388tndntct" || tsbt == "341118tndntct" || tsbt == "341128tndntct")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadbccntndn(detungay.EditValue.ToString(), ngaycuoi, tsbt, "");
                    }
                    else if (tsbt == "131tndntcthmn")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        F.gettsbt(tsbt);
                        F.getdenngay(ngaycuoi);
                        myac();
                        this.Close();
                    }
                    else if (tsbt == "bcslmb")
                    {
                        F.gettungay(detungay.EditValue.ToString());
                        F.getdenngay(DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString());
                        myac();
                        this.Close();
                    }
                    else if (tsbt == "chitiettaikhoan")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        DataSet da = new DataSet();
                        da.Tables.Add(gen.GetTable("bangkechitiettaikhoan '" + ngaydau + "','" + ngaycuoi + "'"));
                        gen.CreateExcel(da, "Chitiettaikhoan_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaydau)) + "_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngaycuoi)) + ".xlsx");
                    }
                    else if (tsbt == "bccntnh" || tsbt == "bkcthddtt")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        if (DateTime.Parse(dedenngay.EditValue.ToString()).Month == DateTime.Now.Month && DateTime.Parse(dedenngay.EditValue.ToString()).Year == DateTime.Now.Year)
                            F.getdenngay(DateTime.Now.ToString());
                        else
                            F.getdenngay(ngaycuoi);
                        myac();
                        this.Close();
                    }
                    else if (tsbt == "3388tndntcttl")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadbchitietlaitndn(detungay.EditValue.ToString(), ngaycuoi);
                    }
                    else if (tsbt == "scth" || tsbt == "sktth")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bct.loadbcdtkthtndn(ngaycuoi, tsbt, ngaydau);
                    }

                    else if (tsbt == "tsbtkqkdth")
                        thtk.loadketquakinhdoanhtonghop(detungay.EditValue.ToString(), dedenngay.EditValue.ToString(), tsbt);
                    else if (tsbt == "tsbtbcthmb")
                        thtk.loadbaocaotinhhinhmuaban(detungay.EditValue.ToString(), dedenngay.EditValue.ToString(), tsbt);
                    else if (tsbt == "bangkehoadondenhan")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        Frm_nhapxuat F = new Frm_nhapxuat();
                        F.getngay(detungay.EditValue.ToString());
                        F.getcongty(ngaycuoi);
                        F.gettsbt(tsbt);
                        F.getrole(userid);
                        F.ShowDialog();
                    }
                    else if (tsbt == "sctbhtkhvmhth")
                    {
                        F.gettungay(detungay.EditValue.ToString());
                        F.getdenngay(DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString());
                        myac();
                        this.Close();
                    }

                    else if (tsbt == "barbctct")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        Frm_nhapxuat F = new Frm_nhapxuat();
                        F.getngay(detungay.EditValue.ToString());
                        F.gettsbt(tsbt);
                        F.getrole(userid);
                        F.ShowDialog();
                    }

                    else
                    {
                        if (gen.GetString("select CompanyTaxCode from Center") == "" && tsbt == "bkpxhtdnb")
                        {
                            string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                            Frm_nhapxuat F = new Frm_nhapxuat();
                            F.getngay(detungay.EditValue.ToString());
                            F.getcongty(ngaycuoi);
                            F.gettsbt(tsbt + "bangkechiphi");
                            F.ShowDialog();
                        }
                        else
                        {
                            test = "1";
                            this.Height = 416;
                            gen.Position(this);
                            if (tsbt == "tsbtbctkbcnvotndn" || tsbt == "bkcpbxhgncc" || tsbt == "sctbhtkhvhd" || tsbt == "sctbhtkhvmh" || tsbt == "bkcthdbh" || tsbt == "sctmhtmh" || tsbt == "lvphtbhtnvvsl" || tsbt == "tsbtbaocaosanluong" || tsbt == "tsbtbaocaoluongsanluong" || tsbt == "snkmh" || tsbt == "snkbh" || tsbt == "snkxk" || tsbt == "snkxktx" || tsbt == "snkxkct" || tsbt == "snknk" || tsbt == "bkcpbh" || tsbt == "bkcntt" || tsbt == "bkcntttdv" || tsbt == "bkcnttct" || tsbt == "bkhdbvt" || tsbt == "bknmvt" || tsbt == "bknckvlpg" || tsbt == "bkxckvlpg" || tsbt == "snkxcnbtc" || tsbt == "bkcpbx" || tsbt == "bkcpk" || tsbt == "bkcpbxthhh" || tsbt == "bkcpbxv" || tsbt == "bkcpvcbh" || tsbt == "bkcpbxth" || tsbt == "bkcpbxthnv" || tsbt == "bkthbhtnvkd" || tsbt == "bkthbhtnvkdlqh" || tsbt == "bkthhkm" || tsbt == "bkthhhtx" || tsbt == "tsbtpnkvtddh" || tsbt == "bkcpbxxck" || tsbt == "bkcpbxxckv" || tsbt == "bkcpbxnck" || tsbt == "bkcpbxnckv" || tsbt == "bkcpvcnck" || tsbt == "bkcpvcxck" || tsbt == "bkcpbxnh" || tsbt == "bkcpbxnhv" || tsbt == "bkcpbxnhtdv" || tsbt == "131tndn" || tsbt == "131tndnbh" || tsbt == "331tndnbh" || tsbt == "331tndn" || tsbt == "1313tndn" || tsbt == "3313tndn" || tsbt == "1388tndn" || tsbt == "3388tndn" || tsbt == "bkxktkhvmh" || tsbt == "bkpxbhttm" || tsbt == "bkxktmhpx" || tsbt == "bkptttkh" || tsbt == "bkpxhtdnb" || tsbt == "tsbtthbhtdtkh" || tsbt == "tsbtlaigopkinhdoanh" || tsbt == "tsbtbcthlthh" || tsbt == "bchgkh" || tsbt == "bchgkhkhach" || tsbt == "bctkhhtn" || tsbt == "bctknxtt" || tsbt == "bctkhhtnvo" || tsbt == "bctkhhtnlpg" || tsbt == "tsbtbctkhtd" || tsbt == "bctqtkho" || tsbt == "barthkqkdhtd")
                                thtk.loadStockmain(gridControl1, view, detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), userid, tsbt);
                            else if (tsbt == "sctbhtkhvmhth" || tsbt == "tsbtbctkbcn" || tsbt == "tsbtbctkbcnvo" || tsbt == "tsbtbcslbhtt" || tsbt == "tsbtbcslbhtq" || tsbt == "tsbtbcdtsl" || tsbt == "tsbtdskhm" || tsbt == "tsbtdskhkpsdt" || tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcdtlnct" || tsbt == "tsbtbcdtlntq")
                                thtk.loadBranchmain(gridControl1, view, detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), userid, tsbt);
                            else if (tsbt == "131tndntdv" || tsbt == "131tndntdvth" || tsbt == "131tndntdvthtk" || tsbt == "331tndntdv" || tsbt == "1313tndntdv" || tsbt == "1313tndnbccnv" || tsbt == "3313tndntdv" || tsbt == "tsbtbccnvkh" || tsbt == "tsbtbccnvncc" || tsbt == "tsbtbccnvkhth" || tsbt == "tsbtbccnvkhtk" || tsbt == "tsbtbccnvnccth" || tsbt == "bkthpsv")
                                thtk.loadStocktdvtndn(gridControl1, view, detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), userid, tsbt);
                            else if (tsbt == "snkxcnb" || tsbt == "snkncnb")
                                thtk.loadStockbkhh(gridControl1, view, detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt, userid);
                            else if (tsbt == "bardckmckunilever" || tsbt == "bardckmckgaudo")
                                thtk.loadStockmainhangtieudung(gridControl1, view, detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt);
                            else if (tsbt == "bkpxhtdnbdc")
                                thtk.loadStock(gridControl1, view, DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), userid, tsbt);
                            gridControl1.Visible = true;
                        }
                    }
                }
                else if (test == "1")
                {
                    if (tsbt == "lvphtbhtnvvsl")
                    {
                        Frm_luongvaphi F = new Frm_luongvaphi();
                        F.getngay(detungay.EditValue.ToString());
                        F.getkho(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.gettenkho(view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString());
                        F.getuser(userid);
                        F.getkhach(khach);
                        F.ShowDialog();
                    }
                    else if (tsbt == "bkthbhtnvkdlqh")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        Frm_chonkhotonghoptaikhoan F = new Frm_chonkhotonghoptaikhoan();
                        F.getngaychungtu(ngaydau);
                        F.getngaycuoi(ngaycuoi);
                        F.gettsbt(tsbt);
                        F.getuser(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.ShowDialog();
                    }
                    else if (tsbt == "tsbtbaocaosanluong")
                        thtk.bangkesanluongbanhang(detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), userid, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    else if (tsbt == "tsbtbaocaoluongsanluong")
                        thtk.bangkeluongsanluongbanhang(detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), userid, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    else if (tsbt == "sctbhtkhvhd" || tsbt == "snkmh" || tsbt == "snkbh" || tsbt == "tsbtthbhtdtkh")
                        thtk.loadnhaphangtrongkytheohdmain(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt, userid);
                    else if (tsbt == "sctbhtkhvmh" || tsbt == "sctmhtmh" || tsbt == "bkxktkhvmh" || tsbt == "bkcthdbh" || tsbt == "bkxktmhpx")
                        thtk.loadnhaphangtrongkymain(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt, userid);
                    else if (tsbt == "sctbhtkhvmhth")
                    {
                        DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng kê, 'No' để xuất excel.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                            thtk.loadnhapxuathangtrongkymain(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt, userid, "");
                        else if (dr == DialogResult.No)
                            thtk.loadnhapxuathangtrongkymain(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt, userid, "No");
                    }
                    else if (tsbt == "snkxk" || tsbt == "snkxkct")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng kê xuất kho kèm hóa đơn, 'No' để in bảng kê xuất kho.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                            thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "co");
                        else if (dr == DialogResult.No)
                            thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "");
                    }
                    else if (tsbt == "tsbtlaigopkinhdoanh")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadketqualaigopkinhdoanh(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), ngaycuoi, tsbt, userid, ngaydau);
                    }
                    else if (tsbt == "tsbtbctkbcn" || tsbt == "bctkhhtn" || tsbt == "bctkhhtnvo" || tsbt == "bctkhhtnlpg")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        baocaotonkho bctk = new baocaotonkho();
                        bctk.loadbctkthdtndnbcn(ngaydau, ngaycuoi, tsbt, userid, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "bctknxtt")
                    {
                        string ngaydau = detungay.EditValue.ToString();
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        baocaotonkho bctk = new baocaotonkho();
                        bctk.baocaonhapxuatthucte(ngaydau, ngaycuoi, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), tsbt);
                    }
                    else if (tsbt == "tsbtbctkbcnvo" || tsbt == "tsbtbctkbcnvotndn")
                    {
                        baocaotonkhovo bctk = new baocaotonkhovo();
                        bctk.loadbctkthdtndn(detungay, dedenngay, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), tsbt, userid);
                    }
                    else if (tsbt == "bkpxbhttm")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in bảng kê chi tiết phiếu, 'No' để in bảng kê tổng hợp khách hàng.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                            thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "");
                        else if (dr == DialogResult.No)
                            thtk.bangkethutienmat(detungay.EditValue.ToString(), ngaycuoi, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), tsbt + "tong");
                    }
                    else if (tsbt == "bkpxhtdnb")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "");
                    }
                    else if (tsbt == "snkxcnb" || tsbt == "snkncnb")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "IDS").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "snkxcnbtc" || tsbt == "bkcpbx" || tsbt == "bkcpk" || tsbt == "bkcpbxthhh" || tsbt == "bkcpbxv" || tsbt == "bkcpvcbh" || tsbt == "bkcpbxth" || tsbt == "bkcpbxthnv" || tsbt == "bkthhkm" || tsbt == "bkcpbxxck" || tsbt == "bkcpbxxckv" || tsbt == "bkcpbxnck" || tsbt == "bkcpbxnckv" || tsbt == "bkcpvcnck" || tsbt == "bkcpvcxck" || tsbt == "bkcpbxnh" || tsbt == "bkcpbxnhv" || tsbt == "bkcpbxnhtdv")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "");
                    }
                    else if (tsbt == "bkthbhtnvkd")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadbangkehanghoatong(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString(), "", "2");
                    }
                    else if (tsbt == "bkthhhtx" || tsbt == "tsbtpnkvtddh")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString(), view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString());
                    }
                    else if (tsbt == "snknk")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadbangkehanghoa(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), "", view.GetRowCellValue(view.FocusedRowHandle, "Mã kho").ToString() + " - " + view.GetRowCellValue(view.FocusedRowHandle, "Tên kho").ToString(), "", "");
                    }
                    else if (tsbt == "bkcntt" || tsbt == "bkcnttct" || tsbt == "bkcntttdv")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadbccntt(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "bkhdbvt" || tsbt == "bknmvt" || tsbt == "bknckvlpg" || tsbt == "bkxckvlpg" || tsbt == "snkxktx")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadbangkenhapxuatvo(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "bkptttkh")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        thtk.loadbangkephieuthu(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "131tndn" || tsbt == "131tndnbh" || tsbt == "331tndnbh" || tsbt == "131tndntdv" || tsbt == "131tndntdvth" || tsbt == "131tndntdvthtk" || tsbt == "331tndn" || tsbt == "331tndntdv" || tsbt == "1313tndn" || tsbt == "1313tndntdv" || tsbt == "1313tndnbccnv" || tsbt == "3313tndn" || tsbt == "3313tndntdv" || tsbt == "1388tndn" || tsbt == "3388tndn" || tsbt == "1313tndnbccnv")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadbccntndn(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "tsbtbccnvkh" || tsbt == "tsbtbccnvncc" || tsbt == "tsbtbccnvkhth" || tsbt == "tsbtbccnvkhtk" || tsbt == "tsbtbccnvnccth")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadbccntndn(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "bkthpsv")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        bccn.loadbkthpsv(detungay.EditValue.ToString(), ngaycuoi, tsbt, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "tsbtbcslbhtt" || tsbt == "tsbtbcslbhtq" || tsbt == "tsbtbcdtlntt" || tsbt == "tsbtbcdtlnct" || tsbt == "tsbtbcdtlntq" || tsbt == "barthkqkdhtd")
                    {
                        F.getdonvicongno(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        myac();
                        this.Close();
                    }
                    else if (tsbt == "tsbtbcdtsl" || tsbt == "tsbtdskhm" || tsbt == "tsbtdskhkpsdt" || tsbt == "tsbtbcthlthh")
                    {
                        F.gettungay(detungay.EditValue.ToString());
                        F.getdenngay(DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString());
                        F.getdonvicongno(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        myac();
                        this.Close();
                    }
                    else if (tsbt == "bchgkh" || tsbt == "bchgkhkhach")
                    {
                        DialogResult dr = XtraMessageBox.Show("Nhấn 'Yes' để in tồn kho, 'No' để in chi tiết.", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.Yes)
                        {
                            baocaotonkhothucte bctktt = new baocaotonkhothucte();
                            bctktt.loadbctkthdtndn(detungay, dedenngay, view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString(), tsbt, userid);
                        }
                        else if (dr == DialogResult.No)
                            thtk.loadnhatkynhaphang(detungay.EditValue.ToString(), DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString(), tsbt, "10338FC1-25A4-438C-8B4D-A0AD5B83909F", view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "bkcpbxhgncc")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        Frm_nhapxuat F = new Frm_nhapxuat();
                        F.getngay(detungay.EditValue.ToString());
                        F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.getcongty(ngaycuoi);
                        F.getkho(userid);
                        F.gettsbt(tsbt);
                        F.ShowDialog();
                    }
                    else if (tsbt == "bkpxhtdnbdc")
                    {
                        string ngaycuoi = DateTime.Parse(dedenngay.EditValue.ToString()).AddDays(1).AddSeconds(-1).ToString();
                        Frm_nhapxuat F = new Frm_nhapxuat();
                        F.getngay(detungay.EditValue.ToString());
                        F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.getcongty(ngaycuoi);
                        F.getkho(userid);
                        F.gettsbt(tsbt);
                        F.ShowDialog();
                    }
                    else if (tsbt == "tsbtbctkhtd")
                    {
                        baocaotonkho bctk = new baocaotonkho();
                        bctk.loadbctkthdtndnbcnhangtieudung(detungay.EditValue.ToString(), view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                    }
                    else if (tsbt == "bctqtkho")
                    {
                        /*Frm_rpcongno F = new Frm_rpcongno();
                        F.gettsbt(tsbt);
                        F.getngaychungtu(ngaychungtu);
                        F.getkho(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.ShowDialog();*/
                        Frm_ngay F = new Frm_ngay();
                        F.getngaychungtu(ngaychungtu);
                        F.getuser(userid);
                        F.getkho(view.GetRowCellValue(view.FocusedRowHandle, "ID").ToString());
                        F.gettsbt("bctqtkho");
                        F.ShowDialog();
                    }
                    else if (tsbt == "bardckmckunilever")
                    {
                        if (Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Số lượng").ToString()) == 0)
                        {
                            Frm_nhapxuat F = new Frm_nhapxuat();
                            F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã khuyến mãi").ToString());
                            if (view.GetRowCellValue(view.FocusedRowHandle, "Kết thúc").ToString() != "")
                                F.getngay(view.GetRowCellValue(view.FocusedRowHandle, "Bắt đầu").ToString());
                            else
                                F.getngay(detungay.EditValue.ToString());
                            F.getcongty(view.GetRowCellValue(view.FocusedRowHandle, "Kết thúc").ToString());
                            F.gettsbt("bardckmckunilevertien");
                            F.ShowDialog();
                        }
                        else
                        {
                            Frm_nhapxuat F = new Frm_nhapxuat();
                            F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã khuyến mãi").ToString());
                            F.getngay(view.GetRowCellValue(view.FocusedRowHandle, "Bắt đầu").ToString());
                            F.getcongty(view.GetRowCellValue(view.FocusedRowHandle, "Kết thúc").ToString());
                            F.gettsbt("bardckmckunileversanluong");
                            F.ShowDialog();
                        }
                    }
                    else if (tsbt == "bardckmckgaudo")
                    {
                        if (Double.Parse(view.GetRowCellValue(view.FocusedRowHandle, "Số lượng").ToString()) == 0)
                        {
                            Frm_nhapxuat F = new Frm_nhapxuat();
                            F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã khuyến mãi").ToString());
                            F.getngay(view.GetRowCellValue(view.FocusedRowHandle, "Bắt đầu").ToString());
                            F.getcongty(view.GetRowCellValue(view.FocusedRowHandle, "Kết thúc").ToString());
                            F.gettsbt("bardckmckgaudotien");
                            F.ShowDialog();
                        }
                        else
                        {
                            Frm_nhapxuat F = new Frm_nhapxuat();
                            F.getrole(view.GetRowCellValue(view.FocusedRowHandle, "Mã khuyến mãi").ToString());
                            F.getngay(view.GetRowCellValue(view.FocusedRowHandle, "Bắt đầu").ToString());
                            F.getcongty(view.GetRowCellValue(view.FocusedRowHandle, "Kết thúc").ToString());
                            F.gettsbt("bardckmckgaudosanluong");
                            F.ShowDialog();
                        }
                    }
                }
            }
            catch { }
        }

        private void view_DoubleClick(object sender, EventArgs e)
        {
            if (tsbt == "bardckmckunilever" || tsbt == "bardckmckgaudo")
            {
                DialogResult dr = XtraMessageBox.Show("Bạn có chắc muốn duyệt mã khuyến mãi " + view.GetRowCellValue(view.FocusedRowHandle, "Mã khuyến mãi").ToString() + ".", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.Yes)
                {
                    gen.ExcuteNonquery("update INOutwardCheck set Checked='True' where FreeCode='" + view.GetRowCellValue(view.FocusedRowHandle, "Mã khuyến mãi").ToString() + "'");
                    view.SetRowCellValue(view.FocusedRowHandle, view.Columns["Duyệt"], "True");
                }
            }
        }

        private void view_FocusedRowChanged(object sender, EventArgs e)
        {
            if (tsbt == "lvphtbhtnvvsl")
            {
                if (gridControl2.Visible == true)
                {
                    gridControl2.Visible = false;
                    this.Height = 416;
                    gen.Position(this);
                }
            }
        }
    }
}