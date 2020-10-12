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
    public partial class Frm_rpthuchi : DevExpress.XtraEditors.XtraForm
    {
        public Frm_rpthuchi()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Frm_rpthuchi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        gencon gen = new gencon();
        DataTable dttien = new DataTable();
        DataTable dttk = new DataTable();
        DataTable temp = new DataTable();
        doiso doi = new doiso();
        string tsbt, role,nguoinop,diachi,sophieu,lydo,chungtugoc,sotienchu,hoten,kho,congty,phieu,mauso,ngaychungtu;
        Double sotien = 0;
        public DataTable getda(DataTable a)
        {
            temp = a;
            return temp;
        }
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
        public string getrole(string a)
        {
            role = a;
            return role;
        }
        public string getcongty(string a)
        {
            congty = a;
            return congty;
        }
        public string gethoten(string a)
        {
            hoten = a;
            return hoten;
        }

        private void rpthuchi_Load(object sender, EventArgs e)
        {
            dttien.Columns.Add("Mã khách", Type.GetType("System.String"));
            dttien.Columns.Add("Họ tên", Type.GetType("System.String"));
            dttien.Columns.Add("sotien", Type.GetType("System.Double"));

            dttk.Columns.Add("Tài khoản", Type.GetType("System.String"));
            dttk.Columns.Add("Số tiền", Type.GetType("System.Double"));
            dttk.Columns.Add("TKDU", Type.GetType("System.String"));

            if (tsbt == "pttm")
            {
                phieu = "PHIẾU THU";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAReceipt a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 01 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from CAReceiptDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select CreditAccount,sum(Amount),DebitAccount from CAReceiptDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "C" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "N" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk,"Người nộp tiền");
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "pttmdonvi")
            {
                DataTable dtchitiet = new DataTable();
                dtchitiet.Columns.Add("nguoinop", Type.GetType("System.String"));
                dtchitiet.Columns.Add("diachi", Type.GetType("System.String"));
                dtchitiet.Columns.Add("lydo", Type.GetType("System.String"));
                dtchitiet.Columns.Add("chungtugoc", Type.GetType("System.String"));
                dtchitiet.Columns.Add("ngaychungtu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sophieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("kho", Type.GetType("System.String"));
                dtchitiet.Columns.Add("hoten", Type.GetType("System.String"));
                dtchitiet.Columns.Add("mauso", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotienchu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotien", Type.GetType("System.Double"));
                dtchitiet.Columns.Add("no", Type.GetType("System.String"));
                dtchitiet.Columns.Add("co", Type.GetType("System.String"));
                dtchitiet.Columns.Add("makhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("tenkhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("phieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("congty", Type.GetType("System.String"));

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,CustomField5,StockCode,StockName,TotalAmount,FullName  from CAReceipt a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");

                DataTable tam = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount,DebitAccount,CreditAccount,b.Address from CAReceiptDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                for (int i = 0; i < tam.Rows.Count; i++)
                {
                    DataRow dr = dtchitiet.NewRow();

                    dr[0] = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                    dr[1] = tam.Rows[i][5].ToString();
                    dr[2] = temp.Rows[0][3].ToString();
                    dr[3] = temp.Rows[0][4].ToString();
                    ngaychungtu = temp.Rows[0][5].ToString();
                    dr[4] = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                    dr[5] = temp.Rows[0][6].ToString();
                    dr[6] = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                    dr[7] = temp.Rows[0][10].ToString();
                    dr[8] = "Mẫu số 01 - TT";

                    sotien = Double.Parse(tam.Rows[i][2].ToString());
                    sotienchu = doi.ChuyenSo(sotien.ToString());
                    char[] charArr = sotienchu.ToCharArray();
                    charArr[0] = Char.ToUpper(charArr[0]);
                    sotienchu = new String(charArr);
                    dr[9] = sotienchu;
                    dr[10] = sotien;

                    dr[11] = "N" + tam.Rows[i][3].ToString();
                    dr[12] = "C" + tam.Rows[i][4].ToString();
                    dr[13] = tam.Rows[i][0].ToString();
                    dr[14] = tam.Rows[i][1].ToString();
                    dr[15] = "PHIẾU THU";
                    dr[16] = gen.GetString("select Top 1 CompanyName from Center");
                    dtchitiet.Rows.Add(dr);
                }
                rpmauthuchidonvi thuchi = new rpmauthuchidonvi();
                thuchi.BindData(dtchitiet);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "ptctm")
            {
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAReceiptTT a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 01 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from CAReceiptDetailTT a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select CreditAccount,sum(Amount),DebitAccount from CAReceiptDetailTT where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "C" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "N" + temp.Rows[i][2].ToString();
                    if (temp.Rows[i][0].ToString() == "131")
                        phieu = "PHIẾU THU";
                    else
                        phieu = "PHIẾU CHI";
                    dttk.Rows.Add(dr);
                }
                if (phieu == "PHIẾU CHI")
                {
                    dttk.Clear();
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dttk.NewRow();
                        dr[0] = "N" + temp.Rows[i][2].ToString();
                        dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                        dr[2] = "C" + temp.Rows[i][0].ToString();
                        dttk.Rows.Add(dr);
                    }
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk, "Người nộp tiền");
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pctm")
            {
                phieu = "PHIẾU CHI";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAPayment a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 02 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from CAPaymentDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select DebitAccount,sum(Amount),CreditAccount from CAPaymentDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "N" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "C" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk, "Người nhận tiền");
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "pctmthanhtoan" || tsbt == "pctmthanhtoantomtat")
            {
                phieu = "PHIẾU THANH TOÁN";
                if (congty == "1")
                    phieu = "CHI NỘP NGÂN HÀNG";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAPayment a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());

                hoten = temp.Rows[0][10].ToString();
                if (tsbt == "pctmthanhtoantomtat")
                    hoten = tsbt;

                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 02 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from CAPaymentDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select DebitAccount,sum(Amount),CreditAccount from CAPaymentDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "N" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "C" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk, "Người nhận tiền");
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pctmbangkethanhtoan")
            {
                /*temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAPayment a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());

                hoten = temp.Rows[0][10].ToString();
                if (tsbt == "pctmthanhtoantomtat")
                    hoten = tsbt;

                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 02 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from CAPaymentDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select DebitAccount,sum(Amount),CreditAccount from CAPaymentDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "N" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "C" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }*/
                this.Text = "Bảng kê thanh toán";
                rpbangkethanhtoan thuchi = new rpbangkethanhtoan();
                thuchi.gettieude(role);
                thuchi.BindData(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "ptnh")
            {
                phieu = "PHIẾU THU NGÂN HÀNG";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from BADeposit a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 01 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from BADepositDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select CreditAccount,sum(Amount),DebitAccount from BADepositDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "C" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "N" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchinganhang thuchi = new rpmauthuchinganhang();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pcnh")
            {
                phieu = "PHIẾU CHI NGÂN HÀNG";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from BATransfer a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 02 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from BATransferDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select DebitAccount,sum(Amount),CreditAccount from BATransferDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "N" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "C" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchinganhang thuchi = new rpmauthuchinganhang();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "uncpc")
            {
                phieu = "ỦY NHIỆM CHI";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,AccountingObjectBankName,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from BAAccreditative a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                mauso = "Mẫu số 02 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from BAAccreditativeDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select DebitAccount,sum(Amount),CreditAccount from BAAccreditativeDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "N" + temp.Rows[i][0].ToString();
                    dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                    dr[2] = "C" + temp.Rows[i][2].ToString();
                    dttk.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchinganhang thuchi = new rpmauthuchinganhang();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pkt")
            {
                phieu = "PHIẾU KẾ TOÁN";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from GLVoucher a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                if (sotien >= 0)
                {
                    sotienchu = doi.ChuyenSo(sotien.ToString());
                    char[] charArr = sotienchu.ToCharArray();
                    charArr[0] = Char.ToUpper(charArr[0]);
                    sotienchu = new String(charArr);
                }
                else
                {
                    sotienchu = "(" + doi.ChuyenSo((0 - sotien).ToString()) + ")";
                    char[] charArr = sotienchu.ToCharArray();
                    charArr[1] = Char.ToUpper(charArr[1]);
                    sotienchu = new String(charArr);
                }
                mauso = "Mẫu số 01 - TT";
                temp = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount from GLVoucherDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = Double.Parse(temp.Rows[i][2].ToString());
                    dttien.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 12; i++)
                {
                    DataRow dr = dttien.NewRow();
                    dr[0] = "";
                    dttien.Rows.Add(dr);
                }

                temp = gen.GetTable("select CreditAccount,sum(Amount),DebitAccount from GLVoucherDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                DataTable check = new DataTable();
                check = gen.GetTable("select CreditAccount from GLVoucherDetail where RefID='" + role + "' group by CreditAccount ");

                if (check.Rows.Count != 1)
                {
                    temp = gen.GetTable("select DebitAccount,sum(Amount),CreditAccount from GLVoucherDetail where RefID='" + role + "' group by CreditAccount,DebitAccount ");
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dttk.NewRow();
                        dr[0] = "C" + temp.Rows[i][2].ToString();
                        dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                        dr[2] = "N" + temp.Rows[i][0].ToString();
                        dttk.Rows.Add(dr);
                    }
                }
                else
                {
                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dttk.NewRow();
                        dr[0] = "N" + temp.Rows[i][2].ToString();
                        dr[1] = Double.Parse(temp.Rows[i][1].ToString());
                        dr[2] = "C" + temp.Rows[i][0].ToString();
                        dttk.Rows.Add(dr);
                    }
                }

                for (int i = temp.Rows.Count; i < 7; i++)
                {
                    DataRow dr = dttk.NewRow();
                    dr[0] = "";
                    dttk.Rows.Add(dr);
                }
                rpmauthuchinganhang thuchi = new rpmauthuchinganhang();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, dttien, dttk);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtpkt")
            {
                rptheodoiphieu thuchi = new rptheodoiphieu();
                thuchi.gettieude(congty, role, hoten, "THEO DÕI PHIẾU KẾ TOÁN");
                thuchi.BindData(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtpkttong")
            {
                rptheodoiphieu thuchi = new rptheodoiphieu();
                thuchi.gettieude(congty, role, hoten, "THEO DÕI PHIẾU KẾ TOÁN");
                thuchi.BindDataSum(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbkthcp" || tsbt == "tsbtbkthcptndn" || tsbt == "tsbtbkthcptn" || tsbt == "tsbtbkthtncp" || tsbt == "tsbtbkthcptheokho" || tsbt == "tsbtbkthcptheokhotndn" || tsbt == "tsbtbkthcpthuan" || tsbt == "tsbtbkthcpthuantndn")
            {
                this.Text = "Bảng kê tổng hợp chi phí";
                rptonghopphi thuchi = new rptonghopphi();
                thuchi.gettieude(congty, role, hoten, tsbt);
                if (tsbt == "tsbtbkthcp" || tsbt == "tsbtbkthcptndn" || tsbt == "tsbtbkthcptn" || tsbt == "tsbtbkthtncp")
                    thuchi.BindData(temp);
                else
                    thuchi.BindDatakho(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtthpnxtt" || tsbt == "tsbtthpnxdc")
            {
                rptonghopphieunhapxuat thuchi = new rptonghopphieunhapxuat();
                if (hoten != "")
                {
                    dttk = gen.GetTable("select StockCode,StockName from Stock where StockID='" + hoten + "'");
                    hoten = dttk.Rows[0][0].ToString() + " - " + dttk.Rows[0][1].ToString();
                }
                thuchi.gettieude(congty, role, hoten, tsbt);
                thuchi.BindData(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtthpnxtttong" || tsbt == "tsbtthpnxdctong")
            {
                rptonghopphieunhapxuattong thuchi = new rptonghopphieunhapxuattong();
                thuchi.gettieude(congty, role, tsbt);
                thuchi.BindData(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtthdtvcp")
            {
                rptonghopdoanhthu thuchi = new rptonghopdoanhthu();
                thuchi.gettieude(role, congty, hoten);
                thuchi.BindData(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtbcdkt")
            {
                rpbangcandoiketoan thuchi = new rpbangcandoiketoan();
                this.Text = "Bảng cân đối kế toán";
                thuchi.gettieude(role, congty);
                thuchi.BindData(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtuncvietcombank")
            {
                uncvietcombank thuchi = new uncvietcombank();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtuncmbbank")
            {
                uncmbbank thuchi = new uncmbbank();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtuncvietinbank")
            {
                uncvietinbank thuchi = new uncvietinbank();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtunceximbank")
            {
                unceximbank thuchi = new unceximbank();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtuncsacombank")
            {
                uncsacombank thuchi = new uncsacombank();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtunchdbank")
            {
                unchdbank thuchi = new unchdbank();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtuncsacombanknew")
            {
                uncsacombanknew thuchi = new uncsacombanknew();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
            else if (tsbt == "tsbtuncbidv")
            {
                uncbidv thuchi = new uncbidv();
                this.Text = "Ủy nhiệm chi";
                thuchi.gettieude(role);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "tsbtbthhdkd")
            {
                rpbaocaoketquahoatdongkinhdoanh thuchi = new rpbaocaoketquahoatdongkinhdoanh();
                this.Text = "Báo cáo kết quả hoạt động kinh doanh";
                thuchi.gettieude(role, congty);
                thuchi.BindData(temp);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }


            else if (tsbt == "pttmchitiet")
            {
                DataTable dtchitiet = new DataTable();
                dtchitiet.Columns.Add("nguoinop", Type.GetType("System.String"));
                dtchitiet.Columns.Add("diachi", Type.GetType("System.String"));
                dtchitiet.Columns.Add("lydo", Type.GetType("System.String"));
                dtchitiet.Columns.Add("chungtugoc", Type.GetType("System.String"));
                dtchitiet.Columns.Add("ngaychungtu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sophieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("kho", Type.GetType("System.String"));
                dtchitiet.Columns.Add("hoten", Type.GetType("System.String"));
                dtchitiet.Columns.Add("mauso", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotienchu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotien", Type.GetType("System.Double"));
                dtchitiet.Columns.Add("no", Type.GetType("System.String"));
                dtchitiet.Columns.Add("co", Type.GetType("System.String"));
                dtchitiet.Columns.Add("makhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("tenkhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("phieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("congty", Type.GetType("System.String"));

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAReceipt a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");

                DataTable tam = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount,DebitAccount,CreditAccount from CAReceiptDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                for (int i = 0; i < tam.Rows.Count; i++)
                {
                    DataRow dr = dtchitiet.NewRow();

                    dr[0] = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                    dr[1] = temp.Rows[0][2].ToString();
                    dr[2] = temp.Rows[0][3].ToString();
                    dr[3] = temp.Rows[0][4].ToString();
                    ngaychungtu = temp.Rows[0][5].ToString();
                    dr[4] = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                    dr[5] = temp.Rows[0][6].ToString();
                    dr[6] = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                    dr[7] = temp.Rows[0][10].ToString();
                    dr[8] = "Mẫu số 01 - TT";

                    sotien = Double.Parse(tam.Rows[i][2].ToString());
                    sotienchu = doi.ChuyenSo(sotien.ToString());
                    char[] charArr = sotienchu.ToCharArray();
                    charArr[0] = Char.ToUpper(charArr[0]);
                    sotienchu = new String(charArr);
                    dr[9] = sotienchu;
                    dr[10] = sotien;

                    dr[11] = "N" + tam.Rows[i][3].ToString();
                    dr[12] = "C" + tam.Rows[i][4].ToString();
                    dr[13] = tam.Rows[i][0].ToString();
                    dr[14] = tam.Rows[i][1].ToString();
                    dr[15] = "PHIẾU THU";
                    dr[16] = gen.GetString("select Top 1 CompanyName from Center");
                    dtchitiet.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.BindData(dtchitiet);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "ptctmchitiet")
            {
                DataTable dtchitiet = new DataTable();
                dtchitiet.Columns.Add("nguoinop", Type.GetType("System.String"));
                dtchitiet.Columns.Add("diachi", Type.GetType("System.String"));
                dtchitiet.Columns.Add("lydo", Type.GetType("System.String"));
                dtchitiet.Columns.Add("chungtugoc", Type.GetType("System.String"));
                dtchitiet.Columns.Add("ngaychungtu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sophieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("kho", Type.GetType("System.String"));
                dtchitiet.Columns.Add("hoten", Type.GetType("System.String"));
                dtchitiet.Columns.Add("mauso", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotienchu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotien", Type.GetType("System.Double"));
                dtchitiet.Columns.Add("no", Type.GetType("System.String"));
                dtchitiet.Columns.Add("co", Type.GetType("System.String"));
                dtchitiet.Columns.Add("makhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("tenkhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("phieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("congty", Type.GetType("System.String"));

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAReceiptTT a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");

                DataTable tam = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount,DebitAccount,CreditAccount from CAReceiptDetailTT a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                for (int i = 0; i < tam.Rows.Count; i++)
                {
                    DataRow dr = dtchitiet.NewRow();

                    dr[0] = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                    dr[1] = temp.Rows[0][2].ToString();
                    dr[2] = temp.Rows[0][3].ToString();
                    dr[3] = temp.Rows[0][4].ToString();
                    ngaychungtu = temp.Rows[0][5].ToString();
                    dr[4] = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                    dr[5] = temp.Rows[0][6].ToString();
                    dr[6] = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                    dr[7] = temp.Rows[0][10].ToString();
                    dr[8] = "Mẫu số 01 - TT";

                    sotien = Double.Parse(tam.Rows[i][2].ToString());
                    sotienchu = doi.ChuyenSo(sotien.ToString());
                    char[] charArr = sotienchu.ToCharArray();
                    charArr[0] = Char.ToUpper(charArr[0]);
                    sotienchu = new String(charArr);
                    dr[9] = sotienchu;
                    dr[10] = sotien;

                    if (tam.Rows[i][3].ToString() == "131")
                        dr[15] = "PHIẾU CHI";
                    else
                        dr[15] = "PHIẾU THU";
                    dr[11] = "N" + tam.Rows[i][3].ToString();
                    dr[12] = "C" + tam.Rows[i][4].ToString();
                    dr[13] = tam.Rows[i][0].ToString();
                    dr[14] = tam.Rows[i][1].ToString();

                    dr[16] = gen.GetString("select Top 1 CompanyName from Center");
                    dtchitiet.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.BindData(dtchitiet);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pctmchitiet")
            {
                DataTable dtchitiet = new DataTable();
                dtchitiet.Columns.Add("nguoinop", Type.GetType("System.String"));
                dtchitiet.Columns.Add("diachi", Type.GetType("System.String"));
                dtchitiet.Columns.Add("lydo", Type.GetType("System.String"));
                dtchitiet.Columns.Add("chungtugoc", Type.GetType("System.String"));
                dtchitiet.Columns.Add("ngaychungtu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sophieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("kho", Type.GetType("System.String"));
                dtchitiet.Columns.Add("hoten", Type.GetType("System.String"));
                dtchitiet.Columns.Add("mauso", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotienchu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("sotien", Type.GetType("System.Double"));
                dtchitiet.Columns.Add("no", Type.GetType("System.String"));
                dtchitiet.Columns.Add("co", Type.GetType("System.String"));
                dtchitiet.Columns.Add("makhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("tenkhach", Type.GetType("System.String"));
                dtchitiet.Columns.Add("phieu", Type.GetType("System.String"));
                dtchitiet.Columns.Add("congty", Type.GetType("System.String"));

                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from CAPayment a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.UserID=d.UserID and RefID='" + role + "'");

                DataTable tam = gen.GetTable("select AccountingObjectCode,AccountingObjectName,Amount,DebitAccount,CreditAccount from CAPaymentDetail a, AccountingObject b where a.AccountingObjectID=b.AccountingObjectID and RefID='" + role + "'");
                for (int i = 0; i < tam.Rows.Count; i++)
                {
                    DataRow dr = dtchitiet.NewRow();

                    dr[0] = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                    dr[1] = temp.Rows[0][2].ToString();
                    dr[2] = temp.Rows[0][3].ToString();
                    dr[3] = temp.Rows[0][4].ToString();
                    ngaychungtu = temp.Rows[0][5].ToString();
                    dr[4] = "Ngày " + String.Format("{0:dd}", DateTime.Parse(ngaychungtu)) + " tháng " + String.Format("{0:MM}", DateTime.Parse(ngaychungtu)) + " năm " + String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu));
                    dr[5] = temp.Rows[0][6].ToString();
                    dr[6] = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                    dr[7] = temp.Rows[0][10].ToString();
                    dr[8] = "Mẫu số 02 - TT";

                    sotien = Double.Parse(tam.Rows[i][2].ToString());
                    sotienchu = doi.ChuyenSo(sotien.ToString());
                    char[] charArr = sotienchu.ToCharArray();
                    charArr[0] = Char.ToUpper(charArr[0]);
                    sotienchu = new String(charArr);
                    dr[9] = sotienchu;
                    dr[10] = sotien;

                    dr[12] = "N" + tam.Rows[i][3].ToString();
                    dr[11] = "C" + tam.Rows[i][4].ToString();
                    dr[13] = tam.Rows[i][0].ToString();
                    dr[14] = tam.Rows[i][1].ToString();
                    dr[15] = "PHIẾU CHI";
                    dr[16] = gen.GetString("select Top 1 CompanyName from Center");
                    dtchitiet.Rows.Add(dr);
                }
                rpmauthuchi thuchi = new rpmauthuchi();
                thuchi.BindData(dtchitiet);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            


            if (tsbt == "pttmvt")
            {
                DataTable dtvattu = new DataTable();
                dtvattu.Columns.Add("Tên vật tư", Type.GetType("System.String"));
                dtvattu.Columns.Add("Mã số", Type.GetType("System.String"));
                dtvattu.Columns.Add("ĐVT", Type.GetType("System.String"));
                dtvattu.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Thành tiền", Type.GetType("System.Double"));

                phieu = "PHIẾU THU TIỀN MẶT BÁN VẬT TƯ";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from SUCAReceipt a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.EmployeeID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string no="1111", co="1313";

                temp = gen.GetTable("select InventoryItemName,InventoryItemCode,Unit,Quantity,a.SalePrice,Amount,DebitAccount,CreditAccount from SUCAReceiptDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = Double.Parse(temp.Rows[i][3].ToString());
                    dr[4] = Double.Parse(temp.Rows[i][4].ToString());
                    dr[5] = Double.Parse(temp.Rows[i][5].ToString());
                    no = temp.Rows[i][6].ToString();
                    co = temp.Rows[i][7].ToString();
                    dtvattu.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 10; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = "";
                    dtvattu.Rows.Add(dr);
                }

               
                rpmauthuchivattu thuchi = new rpmauthuchivattu();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, "Người nộp tiền",no,co);
                thuchi.BindData(dtvattu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pctmvt")
            {
                DataTable dtvattu = new DataTable();
                dtvattu.Columns.Add("Tên vật tư", Type.GetType("System.String"));
                dtvattu.Columns.Add("Mã số", Type.GetType("System.String"));
                dtvattu.Columns.Add("ĐVT", Type.GetType("System.String"));
                dtvattu.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Thành tiền", Type.GetType("System.Double"));

                phieu = "PHIẾU CHI TIỀN MẶT MUA VẬT TƯ";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from SUCAPayment a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.EmployeeID=d.UserID and RefID='" + role + "' ");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string no = "3313", co = "1111";

                temp = gen.GetTable("select InventoryItemName,InventoryItemCode,Unit,Quantity,a.SalePrice,Amount,DebitAccount,CreditAccount from SUCAPaymentDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = Double.Parse(temp.Rows[i][3].ToString());
                    dr[4] = Double.Parse(temp.Rows[i][4].ToString());
                    dr[5] = Double.Parse(temp.Rows[i][5].ToString());
                    no = temp.Rows[i][6].ToString();
                    co = temp.Rows[i][7].ToString();
                    dtvattu.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 10; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = "";
                    dtvattu.Rows.Add(dr);
                }


                rpmauthuchivattu thuchi = new rpmauthuchivattu();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, "Người nhận tiền", no, co);
                thuchi.BindData(dtvattu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "pcnhvt")
            {
                DataTable dtvattu = new DataTable();
                dtvattu.Columns.Add("Tên vật tư", Type.GetType("System.String"));
                dtvattu.Columns.Add("Mã số", Type.GetType("System.String"));
                dtvattu.Columns.Add("ĐVT", Type.GetType("System.String"));
                dtvattu.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Thành tiền", Type.GetType("System.Double"));

                phieu = "PHIẾU CHI NGÂN HÀNG MUA VẬT TƯ";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from SUBATransfer a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.EmployeeID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string no = "3313", co = "1111";

                temp = gen.GetTable("select InventoryItemName,InventoryItemCode,Unit,Quantity,a.SalePrice,Amount,DebitAccount,CreditAccount from SUBATransferDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = Double.Parse(temp.Rows[i][3].ToString());
                    dr[4] = Double.Parse(temp.Rows[i][4].ToString());
                    dr[5] = Double.Parse(temp.Rows[i][5].ToString());
                    no = temp.Rows[i][6].ToString();
                    co = temp.Rows[i][7].ToString();
                    dtvattu.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 10; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = "";
                    dtvattu.Rows.Add(dr);
                }


                rpmauthuchivattu thuchi = new rpmauthuchivattu();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, "Người nhận tiền", no, co);
                thuchi.BindData(dtvattu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }

            else if (tsbt == "ptnhvt")
            {
                DataTable dtvattu = new DataTable();
                dtvattu.Columns.Add("Tên vật tư", Type.GetType("System.String"));
                dtvattu.Columns.Add("Mã số", Type.GetType("System.String"));
                dtvattu.Columns.Add("ĐVT", Type.GetType("System.String"));
                dtvattu.Columns.Add("Số lượng", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Đơn giá", Type.GetType("System.Double"));
                dtvattu.Columns.Add("Thành tiền", Type.GetType("System.Double"));
                this.Text = "Phiếu thu ngân hàng bán vật tư";
                phieu = "PHIẾU THU NGÂN HÀNG BÁN VẬT TƯ";
                temp = gen.GetTable("select AccountingObjectCode,b.AccountingObjectName,b.Address,JournalMemo,DocumentIncluded,RefDate,RefNo,StockCode,StockName,TotalAmount,FullName  from SUBADeposit a, AccountingObject b,Stock c,MSC_user d  where a.AccountingObjectID=b.AccountingObjectID and a.StockID=c.StockID and a.EmployeeID=d.UserID and RefID='" + role + "'");
                nguoinop = temp.Rows[0][1].ToString() + " (" + temp.Rows[0][0].ToString() + ")";
                diachi = temp.Rows[0][2].ToString();
                lydo = temp.Rows[0][3].ToString();
                chungtugoc = temp.Rows[0][4].ToString();
                ngaychungtu = temp.Rows[0][5].ToString();
                sophieu = temp.Rows[0][6].ToString();
                kho = temp.Rows[0][7].ToString() + " - " + temp.Rows[0][8].ToString();
                sotien = Double.Parse(temp.Rows[0][9].ToString());
                hoten = temp.Rows[0][10].ToString();
                sotienchu = doi.ChuyenSo(sotien.ToString());
                char[] charArr = sotienchu.ToCharArray();
                charArr[0] = Char.ToUpper(charArr[0]);
                sotienchu = new String(charArr);
                string no = "3313", co = "1111";

                temp = gen.GetTable("select InventoryItemName,InventoryItemCode,Unit,Quantity,a.SalePrice,Amount,DebitAccount,CreditAccount from SUBADepositDetail a, InventoryItem b where a.InventoryItemID=b.InventoryItemID and RefID='" + role + "' order by SortOrder");
                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = temp.Rows[i][0].ToString();
                    dr[1] = temp.Rows[i][1].ToString();
                    dr[2] = temp.Rows[i][2].ToString();
                    dr[3] = Double.Parse(temp.Rows[i][3].ToString());
                    dr[4] = Double.Parse(temp.Rows[i][4].ToString());
                    dr[5] = Double.Parse(temp.Rows[i][5].ToString());
                    no = temp.Rows[i][6].ToString();
                    co = temp.Rows[i][7].ToString();
                    dtvattu.Rows.Add(dr);
                }
                for (int i = temp.Rows.Count; i < 10; i++)
                {
                    DataRow dr = dtvattu.NewRow();
                    dr[0] = "";
                    dtvattu.Rows.Add(dr);
                }


                rpmauthuchivattu thuchi = new rpmauthuchivattu();
                thuchi.gettieude(ngaychungtu, phieu, mauso, sophieu, kho, congty, nguoinop, diachi, lydo, sotien.ToString(), sotienchu, chungtugoc, hoten, "Người nộp tiền", no, co);
                thuchi.BindData(dtvattu);
                printControl1.PrintingSystem = thuchi.PrintingSystem;
                thuchi.CreateDocument();
            }
        }
       
    }
}