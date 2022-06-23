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
                        Jun = g.Where(c => c.TrnDate?.Month == 1).Sum(c => c.TransAmount),
                        Jul = g.Where(c => c.TrnDate?.Month == 2).Sum(c => c.TransAmount),
                        Aug = g.Where(c => c.TrnDate?.Month == 3).Sum(c => c.TransAmount),
                        Sep = g.Where(c => c.TrnDate?.Month == 4).Sum(c => c.TransAmount),
                        Oct = g.Where(c => c.TrnDate?.Month == 5).Sum(c => c.TransAmount),
                        Nov = g.Where(c => c.TrnDate?.Month == 5).Sum(c => c.TransAmount),
                        Dec = g.Where(c => c.TrnDate?.Month == 5).Sum(c => c.TransAmount),
                        sum=0,
                    });
               
                //_response.ReportsResponse = transaction;

                _response.ReportResponse = JsonConvert.SerializeObject(queryq);
            _response.Message = _toaster.Success;
            return _response;
             }
            else
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
