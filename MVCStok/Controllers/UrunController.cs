using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using System.Data.Entity;


namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index()
        {
            // Include ile kategori tablosunu da yüklüyoruz
            var degerler = db.TblUrunler.Include(u => u.TblKategori).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAD,
                                                 Value = i.KategoryuİD.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TblUrunler p1)
        {
            var ktg = db.TblKategori.Where(m => m.KategoryuİD == p1.TblKategori.KategoryuİD).FirstOrDefault();
            p1.TblKategori = ktg;
            db.TblUrunler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.TblUrunler.Find(id);
            db.TblUrunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TblUrunler.Find(id);
            {
                List<SelectListItem> degerler = (from i in db.TblKategori.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.KategoriAD,
                                                     Value = i.KategoryuİD.ToString()
                                                 }).ToList();
                ViewBag.dgr = degerler;

                return View("UrunGetir", urun);

            } }
            public ActionResult Guncelle(TblUrunler p)
        {
            var urun=db.TblUrunler.Find(p.ürünId);  
            urun.urunad=p.urunad;
            urun.MARKA = p.MARKA;
            urun.stoık = p.stoık;
            urun.fiyat= p.fiyat;
            //urun.urunkategori=p.urunkategori;
            var ktg = db.TblKategori.Where(m => m.KategoryuİD == p.TblKategori.KategoryuİD).FirstOrDefault();
            urun.urunkategori = ktg.KategoryuİD;
            db.SaveChanges();   
            return RedirectToAction("Index");
        
        }
    }
}