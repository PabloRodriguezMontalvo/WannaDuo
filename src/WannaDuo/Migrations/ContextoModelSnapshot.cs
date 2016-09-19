using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WannaDuo.Model;

namespace WannaDuo.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WannaDuo.Model.Entrada", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("hora_fin");

                    b.Property<int>("idioma");

                    b.Property<string>("notas");

                    b.Property<int>("personaje_preferido");

                    b.Property<long>("player");

                    b.Property<int>("posicion");

                    b.Property<int>("server");

                    b.Property<int>("tipo_partida");

                    b.HasKey("id");

                    b.ToTable("Entrada");
                });
        }
    }
}
