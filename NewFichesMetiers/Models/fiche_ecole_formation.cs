using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class fiche_ecole_formation
    {
        public int id { get; set; }
        public int fiche_ecoleID { get; set; }
        public int formationID { get; set; }

        public virtual fiche_ecole fiche_ecole { get; set; }
        public virtual formation formation { get; set; }
    }
}