using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.Common.Response;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeMasterResponse> AddEmployeeMaster(EmployeeMasterRequest employeeMasterRequest);
        public Task<EmployeeMasterResponse> UpdateEmployeeMaster(EmployeeMasterRequest employeeMasterRequest);
        public Task<EmployeeMasterResponse> DeleteEmployeeMaster(EmployeeMasterRequest employeeMasterRequest);
        public EmployeeMasterResponse GenderList();
        public EmployeeMasterResponse GetDepartment();
        public EmployeeMasterResponse GetDesignation();
        public EmployeeMasterResponse GetSalaryPaidMaster();
        public Response GetEmployee(EmployeeMasterRequest employeeMasterRequest);
    }
}
