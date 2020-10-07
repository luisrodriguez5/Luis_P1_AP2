using Microsoft.EntityFrameworkCore;
using Luis_P1_AP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luis_P1_AP2.Data
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data source = Data\\Registro.db");

        }
        public DbSet<Producto> producto {get;set;}
    }
}