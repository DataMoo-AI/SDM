using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class BankMasterEntry
    {
        public int BnkId { get; set; }
        public string BnkCode { get; set; }
        public string BnkName { get; set; }
        public string BnkAccNo { get; set; }
        public string BnkIbanNumb { get; set; }
        public string BnkSwiftCode { get; set; }
        public string BnkAccName { get; set; }
        public string BnkAddress { get; set; }
        public int? BnkAccountCcy { get; set; }
        public string BnkOthers1 { get; set; }
        public string RmName { get; set; }
        public string RmContact { get; set; }
        public string RmEmail { get; set; }
        public string Rm1Name { get; set; }
        public string Rm1Contact { get; set; }
        public string Rm1Email { get; set; }
        public string Rm2Name { get; set; }
        public string Rm2Contact { get; set; }
        public string Rm2Email { get; set; }
        public int? BnkCreatedBy { get; set; }
        public DateTime? BnkCreatedDate { get; set; }
        public int? BnkUpdatedBy { get; set; }
        public DateTime? BnkUpdatedDate { get; set; }
        public int? BnkDeletedBy { get; set; }
        public DateTime? BnkDeletedDate { get; set; }
        public string BnkCreditOrDebit { get; set; }
        public string BnkCreditOrDebit2 { get; set; }
        public string BnkCreditOrDebit3 { get; set; }
        public string BnkCreditOrDebit4 { get; set; }
        public string BnkCreditOrDebit5 { get; set; }
    }
}
