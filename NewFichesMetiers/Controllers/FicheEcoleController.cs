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
    public class FicheEcoleController : Controller
    {
        private fichesmetiersDbContext db = new fichesmetiersDbContext();

        //
        // GET: /FicheEcole/
        public ActionResult Index()
        {
            var fiche_ecole = db.fiche_ecole.Include(f => f.fiche).Include(f => f.ecole);
            return View(fiche_ecole.ToList());
        }

        //
        // GET: /FicheEcole/Details/5
        public ActionResult Details(int id = 0)
        {
            fiche_ecole fiche_ecole = db.fiche_ecole.Find(id);
            if (fiche_ecole == null)
            {
                return HttpNotFound();
            }
            return View(fiche_ecole);
        }

        //
        // GET: /FicheEcole/Create

        public ActionResult Create()
        {
            ViewBag.ficheID = new SelectList(db.fiche, "id", "nom");
            ViewBag.ecoleID = new SelectList(db.ecole, "id", "nom");
            return View();
        }

        //
        // POST: /FicheEcole/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(fiche_ecole fiche_ecole)
        {
            if (ModelState.IsValid)
            {
                db.fiche_ecole.Add(fiche_ecole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ficheID = new SelectList(db.fiche, "id", "nom", fiche_ecole.ficheID);
            ViewBag.ecoleID = new SelectList(db.ecole, "id", "nom", fiche_ecole.ecoleID);
            return View(fiche_ecole);
        }

        //
        // GET: /FicheEcole/Edit/5

        public ActionResult Edit(int id = 0)
        {
            fiche_ecole fiche_ecole = db.fiche_ecole.Find(id);
            if (fiche_ecole == null)
            {
                return HttpNotFound();
            }
            ViewBag.ficheID = new SelectList(db.fiche, "id", "nom", fiche_ecole.ficheID);
            ViewBag.ecoleID = new SelectList(db.ecole, "id", "nom", fiche_ecole.ecoleID);
            return View(fiche_ecole);
        }

        //
        // POST: /FicheEcole/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(fiche_ecole fiche_ecole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiche_ecole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ficheID = new SelectList(db.fiche, "id", "nom", fiche_ecole.ficheID);
            ViewBag.ecoleID = new SelectList(db.ecole, "id", "nom", fiche_ecole.ecoleID);
            return View(fiche_ecole);
        }

        //
        // GET: /FicheEcole/Delete/5

        public ActionResult Delete(int id = 0)
        {
            fiche_ecole fiche_ecole = db.fiche_ecole.Find(id);
            if (fiche_ecole == null)
            {
                return HttpNotFound();
            }
            return View(fiche_ecole);
        }

        //
        // POST: /FicheEcole/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fiche_ecole fiche_ecole = db.fiche_ecole.Find(id);
            db.fiche_ecole.Remove(fiche_ecole);
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