using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TopChart.Models;
using TopChart.Repositories;

namespace TopChart.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryTracks repo;

        public HomeController(IRepositoryTracks r)
        {
            repo = r;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repo.GetTracksList();
            return View(model);
        }
    }
}
