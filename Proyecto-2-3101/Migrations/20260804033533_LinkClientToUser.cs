using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_2_3101.Migrations
{
    /// <inheritdoc />
    public partial class LinkClientToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedBy",
                table: "Clients",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModifiedBy",
                table: "Clients",
                column: "ModifiedBy");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CreatedBy",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_ModifiedBy",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedBy",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ModifiedBy",
                table: "Clients");
        }
    }
}
