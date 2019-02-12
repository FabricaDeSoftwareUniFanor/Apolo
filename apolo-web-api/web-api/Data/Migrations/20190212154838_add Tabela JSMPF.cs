using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaJSMPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JSMPFs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CaloriasGastar = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FCInterrupcao = table.Column<float>(nullable: false),
                    FCRepouso = table.Column<float>(nullable: false),
                    Indice = table.Column<float>(nullable: false),
                    KcalMin60 = table.Column<float>(nullable: false),
                    KcalMin80 = table.Column<float>(nullable: false),
                    LimiteMaxFC = table.Column<float>(nullable: false),
                    LimiteMinFC = table.Column<float>(nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    PatintId = table.Column<int>(nullable: false),
                    Recomendacoes = table.Column<string>(nullable: true),
                    ResultadoVO2 = table.Column<float>(nullable: false),
                    TempoBicicleta = table.Column<float>(nullable: false),
                    TempoEsteira = table.Column<float>(nullable: false),
                    TempoGastar60 = table.Column<float>(nullable: false),
                    TempoGastar80 = table.Column<float>(nullable: false),
                    ValoresTreino = table.Column<int>(nullable: false),
                    VelTerminoTeste = table.Column<float>(nullable: false),
                    VelocBicicleta = table.Column<float>(nullable: false),
                    VelocEsteira = table.Column<float>(nullable: false),
                    Velocidade60 = table.Column<float>(nullable: false),
                    Velocidade80 = table.Column<float>(nullable: false),
                    VezesSemana = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JSMPFs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JSMPFs_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JSMPFs_PatientId",
                table: "JSMPFs",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JSMPFs");
        }
    }
}
