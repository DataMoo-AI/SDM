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
            List<dynamic> l1 = JsonConvert.DeserializeObject<List<dynamic>>(l["reportResponse"].Value);
            ViewData["Print"] = l1;

            HttpContext.Session.SetString("_Summaryresponse", JsonConvert.SerializeObject(l1));
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(HttpContext.Session.GetString("_Summaryresponse")); ;
            dt = GenerateTransposedTable(dt);
            DataRow totalsRow = dt.NewRow();
            foreach (DataColumn col in dt.Columns)
            {
                int colTotal = 0;
                foreach (DataRow row in col.Table.Rows)
                {
                    try { colTotal += Int32.Parse(row[col].ToString()); }
                    catch { colTotal += 0; } 
                }
                totalsRow[col.ColumnName] = colTotal;
            }
            totalsRow[0] = "Total";
            DataRow AvgRow = dt.NewRow();
            foreach (DataColumn col in dt.Columns)
            {
                int colTotal = 0;
                int AvgTotal = 0;
                foreach (DataRow row in col.Table.Rows)
                {
                    
                    try { colTotal += Int32.Parse(row[col].ToString());
                        if (row[col].ToString() != "0")
                            AvgTotal += 1;
                    }
                    catch { colTotal += 0; }
                }
                if (AvgTotal != 0)
                    AvgRow[col.ColumnName] = Convert.ToDouble(colTotal/ AvgTotal);
            }
            AvgRow[0] = "Average";
            dt.Rows.Add(AvgRow);
            dt.Rows.Add(totalsRow);
            if (dt.Rows.Count > 0)
            {
                string[] columnNames = dt.Columns.Cast<DataColumn>()
                                     .Select(x => x.ColumnName)
                                     .ToArray();
                string _cname = "";
                for (int i = 0; i < columnNames.Length; i++)
                {
                    if (columnNames[i] != "Category")
                    {
                        _cname += columnNames[i];
                        if (i != (columnNames.Length - 1))
                            _cname += "+";
                    }

                }
            }
            //dt.Columns.Add("Total", typeof(Double));
            //dt.Columns["Total"].Expression = _cname;
            HttpContext.Session.SetString("_Summarydatatable", JsonConvert.SerializeObject(dt));
            return JsonConvert.SerializeObject(dt);
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

    }
}
