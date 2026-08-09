using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_2_3101.Migrations
{
    /// <inheritdoc />
    public partial class AddNotesToClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Clients",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Clients");
        }
    }
}
