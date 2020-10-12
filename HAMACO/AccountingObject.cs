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
    
    public partial class AccountingObject
    {
        public System.Guid AccountingObjectID { get; set; }
        public string AccountingObjectCode { get; set; }
        public string AccountingObjectName { get; set; }
        public string AccountingObjectCategory { get; set; }
        public Nullable<System.Guid> BranchID { get; set; }
        public Nullable<System.DateTime> EmployeeBirthday { get; set; }
        public string Prefix { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string EmailAddress { get; set; }
        public string Website { get; set; }
        public string BankAccount { get; set; }
        public string BankName { get; set; }
        public string CompanyTaxCode { get; set; }
        public string Description { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public Nullable<int> ContactSex { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string ContactOfficeTel { get; set; }
        public string ContactHomeTel { get; set; }
        public string ContactAddress { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsPersonal { get; set; }
        public string IdentificationNumber { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public string IssueBy { get; set; }
        public Nullable<System.Guid> DepartmentID { get; set; }
        public Nullable<System.Guid> SaleCustomerGroupID { get; set; }
        public Nullable<bool> Insured { get; set; }
        public Nullable<bool> LabourUnionFee { get; set; }
        public Nullable<decimal> FamilyDeductionAmount { get; set; }
        public Nullable<bool> Inactive { get; set; }
        public Nullable<decimal> MaximizeDebtAmount { get; set; }
        public Nullable<int> DueTime { get; set; }
        public Nullable<decimal> SalaryScaleID { get; set; }
        public Nullable<bool> IsVendor { get; set; }
        public Nullable<bool> IsCustomer { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public Nullable<System.Guid> AccountingObjectGroupID { get; set; }
        public Nullable<System.Guid> PaymentTermID { get; set; }
        public string CompanyCode { get; set; }
    
        public virtual AccountingObject AccountingObject1 { get; set; }
        public virtual AccountingObject AccountingObject2 { get; set; }
    }
}
