using Microsoft.AspNetCore.Mvc;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class Sub_Account_MasterController : Controller
    {
        public readonly APICALL Api;
        public Sub_Account_MasterController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(SubAccountMaster e)
        {
            string Result = Api.PostApi("SubAccountMaster/GetSubAccountMaster", e);
            return Result;
        }
        public string BindGridForTransactionEntry(SubAccountMaster e)
        {
            string Result = Api.PostApi("Transaction/GetAccountForTransaction", e);
            return Result;
        }
        public string Add(SubAccountMaster e)
        {
            string Result = Api.PostApi("SubAccountMaster/AddSubAccountMaster", e);
            return Result;
        }
        public string Update(SubAccountMaster e)
        {
            string Result = Api.PostApi("SubAccountMaster/UpdateSubAccountMaster", e);
            return Result;
        }
        public string Delete(SubAccountMaster e)
        {
            string Result = Api.PostApi("SubAccountMaster/DeleteSubAccountMaster", e);
            return Result;
        }
    }
}
