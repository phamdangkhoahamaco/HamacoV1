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
    
    public partial class MSC_User
    {
        public System.Guid UserID { get; set; }
        public string CompanyCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordEncryption { get; set; }
        public string JobTitle { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsBranchManager { get; set; }
        public Nullable<System.Guid> BranchID { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Fax { get; set; }
        public string WorkAddress { get; set; }
        public string HomeAddress { get; set; }
        public byte[] Photo { get; set; }
        public bool Inactive { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public bool IsSystem { get; set; }
        public int AuthenticationType { get; set; }
    }
}
