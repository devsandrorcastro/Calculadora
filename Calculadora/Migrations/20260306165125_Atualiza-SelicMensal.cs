using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calculadora.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaSelicMensal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "SelicMensal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                table: "SelicMensal",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "SelicMensal");

            migrationBuilder.DropColumn(
                name: "Mes",
                table: "SelicMensal");
        }
    }
}
