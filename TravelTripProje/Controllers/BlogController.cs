using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum b = new BlogYorum();
        public ActionResult Index()
        {
            //var bloglar =c.Blogs.ToList();
            b.Deger1=c.Blogs.ToList();
            /*b.Deger3=c.Blogs.Take(3).ToList()*/;
            b.Deger3 = c.Blogs.OrderByDescending(x => x.BlogID).Take(3).ToList();

            return View(b);
        }

        BlogYorum by = new BlogYorum();
        public ActionResult BlogDetay(int id)
        {
            //var blogbul=c.Blogs.Where(x=>x.BlogID==id).ToList();
            by.Deger1=c.Blogs.Where(x=>x.BlogID==id).ToList();
            by.Deger2=c.Yorumlars.Where(x=>x.BlogID==id).ToList() ;
            return View(by);
        }
    }
}