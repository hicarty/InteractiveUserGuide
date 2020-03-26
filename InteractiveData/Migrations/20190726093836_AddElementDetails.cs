using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveData.Migrations
{
    public partial class AddElementDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Panel",
                table: "InteractiveElements",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "MeshName",
                table: "InteractiveElements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteractiveElements");

            migrationBuilder.DropTable(
                name: "InteractiveAmplifiers");
        }
    }
}
