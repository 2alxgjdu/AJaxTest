using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJaxTest.Controllers
{
    public class AJAXTESTController : Controller
    {
        public IActionResult Index()
        {

            return Content("Ajax 別搞  拜託","text/html",System.Text.Encoding.UTF8);
        }
    }
}
