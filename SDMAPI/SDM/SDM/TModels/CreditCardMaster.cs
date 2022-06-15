using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class CreditCardMaster
    {
        public int CcId { get; set; }
        public string CcBnkCode { get; set; }
        public string CcBnkName { get; set; }
        public string CcNumber { get; set; }
        public string CcOwnerName { get; set; }
        public DateTime? CcExpDt { get; set; }
        public int? CcCreatedBy { get; set; }
        public DateTime? CcCreatedDate { get; set; }
        public int? CcUpdatedBy { get; set; }
        public DateTime? CcUpdatedDate { get; set; }
        public int? CcDeletedBy { get; set; }
        public DateTime? CcDeletedDate { get; set; }
    }
}
