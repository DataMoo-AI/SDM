using System;

namespace SDM.Common.Request
{
    public class ReportRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Flag { get; set; }
    }
}
