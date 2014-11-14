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
    public class PartialViewController : Controller
    {
        fichesmetiersDbContext db = new fichesmetiersDbContext();

        /****************************************************************************/
        /***************************  GetView   *************************************/
        /***************** Vue partielle pour la DropDownList ***********************/
        /*********** des ecoles "rajoutables" (ie qui ne sont pas déjà présents) ****/
        /************************ sur une fiche donnée  *****************************/
        /****************************************************************************/
        /****  PARAMETRES : ***/
        /*** IN : idFiche : id de la fiche ***********************/
        /*** OUT : Appel de la vue partielle "_Partiel.cshtml" ***/
        public ActionResult GetView(int idFiche)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<ecole> ec2 = (from e in db.ecole
                                          where !(from fe in db.fiche_ecole
                                                  join e1 in db.ecole on fe.ecoleID equals e1.id
                                                  where fe.ficheID == idFiche
                                                  select e1.id).Contains(e.id)
                                          select e).ToList();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var t in ec2)
                {
                    SelectListItem s = new SelectListItem();
                    s.Text = t.nom.ToString();
                    s.Value = t.id.ToString();
                    items.Add(s);
                }
                ViewBag.ListeEcole = items;
                if (items.Count() == 0)
                    return Content("<span style='color:red'>Plus d'école à ajouter</span>");
            }
            return PartialView("~/Views/Shared/_Partiel.cshtml");
        }

        /****************************************************************************/
        /***************************  GetViewCat   *************************************/
        /***************** Vue partielle pour la DropDownList ***********************/
        /*********** des catégorie "rajoutables" (ie qui ne sont pas déjà présents) ****/
        /************************ sur une fiche donnée  *****************************/
        /****************************************************************************/
        /****  PARAMETRES : ***/
        /*** IN : idFiche : id de la fiche ***********************/
        /*** OUT : Appel de la vue partielle "_PartielCat.cshtml" ***/
        public ActionResult GetViewCat(int idFiche)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<categorie> ec2 = (from c in db.categorie
                                          where !(from fe in db.fiche_categorie
                                                  join e1 in db.categorie on fe.categorieID equals e1.id
                                                  where fe.ficheID == idFiche
                                                  select e1.id).Contains(c.id)
                                          select c).ToList();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach (var t in ec2)
                {
                    SelectListItem s = new SelectListItem();
                    s.Text = t.nom.ToString();
                    s.Value = t.id.ToString();
                    items.Add(s);
                }
                ViewBag.ListeCategorie = items;
                if (items.Count() == 0)
                    return Content("<span style='color:red'>Plus de catégorie à ajouter</span>");
            }
            return PartialView("~/Views/Shared/_PartielCat.cshtml");
        }


    }
}
