using Microsoft.AspNetCore.Mvc;
using SDM.Common.Response;
using SDM.Interfaces;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.InsuranceMaster
{
    [Route("api/Insurance")]
    public class InsuranceMaserController : Controller
    {
        private readonly IInsuranceMaster _iCostCenterRepository;
        public InsuranceMaserController(IInsuranceMaster iCostCenterRepository)
        {
            _iCostCenterRepository = iCostCenterRepository;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] InsuranceReq costCenter)
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
        public async Task<ActionResult> Update([FromBody] InsuranceReq input)
        {
            try
            {
                var response = await _iCostCenterRepository.Update(input);
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
        public async Task<ActionResult> Delete([FromBody] InsuranceReq costCenter)
        {
            try
            {
                SDM.TModels.InsuranceMaster insuranceMaster = new SDM.TModels.InsuranceMaster();
                insuranceMaster.InsId = costCenter.InsId;
                var response = await _iCostCenterRepository.Delete(insuranceMaster);
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
        public async Task<ActionResult> Get([FromBody] InsuranceReq costCenter)
        {
            try
            {
                SDM.TModels.InsuranceMaster insuranceMaster = new SDM.TModels.InsuranceMaster();
                insuranceMaster.InsId = costCenter.InsId;
                var response = await _iCostCenterRepository.Get(insuranceMaster);
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
