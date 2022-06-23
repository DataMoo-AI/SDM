using SDM.TModels;
using System;
using System.Collections.Generic;

namespace SDM.Common.Response
{
    public class Response
    {
        public List<EmployeeMasterResponse> EmployeeMasterResponse { get; set; }
        public List<CustomerMaster> CustomerMasterResponse { get; set; }
        public List<CostCenterMaster> CostCenterResponse { get; set; }
        public List<TransactionAccount> TransactionAccounts { get; set; }
        public List<SAResponse> SubAccountResponse { get; set; }
        public List<VhResponse> VechileResponse { get; set; }
        public List<SupplierMaster> SupplierResponse { get; set; }
        public List<BankMasterEntry> BankResponse { get; set; }
        public List<ExpenseCategory> ExpenseCategoryResponse { get; set; }
        public List<InsuranceMaster> InsuranceMasterResponse { get; set; }
        public List<InsuranceResponse> InsuranceMasterResp { get; set; }
        public List<TransactionEntryResponse> TransactionEntries { get; set; }
        public List<InsuranceReq> InsuranceMasterReq { get; set; }
        public List<ReportResponses> ReportsResponse { get; set; }
        public string? ReportResponse { get; set; }
        public string Message { get; set; }
    }
    public class TransactionAccount 
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }   
    public class ReportResponses
    { 
        
        public DateTime? TrnDate { get; set; }
        public int? TransAmount { get; set; }
        public string? Category { get; set; }
        public string? ReportResponse { get; set; }
    }
    public class InsuranceReq
    {

        public int InsId { get; set; }
        public int? InsCostCenter { get; set; }
        public string InsVehicleCode { get; set; }
        public string InsVehicleName { get; set; }
        public string InsPolicyNo { get; set; }
        public DateTime? InsPurchaseDate { get; set; }
        public string InsPurchaseAmount { get; set; }
        public string InsCompany { get; set; }
        public DateTime? InsExpDate { get; set; }
        public string InsPremiumAmount { get; set; }
        public string InsOthers1 { get; set; }
        public int? InsCreatedBy { get; set; }
        public DateTime? InsCreatedDate { get; set; }
        public int? InsUpdatedBy { get; set; }
        public DateTime? InsUpdatedDate { get; set; }
        public int? InsDeletedBy { get; set; }
        public DateTime? InsDeletedDate { get; set; }
    }
    public class InsuranceResponse
    {
        public int InsId { get; set; }
        public int? InsCostCenter { get; set; }
        public string InsCostCenterName { get; set; }
        public string InsVehicleCode { get; set; }
        public string InsVehicleName { get; set; }
        public string InsPolicyNo { get; set; }
        public DateTime? InsPurchaseDate { get; set; }
        public string InsPurchaseAmount { get; set; }
        public string InsCompany { get; set; }
        public DateTime? InsExpDate { get; set; }
        public string InsPremiumAmount { get; set; }
        public string InsOthers1 { get; set; }
        public int? InsCreatedBy { get; set; }
        public DateTime? InsCreatedDate { get; set; }
        public int? InsUpdatedBy { get; set; }
        public DateTime? InsUpdatedDate { get; set; }
        public int? InsDeletedBy { get; set; }
        public DateTime? InsDeletedDate { get; set; }
    }
    public class VhResponse
    {
        public int VhId { get; set; }
        public string VhCode { get; set; }
        public string VhType { get; set; }
        public string VhVehicleOn { get; set; }
        public string VhCostCentreName { get; set; }
        public string VhName { get; set; }
        public string VhMakeBrand { get; set; }
        public string VhModelYear { get; set; }
        public DateTime? VhPurchaseDt { get; set; }
        public string VhRegNo { get; set; }
        public string VhRegistrationExp { get; set; }
        public string VhTypeOfPurchase { get; set; }
        public string VhSizeCapacity { get; set; }
        public string VhDrivenBy { get; set; }
        public int? VhCostCentre { get; set; }
        public string VhLocation { get; set; }
        public string VhPurchaseValue { get; set; }
        public string VhPurchasedFrom { get; set; }
        public string VhPurchasedColor { get; set; }
        public string VhColour { get; set; }
        public string VhEnginePower { get; set; }
        public string VhNoOfEngines { get; set; }
        public string VhEngineSerialNumber { get; set; }
        public string VhEngineMake { get; set; }
        public string VhTypeOfHull { get; set; }
        public string VhHullChassisNo { get; set; }
        public string VhWeight { get; set; }
        public string VhOriginPlace { get; set; }
        public string VhNoOfPassengers { get; set; }
        public string VhNoOfCrew { get; set; }
        public string VhRadioDeviceName { get; set; }
        public string VhRadioDeviceType { get; set; }
        public string VhRadioDeviceSno { get; set; }
        public string VhImage { get; set; }
        public string VhStatus { get; set; }
        public string VhOthers1 { get; set; }
        public string VhOthers2 { get; set; }
        public string VhOthers3 { get; set; }
        public string VhOthers4 { get; set; }
        public int? VhCreatedBy { get; set; }
        public DateTime? VhCreatedDate { get; set; }
        public int? VhUpdatedBy { get; set; }
        public DateTime? VhUpdatedDate { get; set; }
        public int? VhDeletedBy { get; set; }
        public DateTime? VhDeletedDate { get; set; }
    }
    public class SAResponse
    {
        public int PrpId { get; set; }
        public string PrpShrtName { get; set; }
        public string PrpName { get; set; }
        public string PrpDetails { get; set; }
        public int? PrpCostCentre { get; set; }
        public string PrpCostCentreName { get; set; }
        public string PrpContactPerson { get; set; }
        public string PrpContactPersonNumber { get; set; }
        public string PrpLocation { get; set; }
        public string PrpOthers1 { get; set; }
        public string PrpOthers2 { get; set; }
        public string PrpOthers3 { get; set; }
        public int? PrpCreatedBy { get; set; }
        public DateTime? PrpCreatedDate { get; set; }
        public int? PrpUpdatedBy { get; set; }
        public DateTime? PrpUpdatedDate { get; set; }
        public int? PrpDeletedBy { get; set; }
        public DateTime? PrpDeletedDate { get; set; }
    }
    public class EmployeeMasterResponse
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
        public string EmpCostCenterName { get; set; }
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
        public string Message { get; set; }
    }
    public class TransactionEntryResponse
    {
        public int TrnId { get; set; }
        public DateTime? TrnDate { get; set; }
        public int? TrnCreditDebit { get; set; }
        public int? TrnType { get; set; }
        public int? TrnCategory { get; set; }
        public string TrnCategoryName { get; set; }
        public int? TrnSubAccount { get; set; }
        public string TrnSubAccountName { get; set; }
        public int? TrnCostCentre { get; set; }
        public string TrnCostCentreName { get; set; }
        public string TrnDetails { get; set; }
        public string TrnInvNo { get; set; }
        public int? TrnSupplier { get; set; }
        public string TrnSupplierName { get; set; }
        public int? TrnCurrency { get; set; }
        public string TrnCurrencyName { get; set; }
        public string TrnAmount { get; set; }
        public int? TrnInstrumentType { get; set; }
        public string TrnInstrumentNumb { get; set; }

        public string TrnRemarks { get; set; }
        public string TrnRequestBy { get; set; } 
        public int? TrnBankAccountNumb { get; set; }
        public string? TrnAccountnumber { get; set; }
        public int? TrnVehicle { get; set; }
        public int? TrnEmployee { get; set; }
        public string? TrnVehicleName { get; set; }
        public string? TrnEmployeeName { get; set; }
        public string TrnBankAccountName { get; set; }
        public int? TrnCreatedBy { get; set; }
        public DateTime? TrnCreatedDate { get; set; }
        public int? TrnUpdatedBy { get; set; }
        public DateTime? TrnUpdatedDate { get; set; }
        public int? TrnDeletedBy { get; set; }
        public DateTime? TrnDeletedDate { get; set; }
    }
}
