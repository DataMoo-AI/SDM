using SDM.Common.Request;
using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDM.Repository.CustomerMaster
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SDMContext _context;
        private readonly Response _response;
        private readonly ToasterMessages _toaster;
        public CustomerRepository(SDMContext context, Response response, ToasterMessages toaster)
        {
            _context = context;
            _response = response;
            _toaster = toaster;
        }
        public async Task<Response> AddCustomerMaster(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var customer = _context.CustomerMaster.FirstOrDefault(a => a.CustEmail == customerMasterRequest.CustEmail && a.CustDeletedBy == null);
                if (customer == null)
                {
                    SDM.TModels.CustomerMaster customerMaster = new SDM.TModels.CustomerMaster();
                    customerMaster.CustAddress = customerMasterRequest.CustAddress ;
                    customerMaster.CustContact = customerMasterRequest.CustContact ;
                    customerMaster.CustOthers1 = customerMasterRequest.CustOthers1 ;
                    customerMaster.CustContactMobile = customerMasterRequest.CustContactMobile ;
                    customerMaster.CustFax = customerMasterRequest.CustFax ;
                    customerMaster.CustName = customerMasterRequest.CustName ;
                    customerMaster.CustPhone = customerMasterRequest.CustPhone ;
                    customerMaster.CustEmail = customerMasterRequest.CustEmail ;
                    customerMaster.CustLandLine = customerMasterRequest.CustLandLine ;
                    customerMaster.CustTrnOrVatNo = customerMasterRequest.CustTrnOrVatNo ;
                    _context.CustomerMaster.Add(customerMaster);
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
                _response.Message = "Failed";
                return _response;
            }
        }
        public async Task<Response> UpdateCustomerMaster(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var customer = _context.CustomerMaster.FirstOrDefault(a => a.CustId == customerMasterRequest.CustId && a.CustDeletedBy == null);
                if (customer != null)
                {
                    customer.CustAddress = customerMasterRequest.CustAddress ;
                    customer.CustContact = customerMasterRequest.CustContact ;
                    customer.CustOthers1 = customerMasterRequest.CustOthers1 ;
                    customer.CustContactMobile = customerMasterRequest.CustContactMobile ;
                    customer.CustFax = customerMasterRequest.CustFax ;
                    customer.CustName = customerMasterRequest.CustName ;
                    customer.CustPhone = customerMasterRequest.CustPhone ;
                    customer.CustEmail = customerMasterRequest.CustEmail ;
                    customer.CustLandLine = customerMasterRequest.CustLandLine ;
                    customer.CustTrnOrVatNo = customerMasterRequest.CustTrnOrVatNo ;
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
                _response.Message = "Failed";
                return _response;
            }
        }
        public async Task<Response> DeleteCustomereMaster(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var customer = _context.CustomerMaster.FirstOrDefault(a => a.CustId == customerMasterRequest.CustId && a.CustDeletedBy == null);
                if (customer != null)
                {
                    customer.CustDeletedBy = 1;
                    customer.CustDeletedDate = DateTime.Now;
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
                _response.Message = "Failed";
                return _response;
            }
        }
        public async Task<Response> GetCustomereMaster(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                List<TModels.CustomerMaster> customer = new List<TModels.CustomerMaster>();
                if(customerMasterRequest.CustId != null && customerMasterRequest.CustId == 0)
                    customer = _context.CustomerMaster.Where(a => a.CustDeletedBy == null).ToList();
                else
                    customer = _context.CustomerMaster.Where(a => a.CustId == customerMasterRequest.CustId && a.CustDeletedBy == null).ToList();

                if (customer != null)
                {
                   var customerMaster = (from a in customer orderby -a.CustId
                                         select a).OrderByDescending(a => a.CustId).ToList();
                    _response.CustomerMasterResponse = customerMaster;
                    _response.Message = _toaster.Success;
                    return _response;
                }
                else
                {
                    _response.Message = _toaster.AlreadyExists;
                    return _response;
                }
            }
            catch(Exception ex)
            {
                _response.Message = ex.InnerException.ToString() +" ## "+ ex.Message;
                return _response;
            }
        }
    }
}
