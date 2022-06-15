using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.Customer
{
   
    [Route("api/CustomereMaster")]
    [ApiController] 
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _iCustomerRepository;
        public CustomerController(ICustomerRepository iCustomerRepository)
        {
            _iCustomerRepository = iCustomerRepository;
        }
        [Route("AddCustomereMaster")]
        [HttpPost]
        public async Task<ActionResult> Add(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var response = await _iCustomerRepository.AddCustomerMaster(customerMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("UpdateCustomereMaster")]
        [HttpPost]
        public async Task<ActionResult> Update(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var response = await _iCustomerRepository.UpdateCustomerMaster(customerMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("DeleteCustomereMaster")]
        [HttpPost]
        public async Task<ActionResult> Delete(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var response = await _iCustomerRepository.DeleteCustomereMaster(customerMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetCustomereMaster")]
        [HttpPost]
        public async Task<ActionResult> Get(CustomerMasterRequest customerMasterRequest)
        {
            try
            {
                var response = await _iCustomerRepository.GetCustomereMaster(customerMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
