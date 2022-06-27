using Microsoft.AspNetCore.Mvc;
using Rotativa.NetCore;
using SDM.TModels;
using SDMClient.Models;
using SDM.Common.Response;
using SDM.Interfaces;
using Newtonsoft.Json;
using SDM.Common.Request;
using System.Data;
using System.Reflection;

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
        public IActionResult SummaryReportPDF(ReportRequest e)
        {
            string Result = Api.PostApi("Report/GetReport", e);
            //HttpContext.Session.SetString("_Summaryyear", e.FromDate.ToString("YYYY"));
            dynamic l = JsonConvert.DeserializeObject<dynamic>(Result);
            List<dynamic> l1 = JsonConvert.DeserializeObject<List<dynamic>>(l["reportResponse"].Value);  
            ViewData["Print"] = l1;

            HttpContext.Session.SetString("_Summaryresponse", JsonConvert.SerializeObject(l1));
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(HttpContext.Session.GetString("_Summaryresponse")); ;
             dt = GenerateTransposedTable(dt);
            if (dt.Rows.Count > 0) { 
            string[] columnNames = dt.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();
            string _cname = "";
            for(int i = 0; i < columnNames.Length; i++)
            {
                if (columnNames[i] != "Category")
                {
                    _cname += columnNames[i];
                    if (i != (columnNames.Length-1))
                        _cname += "+";
                }

            }
            }
            //dt.Columns.Add("Total", typeof(Double));
            //dt.Columns["Total"].Expression = _cname;
            HttpContext.Session.SetString("_Summarydatatable", JsonConvert.SerializeObject(dt));
            ViewData["Message"] = "Your application description page.";
            return new ViewAsPdf("SummaryReportPDF", ViewData)
            {
                PageMargins = { Left = 2, Bottom = 2, Right = 2, Top = 2 },
                PageOrientation = Rotativa.NetCore.Options.Orientation.Landscape,
                Password="Hi",
                CustomSwitches = "--page-offset 0 --footer-center [page] --footer-font-size 12",
                
            };
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName.Replace(" ", "_"));
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.Replace(" ", "_").ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
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
