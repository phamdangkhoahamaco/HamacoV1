using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Diagnostics;

using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using DevExpress.Export;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Net.Mail;
using System.Net;

//using System.Data.SQLite;||

namespace HAMACO
{
    public static class p
    {


        public static string strConnectPayroll = "";
        public static string passwordPayroll = "";
        public static string strsql = @"Data Source=192.168.1.99;Initial Catalog=payroll;User Id=sa;Password=admin@123;";
        //public static string strsql = @"Data Source=192.168.1.99;Initial Catalog=payroll-temp-28-05;User Id=sa;Password=admin@123;";
        public static string strsqlite = @"Data Source = D:\Production\hrd.db;Version=3";
        //connect to IE
        public static string strie = @"Data Source=192.168.1.99;Initial Catalog=ie;User Id=sa;Password=admin@123;";
        public static string strieW = @"Data Source=192.168.1.99;Initial Catalog=ieW;User Id=sa;Password=admin@123;";
        public static string strieZ = @"Data Source=192.168.1.99;Initial Catalog=ieZ;User Id=sa;Password=admin@123;";

        public static int start = 0;
        public static string group, user;
        public static SqlConnection consql = new SqlConnection(strsql);
        public static SqlConnection conie = new SqlConnection(strie);
        public static SqlConnection conieW = new SqlConnection(strieW);
        public static SqlConnection conieZ = new SqlConnection(strieZ);
        //public static SqlCommand cmd;
        
       

        public static SqlDataAdapter dauser;
        public static BindingSource bsuser;
        public static DataTable dtuser;

        public static SqlCommandBuilder cb;

        public static SqlDataAdapter datemp;
        public static DataSet dstemp;
        public static BindingSource bstemp;
        public static DataTable dttemp;



        //maximize form, tabcontrol, datagridview

        public static void Maximiumpic(Form form, PictureBox pic)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            form.WindowState = FormWindowState.Maximized;
            pic.Width = wi * 98 / 100;
            pic.Height = hi * 90 / 100;

        }

        public static void MaximiumSCreen(Form form, TabControl tabctl, DataGridView dgr)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            form.WindowState = FormWindowState.Maximized;
            tabctl.Width = wi;
            tabctl.Height = hi;
            dgr.Width = wi * 98 / 100;
            dgr.Height = hi * 60 / 100;
            //dgr.DefaultCellStyle.font = new font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);

        }

        public static void setGridFont(Form form, TabControl tabctl, DataGridView dgr)
        {
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);


        }

        public static void MaximiumSCreen(Form form, TabControl tabctl, GridControl gridControl)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            form.WindowState = FormWindowState.Maximized;
            tabctl.Width = wi;
            tabctl.Height = hi;
            gridControl.Width = wi * 98 / 100;
            gridControl.Height = hi * 60 / 100;


        }

        public static void PerfectSCreen(Form form, TabControl tabctl, DataGridView dgr)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            //form.WindowState = FormWindowState.Maximized;
            form.Width = wi * 100 / 100;
            form.Height = hi;
            tabctl.Width = wi * 100 / 100;
            tabctl.Height = hi;
            dgr.Width = wi * 97 / 100;


            //dgr.Height = hi * 70 / 100;
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);

        }

        public static void SCreen_ViewWidth(Form form, TabControl tabctl, DataGridView dgr)
        {
            int wi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            //hi = Screen.PrimaryScreen.Bounds.Height;
            form.WindowState = FormWindowState.Maximized;
            form.Width = wi * 100 / 100;
            //form.Height = hi;
            tabctl.Width = wi * 100 / 100;
            //tabctl.Height = hi;
            dgr.Width = wi * 97 / 100;


            //dgr.Height = hi * 70 / 100;
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);

        }
        public static void PerfectSCreen_ratio(Form form, TabControl tabctl, DataGridView dgr, int ratio)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            form.WindowState = FormWindowState.Maximized;
            tabctl.Width = wi;
            tabctl.Height = hi;
            dgr.Width = wi * 98 / 100;
            dgr.Height = hi * ratio / 100;
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);

        }

        public static void SCreen_view(Form form, TabControl tabctl, DataGridView dgr, int ratio)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            //form.WindowState = FormWindowState.Maximized;
            form.StartPosition = FormStartPosition.Manual;
            form.Left = 0;
            form.Top = 0;

            form.Height = hi * (ratio + 4) / 100;
            form.Width = wi * (ratio + 4) / 100;
            tabctl.Width = wi * (ratio + 2) / 100;
            tabctl.Height = hi * (ratio + 2) / 100;
            dgr.Width = wi * (ratio) / 100;
            dgr.Height = hi * (ratio - 20) / 100;
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);

        }

        public static void SCreen_gridView3column(Form form, TabControl tabctl, DataGridView dgr, int formheight_ratio, int formwidth_ratio, int ratioGirdheight, int ratioGridwidth)
        {
            int wi, hi;
            wi = Screen.PrimaryScreen.Bounds.Width;
            hi = Screen.PrimaryScreen.Bounds.Height;
            //form.WindowState = FormWindowState.Maximized;
            form.StartPosition = FormStartPosition.Manual;
            form.Left = 0;
            form.Top = 0;
            form.Height = hi * formheight_ratio / 100;
            form.Width = wi * formwidth_ratio / 100;
            tabctl.Width = wi * formwidth_ratio / 100;
            tabctl.Height = hi * formheight_ratio / 100;
            dgr.Width = wi * (ratioGridwidth) / 100;
            dgr.Height = hi * (ratioGirdheight) / 100;
            dgr.DefaultCellStyle.Font = new System.Drawing.Font("tahoma", 9, System.Drawing.FontStyle.Regular, GraphicsUnit.Point);
            dgr.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("tahoma", 8, FontStyle.Bold, GraphicsUnit.Point);

        }

        public static void Updatex(SqlDataAdapter dax, DataSet dsx, BindingSource bsx)
        {

            var ci = bsx.Position;
            if (ci > 0) { bsx.MovePrevious(); bsx.MoveNext(); }
            else { bsx.MovePrevious(); }

            try
            {
                cb = new SqlCommandBuilder(dax);
                cb.GetUpdateCommand();
                dax.Update(dsx.Tables[0]);
                dax.SelectCommand.CommandTimeout = 300;
                dsx.AcceptChanges();
                cb.Dispose();
            }
            catch { MessageBox.Show("Can not Save! Please check again"); }

        }

        public static void Updatetable(SqlDataAdapter dax, DataTable dtx, BindingSource bsx)
        {

            var ci = bsx.Position;
            if (ci > 0) { bsx.MovePrevious(); bsx.MoveNext(); }
            else { bsx.MovePrevious(); }

            try
            {
                cb = new SqlCommandBuilder(dax);
                cb.GetUpdateCommand();
                dax.Update(dtx);
                dax.SelectCommand.CommandTimeout = 300;
                dtx.AcceptChanges();
                cb.Dispose();
            }
            catch (OleDbException err) { MessageBox.Show("ERROR:" + err.Source + " " + err.Message, "ERROR"); return; }
            //catch { MessageBox.Show("Can not Save! Please check again"); }

        }

        public static void UpdatetableOLE(OleDbDataAdapter dax, DataTable dtx, BindingSource bsx)
        {

            var ci = bsx.Position;
            if (ci > 0) { bsx.MovePrevious(); bsx.MoveNext(); }
            else { bsx.MovePrevious(); }

                OleDbCommandBuilder cb1 = new OleDbCommandBuilder(dax);
                cb1.GetUpdateCommand();
                dax.Update(dtx);
                dax.SelectCommand.CommandTimeout = 300;
                dtx.AcceptChanges();
                cb1.Dispose();
          
        }
        public static void UpdateOle(OleDbDataAdapter dax, DataSet dsx, BindingSource bsx)
        {

            var ci = bsx.Position;
            if (ci > 0)
            {
                bsx.MovePrevious();
                bsx.MoveNext();
            }
            else
            { bsx.MovePrevious(); }
            try
            {

                OleDbCommandBuilder cb = new OleDbCommandBuilder(dax);
                cb.GetUpdateCommand();
                dax.Update(dsx.Tables[0]);
                dax.SelectCommand.CommandTimeout = 300;
                dsx.AcceptChanges();
                cb.Dispose();
            }
            catch { MessageBox.Show("Can not Save! Please check again"); }

        }

    
     
       
       public static string Right(string value, int length)
        {
            return value.Substring(value.Length - length, length);
        }

        public static string Left(string value, int length)
        {
            return value.Substring(0, length);
        }

        public static string Mid(string str, int index, int len)
        {
            return str.Substring(index, len);
        }

        public static string Mid_To_All(string str, int index)
        {
            return str.Substring(index);
        }

        public static void month(ComboBox monthi)
        {
            if (monthi.Items.Count == 0)
            {
                string mi; DateTime now = DateTime.Now; int year = now.Year; int month = now.Month;

                if (now.Month <= 3) { year = year - 1; }
                for (int i = 3; i <= 12; i++) { if (i < 10) { mi = "0" + i.ToString(); } else { mi = i.ToString(); } monthi.Items.Add(mi + "/" + year.ToString()); }
                for (int i = 1; i <= 3; i++) { mi = "0" + i.ToString(); monthi.Items.Add(mi + "/" + (year + 1).ToString()); }

                start = 1;
                if (month < 10) { monthi.Text = "0" + month.ToString() + "/" + now.Year.ToString(); }
                else { monthi.Text = month.ToString() + "/" + now.Year.ToString(); }
            }
        }

        public static void month_showprevious(ComboBox monthi)
        {
            if (monthi.Items.Count == 0)
            {
                string mi; DateTime now = DateTime.Now; int year = now.Year; int month = now.Month;

                if (now.Month <= 3) { year = year - 1; }
                for (int i = 3; i <= 12; i++) { if (i < 10) { mi = "0" + i.ToString(); } else { mi = i.ToString(); } monthi.Items.Add(mi + "/" + year.ToString()); }
                for (int i = 1; i <= 3; i++) { mi = "0" + i.ToString(); monthi.Items.Add(mi + "/" + (year + 1).ToString()); }

                start = 1;
                year = now.Year;
                month = now.Month - 1;

                if (month == 0) { month = 12; year = year - 1; }

                if (month < 10) { monthi.Text = "0" + month.ToString() + "/" + year.ToString(); }
                else { monthi.Text = month.ToString() + "/" + year.ToString(); }
                //monthi.Text = "Select month";
            }
        }

        public static void month_showpreviousDev(DevExpress.XtraEditors.Repository.RepositoryItemComboBox monthi)
        {
            if (monthi.Items.Count == 0)
            {
                string mi; DateTime now = DateTime.Now; int year = now.Year; int month = now.Month;

                if (now.Month <= 3) { year = year - 1; }
                for (int i = 3; i <= 12; i++) { if (i < 10) { mi = "0" + i.ToString(); } else { mi = i.ToString(); } monthi.Items.Add(mi + "/" + year.ToString()); }
                for (int i = 1; i <= 3; i++) { mi = "0" + i.ToString(); monthi.Items.Add(mi + "/" + (year + 1).ToString()); }

                start = 1;
                year = now.Year;
                month = now.Month - 1;

                if (month == 0) { month = 12; year = year - 1; }

                //if (month < 10) { monthi.editva = "0" + month.ToString() + "/" + year.ToString(); }
                //else { monthi.Text = month.ToString() + "/" + year.ToString(); }
                //monthi.Text = "Select month";
            }
        }

        public static void division(ComboBox division)
        {
            if (division.Items.Count == 0)
            {

                SqlDataAdapter datemp = new SqlDataAdapter("select distinct division from Mdivision ", p.consql);
                DataTable dttemp = new DataTable();
                datemp.Fill(dttemp);

                division.DataSource = dttemp;
                division.DisplayMember = "division";
                //division.ValueMember = "Value";
            }
        }

        public static void textbox_click(TextBox textbox)
        { textbox.Text = ""; }
        public static void textbox_leave(TextBox textbox)
        { if (textbox.Text == "") { textbox.Text = "Search ID"; textbox.ForeColor = Color.DimGray; } }
        public static void textbox_change(TextBox textbox, BindingSource bindingsource)
        {
            try
            {
                if (textbox.Text == "Search ID") { p.start = 1; return; }
                textbox.ForeColor = Color.Black;
                if (textbox.Text == "") { bindingsource.Filter = "id <> '00000'"; }
                else { bindingsource.Filter = "id = '" + textbox.Text + "'"; }
            }
            catch { return; }
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static int default_Workingdays(string month)
        {
            string mi, yi;
            mi = p.Left(month, 2); yi = p.Right(month, 4);
            int days = DateTime.DaysInMonth(Convert.ToInt32(yi), Convert.ToInt32(mi));

            DateTime date1, date2;
            date1 = Convert.ToDateTime(yi + "-" + mi + "-01");
            date2 = Convert.ToDateTime(mi + "-" + yi + "-" + days);
            return (days - p.NumberOfSunday(date1, date2));
        }

        public static DateTime month15(DateTime date)
        {
            int mi, yi;
            mi = date.Month; yi = date.Year;
            if (date.Day <= 15) { if (mi == 1) { mi = 12; yi = yi - 1; } else { mi = mi - 1; } }

            return Convert.ToDateTime(yi + "-" + mi + "-15");
        }

        public static DateTime End_Contract(DateTime start_Contract, int Nums_Day)
        {
            DateTime datei = DateTime.Now;
            int di, mi, yi, days;

            di = start_Contract.Day; mi = start_Contract.Month; yi = start_Contract.Year;
            days = DateTime.DaysInMonth(yi, mi);

            if (Nums_Day < 30)
            {
                datei = start_Contract.AddDays(Nums_Day + 1);
            }
            if (Nums_Day == 30)
            {
                mi = mi + 1;

                if (mi > 12) { mi = mi - 12; yi = yi + 1; }
                try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + di); }
                catch
                {
                    try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 1)); }
                    catch
                    {
                        try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 2)); }
                        catch
                        {
                            try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 3)); }
                            catch { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 4)); }
                        }
                    }
                }
            }

            if (Nums_Day == 60)
            {
                mi = mi + 2;
                if (mi > 12) { mi = mi - 12; yi = yi + 1; }
                try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + di); }
                catch
                {
                    try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 1)); }
                    catch
                    {
                        try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 2)); }
                        catch
                        {
                            try { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 3)); }
                            catch { datei = Convert.ToDateTime(yi + "-" + mi + "-" + (di - 4)); }
                        }
                    }
                }

            }

            return datei;

        }

        public static int mod(int a, int b)
        { return a - (int)(a / b) * b; }


        public static void user_right(string str, GroupBox gb)
        {
            gb.Enabled = false;
            if (str == p.group || str == "administrator") { gb.Enabled = true; }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
            //yourImage = resizeImage(yourImage, new Size(480,719));
        }

        public static string FirstUcaseLetter(string str)
        {
            string finalstr = "";
            var split = str.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                finalstr = finalstr + " " + split[i].First().ToString().ToUpper() + split[i].Substring(1);
            }
            return finalstr;
        }


        public static Bitmap Resize(Image image, int setWidth)
        {
            //System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(OriginalFileLocation);


            //width=1024, height 1536
            int originWidth = image.Width; int originHeight = image.Height;
            int newWidth, newHeight;

            ////Lấy theo newheight
            //if (newWidth >= newHeight)
            //{
            //    if (newHeight > maxHeight) {  newHeight = maxHeight; newWidth = newWidth * maxHeight / image.Height; }

            //}
            //lay theo width
            //else
            //{
            newWidth = originWidth; newHeight = originHeight;
            if (originWidth > setWidth) { newWidth = setWidth; newHeight = originHeight * setWidth / originWidth; }
            //}


            var res = new Bitmap(newWidth, newHeight);

            using (var graphic = Graphics.FromImage(res))
            {
                graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphic.SmoothingMode = SmoothingMode.HighQuality;
                graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphic.CompositingQuality = CompositingQuality.HighQuality;
                graphic.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return res;
        }

        public static void load_picture(string sourcepath, string targetpath)
        {
            //copy image
            System.Drawing.Image originimage = System.Drawing.Image.FromFile(sourcepath);
            Bitmap bmpImg;
            bmpImg = Resize(originimage, 1024);

            //string imgpath = @"C:\Users\Minh Tri\Desktop\process\10015.jpg";
            bmpImg.Save(targetpath, ImageFormat.Jpeg);
        }

        public static bool Exist_Drive()
        {
            try
            {
                if (!System.IO.Directory.Exists(@"R:\")) { System.Diagnostics.Process.Start("net.exe", @"use R: ""\\192.168.1.202\d$"" /user:192.168.1.202\admin admin123").WaitForExit(); }
                if (!System.IO.Directory.Exists(@"T:\")) { System.Diagnostics.Process.Start("net.exe", @"use T: ""\\192.168.1.200\d$"" /user:192.168.1.200\admin admin123").WaitForExit(); }
                if (!System.IO.Directory.Exists(@"W:\")) { System.Diagnostics.Process.Start("net.exe", @"use W: ""\\192.168.1.201\d$"" /user:192.168.1.201\admin admin123").WaitForExit(); }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Map_Drive()
        {

            if (!System.IO.Directory.Exists(@"R:\")) { System.Diagnostics.Process.Start("net.exe", @"use R: ""\\192.168.1.202\d$"" /user:192.168.1.202\admin admin123").WaitForExit(); }

            if (!System.IO.Directory.Exists(@"T:\")) { System.Diagnostics.Process.Start("net.exe", @"use T: ""\\192.168.1.200\d$"" /user:192.168.1.200\admin admin123").WaitForExit(); }

            if (!System.IO.Directory.Exists(@"W:\")) { System.Diagnostics.Process.Start("net.exe", @"use W: ""\\192.168.1.201\d$"" /user:192.168.1.201\admin admin123").WaitForExit(); }


            if (!System.IO.Directory.Exists(@"R:\")) { MessageBox.Show("Drive R does not exist!", "Warning"); }
            if (!System.IO.Directory.Exists(@"T:\")) { MessageBox.Show("Drive T does not exist!", "Warning"); }
            if (!System.IO.Directory.Exists(@"W:\")) { MessageBox.Show("Drive W does not exist!", "Warning"); }

            //System.Diagnostics.Process.Start("net.exe", @"use R: /delete").WaitForExit();
            //System.Diagnostics.Process.Start("net.exe", @"use t: /delete").WaitForExit();
            //System.Diagnostics.Process.Start("net.exe", @"use w: /delete").WaitForExit();
        }

    
        public static int NumberOfSunday(DateTime start, DateTime end)
        {
            DateTime datei;
            int i, count;

            //check how many days
            int days = Convert.ToInt16((end.Date - start.Date).TotalDays + 1);
            datei = start; count = 0;
            for (i = 1; i <= days; i++)
            {
                if (datei.DayOfWeek == DayOfWeek.Sunday) { count += 1; }
                datei = datei.AddDays(1);
            }
            return count;
        }

        public static void export_Excel(string tenFile, GridView view, bool exportText = false)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel 2007-2010(*.xlsx) |*.xlsx|Excel 97-2003(*.xls)|*.xls";
            sf.AddExtension = true;
            sf.FileName = tenFile;
            if (sf.ShowDialog() == DialogResult.OK)
            {
                if (sf.FileName.Contains(".xlsx"))
                {
                    XlsxExportOptionsEx option = new XlsxExportOptionsEx();
                    
                    if (exportText)
                        option.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
                    option.ExportType = ExportType.WYSIWYG;
                    view.ExportToXlsx(sf.FileName, option);
                    
                }
                else if (sf.FileName.Contains(".xls"))
                {
                    XlsExportOptionsEx option = new XlsExportOptionsEx();
                    if (exportText)
                        option.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;
                    option.ExportType = ExportType.WYSIWYG;
                    view.ExportToXls(sf.FileName, option);
                }

                //if (XtraMessageBox.Show("Export excel, Bạn có muốn mở nó ngay?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                System.Diagnostics.Process.Start(sf.FileName);
            }
        }

        public static void _ShowMDIForm(Form FrmCha, Form FrmCon, bool IsShowDialog)
        {
            bool _valid = false;
            if (FrmCha != null)
            {
                //if (!FrmCon.Text.Contains("ATT -"))
                //foreach (Form _frm in FrmCha.MdiChildren)
                //{
                //    if (_frm.Text == FrmCon.Text)
                //    {
                //        _frm.Activate();
                //        _frm.BringToFront();
                //        if (_frm.WindowState == FormWindowState.Minimized)
                //            _frm.WindowState = FormWindowState.Maximized;

                //        _valid = true;
                //        break;
                //        return;
                //    }

                //}
            }
            if (!_valid)
            {
                if (!IsShowDialog)
                {
                    FrmCon.MdiParent = FrmCha;
                    FrmCon.Show();
                }
                else
                {
                    FrmCon.Activate();
                    FrmCon.BringToFront();
                    FrmCon.ShowDialog();
                }
            }
        }

      

     

        public static DataTable _SQLTraveDatatable(string SQL, SqlConnection conn)
        {
            SqlDataAdapter da = new SqlDataAdapter(SQL, conn);
            da.SelectCommand.CommandTimeout = 0;
            DataSet dt = new DataSet();
            da.Fill(dt);
            return dt.Tables[0];
        }

        public static Boolean IsWorker(string jobtitle)
        {
            //18052020 bổ sung barcoder
            //09072020 bỏ technical operator và custodian
            if (jobtitle.ToLower() == "technical operator" || jobtitle.ToLower() == "custodian" || jobtitle.ToLower() == "cleaner" || jobtitle.ToLower() == "barcoder" || jobtitle.ToLower() == "worker" || jobtitle.ToLower() == "mover" || jobtitle.ToLower() == "technician" || jobtitle.ToLower() == "craftsman" || jobtitle.ToLower() == "sample maker" || jobtitle.ToLower() == "warehouse helper" || jobtitle.ToLower() == "inspector")
            {
                return true;
            }else
                return false;
        }
   
       
         
        public static DateTime MondayOfWeek(this DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Sunday)
            {
                //xét chủ nhật là đầu tuần thì thứ 2 là ngày kế tiếp nên sẽ tăng 1 ngày  
                //return date.AddDays(1);  

                // nếu xét chủ nhật là ngày cuối tuần  
                return date.AddDays(-6);
            }

            // nếu không phải thứ 2 thì lùi ngày lại cho đến thứ 2  
            int offset = dayOfWeek - DayOfWeek.Monday;
            return date.AddDays(-offset);
        }

        public static DateTime SartudayOfWeek(this DateTime date)
        {
            return MondayOfWeek(date).AddDays(5);
        }

        public static int CountDays(DayOfWeek day, DateTime start, DateTime end)
        {
            TimeSpan ts = end - start;                       // Total duration
            int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
            int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
            int sinceLastDay = (int)(end.DayOfWeek - day);   // Number of days since last [day]
            if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]

            // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
            if (remainder >= sinceLastDay) count++;

            return count;
        }


        public static void SendEmail(string from, string pass, string to,string month)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(from);
            msg.To.Add(to);
            msg.Body += "<p> <b>Mail này được gửi từ Bộ phận Nhân sự đến bạn. Dữ liệu chấm công trong tháng "+month+" đã được cập nhật lại, Xin vui lòng kiểm tra lại. Thanks </p>";
            msg.IsBodyHtml = true;
            msg.Subject = "CONFIRM EDIT ATTENDENCE";
            SmtpClient smt = new SmtpClient("mail11.digistar.vn");
            smt.Port = 587;
            smt.Credentials = new NetworkCredential(from, pass);
            smt.EnableSsl = true;
            smt.Send(msg);

            MessageBox.Show("Susscess send email to PPIC");
        }

        public static Boolean IsNumeric(String input)
        {
            Double temp;
            Boolean result = Double.TryParse(input, out temp);
            return result;
        }



    }
}
