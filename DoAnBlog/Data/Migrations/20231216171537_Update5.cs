using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodIngredients_Posts_FoodID",
                table: "FoodIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "FoodIngredients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredients_PostID",
                table: "FoodIngredients",
                column: "PostID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodIngredients_Posts_PostID",
                table: "FoodIngredients",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodIngredients_Posts_PostID",
                table: "FoodIngredients");

            migrationBuilder.DropIndex(
                name: "IX_FoodIngredients_PostID",
                table: "FoodIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "PostID",
                table: "FoodIngredients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodIngredients_Posts_FoodID",
                table: "FoodIngredients",
                column: "FoodID",
                principalTable: "Posts",
                principalColumn: "PostId");
        }
    }
}
