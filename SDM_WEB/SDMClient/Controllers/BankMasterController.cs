using Microsoft.AspNetCore.Mvc;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class BankMasterController : Controller
    {
        public readonly APICALL Api;
        public BankMasterController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(BankMasterEntry e)
        {
            string Result = Api.PostApi("BankMaster/Get", e);
            return Result;
        }
        public string Add(BankMasterEntry e)
        {
            string Result = Api.PostApi("BankMaster/Add", e);
            return Result;
        }
        public string Update(BankMasterEntry e)
        {
            string Result = Api.PostApi("BankMaster/Update", e);
            return Result;
        }
        public string Delete(BankMasterEntry e)
        {
            string Result = Api.PostApi("BankMaster/Delete", e);
            return Result;
        }
    }
}
