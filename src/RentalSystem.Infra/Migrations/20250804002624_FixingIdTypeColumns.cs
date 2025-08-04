using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FixingIdTypeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Remover FKs antes de alterar os tipos das colunas
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals");

            // Alterar colunas de Guid para string
            migrationBuilder.AlterColumn<string>(
                name: "MotorcycleId",
                table: "rentals",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryDriverId",
                table: "rentals",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "motorcycles",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "MotorcycleId",
                table: "motorcycle_registered_events",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "delivery_drivers",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            // Adicionar FKs novamente após a mudança de tipo
            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals",
                column: "DeliveryDriverId",
                principalTable: "delivery_drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover FKs antes de reverter os tipos
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals");

            // Reverter colunas para Guid
            migrationBuilder.AlterColumn<Guid>(
                name: "MotorcycleId",
                table: "rentals",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeliveryDriverId",
                table: "rentals",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "motorcycles",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "MotorcycleId",
                table: "motorcycle_registered_events",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "delivery_drivers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            // Adicionar FKs novamente com Guid
            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals",
                column: "DeliveryDriverId",
                principalTable: "delivery_drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
