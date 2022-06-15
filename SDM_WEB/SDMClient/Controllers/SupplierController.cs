using Microsoft.AspNetCore.Mvc;
using SDMClient.Models;


namespace SDMClient.Controllers
{
    public class SupplierController : Controller
    {
        public readonly APICALL Api;
        public SupplierController(APICALL _Api)
        {
          Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(SDM.TModels.SupplierMaster e)
        {
            string Result = Api.PostApi("SupplierMaster/Get", e);
            return Result;
        }
        public string Add(SDM.TModels.SupplierMaster e)
        {
            string Result = Api.PostApi("SupplierMaster/Add", e);
            return Result;
        }
        public string Update(SDM.TModels.SupplierMaster e)
        {
            string Result = Api.PostApi("SupplierMaster/Update", e);
            return Result;
        }
        public string Delete(SDM.TModels.SupplierMaster e)
        {
            string Result = Api.PostApi("SupplierMaster/Delete", e);
            return Result;
        }
    }
}
