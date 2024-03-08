using Microsoft.AspNetCore.Mvc;

namespace TopChart.Controllers
{
    public class HomeVideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
