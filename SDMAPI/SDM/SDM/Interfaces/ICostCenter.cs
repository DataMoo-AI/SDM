using SDM.Common.Response;
using SDM.TModels;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface ICostCenterRepository
    {
        public Task<Response> AddCostCenter(CostCenterMaster costCenter);
        public Task<Response> UpdateCostCenter(CostCenterMaster costCenter);
        public Task<Response> DeleteCostCenter(CostCenterMaster costCenter);
        public Task<Response> GetCostCenter(CostCenterMaster costCenter);
        public Task<Response> AddExpense(ExpenseCategory costCenter);
        public Task<Response> UpdateExpense(ExpenseCategory costCenter);
        public Task<Response> DeleteExpense(ExpenseCategory costCenter);
        public Task<Response> GetExpense(ExpenseCategory costCenter);
    }
}
