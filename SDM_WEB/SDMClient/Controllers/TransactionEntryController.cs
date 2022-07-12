using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class TransactionEntryController : Controller
    {
        public readonly APICALL Api;
        public TransactionEntryController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(TransactionEntry e)
        {
            string Result = Api.PostApi("Transaction/Get", e);
            return Result;
        }
        public string Add(TransactionRequest e)
        {
            string Result = Api.PostApi("Transaction/Add", e);
            return Result;
        }
        public string Update(TransactionRequest e)
        {
            string Result = Api.PostApi("Transaction/Update", e);
            return Result;
        }
        public string Delete(TransactionEntry e)
        {
            string Result = Api.PostApi("Transaction/Delete", e);
            return Result;
        }
        public string GetCardNumber(TransactionEntry e)
        {
            string Result = Api.PostApi("Transaction/GetCardNumber", e);
            return Result;
        }
    }
}
