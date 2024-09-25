using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviewsDL.Migrations
{
    /// <inheritdoc />
    public partial class image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "Films",
                newName: "CoverImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImagePath",
                table: "Films",
                newName: "CoverImageUrl");
        }
    }
}
