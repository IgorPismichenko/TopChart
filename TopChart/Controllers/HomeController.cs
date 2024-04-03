using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using TopChart.Models;
using TopChart.Repositories;

namespace TopChart.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryTracks repo;
        IRepositoryVideo repoV;
        IRepositoryGenres repoGen;
        IRepositorySingers repoSing;

        public HomeController(IRepositoryTracks r, IRepositoryVideo rV, IRepositoryGenres rG, IRepositorySingers rS)
        {
            repo = r;
            repoV = rV;
            repoGen = rG;
            repoSing = rS;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["TopSingers"] = await repo.GetSortedTracksList();
            var model = await repo.GetTracksList();
            return View(model);
        }
        public async Task<IActionResult> IndexVideo()
        {
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["TopSingers"] = await repo.GetSortedTracksList();
            var model = await repoV.GetVideoList();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["TopSingers"] = await repo.GetSortedTracksList();
            var tracks = repo.GetSearchList(search);
            if (tracks.Count() == 0)
            {
                return View("Index", tracks);
            }
            return View("Index", tracks);
        }

        [HttpPost]
        public async Task<IActionResult> SearchVideo(string search)
        {
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["TopSingers"] = await repo.GetSortedTracksList();
            var clips = repoV.GetSearchList(search);
            if (clips.Count() == 0)
            {
                return View("IndexVideo", clips);
            }
            return View("IndexVideo", clips);
        }

        public async Task<IActionResult> Top()
        {
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["TopSingers"] = await repo.GetSortedTracksList();
            var model = await repo.GetSortedTracksList();
            return View("Index", model);
        }

        public async Task<IActionResult> TopVideo()
        {
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["TopSingers"] = await repo.GetSortedTracksList();
            var model = await repoV.GetSortedTracksList();
            return View("IndexVideo", model);
        }
    }
}
