using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRestaurant.Models.Entity;

namespace MvcRestaurant.Controllers
{
    public class SiparisController : Controller
    {
        // GET: Siparis
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
            prs.ad = p.ad;
            prs.kisisayisi = p.kisisayisi;
            prs.mailadresi = p.mailadresi;
            prs.masano = p.masano;
            prs.personeladi = p.personeladi;
            prs.rezervasyontarihi = p.rezervasyontarihi;
            prs.sefdurum = p.sefdurum;
            prs.telefon = p.telefon;
            prs.Yemeksecimi = p.Yemeksecimi;
            prs.İstekler = p.İstekler;
            prs.garsondurum = p.garsondurum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}