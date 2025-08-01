using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMotorcycleYearCollType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER TABLE motorcycles ALTER COLUMN year TYPE integer USING year::integer;");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "year",
                table: "motorcycles",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
