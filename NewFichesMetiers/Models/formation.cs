using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class formation
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string lien { get; set; }

        public virtual ICollection<fiche_ecole_formation> fiche_ecole_formation { get; set; }
    }
}