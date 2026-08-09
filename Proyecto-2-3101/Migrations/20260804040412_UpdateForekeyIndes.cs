using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_2_3101.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForekeyIndes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedBy",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_ModifiedBy",
                table: "Clients");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedBy",
                table: "Clients",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_ModifiedBy",
                table: "Clients",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedBy",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_ModifiedBy",
                table: "Clients");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CreatedBy",
                table: "Clients",
                column: "CreatedBy",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_ModifiedBy",
                table: "Clients",
                column: "ModifiedBy",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
