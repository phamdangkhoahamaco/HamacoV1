using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;

namespace HAMACO
{
    public partial class Frm_import : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        Form1 F;
        string ngaychungtu,userid;

        DataTable khach = new DataTable();
        DataTable hang = new DataTable();
        DataTable khachuni = new DataTable();

        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }

        public Form getform(Form1 a)
        {
            F = a;
            return F;
        }
        public string getngay(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public Frm_import()
        {
            InitializeComponent();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            view.ShowFindPanel();
        }

       
        private void batai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog F = new OpenFileDialog();
            F.ShowDialog();
            string name = F.FileName;
            if (name != "")
            {
                String sheet = "Sheet";
                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + name + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + sheet + "$]", con);
                try
                {
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    con.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    view.Columns.Clear();
                    lvpq.DataSource = data;
                    view.Columns[0].Width = 100;
                    view.BestFitColumns();
                    view.Columns[0].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    view.Columns[0].SummaryItem.DisplayFormat = "Số dòng:   {0}";
                    con.Close();
                    con.Dispose();
                    SplashScreenManager.CloseForm();
                }
                catch
                {
                    if (name != "")
                        XtraMessageBox.Show("File " + name + " không đúng định dạng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                    con.Dispose();
                    SplashScreenManager.CloseForm();
                }
            }
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật thông tin khách hàng ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string ma = view.GetRowCellValue(i, "Mã khách").ToString();
                    string ten=view.GetRowCellValue(i, "Tên đại diện").ToString().Replace("'","''");
                    if (ten == "")
                        ten = view.GetRowCellValue(i, "Tên khách").ToString().Replace("'","''");
                    string mst = view.GetRowCellValue(i, "Mã số thuế").ToString();
                    string diachi = view.GetRowCellValue(i, "Địa chỉ").ToString().Replace("'", "''");
                    string cmnd = view.GetRowCellValue(i, "CMND").ToString();
                    string maphu = view.GetRowCellValue(i, "Mã phụ").ToString();
                    string sql;
                    string nv = "False";
                    if (view.GetRowCellValue(i, "Loại").ToString() == "1")
                        nv = "True";
                    try
                    {
                        string id = gen.GetString("select * from AccountingObject where AccountingObjectCode='"+ma+"'");
                        sql = "update AccountingObject set AccountingObjectName=N'" + ten + "',Address=N'" + diachi + "',CompanyTaxCode='" + mst + "',IdentificationNumber='" + cmnd + "',Inactive='False',EmailAddress='" + maphu + "' where AccountingObjectCode='" + ma + "'";
                    }
                    catch
                    {
                        sql = "insert into AccountingObject(AccountingObjectID,AccountingObjectCode,AccountingObjectName,BranchID,Address,CompanyTaxCode,IdentificationNumber,IsPersonal,Inactive,IsVendor,IsCustomer,IsEmployee,EmailAddress)  values(newid(),'" + ma + "',N'" + ten + "','" + "D93A0F81-516C-41E8-A37F-14A0E27F581D" +
                            "',N'" + diachi + "','" + mst + "','" + cmnd + "','True','False','False','True','" + nv + "','" + maphu + "')";
                    }
                    gen.ExcuteNonquery(sql);
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật thông tin hàng hóa ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string ma = view.GetRowCellValue(i, "Mã hàng").ToString();
                    string ten = view.GetRowCellValue(i, "Tên hàng").ToString().Replace("'", "''");
                    string manhom = gen.GetString("select InventoryCategoryID from InventoryItemCategory where InventoryCategoryCode='" + ma.Substring(0, 3) + "'");
                    string dvt = view.GetRowCellValue(i, "Đơn vị tính").ToString();
                    string dvqd = view.GetRowCellValue(i, "Đơn vị quy đổi").ToString().Replace("'", "''");
                    string soluongqd = view.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(",",".");
                    string thue =  view.GetRowCellValue(i, "Thuế GTGT").ToString();
                    string nganhhang = view.GetRowCellValue(i, "NGÀNH HÀNG").ToString().ToString().Replace("'", "''");
                    string nhomhang = view.GetRowCellValue(i, "NHÓM HÀNG").ToString().ToString().Replace("'", "''");
                    string sql;
                    try
                    {
                        string id = gen.GetString("select * from InventoryItem where InventoryItemCode='" + ma + "'");
                        sql = "update InventoryItem set InventoryItemName=N'" + ten + "',Unit=N'" + dvt + "',ConvertUnit=N'" + dvqd + "',ConvertRate='" + soluongqd + "',TaxRate='" + thue + "',InventoryCategoryID='" + manhom + "',SaleDescription=N'" + nganhhang + "',PurchaseDescription=N'" + nhomhang + "'  where InventoryItemCode='" + ma + "'";
                    }
                    catch
                    {
                        sql = "insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + ma + "',N'" + ten + "',N'" + dvt + "',N'" + dvqd + "','" + soluongqd + "','" + thue + "','" + manhom + "','False',0,N'" + nganhhang + "',N'" + nhomhang + "')";
                    }
                    gen.ExcuteNonquery(sql);
                }
                SplashScreenManager.CloseForm();
                if (XtraMessageBox.Show("Dữ liệu đã được xử lý xong. Bạn có muốn trở về màn hình chính ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật lại hệ thống phiếu ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string sophieu, ngay, makhach=null, tenkhach, diachi, quyen,ngaythanhtoan,lydo,chungtugoc,makho,makhachtam,thue,tienthue,chiphi,loaihd,khhd,sohd,ngayhd,httt,mst,bancho,matinh,khoden,ptvc,makhophu,phieumoi;
                Double hanno = 0;

                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();

              
            gen.ExcuteNonquery("delete from INOutwardDetail where RefID in (select RefID from INOutward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from INInwardDetail where  RefID in (select RefID from INInward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from SUCAPaymentDetail where RefID in (select RefID from SUCAPayment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from SUBATransferDetail where RefID in (select RefID from SUBATransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from SUCAReceiptDetail where RefID in (select RefID from SUCAReceipt where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from SUBADepositDetail where RefID in (select RefID from SUBADeposit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from CAPaymentDetail where RefID in (select RefID from CAPayment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from BATransferDetail where RefID in (select RefID from BATransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from CAReceiptDetail where RefID in (select RefID from CAReceipt where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from BADepositDetail where RefID in (select RefID from BADeposit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from GLVoucherDetail where RefID in (select RefID from GLVoucher where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from INTransferDetail where RefID in (select RefID from INTransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from INTransferBranchDetail where RefID in (select RefID from INTransferBranch where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");

            gen.ExcuteNonquery("delete from INTransferSUDetail where RefID in (select RefID from INTransferSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from INInwardSUDetail where RefID in (select RefID from INInwardSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from INOutwardSUDetail where RefID in (select RefID from INOutwardSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");

            gen.ExcuteNonquery("delete from INAdjustmentDetail where RefID in (select RefID from INAdjustment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from OUTAdjustmentDetail where RefID in (select RefID from OUTAdjustment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from INSurplusDetail where RefID in (select RefID from INSurplus where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from OUTdeficitDetail where RefID in (select RefID from OUTdeficit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
            gen.ExcuteNonquery("delete from SSInvoiceBranchDetail where RefID in (select RefID from SSInvoiceBranch where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "')");
                
                
                gen.ExcuteNonquery("delete from INOutward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from INInward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from SUCAPayment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from SUBATransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from SUCAReceipt where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from SUBADeposit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from CAPayment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from BATransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from CAReceipt where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from BADeposit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from GLVoucher where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from INTransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from INTransferBranch where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");

                gen.ExcuteNonquery("delete from INTransferSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from INInwardSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from INOutwardSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");

                gen.ExcuteNonquery("delete from INAdjustment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from OUTAdjustment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from INSurplus where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from OUTdeficit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                gen.ExcuteNonquery("delete from SSInvoiceBranch where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "'");
                     
                

                /*gen.ExcuteNonquery("delete from INOutward");
                    gen.ExcuteNonquery("delete from INInward");
                    gen.ExcuteNonquery("delete from SUCAPayment");
                    gen.ExcuteNonquery("delete from SUBATransfer");
                    gen.ExcuteNonquery("delete from SUCAReceipt");
                    gen.ExcuteNonquery("delete from SUBADeposit");
                    gen.ExcuteNonquery("delete from CAPayment");
                    gen.ExcuteNonquery("delete from BATransfer");
                    gen.ExcuteNonquery("delete from CAReceipt");
                    gen.ExcuteNonquery("delete from BADeposit");
                    gen.ExcuteNonquery("delete from GLVoucher");
                    gen.ExcuteNonquery("delete from INTransfer");
                    gen.ExcuteNonquery("delete from INTransferBranch");

                    gen.ExcuteNonquery("delete from INTransferSU");
                    gen.ExcuteNonquery("delete from INInwardSU");
                    gen.ExcuteNonquery("delete from INOutwardSU");

                    gen.ExcuteNonquery("delete from INAdjustment");
                    gen.ExcuteNonquery("delete from OUTAdjustment");
                    gen.ExcuteNonquery("delete from INSurplus");
                    gen.ExcuteNonquery("delete from OUTdeficit");
                    gen.ExcuteNonquery("delete from SSInvoiceBranch");

                    gen.ExcuteNonquery("delete from INOutwardDetail");
                    gen.ExcuteNonquery("delete from INInwardDetail");
                    gen.ExcuteNonquery("delete from SUCAPaymentDetail");
                    gen.ExcuteNonquery("delete from SUBATransferDetail");
                    gen.ExcuteNonquery("delete from SUCAReceiptDetail");
                    gen.ExcuteNonquery("delete from SUBADepositDetail");
                    gen.ExcuteNonquery("delete from CAPaymentDetail");
                    gen.ExcuteNonquery("delete from BATransferDetail");
                    gen.ExcuteNonquery("delete from CAReceiptDetail");
                    gen.ExcuteNonquery("delete from BADepositDetail");
                    gen.ExcuteNonquery("delete from GLVoucherDetail");
                    gen.ExcuteNonquery("delete from INTransferDetail");
                    gen.ExcuteNonquery("delete from INTransferBranchDetail");

                    gen.ExcuteNonquery("delete from INTransferSUDetail");
                    gen.ExcuteNonquery("delete from INInwardSUDetail");
                    gen.ExcuteNonquery("delete from INOutwardSUDetail");

                    gen.ExcuteNonquery("delete from INAdjustmentDetail");
                    gen.ExcuteNonquery("delete from OUTAdjustmentDetail");
                    gen.ExcuteNonquery("delete from INSurplusDetail");
                    gen.ExcuteNonquery("delete from OUTdeficitDetail");
                    gen.ExcuteNonquery("delete from SSInvoiceBranchDetail");*/


                
                for (int i = 0; i < view.RowCount; i++)
                {
                    sophieu = view.GetRowCellValue(i, "Số phiếu").ToString();
                    ngay = view.GetRowCellValue(i, "Ngày lập").ToString();
                    try
                    {
                        makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + view.GetRowCellValue(i, "Mã khách").ToString() + "'");
                    }
                    catch 
                    {
                        makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='090'");
                    }
                    tenkhach = view.GetRowCellValue(i, "Tên khách hàng").ToString().Replace("'", "''");
                    diachi = view.GetRowCellValue(i, "Địa chỉ").ToString().Replace("'", "''");
                    quyen = view.GetRowCellValue(i, "Quyển").ToString();
                    ngaythanhtoan = view.GetRowCellValue(i, "Ngày thanh toán").ToString();
                    lydo = view.GetRowCellValue(i, "Lý do").ToString().Replace("'", "''");
                    chungtugoc = view.GetRowCellValue(i, "Chứng từ gốc").ToString().Replace("'", "''");
                    makho = view.GetRowCellValue(i, "Mã kho").ToString();
                    try
                    {
                        makhachtam = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + view.GetRowCellValue(i, "Mã khách tạm").ToString() + "'");
                    }
                    catch { makhachtam = "";}
                    thue = view.GetRowCellValue(i, "Thuế").ToString();
                    tienthue = view.GetRowCellValue(i, "Tiền thuế").ToString();
                    chiphi = view.GetRowCellValue(i, "Chi phí").ToString();
                    loaihd = view.GetRowCellValue(i, "Loại HĐ").ToString();
                    khhd = view.GetRowCellValue(i, "KHHĐ").ToString();
                    sohd = view.GetRowCellValue(i, "Số HĐ").ToString();
                    try
                    {
                        ngayhd = DateTime.Parse(view.GetRowCellValue(i, "Ngày HĐ").ToString()).ToString();
                    }
                    catch
                    {
                        ngayhd = ngay;
                    }
                    httt = view.GetRowCellValue(i, "HTTT").ToString();
                    mst = view.GetRowCellValue(i, "Mã số thuế").ToString();
                    bancho = view.GetRowCellValue(i, "Bán cho").ToString();
                    matinh = view.GetRowCellValue(i, "Mã tỉnh").ToString();
                    khoden = view.GetRowCellValue(i, "Đến kho").ToString();
                    ptvc = view.GetRowCellValue(i, "PTVC").ToString().Replace("'", "''");
                    makhophu = view.GetRowCellValue(i, "Mã kho phụ").ToString();
                    DataTable dt = new DataTable();
                    dt = gen.GetTable("select a.StockID,a.BranchID,BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and StockCode='"+makho+"'");
                    string idkho = dt.Rows[0][0].ToString();
                    string iddonvi = dt.Rows[0][1].ToString();
                    string donvi = dt.Rows[0][2].ToString();
                    try
                    {
                        TimeSpan Time = DateTime.Parse(ngaythanhtoan) - DateTime.Parse(ngayhd);
                        hanno = Time.Days;
                    }
                    catch { }

                    if (sophieu.Substring(0, 3) == "BDN" || sophieu.Substring(0, 3) == "BXD" || sophieu.Substring(0, 3) == "XHH")
                    {
                        phieumoi=donvi+"-"+makho+"-"+sophieu.Replace(sophieu.Substring(0, 4), "PXKH");
                        gen.ExcuteNonquery("insert into INOutward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,EmployeeID,StockID,Posted,AccountingObjectType,DocumentIncluded,ShippingNo,Tax,CustomField5,TotalAmountOC,CustomField4,CustomField3,CustomField2,CustomField1,CustomField6,CustomField7,CustomField8,CustomField9) values(newid(),'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + idkho + "','False',0,N'" + chungtugoc + "',N'" + ptvc + "','" + thue + "','" + sophieu + "','" + tienthue + "','" + loaihd + "','" + khhd + "','" + sohd + "','" + ngayhd + "','" + httt + "','" + hanno + "','" + bancho + "','"+quyen+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "NHH" || sophieu.Substring(0, 3) == "NXD")
                    {
                        try
                        {
                            string idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                            makho = makhophu;
                            idkho = idmakhophu;
                        }
                        catch
                        {}
                        phieumoi = donvi + "-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PNKH");
                        gen.ExcuteNonquery("insert into INInward(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,EmployeeID,StockID,Posted,AccountingObjectType,DocumentIncluded,ShippingNo,CustomField4,TotalAmountOC,CustomField5,CustomField3,CustomField2,CustomField1,CustomField6,CustomField7,CustomField8,CustomField9,CustomField10) values(newid(),'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + idkho + "','False',0,N'" + chungtugoc + "',N'" + ptvc + "','" + thue + "','" + tienthue + "','" + sophieu + "','" + makhachtam + "','" + loaihd + "','" + khhd + "','" + sohd + "','" + ngayhd + "','" + httt + "'," + hanno + ",'"+chiphi+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "CCN")
                    {
                        phieumoi = "08-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PCVT");
                        gen.ExcuteNonquery("insert into SUCAPayment(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,EmployeeID,StockID,Posted,AccountingObjectType,DocumentIncluded,Tax,InvDate,InvSeries,InvNo,TotalAmount,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + idkho + "','False',0,N'" + chungtugoc + "','" + thue + "','"+ngayhd+"','"+khhd+"','"+sohd+"',0,'"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "CHN")
                    {
                        phieumoi = "08-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "CTVT");
                        gen.ExcuteNonquery("insert into SUBATransfer(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,EmployeeID,StockID,Posted,AccountingObjectType,DocumentIncluded,Tax,InvDate,InvSeries,InvNo,TotalAmount,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + idkho + "','False',0,N'" + chungtugoc + "','" + thue + "','" + ngayhd + "','" + khhd + "','" + sohd + "',0,'"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "TCN")
                    {
                        phieumoi = "08-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PTVT");
                        gen.ExcuteNonquery("insert into SUCAReceipt(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,EmployeeID,StockID,Posted,AccountingObjectType,DocumentIncluded,Tax,InvDate,InvSeries,InvNo,TotalAmount,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + idkho + "','False',0,N'" + chungtugoc + "','" + thue + "','" + ngayhd + "','" + khhd + "','" + sohd + "',0,'"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "THN")
                    {
                        phieumoi = "08-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "NTVT");
                        gen.ExcuteNonquery("insert into SUBADeposit(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,EmployeeID,StockID,Posted,AccountingObjectType,DocumentIncluded,Tax,InvDate,InvSeries,InvNo,TotalAmount,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + idkho + "','False',0,N'" + chungtugoc + "','" + thue + "','" + ngayhd + "','" + khhd + "','" + sohd + "',0,'"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "CNH")
                    {
                        phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PCNH");
                        gen.ExcuteNonquery("insert into BATransfer(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,ExDate,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,0,'"+thue+"','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + hanno + "','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "CTM")
                    {
                        phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PCTM");
                        gen.ExcuteNonquery("insert into CAPayment(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,0,'" + thue + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "TNH")
                    {
                        phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PTNH");
                        gen.ExcuteNonquery("insert into BADeposit(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,ExDate,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,0,'" + thue + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + hanno + "','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "TTM")
                    {
                        phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PTTM");
                        gen.ExcuteNonquery("insert into CAReceipt(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,0,'" + thue + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "KTM")
                    {
                        phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PHKT");
                        gen.ExcuteNonquery("insert into GLVoucher(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,TotalAmount,Tax,UserID,ExDate,CustomField5)" +
                                                            "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,0,'" + thue + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + hanno + "','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XCK")
                    {
                        string idkhoden = gen.GetString("select StockID from Stock where StockCode='"+khoden+"'");
                        string donviden = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and StockCode='" + khoden + "'");
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        if (makhophu == khoden)
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi+"-"+makhophu+"-"+ sophieu.Replace(sophieu.Substring(0, 4), "XKNB");
                            string phieumoinhap = donviden + "-" + khoden + "-" + sophieu.Replace(sophieu.Substring(0, 4), "NKNB");
                            gen.ExcuteNonquery("insert into INTransfer(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,CostAmount,No,InvSeries,InvNo,InvDate,UserID,CustomField5)" +
                                                               "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + phieumoinhap + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "','" + idkhoden + "','" + ptvc + "',0,0,'" + loaihd + "','" + khhd + "','" + sohd + "','" + ngayhd + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XDH")
                    {
                        string idkhoden = gen.GetString("select StockID from Stock where StockCode='" + khoden + "'");
                        string donviden = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and StockCode='" + khoden + "'");
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        if (makhophu == khoden)
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi + "-" + makhophu + "-" + sophieu.Replace(sophieu.Substring(0, 4), "XHGB");
                        string phieumoinhap = donviden + "-" + khoden + "-" + sophieu.Replace(sophieu.Substring(0, 4), "NHGB");
                        gen.ExcuteNonquery("insert into INTransferBranch(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,CostAmount,No,InvSeries,InvNo,InvDate,UserID,CustomField5)" +
                                                           "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + phieumoinhap + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "','" + idkhoden + "','" + ptvc + "',0,0,'" + loaihd + "','" + khhd + "','" + sohd + "','" + ngayhd + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XCV")
                    {
                        string idkhoden = gen.GetString("select StockID from Stock where StockCode='" + khoden + "'");
                        string donviden = gen.GetString("select BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and StockCode='" + khoden + "'");
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi + "-" + makhophu + "-" + sophieu.Replace(sophieu.Substring(0, 4), "XKVT");
                        string phieumoinhap = donviden + "-" + khoden + "-" + sophieu.Replace(sophieu.Substring(0, 4), "NKVT");
                        gen.ExcuteNonquery("insert into INTransferSU(RefID,RefType,RefDate,PostedDate,RefNo,RefNoIn,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,OutwardStockID,InwardStockID,ShippingNo,TotalAmount,No,InvSeries,InvNo,InvDate,UserID,CustomField5)" +
                                                           "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + phieumoinhap + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "','" + idkhoden + "','" + ptvc + "',0,'" + loaihd + "','" + khhd + "','" + sohd + "','" + ngayhd + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "NVT")
                    {
                        phieumoi = donvi + "-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PNVT");
                        gen.ExcuteNonquery("insert into INInwardSU(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID,CustomField5)"+
                                                        "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,N'" + ptvc + "',0,'5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XVT")
                    {
                        phieumoi = donvi + "-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PXVT");
                        gen.ExcuteNonquery("insert into INOutwardSU(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,TotalAmount,UserID,CustomField5)" +
                                                        "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "',N'" + chungtugoc + "','False','" + idkho + "',0,N'" + ptvc + "',0,'5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "NDC")
                    {
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi + "-" + makhophu + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PNDC");
                        gen.ExcuteNonquery("insert into INAdjustment(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,CustomField5)" +
                                                        "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "',0,'" + sohd + "','"+loaihd+"','"+ngayhd+"','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+loaihd+"','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XDC")
                    {
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi + "-" + makhophu + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PXDC");
                        gen.ExcuteNonquery("insert into OUTAdjustment(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,CustomField5)" +
                                                        "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "',0,'" + sohd + "','" + loaihd + "','" + ngayhd + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + loaihd + "','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "NTT")
                    {
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi + "-" + makhophu + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PNHT");
                        gen.ExcuteNonquery("insert into INSurplus(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,CustomField5)" +
                                                        "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "',0,'" + sohd + "','" + loaihd + "','" + ngayhd + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + loaihd + "','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XTT")
                    {
                        string idmakhophu;
                        try
                        {
                            idmakhophu = gen.GetString("select StockID from Stock where StockCode='" + makhophu + "'");
                        }
                        catch
                        {
                            idmakhophu = idkho;
                            makhophu = makho;
                        }
                        phieumoi = donvi + "-" + makhophu + "-" + sophieu.Replace(sophieu.Substring(0, 4), "PXHT");
                        gen.ExcuteNonquery("insert into OUTdeficit(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,JournalMemo,Posted,StockID,TotalAmount,InvSeries,InvNo,InvDate,EmployeeID,No,CustomField5)" +
                                                        "values(newid(),101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + lydo + "','False','" + idmakhophu + "',0,'" + sohd + "','" + loaihd + "','" + ngayhd + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + loaihd + "','"+sophieu+"')");
                    }
                    else if (sophieu.Substring(0, 3) == "XGB")
                    {
                        string idkhoden = gen.GetString("select StockID from Stock where StockCode='" + khoden + "'");
                        phieumoi = donvi + "-" + khoden + "-" + sophieu.Replace(sophieu.Substring(0, 4), "HDGB");
                        gen.ExcuteNonquery("insert into SSInvoiceBranch(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount,StockID,CustomField5)" +
                                                            "values(newid(),'" + iddonvi + "',101,'" + ngay + "','" + ngay + "','" + phieumoi + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','False',0,'"+thue+"','"+khhd+"','"+sohd+"','"+hanno+"',0,'5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','"+ngayhd+"','"+loaihd+"','"+httt+"','"+tienthue+"','" + idkhoden + "','"+sophieu+"')");
                    }

                }
                SplashScreenManager.CloseForm();
            }
        }

        private void Frm_import_Load(object sender, EventArgs e)
        {
            barnct.Caption = "Ngày chứng từ: " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu));
            khachuni = gen.GetTable("select b.AccountingObjectID,a.AccountingObjectCode,a.ContactHomeTel from (select * from AccountingObject where EmailAddress is not null and EmailAddress<>'') a, AccountingObject b where a.EmailAddress=b.AccountingObjectCode");
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật lại chi tiết hệ thống phiếu ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));

                string mahang, sophieu, ngayhd, sohd, khhd, makhach, no, co, dongia, soluongquydoi;
                Double soluong, thanhtien, chiphi;
                string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                string nam = DateTime.Parse(ngaychungtu).Year.ToString();

                gen.ExcuteNonquery("delete from INOutwardDetail where RefID in (select RefID from INOutward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from INInwardDetail where  RefID in (select RefID from INInward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from SUCAPaymentDetail where RefID in (select RefID from SUCAPayment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from SUBATransferDetail where RefID in (select RefID from SUBATransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from SUCAReceiptDetail where RefID in (select RefID from SUCAReceipt where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from SUBADepositDetail where RefID in (select RefID from SUBADeposit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from CAPaymentDetail where RefID in (select RefID from CAPayment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from BATransferDetail where RefID in (select RefID from BATransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from CAReceiptDetail where RefID in (select RefID from CAReceipt where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from BADepositDetail where RefID in (select RefID from BADeposit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from GLVoucherDetail where RefID in (select RefID from GLVoucher where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from INTransferDetail where RefID in (select RefID from INTransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from INTransferBranchDetail where RefID in (select RefID from INTransferBranch where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");

                gen.ExcuteNonquery("delete from INTransferSUDetail where RefID in (select RefID from INTransferSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from INInwardSUDetail where RefID in (select RefID from INInwardSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from INOutwardSUDetail where RefID in (select RefID from INOutwardSU where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");

                gen.ExcuteNonquery("delete from INAdjustmentDetail where RefID in (select RefID from INAdjustment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from OUTAdjustmentDetail where RefID in (select RefID from OUTAdjustment where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from INSurplusDetail where RefID in (select RefID from INSurplus where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from OUTdeficitDetail where RefID in (select RefID from OUTdeficit where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "')");
                gen.ExcuteNonquery("delete from SSInvoiceBranchDetail where RefID in (select RefID from SSInvoiceBranch where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "')");
                

                for (int i = 0; i < view.RowCount; i++)
                {
                    sophieu = view.GetRowCellValue(i, "Số phiếu").ToString();

                    try
                    {
                        mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + view.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                    }
                    catch
                    {
                        mahang = "";
                    }
                    try
                    {
                        makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + view.GetRowCellValue(i, "Mã khách").ToString() + "'");
                    }
                    catch
                    {
                        makhach = "";
                    }

                    soluong = double.Parse(view.GetRowCellValue(i, "Số lượng").ToString());
                    soluongquydoi = double.Parse(view.GetRowCellValue(i, "Số lượng QĐ").ToString()).ToString().Replace(",",".");
                    dongia = double.Parse(view.GetRowCellValue(i, "Đơn giá").ToString()).ToString().Replace(",",".");
                    thanhtien = double.Parse(view.GetRowCellValue(i, "Thành tiền").ToString());
                    chiphi = double.Parse(view.GetRowCellValue(i, "Chi phí").ToString());
                    khhd = view.GetRowCellValue(i, "KHHĐ").ToString();
                    sohd = view.GetRowCellValue(i, "Số HĐ").ToString();
                    ngayhd = view.GetRowCellValue(i, "Ngày HĐ").ToString();
                    if (view.GetRowCellValue(i, "Tài khoản").ToString().Substring(0, 1) == "N")
                    {
                        no = view.GetRowCellValue(i, "Tài khoản").ToString().Replace("N", "");
                        co = view.GetRowCellValue(i, "TKĐU").ToString().Replace("C", "");
                    }
                    else
                    {
                        no = view.GetRowCellValue(i, "TKĐU").ToString().Replace("N", "");
                        co = view.GetRowCellValue(i, "Tài khoản").ToString().Replace("C", "");
                    }



                        if (sophieu.Substring(0, 3) == "BDN" || sophieu.Substring(0, 3) == "BXD" || sophieu.Substring(0, 3) == "XHH")
                        {
                            string id = gen.GetString("select RefID from INOutward where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountRate,DiscountAmount)" +
                                                                    "values(newid(),'" + id + "','" + soluong + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "','" + thanhtien + "',0,0,'" + chiphi + "',0,0)");
                                           
                        }
                        else if (sophieu.Substring(0, 3) == "NHH" || sophieu.Substring(0, 3) == "NXD")
                        {
                            string id = gen.GetString("select RefID from INInward where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INInwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,UnitPrice,Amount,QuantityExits,QuantityConvertExits,AmountOC)" +
                                                                    "values(newid(),'" + id + "','" + soluong + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "','" + thanhtien + "',0,0,'" + chiphi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "CCN")
                        {
                            string id = gen.GetString("select RefID from SUCAPayment where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into SUCAPaymentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,SalePrice)"+
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "CHN")
                        {
                            string id = gen.GetString("select RefID from SUBATransfer where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into SUBATransferDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,SalePrice)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "TCN")
                        {
                            string id = gen.GetString("select RefID from SUCAReceipt where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into SUCAReceiptDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,SalePrice)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "THN")
                        {
                            string id = gen.GetString("select RefID from SUBADeposit where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into SUBADepositDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,SalePrice)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "CNH")
                        {
                            string id = gen.GetString("select RefID from  BATransfer where CustomField5='" + sophieu + "'");
                            try
                            {
                                gen.ExcuteNonquery("insert into BATransferDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo)"+
                                                                        "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "','" + ngayhd + "','" + khhd + "','" + sohd + "')");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into BATransferDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID)"+
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "')");
                            }
                            
                        }
                        else if (sophieu.Substring(0, 3) == "CTM")
                        {
                            string id = gen.GetString("select RefID from  CAPayment where CustomField5='" + sophieu + "'");
                            try
                            {
                                gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo)" +
                                                                        "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "','" + ngayhd + "','" + khhd + "','" + sohd + "')");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into CAPaymentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "')");
                            }
                        }
                        else if (sophieu.Substring(0, 3) == "TNH")
                        {
                            string id = gen.GetString("select RefID from  BADeposit where CustomField5='" + sophieu + "'");
                            try
                            {
                                gen.ExcuteNonquery("insert into  BADepositDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo)" +
                                                                        "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "','" + ngayhd + "','" + khhd + "','" + sohd + "')");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into  BADepositDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "')");
                            }
                        }
                        else if (sophieu.Substring(0, 3) == "TTM")
                        {
                            string id = gen.GetString("select RefID from CAReceipt where CustomField5='" + sophieu + "'");
                            try
                            {
                                gen.ExcuteNonquery("insert into CAReceiptDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo)" +
                                                                        "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "','" + ngayhd + "','" + khhd + "','" + sohd + "')");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into CAReceiptDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "')");
                            }
                        }
                        else if (sophieu.Substring(0, 3) == "KTM")
                        {
                            string id = gen.GetString("select RefID from GLVoucher where CustomField5='" + sophieu + "'");
                            try
                            {
                                gen.ExcuteNonquery("insert into GLVoucherDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID,InvDate,InvSeries,InvNo)" +
                                                                        "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "','" + ngayhd + "','" + khhd + "','" + sohd + "')");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into GLVoucherDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,AccountingObjectID)" +
                                                                    "values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + makhach + "')");
                            }
                        }
                        else if (sophieu.Substring(0, 3) == "XCK")
                        {
                            string id = gen.GetString("select RefID from INTransfer where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INTransferDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,UnitPrice,Amount,Cost) values(newid(),'" + id + "','" + soluong + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "','" + thanhtien + "','" + chiphi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "XDH")
                        {
                            string id = gen.GetString("select RefID from INTransferBranch where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INTransferBranchDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,UnitPrice,Amount,Cost) values(newid(),'" + id + "','" + soluong + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "','" + thanhtien + "','" + chiphi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "XCV")
                        {
                            string id = gen.GetString("select RefID from INTransferSU where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INTransferSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,UnitPrice,Amount)"+
                                                        "values(newid(),'" + id + "','" + soluongquydoi + "','" + soluong + "','" + mahang + "','" + dongia + "','" + thanhtien + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "NVT")
                        {
                            Double tien = thanhtien+chiphi;
                            string id = gen.GetString("select RefID from INInwardSU where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INInwardSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,QuantityExits,QuantityConvertExits,UnitPrice,Amount,DebitAccount,CreditAccount) " +
                                                                "values(newid(),'" + id + "','" + soluongquydoi + "','" + soluong + "','" + mahang + "',0,0,'" + dongia + "','" + tien + "','"+no+"','"+co+"')");
                        }
                        else if (sophieu.Substring(0, 3) == "XVT")
                        {
                            Double tien = thanhtien + chiphi;
                            string id = gen.GetString("select RefID from INOutwardSU where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INOutwardSUDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,QuantityExits,QuantityConvertExits,UnitPrice,Amount,DebitAccount,CreditAccount) " +
                                                                    "values(newid(),'" + id + "','" + soluongquydoi + "','" + soluong + "','" + mahang + "',0,0,'" + dongia + "','" + tien + "','"+no+"','"+co+"')");
                       }
                        else if (sophieu.Substring(0, 3) == "NDC")
                        {
                            string id = gen.GetString("select RefID from INAdjustment where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INAdjustmentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,UnitPrice,QuantityConvert)"+
                                                            " values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluong + "','" + mahang + "','" + dongia + "','" + soluongquydoi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "XDC")
                        {
                            string id = gen.GetString("select RefID from OUTAdjustment where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into OUTAdjustmentDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,UnitPrice,QuantityConvert)" +
                                                            " values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluong + "','" + mahang + "','" + dongia + "','" + soluongquydoi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "NTT")
                        {
                            string id = gen.GetString("select RefID from INSurplus where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into INSurplusDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,UnitPrice,QuantityConvert)" +
                                                            " values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluong + "','" + mahang + "','" + dongia + "','" + soluongquydoi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "XTT")
                        {
                            string id = gen.GetString("select RefID from OUTdeficit where CustomField5='" + sophieu + "'");
                            gen.ExcuteNonquery("insert into OUTdeficitDetail(RefDetailID,RefID,DebitAccount,CreditAccount,Amount,Quantity,InventoryItemID,UnitPrice,QuantityConvert)" +
                                                            " values(newid(),'" + id + "','" + no + "','" + co + "','" + thanhtien + "','" + soluong + "','" + mahang + "','" + dongia + "','" + soluongquydoi + "')");
                        }
                        else if (sophieu.Substring(0, 3) == "XGB")
                        {
                            string id = gen.GetString("select RefID from SSInvoiceBranch where CustomField5='"+sophieu+"'");
                            gen.ExcuteNonquery("insert into SSInvoiceBranchDetail(RefDetailID,RefID,Quantity,QuantityConvert,InventoryItemID,UnitPrice,Amount,FreightAmount)"+
                                            "values(newid(),'" + id + "','" + soluong + "','" + soluongquydoi + "','" + mahang + "','" + dongia + "','" + thanhtien + "','" + chiphi + "')");
                        }

                }
                capnhat(ngaychungtu);
                SplashScreenManager.CloseForm();
                
            }
        }

        private void capnhat(string ngaychungtu)
        {

                    gen.ExcuteNonquery("UPDATE SSInvoiceBranch SET TotalAmount=Amount,TotalFreightAmount=FreightAmount FROM (SELECT RefID,sum(Amount) as Amount,sum(FreightAmount) as FreightAmount FROM  SSInvoiceBranchDetail group by RefID) b where SSInvoiceBranch.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INInward SET TotalAmount=Amount,CustomField10=AmountOC FROM (SELECT RefID,sum(Amount) as Amount,sum(AmountOC) as AmountOC FROM  INInwardDetail group by RefID) b where INInward.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INOutward SET TotalAmount=Amount, TotalFreightAmount=Cost FROM (SELECT RefID,sum(Amount) as Amount,sum(Cost) as Cost FROM  INOutwardDetail group by RefID) b where INOutward.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE SUCAPayment SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM SUCAPaymentDetail group by RefID) b where SUCAPayment.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE SUBATransfer SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM SUBATransferDetail group by RefID) b where SUBATransfer.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE SUCAReceipt SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM SUCAReceiptDetail group by RefID) b where SUCAReceipt.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE SUBADeposit SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM SUBADepositDetail group by RefID) b where SUBADeposit.RefID=b.RefID");

                    gen.ExcuteNonquery("UPDATE CAPayment SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM CAPaymentDetail group by RefID) b where CAPayment.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE BATransfer SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM BATransferDetail group by RefID) b where BATransfer.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE CAReceipt SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM CAReceiptDetail group by RefID) b where CAReceipt.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE BADeposit SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM BADepositDetail group by RefID) b where BADeposit.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE GLVoucher SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM GLVoucherDetail group by RefID) b where GLVoucher.RefID=b.RefID");

                    gen.ExcuteNonquery("UPDATE INTransfer SET TotalAmount=Amount,CostAmount=Cost FROM (SELECT RefID,sum(Amount) as Amount,sum(Cost) Cost FROM INTransferDetail group by RefID) b where INTransfer.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INTransferBranch SET TotalAmount=Amount,CostAmount=Cost FROM (SELECT RefID,sum(Amount) as Amount,sum(Cost) Cost FROM INTransferBranchDetail group by RefID) b where INTransferBranch.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INTransferSU SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM INTransferSUDetail group by RefID) b where INTransferSU.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INInwardSU SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM INInwardSUDetail group by RefID) b where INInwardSU.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INOutwardSU SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM INOutwardSUDetail group by RefID) b where INOutwardSU.RefID=b.RefID");

                    gen.ExcuteNonquery("UPDATE INAdjustment SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM INAdjustmentDetail group by RefID) b where INAdjustment.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE OUTAdjustment SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM OUTAdjustmentDetail group by RefID) b where OUTAdjustment.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE INSurplus SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM INSurplusDetail group by RefID) b where INSurplus.RefID=b.RefID");
                    gen.ExcuteNonquery("UPDATE OUTdeficit SET TotalAmount=Amount FROM (SELECT RefID,sum(Amount) as Amount FROM OUTdeficitDetail group by RefID) b where OUTdeficit.RefID=b.RefID");
            
                    string thang = DateTime.Parse(ngaychungtu).Month.ToString();
                    string nam = DateTime.Parse(ngaychungtu).Year.ToString();
                    gen.ExcuteNonquery("delete from PUInvoiceDetail where RefID in (select RefID from PUInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "')");
                    gen.ExcuteNonquery("delete from PUInvoiceINInward where PUInvoiceID in (select RefID from PUInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "')");
                    gen.ExcuteNonquery("delete from PUInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "'");
            
                    DataTable dt = new DataTable();
                    dt = gen.GetTable("select * from INInward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string maphieu = dt.Rows[i][0].ToString();
                        string makho = dt.Rows[i][22].ToString();
                        string ngay = dt.Rows[i][2].ToString();
                        string ngaydenhan = dt.Rows[i][3].ToString();
                        string sophieu = dt.Rows[i][4].ToString().Replace("PNKH", "HDMH");
                        string makhach = dt.Rows[i][5].ToString();
                        string tenkhach = dt.Rows[i][6].ToString();
                        string diachi = dt.Rows[i][7].ToString();
                        string makhachphu = dt.Rows[i][29].ToString();
                        string lydo = dt.Rows[i][9].ToString();
                        string tongtien = null;
                        try
                        {                           
                            tongtien = Double.Parse(dt.Rows[i][21].ToString()).ToString();
                        }
                        catch { MessageBox.Show(sophieu); }
                        string thue = Double.Parse(dt.Rows[i][30].ToString()).ToString();
                        string tienthue = Double.Parse(dt.Rows[i][20].ToString()).ToString();
                        string loaihd = dt.Rows[i][28].ToString();
                        string sohd = dt.Rows[i][48].ToString();
                        string khhd = dt.Rows[i][47].ToString();
                        string ngayhd = dt.Rows[i][49].ToString();
                        string hanno = Double.Parse(dt.Rows[i][51].ToString()).ToString();
                        string httt = dt.Rows[i][50].ToString();
                        string chiphi = Double.Parse(dt.Rows[i][52].ToString()).ToString();
                        
                        try
                        {
                            gen.ExcuteNonquery("insert into PUInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,AccountingObjectID1562,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount)" +
                                                    "values(newid(),'" + makho + "',101,'" + ngay + "','" + ngaydenhan + "','" + sophieu + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "','" + makhachphu + "',N'" + lydo + "','False',0,'" + tongtien + "','" + thue + "','" + khhd + "','" + sohd + "'," + hanno + ",'" + chiphi + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + ngayhd + "','" + loaihd + "',N'" + httt + "','" + tienthue + "')");
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into PUInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalVatAmount)" +
                                                    "values(newid(),'" + makho + "',101,'" + ngay + "','" + ngaydenhan + "','" + sophieu + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','False',0,'" + tongtien + "','" + thue + "','" + khhd + "','" + sohd + "'," + hanno + ",'" + chiphi + "','5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + ngayhd + "','" + loaihd + "',N'" + httt + "','" + tienthue + "')");
                        }
                        string refid = gen.GetString("select * from PUInvoice where RefNo='" + sophieu + "'");

                        DataTable temp = new DataTable();
                        temp = gen.GetTable("select * from INInwardDetail where RefID='" + maphieu + "'");
                        for (int j = 0; j < temp.Rows.Count; j++)
                        {
                            string sotien = Double.Parse(temp.Rows[j][15].ToString()).ToString();
                            string soluong = Double.Parse(temp.Rows[j][8].ToString()).ToString();
                            string soluongquydoi = Double.Parse(temp.Rows[j][9].ToString()).ToString().Replace(",", ".");
                            string mahang = temp.Rows[j][2].ToString();
                            string dongia = Double.Parse(temp.Rows[j][11].ToString()).ToString().Replace(",", ".");
                            string chiphicon = Double.Parse(temp.Rows[j][14].ToString()).ToString();

                            gen.ExcuteNonquery("insert into PUInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice)" +
                                                                    " values(newid(),'" + refid + "','" + sotien + "','" + soluong + "','" + soluongquydoi + "'," + j + ",'" + mahang + "','" + dongia + "')");

                            gen.ExcuteNonquery("insert into PUInvoiceINInward values(newid(),'" + refid + "','" + maphieu + "','" + makho + "','" + mahang + "','" + soluong + "','" + soluongquydoi + "','" + dongia + "','" + sotien + "','331','" + chiphicon + "','"+j+"')");
                        }
                    }
                    gen.ExcuteNonquery("update INInwardDetail set QuantityExits=Quantity,QuantityConvertExits=QuantityConvert where RefID in (select RefID from INInward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' )");
                    gen.ExcuteNonquery("update INInward set IsExport='True' where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                    

                    gen.ExcuteNonquery("delete from SSInvoiceDetail where RefID in (select RefID from SSInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "')");
                    gen.ExcuteNonquery("delete from SSInvoiceINOutward where SSInvoiceID in (select RefID from SSInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "')");
                    gen.ExcuteNonquery("delete from SSInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "'");

                    dt = gen.GetTable("select * from INOutward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string maphieu = dt.Rows[i][0].ToString();
                        string makho = dt.Rows[i][22].ToString();
                        string ngay = dt.Rows[i][2].ToString();
                        string ngaydenhan = dt.Rows[i][3].ToString();
                        string sophieu = dt.Rows[i][4].ToString().Replace("PXKH", "HDBH");
                        string makhach = dt.Rows[i][5].ToString();
                        string tenkhach = dt.Rows[i][6].ToString();
                        string diachi = dt.Rows[i][7].ToString();
                        
                        string lydo = dt.Rows[i][9].ToString();
                        string tongtien = Double.Parse(dt.Rows[i][21].ToString()).ToString();
                        string thue = Double.Parse(dt.Rows[i][45].ToString()).ToString();
                        string tienthue = Double.Parse(dt.Rows[i][20].ToString()).ToString();
                        string loaihd = dt.Rows[i][30].ToString();
                        string sohd = dt.Rows[i][28].ToString();
                        string khhd = dt.Rows[i][29].ToString();
                        string ngayhd = dt.Rows[i][49].ToString();
                        string chiphi = Double.Parse(dt.Rows[i][48].ToString()).ToString();
                        string httt = dt.Rows[i][50].ToString();
                        string hanno = Double.Parse(dt.Rows[i][51].ToString()).ToString();                     
                        string bancho = "Bán lẻ";
                        if (dt.Rows[i][51].ToString() == "02")
                            bancho = "Công trình";
                        else if (dt.Rows[i][51].ToString() == "03")
                            bancho = "Bán sỉ";
                        string quyen = Double.Parse(dt.Rows[i][52].ToString()).ToString();
                        gen.ExcuteNonquery("insert into SSInvoice(RefID,BranchID,RefType,PURefDate,PUPostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,PUJournalMemo,Posted,AccountingObjectType,TotalAmount,Tax,InvSeries,InvNo,DueDateTime,TotalFreightAmount,UserID,CABARefDate,No,PayNo,TotalCost,TotalVATAmount,TotalDiscountAmount,DocumentIncluded,MoneyPay,Reconciled,IssueBy,ParalellRefNo)" +
                                                "values(newid(),'" + makho + "',101,'" + ngay + "','" + ngaydenhan + "','" + sophieu + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'" + lydo + "','False',0,'" + tongtien + "','" + thue + "','" + khhd + "','" + sohd + "'," + hanno + ",0,'5c2f6d39-e0c4-4d3e-8ab1-e00d51867ccc','" + ngayhd + "','" + loaihd + "',N'" + httt + "','" + chiphi + "','" + tienthue + "',0,NULL,'False','False',N'" + bancho + "','"+quyen+"')");
                        string refid = gen.GetString("select * from SSInvoice where RefNo='" + sophieu + "'");

                        DataTable temp = new DataTable();
                        temp = gen.GetTable("select * from INOutwardDetail where RefID='" + maphieu + "'");
                        for (int j = 0; j < temp.Rows.Count; j++)
                        {
                            string sotien = Double.Parse(temp.Rows[j][15].ToString()).ToString();
                            string soluong = Double.Parse(temp.Rows[j][8].ToString()).ToString();
                            string soluongquydoi = Double.Parse(temp.Rows[j][9].ToString()).ToString().Replace(",", ".");
                            string mahang = temp.Rows[j][2].ToString();
                            string dongia = Double.Parse(temp.Rows[j][11].ToString()).ToString().Replace(",", ".");
                            string chiphicon = Double.Parse(temp.Rows[j][35].ToString()).ToString();

                            gen.ExcuteNonquery("insert into SSInvoiceDetail(RefDetailID,RefID,Amount,Quantity,QuantityConvert,SortOrder,InventoryItemID,UnitPrice)"+
                                                                    " values(newid(),'" + refid + "','" + sotien + "','" + soluong + "','" + soluongquydoi + "'," + j + ",'" + mahang + "','" + dongia + "')");

                            gen.ExcuteNonquery("insert into SSInvoiceINOutward values(newid(),'" + refid + "','" + maphieu + "','" + makho + "','" + mahang + "','" + soluong + "','" + soluongquydoi + "','" + dongia + "','" + sotien + "','131',0,0,'" + chiphicon + "',0,'"+j+"',NULL)");
                        }
                    }
                    gen.ExcuteNonquery("update INOutwardDetail set QuantityExits=Quantity,QuantityConvertExits=QuantityConvert where RefID in (select RefID from INOutward where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' )");
                    gen.ExcuteNonquery("update INOutward set IsExport='True' where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "'");
                    
        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                if (XtraMessageBox.Show("Bạn chắc muốn cập nhật lại hóa đơn ?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                        SplashScreenManager.ShowForm(typeof(Frm_wait));
                        capnhat(ngaychungtu);
                        SplashScreenManager.CloseForm();
                }
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật đầu kỳ hàng hóa Tháng "+thang+" năm " +nam+"?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                gen.ExcuteNonquery("delete from OpeningInventoryEntry where Month(RefOrder)='" + thang + "' and Year(RefOrder)='"+nam+"'");
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số lượng").ToString() != "0" || view.GetRowCellValue(i, "Số lượng quy đổi").ToString() != "0" || view.GetRowCellValue(i, "Số tiền").ToString() != "0")
                    {
                        string mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + view.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        string makho = gen.GetString("select StockID from Stock where StockCode='" + view.GetRowCellValue(i, "Mã kho").ToString() + "'");
                        string soluong = view.GetRowCellValue(i, "Số lượng").ToString();
                        string soluongqd = view.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(",", ".");
                        string sotien = view.GetRowCellValue(i, "Số tiền").ToString();

                        string sql = "insert into OpeningInventoryEntry(RefID,InventoryItemID,StockID,Quantity,QuantityConvert,Amount,RefOrder)  values(newid(),'" + mahang + "','" + makho + "','" + soluong + "','" + soluongqd + "','" + sotien + "','" + ngaychungtu + "')";

                        gen.ExcuteNonquery(sql);
                    }
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem33_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật đầu kỳ hàng hóa Tháng " + thang + " năm " + nam + "?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                gen.ExcuteNonquery("delete from OpeningInventoryEntrySU where Month(RefOrder)='" + thang + "' and Year(RefOrder)='" + nam + "'");
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số lượng").ToString() != "0" || view.GetRowCellValue(i, "Số lượng quy đổi").ToString() != "0" || view.GetRowCellValue(i, "Số tiền").ToString() != "0")
                    {
                        string mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + view.GetRowCellValue(i, "Mã hàng").ToString() + "'");
                        string makho = gen.GetString("select StockID from Stock where StockCode='" + view.GetRowCellValue(i, "Mã kho").ToString() + "'");
                        string soluong = view.GetRowCellValue(i, "Số lượng").ToString();
                        string soluongqd = view.GetRowCellValue(i, "Số lượng quy đổi").ToString().Replace(",", ".");
                        string sotien = view.GetRowCellValue(i, "Số tiền").ToString();

                        string sql = "insert into OpeningInventoryEntrySU(RefID,InventoryItemID,StockID,Quantity,QuantityConvert,Amount,RefOrder)  values(newid(),'" + mahang + "','" + makho + "','" + soluongqd + "','" + soluongqd + "','" + sotien + "','" + ngaychungtu + "')";

                        gen.ExcuteNonquery(sql);
                    }
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem34_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật lại toàn bộ tài khoản tháng " + thang + " năm " + nam + "?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));      
                gen.ExcuteNonquery("tonghophethongtaikhoan '"+thang+"','"+nam+"'");
                SplashScreenManager.CloseForm();
            }
        }


        private void barButtonItem36_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật số dư tài khoản Tháng " + thang + " năm " + nam + "?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                gen.ExcuteNonquery("delete from AccountAccumulated where Month(PostDate)='" + thang + "' and Year(PostDate)='" + nam + "'");
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Mã khách").ToString() == "")
                    {
                        string tk = view.GetRowCellValue(i, "TK").ToString();
                        gen.ExcuteNonquery("delete from AccountAccumulated where Month(PostDate)='" + thang + "' and Year(PostDate)='" + nam + "' and AccountNumber='" + tk + "'");
                        string ngay = view.GetRowCellValue(i, "Ngày").ToString();
                        string no = view.GetRowCellValue(i, "Nợ").ToString().Replace(",", ".");
                        string co = view.GetRowCellValue(i, "Có").ToString().Replace(",", ".");
                        string sql = "insert into AccountAccumulated(RefID,AccountNumber,DebitAmount,CreditAmount,DebitAccumulated,CreditAccumulated,DebitArising,CreditArising,PostDate)  values(newid(),'" + tk + "','" + no + "','" + co + "',0,0,0,0,'" + ngay + "')";
                        gen.ExcuteNonquery(sql);
                    }
                    else
                    {
                        string makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + view.GetRowCellValue(i, "Mã khách").ToString() + "'");
                        string makho = gen.GetString("select StockID from Stock where StockCode='" + view.GetRowCellValue(i, "Mã kho").ToString() + "'");
                        string tk = view.GetRowCellValue(i, "TK").ToString();
                        string ngay = view.GetRowCellValue(i, "Ngày").ToString();
                        string no = view.GetRowCellValue(i, "Nợ").ToString().Replace(",", ".");
                        string co = view.GetRowCellValue(i, "Có").ToString().Replace(",", ".");
                        if (no != "0" || co != "0")
                        {
                            string sql = "insert into AccountAccumulated(RefID,AccountingObjectID,StockID,AccountNumber,DebitAmount,CreditAmount,DebitAccumulated,CreditAccumulated,DebitArising,CreditArising,PostDate)  values(newid(),'" + makhach + "','" + makho + "','" + tk + "','" + no + "','" + co + "',0,0,0,0,'" + ngay + "')";
                            gen.ExcuteNonquery(sql);
                        }
                    }
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem38_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật nợ quá hạn Tháng " + thang + " năm " + nam + "?", "HAMACO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                gen.ExcuteNonquery("delete from OpenExDate where Month(PostedDate)='" + thang + "' and Year(PostedDate)='" + nam + "'");
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "SDCK nợ").ToString() != "0" || view.GetRowCellValue(i, "SDCK có").ToString() != "0")
                    {
                        string sophieu, phieumoi=null,makho,makhach,ngaythanhtoan,ngaylap,ngayhd=null,sohd=null;
                        makho = view.GetRowCellValue(i, "Mã kho").ToString();
                        makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + view.GetRowCellValue(i, "Mã khách").ToString() + "'");
                        DataTable dt = gen.GetTable("select a.StockID,a.BranchID,BranchCode from Stock a, Branch b where a.BranchID=b.BranchID and StockCode='" + makho + "'");
                        string idkho = dt.Rows[0][0].ToString();
                        string donvi = dt.Rows[0][2].ToString();
                        Double hanno =0, thanhtien = 0;

                        if (view.GetRowCellValue(i, "SDCK nợ").ToString() != "0")
                        {
                            sophieu = view.GetRowCellValue(i, "Số phiếu nợ").ToString();
                            ngaythanhtoan = view.GetRowCellValue(i, "Ngày thanh toán").ToString();
                            if (sophieu.Substring(0, 3) == "BDN" || sophieu.Substring(0, 3) == "BXD" || sophieu.Substring(0, 3) == "XHH")
                            {
                                phieumoi = donvi + "-" + makho + "-" + sophieu.Replace(sophieu.Substring(0, 4), "HDBH");
                                ngayhd = view.GetRowCellValue(i, "Ngày HĐ").ToString();
                                sohd = view.GetRowCellValue(i, "Số HĐ").ToString();
                            }
                            else if (sophieu.Substring(0, 3) == "KTM")
                            {
                                phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PHKT");
                                ngayhd = view.GetRowCellValue(i, "Ngày KT").ToString();
                            }
                            try
                            {
                                TimeSpan Time = DateTime.Parse(ngaythanhtoan) - DateTime.Parse(ngayhd);
                                hanno = Time.Days;
                            }
                            catch { }
                            thanhtien = double.Parse(view.GetRowCellValue(i, "SDCK nợ").ToString());
                            string sql = "insert into OpenExDate(RefID,BranchID,AccountingObjectID,SaleCode,SaleMoney,SaleDate,ExitsMoney,ExDate,NoID,PostedDate,Invoice)  values(newid(),'" + idkho + "','" + makhach + "','" + phieumoi + "'," + thanhtien + ",'" + ngayhd + "'," + thanhtien + "," + hanno + ",0,'" + ngaychungtu + "','" + sohd + "')";
                            gen.ExcuteNonquery(sql);
                        }
                        else
                        {                            
                            sophieu = view.GetRowCellValue(i, "Số phiếu trả").ToString();
                            ngaylap = view.GetRowCellValue(i, "Ngày lập PT").ToString();
                            if (sophieu.Substring(0, 3) == "TNH")
                                phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PTNH");
                            else if (sophieu.Substring(0, 3) == "TTM")
                                phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PTTM");
                            else if (sophieu.Substring(0, 3) == "KTM")
                                phieumoi = "08-08-" + sophieu.Replace(sophieu.Substring(0, 4), "PHKT");
                            thanhtien = double.Parse(view.GetRowCellValue(i, "SDCK có").ToString());
                            string sql = "insert into OpenExDate(RefID,BranchID,AccountingObjectID,SaleCode,SaleMoney,SaleDate,ExitsMoney,NoID,PostedDate)  values(newid(),'" + idkho + "','" + makhach + "','" + phieumoi + "'," + thanhtien + ",'" + ngaylap + "'," + thanhtien + ",2,'" + ngaychungtu + "')";
                            gen.ExcuteNonquery(sql);
                        }
                    }
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem39_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Thao tác này sẽ xoá toàn bộ dữ liệu của bạn, bạn có chắc muốn thực hiện ?", gen.GetString("select Top 1 CompanyName from Center"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                   SplashScreenManager.ShowForm(typeof(Frm_wait));

                   gen.ExcuteNonquery("delete from INOutward");
                   gen.ExcuteNonquery("delete from INInward");
                   gen.ExcuteNonquery("delete from SUCAPayment");
                   gen.ExcuteNonquery("delete from SUBATransfer");
                   gen.ExcuteNonquery("delete from SUCAReceipt");
                   gen.ExcuteNonquery("delete from SUBADeposit");
                   gen.ExcuteNonquery("delete from CAPayment");
                   gen.ExcuteNonquery("delete from BATransfer");
                   gen.ExcuteNonquery("delete from CAReceipt");
                   gen.ExcuteNonquery("delete from BADeposit");
                   gen.ExcuteNonquery("delete from GLVoucher");
                   gen.ExcuteNonquery("delete from INTransfer");
                   gen.ExcuteNonquery("delete from INTransferBranch");
                   gen.ExcuteNonquery("delete from INTransfer");
                   gen.ExcuteNonquery("delete from INTransferBranch");
                   gen.ExcuteNonquery("delete from BAAccreditative");
                   gen.ExcuteNonquery("delete from INTransferSU");
                   gen.ExcuteNonquery("delete from INInwardSU");
                   gen.ExcuteNonquery("delete from INOutwardSU");

                   gen.ExcuteNonquery("delete from INAdjustment");
                   gen.ExcuteNonquery("delete from OUTAdjustment");
                   gen.ExcuteNonquery("delete from INSurplus");
                   gen.ExcuteNonquery("delete from OUTdeficit");
                   gen.ExcuteNonquery("delete from SSInvoiceBranch");

                   gen.ExcuteNonquery("delete from INOutwardDetail");
                   gen.ExcuteNonquery("delete from INInwardDetail");
                   gen.ExcuteNonquery("delete from SUCAPaymentDetail");
                   gen.ExcuteNonquery("delete from SUBATransferDetail");
                   gen.ExcuteNonquery("delete from SUCAReceiptDetail");
                   gen.ExcuteNonquery("delete from SUBADepositDetail");
                   gen.ExcuteNonquery("delete from CAPaymentDetail");
                   gen.ExcuteNonquery("delete from BATransferDetail");
                   gen.ExcuteNonquery("delete from CAReceiptDetail");
                   gen.ExcuteNonquery("delete from BADepositDetail");
                   gen.ExcuteNonquery("delete from GLVoucherDetail");
                   gen.ExcuteNonquery("delete from INTransferDetail");
                   gen.ExcuteNonquery("delete from INTransferBranchDetail");
                   gen.ExcuteNonquery("delete from BAAccreditativeDetail");

                   gen.ExcuteNonquery("delete from INTransferSUDetail");
                   gen.ExcuteNonquery("delete from INInwardSUDetail");
                   gen.ExcuteNonquery("delete from INOutwardSUDetail");

                   gen.ExcuteNonquery("delete from INAdjustmentDetail");
                   gen.ExcuteNonquery("delete from OUTAdjustmentDetail");
                   gen.ExcuteNonquery("delete from INSurplusDetail");
                   gen.ExcuteNonquery("delete from OUTdeficitDetail");
                   gen.ExcuteNonquery("delete from SSInvoiceBranchDetail");

                   gen.ExcuteNonquery("delete from AccountAccumulated");
                   gen.ExcuteNonquery("delete from AccountSum");
                   gen.ExcuteNonquery("delete from Detail33");
                   gen.ExcuteNonquery("delete from HACHTOAN");
                   gen.ExcuteNonquery("delete from Open3388");
                   gen.ExcuteNonquery("delete from OpenExDate");
                   gen.ExcuteNonquery("delete from OpeningAccountEntry131");
                   gen.ExcuteNonquery("delete from OpeningInventoryEntrySU");
                   gen.ExcuteNonquery("delete from OpeningInventoryEntry");
                   gen.ExcuteNonquery("delete from OpeningInventoryEntryUnit");
                   gen.ExcuteNonquery("delete from Targets");
                   gen.ExcuteNonquery("delete from Targets2");
                   gen.ExcuteNonquery("delete from Account632");


                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem43_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            string nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (XtraMessageBox.Show("Điều chỉnh lại khấu trừ trên hóa đơn tháng "+thang+" năm "+nam+" ?", gen.GetString("select Top 1 CompanyName from Center"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                DataTable da = gen.GetTable("select RefID,TotalAmount,TotalDiscountAmount from SSInvoice where Month(PURefDate)='" + thang + "' and YEAR(PURefDate)='" + nam + "' and TotalDiscountAmount>0");
                for (int i = 0; i < da.Rows.Count; i++)
                {
                    string ma = da.Rows[i][0].ToString();
                    Double tongtien = Double.Parse(da.Rows[i][1].ToString());
                    Double tongkhautru = Double.Parse(da.Rows[i][2].ToString());
                    Double khautru = Double.Parse(da.Rows[i][2].ToString());
                    DataTable temp = gen.GetTable("select RefDetailID,TotalAmount from SSInvoiceINOutward where SSInvoiceID='" + ma + "' order by SortOrder");
                    for (int j = 0; j < temp.Rows.Count; j++)
                    {
                        string macon = temp.Rows[j][0].ToString();
                        if (j == temp.Rows.Count - 1)
                        {
                            gen.ExcuteNonquery("update SSInvoiceINOutward set FreightAmount='" + khautru + "' where RefDetailID='" + macon + "'");
                        }
                        else
                        {
                            Double tien = Double.Parse(temp.Rows[j][1].ToString());
                            Double socuoi = Math.Round((tien / tongtien) * tongkhautru,0);
                            gen.ExcuteNonquery("update SSInvoiceINOutward set FreightAmount='" + socuoi + "' where RefDetailID='" + macon + "'");
                            khautru = khautru - socuoi;
                        }
                    }
                }
                    SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem44_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc muốn cập nhật vật tư hàng hóa theo kho ?", gen.GetString("select Top 1 CompanyName from Center"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string mahang = view.GetRowCellValue(i, "Mã hàng").ToString();                 
                    string kho = view.GetRowCellValue(i, "Mã kho").ToString().Replace("'", "''");
                    kho = gen.GetString("select StockID from Stock where StockCode='" + kho + "'");                  
                    string tyle = view.GetRowCellValue(i, "Tỷ lệ").ToString().Replace(",", ".");
                    string dongia = view.GetRowCellValue(i, "Đơn giá").ToString().Replace(",", ".");
                    DataTable temp = gen.GetTable("select InventoryItemID,InventoryItemName,Unit,ConvertUnit from InventoryItem where InventoryItemCode='" + mahang + "'");

                    string ma = temp.Rows[0][0].ToString();
                    string ten = temp.Rows[0][1].ToString();
                    string dvt = temp.Rows[0][2].ToString();
                    string dvqd = temp.Rows[0][3].ToString();

                    string sql;
                    try
                    {
                        string id = gen.GetString("select * from StockII where InventoryItemID='" + ma + "' and StockID='" + kho + "'");
                        sql = "update StockII set InventoryItemName=N'" + ten + "',Unit=N'" + dvt + "',ConvertUnit=N'" + dvqd + "',ConvertRate='" + tyle + "',UnitPrice='" + dongia + "',SalePrice='" + dongia + "'  where InventoryItemID='" + ma + "' and StockID='" + kho + "'";
                    }
                    catch
                    {
                        sql = "insert into StockII values(newid(),'" + ma + "',N'" + ten + "',N'" + dvt + "',N'" + dvqd + "','" + tyle + "','" + dongia + "','" + dongia + "','" + kho + "','" + mahang + "')";
                    }
                    gen.ExcuteNonquery(sql);
                }
                SplashScreenManager.CloseForm();
            }
        }

        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            for (int i = 0; i < view.RowCount; i++)
            {
                string sohopdong = view.GetRowCellValue(i, "SOHOPDONG").ToString();
                string loaihopdong = view.GetRowCellValue(i, "LOAIHOPDONG").ToString();

                string makhach = view.GetRowCellValue(i, "MAKHACH").ToString();
                makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
                string ngayky = view.GetRowCellValue(i, "NGAYKY").ToString();
                string ngayhethan = view.GetRowCellValue(i, "NGAYHETHAN").ToString();

                string kho = view.GetRowCellValue(i, "DONVIBANHANG").ToString();
                if (kho == "BPCU")
                    kho = "01";
                else if (kho == "BPBH")
                    kho = "17";
                else if (kho == "CH55")
                    kho = "05";
                else if (kho == "CHCD")
                    if (loaihopdong == "HĐTVC" || loaihopdong == "HĐMH")
                        kho = "20";
                    else kho = "30";
                else if (kho == "CHTN")
                    kho = "11";
                else if (kho == "CNBL")
                    kho = "12";
                else if (kho == "CNPQ")
                    kho = "36";
                else if (kho == "CNST")
                    kho = "22";
                else if (kho == "CNTP")
                    if (loaihopdong == "HĐMH")
                        kho = "06";
                    else kho = "15";
                else if (kho == "CNVT")
                    kho = "14";
                else if (kho == "HAMACO T&S")
                    kho = "10";
                else if (kho == "PKDSON")
                    kho = "41";
                else if (kho == "PKDXDDN")
                    kho = "23";

                kho = gen.GetString("select StockID from Stock where StockCode='" + kho + "'");

                if (loaihopdong == "HĐBH")
                    loaihopdong = "Bán hàng";
                else if (loaihopdong == "HĐCTK")
                    loaihopdong = "Cho thuê kho";
                else if (loaihopdong == "HĐMH")
                    loaihopdong = "Mua hàng";
                else if (loaihopdong == "HĐTVC")
                    loaihopdong = "Thuê vận chuyển";

                Double hanno = Double.Parse(view.GetRowCellValue(i, "NGAYNO").ToString());

                

                string ngaylap = view.GetRowCellValue(i, "GHI CHU").ToString();

                Double tinchap = 0;
                string pay = "1";
                if (Double.Parse(view.GetRowCellValue(i, "TINCHAP").ToString()) > 0)
                {
                    pay = "2";
                    tinchap = Double.Parse(view.GetRowCellValue(i, "TINCHAP").ToString());
                }
                else if (Double.Parse(view.GetRowCellValue(i, "BAOLANH").ToString()) > 0)
                {
                    pay = "3";
                    tinchap = Double.Parse(view.GetRowCellValue(i, "BAOLANH").ToString());
                }

                string noiluu = view.GetRowCellValue(i, "SOLUU").ToString();
                try
                {
                    string mahopdong = gen.GetString("select * from ContractB where ContractCode=N'" + sohopdong + "'");
                }
                catch
                {
                    gen.ExcuteNonquery("insert ContractB(ContractID,ContractCode,ContractName,StockID,AccountingObjectID,SignerName,Position,License,IssuedBy,Change,ChangeDate,CompanyTel,CompanyFax,CompanyBankAccount,CompanyBankName,Proxy,SignedDate,EffectiveDate,DebtLimit,LimitDate,NoPay,NoContract,DeliveryPlace,Saved,Founded,Send,Received,Closed,ClosedDate,ParentContract,No,Inactive)"
                      + "values(newid(),N'" + sohopdong + "',N'" + loaihopdong + "','" + kho + "','" + makhach + "',NULL,NULL,NULL,NULL,NULL,'"+ngaylap+"',NULL,NULL,NULL,NULL,NULL,'" + ngayky + "','" + ngayhethan + "',N'" + tinchap + "',N'" + hanno + "','" + pay + "','1',NULL,N'" + noiluu + "','" + ngaylap + "','" + ngaylap + "','" + ngaylap + "','0','" + ngayhethan + "',N'" + sohopdong + "',0,'1')");
                }
            }
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem46_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             SplashScreenManager.ShowForm(typeof(Frm_wait));
             for (int i = 0; i < view.RowCount-1; i++)
             {
                 string makho = view.GetRowCellValue(i, "Mã kho").ToString();
                 string ghichu = view.GetRowCellValue(i, "Ghi chú").ToString();
                 if (ghichu != "")
                 {
                     for (int j = 0; j < view.RowCount; j++)
                     {
                         string makhach = view.GetRowCellValue(i, "Mã Khách").ToString();
                     }
                 }
                
                 
                /*
                 if (makhach != "" && makho == "")
                     taikhoan = makhach;
                 if (makhach != "" && makho != "")
                 {
                     makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
                     makho = gen.GetString("select StockID from Stock where StockCode='" + makho + "'");
                 }
                 */
                 
             }
        }

        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            gen.ExcuteNonquery("delete from OpeningInventoryEntryAC where MONTH(PostedDate)='12' and YEAR(PostedDate)='2016'");
            for (int i = 0; i < view.RowCount; i++)
            {
                string makhach = view.GetRowCellValue(i, "Mã Khách").ToString();
                makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
                string mahang = view.GetRowCellValue(i, "Mã Hàng").ToString();
                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                Double soluong = Double.Parse(view.GetRowCellValue(i, "Số Lượng").ToString());
                Double sotien = 0;
                try
                {
                    sotien = Double.Parse(view.GetRowCellValue(i, "Số Tiền").ToString());
                }
                catch { }
                gen.ExcuteNonquery("insert into OpeningInventoryEntryAC values(newid(),'" + makhach + "','" + mahang + "', " + soluong + "," + sotien + ",'12/31/2016','0','D93A0F81-516C-41E8-A37F-14A0E27F581D')");
            }
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem48_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            for (int i = 0; i < view.RowCount; i++)
            {
                string makhach = "C1C6DC5C-C678-4B6E-978D-DC2358E34137";
                string tenkhach = view.GetRowCellValue(i, "Khách hàng").ToString();
                string diachi = view.GetRowCellValue(i, "Địa chỉ").ToString().Replace("'", "''");
                string sodt = view.GetRowCellValue(i, "Số ĐT").ToString();
                gen.ExcuteNonquery("insert into INOutwardLPG(RefID,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,CustomField8,Posted) values(newid(),'10/31/2009','10/31/2009','08-08-DDHL000009-10-09','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "','" + sodt + "','False')");
            }
            SplashScreenManager.CloseForm();
        }

        private void barButtonItem50_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(Frm_wait));
            for (int i = 0; i < view.RowCount; i++)
            {
                string nganhhang = view.GetRowCellValue(i, "NGÀNH HÀNG").ToString();
                string nhomhang = view.GetRowCellValue(i, "NHÓM HÀNG").ToString();
                string mahang = view.GetRowCellValue(i, "MÃ HÀNG").ToString();
                gen.ExcuteNonquery("update InventoryItem set SaleDescription=N'" + nganhhang + "',PurchaseDescription=N'" + nhomhang + "' where InventoryItemCode='" + mahang + "'");
            }
            SplashScreenManager.CloseForm();
        }

        private void bardonhanggaudo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu Gấu Đỏ 8A vào hệ thống ngày "+String.Format("{0:dd/MM/yyyy}",DateTime.Parse(ngaychungtu))+"?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='02'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số ĐH").ToString() != "")
                    {
                        string tenkhach = view.GetRowCellValue(i, "Tên KH").ToString();
                        string diachi = view.GetRowCellValue(i, "Địa chỉ").ToString();
                        string nhanvien = view.GetRowCellValue(i, "NVBH").ToString();
                        
                            nhanvien = gen.GetString("select AccountingObjectID from AccountingObject where IsEmployee='1' and  AccountingObjectName=N'" + nhanvien + "' and ContactTitle=N'Nhân viên kinh doanh'");
                        
                        string donhang = view.GetRowCellValue(i, "Số ĐH").ToString();
                        string mahang = "GAU" + view.GetRowCellValue(i, "Mã SP").ToString();
                        string donvi = view.GetRowCellValue(i, "Đơn vị").ToString();

                        if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                            mahang = "GAU" + view.GetRowCellValue(i, "Mã SP").ToString()+"KA";

                        if (mahang != "GAU" && mahang != "GAUKA")
                        {
                            /*try
                            {
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                            catch
                            {
                                string tensp = view.GetRowCellValue(i, "Tên SP").ToString();
                                string nhom = view.GetRowCellValue(i, "Ngành hàng con").ToString();
                                string quycach = view.GetRowCellValue(i, "Quy cách").ToString().ToString().Replace(",", ".");

                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tensp + "',N'Thùng',N'" + donvi + "','" + quycach + "','0','4CA47C44-D1BC-489F-B307-60968C73C024','False',0,N'Gấu Đỏ',N'" + nhom + "')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }*/
                            for (int j = 0; j < hang.Rows.Count; j++)
                                if (mahang.ToUpper() == hang.Rows[j][1].ToString().ToUpper())
                                {
                                    mahang = hang.Rows[j][0].ToString();
                                    break;
                                }
                            if (mahang.Length < 30)
                            {
                                string tensp = view.GetRowCellValue(i, "Tên SP").ToString();
                                string nhom = view.GetRowCellValue(i, "Ngành hàng con").ToString();
                                string quycach = view.GetRowCellValue(i, "Quy cách").ToString().ToString().Replace(",", ".");

                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tensp + "',N'Thùng',N'" + donvi + "','" + quycach + "','0','4CA47C44-D1BC-489F-B307-60968C73C024','False',0,N'Gấu Đỏ',N'" + nhom + "')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                        }
                        string soluong = view.GetRowCellValue(i, "Sản lượng bán (thùng)").ToString().ToString().Replace(",", ".");
                        string trongluong = view.GetRowCellValue(i, "Sản lượng quy đổi (gói)").ToString().ToString().Replace(",", ".");


                        string trongluongkm = view.GetRowCellValue(i, "SLKM (gói)").ToString().ToString().Replace(",", ".");

                        string dgsoluong = view.GetRowCellValue(i, "Giá (thùng)").ToString().ToString().Replace(",", ".");
                        string dgtrongluong = view.GetRowCellValue(i, "Giá (gói)").ToString().ToString().Replace(",", ".");

                        string doanhso = view.GetRowCellValue(i, "Doanh số NET").ToString().ToString().Replace(",", ".");
                        string chietkhau = view.GetRowCellValue(i, "Chiết khấu tiền").ToString().ToString().Replace(",", ".");

                        string chuongtrinh = view.GetRowCellValue(i, "CT HTTM").ToString();
                        /*
                        string makhach = "GAU" + view.GetRowCellValue(i, "Mã KH").ToString();
                        try
                        {
                            makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
                        }
                        catch
                        {
                            string sql = "insert into hamaco.dbo.AccountingObject(AccountingObjectID,AccountingObjectCode,AccountingObjectName,BranchID,Address,CompanyTaxCode,IdentificationNumber,IsPersonal,Inactive,IsVendor,IsCustomer,IsEmployee)  values(newid(),'" + makhach + "',N'" + tenkhach + "','" + "3E2C921B-DC8A-43F7-9D39-EBA9FBB4DA7E" +
                                      "',N'" + diachi + "','','','True','False','False','True','False')";
                            gen.ExcuteNonquery(sql);
                            gen.ExcuteNonquery("insert into hamaco_ta.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + makhach + "'");
                            gen.ExcuteNonquery("insert into hamaco_tn.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + makhach + "'");
                            gen.ExcuteNonquery("insert into hamaco_vithanh.dbo.AccountingObject select * from hamaco.dbo.AccountingObject where AccountingObjectCode='" + makhach + "'");
                            makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
                        }
                        */
                        //string makhach = "87DC3F60-8403-49B9-A0D9-E69ADCEA8F91";   
                        string makhach = nhanvien;                      

                        try
                        {
                            if (donhang != view.GetRowCellValue(i - 1, "Số ĐH").ToString())
                            {
                                if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                                    donhang = "KA" + donhang;
                                gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsct() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                refid = gen.GetString("select RefID from INOutward where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                                donhang = "KA" + donhang;
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsct() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                            refid = gen.GetString("select RefID from INOutward where JournalMemo=N'" + donhang + "'");
                        }

                        if (Double.Parse(chietkhau) != 0)
                            gen.ExcuteNonquery("update INOutward set TotalFreightAmount=TotalFreightAmount+'" + (0 - Double.Parse(chietkhau)).ToString() + "' where RefID='" + refid + "'");
                        else
                            if (Double.Parse(trongluong) != 0)
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",'" + mahang + "','0','" + Math.Round((Double.Parse(doanhso) / 1.1) / Double.Parse(trongluong), 2).ToString().Replace(",", ".") + "','" + Math.Round(Double.Parse(doanhso) / 1.1, 0) + "',0,0,0,0,'" + dgtrongluong + "','" + doanhso + "',0,0,'" + dgsoluong + "',0,0,N'" + chuongtrinh + "')");
                            else
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "',0,'" + trongluongkm + "'," + i + ",'" + mahang + "','0',0,0,0,0,0,0,0,0,0,0,0,0,0,N'" + chuongtrinh + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((B.TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/Cast(Tax as money),0) FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.Close();
            }
        }

        public string themsct()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = "07";
            string mk = "02";
            string idkho = gen.GetString("select * from Stock where StockCode='02'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            return sophieu;
        }

        public string themsct55()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = "07";
            string mk = "28";
            string idkho = gen.GetString("select * from Stock where StockCode='28'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            return sophieu;
        }

        public string themsctTN()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = "07";
            string mk = "35";
            string idkho = gen.GetString("select * from Stock where StockCode='35'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-PXKH";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from INOutward where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            return sophieu;
        }

        public string themscthoadon()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = "07";
            string mk = "02";
            string idkho = gen.GetString("select * from Stock where StockCode='02'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-DDHN";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from DDHNCC where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            return sophieu;
        }

        public string themscthoadon55()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = "07";
            string mk = "28";
            string idkho = gen.GetString("select * from Stock where StockCode='28'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-DDHN";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from DDHNCC where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            return sophieu;
        }

        public string themscthoadonTN()
        {
            DataTable da = new DataTable();
            int dai = 5;
            string branch = "07";
            string mk = "35";
            string idkho = gen.GetString("select * from Stock where StockCode='35'");
            string thang = DateTime.Parse(ngaychungtu).Month.ToString();
            if (thang.Length < 2) thang = "0" + thang;
            string year = DateTime.Parse(ngaychungtu).Year.ToString();
            string nam = "-" + thang + "-" + year.Substring(2, 2);
            string sophieu = branch + "-" + mk + "-DDHN";
            try
            {
                string id = gen.GetString("select Top 1 RefNo from DDHNCC where Month(RefDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and Year(RefDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "' and StockID='" + idkho + "'  order by RefNo DESC");
                int ct = Int32.Parse(id.Substring(10, dai)) + 1;
                for (int i = 0; i < dai - ct.ToString().Length; i++)
                {
                    sophieu = sophieu + "0";
                }
                sophieu = sophieu + ct.ToString() + nam;
            }
            catch { sophieu = sophieu + "00001" + nam; }
            return sophieu;
        }

        private void barcnhdu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu đơn mua hàng Unilever 8A vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='02'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Đơn mua hàng").ToString() != "")
                    {
                        string donhang = view.GetRowCellValue(i, "Đơn mua hàng").ToString();
                        string mahang = "UNI" + view.GetRowCellValue(i, "Vật tư").ToString();
                        string soluong = view.GetRowCellValue(i, "Slượng").ToString().ToString().Replace(",", ".");
                        string trongluong = view.GetRowCellValue(i, "Số lượng").ToString().ToString().Replace(",", ".");
                        //mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                        if (mahang != "UNI")
                            try
                            {
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'',N'CS',N'SU','" + Math.Round(Double.Parse(trongluong)/Double.Parse(soluong),2).ToString() + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                       
                        string doanhso = view.GetRowCellValue(i, "Tổng tiền").ToString().ToString().Replace(",", ".");    
                        string dgtrongluong = Math.Round(Double.Parse(doanhso)/Double.Parse(trongluong),2).ToString();                                               
                        try
                        {
                            if (donhang != view.GetRowCellValue(i - 1, "Đơn mua hàng").ToString())
                            {
                                gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadon() + "','21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6',N'CÔNG TY TNHH QUỐC TẾ UNILEVER VIỆT NAM',N'Lô A2-3 KCN Tây Bắc Củ Chi Xã Tân An Hội , Xã Tân An Hội, Huyện Củ Chi, TP Hồ Chí Minh',N'',N'"+donhang+"',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                                refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadon() + "','21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6',N'CÔNG TY TNHH QUỐC TẾ UNILEVER VIỆT NAM',N'Lô A2-3 KCN Tây Bắc Củ Chi Xã Tân An Hội , Xã Tân An Hội, Huyện Củ Chi, TP Hồ Chí Minh',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                            refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                        }
                        gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",0,'" + mahang + "',0,'" + dgtrongluong + "','" + doanhso + "',0,0,0,0,0,0,0,'" + soluong + "','" + trongluong + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round(B.TotalAmount/Cast(CustomField9 as money),0) FROM (select * from DDHNCC where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from DDHNCCDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void bardonhangU_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu Unilever 8A vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='02'");
                string refid = null;
                string loaidonhang="ZID6";
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số chuyến hàng").ToString() != "")
                    {
                        if (view.GetRowCellValue(i, "Loại đơn hàng").ToString().ToUpper() != loaidonhang.ToUpper())
                        {
                            string diachi = "";
                            string tenkhach = view.GetRowCellValue(i, "Tên cửa hàng").ToString();
                            string nhanvien = "UNI" + view.GetRowCellValue(i, "Mã số NVTT").ToString();
                            string doi = null;
                            for (int j = 0; j < khachuni.Rows.Count; j++)
                                if (khachuni.Rows[j][1].ToString().ToUpper() == nhanvien.ToUpper())
                                {
                                    nhanvien = khachuni.Rows[j][0].ToString();
                                    doi = khachuni.Rows[j][2].ToString();
                                    break;
                                }
                            //nhanvien = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode=N'" + nhanvien + "'");
                            string donhang = view.GetRowCellValue(i, "Số đơn đặt hàng").ToString();

                            string quycach = view.GetRowCellValue(i, "Đóng gói").ToString().ToString().Replace(",", ".");
                            string mahang = "UNI" + view.GetRowCellValue(i, "Số sản phẩm").ToString();
                            string tenhang = view.GetRowCellValue(i, "Mô tả mặt hàng").ToString().Replace("'", "''");
                            if (mahang != "UNI")
                            {
                                /*try
                                {
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }
                                catch
                                {
                                    gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tenhang + "',N'CS',N'SU','" + quycach + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }*/
                                 for (int j = 0; j < hang.Rows.Count; j++)
                                     if (mahang.ToUpper() == hang.Rows[j][1].ToString().ToUpper())
                                     {
                                         mahang = hang.Rows[j][0].ToString();
                                         break;
                                     }
                                 if (mahang.Length < 30)
                                 {
                                     gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tenhang + "',N'CS',N'SU','" + quycach + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                     mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                 }
                            }
                            string soluong = view.GetRowCellValue(i, "Số lượng CS").ToString().ToString().Replace(",", ".");
                            string trongluong = view.GetRowCellValue(i, "Số lượng SU").ToString().ToString().Replace(",", ".");
                            trongluong = (Double.Parse(soluong) * Double.Parse(quycach) + Double.Parse(trongluong)).ToString().Replace(",", ".");

                            string soluongkm = view.GetRowCellValue(i, "Số lượng KM giao (CS)").ToString().ToString().Replace(",", ".");
                            string trongluongkm = view.GetRowCellValue(i, "Số lượng KM giao (PC)").ToString().ToString().Replace(",", ".");
                            trongluongkm = (Double.Parse(soluongkm) * Double.Parse(quycach) + Double.Parse(trongluongkm)).ToString().Replace(",", ".");
                           
                            string doanhso = view.GetRowCellValue(i, "Doanh số GSV").ToString().ToString().Replace(",", ".");
                            string doanhsotruocthue = view.GetRowCellValue(i, "Doanh số GSV").ToString().ToString().Replace(",", ".");
                            /*string doanhsoniv = view.GetRowCellValue(i, "Doanh số NIV").ToString().ToString().Replace(",", ".");

                            string chietkhau = "0";
                            if (Double.Parse(doanhso) != Double.Parse(doanhsoniv))
                                chietkhau = Math.Round((Double.Parse(doanhso) - Double.Parse(doanhsoniv)) * 1.1, 0).ToString().Replace(",", ".");*/
                            
                            string chietkhau = view.GetRowCellValue(i, "Doanh thu").ToString().ToString().Replace(",", ".");

                            doanhso = Math.Round(Double.Parse(doanhso) * 1.1, 0).ToString().Replace(",", ".");

                            string dgsoluong = "0";
                            if (Double.Parse(soluong) != 0)
                                dgsoluong = (Double.Parse(doanhso) / Double.Parse(soluong)).ToString().Replace(",", ".");
                            string dgtrongluong = "0";
                            if (Double.Parse(trongluong) != 0)
                                dgtrongluong = (Double.Parse(doanhso) / Double.Parse(trongluong)).ToString().Replace(",", ".");

                            //string makhach = "19B467F8-0D49-43B7-B7CB-67C807B9E38A";
                            string makhach = nhanvien;
                            try
                            {
                                if (donhang != view.GetRowCellValue(i - 1, "Số đơn đặt hàng").ToString())
                                {
                                    donhang = "UNI" + donhang;
                                    gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsct() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'" + doi + "','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                    refid = gen.GetString("select RefID from INOutward where StockID='" + makho + "' and JournalMemo=N'" + donhang + "'");
                                }
                            }
                            catch
                            {
                                donhang = "UNI" + donhang;
                                gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsct() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'" + doi + "','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                refid = gen.GetString("select RefID from INOutward where StockID='" + makho + "' and JournalMemo=N'" + donhang + "'");
                            }
                            //if (Double.Parse(chietkhau) != 0)
                                gen.ExcuteNonquery("update INOutward set TotalFreightAmount=TotalFreightAmount+'" + Double.Parse(chietkhau).ToString() + "' where RefID='" + refid + "'");
                            
                            if (Double.Parse(trongluong) != 0)
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",'" + mahang + "','0','" + Math.Round(Double.Parse(doanhsotruocthue) / Double.Parse(trongluong), 2).ToString().Replace(",", ".") + "','" + doanhsotruocthue + "',0,0,0,0,'" + dgtrongluong + "','" + doanhso + "',0,0,'" + dgsoluong + "',0,0,N'')");
                            else
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluongkm + "','" + trongluongkm + "'," + i + ",'" + mahang + "','0',0,0,0,0,0,0,0,0,0,0,0,0,0,N'')");
                        }
                    }
                }
                //gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((B.TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/Cast(Tax as money),0) FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((TotalFreightAmount/(1+Cast(Tax as money)/100))/10,0),TotalFreightAmount=B.TotalAmount*(1+Cast(Tax as money)/100)-TotalFreightAmount FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barcndhu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu đơn mua hàng Gấu Đỏ vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='02'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số đơn hàng bán (SO)").ToString() != "")
                    {
                        string donhang = view.GetRowCellValue(i, "Số đơn hàng bán (SO)").ToString();
                        string mahang = "GAU" + view.GetRowCellValue(i, "Mã SP bán").ToString();
                        if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                            mahang = "GAU" + view.GetRowCellValue(i, "Mã SP bán").ToString() + "KA";
                        
                        Double tyle = Double.Parse(view.GetRowCellValue(i, "Quy cách").ToString());

                        string trongluong = view.GetRowCellValue(i, "Số lượng gói quy đổi").ToString();

                        string soluong = Math.Round(Double.Parse(trongluong) / tyle, 0).ToString();

                        if (mahang != "GAU" && mahang!="GAUKA")
                            try
                            {
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                            catch
                            {
                                string tensp = view.GetRowCellValue(i, "Tên SP bán").ToString();
                                string nhom = view.GetRowCellValue(i, "Ngành hàng con").ToString();
                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tensp + "',N'Thùng',N'gói','" + tyle + "','0','4CA47C44-D1BC-489F-B307-60968C73C024','False',0,N'Gấu Đỏ',N'" + nhom + "')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }                       

                        string doanhso = view.GetRowCellValue(i, "Thành tiền").ToString().ToString().Replace(",", ".");
                        
                        string dgtrongluong = Math.Round(Double.Parse(doanhso) / Double.Parse(trongluong), 2).ToString().ToString().Replace(",", ".");
                        try
                        {
                            if (donhang != view.GetRowCellValue(i - 1, "Số đơn hàng bán (SO)").ToString())
                            {
                                gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadon() + "','10E6D9B7-A3D2-4149-9A22-7DDF3562C93E',N'CÔNG TY CỔ PHẦN THỰC PHẨM Á CHÂU',N'Số 9/2 đường ĐT 743, Khu phố 1B, Phường An Phú, TX Thuận An, Tỉnh Bình Dương',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                                refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadon() + "','10E6D9B7-A3D2-4149-9A22-7DDF3562C93E',N'CÔNG TY CỔ PHẦN THỰC PHẨM Á CHÂU',N'Số 9/2 đường ĐT 743, Khu phố 1B, Phường An Phú, TX Thuận An, Tỉnh Bình Dương',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                            refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                        }
                        gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",0,'" + mahang + "',0,'" + dgtrongluong + "','" + doanhso + "',0,0,0,0,0,0,0,'" + soluong + "','" + trongluong + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round(B.TotalAmount/Cast(CustomField9 as money),0) FROM (select * from DDHNCC where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from DDHNCCDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barcncnhtd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ công nợ hàng tiêu dùng vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string donhang = view.GetRowCellValue(i, "Đơn hàng").ToString();
                    string ngay = DateTime.Parse(view.GetRowCellValue(i, "Ngày").ToString()).ToShortDateString();
                    string khachhang = view.GetRowCellValue(i, "Tên khách hàng").ToString();
                    string sotien = view.GetRowCellValue(i, "Số tiền").ToString().Replace(",", ".");
                    string conno = view.GetRowCellValue(i, "Nợ").ToString().Replace(",", ".");
                    string nhanvien = view.GetRowCellValue(i, "Nhân viên").ToString();
                    string chuagiao = view.GetRowCellValue(i, "Chưa giao").ToString();
                    string ghichu = view.GetRowCellValue(i, "Ghi chú").ToString();
                    string nganh = view.GetRowCellValue(i, "Ngành").ToString();
                    gen.ExcuteNonquery("insert OpeningAccountEntry131TTBackup values(NEWID(),'" + donhang + "','" + ngay + "',N'" + khachhang + "','" + sotien + "','" + conno + "',N'" + nganh + "',N'" + nhanvien + "',N'" + chuagiao + "',N'" + ghichu + "',0,'" + DateTime.Parse(ngaychungtu).ToShortDateString() + "')");
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void barcnshd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ mã hóa đơn và mã đơn hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string donhang = "UNI"+view.GetRowCellValue(i, "Mã đơn hàng").ToString();
                    string mahoadon = "UNI"+view.GetRowCellValue(i, "Mã hóa đơn").ToString();
                    if (donhang != "" && mahoadon != "")
                        gen.ExcuteNonquery("update INOutward set ParalellRefNo='" + mahoadon + "' where JournalMemo='" + donhang + "' ");
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void Form_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Dispose();
        }

        private void barcnctkm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ chương trình khuyến mãi chiết khấu Unilever vào hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string mahoadon = "UNI" + view.GetRowCellValue(i, "Số hóa đơn").ToString();
                    string loaihoadon = view.GetRowCellValue(i, "Loại hóa đơn").ToString();
                    if (mahoadon != "" && loaihoadon == "Invoice")
                    {
                        string makhuyenmai = view.GetRowCellValue(i, "Mã khuyến mã").ToString();
                        string chuongtrinh = view.GetRowCellValue(i, "CTKM").ToString();
                        string tennhanvien = view.GetRowCellValue(i, "NVBH").ToString();
                        string sotien = view.GetRowCellValue(i, "Số tiền KM đã sử dụng").ToString().Replace(",", ".");

                        Double k = (Double) char.Parse(makhuyenmai.Substring(0,1));

                        if ((chuongtrinh == "PERSTR" || chuongtrinh == "OCCDIS" || chuongtrinh == "LTYPRG") && (Math.Round(k / 2, 0) - (k / 2) != 0))
                            sotien = Math.Round(Double.Parse(sotien) / 1.1, 0).ToString();
                        string ngaybatdau = DateTime.Parse(view.GetRowCellValue(i, "Ngày bắt đầu khuyến mãi").ToString()).ToShortDateString();
                        string ngayketthuc = "NULL";
                        if (view.GetRowCellValue(i, "Ngày kết thúc").ToString() != "")
                            ngayketthuc = "'"+DateTime.Parse(view.GetRowCellValue(i, "Ngày kết thúc").ToString()).ToShortDateString()+"'";
                        string ngayketthucsua = "NULL";
                        if (view.GetRowCellValue(i, "N#k#thúc đã sửa").ToString() != "")
                            ngayketthucsua = "'"+DateTime.Parse(view.GetRowCellValue(i, "N#k#thúc đã sửa").ToString()).ToShortDateString()+"'";
                        string mahang = "UNI"+view.GetRowCellValue(i, "Free Gift Code").ToString();
                        string soluong = view.GetRowCellValue(i, "Hàng khuyến mãi (Số lượng)UOM-PC").ToString().Replace(",", ".");
                        if (Double.Parse(sotien) >= 0)
                            gen.ExcuteNonquery("insert into INOutwardCheck values(NEWID(),'" + mahoadon + "','" + makhuyenmai + "','" + chuongtrinh + "',N'" + tennhanvien + "','" + sotien + "','" + ngaybatdau + "'," + ngayketthuc + "," + ngayketthucsua + ",'0',NULL,'" + mahang + "','" + soluong + "')");
                    }
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void barcndldcgd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ chương trình khuyến mãi chiết khấu Gấu Đỏ vào hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string mahoadon = view.GetRowCellValue(i, "Số ĐH").ToString();
                    string loaihoadon = view.GetRowCellValue(i, "Loại khuyến mãi").ToString();
                    if (loaihoadon != "")
                    {
                        if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                            mahoadon = "KA" + mahoadon;
                        string makhuyenmai = view.GetRowCellValue(i, "CT HTTM").ToString();
                        string chuongtrinh = view.GetRowCellValue(i, "Loại khuyến mãi").ToString();
                        string tennhanvien = view.GetRowCellValue(i, "NVBH").ToString();
                        string sotien = Math.Round((0-Double.Parse(view.GetRowCellValue(i, "Doanh số NET").ToString())/1.1),0).ToString();
                        string ngaybatdau = "NULL";
                        string ngayketthuc = "NULL";
                        string ngayketthucsua = "NULL";
                        string mahang = "GAU" + view.GetRowCellValue(i, "Mã SP").ToString();
                        string soluong = soluong = view.GetRowCellValue(i, "SLKM (gói)").ToString().Replace(",", ".");

                        if (Double.Parse(sotien) >= 0)
                            gen.ExcuteNonquery("insert into INOutwardCheck values(NEWID(),'" + mahoadon + "','" + makhuyenmai + "',N'" + chuongtrinh + "',N'" + tennhanvien + "','" + sotien + "'," + ngaybatdau + "," + ngayketthuc + "," + ngayketthucsua + ",'0','" + ngaychungtu + "','" + mahang + "'," + soluong + ")");
                    }
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void bardonhangU55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu Unilever vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='28'");
                string refid = null;
                string loaidonhang = "ZID6";
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số chuyến hàng").ToString() != "")
                    {
                        if (view.GetRowCellValue(i, "Loại đơn hàng").ToString().ToUpper() != loaidonhang.ToUpper())
                        {
                            string diachi = "";
                            string tenkhach = view.GetRowCellValue(i, "Tên cửa hàng").ToString();
                            string nhanvien = "UNI" + view.GetRowCellValue(i, "Mã số NVTT").ToString();

                            for (int j = 0; j < khachuni.Rows.Count; j++)
                                if (khachuni.Rows[j][1].ToString().ToUpper() == nhanvien.ToUpper())
                                {
                                    nhanvien = khachuni.Rows[j][0].ToString();
                                    break;
                                }

                            //nhanvien = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode=N'" + nhanvien + "'");
                            string donhang = view.GetRowCellValue(i, "Số đơn đặt hàng").ToString();

                            string quycach = view.GetRowCellValue(i, "Đóng gói").ToString().ToString().Replace(",", ".");
                            string mahang = "UNI" + view.GetRowCellValue(i, "Số sản phẩm").ToString();
                            string tenhang = view.GetRowCellValue(i, "Mô tả mặt hàng").ToString().Replace("'", "''");
                            if (mahang != "UNI")
                            {
                                /*try
                                {
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }
                                catch
                                {
                                    gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tenhang + "',N'CS',N'SU','" + quycach + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }*/
                                for (int j = 0; j < hang.Rows.Count; j++)
                                    if (mahang.ToUpper() == hang.Rows[j][1].ToString().ToUpper())
                                    {
                                        mahang = hang.Rows[j][0].ToString();
                                        break;
                                    }
                                if (mahang.Length < 30)
                                {
                                    gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tenhang + "',N'CS',N'SU','" + quycach + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }

                            }
                            string soluong = view.GetRowCellValue(i, "Số lượng CS").ToString().ToString().Replace(",", ".");
                            string trongluong = view.GetRowCellValue(i, "Số lượng SU").ToString().ToString().Replace(",", ".");
                            trongluong = (Double.Parse(soluong) * Double.Parse(quycach) + Double.Parse(trongluong)).ToString().Replace(",", ".");

                            string soluongkm = view.GetRowCellValue(i, "Số lượng KM giao (CS)").ToString().ToString().Replace(",", ".");
                            string trongluongkm = view.GetRowCellValue(i, "Số lượng KM giao (PC)").ToString().ToString().Replace(",", ".");
                            trongluongkm = (Double.Parse(soluongkm) * Double.Parse(quycach) + Double.Parse(trongluongkm)).ToString().Replace(",", ".");

                            string doanhso = view.GetRowCellValue(i, "Doanh số GSV").ToString().ToString().Replace(",", ".");
                            string doanhsotruocthue = view.GetRowCellValue(i, "Doanh số GSV").ToString().ToString().Replace(",", ".");
                            /*string doanhsoniv = view.GetRowCellValue(i, "Doanh số NIV").ToString().ToString().Replace(",", ".");

                            string chietkhau = "0";
                            if (Double.Parse(doanhso) != Double.Parse(doanhsoniv))
                                chietkhau = Math.Round((Double.Parse(doanhso) - Double.Parse(doanhsoniv)) * 1.1, 0).ToString().Replace(",", ".");*/

                            string chietkhau = view.GetRowCellValue(i, "Doanh thu").ToString().ToString().Replace(",", ".");

                            doanhso = Math.Round(Double.Parse(doanhso) * 1.1, 0).ToString().Replace(",", ".");

                            string dgsoluong = "0";
                            if (Double.Parse(soluong) != 0)
                                dgsoluong = (Double.Parse(doanhso) / Double.Parse(soluong)).ToString().Replace(",", ".");
                            string dgtrongluong = "0";
                            if (Double.Parse(trongluong) != 0)
                                dgtrongluong = (Double.Parse(doanhso) / Double.Parse(trongluong)).ToString().Replace(",", ".");

                            //string makhach = "19B467F8-0D49-43B7-B7CB-67C807B9E38A";
                            string makhach = nhanvien;
                            try
                            {
                                if (donhang != view.GetRowCellValue(i - 1, "Số đơn đặt hàng").ToString())
                                {
                                    donhang = "UNI55" + donhang;
                                    gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsct55() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                    refid = gen.GetString("select RefID from INOutward where StockID='" + makho + "' and JournalMemo=N'" + donhang + "'");
                                }
                            }
                            catch
                            {
                                donhang = "UNI55" + donhang;
                                gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsct55() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                refid = gen.GetString("select RefID from INOutward where StockID='" + makho + "' and JournalMemo=N'" + donhang + "'");
                            }
                            //if (Double.Parse(chietkhau) != 0)
                            gen.ExcuteNonquery("update INOutward set TotalFreightAmount=TotalFreightAmount+'" + Double.Parse(chietkhau).ToString() + "' where RefID='" + refid + "'");

                            if (Double.Parse(trongluong) != 0)
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",'" + mahang + "','0','" + Math.Round(Double.Parse(doanhsotruocthue) / Double.Parse(trongluong), 2).ToString().Replace(",", ".") + "','" + doanhsotruocthue + "',0,0,0,0,'" + dgtrongluong + "','" + doanhso + "',0,0,'" + dgsoluong + "',0,0,N'')");
                            else
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluongkm + "','" + trongluongkm + "'," + i + ",'" + mahang + "','0',0,0,0,0,0,0,0,0,0,0,0,0,0,N'')");
                        }
                    }
                }
                //gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((B.TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/Cast(Tax as money),0) FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((TotalFreightAmount/(1+Cast(Tax as money)/100))/10,0),TotalFreightAmount=B.TotalAmount*(1+Cast(Tax as money)/100)-TotalFreightAmount FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barcnhdu55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu đơn mua hàng Unilever vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='28'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Đơn mua hàng").ToString() != "")
                    {
                        string donhang = view.GetRowCellValue(i, "Đơn mua hàng").ToString();
                        string mahang = "UNI" + view.GetRowCellValue(i, "Vật tư").ToString();
                        string soluong = view.GetRowCellValue(i, "Slượng").ToString().ToString().Replace(",", ".");
                        string trongluong = view.GetRowCellValue(i, "Số lượng").ToString().ToString().Replace(",", ".");
                        //mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                        if (mahang != "UNI")
                            try
                            {
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'',N'CS',N'SU','" + Math.Round(Double.Parse(trongluong) / Double.Parse(soluong), 2).ToString() + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }

                        string doanhso = view.GetRowCellValue(i, "Tổng tiền").ToString().ToString().Replace(",", ".");
                        string dgtrongluong = Math.Round(Double.Parse(doanhso) / Double.Parse(trongluong), 2).ToString();
                        try
                        {
                            if (donhang != view.GetRowCellValue(i - 1, "Đơn mua hàng").ToString())
                            {
                                gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadon55() + "','21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6',N'CÔNG TY TNHH QUỐC TẾ UNILEVER VIỆT NAM',N'Lô A2-3 KCN Tây Bắc Củ Chi Xã Tân An Hội , Xã Tân An Hội, Huyện Củ Chi, TP Hồ Chí Minh',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                                refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadon55() + "','21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6',N'CÔNG TY TNHH QUỐC TẾ UNILEVER VIỆT NAM',N'Lô A2-3 KCN Tây Bắc Củ Chi Xã Tân An Hội , Xã Tân An Hội, Huyện Củ Chi, TP Hồ Chí Minh',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                            refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                        }
                        gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",0,'" + mahang + "',0,'" + dgtrongluong + "','" + doanhso + "',0,0,0,0,0,0,0,'" + soluong + "','" + trongluong + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round(B.TotalAmount/Cast(CustomField9 as money),0) FROM (select * from DDHNCC where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from DDHNCCDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void bardonhangUTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu Unilever Thốt Nốt vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='35'");
                string refid = null;
                string loaidonhang = "ZID6";
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số chuyến hàng").ToString() != "")
                    {
                        if (view.GetRowCellValue(i, "Loại đơn hàng").ToString().ToUpper() != loaidonhang.ToUpper())
                        {
                            string diachi = "";
                            string tenkhach = view.GetRowCellValue(i, "Tên cửa hàng").ToString();
                            string nhanvien = "UNI" + view.GetRowCellValue(i, "Mã số NVTT").ToString();
                            string doi = null;
                            for (int j = 0; j < khachuni.Rows.Count; j++)
                                if (khachuni.Rows[j][1].ToString().ToUpper() == nhanvien.ToUpper())
                                {
                                    nhanvien = khachuni.Rows[j][0].ToString();
                                    doi = khachuni.Rows[j][2].ToString();
                                    break;
                                }
                            //nhanvien = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode=N'" + nhanvien + "'");
                            
                            string donhang = view.GetRowCellValue(i, "Số đơn đặt hàng").ToString();

                            string quycach = view.GetRowCellValue(i, "Đóng gói").ToString().ToString().Replace(",", ".");
                            string mahang = "UNI" + view.GetRowCellValue(i, "Số sản phẩm").ToString();
                            string tenhang = view.GetRowCellValue(i, "Mô tả mặt hàng").ToString().Replace("'", "''");

                            if (mahang != "UNI")
                            {
                                /*try
                                {
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }
                                catch
                                {
                                    gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tenhang + "',N'CS',N'SU','" + quycach + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }*/
                                for (int j = 0; j < hang.Rows.Count; j++)
                                    if (mahang.ToUpper() == hang.Rows[j][1].ToString().ToUpper())
                                    {
                                        mahang = hang.Rows[j][0].ToString();
                                        break;
                                    }
                                if (mahang.Length < 30)
                                {
                                    gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tenhang + "',N'CS',N'SU','" + quycach + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                    mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                                }
                            }

                            string soluong = view.GetRowCellValue(i, "Số lượng CS").ToString().ToString().Replace(",", ".");
                            string trongluong = view.GetRowCellValue(i, "Số lượng SU").ToString().ToString().Replace(",", ".");
                            trongluong = (Double.Parse(soluong) * Double.Parse(quycach) + Double.Parse(trongluong)).ToString().Replace(",", ".");

                            string soluongkm = view.GetRowCellValue(i, "Số lượng KM giao (CS)").ToString().ToString().Replace(",", ".");
                            string trongluongkm = view.GetRowCellValue(i, "Số lượng KM giao (PC)").ToString().ToString().Replace(",", ".");
                            trongluongkm = (Double.Parse(soluongkm) * Double.Parse(quycach) + Double.Parse(trongluongkm)).ToString().Replace(",", ".");

                            string doanhso = view.GetRowCellValue(i, "Doanh số GSV").ToString().ToString().Replace(",", ".");
                            string doanhsotruocthue = view.GetRowCellValue(i, "Doanh số GSV").ToString().ToString().Replace(",", ".");
                            /*string doanhsoniv = view.GetRowCellValue(i, "Doanh số NIV").ToString().ToString().Replace(",", ".");

                            string chietkhau = "0";
                            if (Double.Parse(doanhso) != Double.Parse(doanhsoniv))
                                chietkhau = Math.Round((Double.Parse(doanhso) - Double.Parse(doanhsoniv)) * 1.1, 0).ToString().Replace(",", ".");*/

                            string chietkhau = view.GetRowCellValue(i, "Doanh thu").ToString().ToString().Replace(",", ".");

                            doanhso = Math.Round(Double.Parse(doanhso) * 1.1, 0).ToString().Replace(",", ".");

                            string dgsoluong = "0";
                            if (Double.Parse(soluong) != 0)
                                dgsoluong = (Double.Parse(doanhso) / Double.Parse(soluong)).ToString().Replace(",", ".");
                            string dgtrongluong = "0";
                            if (Double.Parse(trongluong) != 0)
                                dgtrongluong = (Double.Parse(doanhso) / Double.Parse(trongluong)).ToString().Replace(",", ".");

                            //string makhach = "19B467F8-0D49-43B7-B7CB-67C807B9E38A";
                            string makhach = nhanvien;
                            try
                            {
                                if (donhang != view.GetRowCellValue(i - 1, "Số đơn đặt hàng").ToString())
                                {
                                    donhang = "UNITN" + donhang;
                                    gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsctTN() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'" + doi + "','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                    refid = gen.GetString("select RefID from INOutward where StockID='" + makho + "' and JournalMemo=N'" + donhang + "'");
                                }
                            }
                            catch
                            {
                                donhang = "UNITN" + donhang;
                                gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsctTN() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'" + doi + "','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                refid = gen.GetString("select RefID from INOutward where StockID='" + makho + "' and JournalMemo=N'" + donhang + "'");
                            }
                            //if (Double.Parse(chietkhau) != 0)
                            gen.ExcuteNonquery("update INOutward set TotalFreightAmount=TotalFreightAmount+'" + Double.Parse(chietkhau).ToString() + "' where RefID='" + refid + "'");

                            if (Double.Parse(trongluong) != 0)
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",'" + mahang + "','0','" + Math.Round(Double.Parse(doanhsotruocthue) / Double.Parse(trongluong), 2).ToString().Replace(",", ".") + "','" + doanhsotruocthue + "',0,0,0,0,'" + dgtrongluong + "','" + doanhso + "',0,0,'" + dgsoluong + "',0,0,N'')");
                            else
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluongkm + "','" + trongluongkm + "'," + i + ",'" + mahang + "','0',0,0,0,0,0,0,0,0,0,0,0,0,0,N'')");
                        }
                    }
                }
                //gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((B.TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/Cast(Tax as money),0) FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((TotalFreightAmount/(1+Cast(Tax as money)/100))/10,0),TotalFreightAmount=B.TotalAmount*(1+Cast(Tax as money)/100)-TotalFreightAmount FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barcnhduTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu đơn mua hàng Unilever Thốt Nốt vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='35'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Đơn mua hàng").ToString() != "")
                    {
                        string donhang = view.GetRowCellValue(i, "Đơn mua hàng").ToString();
                        string mahang = "UNI" + view.GetRowCellValue(i, "Vật tư").ToString();
                        string soluong = view.GetRowCellValue(i, "Slượng").ToString().ToString().Replace(",", ".");
                        string trongluong = view.GetRowCellValue(i, "Số lượng").ToString().ToString().Replace(",", ".");
                        //mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                        if (mahang != "UNI")
                            try
                            {
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                            catch
                            {
                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'',N'CS',N'SU','" + Math.Round(Double.Parse(trongluong) / Double.Parse(soluong), 2).ToString() + "','0','07856ABC-9755-4F18-BC3A-65AF11C8D192','False',0,N'',N'')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }

                        string doanhso = view.GetRowCellValue(i, "Tổng tiền").ToString().ToString().Replace(",", ".");
                        string dgtrongluong = Math.Round(Double.Parse(doanhso) / Double.Parse(trongluong), 2).ToString();
                        try
                        {
                            if (donhang != view.GetRowCellValue(i - 1, "Đơn mua hàng").ToString())
                            {
                                gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadonTN() + "','21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6',N'CÔNG TY TNHH QUỐC TẾ UNILEVER VIỆT NAM',N'Lô A2-3 KCN Tây Bắc Củ Chi Xã Tân An Hội , Xã Tân An Hội, Huyện Củ Chi, TP Hồ Chí Minh',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                                refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadonTN() + "','21EA1C1A-6A9A-4E81-86E6-A3B5D37989A6',N'CÔNG TY TNHH QUỐC TẾ UNILEVER VIỆT NAM',N'Lô A2-3 KCN Tây Bắc Củ Chi Xã Tân An Hội , Xã Tân An Hội, Huyện Củ Chi, TP Hồ Chí Minh',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                            refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                        }
                        gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",0,'" + mahang + "',0,'" + dgtrongluong + "','" + doanhso + "',0,0,0,0,0,0,0,'" + soluong + "','" + trongluong + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round(B.TotalAmount/Cast(CustomField9 as money),0) FROM (select * from DDHNCC where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from DDHNCCDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barButtonItem53_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ mã hóa đơn và mã đơn hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string donhang = "UNI55" + view.GetRowCellValue(i, "Mã đơn hàng").ToString();
                    string mahoadon = "UNI55" + view.GetRowCellValue(i, "Mã hóa đơn").ToString();
                    if (donhang != "" && mahoadon != "")
                        gen.ExcuteNonquery("update INOutward set ParalellRefNo='" + mahoadon + "' where JournalMemo='" + donhang + "' ");
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void barButtonItem54_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ chương trình khuyến mãi chiết khấu Unilever vào hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string mahoadon = "UNI55" + view.GetRowCellValue(i, "Số hóa đơn").ToString();
                    string loaihoadon = view.GetRowCellValue(i, "Loại hóa đơn").ToString();
                    if (mahoadon != "" && loaihoadon == "Invoice")
                    {
                        string makhuyenmai = view.GetRowCellValue(i, "Mã khuyến mã").ToString();
                        string chuongtrinh = view.GetRowCellValue(i, "CTKM").ToString();
                        string tennhanvien = view.GetRowCellValue(i, "NVBH").ToString();
                        string sotien = view.GetRowCellValue(i, "Số tiền KM đã sử dụng").ToString().Replace(",", ".");

                        Double k = (Double)char.Parse(makhuyenmai.Substring(0, 1));

                        if ((chuongtrinh == "PERSTR" || chuongtrinh == "OCCDIS" || chuongtrinh == "LTYPRG") && (Math.Round(k / 2, 0) - (k / 2) != 0))
                            sotien = Math.Round(Double.Parse(sotien) / 1.1, 0).ToString();
                        string ngaybatdau = DateTime.Parse(view.GetRowCellValue(i, "Ngày bắt đầu khuyến mãi").ToString()).ToShortDateString();
                        string ngayketthuc = "NULL";
                        if (view.GetRowCellValue(i, "Ngày kết thúc").ToString() != "")
                            ngayketthuc = "'" + DateTime.Parse(view.GetRowCellValue(i, "Ngày kết thúc").ToString()).ToShortDateString() + "'";
                        string ngayketthucsua = "NULL";
                        if (view.GetRowCellValue(i, "N#k#thúc đã sửa").ToString() != "")
                            ngayketthucsua = "'" + DateTime.Parse(view.GetRowCellValue(i, "N#k#thúc đã sửa").ToString()).ToShortDateString() + "'";
                        string mahang = "UNI" + view.GetRowCellValue(i, "Free Gift Code").ToString();
                        string soluong = view.GetRowCellValue(i, "Hàng khuyến mãi (Số lượng)UOM-PC").ToString().Replace(",", ".");
                        if (Double.Parse(sotien) >= 0)
                            gen.ExcuteNonquery("insert into INOutwardCheck values(NEWID(),'" + mahoadon + "','" + makhuyenmai + "','" + chuongtrinh + "',N'" + tennhanvien + "','" + sotien + "','" + ngaybatdau + "'," + ngayketthuc + "," + ngayketthucsua + ",'0',NULL,'" + mahang + "','" + soluong + "')");
                    }
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void barButtonItem55_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ mã hóa đơn và mã đơn hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string donhang = "UNITN" + view.GetRowCellValue(i, "Mã đơn hàng").ToString();
                    string mahoadon = "UNITN" + view.GetRowCellValue(i, "Mã hóa đơn").ToString();
                    if (donhang != "" && mahoadon != "")
                        gen.ExcuteNonquery("update INOutward set ParalellRefNo='" + mahoadon + "' where JournalMemo='" + donhang + "' ");
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void barButtonItem56_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ chương trình khuyến mãi chiết khấu Unilever vào hệ thống?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                for (int i = 0; i < view.RowCount; i++)
                {
                    string mahoadon = "UNITN" + view.GetRowCellValue(i, "Số hóa đơn").ToString();
                    string loaihoadon = view.GetRowCellValue(i, "Loại hóa đơn").ToString();
                    if (mahoadon != "" && loaihoadon == "Invoice")
                    {
                        string makhuyenmai = view.GetRowCellValue(i, "Mã khuyến mã").ToString();
                        string chuongtrinh = view.GetRowCellValue(i, "CTKM").ToString();
                        string tennhanvien = view.GetRowCellValue(i, "NVBH").ToString();
                        string sotien = view.GetRowCellValue(i, "Số tiền KM đã sử dụng").ToString().Replace(",", ".");

                        Double k = (Double)char.Parse(makhuyenmai.Substring(0, 1));

                        if ((chuongtrinh == "PERSTR" || chuongtrinh == "OCCDIS" || chuongtrinh == "LTYPRG") && (Math.Round(k / 2, 0) - (k / 2) != 0))
                            sotien = Math.Round(Double.Parse(sotien) / 1.1, 0).ToString();
                        string ngaybatdau = DateTime.Parse(view.GetRowCellValue(i, "Ngày bắt đầu khuyến mãi").ToString()).ToShortDateString();
                        string ngayketthuc = "NULL";
                        if (view.GetRowCellValue(i, "Ngày kết thúc").ToString() != "")
                            ngayketthuc = "'" + DateTime.Parse(view.GetRowCellValue(i, "Ngày kết thúc").ToString()).ToShortDateString() + "'";
                        string ngayketthucsua = "NULL";
                        if (view.GetRowCellValue(i, "N#k#thúc đã sửa").ToString() != "")
                            ngayketthucsua = "'" + DateTime.Parse(view.GetRowCellValue(i, "N#k#thúc đã sửa").ToString()).ToShortDateString() + "'";
                        string mahang = "UNI" + view.GetRowCellValue(i, "Free Gift Code").ToString();
                        string soluong = view.GetRowCellValue(i, "Hàng khuyến mãi (Số lượng)UOM-PC").ToString().Replace(",", ".");
                        if (Double.Parse(sotien) >= 0)
                            gen.ExcuteNonquery("insert into INOutwardCheck values(NEWID(),'" + mahoadon + "','" + makhuyenmai + "','" + chuongtrinh + "',N'" + tennhanvien + "','" + sotien + "','" + ngaybatdau + "'," + ngayketthuc + "," + ngayketthucsua + ",'0',NULL,'" + mahang + "','" + soluong + "')");
                    }
                }
            } SplashScreenManager.CloseForm();
            XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void barButtonItem57_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc cập nhật giá tháng "+DateTime.Parse(ngaychungtu).Month.ToString()+" năm "+DateTime.Parse(ngaychungtu).Year.ToString()+ "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                gen.ExcuteNonquery("delete AccountingObjectInventoryItem where Month(PostedDate)='" + DateTime.Parse(ngaychungtu).Month.ToString() + "' and  Year(PostedDate)='" + DateTime.Parse(ngaychungtu).Year.ToString() + "'");
                for (int i = 0; i < view.RowCount; i++)
                {
                    string makhach = view.GetRowCellValue(i, "Mã khách").ToString();
                    makhach = gen.GetString("select AccountingObjectID from AccountingObject where AccountingObjectCode='" + makhach + "'");
                    string mahang = view.GetRowCellValue(i, "Mã hàng").ToString();
                    mahang=gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='"+mahang+"'");
                    Double giaban = Double.Parse(view.GetRowCellValue(i, "Giá bán").ToString());
                    gen.ExcuteNonquery("insert AccountingObjectInventoryItem values(NEWID(),'" + makhach + "','" + mahang + "'," + giaban + ",'" + ngaychungtu + "')");
                }
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                //InventoryItemAD
            }
        }

        private void bardonhanggaudoTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu Gấu Đỏ Thốt Nốt vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='35'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số ĐH").ToString() != "")
                    {
                        string tenkhach = view.GetRowCellValue(i, "Tên KH").ToString();
                        string diachi = view.GetRowCellValue(i, "Địa chỉ").ToString();
                        string nhanvien = view.GetRowCellValue(i, "NVBH").ToString();

                        nhanvien = gen.GetString("select AccountingObjectID from AccountingObject where IsEmployee='1' and  AccountingObjectName=N'" + nhanvien + "' and ContactTitle=N'Nhân viên kinh doanh'");

                        string donhang = "35"+view.GetRowCellValue(i, "Số ĐH").ToString();
                        string mahang = "GAU" + view.GetRowCellValue(i, "Mã SP").ToString();
                        string donvi = view.GetRowCellValue(i, "Đơn vị").ToString();

                        if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                            mahang = "GAU" + view.GetRowCellValue(i, "Mã SP").ToString() + "KA";

                        if (mahang != "GAU" && mahang != "GAUKA")
                        {
                            for (int j = 0; j < hang.Rows.Count; j++)
                                if (mahang.ToUpper() == hang.Rows[j][1].ToString().ToUpper())
                                {
                                    mahang = hang.Rows[j][0].ToString();
                                    break;
                                }
                            if (mahang.Length < 30)
                            {
                                string tensp = view.GetRowCellValue(i, "Tên SP").ToString();
                                string nhom = view.GetRowCellValue(i, "Ngành hàng con").ToString();
                                string quycach = view.GetRowCellValue(i, "Quy cách").ToString().ToString().Replace(",", ".");

                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tensp + "',N'Thùng',N'" + donvi + "','" + quycach + "','0','4CA47C44-D1BC-489F-B307-60968C73C024','False',0,N'Gấu Đỏ',N'" + nhom + "')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                        }
                        string soluong = view.GetRowCellValue(i, "Sản lượng bán (thùng)").ToString().ToString().Replace(",", ".");
                        string trongluong = view.GetRowCellValue(i, "Sản lượng quy đổi (gói)").ToString().ToString().Replace(",", ".");


                        string trongluongkm = view.GetRowCellValue(i, "SLKM (gói)").ToString().ToString().Replace(",", ".");

                        string dgsoluong = view.GetRowCellValue(i, "Giá (thùng)").ToString().ToString().Replace(",", ".");
                        string dgtrongluong = view.GetRowCellValue(i, "Giá (gói)").ToString().ToString().Replace(",", ".");

                        string doanhso = view.GetRowCellValue(i, "Doanh số NET").ToString().ToString().Replace(",", ".");
                        string chietkhau = view.GetRowCellValue(i, "Chiết khấu tiền").ToString().ToString().Replace(",", ".");

                        string chuongtrinh = view.GetRowCellValue(i, "CT HTTM").ToString();
                       
                        string makhach = nhanvien;

                        try
                        {
                            if (donhang != "35"+view.GetRowCellValue(i - 1, "Số ĐH").ToString())
                            {
                                if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                                    donhang = "KA" + donhang;
                                gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsctTN() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                                refid = gen.GetString("select RefID from INOutward where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                                donhang = "KA" + donhang;
                            gen.ExcuteNonquery("insert into INOutward(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,AccountingObjectType,ShippingNo,Tax,EmployeeID,EmployeeIDSA,TotalFreightAmount,TotalAmount,TotalAmountOC,Cancel,CustomField6,OriginalRefNo,CustomField5) values(newid(),'0','" + ngaychungtu + "','" + ngaychungtu + "','" + themsctTN() + "','" + makhach + "',N'" + tenkhach + "',N'" + diachi + "',N'',N'" + donhang + "',N'','False','" + makho + "','0',N'','10','" + userid + "','" + nhanvien + "',0, 0,0,'True',N'','','')");
                            refid = gen.GetString("select RefID from INOutward where JournalMemo=N'" + donhang + "'");
                        }

                        if (Double.Parse(chietkhau) != 0)
                            gen.ExcuteNonquery("update INOutward set TotalFreightAmount=TotalFreightAmount+'" + (0 - Double.Parse(chietkhau)).ToString() + "' where RefID='" + refid + "'");
                        else
                            if (Double.Parse(trongluong) != 0)
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",'" + mahang + "','0','" + Math.Round((Double.Parse(doanhso) / 1.1) / Double.Parse(trongluong), 2).ToString().Replace(",", ".") + "','" + Math.Round(Double.Parse(doanhso) / 1.1, 0) + "',0,0,0,0,'" + dgtrongluong + "','" + doanhso + "',0,0,'" + dgsoluong + "',0,0,N'" + chuongtrinh + "')");
                            else
                                gen.ExcuteNonquery("insert into INOutwardDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,InventoryItemID,DiscountRate,UnitPrice,Amount,QuantityExits,QuantityConvertExits,Cost,DiscountAmount,UnitPriceOC,AmountOC,ConvertRate,UnitPriceConvertOC,UnitPriceConvert,CustomField1,CustomField2,CustomField3) values(newid(),'" + refid + "',0,'" + trongluongkm + "'," + i + ",'" + mahang + "','0',0,0,0,0,0,0,0,0,0,0,0,0,0,N'" + chuongtrinh + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round((B.TotalAmount-(TotalFreightAmount/(1+Cast(Tax as money)/100)))/Cast(Tax as money),0) FROM (select * from INOutward where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from INOutwardDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barcndhuTN_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn đồng bộ dự liệu đơn mua hàng Gấu Đỏ vào hệ thống ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(ngaychungtu)) + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                string makho = gen.GetString("select * from Stock where StockCode='35'");
                string refid = null;
                for (int i = 0; i < view.RowCount; i++)
                {
                    if (view.GetRowCellValue(i, "Số đơn hàng bán (SO)").ToString() != "")
                    {
                        string donhang = view.GetRowCellValue(i, "Số đơn hàng bán (SO)").ToString();
                        string mahang = "GAU" + view.GetRowCellValue(i, "Mã SP bán").ToString();
                        if (view.GetRowCellValue(i, "Mã NPP").ToString() == "12948")
                            mahang = "GAU" + view.GetRowCellValue(i, "Mã SP bán").ToString() + "KA";

                        Double tyle = Double.Parse(view.GetRowCellValue(i, "Quy cách").ToString());

                        string trongluong = view.GetRowCellValue(i, "Số lượng gói quy đổi").ToString();

                        string soluong = Math.Round(Double.Parse(trongluong) / tyle, 0).ToString();

                        if (mahang != "GAU" && mahang != "GAUKA")
                            try
                            {
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }
                            catch
                            {
                                string tensp = view.GetRowCellValue(i, "Tên SP bán").ToString();
                                string nhom = view.GetRowCellValue(i, "Ngành hàng con").ToString();
                                gen.ExcuteNonquery("insert into InventoryItem(InventoryItemID,InventoryItemCode,InventoryItemName,Unit,ConvertUnit,ConvertRate,TaxRate,InventoryCategoryID,Inactive,InventoryItemType,SaleDescription,PurchaseDescription)  values(newid(),'" + mahang + "',N'" + tensp + "',N'Thùng',N'gói','" + tyle + "','0','4CA47C44-D1BC-489F-B307-60968C73C024','False',0,N'Gấu Đỏ',N'" + nhom + "')");
                                mahang = gen.GetString("select InventoryItemID from InventoryItem where InventoryItemCode='" + mahang + "'");
                            }

                        string doanhso = view.GetRowCellValue(i, "Thành tiền").ToString().ToString().Replace(",", ".");

                        string dgtrongluong = Math.Round(Double.Parse(doanhso) / Double.Parse(trongluong), 2).ToString().ToString().Replace(",", ".");
                        try
                        {
                            if (donhang != view.GetRowCellValue(i - 1, "Số đơn hàng bán (SO)").ToString())
                            {
                                gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadonTN() + "','10E6D9B7-A3D2-4149-9A22-7DDF3562C93E',N'CÔNG TY CỔ PHẦN THỰC PHẨM Á CHÂU',N'Số 9/2 đường ĐT 743, Khu phố 1B, Phường An Phú, TX Thuận An, Tỉnh Bình Dương',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                                refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                            }
                        }
                        catch
                        {
                            gen.ExcuteNonquery("insert into DDHNCC(RefID,RefType,RefDate,PostedDate,RefNo,AccountingObjectID,AccountingObjectName,AccountingObjectAddress,Contactname,JournalMemo,DocumentIncluded,Posted,StockID,ShippingNo,CustomField9,EmployeeID,TotalAmount,TotalAmountOC,Cancel,CustomField6,CustomField1,ExchangeRate,IsImportPurchase,CustomField2,CustomField3) values(newid(),'1','" + ngaychungtu + "','" + ngaychungtu + "','" + themscthoadonTN() + "','10E6D9B7-A3D2-4149-9A22-7DDF3562C93E',N'CÔNG TY CỔ PHẦN THỰC PHẨM Á CHÂU',N'Số 9/2 đường ĐT 743, Khu phố 1B, Phường An Phú, TX Thuận An, Tỉnh Bình Dương',N'',N'" + donhang + "',N'','False','" + makho + "',N'','10','" + userid + "','0','0','0',N'',N'',8,'True',N'Nguyễn Thành Được','')");
                            refid = gen.GetString("select RefID from DDHNCC where JournalMemo=N'" + donhang + "'");
                        }
                        gen.ExcuteNonquery("insert into DDHNCCDetail(RefDetailID,RefID,Quantity,QuantityConvert,SortOrder,ConvertRate,InventoryItemID,UnitPriceConvert,UnitPrice,Amount,CustomField1,CustomField2,CustomField3,CustomField4,CustomField5,QuantityExits,QuantityConvertExits,UnitPriceOC,UnitPriceConvertOC) values(newid(),'" + refid + "','" + soluong + "','" + trongluong + "'," + i + ",0,'" + mahang + "',0,'" + dgtrongluong + "','" + doanhso + "',0,0,0,0,0,0,0,'" + soluong + "','" + trongluong + "')");
                    }
                }
                gen.ExcuteNonquery("UPDATE A SET A.TotalAmount= B.TotalAmount, TotalAmountOC=Round(B.TotalAmount/Cast(CustomField9 as money),0) FROM (select * from DDHNCC where RefDate='" + ngaychungtu + "' and TotalAmount=0 and EmployeeID='" + userid + "' ) A, (select RefID,SUM(Amount) as TotalAmount from DDHNCCDetail group by RefID) B WHERE A.RefID = B.RefID");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void barButtonItem58_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Bạn chắc muốn cập nhật địa giới hành chính?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                SplashScreenManager.ShowForm(typeof(Frm_wait));
                gen.ExcuteNonquery("delete ProvinceFull");
                for (int i = 0; i < view.RowCount; i++)
                {
                    string tinh = view.GetRowCellValue(i, "Tên tỉnh").ToString();
                    string huyen = view.GetRowCellValue(i, "Tên huyện").ToString();
                    string xa = view.GetRowCellValue(i, "Tên Xã").ToString();
                    gen.ExcuteNonquery("insert into ProvinceFull values(newid(),N'" + tinh + "',N'" + huyen + "',N'" + xa + "')");
                }
                gen.ExcuteNonquery("tonghopdiagioihanhchinh '" + ngaychungtu + "'");
                SplashScreenManager.CloseForm();
                XtraMessageBox.Show("Dữ liệu đã được xử lý xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

    }
}