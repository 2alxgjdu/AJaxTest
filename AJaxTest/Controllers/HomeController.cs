using AJaxTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AJaxTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult First()
        {
            return View();
        }
        public IActionResult AutoComplete()
        {
            return View();
        }
        public IActionResult HomeWork()
        {
            return View();
        }
        public IActionResult HomeWorkday2()
        {
            return View();
        }
        public IActionResult FirstGet()
        {
            return View();
        }
        public IActionResult Address()
        {
            return View();
        }
        public IActionResult AjaxEvent()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Promise()
        {
            return View();
        }
        public IActionResult Fetch()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult History()
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
