using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class DesignationMaster
    {
        public int DesId { get; set; }
        public string DesName { get; set; }
        public int? DesCreatedBy { get; set; }
        public DateTime? DesCreatedDate { get; set; }
        public int? DesUpdatedBy { get; set; }
        public DateTime? DesUpdatedDate { get; set; }
        public int? DesDeletedBy { get; set; }
        public DateTime? DesDeletedDate { get; set; }
    }
}
