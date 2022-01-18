using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NEWS_SITE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NEWS_SITE.Controllers
{
    public class HomeController : Controller
    {

        NewsContext db;
        
        public HomeController(NewsContext context)
        {
           db = context;
        }
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            var cats=db.catogeries.ToList();
            
            return View(cats);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Call()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Savecontact(Contactus model )
        {
            
            db.contactus.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Messages()
        {
            var cll = db.contactus.ToList();

            return View(cll);
            
        }

       

        public IActionResult News(int  id )
        {
            Catogery getnamecat = db.catogeries.Find(id);
            var name = getnamecat.Name;
            ViewBag.cname = name;

            var res =db.News.Where(x=>x.catogeryID==id).OrderByDescending(x=>x.Date).ToList();
            
            return View(res);

        }
        public IActionResult DeleteNews(int id)
        {
            var searchid=db.News.Find(id);
            db.News.Remove(searchid);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
