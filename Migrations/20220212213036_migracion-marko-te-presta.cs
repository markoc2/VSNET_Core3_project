using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VBNET_Core3_project.Migrations
{
    public partial class migracionmarkotepresta : Migration
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

            migrationBuilder.CreateTable(
                name: "prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Plazo = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    CreadoPor = table.Column<string>(nullable: true),
                    EstadoPrestamo = table.Column<string>(nullable: true),
                    PrestamosFK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestamos", x => x.IdPrestamo);
                    table.ForeignKey(
                        name: "FK_prestamos_clientes_PrestamosFK",
                        column: x => x.PrestamosFK,
                        principalTable: "clientes",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pagos",
                columns: table => new
                {
                    IdPago = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrestamo = table.Column<int>(nullable: false),
                    MontoPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(nullable: false),
                    PagosFK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagos", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_pagos_prestamos_PagosFK",
                        column: x => x.PagosFK,
                        principalTable: "prestamos",
                        principalColumn: "IdPrestamo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pagos_PagosFK",
                table: "pagos",
                column: "PagosFK");

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_PrestamosFK",
                table: "prestamos",
                column: "PrestamosFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pagos");

            migrationBuilder.DropTable(
                name: "prestamos");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
