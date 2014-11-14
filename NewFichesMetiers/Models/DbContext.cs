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
    public class fichesmetiersDbContext : DbContext
    {
        public fichesmetiersDbContext()
            : base("name=fichesmetiers")
        {
        }
        public DbSet<categorie> categorie { get; set; }
        public DbSet<ecole> ecole { get; set; }
        public DbSet<fiche> fiche { get; set; }
        public DbSet<fiche_categorie> fiche_categorie { get; set; }
        public DbSet<fiche_ecole> fiche_ecole { get; set; }
        public DbSet<fiche_ecole_formation> fiche_ecole_formation { get; set; }
        public DbSet<formation> formation { get; set; }
    }

}