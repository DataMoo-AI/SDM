using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class SalaryPaidMaster
    {
        public int SalId { get; set; }
        public string SalName { get; set; }
        public int? SalCreatedBy { get; set; }
        public DateTime? SalCreatedDate { get; set; }
        public int? SalUpdatedBy { get; set; }
        public DateTime? SalUpdatedDate { get; set; }
        public int? SalDeletedBy { get; set; }
        public DateTime? SalDeletedDate { get; set; }
    }
}
