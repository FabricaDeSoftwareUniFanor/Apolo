using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaAnamnese : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DiabetesHipoglicemia = table.Column<string>(nullable: true),
                    DistAlergico = table.Column<string>(nullable: true),
                    DistCardiaco = table.Column<string>(nullable: true),
                    DistPlmonar = table.Column<string>(nullable: true),
                    DoresFrequentes = table.Column<string>(nullable: true),
                    Eplepsia = table.Column<string>(nullable: true),
                    HipertensaoHipotensao = table.Column<string>(nullable: true),
                    Historico = table.Column<string>(nullable: true),
                    InfluAtvdFisica = table.Column<string>(nullable: true),
                    IntervCirurgica = table.Column<string>(nullable: true),
                    Objetivos = table.Column<string>(nullable: true),
                    PatientId = table.Column<int>(nullable: false),
                    ProblArticular = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamneses_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_PatientId",
                table: "Anamneses",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anamneses");
        }
    }
}
