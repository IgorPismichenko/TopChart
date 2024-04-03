using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using TopChart.Models;
using TopChart.Repositories;

namespace TopChart.Controllers
{
    public class AccountController : Controller
    {
        IRepositoryUsers repo;

        public AccountController(IRepositoryUsers r)
        {
            repo = r;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel logon)
        {
            if (ModelState.IsValid)
            {
                var us = repo.GetUsersList();
                if (us == null)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(logon);
                }
                var users = repo.CheckUser(logon);
                if (users.ToList().Count == 0)
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(logon);
                }
                var user = users.First();
                string? salt = user.Salt;
                byte[] password = Encoding.Unicode.GetBytes(salt + logon.Password);
                byte[] byteHash = SHA256.HashData(password);
                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));
                if (user.Password != hash.ToString())
                {
                    ModelState.AddModelError("", "Wrong login or password!");
                    return View(logon);
                }
                HttpContext.Session.SetString("Login", user.Login);
                HttpContext.Session.SetInt32("Status", user.Status);
                return RedirectToAction("Audio", "HomeAudio");
            }
            return View(logon);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                var result = repo.CheckRegisterUser(reg);
                if (result.ToList().Count > 0)
                {
                    ModelState.AddModelError("", "Such login already exists, try another one!");
                    return View(reg);
                }
                user.Login = reg.Login;
                byte[] saltbuf = new byte[16];
                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(saltbuf);
                StringBuilder sb = new StringBuilder(16);
                for (int i = 0; i < 16; i++)
                    sb.Append(string.Format("{0:X2}", saltbuf[i]));
                string salt = sb.ToString();  
                byte[] password = Encoding.Unicode.GetBytes(salt + reg.Password);
                byte[] byteHash = SHA256.HashData(password);
                StringBuilder hash = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                    hash.Append(string.Format("{0:X2}", byteHash[i]));
                user.Password = hash.ToString();
                user.Salt = salt;
                if (reg.Login == "admin" || reg.Login == "Admin")
                    user.Status = 2;
                else
                    user.Status = 0;
                repo.Create(user);
                return RedirectToAction("Login");
            }
            return View(reg);
        }
    }
}
