using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Pictures_ProfilePictureId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_ProfilePictureId",
                table: "People");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfilePictureId",
                table: "People",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ProfilePictureId",
                table: "People",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_People_ProfilePictureId",
                table: "People",
                column: "ProfilePictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Pictures_ProfilePictureId",
                table: "People",
                column: "ProfilePictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
