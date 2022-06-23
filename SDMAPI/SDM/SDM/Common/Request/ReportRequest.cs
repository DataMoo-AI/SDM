using System;

namespace SDM.Common.Request
{
    public class ReportRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Currency { get; set; }
        public string? Type { get; set; }
        public string? Flag { get; set; }
    }
}
