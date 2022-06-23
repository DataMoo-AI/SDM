using Microsoft.AspNetCore.Mvc;

namespace SDMClient.Controllers
{
    public class ViewMaster : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
