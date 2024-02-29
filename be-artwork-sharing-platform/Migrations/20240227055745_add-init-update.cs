using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_artwork_sharing_platform.Migrations
{
    /// <inheritdoc />
    public partial class addinitupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User_Name",
                table: "artworks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User_Name",
                table: "artworks");
        }
    }
}
