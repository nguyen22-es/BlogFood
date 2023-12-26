using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DATAA.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_chatRooms_UserProfile_UserID",
                table: "chatRooms");

            migrationBuilder.DropIndex(
                name: "IX_chatRooms_Admin",
                table: "chatRooms");

            migrationBuilder.DropIndex(
                name: "IX_chatRooms_UserID",
                table: "chatRooms");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "chatRooms");

            migrationBuilder.CreateIndex(
                name: "IX_chatRooms_Admin",
                table: "chatRooms",
                column: "Admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_chatRooms_Admin",
                table: "chatRooms");

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "chatRooms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_chatRooms_Admin",
                table: "chatRooms",
                column: "Admin",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chatRooms_UserID",
                table: "chatRooms",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_chatRooms_UserProfile_UserID",
                table: "chatRooms",
                column: "UserID",
                principalTable: "UserProfile",
                principalColumn: "ID");
        }
    }
}
