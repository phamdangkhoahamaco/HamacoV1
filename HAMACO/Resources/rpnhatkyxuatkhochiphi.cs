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
    public partial class rpnhatkyxuatkhochiphi : DevExpress.XtraReports.UI.XtraReport
    {
        public rpnhatkyxuatkhochiphi()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude(string tungay, string denngay, string kho, string phieu,string khonhap)
        {
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");

            if (phieu == "BẢNG KÊ BÁN HÀNG THEO TÀI XẾ" || phieu == "BẢNG KÊ BÁN HÀNG THEO GIAO NHẬN")
                GroupHeader2.Visible = false;

            xrLabel2.Text = phieu;
            try
            {
                xrLabel3.Text = xrLabel6.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            }
            catch { xrLabel3.Text = kho; }
            xrLabel5.Text = "Từ ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(tungay)) + " đến ngày " + String.Format("{0: dd-MM-yyyy}", DateTime.Parse(denngay));
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0:dd-MM-yyyy}", DateTime.Now);

            if (phieu == "BẢNG KÊ PHIẾU XUẤT BÁN HÀNG TRẢ TIỀN MẶT")
                xrTable6.Visible = false;
            else if (phieu == "BẢNG KÊ CHI PHÍ BỐC XẾP BÁN HÀNG" && gen.GetString("select CompanyTaxCode from Center") == "")
                xrLabel2.Text = "BẢNG KÊ CHI PHÍ BỐC XẾP XUẤT KHO";
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            Bands.Add(GroupHeader2);
            GroupField groupField = new GroupField("Ngày lập");
            GroupHeader2.GroupFields.Add(groupField);

            xrTableCell14.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell1.DataBindings.Add("Text", DataSource, "Phương tiện");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Nơi giao");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tên khách");

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
            XRSummary summarytotal12 = new XRSummary();

            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();


            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell3.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell4.Summary = summarytotal10;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell7.Summary = summarytotal12;


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell28.Summary = summarytotal;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell29.Summary = summarytotal5;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell33.Summary = summarytotal3;



            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell36.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell39.Summary = summarytotal2;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell53.Summary = summarytotal8;


            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thép", "{0:n0}");
            xrTableCell10.Summary = summarytotal4;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Xi măng", "{0:n0}");
            xrTableCell11.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell12.Summary = summarytotal7;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell24.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell31.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell15.DataBindings.Add("Text", DataSource, "Khác", "{0:n0}");
            xrTableCell15.Summary = summarytotal15;


            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn vị tính");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
        }


        public void BindDatanoibo(DataTable da)
        {
            DataSource = da;
            this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            Bands.Add(GroupHeader2);
            GroupField groupField = new GroupField("Tên khách");
            GroupHeader2.GroupFields.Add(groupField);

            xrTableCell13.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Tên khách");

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
            XRSummary summarytotal12 = new XRSummary();

            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();


            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell3.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell4.Summary = summarytotal10;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell7.Summary = summarytotal12;





            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell28.Summary = summarytotal;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell29.Summary = summarytotal5;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell33.Summary = summarytotal3;



            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell36.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell39.Summary = summarytotal2;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell53.Summary = summarytotal8;


            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thép", "{0:n0}");
            xrTableCell10.Summary = summarytotal4;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Xi măng", "{0:n0}");
            xrTableCell11.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell12.Summary = summarytotal7;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell24.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell31.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell15.DataBindings.Add("Text", DataSource, "Khác", "{0:n0}");
            xrTableCell15.Summary = summarytotal15;


            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn vị tính");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
        }


        public void BindDatath(DataTable da)
        {
            DataSource = da;

            Bands.Add(GroupHeader1);
            GroupField groupField1 = new GroupField("Phiếu");
            GroupHeader1.GroupFields.Add(groupField1);

            Bands.Add(GroupHeader2);
            GroupField groupField = new GroupField("Phương tiện");
            GroupHeader2.GroupFields.Add(groupField);

            xrTableCell1.DataBindings.Add("Text", DataSource, "Ngày lập", "{0:dd-MM-yyyy}");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Hóa đơn");
            xrTableCell6.DataBindings.Add("Text", DataSource, "Phiếu");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Phương tiện");
            xrTableCell9.DataBindings.Add("Text", DataSource, "Nơi giao");
            xrTableCell32.DataBindings.Add("Text", DataSource, "Tên khách");

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
            XRSummary summarytotal12 = new XRSummary();

            XRSummary summarytotal13 = new XRSummary();
            XRSummary summarytotal14 = new XRSummary();
            XRSummary summarytotal15 = new XRSummary();


            summarytotal9.Running = SummaryRunning.Group;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell3.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell3.Summary = summarytotal9;

            summarytotal10.Running = SummaryRunning.Group;
            summarytotal10.IgnoreNullValues = true;
            summarytotal10.FormatString = "{0:n2}";
            xrTableCell4.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell4.Summary = summarytotal10;

            summarytotal12.Running = SummaryRunning.Group;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell7.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell7.Summary = summarytotal12;





            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell28.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell28.Summary = summarytotal;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n2}";
            xrTableCell29.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell29.Summary = summarytotal5;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell33.Summary = summarytotal3;



            summarytotal1.Running = SummaryRunning.Group;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell36.Summary = summarytotal1;

            summarytotal2.Running = SummaryRunning.Group;
            summarytotal2.IgnoreNullValues = true;
            summarytotal2.FormatString = "{0:n2}";
            xrTableCell39.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell39.Summary = summarytotal2;

            summarytotal8.Running = SummaryRunning.Group;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n0}";
            xrTableCell53.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
            xrTableCell53.Summary = summarytotal8;


            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell10.DataBindings.Add("Text", DataSource, "Thép", "{0:n0}");
            xrTableCell10.Summary = summarytotal4;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Xi măng", "{0:n0}");
            xrTableCell11.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell12.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell12.Summary = summarytotal7;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n0}";
            xrTableCell24.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell24.Summary = summarytotal13;

            summarytotal14.Running = SummaryRunning.Report;
            summarytotal14.IgnoreNullValues = true;
            summarytotal14.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell31.Summary = summarytotal14;

            summarytotal15.Running = SummaryRunning.Report;
            summarytotal15.IgnoreNullValues = true;
            summarytotal15.FormatString = "{0:n0}";
            xrTableCell15.DataBindings.Add("Text", DataSource, "Khác", "{0:n0}");
            xrTableCell15.Summary = summarytotal15;


            xrTableCell43.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đơn vị tính");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell19.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell20.DataBindings.Add("Text", DataSource, "Đơn giá", "{0:n2}");
            xrTableCell41.DataBindings.Add("Text", DataSource, "Có thuế", "{0:n0}");
        }


    }
}
