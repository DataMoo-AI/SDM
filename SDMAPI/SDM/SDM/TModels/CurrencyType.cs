using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class CurrencyType
    {
        public int CtId { get; set; }
        public string CtName { get; set; }
        public int? CtCreatedBy { get; set; }
        public DateTime? CtCreatedDate { get; set; }
        public int? CtUpdatedBy { get; set; }
        public DateTime? CtUpdatedDate { get; set; }
        public int? CtDeletedBy { get; set; }
        public DateTime? CtDeletedDate { get; set; }
    }
}
