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
    public partial class rpbaocaotonkhothucte : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbaocaotonkhothucte()
        {
            InitializeComponent();
        }
        string tungay, denngay, tsbt,kho;
        DataTable data = new DataTable();
        gencon gen = new gencon();
        public void gettieude(string a, string b,string tungay1,string denngay1,string tsbt1,string kho1)
        {
            tungay = tungay1;
            denngay = denngay1;
            kho = kho1;
            tsbt = tsbt1;
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel2.Text = a;
            xrLabel5.Text = b;
            xrLabel4.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            if (gen.GetString("select CompanyTaxCode from Center") == "" && b == "")
                xrLabel2.Text = xrLabel2.Text.Replace("HÀNG HÓA THỰC TẾ", "HÀNG GỬI");
        }

        public void BindData(DataTable da)
        {
            DataSource = da;
            data = da;
            Bands.Add(GroupHeader1);
            GroupField groupField = new GroupField("nhomhang");

            GroupHeader1.GroupFields.Add(groupField);
            xrTableCell39.DataBindings.Add("Text", DataSource, "tennhom");

            xrTableCell43.DataBindings.Add("Text", DataSource, "slbbdau", "{0:n0}");
            XRSummary summary3 = new XRSummary();
            summary3.Running = SummaryRunning.Group;
            summary3.IgnoreNullValues = true;
            summary3.FormatString = "{0:n0}";
            xrTableCell43.Summary = summary3;

            xrTableCell44.DataBindings.Add("Text", DataSource, "sldau", "{0:n2}");
            XRSummary summary4 = new XRSummary();
            summary4.Running = SummaryRunning.Group;
            summary4.IgnoreNullValues = true;
            summary4.FormatString = "{0:n2}";
            xrTableCell44.Summary = summary4;

            xrTableCell45.DataBindings.Add("Text", DataSource, "slbbnhap", "{0:n0}");
            XRSummary summary5 = new XRSummary();
            summary5.Running = SummaryRunning.Group;
            summary5.IgnoreNullValues = true;
            summary5.FormatString = "{0:n0}";
            xrTableCell45.Summary = summary5;

            xrTableCell46.DataBindings.Add("Text", DataSource, "slnhap", "{0:n2}");
            XRSummary summary6 = new XRSummary();
            summary6.Running = SummaryRunning.Group;
            summary6.IgnoreNullValues = true;
            summary6.FormatString = "{0:n2}";
            xrTableCell46.Summary = summary6;

            xrTableCell47.DataBindings.Add("Text", DataSource, "slbbchuyen", "{0:n0}");
            XRSummary summary7 = new XRSummary();
            summary7.Running = SummaryRunning.Group;
            summary7.IgnoreNullValues = true;
            summary7.FormatString = "{0:n0}";
            xrTableCell47.Summary = summary7;

            xrTableCell48.DataBindings.Add("Text", DataSource, "slchuyen", "{0:n2}");
            XRSummary summary8 = new XRSummary();
            summary8.Running = SummaryRunning.Group;
            summary8.IgnoreNullValues = true;
            summary8.FormatString = "{0:n2}";
            xrTableCell48.Summary = summary8;

            xrTableCell49.DataBindings.Add("Text", DataSource, "slbbxuatchuyen", "{0:n0}");
            XRSummary summary9 = new XRSummary();
            summary9.Running = SummaryRunning.Group;
            summary9.IgnoreNullValues = true;
            summary9.FormatString = "{0:n0}";
            xrTableCell49.Summary = summary9;

            xrTableCell50.DataBindings.Add("Text", DataSource, "slxuatchuyen", "{0:n2}");
            XRSummary summary10 = new XRSummary();
            summary10.Running = SummaryRunning.Group;
            summary10.IgnoreNullValues = true;
            summary10.FormatString = "{0:n2}";
            xrTableCell50.Summary = summary10;

            xrTableCell51.DataBindings.Add("Text", DataSource, "slbbxuat", "{0:n0}");
            XRSummary summary11 = new XRSummary();
            summary11.Running = SummaryRunning.Group;
            summary11.IgnoreNullValues = true;
            summary11.FormatString = "{0:n0}";
            xrTableCell51.Summary = summary11;

            xrTableCell52.DataBindings.Add("Text", DataSource, "slxuat", "{0:n2}");
            XRSummary summary12 = new XRSummary();
            summary12.Running = SummaryRunning.Group;
            summary12.IgnoreNullValues = true;
            summary12.FormatString = "{0:n2}";
            xrTableCell52.Summary = summary12;

            xrTableCell53.DataBindings.Add("Text", DataSource, "slbbton", "{0:n0}");
            XRSummary summary13 = new XRSummary();
            summary13.Running = SummaryRunning.Group;
            summary13.IgnoreNullValues = true;
            summary13.FormatString = "{0:n0}";
            xrTableCell53.Summary = summary13;

            xrTableCell23.DataBindings.Add("Text", DataSource, "slton", "{0:n2}");
            XRSummary summary14 = new XRSummary();
            summary14.Running = SummaryRunning.Group;
            summary14.IgnoreNullValues = true;
            summary14.FormatString = "{0:n2}";
            xrTableCell23.Summary = summary14;


            /*xrTableCell83.DataBindings.Add("Text", DataSource, "slbbkmtd", "{0:n0}");
            XRSummary summary15 = new XRSummary();
            summary15.Running = SummaryRunning.Group;
            summary15.IgnoreNullValues = true;
            summary15.FormatString = "{0:n0}";
            xrTableCell83.Summary = summary15;

            xrTableCell63.DataBindings.Add("Text", DataSource, "slkmtd", "{0:n2}");
            XRSummary summary16 = new XRSummary();
            summary16.Running = SummaryRunning.Group;
            summary16.IgnoreNullValues = true;
            summary16.FormatString = "{0:n2}";
            xrTableCell63.Summary = summary16;

            xrTableCell84.DataBindings.Add("Text", DataSource, "slbbnhapkm", "{0:n0}");
            XRSummary summary17 = new XRSummary();
            summary17.Running = SummaryRunning.Group;
            summary17.IgnoreNullValues = true;
            summary17.FormatString = "{0:n0}";
            xrTableCell84.Summary = summary17;

            xrTableCell64.DataBindings.Add("Text", DataSource, "slnhapkm", "{0:n2}");
            XRSummary summary18 = new XRSummary();
            summary18.Running = SummaryRunning.Group;
            summary18.IgnoreNullValues = true;
            summary18.FormatString = "{0:n2}";
            xrTableCell64.Summary = summary18;

            xrTableCell85.DataBindings.Add("Text", DataSource, "slbbxuatkm", "{0:n0}");
            XRSummary summary19 = new XRSummary();
            summary19.Running = SummaryRunning.Group;
            summary19.IgnoreNullValues = true;
            summary19.FormatString = "{0:n0}";
            xrTableCell85.Summary = summary19;

            xrTableCell65.DataBindings.Add("Text", DataSource, "slxuatkm", "{0:n2}");
            XRSummary summary20 = new XRSummary();
            summary20.Running = SummaryRunning.Group;
            summary20.IgnoreNullValues = true;
            summary20.FormatString = "{0:n2}";
            xrTableCell65.Summary = summary20;

            xrTableCell86.DataBindings.Add("Text", DataSource, "slbbtonkm", "{0:n0}");
            XRSummary summary21 = new XRSummary();
            summary21.Running = SummaryRunning.Group;
            summary21.IgnoreNullValues = true;
            summary21.FormatString = "{0:n0}";
            xrTableCell86.Summary = summary21;

            xrTableCell66.DataBindings.Add("Text", DataSource, "sltonkm", "{0:n2}");
            XRSummary summary22 = new XRSummary();
            summary22.Running = SummaryRunning.Group;
            summary22.IgnoreNullValues = true;
            summary22.FormatString = "{0:n2}";
            xrTableCell66.Summary = summary22;*/




            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();
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

            XRSummary summarytotal16 = new XRSummary();
            XRSummary summarytotal17 = new XRSummary();
            XRSummary summarytotal18 = new XRSummary();
            XRSummary summarytotal19 = new XRSummary();
            XRSummary summarytotal20 = new XRSummary();
            XRSummary summarytotal21 = new XRSummary();
            XRSummary summarytotal22 = new XRSummary();
            XRSummary summarytotal23 = new XRSummary();

            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "slbbdau", "{0:n0}");
            xrTableCell35.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n2}";
            xrTableCell36.DataBindings.Add("Text", DataSource, "sldau", "{0:n2}");
            xrTableCell36.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell37.DataBindings.Add("Text", DataSource, "slbbnhap", "{0:n0}");
            xrTableCell37.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n2}";
            xrTableCell38.DataBindings.Add("Text", DataSource, "slnhap", "{0:n2}");
            xrTableCell38.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell40.DataBindings.Add("Text", DataSource, "slbbchuyen", "{0:n0}");
            xrTableCell40.Summary = summarytotal5;

            summarytotal6.Running = SummaryRunning.Report;
            summarytotal6.IgnoreNullValues = true;
            summarytotal6.FormatString = "{0:n2}";
            xrTableCell41.DataBindings.Add("Text", DataSource, "slchuyen", "{0:n2}");
            xrTableCell41.Summary = summarytotal6;

            summarytotal7.Running = SummaryRunning.Report;
            summarytotal7.IgnoreNullValues = true;
            summarytotal7.FormatString = "{0:n0}";
            xrTableCell42.DataBindings.Add("Text", DataSource, "slbbxuatchuyen", "{0:n0}");
            xrTableCell42.Summary = summarytotal7;

            summarytotal8.Running = SummaryRunning.Report;
            summarytotal8.IgnoreNullValues = true;
            summarytotal8.FormatString = "{0:n2}";
            xrTableCell54.DataBindings.Add("Text", DataSource, "slxuatchuyen", "{0:n2}");
            xrTableCell54.Summary = summarytotal8;

            summarytotal9.Running = SummaryRunning.Report;
            summarytotal9.IgnoreNullValues = true;
            summarytotal9.FormatString = "{0:n0}";
            xrTableCell55.DataBindings.Add("Text", DataSource, "slbbxuat", "{0:n0}");
            xrTableCell55.Summary = summarytotal9;



            summarytotal11.Running = SummaryRunning.Report;
            summarytotal11.IgnoreNullValues = true;
            summarytotal11.FormatString = "{0:n2}";
            xrTableCell56.DataBindings.Add("Text", DataSource, "slxuat", "{0:n2}");
            xrTableCell56.Summary = summarytotal11;

            summarytotal12.Running = SummaryRunning.Report;
            summarytotal12.IgnoreNullValues = true;
            summarytotal12.FormatString = "{0:n0}";
            xrTableCell57.DataBindings.Add("Text", DataSource, "slbbton", "{0:n0}");
            xrTableCell57.Summary = summarytotal12;

            summarytotal13.Running = SummaryRunning.Report;
            summarytotal13.IgnoreNullValues = true;
            summarytotal13.FormatString = "{0:n2}";
            xrTableCell58.DataBindings.Add("Text", DataSource, "slton", "{0:n2}");
            xrTableCell58.Summary = summarytotal13;


            /*summarytotal16.Running = SummaryRunning.Report;
            summarytotal16.IgnoreNullValues = true;
            summarytotal16.FormatString = "{0:n0}";
            xrTableCell91.DataBindings.Add("Text", DataSource, "slbbkmtd", "{0:n0}");
            xrTableCell91.Summary = summarytotal16;

            summarytotal17.Running = SummaryRunning.Report;
            summarytotal17.IgnoreNullValues = true;
            summarytotal17.FormatString = "{0:n2}";
            xrTableCell71.DataBindings.Add("Text", DataSource, "slkmtd", "{0:n2}");
            xrTableCell71.Summary = summarytotal17;

            summarytotal18.Running = SummaryRunning.Report;
            summarytotal18.IgnoreNullValues = true;
            summarytotal18.FormatString = "{0:n0}";
            xrTableCell92.DataBindings.Add("Text", DataSource, "slbbnhapkm", "{0:n0}");
            xrTableCell92.Summary = summarytotal18;

            summarytotal19.Running = SummaryRunning.Report;
            summarytotal19.IgnoreNullValues = true;
            summarytotal19.FormatString = "{0:n2}";
            xrTableCell72.DataBindings.Add("Text", DataSource, "slnhapkm", "{0:n2}");
            xrTableCell72.Summary = summarytotal19;

            summarytotal20.Running = SummaryRunning.Report;
            summarytotal20.IgnoreNullValues = true;
            summarytotal20.FormatString = "{0:n0}";
            xrTableCell93.DataBindings.Add("Text", DataSource, "slbbxuatkm", "{0:n0}");
            xrTableCell93.Summary = summarytotal20;

            summarytotal21.Running = SummaryRunning.Report;
            summarytotal21.IgnoreNullValues = true;
            summarytotal21.FormatString = "{0:n2}";
            xrTableCell73.DataBindings.Add("Text", DataSource, "slxuatkm", "{0:n2}");
            xrTableCell73.Summary = summarytotal21;

            summarytotal22.Running = SummaryRunning.Report;
            summarytotal22.IgnoreNullValues = true;
            summarytotal22.FormatString = "{0:n0}";
            xrTableCell94.DataBindings.Add("Text", DataSource, "slbbtonkm", "{0:n0}");
            xrTableCell94.Summary = summarytotal22;

            summarytotal23.Running = SummaryRunning.Report;
            summarytotal23.IgnoreNullValues = true;
            summarytotal23.FormatString = "{0:n2}";
            xrTableCell74.DataBindings.Add("Text", DataSource, "sltonkm", "{0:n2}");
            xrTableCell74.Summary = summarytotal23;*/
            

            xrTableCell2.DataBindings.Add("Text", DataSource, "tenhang");
            xrTableCell14.DataBindings.Add("Text", DataSource, "slbbdau", "{0:n0}");
            xrTableCell22.DataBindings.Add("Text", DataSource, "sldau", "{0:n2}");
            xrTableCell24.DataBindings.Add("Text", DataSource, "slbbnhap", "{0:n0}");
            xrTableCell25.DataBindings.Add("Text", DataSource, "slnhap", "{0:n2}");
            xrTableCell26.DataBindings.Add("Text", DataSource, "slbbchuyen", "{0:n0}");
            xrTableCell27.DataBindings.Add("Text", DataSource, "slchuyen", "{0:n2}");
            xrTableCell28.DataBindings.Add("Text", DataSource, "slbbxuatchuyen", "{0:n0}");
            xrTableCell29.DataBindings.Add("Text", DataSource, "slxuatchuyen", "{0:n2}");
            xrTableCell30.DataBindings.Add("Text", DataSource, "slbbxuat","{0:n0}");
            xrTableCell31.DataBindings.Add("Text", DataSource, "slxuat", "{0:n2}");
            xrTableCell32.DataBindings.Add("Text", DataSource, "slbbton", "{0:n0}");
            xrTableCell33.DataBindings.Add("Text", DataSource, "slton", "{0:n2}");
            xrTableCell60.DataBindings.Add("Text", DataSource, "mahang");

            /*xrTableCell87.DataBindings.Add("Text", DataSource, "slbbkmtd", "{0:0,0}");
            xrTableCell67.DataBindings.Add("Text", DataSource, "slkmtd", "{0:0,0.00}");
            xrTableCell88.DataBindings.Add("Text", DataSource, "slbbnhapkm", "{0:0,0}");
            xrTableCell68.DataBindings.Add("Text", DataSource, "slnhapkm", "{0:0,0.00}");
            xrTableCell89.DataBindings.Add("Text", DataSource, "slbbxuatkm", "{0:0,0}");
            xrTableCell69.DataBindings.Add("Text", DataSource, "slxuatkm", "{0:0,0.00}");
            xrTableCell90.DataBindings.Add("Text", DataSource, "slbbtonkm", "{0:0,0}");
            xrTableCell70.DataBindings.Add("Text", DataSource, "sltonkm", "{0:0,0.00}");*/
        }

        private void xrTableCell60_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            if (tsbt == "tsbtbctktttndntpxk" || tsbt == "tsbtbctktttndntaidv")
            {
                baocaotonkhovo bctk = new baocaotonkhovo();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i][15].ToString() == e.Brick.Text)
                    {
                        bctk.inthekhotndn(tungay, denngay, tsbt, kho, data.Rows[i][24].ToString(), data.Rows[i][1].ToString(), data.Rows[i][2].ToString(), data.Rows[i][13].ToString());
                        return;
                    }
                }
            }
            else if (tsbt == "bchgkh")
            {
                baocaotonkhovo bctk = new baocaotonkhovo();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (data.Rows[i][15].ToString() == e.Brick.Text)
                    {
                        bctk.inthekhotndn(tungay, denngay, tsbt, kho, data.Rows[i][24].ToString(), data.Rows[i][1].ToString(), data.Rows[i][2].ToString(), xrLabel5.Text.Substring(0,8));
                        return;
                    }
                }
            }
        }
    }
}
