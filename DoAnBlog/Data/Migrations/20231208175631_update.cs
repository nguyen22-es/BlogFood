using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostContents_Posts_PostId",
                table: "PostContents");

            migrationBuilder.DropIndex(
                name: "IX_PostContents_PostId",
                table: "PostContents");

            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "PostContents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PostId",
                table: "PostContents",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_PostContents_PostId",
                table: "PostContents",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostContents_Posts_PostId",
                table: "PostContents",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId");
        }
    }
}
