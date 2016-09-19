using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WannaDuo.Migrations
{
    public partial class idiomayserver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idioma",
                table: "Entrada",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "server",
                table: "Entrada",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idioma",
                table: "Entrada");

            migrationBuilder.DropColumn(
                name: "server",
                table: "Entrada");
        }
    }
}
