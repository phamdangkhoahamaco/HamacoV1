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
    
    public partial class Account
    {
        public System.Guid AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
        public int Grade { get; set; }
        public bool IsParent { get; set; }
        public string AccountCategoryID { get; set; }
        public Nullable<int> AccountCategoryKind { get; set; }
        public bool DetailByAccountingObject { get; set; }
        public bool DetailByInventoryItem { get; set; }
        public bool DetailByJob { get; set; }
        public bool DetailByContract { get; set; }
        public bool Inactive { get; set; }
        public bool DetailByForeignCurrency { get; set; }
        public Nullable<int> AccountingObjectType { get; set; }
        public Nullable<bool> DetailByBankAccount { get; set; }
        public string AccountNameEnglish { get; set; }
        public Nullable<bool> Exits { get; set; }
        public Nullable<int> GroupCost { get; set; }
    }
}
