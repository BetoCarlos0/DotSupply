using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoMercadoria.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entradaSaidaMercadorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InfoCadastro = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entradaSaidaMercadorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercadoria",
                columns: table => new
                {
                    MercadoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NumRegistro = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    EntradaSaidaMercadoriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadoria", x => x.MercadoriaId);
                    table.ForeignKey(
                        name: "FK_Mercadoria_entradaSaidaMercadorias_EntradaSaidaMercadoriaId",
                        column: x => x.EntradaSaidaMercadoriaId,
                        principalTable: "entradaSaidaMercadorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mercadoria_EntradaSaidaMercadoriaId",
                table: "Mercadoria",
                column: "EntradaSaidaMercadoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mercadoria");

            migrationBuilder.DropTable(
                name: "entradaSaidaMercadorias");
        }
    }
}
