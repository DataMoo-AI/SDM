using SDM.Common.Response;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface IInsuranceMaster
    {
        public Task<Response> Add(InsuranceReq costCenter);
        public Task<Response> Update(InsuranceReq costCenter);
        public Task<Response> Delete(SDM.TModels.InsuranceMaster costCenter);
        public Task<Response> Get(SDM.TModels.InsuranceMaster costCenter);
    }
}
