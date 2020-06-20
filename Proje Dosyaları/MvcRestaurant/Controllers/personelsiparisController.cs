using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;
using System.Web.Security;

namespace MvcRestaurant.Controllers
{
    public class personelsiparisController : Controller
    {
        // GET: personelsiparis
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLRezervasyon.ToList();
            return View(degerler);
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
        public ActionResult SiparisiGetir(int id)
        {
            var prs = db.TBLRezervasyon.Find(id);
            return View("SiparisiGetir", prs);
        }
        public ActionResult SiparisiGuncelle(TBLRezervasyon p)
        {
            var prs = db.TBLRezervasyon.Find(p.ID);        
            prs.garsondurum = p.garsondurum;
            prs.kar = p.kar;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}