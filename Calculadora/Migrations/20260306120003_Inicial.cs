using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculadora.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorOriginal = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorCorrigidoUffi = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorSelic = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorTotalAtualizado = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelicMensal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Competencia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PercentualMensal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelicMensal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UffiAnual",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UffiAnual", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculos");

            migrationBuilder.DropTable(
                name: "SelicMensal");

            migrationBuilder.DropTable(
                name: "UffiAnual");
        }
    }
}
