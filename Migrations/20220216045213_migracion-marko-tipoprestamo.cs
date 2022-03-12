using Microsoft.EntityFrameworkCore.Migrations;

namespace VBNET_Core3_project.Migrations
{
    public partial class migracionmarkotipoprestamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTipoPrestamo",
                table: "prestamos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPrestamoFK",
                table: "prestamos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tipoprestamos",
                columns: table => new
                {
                    IdTipoPrestamo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoprestamos", x => x.IdTipoPrestamo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prestamos_TipoPrestamoFK",
                table: "prestamos",
                column: "TipoPrestamoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_prestamos_tipoprestamos_TipoPrestamoFK",
                table: "prestamos",
                column: "TipoPrestamoFK",
                principalTable: "tipoprestamos",
                principalColumn: "IdTipoPrestamo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_prestamos_tipoprestamos_TipoPrestamoFK",
                table: "prestamos");

            migrationBuilder.DropTable(
                name: "tipoprestamos");

            migrationBuilder.DropIndex(
                name: "IX_prestamos_TipoPrestamoFK",
                table: "prestamos");

            migrationBuilder.DropColumn(
                name: "IdTipoPrestamo",
                table: "prestamos");

            migrationBuilder.DropColumn(
                name: "TipoPrestamoFK",
                table: "prestamos");
        }
    }
}
