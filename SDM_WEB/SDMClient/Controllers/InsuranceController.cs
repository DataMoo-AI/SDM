using Microsoft.AspNetCore.Mvc;
using SDM.Common.Response;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class InsuranceController : Controller
    {
        public readonly APICALL Api;
        public InsuranceController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(InsuranceReq e)
        {
            string Result = Api.PostApi("Insurance/Get", e);
            return Result;
        }
        public string Add(InsuranceReq e)
        {
            string Result = Api.PostApi("Insurance/Add", e);
            return Result;
        }
        public string Update(InsuranceReq e)
        {
            string Result = Api.PostApi("Insurance/Update", e);
            return Result;
        }
        public string Delete(InsuranceReq e)
        {
            string Result = Api.PostApi("Insurance/Delete", e);
            return Result;
        }
    }
}
