using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace be_artwork_sharing_platform.Migrations
{
    /// <inheritdoc />
    public partial class updateinitinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName_Receivier",
                table: "requestorders",
                newName: "UserId_Receivier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId_Receivier",
                table: "requestorders",
                newName: "UserName_Receivier");
        }
    }
}
