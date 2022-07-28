using System;

namespace SDM.Common.Request
{
    public class EmployeeMasterRequest
    {
        public int EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public int? EmpGenderId { get; set; }
        public string EmpDesignation { get; set; }
        public string EmpDepartment { get; set; }
        public string EmpPhoto { get; set; }
        public string EmpNationality { get; set; }
        public DateTime? EmpJoiningDate { get; set; }
        public string EmpMonthlySalary { get; set; }
        public string EmpSalaryPaid { get; set; }
        public DateTime? EmpDob { get; set; }
        public string EmpEmployer { get; set; }
        public string EmpJobLocation { get; set; }
        public int? EmpCostCenter { get; set; }
        public string EmpPpNo { get; set; }
        public DateTime? EmpPpIssuedDate { get; set; }
        public DateTime? EmpPpExpirationDate { get; set; }
        public string EmpPpImageAttachment { get; set; }
        public string EmpVisaIssuedFrom { get; set; }
        public string EmpVisaNo { get; set; }
        public string EmpVisaExpDt { get; set; }
        public string EmpVisaImageAttachment { get; set; }
        public string? EmpEidNo { get; set; }
        public string EmpEidExpDt { get; set; }
        public string EmpEidImageAttachment { get; set; }
        public string EmpAssetsGiven { get; set; }
        public string EmpHousingDetails { get; set; }
        public string EmpLoansGiven { get; set; }
        public string EmpMobileNumber { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpPrevVacationDetails { get; set; }
        public string EmpLeaveBalance { get; set; }
        public string EmpAirTicket { get; set; }
        public string EmpProbationPeriod { get; set; }
        public DateTime? EmpEmploymentEndDate { get; set; }
        public string EmpEmploymentStatus { get; set; }
        public string EmpType { get; set; }
        public string EmpOthers1 { get; set; }
        public int? EmpCreatedBy { get; set; }
        public DateTime? EmpCreatedDate { get; set; }
        public int? EmpUpdatedBy { get; set; }
        public DateTime? EmpUpdatedDate { get; set; }
        public int? EmpDeletedBy { get; set; }
        public DateTime? EmpDeletedDate { get; set; }

        public string? EmpPassPortFrontImage { get; set; }
        public string? EmpPassPortBackImage { get; set; }
        public string? EmpVisaFrontImage { get; set; }
        public string? EmpVisaBackImage { get; set; }
    }
}
