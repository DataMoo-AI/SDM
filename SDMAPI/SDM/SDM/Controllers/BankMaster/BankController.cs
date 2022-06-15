using Microsoft.AspNetCore.Mvc;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.BankMaster
{
    [Route("api/BankMaster")]
    [ApiController]
    public class BankController : Controller
    {
        private readonly IBankMaster _iCostCenterRepository;
        public BankController(IBankMaster iCostCenterRepository)
        {
            _iCostCenterRepository = iCostCenterRepository;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> Add(BankMasterEntry costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.Add(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult> Update(BankMasterEntry costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.Update(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("Delete")]
        [HttpPost]
        public async Task<ActionResult> Delete(BankMasterEntry costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.Delete(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("Get")]
        [HttpPost]
        public ActionResult Get(BankMasterEntry costCenter)
        {
            try
            {
                var response = _iCostCenterRepository.Get(costCenter);
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
