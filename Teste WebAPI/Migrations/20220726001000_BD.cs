using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_WebAPI.Migrations
{
    public partial class BD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnderecoFuncionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idFuncionario = table.Column<int>(type: "int", nullable: false),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoFuncionario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enderecoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Funcionario_EnderecoFuncionario_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "EnderecoFuncionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_enderecoid",
                table: "Funcionario",
                column: "enderecoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "EnderecoFuncionario");
        }
    }
}
