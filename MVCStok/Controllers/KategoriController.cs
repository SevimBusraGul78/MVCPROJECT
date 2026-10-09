using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities1 db = new MvcDbStokEntities1();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TblKategori.ToList();
            var degerler = db.TblKategori.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TblKategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TblKategori.Add(p1);
            db.SaveChanges();

            // Yeni kategori eklendikten sonra listeye (Index sayfasına) geri yönlendiriyoruz:
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(kategori);    
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TblKategori.Find(id);
            return View("Guncelle", ktgr);
            
        }

        [HttpPost]
        public ActionResult Guncelle(TblKategori p1)
        {
            var ktg = db.TblKategori.Find(p1.KategoryuİD);

            if (ktg == null)
            {
                return HttpNotFound();
            }

            ktg.KategoriAD = p1.KategoriAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}