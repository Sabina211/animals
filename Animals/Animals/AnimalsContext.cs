using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    class AnimalsContext : DbContext
    {
        public AnimalsContext() : base("name=AnimalsContext")
        { }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        */
        public virtual DbSet<Mammal> Mammals { get; set; }
        public virtual DbSet<Amphibian> Amphibians { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }
    }
}
