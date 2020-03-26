using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractiveData.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InteractiveAmplifiers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    Power = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractiveAmplifiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InteractiveElements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InteractiveAmplifierId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Panel = table.Column<string>(nullable: true),
                    MeshName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractiveElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractiveElements_InteractiveAmplifiers_InteractiveAmplifierId",
                        column: x => x.InteractiveAmplifierId,
                        principalTable: "InteractiveAmplifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InteractiveElements_InteractiveAmplifierId",
                table: "InteractiveElements",
                column: "InteractiveAmplifierId");
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
