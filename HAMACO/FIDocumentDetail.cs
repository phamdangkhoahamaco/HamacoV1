//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HAMACO
{
    using System;
    using System.Collections.Generic;
    
    public partial class FIDocumentDetail
    {
        public System.Guid RefDetailID { get; set; }
        public string CompanyCode { get; set; }
        public string FIDoc { get; set; }
        public string Description { get; set; }
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string AccountingObjectCode { get; set; }
        public string AccountingObjectName { get; set; }
        public string ItemNote { get; set; }
        public Nullable<int> Posted { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string FIHeader { get; set; }
        public string DocType { get; set; }
        public string StockCode { get; set; }
    }
}
