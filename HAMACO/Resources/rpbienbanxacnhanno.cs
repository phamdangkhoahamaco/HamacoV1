using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

namespace HAMACO.Resources
{
    public partial class rpbienbanxacnhanno : DevExpress.XtraReports.UI.XtraReport
    {
        public rpbienbanxacnhanno()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        public void gettieude( string ngaychungtu,string denngay, string makhach, string sotien, string tienchu, string kho)
        {
            if (kho == null)
            {
                xrLabel1.Text = xrLabel17.Text = xrLabel24.Text= xrLabel1.Text = gen.GetString("select Top 1 CompanyName from Center");
                xrLabel6.Text = xrLabel14.Text = gen.GetString("select Top 1 Address from Center");
                xrLabel30.Text = "Địa chỉ: " + gen.GetString("select Top 1 Address from Center");
                xrLabel4.Text = xrLabel19.Text = "Điện thoại: " + gen.GetString("select Top 1 Phone from Center");
            }
            else
            {
                xrLabel1.Text = xrLabel17.Text = xrLabel24.Text=xrLabel1.Text = gen.GetString("select InvName from Stock where StockID='" + kho + "'").ToUpper();
                xrLabel6.Text = xrLabel14.Text = gen.GetString("select Description from Stock where StockID='" + kho + "'");
                xrLabel30.Text = "Địa chỉ: " + gen.GetString("select Description from Stock where StockID='" + kho + "'");
                xrLabel4.Text = xrLabel19.Text = "Điện thoại: " + gen.GetString("select Note from Stock where StockID='" + kho + "'");
            }

            DataTable temp = gen.GetTable("select AccountingObjectName,AccountingObjectCode,Address,Tel,Website,ContactTitle from AccountingObject where AccountingObjectID='" + makhach + "'");
            xrLabel11.Text = temp.Rows[0][0].ToString().ToUpper() + " (" + temp.Rows[0][1].ToString()+")";
            string tenkhach = temp.Rows[0][0].ToString().ToUpper();
            xrLabel13.Text = temp.Rows[0][2].ToString();
            xrLabel23.Text = temp.Rows[0][3].ToString();
            xrLabel26.Text = temp.Rows[0][4].ToString();
            xrLabel15.Text = temp.Rows[0][5].ToString();

            string hopdong=null,ngayky=null;

            xrLabel3.Text="Hôm nay, ngày "+String.Format("{0:dd}", DateTime.Parse(ngaychungtu))+" tháng "+String.Format("{0:MM}", DateTime.Parse(ngaychungtu))+" năm "+String.Format("{0:yyyy}", DateTime.Parse(ngaychungtu))+". Chúng tôi gồm có:";

            xrLabel20.Text = xrLabel1.Text+" đề nghị quý khách hàng đối chiếu, xác nhận số dư nợ trên và thanh toán số tiền đến hạn (lãi quá hạn đính kèm bảng kê nếu có) nói trên. Đồng thời gửi lại cho Công ty Chúng tôi theo địa chỉ: ";

            temp= gen.GetTable("select Top 1 a.ParentContract,a.SignedDate from contractB a,(select ParentContract, MAX(SignedDate) as  SignedDate from contractB where AccountingObjectID='" + makhach + "' and SignedDate<='" + denngay + "'and EffectiveDate>='" + denngay + "' group by ParentContract) b where a.ParentContract=b.ParentContract and a.SignedDate=b.SignedDate");
            try
            {
                hopdong = " theo hợp đồng số " + temp.Rows[0][0].ToString();
                ngayky = ", ký ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(temp.Rows[0][1].ToString()));
            }
            catch
            {
                hopdong = null;
                ngayky = null;
            }
            xrLabel5.Text = "- Căn cứ vào các điều khoản, điều kiện thỏa thuận mua bán" + hopdong + ngayky + " giữa " + xrLabel24.Text + " và " + tenkhach + ".";
            xrLabel18.Text = "Tính đến hết ngày " + String.Format("{0:dd/MM/yyyy}", DateTime.Parse(denngay)) + ", Bên mua còn nợ " + xrLabel24.Text;
            xrLabel38.Text=String.Format("{0:n0}", Double.Parse(sotien)) + " đồng./.";
            xrLabel39.Text = "Số tài khoản: "+gen.GetString("select Top 1 Bank from Center");            
            xrLabel29.Text = tienchu;
        }
    }
}
