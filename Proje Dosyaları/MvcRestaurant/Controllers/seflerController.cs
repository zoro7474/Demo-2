using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;
using System.Web.Security;
namespace MvcRestaurant.Controllers
{
    public class seflerController : Controller
    {
        // GET: sefler
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var deger = db.TBLSEF.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult SefEkle()
        {
            return View();
        }
        public ActionResult SefEkle(TBLSEF p)
        {
            db.TBLSEF.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult SefSil(int id)
        {
            var sef = db.TBLSEF.Find(id);
            db.TBLSEF.Remove(sef);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SefGetir(int id)
        {
            var sf = db.TBLSEF.Find(id);
            return View("SefGetir", sf);
        }
        public ActionResult SefGüncelle(TBLSEF p )
        {
            var sf = db.TBLSEF.Find(p.ID);
            sf.AD = p.AD;
            sf.SOYAD = p.SOYAD;
            sf.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}