using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
namespace HAMACO
{
    class ClassApiEinvoice
    {
        //cài cái này Tool - Nuget - Console
        //Install-Package RestSharp -Version 106.11.5
        public static string url_create_invoice = "https://api-einvoice.xplat.fpt.com.vn/create-invoice";
        public static string url_updatete_invoice = "https://api-einvoice.xplat.fpt.com.vn/update-invoice";
        public static string url_approve_invoice = "https://api-einvoice.xplat.fpt.com.vn/appr-invoice";
        public static string url_search_invoice = "https://api-einvoice.xplat.fpt.com.vn/search-invoice";
        public static string url_signin_invoice = "https://api-einvoice.xplat.fpt.com.vn/c_signin";

        public static string APIusername = "hamaco";
        public static string APIpassword = "admin@123";
        public static string APItax = "1800506679";


        public class user
        {
            public string username = APItax + "." + APIusername;
            public string password = APIpassword;
        }
        public class inv
        {
            //tạo hóa đơn
            public string sid { get; set; }
            public string idt { get; set; }
            public string type { get; set; }
            public string form { get; set; }
            public string serial { get; set; }
            public string seq { get; set; }
            public string bname { get; set; }
            public string buyer { get; set; }
            public string btax { get; set; }
            public string baddr { get; set; }
            public string btel { get; set; }
            public string bmail { get; set; }
            public string paym { get; set; }
            public string curr { get; set; }
            public double exrt { get; set; }
            public string bacc { get; set; }
            public string bbank { get; set; }
            public double vat { get; set; }
            public string note { get; set; }
            public double sumv { get; set; }
            public double sum { get; set; }
            public double vatv { get; set; }
            public string word { get; set; }
            public double totalv { get; set; }
            public double total { get; set; }
            public double discount { get; set; }
            public double aun { get; set; }
            public List<items> items = new List<items>();

            public string stax = APItax;
        }

        public class items
        {
            public double line { get; set; }
            public string type { get; set; }
            public string vrt { get; set; }
            public string name { get; set; }
            public string unit { get; set; }
            public double price { get; set; }
            public double quantity { get; set; }
            public double amount { get; set; }
        }
        public class create_invoice
        {
            public user user;
            public inv inv;
        }
          

        public static string EInvoiceSignin()
        {

            user u = new user();
            string data = JsonConvert.SerializeObject(u);

            // data có thể dùng object để format sang JSON 
            var client = new RestClient(url_signin_invoice);  // URL là request url tham khảo mục 3.5.3 
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("data", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string resultContent = response.Content;
            return resultContent;

        }

        public static IRestResponse EInvoiceCreate(string data)
        {
            // data có thể dùng object để format sang JSON 
            var client = new RestClient(url_create_invoice);  // URL là request url  (tham khảo mục 1.2)
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("data", data, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response;


        }

    }


}
