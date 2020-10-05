using Microsoft.EntityFrameworkCore;
using Primer_Parcial_A1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Primer_Parcial_A1.DAL
{
    class Contexto : DbContext
    {
        public DbSet<Ciudad> Ciudad { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data source=Data/Ciudad.bd");
        }

    }
}
