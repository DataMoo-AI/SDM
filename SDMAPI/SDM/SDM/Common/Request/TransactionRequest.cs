using System;

namespace SDM.Common.Request
{
    public class TransactionRequest
    {
        public int TrnId { get; set; }
        public DateTime? TrnDate { get; set; }
        public int? TrnCreditDebit { get; set; }
        public int? TrnType { get; set; }
        public int? TrnCategory { get; set; }
        public int? TrnSubAccount { get; set; }
        public string TrnSubAccountStr { get; set; }
        public int? TrnCostCentre { get; set; }
        public string TrnDetails { get; set; }
        public string TrnInvNo { get; set; }
        public int? TrnSupplier { get; set; }
        public int? TrnCurrency { get; set; }
        public string TrnAmount { get; set; }
        public string TrnAccountnumber { get; set; }
        public int? TrnInstrumentType { get; set; }
        public string TrnInstrumentNo { get; set; }
        public string TrnRemarks { get; set; }
        public string TrnRequestBy { get; set; }
        public int? TrnBankAccountNo { get; set; }
        public int? TrnCreatedBy { get; set; }
        public int? TrnVehicle { get; set; }
        public int? TrnEmployee { get; set; }
        public DateTime? TrnCreatedDate { get; set; }
        public int? TrnUpdatedBy { get; set; }
        public DateTime? TrnUpdatedDate { get; set; }
        public int? TrnDeletedBy { get; set; }
        public DateTime? TrnDeletedDate { get; set; }
    }
}
