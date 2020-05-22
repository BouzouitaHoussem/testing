using Solution.Data.Configurations;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext:DbContext
    {
        public MyContext():base("MaChaine")
        {

        }
        //les dbsets
      
        public DbSet<Livreur> Livreurs { get; set; }
        public DbSet<Reclamation> Reclamations { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //config + conventions

            modelBuilder.Configurations.Add(new LivreurConfiguration());
            modelBuilder.Configurations.Add(new ReclamationConfiguration());

            //modelBuilder.Conventions.Add(...);
        }
    }
}
