using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
     
        Context c=new Context();
        public ActionResult Login() 
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Login (Admin admin) 
        { 
            var values=c.Admins.FirstOrDefault(x=>x.Kullanici==admin.Kullanici && x.Sifre==admin.Sifre);
            if (values!=null) 
            {
                FormsAuthentication.SetAuthCookie(values.Kullanici, false);
                Session["Kullanici"]=values.Kullanici.ToString();
                return RedirectToAction("Index","Admin");
            }
            else
            {
                return View(); 
            }

        }

        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login","GirisYap");
        }
    }
}