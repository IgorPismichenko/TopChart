using Microsoft.AspNetCore.Mvc;

namespace TopChart.Controllers
{
    public class HomeAudioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
