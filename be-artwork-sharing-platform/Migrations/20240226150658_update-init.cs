using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_artwork_sharing_platform.Migrations
{
    /// <inheritdoc />
    public partial class updateinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artworks_categories_CategoryId",
                table: "artworks");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "artworks",
                newName: "Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_artworks_CategoryId",
                table: "artworks",
                newName: "IX_artworks_Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_artworks_categories_Category_Id",
                table: "artworks",
                column: "Category_Id",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_artworks_categories_Category_Id",
                table: "artworks");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "artworks",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_artworks_Category_Id",
                table: "artworks",
                newName: "IX_artworks_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_artworks_categories_CategoryId",
                table: "artworks",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
