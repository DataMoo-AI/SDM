using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SDM.Repository.Vehicle
{
    public class VehicleRepository : IVehicle
    {

        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public VehicleRepository(SDMContext context, ToasterMessages toaster, Response response)
        {
            _context = context;
            _toaster = toaster;
            _response = response;
        }
        public async Task<Response> Add(VehicleMaster vehicleRequest)
        {

            var _values = _context.VehicleMaster.FirstOrDefault(a => a.VhCode == vehicleRequest.VhCode && a.VhDeletedBy == null);
            if (_values == null)
            {
                _context.VehicleMaster.Add(vehicleRequest);
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
                return _response;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
                return _response;
            }
        }
        public async Task<Response> Update(VehicleMaster vehicleRequest)
        {
            var _values = _context.VehicleMaster.FirstOrDefault(a => a.VhId == vehicleRequest.VhId && a.VhDeletedBy == null);
            if (_values != null)
            {
                _values.VhId =  vehicleRequest.VhId;
                _values.VhCode = vehicleRequest.VhCode;
                _values.VhType = vehicleRequest.VhType;
                _values.VhVehicleOn = vehicleRequest.VhVehicleOn;
                _values.VhName = vehicleRequest.VhName;
                _values.VhMakeBrand = vehicleRequest.VhMakeBrand;
                _values.VhModelYear = vehicleRequest.VhModelYear;
                _values.VhPurchaseDt = vehicleRequest.VhPurchaseDt;
                _values.VhRegNo = vehicleRequest.VhRegNo;
                _values.VhRegistrationExp = vehicleRequest.VhRegistrationExp;
                _values.VhTypeOfPurchase = vehicleRequest.VhTypeOfPurchase;
                _values.VhSizeCapacity = vehicleRequest.VhSizeCapacity;
                _values.VhDrivenBy = vehicleRequest.VhDrivenBy;
                _values.VhCostCentre = vehicleRequest.VhCostCentre;
                _values.VhLocation = vehicleRequest.VhLocation;
                _values.VhPurchasedColor = vehicleRequest.VhPurchasedColor;
                _values.VhPurchaseValue = vehicleRequest.VhPurchaseValue;
                _values.VhPurchasedFrom = vehicleRequest.VhPurchasedFrom;
                _values.VhColour = vehicleRequest.VhColour;
                _values.VhEngineMake = vehicleRequest.VhEngineMake;
                _values.VhEnginePower = vehicleRequest.VhEnginePower;
                _values.VhNoOfEngines = vehicleRequest.VhNoOfEngines;
                _values.VhEngineSerialNumber = vehicleRequest.VhEngineSerialNumber; 
                _values.VhTypeOfHull = vehicleRequest.VhTypeOfHull;
                _values.VhHullChassisNo = vehicleRequest.VhHullChassisNo;
                _values.VhWeight = vehicleRequest.VhWeight;
                _values.VhOriginPlace = vehicleRequest.VhOriginPlace;
                _values.VhNoOfPassengers = vehicleRequest.VhNoOfPassengers;
                _values.VhNoOfCrew = vehicleRequest.VhNoOfCrew;
                _values.VhRadioDeviceName = vehicleRequest.VhRadioDeviceName;
                _values.VhRadioDeviceType = vehicleRequest.VhRadioDeviceType;
                _values.VhRadioDeviceSno = vehicleRequest.VhRadioDeviceSno;
                _values.VhImage = vehicleRequest.VhImage;
                _values.VhStatus = vehicleRequest.VhStatus;
                _values.VhOthers1 = vehicleRequest.VhOthers1;
                _values.VhOthers2 = vehicleRequest.VhOthers2;
                _values.VhOthers3 = vehicleRequest.VhOthers3;
                _values.VhOthers4 = vehicleRequest.VhOthers4;
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
                return _response;
            }
            else
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
        }
        public async Task<Response> Delete(VehicleMaster vehicleRequest)
        {
            var _values = _context.VehicleMaster.FirstOrDefault(a => a.VhId == vehicleRequest.VhId && a.VhDeletedBy == null);
            if (_values != null)
            {
                _values.VhDeletedBy = 1;
                _values.VhDeletedDate = System.DateTime.Now;
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
                return _response;
            }
            else
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
        }
        public Response Get(VehicleMaster vehicleRequest)
        {
            var _values = new List<VehicleMaster>();
            if(vehicleRequest.VhId != 0)
                _values = _context.VehicleMaster.Where(a => a.VhId == vehicleRequest.VhId && a.VhDeletedBy == null).ToList();
            else
                _values = _context.VehicleMaster.Where(a =>  a.VhDeletedBy == null).ToList();
            if (_values != null)
            {
                var _val = (from V in _values
                            orderby -V.VhId
                            select new VhResponse
                            {
                                VhId = V.VhId,
                                VhCode = V.VhCode,
                                VhType = V.VhType,
                                VhVehicleOn = V.VhVehicleOn,
                                VhCostCentreName = _context.CostCenterMaster.FirstOrDefault(a => a.CsDeletedBy == null && a.CsId == V.VhCostCentre).CsName ?? "",
                                VhName = V.VhName,
                                VhMakeBrand = V.VhMakeBrand,
                                VhModelYear = V.VhModelYear,
                                VhPurchaseDt = V.VhPurchaseDt,
                                VhRegNo = V.VhRegNo,
                                VhRegistrationExp = V.VhRegistrationExp,
                                VhTypeOfPurchase = V.VhTypeOfPurchase,
                                VhSizeCapacity = V.VhSizeCapacity,
                                VhDrivenBy = V.VhDrivenBy,
                                VhCostCentre = V.VhCostCentre,
                                VhLocation = V.VhLocation,
                                VhPurchaseValue = V.VhPurchaseValue,
                                VhPurchasedFrom = V.VhPurchasedFrom,
                                VhPurchasedColor = V.VhPurchasedColor,
                                VhColour = V.VhColour,
                                VhEnginePower = V.VhEnginePower,
                                VhNoOfEngines = V.VhNoOfEngines,
                                VhEngineSerialNumber = V.VhEngineSerialNumber,
                                VhEngineMake = V.VhEngineMake,
                                VhTypeOfHull = V.VhTypeOfHull,
                                VhHullChassisNo = V.VhHullChassisNo,
                                VhWeight = V.VhWeight,
                                VhOriginPlace = V.VhOriginPlace,
                                VhNoOfPassengers = V.VhNoOfPassengers,
                                VhNoOfCrew = V.VhNoOfCrew,
                                VhRadioDeviceName = V.VhRadioDeviceName,
                                VhRadioDeviceType = V.VhRadioDeviceType,
                                VhRadioDeviceSno = V.VhRadioDeviceSno,
                                VhImage = V.VhImage,
                                VhStatus = V.VhStatus,
                                VhOthers1 = V.VhOthers1,
                                VhOthers2 = V.VhOthers2,
                                VhOthers3 = V.VhOthers3,
                                VhOthers4 = V.VhOthers4,
                            }).ToList();
                _response.VechileResponse = _val;
                _response.Message = _toaster.Success;
                _response.CustomerMasterResponse = _context.CustomerMaster.Where(a => a.CustDeletedBy == null).ToList();

                return _response;
            }
            else
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
        }
    }
}
