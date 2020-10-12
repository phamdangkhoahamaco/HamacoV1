using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace HAMACO.Resources
{
    class gencon_vt
    {
        private string constring = @"server=SERVER02;Database=hamaco;UID=sa;PWD=162534;Max Pool Size=300;Min Pool Size=5";
        //ham tra ve mot chuoi ket noi
        public SqlConnection GetConn()
        {
            return new SqlConnection(constring);
        }

        //ham thuc thi khong tra ve ket qua (nhu Insert, Update, Delete) voi doi so la mot cau truy van SQL
        public void ExcuteNonquery(string sql)
        {
            SqlConnection conn = GetConn(); //khai bao 1 doi tuong Connection

            conn.Open(); //mo ket noi

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery(); //thuc thi cau lenh cmd
            conn.Close(); //dong ket noi            
            cmd.Dispose(); //huy cau lenh
        }

        //ham tra ve 1 bang (kieu DataTable) tu cau truy van SQL (de do vao DataGridview)
        public DataTable GetTable(string sql)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn); //thuc thi cau lenh
            da.Fill(dt); // do DL vao DataTable
            conn.Close();
            conn.Dispose();
            da.Dispose();
            return dt;
        }

        //Ham tra ve 1 gia tri duy nhat (dung trong so sanh) duoc ep sang kieu chuoi (string)
        public string GetString(string sql)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            string kq = cmd.ExecuteScalar().ToString(); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            conn.Close();
            cmd.Dispose();
            return kq;
        }
        // cat ngay trong masktexbox
        public DateTime catngay(string mask)
        {
            string m = mask;
            string ngay = m.Substring(0, 2);
            string thang = m.Substring(3, 2);
            string nam = m.Substring(6, 4);
            DateTime date = DateTime.Parse(thang + "/" + ngay + "/" + nam);
            return date;
        }

        public SqlDataAdapter GetData(string sql)
        {
            SqlConnection conn = GetConn();
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            conn.Close();
            return da;
        }
        public string checklog(string user, string pass)
        {
            string kq;
            SqlConnection conn = GetConn();
            conn.Open();

            //kiem tra username nhap vao co ton tai hay khong
            SqlCommand cmd = new SqlCommand("select * from tai_khoan where username='" + user + "'", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) //neu co ket qua (tuc la username ton tai) thi tiep tuc check password
            {
                if (pass == GetString("select password from tai_khoan where username= '" + user + "'").Trim()) //neu pass nhap vao giong' voi pass truy van CSDL thi tra ve 'Role' cua user
                {
                    kq = GetString("select role from tai_khoan where username = '" + user + "'");
                }
                else kq = "pass";//nguoc lai thi tra ve 'pass' (tuc la sai password)
            }
            else kq = "user"; //nguoc lai tra ve "user" (tuc la sai username)
            conn.Close();
            cmd.Dispose();
            return kq;
        }

        public string EncodeMD5(string inputString)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        public void Position(Form F)
        {
            int boundWidth = Screen.PrimaryScreen.Bounds.Width;
            int boundHeight = Screen.PrimaryScreen.Bounds.Height;
            int x = boundWidth - F.Width;
            int y = boundHeight - F.Height;
            F.Location = new Point(x / 2, y / 2);
        }
    }
}
