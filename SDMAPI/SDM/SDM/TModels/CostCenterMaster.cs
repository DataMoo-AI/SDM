using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class CostCenterMaster
    {
        public int CsId { get; set; }
        public string CsCode { get; set; }
        public string CsName { get; set; }
        public string CsLocation { get; set; }
        public string CsCountry { get; set; }
        public string CsOthers1 { get; set; }
        public int? CsCreatedBy { get; set; }
        public DateTime? CsCreatedDate { get; set; }
        public int? CsUpdatedBy { get; set; }
        public DateTime? CsUpdatedDate { get; set; }
        public int? CsDeletedBy { get; set; }
        public DateTime? CsDeletedDate { get; set; }
    }
}
