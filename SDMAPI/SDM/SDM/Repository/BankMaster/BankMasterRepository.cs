using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.BankMaster
{
    public class BankMasterRepository : IBankMaster
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public BankMasterRepository(SDMContext context, ToasterMessages toaster, Response response)
        {
            _context = context;
            _toaster = toaster;
            _response = response;
        }
        public async Task<Response> Add(BankMasterEntry supplierRequest)
        {
            var _values = _context.BankMasterEntry.FirstOrDefault(a => a.BnkName == supplierRequest.BnkName && a.BnkDeletedBy == null);
            if (_values == null)
            {
                _context.BankMasterEntry.Add(supplierRequest);
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
        public async Task<Response> Update(BankMasterEntry supplierRequest)
        {
            var _values = _context.BankMasterEntry.FirstOrDefault(a => a.BnkId == supplierRequest.BnkId && a.BnkDeletedBy == null);
            if (_values != null)
            {
                _values.BnkAccName = supplierRequest.BnkAccName;
                _values.BnkAccNo = supplierRequest.BnkAccNo;
                _values.BnkAccountCcy = supplierRequest.BnkAccountCcy;
                _values.BnkAddress = supplierRequest.BnkAddress;
                _values.BnkCode = supplierRequest.BnkCode;
                _values.BnkIbanNumb = supplierRequest.BnkIbanNumb;
                _values.BnkCreditOrDebit = supplierRequest.BnkCreditOrDebit;
                _values.BnkCreditOrDebit2 = supplierRequest.BnkCreditOrDebit2;
                _values.BnkCreditOrDebit3 = supplierRequest.BnkCreditOrDebit3;
                _values.BnkCreditOrDebit4 = supplierRequest.BnkCreditOrDebit4;
                _values.BnkCreditOrDebit5 = supplierRequest.BnkCreditOrDebit5;
                _values.BnkName = supplierRequest.BnkName;
                _values.BnkSwiftCode = supplierRequest.BnkSwiftCode;
                _values.BnkOthers1 = supplierRequest.BnkOthers1;
                _values.Rm1Contact = supplierRequest.Rm1Contact;
                _values.Rm1Email = supplierRequest.Rm1Email;
                _values.Rm1Name = supplierRequest.Rm1Name;
                _values.RmEmail = supplierRequest.RmEmail;
                _values.RmName = supplierRequest.RmName;
                _values.RmContact = supplierRequest.RmContact;
                _values.Rm2Name = supplierRequest.Rm2Name;
                _values.Rm2Email = supplierRequest.Rm2Email;
                _values.Rm2Contact = supplierRequest.Rm2Contact;
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
        public async Task<Response> Delete(BankMasterEntry supplierRequest)
        {
            var _values = _context.BankMasterEntry.FirstOrDefault(a => a.BnkId == supplierRequest.BnkId && a.BnkDeletedBy == null);
            if (_values != null)
            {
                _values.BnkDeletedBy = 1;
                _values.BnkDeletedDate = System.DateTime.Now;
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
        public Response Get(BankMasterEntry supplierRequest)
        {
            var _values = new List<BankMasterEntry>();
            if (supplierRequest.BnkId != 0)
                _values = _context.BankMasterEntry.Where(a => a.BnkId == supplierRequest.BnkId && a.BnkDeletedBy == null).ToList();
            else
                _values = _context.BankMasterEntry.Where(a => a.BnkDeletedBy == null).ToList();
            if (_values != null)
            {
                _response.BankResponse = _values;
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
