using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Forum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exemplo");

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomePessoa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextoPergunta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TextoResposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerguntaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respostas_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respostas_PerguntaId",
                table: "Respostas",
                column: "PerguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respostas");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.CreateTable(
                name: "Exemplo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
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
    }
}
