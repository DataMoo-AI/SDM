using Microsoft.AspNetCore.Mvc;
using SDM.Common.Request;
using SDM.TModels;
using SDMClient.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace SDMClient.Controllers
{
    public class Employee_Master : Controller
    {
        public readonly APICALL Api;
        private readonly IHostingEnvironment env;
        public Employee_Master(APICALL _Api, IHostingEnvironment _env)
        {
            Api = _Api;
            env = _env;
        }

        HttpClient client = new HttpClient();
        string dataString = "";
        public IActionResult Index()
        {
            return View();
        }
        public string BindGrid(EmployeeMasterRequest e)
        {
            string Result = Api.PostApi("EmployeeMaster/GetEmployee", e);
            return Result;
        }
        public string Add(EmployeeMasterRequest e)
        {
            string Result = Api.PostApi("EmployeeMaster/Add", e);
            return Result;
        }
        public string Update(EmployeeMasterRequest e)
        {
            string Result = Api.PostApi("EmployeeMaster/Update", e);
            return Result;
        }
        public string Delete(EmployeeMasterRequest e)
        {
            string Result = Api.PostApi("EmployeeMaster/Delete", e);
            return Result;
        }
        public string BindCostCenter(CostCenterMaster e)
        {
            string Result = Api.PostApi("CostCenterMaster/GetCostCenter", e);
            return Result;
        }
        public async Task<IActionResult> FileUpload(IFormFile formFile)
        {
            try
            {
                // To get the physical path of the upload file in wwwroot
                string _imgname = "";

                var now = DateTime.Now.ToString();
                _imgname = Guid.NewGuid().ToString();
                _imgname += DateTime.Now.ToString("yyyyMMddHHmmss") + formFile.FileName;
                var filePath = Path.Combine(env.WebRootPath, "UploadFiles/Employee/", _imgname);
                using var stream = new FileStream(filePath, FileMode.Create);

                // To copy the file to the target stream
                await formFile.CopyToAsync(stream);
                string FileNames = "/UploadFiles/Employee//" + _imgname;
                return Json(new { status = "success", fileName = FileNames, fileSize = formFile.Length });
            }
            catch (Exception ex)
            {
                return Json(new { status = "error " + ex.Message });
            }

        }
    }
} 
