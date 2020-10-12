using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using HAMACO.Resources;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;

namespace HAMACO
{
    public partial class Frm_login : DevExpress.XtraEditors.XtraForm
    {
        string ver = "V180";
        gencon gen = new gencon();
        public Frm_login()
        {
            InitializeComponent();
        }

        public void delete()
        {
            txtmk.Text=null;
            txtmk.Focus();
        }


        private void btcancel_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("rasdial.exe", "HAMACO-VPN /d");
            this.Dispose();
            this.Close();
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            if (txtten.Text == "Tên đăng nhập" || txtten.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập tên đăng nhập.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtten.Focus();
            }
            else if (txtmk.Text == "Mật khẩu" || txtmk.Text == "")
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmk.Focus();
            }
            else
            {
                                
                try 
                {
                   // gencon gen = new gencon();
                    //trong luc cho xu lý thì load frm_wait lên
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    string userid = "";
                    try {
                        userid = gen.GetString("select Userid from Users where UserName='" + txtten.Text.Replace("-", "") + "' and Password='" + gen.EncodeMD5(txtmk.Text) + "' AND " 
                            + " ClientID =" + txtClient.Text);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        
                    SplashScreenManager.CloseForm();
                    //int clientid = Int16.Parse(txtClientID.Text);

                    Globals.userid = userid;
                    Globals.clientid = Int32.Parse(txtClient.Text);                    
                    Globals.username = txtten.Text.Replace("-", "");
                    Globals.companycode = gen.GetString2("Users", "companycode", "Username", Globals.username, Globals.clientid);
                    Globals.ngaychungtu = DateTime.Now.ToString();
                    //DataTable dtinfo = gen.GetTable("select FullName,BranchName,a.BranchID from MSC_User a with (NOLOCK), Branch b with (NOLOCK) where UserID='" + userid + "' and a.BranchID=b.BranchID ");
                    //Globals.branchid = dtinfo.Rows[0][2].ToString();
                    //Globals.khach = gen.GetTable("select AccountingObjectID as 'ID',AccountingObjectCode as 'Mã khách hàng',AccountingObjectName as 'Tên khách',Address as 'Địa chỉ', CompanyTaxCode as 'Mã số thuế', ContactHomeTel as 'Đội' from AccountingObject with (NOLOCK) order by AccountingObjectCode");
                    //Globals.hang = gen.GetTable("select InventoryItemID as 'ID',InventoryItemCode as 'Mã hàng hóa',InventoryItemName as 'Tên hàng',Unit as 'Đơn vị tính', ConvertUnit as 'Đơn vị quy đổi',convert(decimal(22,2),ConvertRate) as 'Tỷ lệ quy đổi',SalePrice as 'Đơn giá tham khảo',GuarantyPeriod as 'Công ty' from InventoryItem with (NOLOCK) order by InventoryItemCode");
                    //Globals.roleid = gen.GetString("select RoleID from MSC_UserJoinRole with (NOLOCK) where UserID='" + userid + "'");
                    //Form1 F = new Form1();// mo Form 1 báo cáo ghi nợ
                    MainForm F = new MainForm();

                    //F.getform(this); //-- cua Form1
                    //F.getuserid(userid); //-- cua Form1
                    
                    F.Show();
                }
                catch 
                { 
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.","HAMACO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtmk.Text = "";
                    txtmk.Focus();
                    SplashScreenManager.CloseForm();
                }
            }
        }

        private void Frm_login_Load(object sender, EventArgs e)
        {
            
            //load_txtDatabase(); // combo                       

            try
            {
                gen.ExcuteNonquery("select * from Center");
                try
                {                 
                     gen.GetString("select * from Center where Version='" + ver + "'");
                     this.Text = gen.GetString("select Top 1 CompanyName from Center");
                }
                catch
                {
                    XtraMessageBox.Show("Phiên bản bạn đang dùng chưa đúng, vui lòng cập nhật phiên bản mới.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show("Kết nối tới Server chưa được thiết lập, vui lòng kết nối và thử lại.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                XtraMessageBox.Show(ex.Message, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
          
        }

       

        private void txtten_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

       
    }
}