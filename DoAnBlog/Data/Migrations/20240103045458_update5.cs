using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodIngredients_Posts_PostID",
                table: "FoodIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodIngredients_Posts_PostID",
                table: "FoodIngredients",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodIngredients_Posts_PostID",
                table: "FoodIngredients");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodIngredients_Posts_PostID",
                table: "FoodIngredients",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostId");
        }
    }
}
