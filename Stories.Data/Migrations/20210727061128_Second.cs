using Microsoft.EntityFrameworkCore.Migrations;

namespace Stories.Data.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "PersonalInfos",
                newName: "EncryptedPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EncryptedPassword",
                table: "PersonalInfos",
                newName: "Password");
        }
    }
}
