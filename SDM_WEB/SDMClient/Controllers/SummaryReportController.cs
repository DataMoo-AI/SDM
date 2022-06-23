using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SDM.Common.Request;
using SDMClient.Models;
using System.Data;
using System.Reflection;

namespace SDMClient.Controllers
{
    public class SummaryReportController : Controller
    {
        public readonly APICALL Api;
        public SummaryReportController(APICALL _Api)
        {
            Api = _Api;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string getreport(ReportRequest e)
        {
            string Result = Api.PostApi("Report/GetReport", e);
         
            dynamic l = JsonConvert.DeserializeObject<dynamic>(Result);
            List<dynamic> l1= JsonConvert.DeserializeObject<List<dynamic>>(l["reportResponse"].Value);
            DataTable dt = ToDataTable(l1);
            return Result;
        }
        public string Gettransactiontype(ReportRequest e)
        {
            string Result = Api.PostApi("Report/Gettransactiontype", e);  
            return Result;
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
    }
}
