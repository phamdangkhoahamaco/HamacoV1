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
    public partial class rpbienbangiaonhanhanghoa : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbangiaonhanhanghoa()
        {
            InitializeComponent();
        }
        Frm_nhapxuat ThisF = new Frm_nhapxuat();
        gencon gen = new gencon();
        doiso doi = new doiso();
        string roleID, tsbtID, loaiID;
        public void gettieude(string phieu, string loai, string tsbt, Frm_nhapxuat F)
        {
            roleID = phieu;
            tsbtID = tsbt;
            ThisF = F;
            loaiID = loai;
            DataTable temp=new DataTable();
            if (tsbt == "pxhtbienban")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,Case when b.ContactName='' then b.ContactAddress else b.ContactName end,ContactTitle,IdentificationNumber,IssueDate,RefDate,ContactOfficeTel,c.FullName,c.JobTitle,c.HomePhone,c.MobilePhone,c.HomeAddress from OUTdeficit a, AccountingObject b, MSC_User c where a.AccountingObjectID=b.AccountingObjectID and a.EmployeeID=c.UserID and RefID='" + phieu + "'");
            else if (tsbt == "tsbthdmhkpnbienban")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,Case when b.ContactName='' then b.ContactAddress else b.ContactName end,ContactTitle,b.IdentificationNumber,b.IssueDate,PURefDate,ContactOfficeTel,c.FullName,c.JobTitle,c.HomePhone,c.MobilePhone,c.HomeAddress from PUInvoice a, AccountingObject b, MSC_User c where a.AccountingObjectID=b.AccountingObjectID and a.UserID=c.UserID and RefID='" + phieu + "'");
            else if (tsbt == "tsbthddhbienbanhp")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,Case when b.ContactName='' then b.ContactAddress else b.ContactName end,ContactTitle,b.IdentificationNumber,b.IssueDate,RefDate,ContactOfficeTel,c.FullName,c.JobTitle,c.HomePhone,c.MobilePhone,c.HomeAddress from DDHNCC a, AccountingObject b, MSC_User c where a.AccountingObjectID=b.AccountingObjectID and a.EmployeeID=c.UserID and RefID='" + phieu + "'");
            else if (tsbt == "tsbthdbhkpnbienban")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,Case when b.ContactName='' then b.ContactAddress else b.ContactName end,ContactTitle,b.IdentificationNumber,b.IssueDate,PURefDate,ContactOfficeTel,c.FullName,c.JobTitle,c.HomePhone,c.MobilePhone,c.HomeAddress from SSInvoice a, AccountingObject b, MSC_User c where a.AccountingObjectID=b.AccountingObjectID and a.UserID=c.UserID and RefID='" + phieu + "'");
            else if (tsbt == "tsbtpnkttbienban")
                temp = gen.GetTable("select RefNo,b.AccountingObjectName,Case when b.ContactName='' then b.ContactAddress else b.ContactName end,ContactTitle,IdentificationNumber,IssueDate,RefDate,ContactOfficeTel,c.FullName,c.JobTitle,c.HomePhone,c.MobilePhone,c.HomeAddress from INInwardTT a, AccountingObject b, MSC_User c where a.AccountingObjectID=b.AccountingObjectID and a.EmployeeID=c.UserID and RefID='" + phieu + "'");
            
            xrLabel5.Text = "Cần Thơ, ngày  " + String.Format("{0:dd}", DateTime.Parse(temp.Rows[0][6].ToString())) + " tháng " + String.Format("{0:MM}", DateTime.Parse(temp.Rows[0][6].ToString())) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(temp.Rows[0][6].ToString()));
            xrLabel7.Text = "Căn cứ theo hợp đồng thuê kho, quản lý, bốc xếp số: ";
            string tenkhach = temp.Rows[0][1].ToString();
            xrLabel10.Text = "Bên giao: " + tenkhach.ToUpper();
            xrLabel16.Text = temp.Rows[0][2].ToString();
            xrLabel19.Text = temp.Rows[0][3].ToString();
            if (temp.Rows[0][4].ToString() != "")
            {
                xrLabel14.Text = temp.Rows[0][4].ToString();
                xrLabel20.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][5].ToString()));
            }
            xrLabel15.Text = temp.Rows[0][7].ToString();

            xrLabel27.Text = temp.Rows[0][8].ToString();
            xrLabel30.Text = temp.Rows[0][9].ToString();
            xrLabel25.Text = temp.Rows[0][10].ToString();
            xrLabel26.Text = temp.Rows[0][11].ToString();
            xrLabel31.Text = temp.Rows[0][12].ToString();
            if (tsbt == "pxhtbienban")
                temp = gen.GetTable("select top 1 ContractCode,SignedDate  from OUTdeficit a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and ContractName=N'Cho thuê kho' and SignedDate<=RefDate and EffectiveDate>=RefDate and b.No=0 and RefID='" + phieu + "' order by b.SignedDate");
            else if (tsbt == "tsbthdmhkpnbienban")
                temp = gen.GetTable("select top 1 ContractCode,SignedDate  from PUInvoice a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and ContractName=N'Cho thuê kho' and SignedDate<=PURefDate and EffectiveDate>=PURefDate and b.No=0 and RefID='" + phieu + "' order by b.SignedDate");
            else if (tsbt == "tsbthddhbienbanhp")
                temp = gen.GetTable("select top 1 ContractCode,SignedDate  from DDHNCC a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and ContractName=N'Cho thuê kho' and SignedDate<=RefDate and EffectiveDate>=RefDate and b.No=0 and RefID='" + phieu + "' order by b.SignedDate");
            else if (tsbt == "tsbthdbhkpnbienban")
                temp = gen.GetTable("select top 1 ContractCode,SignedDate  from SSInvoice a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and ContractName=N'Cho thuê kho' and SignedDate<=PURefDate and EffectiveDate>=PURefDate and b.No=0 and RefID='" + phieu + "' order by b.SignedDate");
            else if (tsbt == "tsbtpnkttbienban")
                temp = gen.GetTable("select top 1 ContractCode,SignedDate  from INInwardTT a, ContractB b  where a.AccountingObjectID=b.AccountingObjectID and ContractName=N'Cho thuê kho' and SignedDate<=RefDate and EffectiveDate>=RefDate and b.No=0 and RefID='" + phieu + "' order by b.SignedDate");
            
            try { xrLabel7.Text = xrLabel7.Text + temp.Rows[0][0].ToString() + " ký ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][1].ToString())); }
            catch { }
            xrLabel7.Text = xrLabel7.Text + " giữa " + tenkhach+" và Công ty Cổ phần Vật tư Hậu Giang";

            if (loai == "0")
            {
                if (tsbt == "pxhtbienban")
                    temp = gen.GetTable("select sum(QuantityConvert) from OUTdeficitDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbthdmhkpnbienban")
                    temp = gen.GetTable("select sum(QuantityConvert) from PUInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbthddhbienbanhp")
                    temp = gen.GetTable("select sum(QuantityConvert) from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbthdbhkpnbienban")
                    temp = gen.GetTable("select sum(QuantityConvert) from SSInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbtpnkttbienban")
                    temp = gen.GetTable("select sum(QuantityConvert) from INInwardDetailTT a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                xrLabel35.Text = "Bằng chữ: " + doi.ChuyenSo(Math.Round(Double.Parse(temp.Rows[0][0].ToString()), 0).ToString()).Replace("đồng", "kg");
            }
            else
            {
                if (tsbt == "pxhtbienban")
                    temp = gen.GetTable("select sum(Quantity) from OUTdeficitDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbthdmhkpnbienban")
                    temp = gen.GetTable("select sum(Quantity) from PUInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbthddhbienbanhp")
                    temp = gen.GetTable("select sum(Quantity) from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbthdbhkpnbienban")
                    temp = gen.GetTable("select sum(Quantity) from SSInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                else if (tsbt == "tsbtpnkttbienban")
                    temp = gen.GetTable("select sum(Quantity) from INInwardDetailTT a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "'");
                xrLabel35.Text = "Bằng chữ: " + doi.ChuyenSo(Math.Round(Double.Parse(temp.Rows[0][0].ToString()), 0).ToString()).Replace("đồng", "cây");
            }
        }

        public void BindData(string phieu, string tsbt)
        {
            DataTable dt = new DataTable();           
            dt.Columns.Add("Tên hàng", Type.GetType("System.String"));
            dt.Columns.Add("Số lượng", Type.GetType("System.Double"));
            dt.Columns.Add("Trọng lượng", Type.GetType("System.Double"));
            dt.Columns.Add("STT", Type.GetType("System.Double"));
            DataTable temp = new DataTable();
            if (tsbt == "pxhtbienban")
                temp = gen.GetTable("select InventoryItemName, Quantity,QuantityConvert from OUTdeficitDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if(tsbt == "tsbthdmhkpnbienban")
                temp = gen.GetTable("select InventoryItemName, Quantity,QuantityConvert from PUInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbthddhbienbanhp")
                temp = gen.GetTable("select InventoryItemName, Quantity,QuantityConvert from DDHNCCDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbthdbhkpnbienban")
                temp = gen.GetTable("select InventoryItemName, Quantity,QuantityConvert from SSInvoiceDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            else if (tsbt == "tsbtpnkttbienban")
                temp = gen.GetTable("select InventoryItemName, Quantity,QuantityConvert from INInwardDetailTT a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + phieu + "' order by a.SortOrder");
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = temp.Rows[i][0];
                if (Double.Parse(temp.Rows[i][1].ToString()) != 0)
                    dr[1] = temp.Rows[i][1];
                if (Double.Parse(temp.Rows[i][2].ToString()) != 0)
                    dr[2] = temp.Rows[i][2];
                dr[3] = i + 1;
                dt.Rows.Add(dr);
            }

            DataSource = dt;
            XRSummary summarytotal = new XRSummary();
            XRSummary summarytotal1 = new XRSummary();


            summarytotal.Running = SummaryRunning.Report;
            summarytotal.IgnoreNullValues = true;
            summarytotal.FormatString = "{0:n2}";
            xrTableCell18.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
            xrTableCell18.Summary = summarytotal;

            summarytotal1.Running = SummaryRunning.Report;
            summarytotal1.IgnoreNullValues = true;
            summarytotal1.FormatString = "{0:n0}";
            xrTableCell11.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell11.Summary = summarytotal1;

            xrTableCell1.DataBindings.Add("Text", DataSource, "STT");
            xrTableCell2.DataBindings.Add("Text", DataSource, "Tên hàng");
            xrTableCell4.DataBindings.Add("Text", DataSource, "Số lượng", "{0:n0}");
            xrTableCell17.DataBindings.Add("Text", DataSource, "Trọng lượng", "{0:n2}");
        }

        private void xrLabel35_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            Frm_nhapxuat F = new Frm_nhapxuat();
            F.gettsbt(tsbtID);
            F.getrole(roleID);
            if (loaiID == "0")
                F.getkho("1");
            else
                F.getkho("0");
            F.ShowDialog();
            ThisF.Close();
        }
    }
}
