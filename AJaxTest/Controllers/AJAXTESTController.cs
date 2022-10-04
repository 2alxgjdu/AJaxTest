using AJaxTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AJaxTest.Controllers
{
    public class AJAXTESTController : Controller
    {
        private readonly DemoContext _context;

        public AJAXTESTController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult Index(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "Ajax";
            }
            return Content($"{keyword}別搞  拜託","text/html",System.Text.Encoding.UTF8);
        }


        public IActionResult wait()
        {

            System.Threading.Thread.Sleep(10000);
            return Content("哈樓你好嗎","text/plain");
        }
        public IActionResult Register(Member member)
        {
   
                return Content(member.Name, "text/plain");


        }
        public IActionResult HomeWorkday2(Member member)
        {

            Member x = _context.Members.FirstOrDefault(p => p.Name == member.Name);
            if (x ==null)
            {
                return Content("重複了啦!!!!!", "text/plain");

            }
            else
                return Content("姓名並無重複", "text/plain", System.Text.Encoding.UTF8);


        }
    }
}
