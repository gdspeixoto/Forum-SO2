using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exemplo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemplo", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Exemplo",
                columns: new[] { "ID", "Ativo", "DataAtualizacao", "DataCriacao", "DataExclusao", "Nome", "Valor" },
                values: new object[] { 1, true, null, new DateTime(2023, 6, 26, 21, 12, 27, 193, DateTimeKind.Local).AddTicks(9489), null, "Exemplo 1", 10.0 });

            migrationBuilder.InsertData(
                table: "Exemplo",
                columns: new[] { "ID", "Ativo", "DataAtualizacao", "DataCriacao", "DataExclusao", "Nome", "Valor" },
                values: new object[] { 2, false, null, new DateTime(2023, 6, 26, 21, 12, 27, 211, DateTimeKind.Local).AddTicks(9164), null, "Exemplo 2", 20.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemplo");
        }
    }
}
