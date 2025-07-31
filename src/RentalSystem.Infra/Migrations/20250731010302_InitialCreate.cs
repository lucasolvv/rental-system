using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalSystem.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entregadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    numero_cnh = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    tipo_cnh = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    imagem_cnh_path = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entregadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "eventos_moto_cadastrada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MotoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataEvento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConteudoMensagem = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventos_moto_cadastrada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "motos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    placa = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EntregadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotoId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataPrevisaoTermino = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiasPlano = table.Column<int>(type: "integer", nullable: false),
                    ValorDiaria = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_locacoes_entregadores_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "entregadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_locacoes_motos_MotoId",
                        column: x => x.MotoId,
                        principalTable: "motos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_entregadores_cnpj",
                table: "entregadores",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entregadores_numero_cnh",
                table: "entregadores",
                column: "numero_cnh",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_locacoes_EntregadorId",
                table: "locacoes",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_locacoes_MotoId",
                table: "locacoes",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_motos_placa",
                table: "motos",
                column: "placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "eventos_moto_cadastrada");

            migrationBuilder.DropTable(
                name: "locacoes");

            migrationBuilder.DropTable(
                name: "entregadores");

            migrationBuilder.DropTable(
                name: "motos");
        }
    }
}
