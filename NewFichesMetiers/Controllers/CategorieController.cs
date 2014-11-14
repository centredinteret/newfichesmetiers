using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewFichesMetiers.Models;

namespace NewFichesMetiers.Controllers
{
    public class CategorieController : Controller
    {
        private fichesmetiersDbContext db = new fichesmetiersDbContext();

        //
        // GET: /Categorie/

        public ActionResult Index()
        {
            return View(db.categorie.ToList());
        }

        //
        // GET: /Categorie/Details/5

        public ActionResult Details(int id = 0)
        {
            categorie categorie = db.categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        //
        // GET: /Categorie/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categorie/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.categorie.Add(categorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categorie);
        }

        //
        // GET: /Categorie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            categorie categorie = db.categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        //
        // POST: /Categorie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        //
        // GET: /Categorie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            categorie categorie = db.categorie.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        //
        // POST: /Categorie/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            // On delete la catégorie
            categorie categorie = db.categorie.Find(id);
            db.categorie.Remove(categorie);
            db.SaveChanges();

            // Mais on delete aussi les fiche_catégorie qui contiennent cette catégorie
            var ficheCat = (from fc in db.fiche_categorie
                            join c in db.categorie on fc.categorieID equals c.id
                            where fc.categorieID == id
                            select fc).ToList();
            foreach (fiche_categorie fc in ficheCat)
            {
                db.fiche_categorie.Remove(fc);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}