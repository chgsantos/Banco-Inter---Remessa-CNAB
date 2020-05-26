using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNAB.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoServico = table.Column<string>(nullable: true),
                    BancoCodigo = table.Column<string>(nullable: true),
                    Agencia = table.Column<string>(nullable: true),
                    AgenciaDigito = table.Column<string>(nullable: true),
                    ContaCorrente = table.Column<string>(nullable: true),
                    ContaCorrenteDigito = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<decimal>(nullable: false),
                    TipoInscricao = table.Column<string>(nullable: true),
                    Inscricao = table.Column<string>(nullable: true),
                    EnderecoLogradouro = table.Column<string>(nullable: true),
                    EnderecoNumero = table.Column<string>(nullable: true),
                    EnderecoComplemento = table.Column<string>(nullable: true),
                    EnderecoBairro = table.Column<string>(nullable: true),
                    EnderecoCidade = table.Column<string>(nullable: true),
                    EnderecoCep = table.Column<string>(nullable: true),
                    EnderecoSiglaEstado = table.Column<string>(nullable: true),
                    Ativado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pagamento",
                columns: new[] { "Id", "Agencia", "AgenciaDigito", "Ativado", "BancoCodigo", "ContaCorrente", "ContaCorrenteDigito", "DataPagamento", "EnderecoBairro", "EnderecoCep", "EnderecoCidade", "EnderecoComplemento", "EnderecoLogradouro", "EnderecoNumero", "EnderecoSiglaEstado", "Inscricao", "Nome", "TipoInscricao", "TipoServico", "Valor" },
                values: new object[] { 1, "1", "9", 1, "77", "999999", "9", new DateTime(2020, 5, 26, 20, 52, 3, 982, DateTimeKind.Local).AddTicks(8727), "CENTRO", "31275000", "BELO HORIZONTE", "SALA 9", "AVENIDA PRINCIPAL", "99", "MG", "999.999.999-99", "JOAO SILVA", "1", null, 1000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamento");
        }
    }
}
