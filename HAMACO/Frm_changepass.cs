using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;
namespace HAMACO
{
    public partial class Frm_changepass : DevExpress.XtraEditors.XtraForm
    {
        public Frm_changepass()
        {
            InitializeComponent();
        }
        gencon gen = new gencon();
        string userid;

        public string getuser(string a)
        {
            userid = a;
            return userid;
        }

        private void Frm_changepass_Load(object sender, EventArgs e)
        {
            txtten.Text = gen.GetString("select UserName from MSC_User where UserID='" + userid + "'");
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            if (txtmk.Text != textEdit2.Text || txtmk.Text=="")
            {
                XtraMessageBox.Show("Mật khẩu mới chưa khớp hoặc bạn chưa nhập mật khẩu mới.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textEdit2.Text = "";
                txtmk.Text = "";
                txtmk.Focus();
            }
            else
            {
                try
                {
                    SplashScreenManager.ShowForm(typeof(Frm_wait));
                    string userid = gen.GetString("select Userid from MSC_User where UserName='" + txtten.Text + "' and Password='" + gen.EncodeMD5(textEdit1.Text) + "'");
                    gen.ExcuteNonquery("update MSC_User set Password='" + gen.EncodeMD5(txtmk.Text) + "' where UserID='"+userid+"'");
                    XtraMessageBox.Show("Mật khẩu của bạn đã được thay đổi.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textEdit1.Text = "";
                    textEdit2.Text = "";
                    txtmk.Text = "";
                    textEdit1.Focus();
                    SplashScreenManager.CloseForm();
                }
                catch
                {
                    XtraMessageBox.Show("Mật khẩu hiện tại không đúng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textEdit1.Text = "";
                    textEdit1.Focus();
                    SplashScreenManager.CloseForm();
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}