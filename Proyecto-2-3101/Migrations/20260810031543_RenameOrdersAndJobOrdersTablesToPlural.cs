using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_2_3101.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrdersAndJobOrdersTablesToPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOrderModel_JobTypes_JobTypeId",
                table: "JobOrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOrderModel_OrderModel_OrderId",
                table: "JobOrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Clients_ClientId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Users_CreatedUserId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Users_UpdatedUserId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Vehicles_VehicleId",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOrderModel",
                table: "JobOrderModel");

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "JobOrderModel",
                newName: "JobOrders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_VehicleId",
                table: "Orders",
                newName: "IX_Orders_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_UpdatedUserId",
                table: "Orders",
                newName: "IX_Orders_UpdatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_CreatedUserId",
                table: "Orders",
                newName: "IX_Orders_CreatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_ClientId",
                table: "Orders",
                newName: "IX_Orders_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOrderModel_JobTypeId",
                table: "JobOrders",
                newName: "IX_JobOrders_JobTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOrders",
                table: "JobOrders",
                columns: new[] { "OrderId", "JobTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrders_JobTypes_JobTypeId",
                table: "JobOrders",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "JobTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrders_Orders_OrderId",
                table: "JobOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CreatedUserId",
                table: "Orders",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UpdatedUserId",
                table: "Orders",
                column: "UpdatedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "IdVehicle",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOrders_JobTypes_JobTypeId",
                table: "JobOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOrders_Orders_OrderId",
                table: "JobOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CreatedUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UpdatedUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicles_VehicleId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobOrders",
                table: "JobOrders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderModel");

            migrationBuilder.RenameTable(
                name: "JobOrders",
                newName: "JobOrderModel");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_VehicleId",
                table: "OrderModel",
                newName: "IX_OrderModel_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UpdatedUserId",
                table: "OrderModel",
                newName: "IX_OrderModel_UpdatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CreatedUserId",
                table: "OrderModel",
                newName: "IX_OrderModel_CreatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientId",
                table: "OrderModel",
                newName: "IX_OrderModel_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_JobOrders_JobTypeId",
                table: "JobOrderModel",
                newName: "IX_JobOrderModel_JobTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobOrderModel",
                table: "JobOrderModel",
                columns: new[] { "OrderId", "JobTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrderModel_JobTypes_JobTypeId",
                table: "JobOrderModel",
                column: "JobTypeId",
                principalTable: "JobTypes",
                principalColumn: "JobTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrderModel_OrderModel_OrderId",
                table: "JobOrderModel",
                column: "OrderId",
                principalTable: "OrderModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Clients_ClientId",
                table: "OrderModel",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Users_CreatedUserId",
                table: "OrderModel",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Users_UpdatedUserId",
                table: "OrderModel",
                column: "UpdatedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Vehicles_VehicleId",
                table: "OrderModel",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "IdVehicle",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
