using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATAA.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatRoomUsers_UserProfile_UserID1",
                table: "chatRoomUsers");

            migrationBuilder.DropIndex(
                name: "IX_chatRoomUsers_UserID1",
                table: "chatRoomUsers");

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "chatRoomUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID1",
                table: "chatRoomUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_chatRoomUsers_UserID1",
                table: "chatRoomUsers",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_chatRoomUsers_UserProfile_UserID1",
                table: "chatRoomUsers",
                column: "UserID1",
                principalTable: "UserProfile",
                principalColumn: "ID");
        }
    }
}
