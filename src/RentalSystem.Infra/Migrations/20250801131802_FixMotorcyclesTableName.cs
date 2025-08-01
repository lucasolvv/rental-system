using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FixMotorcyclesTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcyles_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_motorcyles",
                table: "motorcyles");

            migrationBuilder.RenameTable(
                name: "motorcyles",
                newName: "motorcycles");

            migrationBuilder.RenameIndex(
                name: "IX_motorcyles_license_plate",
                table: "motorcycles",
                newName: "IX_motorcycles_license_plate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_motorcycles",
                table: "motorcycles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_motorcycles",
                table: "motorcycles");

            migrationBuilder.RenameTable(
                name: "motorcycles",
                newName: "motorcyles");

            migrationBuilder.RenameIndex(
                name: "IX_motorcycles_license_plate",
                table: "motorcyles",
                newName: "IX_motorcyles_license_plate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_motorcyles",
                table: "motorcyles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcyles_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId",
                principalTable: "motorcyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
