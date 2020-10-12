using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using HAMACO.Resources;
namespace HAMACO
{
    public partial class Frm_center : DevExpress.XtraEditors.XtraForm
    {
        gencon gen = new gencon();
        int cliendid = Globals.clientid;
        string userid = Globals.userid;
        public Frm_center()
        {
            InitializeComponent();
        }

        private void Frm_center_Load(object sender, EventArgs e)
        {
            DataTable da = gen.GetTable("select * from Center");
            for (int i = 0; i < da.Rows.Count; i++)
            {
                txtten.Text = da.Rows[i][0].ToString(); // don vi
                textEdit1.Text = da.Rows[i][1].ToString(); // dia chi
                textEdit2.Text = da.Rows[i][2].ToString(); // nganh nghe
                textEdit3.Text = da.Rows[i][3].ToString(); // dien thoai
                textEdit4.Text = da.Rows[i][4].ToString(); // MST
                textEdit5.Text = da.Rows[i][5].ToString(); // tong giam doc
                textEdit6.Text = da.Rows[i][6].ToString(); //pho GD
                textEdit7.Text = da.Rows[i][7].ToString(); // ke toan truong
                textEdit8.Text = da.Rows[i][8].ToString(); // thu quy
                textEdit9.Text = da.Rows[i][9].ToString(); // phien ban
                textEdit10.Text = da.Rows[i][10].ToString(); // chuc danh
                textEdit11.Text = da.Rows[i][11].ToString(); //  tinh thanh               
                                                             //CompanyName,                Address,                Job, Phone, CompanyTaxCode
                                                             //CEO, DGM, ChiefAccountant, Cashier, Version, Title ,Province
                                                             //Bank,Dongia

            }
        }

        private void btlogin_Click(object sender, EventArgs e)
        {
            gen.ExcuteNonquery("delete from Center");
            // update by Khoa Pham 2/18/2020
            gen.ExcuteNonquery("insert into Center values(N'" + txtten.Text + "',N'" + textEdit1.Text + "',N'" + textEdit2.Text + "',N'" + textEdit3.Text + "',N'" + textEdit4.Text + "',N'" + textEdit5.Text + "',N'" + textEdit6.Text + "',N'" + textEdit7.Text + "',N'" + textEdit8.Text + "','" + textEdit9.Text + "',N'" + textEdit10.Text + "',N'" + textEdit11.Text + "','',0)");
            XtraMessageBox.Show("Hệ thống đã lưu thông tin thay đổi.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            String SQLString = "insert into TransactionFav values(" + cliendid + ",'CE01','" + userid + "')";
            try
            {

                gen.ExcuteNonquery(SQLString);
                XtraMessageBox.Show("Transaction was added to the favorite.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                //txtSQL.Text = SQLString;
                XtraMessageBox.Show("Transaction existed.", "HAMACO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}