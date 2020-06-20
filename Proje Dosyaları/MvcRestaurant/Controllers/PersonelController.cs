using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;
using System.Web.Security;

namespace MvcRestaurant.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBRESTAURANTEntities db = new DBRESTAURANTEntities();
        public ActionResult Index()
        {
            var deger1 = db.TBLPERSONEL.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.TBLUYELER.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.TBLYEMEK.Count();
            ViewBag.dgr3 = deger3;
            var deger4 = db.TBLRezervasyon.Count();
            ViewBag.dgr4 = deger4;
            var deger5 = db.TBLSEF.Count();
            ViewBag.dgr5 = deger5;
            var degerler = db.TBLPERSONEL.ToList();
            var deger6 = db.TBLKATAGORI.Count();
            ViewBag.dgr6 = deger6;
            var deger7 = db.TBLRezervasyon.Where(x => x.sefdurum == "basarili").Count();
            ViewBag.dgr7 = deger7;
            var deger8 = db.TBLRezervasyon.Where(x => x.sefdurum == "basarisiz").Count();
            ViewBag.dgr8 = deger8;
            var deger9 = db.TBLRezervasyon.Sum(x => x.satiss);
            ViewBag.dgr9 = deger9;
            var deger10 = db.TBLRezervasyon.Sum(x => x.kar);
            ViewBag.dgr10 = deger10;
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL p)
        {
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult PersonelSil(int id)
        {
            var person = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersoneliGetir(int id)
        {
            var prs = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBLPERSONEL p)
        {
            var prs = db.TBLPERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            prs.Durum = p.Durum;
            prs.Calisma = p.Calisma;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}