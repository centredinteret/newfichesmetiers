using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NewFichesMetiers.Models
{
    public class ficheViewBis
    {
        public IEnumerable<fiche> fiches { get; set; }
        public IEnumerable<fiche_ecole> fiches_ecoles { get; set; }
        public IEnumerable<ecole> ecoles { get; set; }
    }
}