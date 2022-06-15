using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class SubAccountMaster
    {
        public int PrpId { get; set; }
        public string PrpShortName { get; set; }
        public string PrpName { get; set; }
        public string PrpDetails { get; set; }
        public int? PrpCostCentre { get; set; }
        public string PrpContactPerson { get; set; }
        public string PrpContactPersonNumber { get; set; }
        public string PrpLocation { get; set; }
        public string PrpOthers1 { get; set; }
        public string PrpOthers2 { get; set; }
        public string PrpOthers3 { get; set; }
        public int? PrpCreatedBy { get; set; }
        public DateTime? PrpCreatedDate { get; set; }
        public int? PrpUpdatedBy { get; set; }
        public DateTime? PrpUpdatedDate { get; set; }
        public int? PrpDeletedBy { get; set; }
        public DateTime? PrpDeletedDate { get; set; }
    }
}
