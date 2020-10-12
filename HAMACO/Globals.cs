using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAMACO
{
    public static class Globals
    {
        public static int clientid = 300; 
        public static String userid = ""; // Modifiable
        public static String username = ""; // Modifiable        
        public static String companycode = ""; // Modifiable
        public static String companyname = ""; // Modifiable
        public static String version = "2.1"; // Modifiable
        public static String transactioncode = ""; // Modifiable
        public static String ngaychungtu = "";
        public static String roleid = "";
        public static String branchid = "";
        //public static Datatable branchid = "";
        public static DataTable khach = new DataTable();
        public static DataTable hang = new DataTable();
        //public static string constring = @"server=192.168.0.12;Database=hamaco;UID=sa;PWD=HAMsql2008;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";
        //public static string constring = @"server=SQL2016A.HAMACO.VN,65102;Database=PhamDangKhoa;UID=sa;PWD=Khoa123456;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";
        public static string constring = @"server=SQL2016A.HAMACO.VN,65102;Database=HamacoV3;UID=PhamDangKhoa;PWD=Khoa123456;Max Pool Size=300;Min Pool Size=5;Connection Timeout=60";
        //HamacoV2;UID=PhamDangKhoa;PWD=Khoa123456;Max Pool Size=300;Min Pool Size=5;Connection Timeout = 60";
        //just for testing


    }
}
