

using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.InsuranceMaster
{
    public class InsuranceRepository : IInsuranceMaster
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public InsuranceRepository(SDMContext context, Response response, ToasterMessages toaster)
        {
            _context = context;
            _response = response;
            _toaster = toaster;
        }
        public async Task<Response> Add(InsuranceReq costCenter)
        {
            var cC = _context.InsuranceMaster.FirstOrDefault(a => a.InsPolicyNo == costCenter.InsPolicyNo && a.InsDeletedBy == null);
            if (cC == null)
            {
                SDM.TModels.InsuranceMaster cC1 = new SDM.TModels.InsuranceMaster();
                cC1.InsCompany = costCenter.InsCompany  ;
                cC1.InsExpDate = costCenter.InsExpDate ;
                cC1.InsOthers1 = costCenter.InsOthers1  ;
                cC1.InsPolicyNo = costCenter.InsPolicyNo  ;
                cC1.InsPremiumAmount = costCenter.InsPremiumAmount  ;
                cC1.InsPurchaseDate = costCenter.InsPurchaseDate ;
                cC1.InsPurchaseAmount = costCenter.InsPurchaseAmount  ;
                cC1.InsVehicleCode = costCenter.InsVehicleCode  ;
                cC1.InsVehicleName = costCenter.InsVehicleName  ;
                cC1.InsCostCenter = costCenter.InsCostCenter ;
                _context.InsuranceMaster.Add(cC1);
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
            }
            return _response;
        }
        public async Task<Response> Update(InsuranceReq costCenter)
        {
            var cC = _context.InsuranceMaster.FirstOrDefault(a => a.InsId == costCenter.InsId && a.InsDeletedBy == null);
            if (cC != null)
            {
                cC.InsCompany = costCenter.InsCompany  ;
                cC.InsExpDate = costCenter.InsExpDate;
                cC.InsOthers1 = costCenter.InsOthers1  ;
                cC.InsPolicyNo = costCenter.InsPolicyNo  ;
                cC.InsPremiumAmount = costCenter.InsPremiumAmount  ;
                cC.InsPurchaseDate = costCenter.InsPurchaseDate  ;
                cC.InsVehicleCode = costCenter.InsVehicleCode  ;
                cC.InsVehicleName = costCenter.InsVehicleName  ;
                cC.InsCostCenter = costCenter.InsCostCenter ;
                cC.InsPurchaseAmount = costCenter.InsPurchaseAmount  ;
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.NotExists;
            }
            return _response;
        }
        public async Task<Response> Delete(SDM.TModels.InsuranceMaster costCenter)
        {
            var cC = _context.InsuranceMaster.FirstOrDefault(a => a.InsId == costCenter.InsId && a.InsDeletedBy == null);
            if (cC != null)
            {
                cC.InsDeletedBy = 1;
                cC.InsDeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.NotExists;
            }
            return _response;
        }
        public async Task<Response> Get(SDM.TModels.InsuranceMaster costCenter)
        {
            var cC = new List<SDM.TModels.InsuranceMaster>();
            if (costCenter.InsId == null || costCenter.InsId == 0)
                cC = _context.InsuranceMaster.Where(a => a.InsDeletedBy == null).ToList();
            else
                cC = _context.InsuranceMaster.Where(a => a.InsDeletedBy == null && a.InsId == costCenter.InsId).ToList();


         
            if (cC != null)
            {
                _response.InsuranceMasterResponse = cC.OrderByDescending(a => a.InsId).ToList();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.NotExists;
            }
            return _response;
        }
    }
}
