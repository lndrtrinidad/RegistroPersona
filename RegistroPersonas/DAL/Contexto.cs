using Microsoft.EntityFrameworkCore;
using RegistroPersonas.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroPersonas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = RegistroPersonasDb.db");
        }
    }
}
