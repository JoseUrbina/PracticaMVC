using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PracticaEFNET.Models
{
    public class PracticaDBContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Direccion> Direccion { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Propiedad de datetime configurar como datetime2
            modelBuilder.Properties<DateTime>().Configure(x  => x.HasColumnType("datetime2"));

            // Propiedad que inicie con codigo configurar como llave primaria siempre
            modelBuilder.Properties<int>().Where(x => x.Name.StartsWith("Codigo"))
                    .Configure(p => p.IsKey());

            base.OnModelCreating(modelBuilder);
        }

    }
}