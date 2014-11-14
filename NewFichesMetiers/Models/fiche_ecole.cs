using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewFichesMetiers.Models
{
    public class fiche_ecole
    {
        public int id { get; set; }
        public int ficheID { get; set; }
        public int ecoleID { get; set; }

        public virtual fiche fiche { get; set; }
        public virtual ecole ecole { get; set; }
        public virtual ICollection<fiche_ecole_formation> fiche_ecole_formation { get; set; }
    }
}