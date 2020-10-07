using Microsoft.EntityFrameworkCore.Migrations;

namespace Atividade.EfCore.Senai.Migrations
{
    public partial class AlterTableproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Produto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Produto");
        }
    }
}
