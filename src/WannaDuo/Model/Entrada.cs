using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WannaDuo.Model
{
   
    public class Entrada 
    {
        public int id { get; set; }
        [Display(ResourceType = typeof(Traducciones),
         Name = "soy")]
        [Required]
        public long player { get; set; }
        [Display(ResourceType = typeof(Traducciones),
        Name = "horas")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
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
