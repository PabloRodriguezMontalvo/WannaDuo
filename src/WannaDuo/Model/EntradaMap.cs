using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WannaDuo.Model
{
    public class EntradaMap
    {
        public EntradaMap(EntityTypeBuilder<Entrada> entityBuilder)
        {
            entityBuilder.HasKey(t => t.id);
            entityBuilder.Property(t => t.hora_fin).IsRequired();
            entityBuilder.Property(t => t.idioma).IsRequired();
            entityBuilder.Property(t => t.personaje_preferido).IsRequired();
            entityBuilder.Property(t => t.player).IsRequired();
            entityBuilder.Property(t => t.posicion).IsRequired();
            entityBuilder.Property(t => t.server).IsRequired();
            entityBuilder.Property(t => t.tipo_partida).IsRequired();
        }
    }
}
