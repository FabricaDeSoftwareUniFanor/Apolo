using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaRiscoCoronariano : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiscosCoronarianos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Colesterol = table.Column<int>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ExercicioFisico = table.Column<int>(nullable: false),
                    Historico = table.Column<int>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    PressaoSistolica = table.Column<int>(nullable: false),
                    Risco = table.Column<int>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    Tabagismo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiscosCoronarianos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RiscosCoronarianos_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RiscosCoronarianos_PatientId",
                table: "RiscosCoronarianos",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RiscosCoronarianos");
        }
    }
}
