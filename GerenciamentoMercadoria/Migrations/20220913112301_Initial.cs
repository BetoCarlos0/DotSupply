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
                name: "Mercadoria",
                columns: table => new
                {
                    MercadoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NumRegistro = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercadoria", x => x.MercadoriaId);
                });

            migrationBuilder.CreateTable(
                name: "EntradaMercadoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MercadoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaMercadoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntradaMercadoria_Mercadoria_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadoria",
                        principalColumn: "MercadoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaidaMercadoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    MercadoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaidaMercadoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaidaMercadoria_Mercadoria_MercadoriaId",
                        column: x => x.MercadoriaId,
                        principalTable: "Mercadoria",
                        principalColumn: "MercadoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaMercadoria_MercadoriaId",
                table: "EntradaMercadoria",
                column: "MercadoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_SaidaMercadoria_MercadoriaId",
                table: "SaidaMercadoria",
                column: "MercadoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaMercadoria");

            migrationBuilder.DropTable(
                name: "SaidaMercadoria");

            migrationBuilder.DropTable(
                name: "Mercadoria");
        }
    }
}
