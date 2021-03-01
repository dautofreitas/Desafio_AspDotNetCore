using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Migrations
{
    public partial class SegundaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorCorrigido",
                table: "Conta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorCorrigido",
                table: "Conta");
        }
    }
}
