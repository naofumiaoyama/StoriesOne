using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "Stories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Stories_GenreId",
                table: "Stories",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Genres_GenreId",
                table: "Stories",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Genres_GenreId",
                table: "Stories");

            migrationBuilder.DropIndex(
                name: "IX_Stories_GenreId",
                table: "Stories");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "Stories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
