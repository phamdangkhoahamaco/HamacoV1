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
    
    public partial class Branch
    {
        public System.Guid BranchID { get; set; }
        public string CompanyCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public bool IsDependent { get; set; }
        public bool Inactive { get; set; }
        public Nullable<bool> IsSystem { get; set; }
        public Nullable<bool> IsParent { get; set; }
        public Nullable<System.Guid> Parent { get; set; }
        public Nullable<int> Grade { get; set; }
        public Nullable<System.Guid> StockBranch { get; set; }
        public string Province { get; set; }
        public string Code { get; set; }
        public string TDV { get; set; }
        public string TK { get; set; }
    }
}