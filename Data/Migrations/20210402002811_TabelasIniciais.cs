using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginMVCIdentity.Data.Migrations
{
    public partial class TabelasIniciais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    CPF = table.Column<long>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    RG = table.Column<string>(nullable: true),
                    CartaoSUS = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EtiniaPaciente = table.Column<int>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    NumeroLogradouro = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Municipio = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    NomeMae = table.Column<string>(nullable: true),
                    NomePai = table.Column<string>(nullable: true),
                    Responsavel = table.Column<string>(nullable: true),
                    Telefone1 = table.Column<string>(nullable: true),
                    Telefone2 = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NumeroProntuario = table.Column<int>(nullable: false),
                    RegistroFuncional = table.Column<int>(nullable: false),
                    InformacaoComplementar = table.Column<string>(nullable: true),
                    GeneroPaciente = table.Column<int>(nullable: false),
                    OrigemFuncionario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Profissionals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRM = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FichaId = table.Column<int>(nullable: false),
                    PacienteCPF = table.Column<long>(nullable: true),
                    DataFicha = table.Column<DateTime>(nullable: false),
                    Queixa = table.Column<string>(nullable: true),
                    InformacaoResgate = table.Column<string>(nullable: true),
                    StatusDaFicha = table.Column<int>(nullable: false),
                    Especialidade = table.Column<int>(nullable: false),
                    Procedencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fichas_Pacientes_PacienteCPF",
                        column: x => x.PacienteCPF,
                        principalTable: "Pacientes",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DadosClinicos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FichaForeignKey = table.Column<int>(nullable: false),
                    RegistroClinico = table.Column<string>(nullable: true),
                    ProfissionalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosClinicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DadosClinicos_Fichas_FichaForeignKey",
                        column: x => x.FichaForeignKey,
                        principalTable: "Fichas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DadosClinicos_Profissionals_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "Profissionals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DadosClinicos_FichaForeignKey",
                table: "DadosClinicos",
                column: "FichaForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DadosClinicos_ProfissionalId",
                table: "DadosClinicos",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_PacienteCPF",
                table: "Fichas",
                column: "PacienteCPF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosClinicos");

            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.DropTable(
                name: "Profissionals");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
