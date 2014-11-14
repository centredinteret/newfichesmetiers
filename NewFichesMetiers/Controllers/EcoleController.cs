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
    public class EcoleController : Controller
    {
        private fichesmetiersDbContext db = new fichesmetiersDbContext();

        //
        // GET: /Ecole/

        public ActionResult Index()
        {
            return View(db.ecole.ToList());
        }

        //
        // GET: /Ecole/Details/5

        public ActionResult Details(int id = 0)
        {
            ecole ecole = db.ecole.Find(id);
            if (ecole == null)
            {
                return HttpNotFound();
            }
            return View(ecole);
        }

        //
        // GET: /Ecole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Ecole/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ecole ecole)
        {
            if (ModelState.IsValid)
            {
                db.ecole.Add(ecole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ecole);
        }

        //
        // GET: /Ecole/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ecole ecole = db.ecole.Find(id);
            if (ecole == null)
            {
                return HttpNotFound();
            }
            return View(ecole);
        }

        //
        // POST: /Ecole/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ecole ecole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ecole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ecole);
        }

        //
        // GET: /Ecole/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ecole ecole = db.ecole.Find(id);
            if (ecole == null)
            {
                return HttpNotFound();
            }
            return View(ecole);
        }

        //
        // POST: /Ecole/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ecole ecole = db.ecole.Find(id);
            db.ecole.Remove(ecole);
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