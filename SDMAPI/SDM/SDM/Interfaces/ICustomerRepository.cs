using SDM.Common.Request;
using SDM.Common.Response;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Response> AddCustomerMaster(CustomerMasterRequest customerMasterRequest);
        public Task<Response> UpdateCustomerMaster(CustomerMasterRequest customerMasterRequest);
        public Task<Response> DeleteCustomereMaster(CustomerMasterRequest customerMasterRequest);
        public Task<Response> GetCustomereMaster(CustomerMasterRequest customerMasterRequest);
    }
}
