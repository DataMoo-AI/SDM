using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class InsuranceMaster
    {
        public int InsId { get; set; }
        public int? InsCostCenter { get; set; }
        public string InsVehicleCode { get; set; }
        public string InsVehicleName { get; set; }
        public string InsPolicyNo { get; set; }
        public DateTime? InsPurchaseDate { get; set; }
        public string InsPurchaseAmount { get; set; }
        public string InsCompany { get; set; }
        public DateTime? InsExpDate { get; set; }
        public string InsPremiumAmount { get; set; }
        public string InsOthers1 { get; set; }
        public int? InsCreatedBy { get; set; }
        public DateTime? InsCreatedDate { get; set; }
        public int? InsUpdatedBy { get; set; }
        public DateTime? InsUpdatedDate { get; set; }
        public int? InsDeletedBy { get; set; }
        public DateTime? InsDeletedDate { get; set; }
    }
}
