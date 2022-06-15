using Microsoft.AspNetCore.Mvc;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class Cost_Center_MasterController : Controller
    {
        public readonly APICALL Api;
        public Cost_Center_MasterController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(CostCenterMaster e)
        {
            string Result = Api.PostApi("CostCenterMaster/GetCostCenter", e);
            return Result;
        }
        public string Add(CostCenterMaster e)
        {
            string Result = Api.PostApi("CostCenterMaster/AddCostCenter", e);
            return Result;
        }
        public string Update(CostCenterMaster e)
        {
            string Result = Api.PostApi("CostCenterMaster/UpdateCostCenter", e);
            return Result;
        }
        public string Delete(CostCenterMaster e)
        {
            string Result = Api.PostApi("CostCenterMaster/DeleteCostCenter", e);
            return Result;
        }
    }
}
