using SDM.Common.Response;
using SDM.TModels;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface IVehicle
    {
        public Task<Response> Add(VehicleMaster vehicleRequest);
        public Task<Response> Update(VehicleMaster vehicleRequest);
        public Task<Response> Delete(VehicleMaster vehicleRequest);
        public Response Get(VehicleMaster vehicleRequest);
    }
}
