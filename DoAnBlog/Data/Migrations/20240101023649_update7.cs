using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChild",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "CoutChild",
                table: "Comments",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoutChild",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "IsChild",
                table: "Comments",
                type: "bit",
                nullable: true,
                defaultValue: false);
        }
    }
}
