using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Body",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChapterNumber = table.Column<int>(type: "int", nullable: false),
                    BodyContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Body", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Body_Stories_StoryId",
                        column: x => x.StoryId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Body_StoryId",
                table: "Body",
                column: "StoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Body");
        }
    }
}
