using Newtonsoft.Json;
using SDM.Common.Request;
using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.Report
{
    public class ReportRepository : IReport
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public ReportRepository(SDMContext context, Response response, ToasterMessages toaster)
        {
            _context = context;
            _response = response;
            _toaster = toaster;
        }

         public  async Task<Response> GetReport(ReportRequest g)
        {
         
             var _values =  _context.TransactionEntry.Where(t => t.TrnDeletedBy == null && t.TrnDate >= g.FromDate && t.TrnDate <= g.ToDate  ).ToList();
           if(g.Currency != 0)
            {
                _values = _context.TransactionEntry.Where(t => t.TrnDeletedBy == null && t.TrnDate >= g.FromDate && t.TrnDate <= g.ToDate && t.TrnCurrency == g.Currency).ToList();
            }
            if (g.Type != "0")
            {
                _values = _context.TransactionEntry.Where(t => t.TrnDeletedBy == null && t.TrnDate >= g.FromDate && t.TrnDate <= g.ToDate && t.TrnFlag == g.Type).ToList();
            }
            if (g.Currency != 0 && g.Type != "0")
            {
                _values = _context.TransactionEntry.Where(t => t.TrnDeletedBy == null && t.TrnDate >= g.FromDate && t.TrnDate <= g.ToDate && t.TrnFlag == g.Type && t.TrnCurrency == g.Currency).ToList();

            }


            if (_values != null)
            {
                var transaction = (from a in _values
                                   orderby -a.TrnId
                                   select new ReportResponses
                                   {
                                       Category = _context.ExpenseCategory.FirstOrDefault(e => e.TrnId == (int)a.TrnCategory).TrnCategory,
                                       TransAmount =  Convert.ToInt32(a.TrnAmount),
                                       TrnDate =  a.TrnDate,
                                      
                                       // TrnBankAccountName = _context.BankMasterEntry.FirstOrDefault(s => s.BnkId == a.TrnBankAccountNumb && s.BnkDeletedBy == null).BnkAccName ?? "",
                                   }).ToList();
               

                var queryq = transaction
                    .GroupBy(c => c.Category)
                    .Select(g => new {
                        Category = g.Key,
                        Jan = g.Where(c => c.TrnDate?.Month == 1).Sum(c => c.TransAmount),
                        Feb = g.Where(c => c.TrnDate?.Month == 2).Sum(c => c.TransAmount),
                        Mar = g.Where(c => c.TrnDate?.Month == 3).Sum(c => c.TransAmount),
                        Apr = g.Where(c => c.TrnDate?.Month == 4).Sum(c => c.TransAmount),
                        May = g.Where(c => c.TrnDate?.Month == 5).Sum(c => c.TransAmount),
                        Jun = g.Where(c => c.TrnDate?.Month == 6).Sum(c => c.TransAmount),
                        Jul = g.Where(c => c.TrnDate?.Month == 7).Sum(c => c.TransAmount),
                        Aug = g.Where(c => c.TrnDate?.Month == 8).Sum(c => c.TransAmount),
                        Sep = g.Where(c => c.TrnDate?.Month == 9).Sum(c => c.TransAmount),
                        Oct = g.Where(c => c.TrnDate?.Month == 10).Sum(c => c.TransAmount),
                        Nov = g.Where(c => c.TrnDate?.Month == 11).Sum(c => c.TransAmount),
                        Dec = g.Where(c => c.TrnDate?.Month == 12).Sum(c => c.TransAmount),
                       
                    });
                var _x = new
                {
                    Category = "Total",
                    Jan = queryq.Select(x => x.Jan).Sum(),
                    Feb = queryq.Select(x => x.Feb).Sum(),
                    Mar = queryq.Select(x => x.Mar).Sum(),
                    Apr = queryq.Select(x => x.Apr).Sum(),
                    May = queryq.Select(x => x.May).Sum(),
                    Jun = queryq.Select(x => x.Jun).Sum(),
                    Jul = queryq.Select(x => x.Jul).Sum(),
                    Aug = queryq.Select(x => x.Aug).Sum(),
                    Sep = queryq.Select(x => x.Sep).Sum(),
                    Oct = queryq.Select(x => x.Oct).Sum(),
                    Nov = queryq.Select(x => x.Nov).Sum(),
                    Dec = queryq.Select(x => x.Dec).Sum(),
                     
                };
                //_response.ReportsResponse = transaction;
                string D = JsonConvert.SerializeObject(queryq);
                List<Report1> List11 = JsonConvert.DeserializeObject<List<Report1>>(D);
                string D1 = JsonConvert.SerializeObject(_x);
                Report1 List1 = JsonConvert.DeserializeObject<Report1>(D1);
                List11.Add(List1);
                //List<Report1> List1 = new List<Report1>();
                //List<dynamic> List11 = new List<dynamic>();
                //List11.Add(queryq.ToList());
                // List11.Add(_x);
                _response.ReportResponse = JsonConvert.SerializeObject(List11);
                _response.CustomerMasterResponse = _context.CustomerMaster.Where(a => a.CustDeletedBy == null).ToList(); 
            _response.Message = _toaster.Success;
            return _response;
             }
            else
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
}
        public class Report1
        {
            public string Category { get; set; }
            public int? Jan { get; set; }
            public int? Feb { get; set; }
            public int? Mar { get; set; }
            public int? Apr { get; set; }
            public int? May { get; set; }
            public int? Jun { get; set; }
            public int? Jul { get; set; }
            public int? Aug { get; set; }
            public int? Sep { get; set; }
            public int? Oct { get; set; }
            public int? Nov { get; set; }
            public int? Dec { get; set; } 
           
        }

        public async Task<Response> GetCardReport(ReportCardRequest g)
        {

            var _values = _context.TransactionEntry.Where(t => t.TrnDeletedBy == null && t.TrnDate >= g.FromDate && t.TrnDate <= g.ToDate).ToList();
       
            string Currency = "";            
            string CostCenter = "";
            string BankAccNumber = "";
            string Category = "";
            string SubAccount = "";
            if (g.Currency == 0 || g.Currency == null)
                Currency = "";
            else
                Currency = Convert.ToString(g.Currency);
            if (g.CostCenter == "0" || g.CostCenter == null)
                CostCenter = "";
            else
                CostCenter = g.CostCenter;
            if (g.BankAccNumber == "0" || g.BankAccNumber == null)
                BankAccNumber = "";
            else
                BankAccNumber = g.BankAccNumber;
            if (g.Category == "0" || g.Category == null)
                Category = "";
            else
                Category = g.Category;
            if (g.SubAccount == "0" || g.SubAccount == null)
                SubAccount = "";
            else
                SubAccount = g.SubAccount;

            try
            {
                var subAccVlues = _context.SubAccountMaster.Where(a => a.PrpDeletedBy == null).ToList();
                var empvalues = _context.EmployeeMaster.Where(a => a.EmpDeletedBy == null).ToList();
                var vhvalues = _context.VehicleMaster.Where(a => a.VhDeletedBy == null).ToList();
                List<TransactionAccount> transactionAccounts = new List<TransactionAccount>();
                if (subAccVlues.Any())
                {
                    foreach (var sa in subAccVlues)
                    {
                        TransactionAccount transactionAccount = new TransactionAccount();
                        transactionAccount.Id = sa.PrpId;
                        transactionAccount.Type = "PRP";
                        transactionAccount.Value = "(SA) - " + sa.PrpName + " (" + sa.PrpShortName + ")";
                        transactionAccounts.Add(transactionAccount);
                    }
                }
                if (empvalues.Any())
                {
                    foreach (var emp in empvalues)
                    {
                        TransactionAccount transactionAccount = new TransactionAccount();
                        transactionAccount.Id = emp.EmpId;
                        transactionAccount.Type = "EM";
                        transactionAccount.Value = "(Em) - " + emp.EmpName + " (" + emp.EmpCode + ")";
                        transactionAccounts.Add(transactionAccount);
                    }
                }
                if (vhvalues.Any())
                {
                    foreach (var vh in vhvalues)
                    {
                        TransactionAccount transactionAccount = new TransactionAccount();
                        transactionAccount.Id = vh.VhId;
                        transactionAccount.Type = vh.VhType;
                        transactionAccount.Value = "(VH) - " + vh.VhName + " (" + vh.VhRegNo + ")";
                        transactionAccounts.Add(transactionAccount);
                    }
                }


                if (_values != null)
            {
                var transaction = (from a in _values
                                   orderby -a.TrnId
                                   select new TransactionEntryResponse
                                   {
                                       TrnId = a.TrnId,
                                       TrnDate = a.TrnDate,
                                       TrnDateFormat = a.TrnDate?.ToString("dd/MM/yyyy"),
                                       TrnMonthFormat = a.TrnDate?.ToString("MMM"),
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
                                       TrnCommonSubAccount= transactionAccounts.Where(x => x.Type.Contains(a.TrnFlag)&& x.Id==a.TrnSubAccount).Select(x=>x.Value).FirstOrDefault(),
                                       // TrnBankAccountName = _context.BankMasterEntry.FirstOrDefault(s => s.BnkId == a.TrnBankAccountNumb && s.BnkDeletedBy == null).BnkAccName ?? "",
                                   }).Where(t => t.TrnDeletedBy == null &&
                t.TrnDate >= g.FromDate && t.TrnDate <= g.ToDate
                && t.TrnSubAccount.ToString().ToLower().Contains(SubAccount.ToLower())
                && t.TrnCategory.ToString().ToLower().Contains(Category.ToLower())
                && t.TrnBankAccountNumb.ToString().ToLower().Contains(BankAccNumber.ToLower())
                && t.TrnCostCentre.ToString().ToLower().Contains(CostCenter.ToLower())
                && t.TrnCurrency.ToString().ToLower().Contains(Currency.ToLower())
                ).ToList();
                if (transaction.Any())
                {
                    foreach (var a in transaction)
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
                        if (sa != null)
                        {
                            a.TrnSubAccount = sa.PrpId;
                            a.TrnSubAccountName = sa.PrpName;
                        }
                        else
                        {
                            a.TrnSubAccountName = "";
                        }
                        if (cc != null)
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
                        if (bm != null)
                        {
                            a.TrnBankAccountName = bm.BnkAccNo;
                        }
                        else
                        {
                            a.TrnBankAccountName = "";
                        }
                    }
                }   //_response.ReportsResponse = transaction;
                    transaction = transaction.OrderBy(x => x.TrnDate).ToList();
                    var _returnValues = transaction.GroupBy(t => (t.TrnBankAccountNumb, t.TrnAccountnumber)).ToList();
                    _response.ReportTemp = transaction.OrderBy(x=>x.TrnDate);
                    _response.ReportResponse = JsonConvert.SerializeObject(_returnValues);
                    _response.CustomerMasterResponse = _context.CustomerMaster.Where(a => a.CustDeletedBy == null).ToList();
                    _response.Message = _toaster.Success;
                return _response;
            }
            else
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
            }
            catch (Exception e)
            {
                _response.Message = _toaster.NotExists;
                return _response;
            }
        }

        public async Task<Response> Gettransactiontype()
        {
            var _values = _context.TransactionEntry.Where(t => t.TrnDeletedBy == null && t.TrnFlag != null).Select(o => o.TrnFlag).Distinct().ToList();
            if (_values != null)
            {
            _response.ReportTemp = _values;
            _response.Message = _toaster.Success;
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
