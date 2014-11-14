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
    public class AjaxController : Controller
    {
        fichesmetiersDbContext db = new fichesmetiersDbContext();
        string retour = "";

        /************************************************************/
        /***************** SaveFicheEcoleAjax ***********************/
        /******* Ajoute dans la table fiche_ecole l'école ***********/
        /***************** pour une fiche donnée  *******************/
        /************************************************************/
        /****  APPELE PAR JS : addEcoleFiche() ***/
        /****  PARAMETRES : ***/
        /*** IN : param0 : id de la fiche ************/
        /*** IN : param1 : id de l'école *************/
        /*** OUT : Renvoie le contenu de "retour" ****/
        [HttpPost]
        public ActionResult SaveFicheEcoleAjax(int param0, int param1)
        {
            retour = "";
            int ifiche = Convert.ToInt32(param0);
            int iecole = Convert.ToInt32(param1);
            if (ModelState.IsValid)
            {
                fiche ficheExiste = db.fiche.SingleOrDefault(e => e.id == ifiche);
                if (ficheExiste != null)
                {
                    fiche_ecole myFicheEcole = new fiche_ecole()
                    {
                        ficheID = ifiche
                        , ecoleID = iecole
                    };
                    db.fiche_ecole.Add(myFicheEcole);
                    db.SaveChanges();
                }
            }
            return Content(retour);
        }

        /*********************************************************************/
        /***************** SaveFicheCategorieAjax ****************************/
        /******* Ajoute dans la table fiche_categorie la catégorie ***********/
        /***************** pour une fiche donnée  ****************************/
        /*********************************************************************/
        /****  APPELE PAR JS : addCategorieFiche() ***/
        /****  PARAMETRES : ***/
        /*** IN : param0 : id de la fiche ************/
        /*** IN : param1 : id de l'école *************/
        /*** OUT : Renvoie le contenu de "retour" ****/
        [HttpPost]
        public ActionResult SaveFicheCategorieAjax(int param0, int param1)
        {
            retour = "";
            int ifiche = Convert.ToInt32(param0);
            int iecole = Convert.ToInt32(param1);
            if (ModelState.IsValid)
            {
                fiche ficheExiste = db.fiche.SingleOrDefault(e => e.id == ifiche);
                if (ficheExiste != null)
                {
                    fiche_categorie myFicheCat = new fiche_categorie()
                    {
                        ficheID = ifiche
                        , categorieID = iecole
                    };
                    db.fiche_categorie.Add(myFicheCat);
                    db.SaveChanges();
                }
            }
            return Content(retour);
        }

        /************************************************************/
        /******************** SaveFicheAjax *************************/
        /******* Ajoute ou Met à jour dans la table fiche ***********/
        /******** les propriétés pour une fiche donnée  *************/
        /************************************************************/
        /****  APPELE PAR JS : savefiche() ***/
        /****  PARAMETRES : ***/
        /*** IN : param0 : publier ************/
        /*** IN : param1 : id fiche     ************/
        /*** IN : param2 : nom     ************/
        /*** IN : param3 : texte   ************/
        /*** OUT : Renvoie le contenu de "retour" ****/
        [HttpPost]
        public ActionResult SaveFicheAjax(Boolean param0
                                      , int param1
                                      , string param2
                                      , string param3
                                    )
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(param1);
                fiche ficheExiste = db.fiche.SingleOrDefault(e => e.id == id);
                if (ficheExiste != null)
                {
                    // Fiche existante
                    ficheExiste.publier = param0;
                    ficheExiste.nom = param2;
                    ficheExiste.texte = param3;
                    db.SaveChanges();
                    retour = "Update";
                }
            }
            return Content(retour);
        }

        /**********************************************************/
        /****************** SupprimerEcoleFicheAjax ***************/
        /************ Supprime dans la table fiche_ecole **********/
        /*************  l'école pour une fiche donnée  ************/
        /**********************************************************/
        /****  APPELE PAR JS : supprimerEcoleFiche() ***/
        /****  PARAMETRES : ***/
        /*** IN : param0 : id fiche ************/
        /*** IN : param1 : id ecole ************/
        /*** OUT : Renvoie le contenu de "retour" ****/
        [HttpPost]
        public ActionResult SupprimerEcoleFicheAjax(int param0, int param1)
        {
            string retour = param0.ToString() + " " + param1.ToString();
            if (ModelState.IsValid)
            {
                fiche_ecole fe1 = (fiche_ecole)(from fe in db.fiche_ecole
                                                where fe.ficheID == param0 && fe.ecoleID == param1
                                                select fe).First();

                if (fe1 == null)
                {
                    retour = "0";
                    return HttpNotFound();
                }
                else
                {
                    db.fiche_ecole.Remove(fe1);
                    db.SaveChanges();
                    retour = fe1.id.ToString();
                }
            }
            return Content(retour);
        }

        /**********************************************************/
        /****************** SupprimerCatFicheAjax *****************/
        /************ Supprime dans la table fiche_categorie ******/
        /*************  la catégorie pour une fiche donnée  *******/
        /**********************************************************/
        /****  APPELE PAR JS : supprimerCatFiche() ***/
        /****  PARAMETRES : ***/
        /*** IN : param0 : id fiche ************/
        /*** IN : param1 : id ecole ************/
        /*** OUT : Renvoie le contenu de "retour" ****/
        [HttpPost]
        public ActionResult SupprimerCatFicheAjax(int param0, int param1)
        {
            string retour = param0.ToString() + " " + param1.ToString();
            if (ModelState.IsValid)
            {
                fiche_categorie fc1 = (fiche_categorie)(from fc in db.fiche_categorie
                                                        where fc.ficheID == param0 && fc.categorieID == param1
                                                        select fc).First();
                if (fc1 == null)
                {
                    retour = "0";
                    return HttpNotFound();
                }
                else
                {
                    db.fiche_categorie.Remove(fc1);
                    db.SaveChanges();
                    retour = fc1.id.ToString();
                }
            }
            return Content(retour);
        }
    
    
    }
}