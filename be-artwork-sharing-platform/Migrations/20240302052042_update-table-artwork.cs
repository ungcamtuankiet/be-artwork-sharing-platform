using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_artwork_sharing_platform.Migrations
{
    /// <inheritdoc />
    public partial class updatetableartwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "artworks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Category_Id",
                table: "artworks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
