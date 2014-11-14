using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class categorie
    {
        public int id { get; set; }
        public string nom { get; set; }

        public virtual ICollection<fiche_categorie> fiche_categorie { get; set; }
    }
}