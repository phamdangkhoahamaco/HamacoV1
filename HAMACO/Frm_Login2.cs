using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
using DevExpress.XtraSplashScreen;
using System.Configuration;

namespace HAMACO
{
    public partial class Frm_Login2 : DevExpress.XtraEditors.XtraForm
    {
        string ver = "V2.1";
       
        public Frm_Login2()
        {
            InitializeComponent();
        }

        private void Frm_Login2_Load(object sender, EventArgs e)
        {
            //load_txtDatabase(); // combo                                 
            //txtDatabase.Text = "hamaco_test";
            //txtDatabase.EditValue = "hamaco";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                login_user();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        

        private void btcancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }


        private void btlogin_Click(object sender, EventArgs e)
        {
            login_user();
            
        }

        private void login_user()
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
            }//
            else
            {


                try
                {


                    //trong luc cho xu lý thì load frm_wait lên
                    //SplashScreenManager.ShowForm(typeof(Frm_wait));
                    gencon gen = new gencon();
                    //XtraMessageBox.Show(Globals.constring, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    string userid = "";
                    try
                    {
                        userid = gen.GetString("select Userid from MSC_User where UserName='" + txtten.Text.Replace("-", "") + "' and Password='" + gen.EncodeMD5(txtmk.Text) + "'");


                        if (userid != "")
                        {
                            this.Text = gen.GetString("select Top 1 CompanyName from Center");
                            Globals.userid = userid;
                            //Globals.clientid = Int32.Parse(txtClient.Text);                    
                            Globals.companycode = gen.GetString2("MSC_User", "CompanyCode", "Userid", userid);
                            Globals.version = gen.GetString("select Version from Center where CompanyCode='" + Globals.companycode + "'");
                            Globals.username = txtten.Text.Replace("-", "").ToUpper();                            
                            Globals.companyname = this.Text;
                            Globals.ngaychungtu = DateTime.Now.ToString();

                            //MainForm F = new MainForm();
                            Frm_Main F = new Frm_Main();
                            F.Show();
                        }
                        else
                        {
                            XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng hay tk bị block", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        //XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtmk.Text = "";
                        txtmk.Focus();
                        XtraMessageBox.Show(ex.Message, "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //SplashScreenManager.CloseForm();
                    }
                }
                catch
                {
                    XtraMessageBox.Show("Kết nối DB không thành công", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}