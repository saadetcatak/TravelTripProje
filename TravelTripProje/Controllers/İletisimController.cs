using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class İletisimController : Controller
    {
        Context c = new Context();
        // GET: İletisim
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(İletisim p)
        {
            c.iletisims.Add(p);
            c.SaveChanges();
            return View("Index", "Default");

        }
        public ActionResult İletisims()
        {
            var values = c.iletisims.ToList();
            return View(values);
        }

        public ActionResult MesajSil(int id)
        {
            var values = c.iletisims.Find(id);
            c.iletisims.Remove(values);
            c.SaveChanges();
            return RedirectToAction("İletisims");
        }
    }
}