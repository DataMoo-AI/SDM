using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class ExpenseCategory
    {
        public int TrnId { get; set; }
        public string TrnCategory { get; set; }
        public int? TrnCreatedBy { get; set; }
        public DateTime? TrnCreatedDate { get; set; }
        public int? TrnUpdatedBy { get; set; }
        public DateTime? TrnUpdatedDate { get; set; }
        public int? TrnDeletedBy { get; set; }
        public DateTime? TrnDeletedDate { get; set; }
    }
}
