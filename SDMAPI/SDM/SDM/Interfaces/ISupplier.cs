using SDM.Common.Response;
using SDM.TModels;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface ISupplier
    {
        public Task<Response> Add(SDM.TModels.SupplierMaster SRequest);
        public Task<Response> Update(SDM.TModels.SupplierMaster SRequest);
        public Task<Response> Delete(SDM.TModels.SupplierMaster SRequest);
        public Response Get(SDM.TModels.SupplierMaster SRequest);
    }
}
