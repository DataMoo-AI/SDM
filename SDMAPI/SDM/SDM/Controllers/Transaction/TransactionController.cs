using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.Common.Response;
using SDM.Interfaces;
using SDM.TModels;
using System;
using System.Threading.Tasks;

namespace SDM.Controllers.Transaction
{
    [Route("api/Transaction")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _iTransaction;
        public TransactionController(ITransactionRepository iTransaction)
        {
            _iTransaction = iTransaction;
        }
        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] TransactionRequest transactionEntry)
        {
            try
            {
                var response = await _iTransaction.Add(transactionEntry);
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
        public async Task<ActionResult> Update([FromBody] TransactionRequest transactionEntry)
        {
            try
            {
                var response = await _iTransaction.Update(transactionEntry);
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
        public async Task<ActionResult> Delete([FromBody] TransactionEntry transactionEntry)
        {
            try
            {
                var response = await _iTransaction.Delete(transactionEntry);
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
        public ActionResult Get([FromBody] TransactionEntry transactionEntry)
        {
            try
            {
                var response = _iTransaction.Get(transactionEntry);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetAccountForTransaction")]
        [HttpPost]
        public ActionResult GetAccountForTransaction([FromBody] TransactionEntry transactionEntry)
        {
            try
            {
                var response = _iTransaction.GetAccountForTransaction(transactionEntry);
                if (response.Message.ToLower() == "success") { return Ok(response); }
                else { return BadRequest(response); }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("GetCardNumber")]
        [HttpPost]
        public ActionResult GetCardNumber([FromBody] TransactionEntry transactionEntry)
        {
            try
            {
                var response = _iTransaction.GetCardNumber(transactionEntry);
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
