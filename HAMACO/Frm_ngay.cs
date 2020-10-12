using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HAMACO.Resources;

namespace HAMACO
{
    public partial class Frm_ngay : DevExpress.XtraEditors.XtraForm
    {
        public Frm_ngay()
        {
            InitializeComponent();
        }

        gencon gen = new gencon();
        tonghoptaikhoan thtk = new tonghoptaikhoan();
        string ngaychungtu, tsbt, account, accountname, thang, nam, userid, kho;
        GridView viewsum = new GridView();
        public string getngaychungtu(string a)
        {
            ngaychungtu = a;
            return ngaychungtu;
        }
        public string getuser(string a)
        {
            userid = a;
            return userid;
        }
        public string getkho(string a)
        {
            kho = a;
            return kho;
        }
        public GridView getview(GridView a)
        {
            viewsum = a;
            return viewsum;
        }

        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }
       

        private void Frm_ngay_Load(object sender, EventArgs e)
        {
            thang = String.Format("{0:MM}", DateTime.Parse(ngaychungtu));
            nam = DateTime.Parse(ngaychungtu).Year.ToString();
            if (tsbt == "tsbtbktdng")
            {
                this.Text = "Bảng kê tài khoản ngân hàng tháng " + thang + " năm " + nam;
                thtk.loaddate(gridControl1, gridView1, ngaychungtu);
            }
            else if (tsbt == "tsbtpttm" || tsbt == "bctqtkho")
            {
                account = "1111";
                this.Text = "TK - 1111 Tháng " + thang + " năm " + nam;
                thtk.loaddate(gridControl1, gridView1, ngaychungtu, account);
            }
            else
            {
                account = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Tài khoản").ToString();
                accountname = viewsum.GetRowCellValue(viewsum.FocusedRowHandle, "Tên tài khoản").ToString();
                this.Text = "TK - " + account + " Tháng " + thang + " năm " + nam;
                thtk.loaddate(gridControl1, gridView1, ngaychungtu, account);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn).ToString() != "")
            {
                string ngay = DateTime.Parse(thang + "/" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn).ToString() + "/" + nam).ToString();
                if (tsbt == "tsbtbktdng")
                {
                    Frm_rpcongno rp = new Frm_rpcongno();
                    rp.getngaychungtu(ngay);
                    rp.gettsbt(tsbt);
                    rp.Show();
                }
                else if (tsbt == "tsbtpttm")
                {
                    DataSet ds = new DataSet();
                    ds.Tables.Add(gen.GetTable("select RefNo as 'Số phiếu',b.CustomField5 as 'Số phiếu đơn vị',DebitAccount as 'TK nợ',CreditAccount as 'TK có',d.AccountingObjectCode as 'Người nộp',d.AccountingObjectName as 'Tên người nộp',b.JournalMemo as 'Lý do',c.AccountingObjectCode as 'Đối tượng',c.AccountingObjectName as 'Tên đối tượng',Amount as 'Số tiền',b.Contactname as 'Đội',Note as 'Ghi chú' from CAReceiptDetail a, CAReceipt b, AccountingObject c, AccountingObject d  where b.AccountingObjectID=d.AccountingObjectID and a.AccountingObjectID=c.AccountingObjectID and a.RefID=b.RefID and Cast(RefDate as date)= cast('" + ngay + "' as date) and b.StockID in (select StockID from MSC_UserJoinStock where UserID='" + userid + "') order by RefNo,d.AccountingObjectCode,c.AccountingObjectCode"));
                    gen.CreateExcel(ds, "Bangkephieuthu_" + String.Format("{0:dd-MM-yyyy}", DateTime.Parse(ngay)) + ".xlsx");
                }
                else if (tsbt == "bctqtkho")
                {
                    Frm_rpcongno F = new Frm_rpcongno();
                    F.gettsbt(tsbt);
                    F.getngaychungtu(ngay);
                    F.getkho(kho);
                    F.ShowDialog();
                }
                else
                    thtk.loadton(gridView1, account, accountname, tsbt, ngay);
            }
        }

        private void gridView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn).ToString() != "")
                {
                    string ngay = DateTime.Parse(thang + "/" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.FocusedColumn).ToString() + "/" + nam).ToString();
                    thtk.loadton(gridView1, account, accountname, tsbt, ngay);
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}