using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnect.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_Members_AuthorId1",
                table: "Bulletins");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Bulletins");

            migrationBuilder.RenameColumn(
                name: "AuthorId1",
                table: "Bulletins",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Bulletins_AuthorId1",
                table: "Bulletins",
                newName: "IX_Bulletins_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_Members_MemberId",
                table: "Bulletins",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bulletins_Members_MemberId",
                table: "Bulletins");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Bulletins",
                newName: "AuthorId1");

            migrationBuilder.RenameIndex(
                name: "IX_Bulletins_MemberId",
                table: "Bulletins",
                newName: "IX_Bulletins_AuthorId1");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Bulletins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Bulletins_Members_AuthorId1",
                table: "Bulletins",
                column: "AuthorId1",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
