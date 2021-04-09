using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginMVCIdentity.Data.Migrations
{
    public partial class UmPraUmFichaDadoClinico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FichaId",
                table: "Fichas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FichaId",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
