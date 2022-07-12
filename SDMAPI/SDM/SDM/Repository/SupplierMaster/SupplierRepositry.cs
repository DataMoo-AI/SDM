using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.SupplierMaster
{
    public class SupplierRepositry :ISupplier
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public SupplierRepositry(SDMContext context, ToasterMessages toaster, Response response)
        {
            _context = context;
            _toaster = toaster;
            _response = response;
        }
        public async Task<Response> Add(SDM.TModels.SupplierMaster supplierRequest)
        {
            var _values = _context.SupplierMaster.FirstOrDefault(a => a.SupId == supplierRequest.SupId && a.SupDeletedBy == null);
            if (_values == null)
            {
                _context.SupplierMaster.Add(supplierRequest);
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
        public async Task<Response> Update(SDM.TModels.SupplierMaster supplierRequest)
        {
            var _values = _context.SupplierMaster.FirstOrDefault(a => a.SupId == supplierRequest.SupId && a.SupDeletedBy == null);
            if (_values != null)
            {
                _values.SupCode = supplierRequest.SupCode;
                _values.SupCompanyName = supplierRequest.SupCompanyName;
                _values.SupAddress = supplierRequest.SupAddress;
                _values.SupContactPerson = supplierRequest.SupContactPerson;
                _values.SupLandline = supplierRequest.SupLandline;
                _values.SupContactMobile = supplierRequest.SupContactMobile;
                _values.SupEmail = supplierRequest.SupEmail;
                _values.SupDetails = supplierRequest.SupDetails;
                _values.SupVatNumb = supplierRequest.SupVatNumb;
                _values.SupOthers1 = supplierRequest.SupOthers1;
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
        public async Task<Response> Delete(SDM.TModels.SupplierMaster supplierRequest)
        {
            var _values = _context.SupplierMaster.FirstOrDefault(a => a.SupId == supplierRequest.SupId && a.SupDeletedBy == null);
            if (_values != null)
            {
                _values.SupDeletedBy = 1;
                _values.SupDeletedDate = System.DateTime.Now;
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
        public Response Get(SDM.TModels.SupplierMaster supplierRequest)
        {
            var _values = new List<SDM.TModels.SupplierMaster>();
            if (supplierRequest.SupId != 0)
                _values = _context.SupplierMaster.Where(a => a.SupId == supplierRequest.SupId && a.SupDeletedBy == null).ToList();
            else
                _values = _context.SupplierMaster.Where(a => a.SupDeletedBy == null).ToList();
            if (_values != null)
            {
                _response.SupplierResponse = _values;
                _response.Message = _toaster.Success;
                _response.CustomerMasterResponse = _context.CustomerMaster.Where(a => a.CustDeletedBy == null).ToList();

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
