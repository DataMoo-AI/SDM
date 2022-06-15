using SDM.Common.Response;
using SDM.TModels;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface IBankMaster
    {
        public Task<Response> Add(BankMasterEntry SRequest);
        public Task<Response> Update(BankMasterEntry SRequest);
        public Task<Response> Delete(BankMasterEntry SRequest);
        public Response Get(BankMasterEntry SRequest);
    }
}
