using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewFichesMetiers.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewFichesMetiers.Controllers
{
    public class HomeController : Controller
    {
        private fichesmetiersDbContext db = new fichesmetiersDbContext();

        // Ecoles qui sont dans la fiche id
        private IEnumerable<ecole> GetEcoles(int id)
        {
            return (from fe in db.fiche_ecole
                    join e in db.ecole on fe.ecoleID equals e.id
                    where fe.ficheID == id
                    select e);
        }
        // Catégories qui sont dans la fiche id
        private IEnumerable<categorie> GetCategories(int id)
        {
            return (from fc in db.fiche_categorie
                    join c in db.categorie on fc.categorieID equals c.id
                    where fc.ficheID == id
                    select c);
        }
        
        //
        // GET: /Gestion/
        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(1000);
            var ficheVM = from f in db.fiche
                            select new ficheView
                            {
                                nom = f.nom
                                , texte = f.texte
                                , id = f.id
                                , publier = f.publier
                                , ecoles = (from fe in db.fiche_ecole
                                            join e in db.ecole on fe.ecoleID equals e.id
                                            where fe.ficheID == f.id
                                            select e)

 
                               , categories = (from fc in db.fiche_categorie
                                                join c in db.categorie on fc.categorieID equals c.id
                                                where fc.ficheID == f.id
                                                select c)
                            };
            return View(ficheVM);
            //return View(db.fiche.ToList()); // Toutes les fiches dans db.fiche
            //return View(fiche.ToList()); // Résultat de la variable fiche
        }

        //
        // GET: /Gestion/Details/5
        public ActionResult Modifier(int id = 0)
        {
            fiche fiche = db.fiche.Find(id);
            if (fiche == null)
            {
                return HttpNotFound();
            }

            @ViewData["fiche"] = id;
            @ViewData["publier"] = fiche.publier;
            var ecoles = GetEcoles(id).ToList();
            var categories = GetCategories(id).ToList();

            ficheView ficheVM = new ficheView
            {
                id = id
                , nom = fiche.nom
                , texte = fiche.texte
                , ecoles = ecoles
                , categories = categories
            };
            return View(ficheVM);
        }


        // GET: /Gestion/Details/5
        public ActionResult Details(int id = 0)
        {
            fiche fiche = db.fiche.Find(id);
            if (fiche == null)
            {
                return HttpNotFound();
            }
            return View(fiche);
        }

        //
        // GET: /Gestion/Create
        public ActionResult Create()
        {
            return View();
        }


        public int GetLastInsertedId()
        {
            return (from x in db.fiche
                    select x).OrderByDescending(x => x.id).First().id;
        }
        //
        // POST: /Gestion/Create
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(fiche fiche)
        {
            if (ModelState.IsValid)
            {
                db.fiche.Add(fiche);
                db.SaveChanges();
                return RedirectToAction("Modifier", "Home", new { id = this.GetLastInsertedId() });
                //return RedirectToAction("Index");
            }

            return View(fiche);
        }

        //
        // GET: /Gestion/Edit/5
        public ActionResult Edit(int id = 0)
        {
            fiche fiche = db.fiche.Find(id);
            if (fiche == null)
            {
                return HttpNotFound();
            }
            return View(fiche);
        }

        //
        // POST: /Gestion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(fiche fiche)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiche).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiche);
        }

        //
        // GET: /Gestion/Delete/5
        public ActionResult Delete(int id = 0)
        {
            fiche fiche = db.fiche.Find(id);
            if (fiche == null)
            {
                return HttpNotFound();
            }
            return View(fiche);
        }

        //
        // POST: /Gestion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fiche fiche = db.fiche.Find(id);
            db.fiche.Remove(fiche);
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
