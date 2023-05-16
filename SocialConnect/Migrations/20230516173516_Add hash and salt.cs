using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnect.Migrations
{
    /// <inheritdoc />
    public partial class Addhashandsalt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Members",
                newName: "PasswordSaltBase64");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHashBase64",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHashBase64",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "PasswordSaltBase64",
                table: "Members",
                newName: "Password");
        }
    }
}
