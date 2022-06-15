using Microsoft.AspNetCore.Mvc;
using SDM.TModels;
using SDMClient.Models;

namespace SDMClient.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        public readonly APICALL Api;
        public ExpenseCategoryController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(ExpenseCategory e)
        {
            string Result = Api.PostApi("CostCenterMaster/GetExpense", e);
            return Result;
        }
        public string Add(ExpenseCategory e)
        {
            string Result = Api.PostApi("CostCenterMaster/AddExpense", e);
            return Result;
        }
        public string Update(ExpenseCategory e)
        {
            string Result = Api.PostApi("CostCenterMaster/UpdateExpense", e);
            return Result;
        }
        public string Delete(ExpenseCategory e)
        {
            string Result = Api.PostApi("CostCenterMaster/DeleteExpense", e);
            return Result;
        }
    }
}
