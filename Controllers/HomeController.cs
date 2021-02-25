using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using TedAz.Data.Models;
using TedAz.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace TedAz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _appEnvironment;

        private readonly TedAzContext context;
     
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;


        }
       

        public IActionResult Index()
        {
            //Program.ProccessFiles();
            return View();
        
        }

        public IActionResult Gallery()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
 
   
       
        public IActionResult Images()
        {
            return View();
        }
        public IActionResult Compare()
        {
            return View();
        }
  
     
        public IActionResult Authors()
        {
            return View();
        }
        public IActionResult Notifications()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult Links()
        {
            return View();

        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
