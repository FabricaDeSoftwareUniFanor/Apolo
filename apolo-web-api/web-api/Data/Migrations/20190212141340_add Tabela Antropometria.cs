using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaAntropometria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antropometrias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abdominal = table.Column<float>(nullable: false),
                    AxilaMedia = table.Column<float>(nullable: false),
                    Biceps = table.Column<float>(nullable: false),
                    BracoDContraido = table.Column<float>(nullable: false),
                    BracoDRelaxado = table.Column<float>(nullable: false),
                    BracoEContraido = table.Column<float>(nullable: false),
                    BracoERelaxado = table.Column<float>(nullable: false),
                    Cintura = table.Column<float>(nullable: false),
                    CinturaMenorP = table.Column<float>(nullable: false),
                    CinturaUmbilical = table.Column<float>(nullable: false),
                    Coxa = table.Column<float>(nullable: false),
                    CoxaD = table.Column<float>(nullable: false),
                    CoxaE = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DiametroFemur = table.Column<float>(nullable: false),
                    DiametroRadio = table.Column<float>(nullable: false),
                    Estatura = table.Column<float>(nullable: false),
                    Gordura = table.Column<float>(nullable: false),
                    IMC = table.Column<float>(nullable: false),
                    IMCMax = table.Column<float>(nullable: false),
                    IMCMed = table.Column<float>(nullable: false),
                    IMCMin = table.Column<float>(nullable: false),
                    JacksonPollock = table.Column<float>(nullable: false),
                    MassaMagra = table.Column<float>(nullable: false),
                    Panturrilha = table.Column<float>(nullable: false),
                    PanturrilhaD = table.Column<float>(nullable: false),
                    PanturrilhaE = table.Column<float>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Peitoral = table.Column<float>(nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    PesoGordura = table.Column<float>(nullable: false),
                    PesoMuscular = table.Column<float>(nullable: false),
                    PesoOsseo = table.Column<float>(nullable: false),
                    PesoResidual = table.Column<float>(nullable: false),
                    Quadril = table.Column<float>(nullable: false),
                    Subescapular = table.Column<float>(nullable: false),
                    SupraIliaca = table.Column<float>(nullable: false),
                    TonicidadeMusc = table.Column<float>(nullable: false),
                    ToraxLinhaMamilos = table.Column<float>(nullable: false),
                    ToraxMesmoEsternal = table.Column<float>(nullable: false),
                    Triceps = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antropometrias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antropometrias_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Antropometrias_PatientId",
                table: "Antropometrias",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antropometrias");
        }
    }
}
