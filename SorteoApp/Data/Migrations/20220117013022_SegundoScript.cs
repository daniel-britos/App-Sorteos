using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SorteoApp.Data.Migrations
{
    public partial class SegundoScript : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Confirmar",
                table: "Participantes",
                newName: "Legal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Legal",
                table: "Participantes",
                newName: "Confirmar");
        }
    }
}
