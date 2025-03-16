using Microsoft.AspNetCore.Mvc;

namespace FreeLancerDirectoryList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
