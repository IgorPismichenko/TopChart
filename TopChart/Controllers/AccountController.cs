using Microsoft.AspNetCore.Mvc;

namespace TopChart.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
