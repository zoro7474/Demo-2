using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcRestaurant.Models.Entity;
using System.Web.Security;

namespace MvcRestaurant.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            
            var degerler = db.TBLKATAGORI.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATAGORI p)
        {
            db.TBLKATAGORI.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATAGORI.Find(id);
            db.TBLKATAGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBLKATAGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult Guncelle(TBLKATAGORI p)
        {
            var ktg = db.TBLKATAGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");

        }
    }
}

