using SDM.Common.Request;
using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public TransactionRepository(SDMContext context, ToasterMessages toaster, Response response)
        {
            _context = context;
            _toaster = toaster;
            _response = response;
        }
        public async Task<Response> Add(TransactionRequest transactionEntry)
        {
            var _values1 = _context.TransactionEntry.FirstOrDefault(a => a.TrnId == transactionEntry.TrnId && a.TrnDeletedBy == null);
            if (_values1 == null)
            {
                TransactionEntry _values = new TransactionEntry();
                _values.TrnDate = transactionEntry.TrnDate;
                _values.TrnCreditDebit = transactionEntry.TrnCreditDebit;
                _values.TrnType = transactionEntry.TrnType;
                _values.TrnCategory = transactionEntry.TrnCategory;
                _values.TrnSubAccount = transactionEntry.TrnSubAccount;
                _values.TrnCostCentre = transactionEntry.TrnCostCentre;
                _values.TrnDetails = transactionEntry.TrnDetails;
                _values.TrnInvNo = transactionEntry.TrnInvNo;
                _values.TrnSupplier = transactionEntry.TrnSupplier;
                _values.TrnCurrency = transactionEntry.TrnCurrency;
                _values.TrnAmount = transactionEntry.TrnAmount;
                _values.TrnInstrumentType = transactionEntry.TrnInstrumentType;
                _values.TrnInstrumentNo = transactionEntry.TrnInstrumentNo;
                _values.TrnBankAccountNo = transactionEntry.TrnBankAccountNo;
                _values.TrnRemarks = transactionEntry.TrnRemarks;
                _values.TrnRequestBy = transactionEntry.TrnRequestBy;
                _values.TrnAccountnumber = transactionEntry.TrnAccountnumber;
                _values.TrnVechile = transactionEntry.TrnVehicle;
                _values.TrnEmployee = transactionEntry.TrnEmployee;
                //_values.TrnBankAccountNumb = transactionEntry.TrnBankAccountNumb;
                _context.TransactionEntry.Add(_values);
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
        public async Task<Response> Update(TransactionRequest transactionEntry)
        {
            var _values = _context.TransactionEntry.FirstOrDefault(a => a.TrnId == transactionEntry.TrnId && a.TrnDeletedBy == null);
            if (_values != null)
            {
                _values.TrnDate = transactionEntry.TrnDate;
                _values.TrnCreditDebit = transactionEntry.TrnCreditDebit;
                _values.TrnType = transactionEntry.TrnType;
                _values.TrnCategory = transactionEntry.TrnCategory;
                _values.TrnSubAccount = transactionEntry.TrnSubAccount;
                _values.TrnCostCentre = transactionEntry.TrnCostCentre;
                _values.TrnDetails = transactionEntry.TrnDetails;
                _values.TrnInvNo = transactionEntry.TrnInvNo;
                _values.TrnSupplier = transactionEntry.TrnSupplier;
                _values.TrnCurrency = transactionEntry.TrnCurrency;
                _values.TrnAmount = transactionEntry.TrnAmount;
                _values.TrnInstrumentType = transactionEntry.TrnInstrumentType;
                _values.TrnInstrumentNo = transactionEntry.TrnInstrumentNo;
                _values.TrnBankAccountNo = transactionEntry.TrnBankAccountNo;
                _values.TrnAccountnumber = transactionEntry.TrnAccountnumber;
                _values.TrnRemarks = transactionEntry.TrnRemarks;
                _values.TrnRequestBy = transactionEntry.TrnRequestBy;
                _values.TrnVechile = transactionEntry.TrnVehicle;
                _values.TrnEmployee = transactionEntry.TrnEmployee;
                if(transactionEntry.TrnSubAccountStr.Contains("(VH)"))
                {
                    var vhMaster = _context.VehicleMaster.FirstOrDefault(a => a.VhId == _values.TrnVechile && a.VhDeletedBy == null);
                    _values.TrnFlag = PascalCase(vhMaster.VhType);
                }
                else if(transactionEntry.TrnSubAccountStr.Contains("(EM)"))
                {

                }
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
        public string PascalCase(string word)
        {
            return string.Join("", word.Split('_')
                         .Select(w => w.Trim())
                         .Where(w => w.Length > 0)
                         .Select(w => w.Substring(0, 1).ToUpper() + w.Substring(1).ToLower()));
        }
        public async Task<Response> Delete(TransactionEntry transactionEntry)
        {
            var _values = _context.TransactionEntry.FirstOrDefault(a => a.TrnId == transactionEntry.TrnId && a.TrnDeletedBy == null);
            if (_values != null)
            {
                _values.TrnDeletedBy = 1;
                _values.TrnDeletedDate = System.DateTime.Now;
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
        public Response Get(TransactionEntry transactionEntry)
        {
            var _values = new List<TransactionEntry>();
            if (transactionEntry.TrnId != 0)
                _values = _context.TransactionEntry.Where(a => a.TrnId == transactionEntry.TrnId && a.TrnDeletedBy == null).ToList();
            else
                _values = _context.TransactionEntry.Where(a => a.TrnDeletedBy == null).ToList();
            if (_values != null)
            {
                var transaction = (from a in _values
                                   orderby -a.TrnId
                                   select new TransactionEntryResponse
                                   {
                                       TrnId = a.TrnId,
                                       TrnDate = a.TrnDate,
                                       TrnCreditDebit = a.TrnCreditDebit,
                                       TrnType = a.TrnType,
                                       TrnCategory = a.TrnCategory,
                                       //TrnCategoryName = _context.ExpenseCategory.FirstOrDefault(e => e.TrnId == a.TrnId && e.TrnDeletedBy == null).TrnCategory ?? "",
                                       TrnSubAccount = a.TrnSubAccount,
                                       //TrnSubAccountName = _context.SubAccountMaster.FirstOrDefault(s => s.PrpId == a.TrnSubAccount && s.PrpDeletedBy == null).PrpName ?? "",
                                       TrnCostCentre = a.TrnCostCentre,
                                       //TrnCostCentreName = _context.CostCenterMaster.FirstOrDefault(s => s.CsId == a.TrnCostCentre && s.CsDeletedBy == null).CsName ?? "",
                                       TrnDetails = a.TrnDetails ?? "",
                                       TrnInvNo = a.TrnInvNo ?? "",
                                       TrnSupplier = a.TrnSupplier,
                                      // TrnSupplierName = _context.SuppliarMaster.FirstOrDefault(s => s.SupId == a.TrnSupplier && s.SupDeletedBy == null).SupCmpyName ?? "",
                                       TrnCurrency = a.TrnCurrency,
                                       TrnAmount = a.TrnAmount ?? "",
                                       TrnInstrumentType = a.TrnInstrumentType,
                                        TrnInstrumentNumb = a.TrnInstrumentNo,
                                        TrnRemarks = a.TrnRemarks,
                                        TrnRequestBy = a.TrnInstrumentNo, 
                                        TrnBankAccountNumb = a.TrnBankAccountNo,
                                       TrnAccountnumber = a.TrnAccountnumber,
                                       TrnVehicle = a.TrnVechile,
                                       TrnEmployee = a.TrnEmployee,
                                      // TrnBankAccountName = _context.BankMasterEntry.FirstOrDefault(s => s.BnkId == a.TrnBankAccountNumb && s.BnkDeletedBy == null).BnkAccName ?? "",
                                   }).ToList();
                if (transaction.Any())
                {
                    foreach(var a in transaction)
                    {
                       var ec = _context.ExpenseCategory.FirstOrDefault(e => e.TrnId == a.TrnCategory && e.TrnDeletedBy == null);
                       var sa = _context.SubAccountMaster.FirstOrDefault(s => s.PrpId == a.TrnSubAccount && s.PrpDeletedBy == null);
                       var cc = _context.CostCenterMaster.FirstOrDefault(s => s.CsId == a.TrnCostCentre && s.CsDeletedBy == null);
                       var sm = _context.SupplierMaster.FirstOrDefault(s => s.SupId == a.TrnSupplier && s.SupDeletedBy == null);
                        var bm = _context.BankMasterEntry.FirstOrDefault(s => s.BnkId == a.TrnBankAccountNumb && s.BnkDeletedBy == null);
                        var em = _context.EmployeeMaster.FirstOrDefault(s => s.EmpId == a.TrnEmployee && s.EmpDeletedBy == null);
                        var vn = _context.VehicleMaster.FirstOrDefault(s => s.VhId == a.TrnVehicle && s.VhDeletedBy == null);
                        
                        if (em != null)
                        { 
                            a.TrnEmployeeName = em.EmpName;
                        }
                        if (vn != null)
                        { 
                            a.TrnVehicleName = vn.VhName;
                        }
                        if (ec != null)
                        {
                            a.TrnCategory = ec.TrnId;
                            a.TrnCategoryName = ec.TrnCategory;
                        }
                        else
                        {
                            a.TrnCategory = 0;
                        }
                        if(sa != null)
                        {
                            a.TrnSubAccount = sa.PrpId;
                            a.TrnSubAccountName = sa.PrpName;
                        }
                        else
                        {
                            a.TrnSubAccountName = "";
                        }
                        if(cc != null)
                        {
                            a.TrnCostCentreName = cc.CsName;
                        }
                        else
                        {
                            a.TrnCostCentreName = "";
                        }
                        if (sm != null)
                        {
                            a.TrnSupplierName = sm.SupCompanyName;
                        }
                        else
                        {
                            a.TrnSupplierName = "";
                        }
                        if(bm != null)
                        {
                            a.TrnBankAccountName = bm.BnkAccNo;
                        }
                        else
                        {
                            a.TrnBankAccountName = "";
                        }
                    }
                }
                _response.TransactionEntries = transaction;
                _response.Message = _toaster.Success;
                return _response;
            }
            else
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
        }
        public Response GetAccountForTransaction(TransactionEntry transactionEntry)
        {
            var subAccVlues = _context.SubAccountMaster.Where(a => a.PrpDeletedBy == null).ToList();
            var empvalues = _context.EmployeeMaster.Where(a => a.EmpDeletedBy == null).ToList();
            var vhvalues = _context.VehicleMaster.Where(a => a.VhDeletedBy == null).ToList();
            List<TransactionAccount> transactionAccounts = new List<TransactionAccount>();
            if (subAccVlues.Any())
            {
                foreach(var sa in subAccVlues)
                {
                    TransactionAccount transactionAccount = new TransactionAccount();
                    transactionAccount.Id = sa.PrpId;
                    transactionAccount.Value = "(SA) - " + sa.PrpName +" ("+ sa.PrpShortName+")";
                    transactionAccounts.Add(transactionAccount);
                }
            }
            if (empvalues.Any())
            {
                foreach (var emp in empvalues)
                {
                    TransactionAccount transactionAccount = new TransactionAccount();
                    transactionAccount.Id = emp.EmpId;
                    transactionAccount.Value = "(Em) - " + emp.EmpName + " ("+ emp.EmpCode +")";
                    transactionAccounts.Add(transactionAccount);
                }
            }
            if (vhvalues.Any())
            {
                foreach (var vh in vhvalues)
                {
                    TransactionAccount transactionAccount = new TransactionAccount();
                    transactionAccount.Id = vh.VhId;
                    transactionAccount.Value = "(VH) - " + vh.VhName + " (" + vh.VhRegNo + ")";
                    transactionAccounts.Add(transactionAccount);
                }
            }
            _response.TransactionAccounts = transactionAccounts;
            _response.Message = _toaster.Success;
            return _response;
        }
    }
}
