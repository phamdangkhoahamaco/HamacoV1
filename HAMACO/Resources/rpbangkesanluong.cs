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
    public partial class rpbangkesanluong : DevExpress.XtraReports.UI.XtraReport
    {
        gencon gen = new gencon();
        public rpbangkesanluong()
        {
            InitializeComponent();
        }
        public void gettieude(string ngaythang, string kho, string nhanvien)
        {
            xrLabel5.Text = "KHO " + gen.GetString("select StockCode+' - '+StockName from Stock where StockID='" + kho + "'").ToUpper();
            xrLabel2.Text = "BẢNG KÊ SẢN LƯỢNG VÀ ĐƠN GIÁ LƯƠNG THÁNG "+String.Format("{0:MM}", DateTime.Parse(ngaythang))+" NĂM "+String.Format("{0:yyyy}", DateTime.Parse(ngaythang));
            xrLabel3.Text = "Nhân viên: " + gen.GetString("select AccountingObjectCode+' - '+AccountingObjectName from AccountingObject where AccountingObjectID='"+nhanvien+"'");
            xrLabel6.Text = "In lúc: " + String.Format("{0: HH:mm:ss}", DateTime.Now) + " ngày: " + String.Format("{0: dd-MM-yyyy}", DateTime.Now);
            xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
            xrLabel4.Text = "Bảng kê sản lượng và đơn giá lương tháng " + String.Format("{0:MM}", DateTime.Parse(ngaythang)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaythang)) + " - " + gen.GetString("select AccountingObjectName+'('+AccountingObjectCode+')' from AccountingObject where AccountingObjectID='" + nhanvien + "'");

            DataTable temp = gen.GetTable("bangkesanluongbanhang '" + ngaythang + "','" + nhanvien + "','" + kho + "','2'");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count; j++)
                {

                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        if (i == 0)
                            xrTable5.Rows[i].Cells[j + 1].Text = String.Format("{0:n0}", Double.Parse(temp.Rows[i][j].ToString()));
                        else
                            xrTable5.Rows[i].Cells[j + 1].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][j].ToString())) + "%";
                    else
                        xrTable5.Rows[i].Cells[j + 1].Text = "";
                }
            }

            temp = gen.GetTable("select top 1 HP,VKS,VAS,CN,TKhac,NS,Fico,XMKhac,Sand,Stone,Bricks from SalaryDG where DateLine<='" + ngaythang + "' and EmployeeID='" + nhanvien + "' and General=1 order by DateLine DESC");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count; j++)
                {

                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                            xrTable9.Rows[i].Cells[j + 1].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable9.Rows[i].Cells[j + 1].Text = "";
                }
            }

            temp = gen.GetTable("select HP,VKS,VAS,CN,TKhac,NS,Fico,XMKhac,Sand,Stone,Bricks from SalaryDG where MONTH('" + ngaythang + "')=MONTH(DateLine) and YEAR('" + ngaythang + "')=YEAR(DateLine) and EmployeeID='" + nhanvien + "' and General=0");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                for (int j = 0; j < temp.Columns.Count; j++)
                {

                    if (Double.Parse(temp.Rows[i][j].ToString()) != 0)
                        xrTable9.Rows[i+1].Cells[j + 1].Text = String.Format("{0:n2}", Double.Parse(temp.Rows[i][j].ToString()));
                    else
                        xrTable9.Rows[i+1].Cells[j + 1].Text = "";
                }
            }
            
        }

        public void BindData(DataTable da)
        {
            DataSource = da;

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

            
            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n0}";
            xrTableCell31.DataBindings.Add("Text", DataSource, "Thép", "{0:n0}");
            xrTableCell31.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell32.DataBindings.Add("Text", DataSource, "Xi măng", "{0:n0}");
            xrTableCell32.Summary = summarytotal1;

            summarytotal3.Running = SummaryRunning.Report;
            summarytotal3.IgnoreNullValues = true;
            summarytotal3.FormatString = "{0:n0}";
            xrTableCell33.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell33.Summary = summarytotal3;

            summarytotal4.Running = SummaryRunning.Report;
            summarytotal4.IgnoreNullValues = true;
            summarytotal4.FormatString = "{0:n0}";
            xrTableCell34.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell34.Summary = summarytotal4;

            summarytotal5.Running = SummaryRunning.Report;
            summarytotal5.IgnoreNullValues = true;
            summarytotal5.FormatString = "{0:n0}";
            xrTableCell35.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
            xrTableCell35.Summary = summarytotal5;

           
            xrTableCell7.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell8.DataBindings.Add("Text", DataSource, "Mã khách");
            xrTableCell13.DataBindings.Add("Text", DataSource, "Tên khách");
            xrTableCell14.DataBindings.Add("Text", DataSource, "Thép", "{0:n0}");
            xrTableCell15.DataBindings.Add("Text", DataSource, "Xi măng", "{0:n0}");
            xrTableCell16.DataBindings.Add("Text", DataSource, "Cát", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Đá", "{0:n0}");
            xrTableCell18.DataBindings.Add("Text", DataSource, "Gạch", "{0:n0}");
        }

    }
}
