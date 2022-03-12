using Microsoft.EntityFrameworkCore.Migrations;

namespace VBNET_Core3_project.Migrations
{
    public partial class migracionmarkotipoprestamointdecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Interes",
                table: "tipoprestamos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Interes",
                table: "tipoprestamos",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
