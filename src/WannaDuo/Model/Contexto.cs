using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WannaDuo.Model
{
    public class Contexto:DbContext

    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new EntradaMap(modelBuilder.Entity<Entrada>());
        }
    }
}
