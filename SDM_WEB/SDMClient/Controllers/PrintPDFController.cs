using Microsoft.AspNetCore.Mvc;
using Rotativa.NetCore;
using SDM.TModels;
using SDMClient.Models;
using SDM.Common.Response;
using SDM.Interfaces;
using Newtonsoft.Json;
using SDM.Common.Request;

namespace SDMClient.Controllers
{
    public class PrintPDFController : Controller
    {
        public readonly APICALL Api;
        public PrintPDFController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EmployeePDF(int ID)
        {
            EmployeeMaster e = new EmployeeMaster();
            e.EmpId = ID;
            string Result = Api.PostApi("EmployeeMaster/GetEmployee", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("EmployeePDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }
        public IActionResult VehiclePDF(int ID)
        {
            VehicleMaster e = new VehicleMaster();
            e.VhId = ID;
            string Result = Api.PostApi("VehicleMaster/Get", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("VehiclePDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }
        public IActionResult CostCenterPDF(int ID)
        {
            CostCenterMaster e = new CostCenterMaster();
            e.CsId = ID;
            string Result = Api.PostApi("CostCenterMaster/GetCostCenter", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page."; 
            return new ViewAsPdf("CostCenterPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };         
        }
        public IActionResult SubAccountPDF(int ID)
        {
            SubAccountMaster e = new SubAccountMaster();
            e.PrpId = ID;
            string Result = Api.PostApi("SubAccountMaster/GetSubAccountMaster", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("SubAccountPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }
        public IActionResult SupplierPDF(int ID)
        {
            SupplierMaster e = new SupplierMaster();
            e.SupId = ID;
            string Result = Api.PostApi("SupplierMaster/Get", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("SupplierPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }

        public IActionResult ExpensesPDF(int ID)
        {
            ExpenseCategory e = new ExpenseCategory();
            e.TrnId = ID;
            string Result = Api.PostApi("CostCenterMaster/GetExpense", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("ExpensesPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }
        public IActionResult BankPDF(int ID)
        {
            BankMasterEntry e = new BankMasterEntry();
            e.BnkId = ID;
            string Result = Api.PostApi("BankMaster/Get", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("BankPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }
        public IActionResult InsurancePDF(int ID)
        {
            InsuranceMaster e = new InsuranceMaster();
            e.InsId = ID;
            string Result = Api.PostApi("Insurance/Get", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("InsurancePDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }

        public IActionResult TransactionPDF(int ID)
        {
            TransactionEntry e = new TransactionEntry();
            e.TrnId = ID;
            string Result = Api.PostApi("Transaction/Get", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("TransactionPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }
        public IActionResult ParameterPDF(int ID)
        {
            CustomerMasterRequest e = new CustomerMasterRequest();
            e.CustId = ID;
            string Result = Api.PostApi("CustomereMaster/GetCustomereMaster", e);
            Response _response = JsonConvert.DeserializeObject<Response>(Result);
            ViewData["Print"] = _response;
            HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("ParameterPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
            };
        }



        //CostCenterMaster e = new CostCenterMaster();
        //e.CsId = ID;
        //string Result = Api.PostApi("CostCenterMaster/GetCostCenter", e);
        //Response _response = JsonConvert.DeserializeObject<Response>(Result);
        //TempData["_response"] = _response.CostCenterResponse;
        //HttpContext.Session.SetString("_response", JsonConvert.SerializeObject(_response));
        //var report = new ViewAsPdf("CostCenterPDF")
        //{
        //    PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
        //    CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
        //};
        ////var demoViewPortrait = new ViewAsPdf("CostCenterPDF")
        ////{
        ////    FileName = "Invoice.pdf",
        ////    PageMargins = { Left = 20, Bottom = 20, Right = 20, Top = 20 },
        ////    CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
        ////};
        //return report;
    }
}
