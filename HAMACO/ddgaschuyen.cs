using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace HAMACO
{
    public partial class ddgaschuyen : DevExpress.XtraEditors.XtraForm
    {
        public ddgaschuyen()
        {
            InitializeComponent();
        }
        string tsbt = null;
        public string gettsbt(string a)
        {
            tsbt = a;
            return tsbt;
        }

        Form1 F;
        public Form getform(Form1 a)
        {
            F = a;
            return F;
        }

        private void ddgaschuyen_Load(object sender, EventArgs e)
        {
            cbgiaonhan.Properties.Items.Clear();
            cbgiaonhan.Properties.Items.Add("ĐOÀN VĂN ĐẠT");
            cbgiaonhan.Properties.Items.Add("Lê Trung Nghĩa");
            cbgiaonhan.Properties.Items.Add("LÝ CHÍ THẢO");
            cbgiaonhan.Properties.Items.Add("Mai Đình Hướng");
            cbgiaonhan.Properties.Items.Add("Nguyễn Anh Khoa");
            cbgiaonhan.Properties.Items.Add("NGUYỄN CÔNG VĂN");
            cbgiaonhan.Properties.Items.Add("NGUYỄN ĐÔNG GIANG");
            cbgiaonhan.Properties.Items.Add("Nguyễn Phúc Hậu");
            cbgiaonhan.Properties.Items.Add("Nguyễn Hữu Tấn");
            cbgiaonhan.Properties.Items.Add("Nguyễn Văn Ngọc");
            cbgiaonhan.Properties.Items.Add("Phan Thành Trung");
            cbgiaonhan.Properties.Items.Add("Thạch Khanh");
            cbgiaonhan.Properties.Items.Add("THÁI TRUNG HẬU");


            cbgiaonhan.SelectedIndex = -1;


            cbpt.Properties.Items.Clear();

            cbpt.Properties.Items.Add("Dương Thanh Châu");
            cbpt.Properties.Items.Add("ĐẶNG QUANG HOÀNG PHÚC");
            cbpt.Properties.Items.Add("ĐOÀN VĂN ĐẠT");
            cbpt.Properties.Items.Add("Lê Quốc Tuấn");
            cbpt.Properties.Items.Add("LÝ CHÍ THẢO");
            cbpt.Properties.Items.Add("Mai Vĩnh Xuyên");
            cbpt.Properties.Items.Add("NGÔ MẠNH TUẤN");
            cbpt.Properties.Items.Add("NGUYỄN ĐÔNG GIANG");
            cbpt.Properties.Items.Add("NGUYỄN MINH TRIỀU");
            cbpt.Properties.Items.Add("Nguyễn Phúc Hậu");
            cbpt.Properties.Items.Add("Nguyễn Quan Phương");
            cbpt.Properties.Items.Add("Nguyễn Thanh Sang");
            cbpt.Properties.Items.Add("NGUYỄN THANH HÙNG");
            cbpt.Properties.Items.Add("Nguyễn Thành Nghĩa");
            cbpt.Properties.Items.Add("NGUYỄN VĂN THĂM");
            cbpt.Properties.Items.Add("Thạch Khanh");
            cbpt.Properties.Items.Add("THÁI TRUNG HẬU");
            cbpt.Properties.Items.Add("THÁI VĂN BẰNG");
            cbpt.Properties.Items.Add("THÁI VĂN TUỆ");
            cbpt.Properties.Items.Add("Trần Anh Đức");
            cbpt.Properties.Items.Add("TRẦN CHÍ LINH");
            cbpt.Properties.Items.Add("Trần Văn Kiệt");

            cbpt.SelectedIndex = -1;


            cbptgh.Properties.Items.Clear();
            cbptgh.Properties.Items.Add("65C 01957");
            cbptgh.Properties.Items.Add("65C 01994");
            cbptgh.Properties.Items.Add("65C 03771");
            cbptgh.Properties.Items.Add("65C 04847");
            cbptgh.Properties.Items.Add("65C 04962");
            cbptgh.Properties.Items.Add("65C 05132");
            cbptgh.Properties.Items.Add("65C 6126");
            cbptgh.Properties.Items.Add("65C 08559");

            cbptgh.Properties.Items.Add("65N 0285");
            cbptgh.Properties.Items.Add("65N 1443");
            cbptgh.Properties.Items.Add("65M 2064");
            cbptgh.Properties.Items.Add("65M 2856");

            cbptgh.SelectedIndex = -1;
            
        }

        private void sbok_Click(object sender, EventArgs e)
        {
              DialogResult dr = XtraMessageBox.Show("Bạn có thực sự muốn thay đổi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
              if (dr == DialogResult.Yes)
              {
                  F.refreshddhlpgcapnhap(cbptgh.Text, cbpt.Text, cbgiaonhan.Text);
                  this.Dispose();
                  this.Close();
              }
        }
    }
}