using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class ecole
    {
        public int id { get; set; }
        public string nom { get; set; }

        public virtual ICollection<fiche_ecole> fiche_ecole { get; set; }
    }
}