using Microsoft.AspNetCore.Mvc;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.VehicleMaster
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMasterController : ControllerBase
    {
        private readonly IVehicle _ivehicle;
        public VehicleMasterController(IVehicle ivehicle)
        {
            _ivehicle = ivehicle;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> Add(SDM.TModels.VehicleMaster vehicleRequest)
        {
            try
            {
                var response = await _ivehicle.Add(vehicleRequest);
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
        public async Task<ActionResult> Update(SDM.TModels.VehicleMaster vehicleRequest)
        {
            try
            {
                var response = await _ivehicle.Update(vehicleRequest);
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
        public async Task<ActionResult> Delete(SDM.TModels.VehicleMaster vehicleRequest)
        {
            try
            {
                var response = await _ivehicle.Delete(vehicleRequest);
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
        public ActionResult Get(SDM.TModels.VehicleMaster vehicleRequest)
        {
            try
            {
                var response = _ivehicle.Get(vehicleRequest);
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
