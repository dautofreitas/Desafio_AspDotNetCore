using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Migrations
{
    public partial class TerceiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PorcentagemJurosDia",
                table: "Conta",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentagemMulta",
                table: "Conta",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PorcentagemJurosDia",
                table: "Conta");

            migrationBuilder.DropColumn(
                name: "PorcentagemMulta",
                table: "Conta");
        }
    }
}
