using Microsoft.AspNetCore.Mvc;
using SDM.Interfaces;
using SDM.TModels;
using SDM.Repository.CostCenter;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.CostCenter
{
    [Route("api/CostCenterMaster")]
    [ApiController]
    public class CostCenterController : Controller
    {
        private ICostCenterRepository _iCostCenterRepository;
        public CostCenterController(ICostCenterRepository iCostCenterRepository)
        {
            _iCostCenterRepository = iCostCenterRepository;
        }
        [Route("AddCostCenter")]
        [HttpPost]
        public async Task<ActionResult> Add(CostCenterMaster costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.AddCostCenter(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("UpdateCostCenter")]
        [HttpPost]
        public async Task<ActionResult> Update(CostCenterMaster costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.UpdateCostCenter(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("DeleteCostCenter")]
        [HttpPost]
        public async Task<ActionResult> Delete(CostCenterMaster costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.DeleteCostCenter(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetCostCenter")]
        [HttpPost]
        public async Task<ActionResult> Get(CostCenterMaster costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.GetCostCenter(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("AddExpense")]
        [HttpPost]
        public async Task<ActionResult> AddExpense(ExpenseCategory costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.AddExpense(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("UpdateExpense")]
        [HttpPost]
        public async Task<ActionResult> UExpense(ExpenseCategory costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.UpdateExpense(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("DeleteExpense")]
        [HttpPost]
        public async Task<ActionResult> DeleteExpense(ExpenseCategory costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.DeleteExpense(costCenter);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetExpense")]
        [HttpPost]
        public async Task<ActionResult> GetExpense(ExpenseCategory costCenter)
        {
            try
            {
                var response = await _iCostCenterRepository.GetExpense(costCenter);
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
