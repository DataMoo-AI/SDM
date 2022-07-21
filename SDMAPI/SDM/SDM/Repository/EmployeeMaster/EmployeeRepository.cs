using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SDMContext _context;
        private readonly EmployeeMasterResponse _response;
        private readonly Response _employeeResponse;
        private readonly ToasterMessages _toaster;
        public EmployeeRepository(SDMContext context, EmployeeMasterResponse response, ToasterMessages toaster, Response employeeResponse)
        {
            _context = context;
            _response = response;
            _toaster = toaster;
            _employeeResponse = employeeResponse;
        }
        public async Task<EmployeeMasterResponse> AddEmployeeMaster(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var employeeMaster = _context.EmployeeMaster.FirstOrDefault(a => a.EmpCode == employeeMasterRequest.EmpCode && a.EmpDeletedBy == null);
                if (employeeMaster == null)
                {
                    EmployeeMaster employee = SetEmployeeValues(employeeMasterRequest);
                     employee.EmpPpNo = employeeMasterRequest.EmpPpNo  ;
                    employee.EmpPpExpirationDate = employeeMasterRequest.EmpPpExpirationDate ;
                    employee.EmpPpIssuedDate = employeeMasterRequest.EmpPpIssuedDate ;
                    employee.EmpCode = employeeMasterRequest.EmpCode  ;
                    employee.EmpProbationPeriod = employeeMasterRequest.EmpProbationPeriod  ;
                    employee.EmpAirTicket = employeeMasterRequest.EmpAirTicket  ;
                    employee.EmpAssetsGiven = employeeMasterRequest.EmpAssetsGiven  ;
                    employee.EmpLoansGiven = employeeMasterRequest.EmpLoansGiven  ;
                    employee.EmpOthers1 = employeeMasterRequest.EmpOthers1  ;
                    employee.EmpVisaExpDt = employeeMasterRequest.EmpVisaExpDt  ;
                    employee.EmpCostCenter = employeeMasterRequest.EmpCostCenter ;
                    employee.EmpVisaNo = employeeMasterRequest.EmpVisaNo  ;
                    employee.EmpVisaIssuedFrom = employeeMasterRequest.EmpVisaIssuedFrom  ;
                    employee.EmpGenderId = employeeMasterRequest.EmpGenderId ;
                    employee.EmpEmailId = employeeMasterRequest.EmpEmailId  ;
                    employee.EmpPassPortBackImage = employeeMasterRequest.EmpPassPortBackImage  ;
                    employee.EmpPassPortFrontImage = employeeMasterRequest.EmpPassPortFrontImage  ;
                    employee.EmpVisaFrontImage = employeeMasterRequest.EmpVisaFrontImage;
                    employee.EmpVisaBackImage = employeeMasterRequest.EmpVisaBackImage;

                    employee.EmpPhoto = employeeMasterRequest.EmpPhoto  ;
                    employee.EmpHousingDetails = employeeMasterRequest.EmpHousingDetails  ;
                    employee.EmpId = employeeMasterRequest.EmpId ;
                    employee.EmpJobLocation = employeeMasterRequest.EmpJobLocation  ;
                    employee.EmpDob = employeeMasterRequest.EmpDob ;
                    employee.EmpDepartment = employeeMasterRequest.EmpDepartment  ;
                    employee.EmpDesignation = employeeMasterRequest.EmpDesignation  ;
                    employee.EmpEmploymentEndDate = employeeMasterRequest.EmpEmploymentEndDate  ;
                    employee.EmpEmploymentStatus = employeeMasterRequest.EmpEmploymentStatus  ;
                    employee.EmpJoiningDate = employeeMasterRequest.EmpJoiningDate ;
                    employee.EmpLeaveBalance = employeeMasterRequest.EmpLeaveBalance  ;
                    employee.EmpNationality = employeeMasterRequest.EmpNationality  ;
                    employee.EmpMonthlySalary = employeeMasterRequest.EmpMonthlySalary  ;
                    employee.EmpPpImageAttachment = employeeMasterRequest.EmpPpImageAttachment  ;
                    employee.EmpPrevVacationDetails = employeeMasterRequest.EmpPrevVacationDetails  ;
                    employee.EmpEidExpDt= employeeMasterRequest.EmpEidExpDt  ;
                    employee.EmpEmployer = employeeMasterRequest.EmpEmployer  ;
                    employee.EmpEidImageAttachment = employeeMasterRequest.EmpEidImageAttachment  ;
                    employee.EmpEidNo= employeeMasterRequest.EmpEidNo  ;
                    employee.EmpMobileNumber = employeeMasterRequest.EmpMobileNumber  ;
                    employee.EmpName = employeeMasterRequest.EmpName  ;
                    employee.EmpSalaryPaid = employeeMasterRequest.EmpSalaryPaid  ;
                    employee.EmpType = employeeMasterRequest.EmpType  ;
                    employee.EmpVisaImageAttachment = employeeMasterRequest.EmpVisaImageAttachment  ;
                    _context.EmployeeMaster.Add(employee);
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
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public async Task<EmployeeMasterResponse> UpdateEmployeeMaster(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var employee = _context.EmployeeMaster.FirstOrDefault(a => a.EmpId == employeeMasterRequest.EmpId);
                if (employee != null)
                {
                    employee.EmpPpNo = employeeMasterRequest.EmpPpNo  ;
                    employee.EmpPpExpirationDate = employeeMasterRequest.EmpPpExpirationDate ;
                    employee.EmpPpIssuedDate = employeeMasterRequest.EmpPpIssuedDate  ;
                    employee.EmpCode = employeeMasterRequest.EmpCode  ;
                    employee.EmpProbationPeriod = employeeMasterRequest.EmpProbationPeriod  ;
                    employee.EmpAirTicket = employeeMasterRequest.EmpAirTicket  ;
                    employee.EmpAssetsGiven = employeeMasterRequest.EmpAssetsGiven  ;
                    employee.EmpLoansGiven = employeeMasterRequest.EmpLoansGiven  ;
                    employee.EmpOthers1 = employeeMasterRequest.EmpOthers1  ;
                    employee.EmpVisaExpDt = employeeMasterRequest.EmpVisaExpDt  ;
                    employee.EmpCostCenter = employeeMasterRequest.EmpCostCenter ;
                    employee.EmpVisaNo = employeeMasterRequest.EmpVisaNo  ;
                    employee.EmpVisaIssuedFrom = employeeMasterRequest.EmpVisaIssuedFrom  ;
                    employee.EmpGenderId = employeeMasterRequest.EmpGenderId ;
                    employee.EmpEmailId = employeeMasterRequest.EmpEmailId  ;
                    employee.EmpPhoto = employeeMasterRequest.EmpPhoto  ;

                    employee.EmpPassPortBackImage = employeeMasterRequest.EmpPassPortBackImage;
                    employee.EmpPassPortFrontImage = employeeMasterRequest.EmpPassPortFrontImage;
                    employee.EmpVisaFrontImage = employeeMasterRequest.EmpVisaFrontImage;
                    employee.EmpVisaBackImage = employeeMasterRequest.EmpVisaBackImage;

                    employee.EmpHousingDetails = employeeMasterRequest.EmpHousingDetails  ;
                    employee.EmpId = employeeMasterRequest.EmpId  ;
                    employee.EmpJobLocation = employeeMasterRequest.EmpJobLocation  ;
                    employee.EmpDob = employeeMasterRequest.EmpDob ;
                    employee.EmpDepartment = employeeMasterRequest.EmpDepartment  ;
                    employee.EmpDesignation = employeeMasterRequest.EmpDesignation  ;
                    employee.EmpEmploymentEndDate = employeeMasterRequest.EmpEmploymentEndDate ;
                    employee.EmpEmploymentStatus = employeeMasterRequest.EmpEmploymentStatus  ;
                    employee.EmpJoiningDate = employeeMasterRequest.EmpJoiningDate ;
                    employee.EmpLeaveBalance = employeeMasterRequest.EmpLeaveBalance  ;
                    employee.EmpNationality = employeeMasterRequest.EmpNationality  ;
                    employee.EmpMonthlySalary = employeeMasterRequest.EmpMonthlySalary  ;
                    employee.EmpPpImageAttachment = employeeMasterRequest.EmpPpImageAttachment  ;
                    employee.EmpPrevVacationDetails = employeeMasterRequest.EmpPrevVacationDetails  ;
                    employee.EmpEidExpDt= employeeMasterRequest.EmpEidExpDt  ;
                    employee.EmpEmployer = employeeMasterRequest.EmpEmployer  ;
                    employee.EmpEidImageAttachment = employeeMasterRequest.EmpEidImageAttachment  ;
                    employee.EmpEidNo= employeeMasterRequest.EmpEidNo  ;
                    employee.EmpMobileNumber = employeeMasterRequest.EmpMobileNumber  ;
                    employee.EmpName = employeeMasterRequest.EmpName  ;
                    employee.EmpSalaryPaid = employeeMasterRequest.EmpSalaryPaid  ;
                    employee.EmpType = employeeMasterRequest.EmpType  ;
                    employee.EmpVisaImageAttachment = employeeMasterRequest.EmpVisaImageAttachment  ;
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
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public async Task<EmployeeMasterResponse> DeleteEmployeeMaster(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var employeeMaster = _context.EmployeeMaster.FirstOrDefault(a => a.EmpId == employeeMasterRequest.EmpId);
                if (employeeMaster != null)
                {
                    employeeMaster.EmpDeletedBy = 1;
                    employeeMaster.EmpDeletedDate = employeeMasterRequest.EmpDeletedDate;
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
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public EmployeeMasterResponse GenderList()
        {
            try
            {
                var genderMaster = _context.GenderMaster.ToList();
                if (genderMaster != null && genderMaster.Any())
                {
                   // _response.EmpGenderId = (from a in genderMaster select new { text = a.GenGender, id = a.GenId }).ToList();
                    _response.Message = _toaster.Success;
                    return _response;
                }
                else
                {
                    _response.Message = _toaster.NoData;
                    return _response;

                }
            }
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public EmployeeMasterResponse GetDepartment()
        {
            try
            {
                var departmentMaster = _context.DepartmentMaster.ToList();
                if (departmentMaster != null && departmentMaster.Any())
                {
                    //_response.Department = (from a in departmentMaster select new {text = a.DepName, id = a.DepId }).ToList();
                    _response.Message = _toaster.Success;
                    return _response;
                }
                else
                {
                    _response.Message = _toaster.NoData;
                    return _response;

                }
            }
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public EmployeeMasterResponse GetDesignation()
        {
            try
            {
                var designationMaster = _context.DesignationMaster.ToList();
                if (designationMaster != null && designationMaster.Any())
                {
                   // _response.Designation = (from a in designationMaster select new { text = a.DesName, id = a.DesId }).ToList();
                    _response.Message = _toaster.Success;
                    return _response;
                }
                else
                {
                    _response.Message = _toaster.NoData;
                    return _response;

                }
            }
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public EmployeeMasterResponse GetSalaryPaidMaster()
        {
            try
            {
                var salaryPaidMaster = _context.SalaryPaidMaster.ToList();
                if (salaryPaidMaster != null && salaryPaidMaster.Any())
                {
                   // _response.EmpSalaryPaid = (from a in salaryPaidMaster select new { text = a.SalName, id = a.SalId }).ToList(); 
                    _response.Message = _toaster.Success;
                    return _response;
                }
                else
                {
                    _response.Message = _toaster.NoData;
                    return _response;

                }
            }
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _response;
            }
        }
        public Response GetEmployee(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            { 
                var Tw = _context.EmployeeMaster.ToList();
                var employeeMaster = _context.EmployeeMaster.Where(a => a.EmpDeletedBy == null).ToList();
                if (employeeMasterRequest.EmpId==0)
                    employeeMaster= _context.EmployeeMaster.Where(a => a.EmpDeletedBy == null).ToList();
                else
                    employeeMaster = _context.EmployeeMaster.Where(a => a.EmpDeletedBy == null && a.EmpId == employeeMasterRequest.EmpId).ToList();

                if (employeeMaster != null && employeeMaster.Any())
                {
                   var employeeMastert = (from emp in employeeMaster
                                          orderby -emp.EmpId
                                      where emp.EmpDeletedBy == null
                                      select new EmployeeMasterResponse
                                      {
                                          EmpAirTicket = emp.EmpAirTicket ?? "",
                                          EmpCode = emp.EmpCode ?? "",
                                          EmpCostCenter = emp.EmpCostCenter,
                                          //EmpCostCentre = _context.CostCenterMaster.FirstOrDefault(a => a.CsId == emp.EmpCostCentre && a.CsDeletedBy == null).CsName ?? "",
                                          EmpAssetsGiven = emp.EmpAssetsGiven ?? "",
                                          EmpDepartment = emp.EmpDepartment ?? "",
                                          //EmpDepartmanetName = (_context.DepartmentMaster.FirstOrDefault(a => a.DepId == emp.EmpDepartmentId).DepName ?? "Undefined"),
                                          EmpDesignation = emp.EmpDesignation ?? "",
                                          EmpGenderId = (int)emp.EmpGenderId,//(_context.GenderMaster.FirstOrDefault(a => a.GenId == emp.EmpGenderId).GenGender ?? ""),
                                          EmpSalaryPaid = emp.EmpSalaryPaid ?? "",
                                         // EmpDesignationMaster = (_context.DesignationMaster.FirstOrDefault(a => a.DesId == emp.EmpDesignation)),
                                          //SalaryPaid = (_context.SalaryPaidMaster.FirstOrDefault(a => a.SalId == emp.EmpSalaryPaidId)),
                                         // EmpGenderMaster = (_context.GenderMaster.FirstOrDefault(a => a.GenId == emp.EmpGenderId)),
                                          EmpDob = emp.EmpDob,
                                          EmpEidExpDt = emp.EmpEidExpDt,
                                          EmpPpIssuedDate = emp.EmpPpIssuedDate,
                                          EmpPpExpirationDate = emp.EmpPpExpirationDate,
                                          EmpEidImageAttachment = emp.EmpEidImageAttachment ?? "",
                                          EmpEidNo = emp.EmpEidNo,
                                          EmpEmailId = emp.EmpEmailId ?? "",
                                          EmpEmployer = emp.EmpEmployer ?? "",
                                          EmpEmploymentEndDate = emp.EmpEmploymentEndDate,
                                          EmpEmploymentStatus = emp.EmpEmploymentStatus ?? "",
                                          EmpHousingDetails = emp.EmpHousingDetails ?? "",
                                          EmpId = emp.EmpId,
                                          EmpJobLocation = emp.EmpJobLocation ?? "",
                                          EmpJoiningDate = emp.EmpJoiningDate,
                                          EmpLeaveBalance = emp.EmpLeaveBalance ?? "",
                                          EmpLoansGiven = emp.EmpLoansGiven ?? "",
                                          EmpMobileNumber = emp.EmpMobileNumber ?? "",
                                          EmpMonthlySalary = emp.EmpMonthlySalary,
                                          EmpName = emp.EmpName ?? "",
                                          EmpNationality = emp.EmpNationality ?? "",
                                          EmpOthers1 = emp.EmpOthers1 ?? "",
                                          EmpPhoto = emp.EmpPhoto ?? "",
                                          EmpPpImageAttachment = emp.EmpPpImageAttachment ?? "",
                                          EmpPpNo = emp.EmpPpNo ?? "",
                                          EmpPrevVacationDetails = emp.EmpPrevVacationDetails ?? "",
                                          EmpProbationPeriod = emp.EmpProbationPeriod ?? "",
                                          EmpType = emp.EmpType ?? "",
                                          EmpVisaExpDt = emp.EmpVisaExpDt,
                                          EmpVisaImageAttachment = emp.EmpVisaImageAttachment ?? "",
                                          EmpVisaIssuedFrom = emp.EmpVisaIssuedFrom ?? "",
                                          EmpVisaNo = emp.EmpVisaNo,                                          
                                      }).ToList();
                    if (employeeMastert.Any())
                    {
                        foreach(var emp in employeeMastert)
                        {
                            var empCostCentre = _context.CostCenterMaster.FirstOrDefault(a => a.CsId == emp.EmpCostCenter && a.CsDeletedBy == null);
                            if(empCostCentre != null)
                            {
                                emp.EmpCostCenterName = empCostCentre.CsName;
                            }
                            else
                            {
                                emp.EmpCostCenter = 0;
                            }
                        }
                    }
                    _employeeResponse.EmployeeMasterResponse = employeeMastert.OrderByDescending(a => a.EmpId).ToList();
                    _employeeResponse.Message = _toaster.Success;
                    _employeeResponse.CustomerMasterResponse = _context.CustomerMaster.Where(a => a.CustDeletedBy == null).ToList();

                    return _employeeResponse;
                }
                else
                {
                    _employeeResponse.Message = _toaster.NoData;
                    return _employeeResponse;

                }
            }
            catch
            {
                _response.Message = "Emp code " + _toaster.Failed;
                return _employeeResponse;
            }
        }
        
        private EmployeeMaster SetEmployeeValues(EmployeeMasterRequest employeeMasterRequest)
        {
            EmployeeMaster employee = new EmployeeMaster();
            employee.EmpPpNo = employeeMasterRequest.EmpPpNo;
            employee.EmpPpExpirationDate = employeeMasterRequest.EmpPpExpirationDate;
            employee.EmpPpIssuedDate = employeeMasterRequest.EmpPpIssuedDate;
            employee.EmpCode = employeeMasterRequest.EmpCode;
            employee.EmpProbationPeriod = employeeMasterRequest.EmpProbationPeriod;
            employee.EmpAirTicket = employeeMasterRequest.EmpAirTicket;
            employee.EmpAssetsGiven = employeeMasterRequest.EmpAssetsGiven;
            employee.EmpLoansGiven = employeeMasterRequest.EmpLoansGiven;
            employee.EmpOthers1 = employeeMasterRequest.EmpOthers1;
            employee.EmpEidExpDt = employeeMasterRequest.EmpEidExpDt;
            employee.EmpCostCenter = employeeMasterRequest.EmpCostCenter;
            employee.EmpVisaNo = employeeMasterRequest.EmpVisaNo;
            employee.EmpVisaIssuedFrom = employeeMasterRequest.EmpVisaIssuedFrom;
            employee.EmpGenderId = employeeMasterRequest.EmpGenderId;
            employee.EmpEmailId = employeeMasterRequest.EmpEmailId;
            employee.EmpPhoto = employeeMasterRequest.EmpPhoto;
            employee.EmpHousingDetails = employeeMasterRequest.EmpHousingDetails;
            employee.EmpId = employeeMasterRequest.EmpId;
            employee.EmpJobLocation = employeeMasterRequest.EmpJobLocation;
            employee.EmpDob = employeeMasterRequest.EmpDob;
            employee.EmpDepartment = employeeMasterRequest.EmpDepartment;
            employee.EmpDesignation = employeeMasterRequest.EmpDesignation;
            employee.EmpEmploymentEndDate = employeeMasterRequest.EmpEmploymentEndDate;
            employee.EmpEmploymentStatus = employeeMasterRequest.EmpEmploymentStatus;
            employee.EmpJoiningDate = employeeMasterRequest.EmpJoiningDate;
            employee.EmpLeaveBalance = employeeMasterRequest.EmpLeaveBalance;
            employee.EmpNationality = employeeMasterRequest.EmpNationality;
            employee.EmpMonthlySalary = employeeMasterRequest.EmpMonthlySalary;
            employee.EmpPpImageAttachment = employeeMasterRequest.EmpPpImageAttachment;
            employee.EmpPrevVacationDetails = employeeMasterRequest.EmpPrevVacationDetails;
            employee.EmpEidExpDt = employeeMasterRequest.EmpEidExpDt;
            employee.EmpEmployer = employeeMasterRequest.EmpEmployer;
            employee.EmpEidImageAttachment = employeeMasterRequest.EmpEidImageAttachment;
            employee.EmpEidNo = employeeMasterRequest.EmpEidNo;
            employee.EmpMobileNumber = employeeMasterRequest.EmpMobileNumber;
            employee.EmpName = employeeMasterRequest.EmpName;
            employee.EmpSalaryPaid = employeeMasterRequest.EmpSalaryPaid;
            employee.EmpType = employeeMasterRequest.EmpType;
            employee.EmpVisaImageAttachment = employeeMasterRequest.EmpVisaImageAttachment;
            return employee;
        }
    }
}
