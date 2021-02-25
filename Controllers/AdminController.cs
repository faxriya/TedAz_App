using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TedAz;
using TedAz.Data.Models;
using TedAzApp.DataContext.Models;

namespace TedAzApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        TedAzContext _context;
        IWebHostEnvironment _appEnvironment;

        public AdminController(TedAzContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult IndexMentions()
        {
            return View(_context.FileMentions.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddFileMentions(IFormFile uploadedFile)
        {
            if(CheckFile(uploadedFile))
            {
                string now = DateTime.Now.ToString(new CultureInfo("ru-RU")).Replace(":", ".");
                string path = "/Files/Mentions/" + now + " - " + uploadedFile.FileName;
                using(var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileMentions file = new FileMentions { Name = uploadedFile.FileName, Path = path };
                _context.FileMentions.Add(file);
                _context.SaveChanges();
                Program.ProccessFiles(_appEnvironment.WebRootPath + "\\Files\\Mentions");
            }

            return RedirectToAction("IndexMentions");
        }

        public IActionResult IndexUsers()
        {
            return View(_context.FileUsers.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddFileUsers(IFormFile uploadedFile)
        {
            string path; string now = DateTime.Now.ToString(new CultureInfo("ru-RU")).Replace(":", ".");

            if (CheckFile(uploadedFile))
            {
                path = "/Files/Users/" + now + " - " + uploadedFile.FileName;
                var filePath = _appEnvironment.WebRootPath + path;
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileUsers file = new FileUsers { Name = uploadedFile.FileName, Path = path };
                _context.FileUsers.Add(file);
                _context.SaveChanges();

                return RedirectToAction("UsersCreate", "UserRole", new { filePath = filePath });
            }

            return RedirectToAction("IndexUsers");
        }

        private bool CheckFile(IFormFile uploadedFile)
        {
            if(uploadedFile == null)
                return false;

            var extensionIndex = uploadedFile.FileName.LastIndexOf(".");
            var extension = uploadedFile.FileName.Substring(extensionIndex + 1);
            return extension == "xlsx";
        }
    }
}
