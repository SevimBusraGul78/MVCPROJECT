using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index(string p)
        {
            var degerler = from d in db.TblMüsteriler select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MusteriAd.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TblMüsteriler.ToList();
            //return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TblMüsteriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TblMüsteriler.Add(p1);
            db.SaveChanges();

            // Kayıttan sonra müşteri listesine yönlendiriyoruz:
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var müsteri = db.TblMüsteriler.Find(id);
            db.TblMüsteriler.Remove(müsteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TblMüsteriler.Find(id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(TblMüsteriler p1)
        {
            var musteri = db.TblMüsteriler.Find(p1.MusteriId);
            musteri.MusteriAd = p1.MusteriAd;
            musteri.MusteriSoyad = p1.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}