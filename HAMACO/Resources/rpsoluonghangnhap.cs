using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;

namespace HAMACO.Resources
{
    public partial class rpsoluonghangnhap : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpsoluonghangnhap()
        {
            InitializeComponent();
        }
        public void gettieude(string makho, string userid,string tsbt,string ngaychungtu)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            string thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
            string nam = String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));

            if (tsbt == "tsbthdmh")
                xrLabel2.Text = "BẢNG KÊ HÀNG HÓA NHẬP TRONG KỲ THÁNG "+thang+" NĂM "+nam;
            else if (tsbt == "tsbthdbh")
                xrLabel2.Text = "BẢNG KÊ HÀNG HÓA XUẤT TRONG KỲ THÁNG " + thang + " NĂM " + nam;
            else if (tsbt == "tsbthdbhchitiet")
            {
                xrLabel2.Text = "BẢNG KÊ CHI TIẾT XUẤT KHO";
                xrTableCell54.Text = "";
                xrTableCell47.Text = "";
            }
            else if (tsbt == "tsbthdbhhd")
            {
                xrLabel2.Text = "BẢNG KÊ HÀNG HÓA XUẤT TRONG KỲ THÁNG THEO HÓA ĐƠN " + thang + " NĂM " + nam;
                xrTableCell54.Text = "";
                xrTableCell47.Text = "";
            }
            else if (tsbt == "tsbtpnht")
                xrLabel2.Text = "BẢNG KÊ HÀNG HÓA NHẬP THỪA TRONG KỲ THÁNG " + thang + " NĂM " + nam;
            else if (tsbt == "sctbhtkhvmh")
                xrLabel2.Text = "BẢNG KÊ HÀNG HÓA NHẬP THỪA TRONG KỲ THÁNG " + thang + " NĂM " + nam;
            try
            {
                xrLabel5.Text = gen.GetString("select StockCode+' - '+StockName from  Stock where StockID='" + makho + "'").ToUpper();
            }
            catch { xrLabel5.Text = gen.GetString("select BranchCode+' - '+BranchName from  Branch where BranchID='" + makho + "'").ToUpper(); }
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
        }

        public void gettieudehoadon(string hoadon,string ngaychungtu, string role,string tsbt)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");            
            xrLabel2.Text = "BẢNG KÊ CHI TIẾT XUẤT KHO";
            xrLabel5.Text = "THEO HÓA ĐƠN: " + hoadon + " - NGÀY " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            xrTableCell17.Text = "Đơn giá";
            if (tsbt == "tsbthdbhchitiet")
                xrTableCell25.Text = "Ngày lập";
            else if (tsbt == "tsbthdbhchitiettomtat")
                GroupHeader1.Visible = false;
            xrLabel3.Text = "Bảng kê số: " + hoadon;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            DataTable dt = gen.GetTable("select TotalAmount-TotalFreightAmount+TotalCost+TotalVatAmount-TotalDiscountAmount,TotalVatAmount,TotalDiscountAmount  from SSInvoice where RefID='" + role + "'");
            xrTableCell33.Text = String.Format("{0:n0}", Double.Parse(dt.Rows[0][2].ToString()));
            xrTableCell38.Text = String.Format("{0:n0}", Double.Parse(dt.Rows[0][1].ToString()));
            xrTableCell43.Text = String.Format("{0:n0}", Double.Parse(dt.Rows[0][0].ToString()));
            xrTableCell45.Text = "Cần Thơ, ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
            xrTableCell51.Text = "";
            xrTableCell46.Text = "";
            xrTableCell54.Text = "Người lập";
        }

        public void gettieudemain(string makho, string userid, string tsbt, string tungay, string denngay)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            if (DateTime.Parse(tungay).Day == 1 && DateTime.Parse(denngay).Day == DateTime.DaysInMonth(DateTime.Parse(denngay).Year, DateTime.Parse(denngay).Month) && DateTime.Parse(tungay).Year == DateTime.Parse(denngay).Year)
            {
                if (DateTime.Parse(tungay).Month == DateTime.Parse(denngay).Month)
                    xrLabel2.Text = "THÁNG "+DateTime.Parse(denngay).Month+" NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 3)
                    xrLabel2.Text = "QUÝ I NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 4 && DateTime.Parse(denngay).Month == 6)
                    xrLabel2.Text = "QUÝ II NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 7 && DateTime.Parse(denngay).Month == 9)
                    xrLabel2.Text = "QUÝ III NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 10 && DateTime.Parse(denngay).Month == 12)
                    xrLabel2.Text = "QUÝ VI NĂM " + DateTime.Parse(denngay).Year;
                else if (DateTime.Parse(tungay).Month == 1 && DateTime.Parse(denngay).Month == 12)
                    xrLabel2.Text = "NĂM " + DateTime.Parse(denngay).Year;
                else
                {
                    tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                    denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                    xrLabel2.Text = "TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay;
                }
            }
            else
            {
                tungay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(tungay));
                denngay = String.Format("{0:dd/MM/yyy}", DateTime.Parse(denngay));
                xrLabel2.Text = "TỪ NGÀY " + tungay + " ĐẾN NGÀY " + denngay;
            }
            try
            {
                xrLabel5.Text = gen.GetString("select StockCode+' - '+StockName from  Stock where StockID='" + makho + "'").ToUpper();
            }
            catch { xrLabel5.Text = gen.GetString("select BranchCode+' - '+BranchName from  Branch where BranchID='" + makho + "'").ToUpper(); }
            xrLabel4.Text = "In lúc: " + String.Format("{0:HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);
            if (tsbt == "sctbhtkhvhd")
                xrLabel2.Text = "SỔ CHI TIẾT BÁN HÀNG THEO KHÁCH HÀNG VÀ HÓA ĐƠN " + xrLabel2.Text;
            else if (tsbt == "tsbtthbhtdtkh")
                xrLabel2.Text = "BẢNG KÊ BÁN HÀNG THEO ĐỐI TƯỢNG KHÁCH HÀNG " + xrLabel2.Text;
            else if (tsbt == "sctbhtkhvmh")
                xrLabel2.Text = "SỔ CHI TIẾT BÁN HÀNG THEO KHÁCH HÀNG VÀ MẶT HÀNG " + xrLabel2.Text;
            else if (tsbt == "sctbhtkhvmhth")
            {
                xrLabel2.Text = "SỔ CHI TIẾT BÁN HÀNG THEO KHÁCH HÀNG VÀ MẶT HÀNG " + xrLabel2.Text;
                xrTableCell18.Text = "Đơn giá";
                xrTableCell25.Text = "Số tiền";
            }
            else if (tsbt == "sctmhtmh")
                xrLabel2.Text = "SỔ CHI TIẾT MUA HÀNG THEO MẶT HÀNG " + xrLabel2.Text;
            else if (tsbt == "bkxktkhvmh")
                xrLabel2.Text = "BẢNG KÊ XUẤT KHO THEO KHÁCH HÀNG " + xrLabel2.Text;
            else if (tsbt == "bkxktmhpx")
            {
                xrLabel2.Text = "BẢNG KÊ XUẤT KHO THEO MẶT HÀNG " + xrLabel2.Text;
                xrTableCell18.Text = "Đơn giá";
                xrTableCell25.Text = "Số tiền";
            }
            else if (tsbt == "bkcthdbh")
            {
                xrLabel2.Text = "BẢNG KÊ CHI TIẾT HÓA ĐƠN BÁN HÀNG " + xrLabel2.Text;
                xrTableCell17.Text = "Đơn giá";
                xrTableCell1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
                xrTableCell16.ForeColor = System.Drawing.Color.White;
                xrTableCell10.ForeColor = System.Drawing.Color.White;
            }
        }

        public void BindData(DataTable da)
        {

            DataSource = da;
            GroupHeader2.Visible = false;
            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Mã nhóm");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell4.DataBindings.Add("Text", DataSource, "Mã nhóm");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Tên nhóm");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();


            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell13.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Group;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n2}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell16.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell19.Summary = summarytotal5;



            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell7.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell10.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;


            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Ghi chú");
        }

        public void BindDatahoadon(DataTable da)
        {

            DataSource = da;
            GroupHeader2.Visible = false;
            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Mã nhóm");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell4.DataBindings.Add("Text", DataSource, "Mã nhóm");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Tên nhóm");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Ghi chú","{0:dd/MM/yyyy}");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();


            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell13.Summary = summarytotal3;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell19.Summary = summarytotal5;



            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell7.Summary = summarytotal;


            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;


            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }


        public void BindDatamh(DataTable da)
        {

            DataSource = da;
            GroupHeader2.Visible = false;
            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Mã nhóm");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell4.DataBindings.Add("Text", DataSource, "Mã nhóm");
            xrTableCell5.DataBindings.Add("Text", DataSource, "Tên nhóm");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();


            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell13.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Group;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n2}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell16.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell27.Summary = summarytotal5;



            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell7.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell10.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell29.Summary = summarytotal1;


            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
        }

        public void BindDatahd(DataTable da)
        {
            xrTableCell25.Text = "Chiết khấu";
            DataSource = da;          

            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("Hóa đơn");
            GroupHeader1.GroupFields.Add(groupField);

            Bands.Add(GroupHeader2);
            GroupField groupField1 = new GroupField("Mã nhóm");
            GroupHeader2.GroupFields.Add(groupField1);

            xrTableCell20.DataBindings.Add("Text", DataSource, "Mã nhóm");
            xrTableCell21.DataBindings.Add("Text", DataSource, "Tên nhóm");

            xrTableCell5.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell27.DataBindings.Add("Text", DataSource, "Hạn nợ","{0:n0}");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Ngày HĐ", "{0:dd-MM-yyyy}");

            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
            XRSummary summarytotal2 = new XRSummary();
            XRSummary summarytotal3 = new XRSummary();
            XRSummary summarytotal4 = new XRSummary();
            XRSummary summarytotal5 = new XRSummary();
            XRSummary summarytotal6 = new XRSummary();
            XRSummary summarytotal7 = new XRSummary();
            XRSummary summarytotal8 = new XRSummary();

            XRSummary summarytotal9 = new XRSummary();
            XRSummary summarytotal10 = new XRSummary();
            XRSummary summarytotal11 = new XRSummary();


            summarytotal3.Running = SummaryRunning.Group;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell13.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell13.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Group;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n2}";
            xrTableCell16.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell16.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Group;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell19.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell19.Summary = summarytotal5;

            /*
            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell27.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell27.Summary = summarytotal9;
            */

            summarytotal6.Running = SummaryRunning.Group;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell22.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell22.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Group;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n2}";
            xrTableCell23.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell23.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell24.Summary = summarytotal8;

            /*
            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n0}";
            xrTableCell26.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell26.Summary = summarytotal10;
            */


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell7.Summary = summarytotal;

            summarytotal2.Running = SummaryRunning.Report;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell10.Summary = summarytotal2;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;

            /*
            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n0}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");
            xrTableCell29.Summary = summarytotal11;
            */

            xrTableCell1.DataBindings.Add("Text", DataSource, "Mã hàng");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell12.DataBindings.Add("Text", DataSource, "Số lượng quy đổi", "{0:n2}");
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số tiền", "{0:n0}");
            /*xrTableCell28.DataBindings.Add("Text", DataSource, "Hạn nợ", "{0:n0}");*/
        }
    }
}
