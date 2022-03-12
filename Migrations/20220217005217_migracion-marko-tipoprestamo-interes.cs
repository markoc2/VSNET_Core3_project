using Microsoft.EntityFrameworkCore.Migrations;

namespace VBNET_Core3_project.Migrations
{
    public partial class migracionmarkotipoprestamointeres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Interes",
                table: "tipoprestamos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Interes",
                table: "tipoprestamos");
        }
    }
}
