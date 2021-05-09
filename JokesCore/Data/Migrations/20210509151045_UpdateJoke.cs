using Microsoft.EntityFrameworkCore.Migrations;

namespace JokesCore.Data.Migrations
{
    public partial class UpdateJoke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Joke",
                schema: "JokesCore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<string>(nullable: true),
                    Bericht = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joke_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "JokesCore",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Joke_AccountId",
                schema: "JokesCore",
                table: "Joke",
                column: "AccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Joke",
                schema: "JokesCore");
        }
    }
}
