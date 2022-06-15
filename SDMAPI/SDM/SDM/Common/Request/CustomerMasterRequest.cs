using System;

namespace SDM.Common.Request
{
    public class CustomerMasterRequest
    {
        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustContact { get; set; }
        public string CustPhone { get; set; }
        public string CustContactMobile { get; set; }
        public string CustLandLine { get; set; }
        public string CustTrnOrVatNo { get; set; }
        public string CustFax { get; set; }
        public string CustEmail { get; set; }
        public string CustOthers1 { get; set; }
        public int? CustCreatedBy { get; set; }
        public DateTime? CustCreatedDate { get; set; }
        public int? CustUpdatedBy { get; set; }
        public DateTime? CustUpdatedDate { get; set; }
        public int? CustDeletedBy { get; set; }
        public DateTime? CustDeletedDate { get; set; }
    }
}
