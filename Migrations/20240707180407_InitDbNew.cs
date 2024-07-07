using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeltekMvcWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitDbNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GunlukDersSaati",
                table: "Dersler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GunlukDersSaati",
                table: "Dersler");
        }
    }
}
