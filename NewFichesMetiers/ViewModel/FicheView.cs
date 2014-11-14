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
    public class ficheView
    {
        // Vient de db.fiche
        public int id { get; set; }
        public string nom { get; set; }
        public string texte { get; set; }
        public bool publier { get; set; }
        // Vient de db.categorie
        public IEnumerable<categorie> categories { get; set; }
        // Vient de db.ecole
        public IEnumerable<ecole> ecoles { get; set; }
        public ficheView()
        {
            ecoles = new List<ecole>();
            categories = new List<categorie>();
        }
    }
}