using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.Interfaces;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.EmployeeMaster
{
    [Route("api/EmployeeMaster")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        public EmployeeController(IEmployeeRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> Add(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var response = await _iEmployeeRepository.AddEmployeeMaster(employeeMasterRequest);
                if(response.Message.ToLower() == "success") { return Ok(response); }                   
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult> Update(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var response = await _iEmployeeRepository.UpdateEmployeeMaster(employeeMasterRequest);
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
        public async Task<ActionResult> Delete(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var response = await _iEmployeeRepository.DeleteEmployeeMaster(employeeMasterRequest);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetGender")]
        [HttpGet]
        public ActionResult GetGender()
        {
            try
            {
                var response = _iEmployeeRepository.GenderList();
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetDepartment")]
        [HttpGet]
        public ActionResult GetDepartment()
        {
            try
            {
                var response = _iEmployeeRepository.GetDepartment();
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetDesignation")]
        [HttpGet]
        public ActionResult GetDesignation()
        {
            try
            {
                var response = _iEmployeeRepository.GetDesignation();
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetSalaryPaidMaster")]
        [HttpGet]
        public ActionResult GetSalaryPaidMaster()
        {
            try
            {
                var response = _iEmployeeRepository.GetSalaryPaidMaster();
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetEmployee")]
        [HttpPost]
        public ActionResult GetEmployee(EmployeeMasterRequest employeeMasterRequest)
        {
            try
            {
                var response = _iEmployeeRepository.GetEmployee(employeeMasterRequest);
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
