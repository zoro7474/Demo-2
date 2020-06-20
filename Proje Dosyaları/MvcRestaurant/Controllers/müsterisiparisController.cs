using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;

namespace MvcRestaurant.Controllers
{
    public class müsterisiparisController : Controller
    {
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var rezervasyon = db.TBLRezervasyon.Where(x => x.mailadresi == uyemail.ToString()).ToList();
            return View(rezervasyon);
        }
        [HttpGet]
        public ActionResult Siparisver()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Siparisver(TBLRezervasyon p)
        {
            db.TBLRezervasyon.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Siparisiptal(int id)
        {
            var yemek = db.TBLRezervasyon.Find(id);
            db.TBLRezervasyon.Remove(yemek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}