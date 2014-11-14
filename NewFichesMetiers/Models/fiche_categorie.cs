using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class fiche_categorie
    {
        public int id { get; set; }
        public int ficheID { get; set; }
        public int categorieID { get; set; }

        public virtual fiche fiche { get; set; }
        public virtual categorie categorie { get; set; }
    }
}