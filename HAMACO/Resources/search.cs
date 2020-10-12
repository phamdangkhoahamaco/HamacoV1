using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using HAMACO.Resources;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HAMACO.Resources
{
    class search
    {
        gencon gen = new gencon();
        DataTable hang = new DataTable();
        DataTable khach = new DataTable();
        public DataTable gethang(DataTable a)
        {
            hang = a;
            return hang;
        }
        public DataTable getkhach(DataTable a)
        {
            khach = a;
            return khach;
        }
        public void searchform(string item,string thang,string nam,string userid)
        {
            DataTable temp = new DataTable();
            string id, ngaychungtu, makho;
            if (item.IndexOf("HDMH") >= 0)
            {
                temp = gen.GetTable("select RefID,PURefDate,BranchID from PUInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "' and substring(RefNo,4,12)='" + item + "'");
                id = temp.Rows[0][0].ToString();
                ngaychungtu = temp.Rows[0][1].ToString();
                makho = temp.Rows[0][2].ToString();
                Frm_hdmuahang u = new Frm_hdmuahang();
                u.getactive("1");
                u.getuser(userid);
                u.getdate(ngaychungtu);
                u.gethang(hang);
                u.getkhach(khach);
                u.getbranch(makho);
                u.getrole(id);
                u.ShowDialog();
            }
            else if (item.IndexOf("HDBH") >= 0)
            {
                string roleid = gen.GetString("select RoleID from MSC_UserJoinRole where UserID='" + userid + "'");
                temp = gen.GetTable("select RefID,PURefDate,BranchID,IsExport from SSInvoice where Month(PURefDate)='" + thang + "' and Year(PURefDate)='" + nam + "' and substring(RefNo,4,12)='" + item + "'");
                id = temp.Rows[0][0].ToString();
                ngaychungtu = temp.Rows[0][1].ToString();
                makho = temp.Rows[0][2].ToString();

                if (temp.Rows[0][3].ToString() == "True")
                {
                    Frm_hdbhkpx u = new Frm_hdbhkpx();
                    u.getactive("1");
                    u.getuser(userid);
                    u.getdate(ngaychungtu);
                    u.getbranch(makho);
                    u.getroleid(roleid);
                    u.getpt("pxk");
                    u.getsub("PUmnuBusinessPUInvoiceWithoutStockList");
                    u.gethang(hang);
                    u.getkhach(khach);
                    u.getrole(id);
                    u.ShowDialog();
                }
                else
                {
                    Frm_hdbanhang u = new Frm_hdbanhang();
                    u.getactive("1");
                    u.getuser(userid);
                    u.getdate(ngaychungtu);
                    u.getbranch(makho);
                    u.getroleid(roleid);
                    u.getsub("PUmnuBusinessPUInvoiceWithoutStockList");
                    u.gethang(hang);
                    u.getkhach(khach);
                    u.getrole(id);
                    u.ShowDialog();
                }
            }
            else if (item.IndexOf("XKNB") >= 0)
            {
                temp = gen.GetTable("select RefID,RefDate,OutwardStockID from INTransfer where Month(RefDate)='" + thang + "' and Year(RefDate)='" + nam + "' and substring(RefNo,4,12)='" + item + "'");
                id = temp.Rows[0][0].ToString();
                ngaychungtu = temp.Rows[0][1].ToString();
                makho = temp.Rows[0][2].ToString();
                Frm_chuyenkhonb u = new Frm_chuyenkhonb();
                u.getpt("tsbtpncknb");
                u.getactive("1");
                u.getuser(userid);
                u.gethang(hang);
                u.getkhach(khach);
                u.getdate(ngaychungtu);
                u.getbranch(makho);
                u.getrole(id);
                u.ShowDialog();
            }   
           
        }
    }
}
