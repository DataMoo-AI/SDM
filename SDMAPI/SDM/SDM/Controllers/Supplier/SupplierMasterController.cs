using Microsoft.AspNetCore.Mvc;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.Supplier
{
    [Route("api/SupplierMaster")]
    [ApiController]
    public class SupplierMasterController : ControllerBase
    {
         private readonly ISupplier _iSupplier;
        public SupplierMasterController(ISupplier iSupplier)
        {
            _iSupplier = iSupplier;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> Add(SDM.TModels.SupplierMaster supplierRequest)
        {
            try
            {
                var response = await _iSupplier.Add(supplierRequest);
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
        public async Task<ActionResult> Update(SDM.TModels.SupplierMaster supplierRequest)
        {
            try
            {
                var response = await _iSupplier.Update(supplierRequest);
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
        public async Task<ActionResult> Delete(SDM.TModels.SupplierMaster supplierRequest)
        {
            try
            {
                var response = await _iSupplier.Delete(supplierRequest);
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
        public ActionResult Get(SDM.TModels.SupplierMaster supplierRequest)
        {
            try
            {
                var response = _iSupplier.Get(supplierRequest);
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
