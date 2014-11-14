using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class fiche
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string texte { get; set; }
        public bool publier { get; set; }

        public virtual ICollection<fiche_categorie> fiche_categorie { get; set; }
        public virtual ICollection<fiche_ecole> fiche_ecole { get; set; }
    }
}