﻿using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.Common.Response;
using SDM.Interfaces;
using System;
using System.Threading.Tasks;
namespace SDM.Controllers.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _iReport;
        public ReportController(IReport iReport)
        {
            _iReport = iReport;
        }
        [Route("GetReport")]
        [HttpPost]
        public async Task<ActionResult> GetReport(ReportRequest g)
        {
            try
            {
                Response response1 = await _iReport.GetReport(g);
                if (response1.Message.ToLower() == "success") { return Ok(response1); }
                else { return BadRequest(response1); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
