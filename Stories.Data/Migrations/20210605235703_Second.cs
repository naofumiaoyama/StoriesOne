using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Pictures_UserIconURLId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_UserIconURLId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "UserIconURLId",
                table: "People");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "Pictures",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PersonId",
                table: "Pictures",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_People_PersonId",
                table: "Pictures",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_People_PersonId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_PersonId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Pictures");

            migrationBuilder.AddColumn<Guid>(
                name: "UserIconURLId",
                table: "People",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_UserIconURLId",
                table: "People",
                column: "UserIconURLId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Pictures_UserIconURLId",
                table: "People",
                column: "UserIconURLId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
