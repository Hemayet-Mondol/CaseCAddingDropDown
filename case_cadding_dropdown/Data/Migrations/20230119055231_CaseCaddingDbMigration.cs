using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace case_cadding_dropdown.Data.Migrations
{
    public partial class CaseCaddingDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StateTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StateTable_CountryTable_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CityTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTable_StateTable_StateId",
                        column: x => x.StateId,
                        principalTable: "StateTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTable_StateId",
                table: "CityTable",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_StateTable_CountryId",
                table: "StateTable",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTable");

            migrationBuilder.DropTable(
                name: "StateTable");

            migrationBuilder.DropTable(
                name: "CountryTable");
        }
    }
}
