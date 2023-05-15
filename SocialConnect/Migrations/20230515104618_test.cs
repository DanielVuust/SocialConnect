using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialConnect.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Members_AuthorId1",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "UserComments");

            migrationBuilder.RenameColumn(
                name: "AuthorId1",
                table: "UserComments",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_AuthorId1",
                table: "UserComments",
                newName: "IX_UserComments_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Members_MemberId",
                table: "UserComments",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Members_MemberId",
                table: "UserComments");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "UserComments",
                newName: "AuthorId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_MemberId",
                table: "UserComments",
                newName: "IX_UserComments_AuthorId1");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "UserComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Members_AuthorId1",
                table: "UserComments",
                column: "AuthorId1",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
