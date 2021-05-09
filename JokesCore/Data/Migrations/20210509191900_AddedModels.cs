using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesCore.Data.Migrations
{
    public partial class AddedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                schema: "JokesCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JokeCategorie",
                schema: "JokesCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JokeId = table.Column<int>(nullable: false),
                    CategorieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JokeCategorie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JokeCategorie_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalSchema: "JokesCore",
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JokeCategorie_Joke_JokeId",
                        column: x => x.JokeId,
                        principalSchema: "JokesCore",
                        principalTable: "Joke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JokeCategorie_CategorieId",
                schema: "JokesCore",
                table: "JokeCategorie",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_JokeCategorie_JokeId",
                schema: "JokesCore",
                table: "JokeCategorie",
                column: "JokeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JokeCategorie",
                schema: "JokesCore");

            migrationBuilder.DropTable(
                name: "Categorie",
                schema: "JokesCore");
        }
    }
}
