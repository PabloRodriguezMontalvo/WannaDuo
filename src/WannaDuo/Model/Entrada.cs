using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace WannaDuo.Model
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        { }

        public DbSet<Entrada> Entrada { get; set; }
    
    }
    public class Entrada 
    {
        public int id { get; set; }
        [Display(ResourceType = typeof(Traducciones),
         Name = "soy")]
        public long player { get; set; }
        [Display(ResourceType = typeof(Traducciones),
        Name = "horas")]
        public DateTime hora_fin { get; set; }
        [Display(ResourceType = typeof(Traducciones),
        Name = "prefe")]

        public int personaje_preferido { get; set; }
        [Display(ResourceType = typeof(Traducciones),
        Name = "notas")]
        public string notas { get; set; }
        [Display(ResourceType = typeof(Traducciones),
        Name = "tipo_partida")]
        public int tipo_partida { get; set; }
        [Display(ResourceType = typeof(Traducciones),
   Name = "server")]
        public int server { get; set; }
        [Display(ResourceType = typeof(Traducciones),
Name = "idioma")]
        public int idioma { get; set; }
        [Display(ResourceType = typeof(Traducciones),
Name = "posicion")]
        public int posicion { get; set; }

    }
}
