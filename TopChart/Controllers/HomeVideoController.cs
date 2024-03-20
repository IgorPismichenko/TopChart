using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopChart.Models;
using TopChart.Repositories;

namespace TopChart.Controllers
{
    public class HomeVideoController : Controller
    {
        IRepositoryVideo repo;
        IRepositoryGenres repoGen;
        IRepositorySingers repoSing;
        IRepositoryUsers repoUsers;
        IRepositoryCommentsVideo repoComm;
        IWebHostEnvironment _appEnvironment;
        public HomeVideoController(IRepositoryVideo v, IRepositoryGenres g, IRepositorySingers s, IRepositoryUsers u, IRepositoryCommentsVideo c, IWebHostEnvironment appEnvironment)
        {
            repo = v;
            repoGen = g;
            repoSing = s;
            repoUsers = u;
            repoComm = c;
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> Video()
        {
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            Users users = new Users();
            ViewData["Users"] = users;
            var model = await repo.GetVideoList();
            return View(model);
        }

        public async Task<IActionResult> AdminVideo()
        {
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            var model = await repo.GetVideoList();
            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["SingerId"] = new SelectList(repoSing.GetValues(), "Id", "Name");
            ViewData["GenreId"] = new SelectList(repoGen.GetValues(), "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SingerId,Album,GenreId,Path")] Video track, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    string path = "/Video/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    track.Path = path;
                    track.Size = uploadedFile.Length.ToString();
                }
                track.Date = DateTime.Today.ToString();
                track.Like = 0;
                await repo.Create(track);
                await repo.Save();
                return RedirectToAction(nameof(Video));
            }
            return View(track);
        }

        public IActionResult CreateGenre()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGenre([Bind("Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                await repoGen.Create(genre);
                await repoGen.Save();
                return RedirectToAction(nameof(AdminVideo));
            }
            return View(genre);
        }

        public IActionResult CreateSinger()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSinger([Bind("Id,Name")] Singer singer, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (uploadedFile != null)
                {
                    string path = "/Posters/" + uploadedFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }
                    singer.Path = path;
                }
                await repoSing.Create(singer);
                await repoSing.Save();
                return RedirectToAction(nameof(Video));
            }
            return View(singer);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> SearchVideo(string search)
        {
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            var clips = repo.GetSearchList(search);
            if (clips.Count() == 0)
            {
                return View("Video", clips);
            }
            return View("Video", clips);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32("Id", (int)id);
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["CommentsVideo"] = await repoComm.GetCommentList();
            ViewData["Users"] = await repoUsers.GetUsersList();
            var clip = repo.GetTrack(id);
            if (clip == null)
            {
                return NotFound();
            }

            return View(clip);
        }

        [HttpPost]
        public async Task<IActionResult> CommentVideo([Bind("Id")] CommentVideo comm, string comment)
        {
            comm.Message = comment;
            comm.Date = DateTime.Today.ToString();
            string? login = HttpContext.Session.GetString("Login");
            var users = await repoUsers.GetUsersList();
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    comm.UserId = user.Id;
                }
            }
            var id = HttpContext.Session.GetInt32("Id");
            var clip = repo.GetTrack(id);
            comm.VideoId = clip.Id;
            await repoComm.Create(comm);
            await repoComm.Save();
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            ViewData["CommentsVideo"] = await repoComm.GetCommentList();
            ViewData["Users"] = await repoUsers.GetUsersList();
            HttpContext.Session.SetInt32("Id", (int)id);
            return View("Details", clip);
        }

        public async Task<IActionResult> LikeVideo(int? id)
        {
            Video track = repo.GetTrack(id);
            track.Like += 1;
            repo.Update(track);
            await repo.Save();
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            Users users = new Users();
            ViewData["Users"] = users;
            var model = await repo.GetVideoList();
            return View("Video", model);
        }

        public async Task<IActionResult> TopVideo()
        {
            ViewData["Singer"] = await repoSing.GetSingersList();
            ViewData["Genre"] = await repoGen.GetGenresList();
            var model = await repo.GetSortedTracksList();
            return View("Video", model);
        }
    }
}
