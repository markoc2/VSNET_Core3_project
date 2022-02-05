using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VBNET_Core3_project.Migrations
{
    public partial class migracionmarkoteprestacliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(maxLength: 500, nullable: true),
                    Telefono = table.Column<string>(maxLength: 12, nullable: false),
                    Genero = table.Column<int>(nullable: false),
                    Cedula = table.Column<string>(maxLength: 15, nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.IdCliente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
