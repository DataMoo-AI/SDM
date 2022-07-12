using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.CostCenter
{
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public CostCenterRepository(SDMContext context, Response response, ToasterMessages toaster)
        {
            _context = context;
            _response = response;
            _toaster = toaster;
        }
        public async Task<Response> AddCostCenter(CostCenterMaster costCenter)
        {
           var cC = _context.CostCenterMaster.FirstOrDefault(a => a.CsName == costCenter.CsName && a.CsDeletedBy == null);
            if(cC == null)
            {
                _context.CostCenterMaster.Add(costCenter);
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
            }
            return _response;
        }
        public async Task<Response> UpdateCostCenter(CostCenterMaster costCenter)
        {
            var cC = _context.CostCenterMaster.FirstOrDefault(a => a.CsId == costCenter.CsId && a.CsDeletedBy == null);
            if (cC != null)
            {
                cC.CsOthers1 = costCenter.CsOthers1 ?? "";
                cC.CsCode = costCenter.CsCode ?? "";
                cC.CsLocation = costCenter.CsLocation ?? "";
                cC.CsCountry = costCenter.CsCountry ?? "";
                cC.CsName = costCenter.CsName ?? "";
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.NotExists;
            }
            return _response;
        }
        public async Task<Response> DeleteCostCenter(CostCenterMaster costCenter)
        {
            var cC = _context.CostCenterMaster.FirstOrDefault(a => a.CsId == costCenter.CsId && a.CsDeletedBy == null);
            if (cC != null)
            {
                cC.CsDeletedBy = 1;
                cC.CsDeletedDate = DateTime.Now;           
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.NotExists;
            }
            return _response;
        }
        public async Task<Response> GetCostCenter(CostCenterMaster costCenter)
        {
            var cC = new List<CostCenterMaster>();
            if(costCenter.CsId == null || costCenter.CsId == 0)
                cC  = _context.CostCenterMaster.Where(a => a.CsDeletedBy == null).ToList();
            else
                cC = _context.CostCenterMaster.Where(a => a.CsDeletedBy == null && a.CsId == costCenter.CsId).ToList();
            if (cC != null)
            {
                _response.CostCenterResponse = cC;
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.NotExists;
            }
            return _response;
        }
        public async Task<Response> AddExpense(ExpenseCategory costCenter)
        {
            var cC = _context.ExpenseCategory.FirstOrDefault(a => a.TrnCategory == costCenter.TrnCategory && a.TrnDeletedBy == null);
            if (cC == null)
            {
                _context.ExpenseCategory.Add(costCenter);
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
            }
            return _response;
        }
        public async Task<Response> UpdateExpense(ExpenseCategory costCenter)
        {
            var cC = _context.ExpenseCategory.FirstOrDefault(a => a.TrnId == costCenter.TrnId && a.TrnDeletedBy == null);
            if (cC != null)
            {
                cC.TrnCategory = costCenter.TrnCategory;
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
            }
            return _response;
        }
        public async Task<Response> DeleteExpense(ExpenseCategory costCenter)
        {
            var cC = _context.ExpenseCategory.FirstOrDefault(a => a.TrnId == costCenter.TrnId && a.TrnDeletedBy == null);
            if (cC != null)
            {
                cC.TrnDeletedBy = 1;
                cC.TrnDeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
            }
            return _response;
        }
        public async Task<Response> GetExpense(ExpenseCategory costCenter)
        {
            var cC = new List<ExpenseCategory>();
            if (costCenter.TrnId == 0)
                cC = _context.ExpenseCategory.Where(a => a.TrnDeletedBy == null).ToList();
            else
                cC = _context.ExpenseCategory.Where(a => a.TrnId == costCenter.TrnId && a.TrnDeletedBy == null).ToList();
            if (cC != null)
            {
                _response.ExpenseCategoryResponse = cC;
                _response.Message = _toaster.Success;
            }
            else
            {
                _response.Message = _toaster.AlreadyExists;
            }
            return _response;
        }
    }
}
