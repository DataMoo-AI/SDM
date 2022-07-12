using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.SubAccount
{
    public class SubAccountRepository : ISubAccountRepository
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public SubAccountRepository(SDMContext context,ToasterMessages toaster, Response response)
        {
            _context = context;
            _toaster = toaster;
            _response = response;
        }
        public async Task<Response> AddSubAccount(SubAccountMaster subAccountMasterRequest) 
        {
            var subAcc = _context.SubAccountMaster.FirstOrDefault(a => a.PrpName == subAccountMasterRequest.PrpName && a.PrpDeletedBy == null);
            if(subAcc == null)
            {
                _context.SubAccountMaster.Add(subAccountMasterRequest);
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
        public async Task<Response> UpdateSubAccount(SubAccountMaster subAccountMasterRequest) {
            var subAcc = _context.SubAccountMaster.FirstOrDefault(a => a.PrpId == subAccountMasterRequest.PrpId && a.PrpDeletedBy == null);
            if (subAcc != null)
            {
                subAcc.PrpCostCentre = subAccountMasterRequest.PrpCostCentre ;
                subAcc.PrpContactPerson = subAccountMasterRequest.PrpContactPerson ?? "" ;
                subAcc.PrpContactPersonNumber = subAccountMasterRequest.PrpContactPersonNumber ?? "" ;
                subAcc.PrpOthers1 = subAccountMasterRequest.PrpOthers1 ?? "" ;
                subAcc.PrpOthers2 = subAccountMasterRequest.PrpOthers2 ?? "" ;
                subAcc.PrpOthers3 = subAccountMasterRequest.PrpOthers3 ?? "" ;
                subAcc.PrpDetails = subAccountMasterRequest.PrpDetails ?? "" ;
                subAcc.PrpCostCentre = subAccountMasterRequest.PrpCostCentre ;
                subAcc.PrpLocation = subAccountMasterRequest.PrpLocation ?? "" ;
                subAcc.PrpName = subAccountMasterRequest.PrpName ?? "" ;
                subAcc.PrpShortName = subAccountMasterRequest.PrpShortName ?? "" ;
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
        public async Task<Response> DeleteSubAccount(SubAccountMaster subAccountMasterRequest) {
            var subAcc = _context.SubAccountMaster.FirstOrDefault(a => a.PrpId == subAccountMasterRequest.PrpId && a.PrpDeletedBy == null);
            if (subAcc != null)
            {
                subAcc.PrpDeletedBy = 1;
                subAcc.PrpDeletedDate = System.DateTime.Now;
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
        public Response GetSubAccount(SubAccountMaster subAccountMasterRequest) {
            var subAcc = new List<SubAccountMaster>();    
            if (subAccountMasterRequest.PrpId != 0)
              subAcc = _context.SubAccountMaster.Where(a => a.PrpId == subAccountMasterRequest.PrpId && a.PrpDeletedBy == null).ToList();
            else
                subAcc = _context.SubAccountMaster.Where(a => a.PrpDeletedBy == null).ToList();
            if (subAcc != null)
            {
                var SA = (from a in subAcc
                          orderby -a.PrpId
                          select new SAResponse
                          {
                              PrpId = a.PrpId,
                              PrpCostCentre = a.PrpCostCentre,
                              PrpContactPerson = a.PrpContactPerson,
                              PrpContactPersonNumber = a.PrpContactPersonNumber,
                                PrpOthers1 = a.PrpOthers1,
                                PrpOthers2 = a.PrpOthers2,
                                PrpOthers3 = a.PrpOthers3,
                                PrpDetails = a.PrpDetails,
                                //PrpCostCentreName = (_context.CostCenterMaster.FirstOrDefault(v => v.CsId == a.PrpCostCentre && v.CsDeletedBy == null).CsName ?? ""),
                                PrpLocation = a.PrpLocation,
                                PrpName = a.PrpName,
                              PrpShrtName = a.PrpShortName,
                          }).ToList();
                if (SA.Any())
                {
                    foreach(var rr in SA)
                    {
                        var ff = _context.CostCenterMaster.FirstOrDefault(v => v.CsId == rr.PrpCostCentre && v.CsDeletedBy == null);
                        if(ff != null)
                        {
                            rr.PrpCostCentreName = ff.CsName;
                        }
                        else
                        {
                            rr.PrpCostCentreName = "";
                        }
                    }
                }
                _response.SubAccountResponse = SA;
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
