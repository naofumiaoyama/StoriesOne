using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Genres_GenreId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_GenreId",
                table: "Stories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stories_GenreId",
                table: "Stories",
                column: "GenreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Genres_GenreId",
                table: "Stories",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
