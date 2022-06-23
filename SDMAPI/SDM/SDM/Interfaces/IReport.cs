using SDM.Common.Request;
using SDM.Common.Response;
using SDM.TModels;
using System;
using System.Threading.Tasks;
namespace SDM.Interfaces
{
    public interface IReport
    {
        public Task<Response> GetReport(ReportRequest g);
        public Task<Response> Gettransactiontype();
    }
}
