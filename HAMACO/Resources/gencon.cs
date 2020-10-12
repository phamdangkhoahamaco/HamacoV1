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
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace HAMACO.Resources
{
    class gencon
    {

        // hang tieu dung
        private string constring = Globals.constring;
       // private string constring = @"server=192.168.0.12;Database=hamaco;UID=sa;PWD=HAMsql2008;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60"; 
        //private string constring = @"server=SQL2016A.HAMACO.VN,65102;Database=hamaco;UID=PhamDangKhoa;PWD=Khoa123456;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";
        //--> server chinh        
        //private string constring = @"server=CNTT13;Database=hamaco2;UID=sa;PWD=123456;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";




        ////////private string constringtest = @"server=192.168.0.2;Database=hamaco;UID=sa;PWD=162534;Max Pool Size=300;Min Pool Size=5;Connection Timeout=10";
       // private string constringtest = @"server=192.168.0.12\MSSQLSERVER2008;Database=hamaco;UID=sa;PWD=HAMsql2008;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";
        private string constringtest = Globals.constring;
        //private string constringtest = @"server=SQL2016A.HAMACO.VN,65102;Database=hamaco;UID=PhamDangKhoa;PWD=Khoa123456;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";

        //private string constring = @"server=server02bk;Database=hamaco;UID=sa;PWD=162534;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";
        //private string constring = @"server=192.168.0.2\SQLEXPRESS;Database=hamaco_chk_vt;UID=sa;PWD=162534;Min Pool Size=5; Connect Timeout=600; Max Pool Size=600";
        //private string constring = @"server=.\SQLEXPRESS;Database=hamaco_tn;UID=sa;PWD=162534;Max Pool Size=300;Min Pool Size=5";
        //private string constring = @"server=.\SQLEXPRESS;Database=hamaco_tn;UID=sa;PWD=162534;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";

        //ham tra ve mot chuoi ket noi Connection Timeout=60  +


        public DataTable ConvertToDataTable<T>(IList<T> data)//convert list to datable
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public SqlConnection GetConn()
        {
            return new SqlConnection(constring);
        }

        //var ctx = gen.GetNewEntity(); // khai bao new entity Framework;

        public HamacoV3Entities GetNewEntity() //set new entity framework
        {
            return new HamacoV3Entities ();
        }

        public SqlConnection GetConnTest()
        {
            return new SqlConnection(constringtest);
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

        public string getFieldNameVN(string transactioncode, string FieldName)
        {
            string kq = "";
            var db = GetNewEntity(); // khai bao new entity Framework                   
            var dt = db.Transactions_DynamicReport.FirstOrDefault(x => x.TransactionCode == transactioncode && x.FieldName == FieldName && x.IsInput == 0);            
            if (dt != null)
            {
                kq = dt.FieldNameVN;
            }
            return kq;
        }

        public Boolean checkPermission(string username, string tcode, string CompanyCode)
        {
            Boolean kq = false;
            String rolecode = GetString("select RoleCode from Transactions where TransactionCode='" + tcode  + "'");
            String username2 = GetString("SELECT UserName FROM UserJoinRole WHERE UserName='" + username + "' AND RoleCode='" + rolecode + "' and CompanyCode='" + CompanyCode +"'");
            if (username2 == username)
            {
                kq = true;
            }
            return kq;
        }

        public void ExcuteNonqueryTest(string sql)
        {
            SqlConnection conn = GetConnTest(); //khai bao 1 doi tuong Connection            
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
            da.SelectCommand.CommandTimeout = 600;
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
            string kq = "";
            try {
                kq = cmd.ExecuteScalar().ToString(); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            }
            catch(Exception ex)
            {
                kq = "";
            }
            
            conn.Close();
            cmd.Dispose();
            return kq;
        }



        // Lay du lieu 1 field tu 1 table
      

        public string GetString2(string TableName, string FieldNameGet, string FieldName, string FieldValue)

        {
            SqlConnection conn = GetConn();
            conn.Open();
            String sql = "Select " + FieldNameGet + " FROM " + TableName + " WHERE " + FieldName + "='" + FieldValue + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            string kq = "";
            try
            {
                kq = cmd.ExecuteScalar().ToString(); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            }
            catch
            {
                kq = "";
            }

            conn.Close();
            cmd.Dispose();
            return kq;
        }
        public string GetString2(string TableName, string FieldNameGet, string FieldName, string FieldValue, int clientID)        

        {
            SqlConnection conn = GetConn();
            conn.Open();
            String sql = "Select " + FieldNameGet + " FROM " + TableName + " WHERE " + FieldName + "='" + FieldValue + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            string kq = "";
            try
            {
                kq = cmd.ExecuteScalar().ToString(); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            }
            catch
            {
                kq = "";
            }

            conn.Close();
            cmd.Dispose();
            return kq;
        }
        // field chon kieu int overload
        public string GetString2(string TableName, string FieldNameGet, string FieldName, int FieldValue, int clientID)

        {
            SqlConnection conn = GetConn();
            conn.Open();
            String sql = "Select " + FieldNameGet + " FROM " + TableName + " WHERE " + FieldName + "=" + FieldValue;
            SqlCommand cmd = new SqlCommand(sql, conn);
            string kq = "";
            try
            {
                kq = cmd.ExecuteScalar().ToString(); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            }
            catch
            {
                kq = "";
            }

            conn.Close();
            cmd.Dispose();
            return kq;
        }

        // field chon kieu Guid overload
        public Guid GetString2a(string TableName, string FieldNameGet, string FieldName, string FieldValue)

        {
            SqlConnection conn = GetConn();
            conn.Open();
            String sql = "Select " + FieldNameGet + " FROM " + TableName + " WHERE " + FieldName + "='" + FieldValue + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            Guid kq = Guid.NewGuid();
            try
            {
                kq = Guid.Parse(cmd.ExecuteScalar().ToString()); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            }
            catch
            {               
            }

            conn.Close();
            cmd.Dispose();
            return kq;
        }

        // dk lay 1 field tu 2 field
        public string GetString3(string TableName, string FieldNameGet, string FieldName, string FieldValue, string FieldName2, string FieldValue2)

        {
            SqlConnection conn = GetConn();
            conn.Open();
            String sql = "Select " + FieldNameGet + " FROM " + TableName + " WHERE " + FieldName + "='" + FieldValue + "'";
            sql += " AND " + FieldName2 + "='" + FieldValue2 + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            string kq = "";
            try
            {
                kq = cmd.ExecuteScalar().ToString(); // ep ket qua tra ve sang kieu chuoi va gan vao bien kq
            }
            catch
            {
                kq = "";
            }

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
        public void LogError(Exception ex, string SQLString)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += string.Format("SQL String: {0}", SQLString);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;


            TextWriter txt = new StreamWriter("D:\\log.txt");
            txt.Write(message);
            txt.Close();

        }
        // doi so thanh chu
        public string ChuyenSo(string number)
        {
            string[] strTachPhanSauDauPhay;
            if (number.Contains('.') || number.Contains(','))
            {
                strTachPhanSauDauPhay = number.Split(',', '.');
                return (ChuyenSo(strTachPhanSauDauPhay[0]) + " lẻ " + ChuyenSo(strTachPhanSauDauPhay[1]).Replace(" đồng.", " xu"));
            }

            string[] dv = { "", "mươi", "trăm", "nghìn", "triệu", "tỷ" };
            string[] cs = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string doc;
            int i, j, k, n, len, found, ddv, rd;

            len = number.Length;
            number += "ss";
            doc = "";
            found = 0;
            ddv = 0;
            rd = 0;

            i = 0;
            while (i < len)
            {
                //So chu so o hang dang duyet
                n = (len - i + 2) % 3 + 1;

                //Kiem tra so 0
                found = 0;
                for (j = 0; j < n; j++)
                {
                    if (number[i + j] != '0')
                    {
                        found = 1;
                        break;
                    }
                }

                //Duyet n chu so
                if (found == 1)
                {
                    rd = 1;
                    for (j = 0; j < n; j++)
                    {
                        ddv = 1;
                        switch (number[i + j])
                        {
                            case '0':
                                if (n - j == 3) doc += cs[0] + " ";
                                if (n - j == 2)
                                {
                                    if (number[i + j + 1] != '0') doc += "lẻ ";
                                    ddv = 0;
                                }
                                break;
                            case '1':
                                if (n - j == 3) doc += cs[1] + " ";
                                if (n - j == 2)
                                {
                                    doc += "mười ";
                                    ddv = 0;
                                }
                                if (n - j == 1)
                                {
                                    if (i + j == 0) k = 0;
                                    else k = i + j - 1;

                                    if (number[k] != '1' && number[k] != '0')
                                        doc += "mốt ";
                                    else
                                        doc += cs[1] + " ";
                                }
                                break;
                            case '5':
                                if (((i + j) % 3 == len % 3 - 1 && j != 0))
                                {
                                    doc += "lăm ";
                                }
                                else
                                {
                                    doc += cs[5] + " ";
                                }
                                break;
                            default:
                                doc += cs[(int)number[i + j] - 48] + " ";
                                break;
                        }

                        //Doc don vi nho
                        if (ddv == 1)
                        {
                            doc += ((n - j) != 1) ? dv[n - j - 1] + " " : dv[n - j - 1];
                        }
                    }
                }


                //Doc don vi lon
                if (len - i - n > 0)
                {
                    if ((len - i - n) % 9 == 0)
                    {
                        if (rd == 1)
                            for (k = 0; k < (len - i - n) / 9; k++)
                                doc += "tỷ ";
                        rd = 0;
                    }
                    else
                        if (found != 0) doc += dv[((len - i - n + 1) % 9) / 3 + 2] + " ";
                }

                i += n;
            }

            if (len == 1)
                if (number[0] == '0' || number[0] == '5') return cs[(int)number[0] - 48];

            doc = doc.Substring(0, 1).ToUpper() + doc.Substring(1, doc.Length - 1);
            return (doc + "đồng.").Replace("mươi năm", "mươi lăm").Replace("lẻ lăm", "lẻ năm");
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



        /* lệnh xuất excel-----------------------------------------------------------*/
        public void CreateExcel(DataSet ds,string name)
        {
            try
            {
                //  In DEBUG mode, I'll just hardcode a path & filename to write to.
                string targetFilename = "C:\\Sample.xlsx";
                try
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    // Prompt the user to enter a path/filename to save an example Excel file to
                    saveFileDialog1.FileName = name;
                    saveFileDialog1.Filter = "Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.OverwritePrompt = false;

                    //  If the user hit Cancel, then abort!
                    if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    targetFilename = saveFileDialog1.FileName;
                }
                catch { }

                //  Step 1: Create a DataSet, and put some sample data in it
                // DataSet ds = CreateSampleData();

                //  Step 2: Create the Excel file

                try
                {
                    System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
                    customCulture.NumberFormat.NumberGroupSeparator = ",";
                    customCulture.NumberFormat.NumberDecimalSeparator = ".";
                    System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

                    CreateExcelFile.CreateExcelDocument(ds, targetFilename);

                    customCulture.NumberFormat.NumberGroupSeparator = ".";
                    customCulture.NumberFormat.NumberDecimalSeparator = ",";
                    System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Couldn't create Excel file.\r\nException: " + ex.Message);
                    return;
                }

                //  Step 3:  Let's open our new Excel file and shut down this application.
                DialogResult dr = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có muốn mở tập tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    Process p = new Process();
                    p.StartInfo = new ProcessStartInfo(targetFilename);
                    p.Start();
                }
            }
            catch { }

           
        }

        public void ViewExcel(DevExpress.XtraGrid.Views.Grid.GridView view, string name)
        {
            string targetFilename = "D:\\Danhsach.xlsx";
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = name;
            saveFileDialog1.Filter = "Excel 2007 files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.OverwritePrompt = false;
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            targetFilename = saveFileDialog1.FileName;

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberGroupSeparator = ",";
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            view.ExportToXlsx(targetFilename);

            customCulture.NumberFormat.NumberGroupSeparator = ".";
            customCulture.NumberFormat.NumberDecimalSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            DialogResult dr = DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có muốn mở tập tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(targetFilename);
                p.Start();
            }            
        }



        bool LaNamNhuan(int Nam)
        {
            if (Nam % 4 != 0) return false;
            if (Nam % 100 != 0) return true;
            if (Nam % 400 != 0) return false;
            return true;
        }

        int SoNgayTrongNam(int Nam)
        {
            if (LaNamNhuan(Nam)) return 366;
            return (365);
        }

        int SoNgayTruocNam(int Nam)
        {
            int TongSoNgayTruoc = 0;
            for (int i = 1; i < Nam; i += 1)
                TongSoNgayTruoc += SoNgayTrongNam(i);
            return TongSoNgayTruoc;
        }

        int SoNgayTrongThang(int Nam, int Thang)
        {
            switch (Thang)
            {
                case 4:
                case 6:
                case 9:
                case 11: return 30;
                case 2:
                    {
                        if (LaNamNhuan(Nam)) return 29;
                        return 28;
                    }
                default: return 31;
            }
        }

        int SoNgayTruocThang(int Nam, int Thang)
        {
            var SoNgay = 0;
            for (int i = 1; i < Thang; i += 1)
                SoNgay += SoNgayTrongThang(Nam, i);
            return SoNgay;
        }

        int TongSoNgay(int Nam, int Thang, int Ngay)
        {
            return SoNgayTruocNam(Nam) + SoNgayTruocThang(Nam, Thang) + Ngay;
        }

        public string NgayTrongTuan(int Nam, int Thang, int Ngay)
        {
            switch (TongSoNgay(Nam, Thang, Ngay) % 7)
            {
                case 0: return "CN";
                case 1: return "2";
                case 2: return "3";
                case 3: return "4";
                case 4: return "5";
                case 5: return "6";
                default: return "7";
            }
        }


     }
}
