using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class DepartmentMaster
    {
        public int DepId { get; set; }
        public string DepName { get; set; }
        public int? DepCreatedBy { get; set; }
        public DateTime? DepCreatedDate { get; set; }
        public int? DepUpdatedBy { get; set; }
        public DateTime? DepUpdatedDate { get; set; }
        public int? DepDeletedBy { get; set; }
        public DateTime? DepDeletedDate { get; set; }
    }
}
