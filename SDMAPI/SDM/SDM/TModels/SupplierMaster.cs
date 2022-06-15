using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class SupplierMaster
    {
        public int SupId { get; set; }
        public string SupCode { get; set; }
        public string SupCompanyName { get; set; }
        public string SupAddress { get; set; }
        public string SupContactPerson { get; set; }
        public string SupLandline { get; set; }
        public string SupContactMobile { get; set; }
        public string SupEmail { get; set; }
        public string SupDetails { get; set; }
        public string SupVatNumb { get; set; }
        public string SupOthers1 { get; set; }
        public int? SupCreatedBy { get; set; }
        public DateTime? SupCreatedDate { get; set; }
        public int? SupUpdatedBy { get; set; }
        public DateTime? SupUpdatedDate { get; set; }
        public int? SupDeletedBy { get; set; }
        public DateTime? SupDeletedDate { get; set; }
    }
}
