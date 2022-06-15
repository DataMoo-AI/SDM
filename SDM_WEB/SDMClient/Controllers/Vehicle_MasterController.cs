using Microsoft.AspNetCore.Mvc;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class Vehicle_MasterController : Controller
    {
        public readonly APICALL Api;
        public Vehicle_MasterController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(VehicleMaster e)
        {
            string Result = Api.PostApi("VehicleMaster/Get", e);
            return Result;
        }
        public string Add(VehicleMaster e)
        {
            string Result = Api.PostApi("VehicleMaster/Add", e);
            return Result;
        }
        public string Update(VehicleMaster e)
        {
            string Result = Api.PostApi("VehicleMaster/Update", e);
            return Result;
        }
        public string Delete(VehicleMaster e)
        {
            string Result = Api.PostApi("VehicleMaster/Delete", e);
            return Result;
        }
    }
}
