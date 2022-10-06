using AJaxTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace AJaxTest.Controllers
{
    public class AJAXTESTController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly DemoContext _context;
        private readonly NorthwindContext _northwind;
        public AJAXTESTController(IWebHostEnvironment host,DemoContext context, NorthwindContext northwind)
        {
           
            _context = context;
            _host = host;
            _northwind = northwind;
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
        public IActionResult Register(Member member, IFormFile File1)
        {
            //string info = $" {File1.Name}-{File1.ContentType}-{File1.Length}";
            //string info = _host.WebRootPath;
            //string info = _host.ContentRootPath;
            string filePath = Path.Combine(_host.WebRootPath,"uploads",File1.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File1.CopyTo(fileStream);
            }
            byte[] imgByte = null;
            using (var memoryStream=new MemoryStream())
            {
                File1.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileName = File1.FileName;
            member.FileData = imgByte;
            _context.Members.Add(member);
            _context.SaveChanges();
                return Content(filePath, "text/plain");


        }

        public IActionResult HomeWorkday2(Member member,IFormFile File1)
        {

            Member x = _context.Members.FirstOrDefault(p => p.Name == member.Name);
            if (x ==null)
            {
                return Content("重複了啦!!!!!", "text/plain");

            }
            else
                return Content("姓名並無重複", "text/plain", System.Text.Encoding.UTF8);


        }


        public IActionResult City()
        {
            var cities=_context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }
        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(sites);
        }
        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);
        }
        public IActionResult ptsname(string keyword)
        {
            var name = _northwind.Products.Where(i => i.ProductName.Contains(keyword)).Select(i => i.ProductName);
            return Json(name);
          
        }

    }
}
