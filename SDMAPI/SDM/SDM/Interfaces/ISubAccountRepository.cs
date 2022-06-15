using SDM.Common.Response;
using SDM.TModels;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface ISubAccountRepository
    {
        public Task<Response> AddSubAccount(SubAccountMaster subAccountMasterRequest);
        public Task<Response> UpdateSubAccount(SubAccountMaster subAccountMasterRequest);
        public Task<Response> DeleteSubAccount(SubAccountMaster subAccountMasterRequest);
        public Response GetSubAccount(SubAccountMaster subAccountMasterRequest);
    }
}
