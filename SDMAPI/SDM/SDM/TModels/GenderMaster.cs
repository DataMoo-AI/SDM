using System;
using System.Collections.Generic;

namespace SDM.TModels
{
    public partial class GenderMaster
    {
        public int GenId { get; set; }
        public string GenGender { get; set; }
        public int? GenCreatedBy { get; set; }
        public DateTime? GenCreatedDate { get; set; }
        public int? GenUpdatedBy { get; set; }
        public DateTime? GenUpdatedDate { get; set; }
        public int? GenDeletedBy { get; set; }
        public DateTime? GenDeletedDate { get; set; }
    }
}
