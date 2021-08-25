using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Thougts",
                table: "Stories",
                newName: "Thoughts");

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId",
                table: "Stories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Genres_GenreId",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Stories_GenreId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "Thoughts",
                table: "Stories",
                newName: "Thougts");
        }
    }
}
