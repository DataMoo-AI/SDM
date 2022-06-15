using Microsoft.AspNetCore.Mvc;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.SubAccount
{
    [Route("api/SubAccountMaster")]
    [ApiController]
    public class SubAccountController : Controller
    {
        private readonly ISubAccountRepository _iSubAccountRepository;
        public SubAccountController(ISubAccountRepository iSubAccountRepository)
        {
            _iSubAccountRepository = iSubAccountRepository;
        }
        [Route("AddSubAccountMaster")]
        [HttpPost]
        public async Task<ActionResult> Add(SubAccountMaster subAccountMasterRequest)
        {
            try
            {
                var response = await _iSubAccountRepository.AddSubAccount(subAccountMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("UpdateSubAccountMaster")]
        [HttpPost]
        public async Task<ActionResult> Update(SubAccountMaster subAccountMasterRequest)
        {
            try
            {
                var response = await _iSubAccountRepository.UpdateSubAccount(subAccountMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("DeleteSubAccountMaster")]
        [HttpPost]
        public async Task<ActionResult> Delete(SubAccountMaster subAccountMasterRequest)
        {
            try
            {
                var response = await _iSubAccountRepository.DeleteSubAccount(subAccountMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetSubAccountMaster")]
        [HttpPost]
        public ActionResult Get(SubAccountMaster subAccountMasterRequest)
        {
            try
            {
                var response = _iSubAccountRepository.GetSubAccount(subAccountMasterRequest);
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
