using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class Parameter_MasterController : Controller
    {
        public readonly APICALL Api;
        public Parameter_MasterController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(CustomerMasterRequest e)
        {
            string Result = Api.PostApi("CustomereMaster/GetCustomereMaster", e);
            return Result;
        }
        public string Add(CustomerMasterRequest e)
        {
            string Result = Api.PostApi("CustomereMaster/AddCustomereMaster", e);
            return Result;
        }
        public string Update(CustomerMasterRequest e)
        {
            string Result = Api.PostApi("CustomereMaster/UpdateCustomereMaster", e);
            return Result;
        }
        public string Delete(CustomerMasterRequest e)
        {
            string Result = Api.PostApi("CustomereMaster/DeleteCustomereMaster", e);
            return Result;
        }
    }
}
