using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaAvaliacaoFisica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacoesFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cabeca = table.Column<int>(nullable: false),
                    ColunaLombar = table.Column<int>(nullable: false),
                    ColunaToracica = table.Column<int>(nullable: false),
                    CristasIliacas = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Escoliose = table.Column<int>(nullable: false),
                    Jelhos = table.Column<int>(nullable: false),
                    JoelhosLat = table.Column<int>(nullable: false),
                    Ombros = table.Column<int>(nullable: false),
                    OmbrosLat = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    PatirntId = table.Column<int>(nullable: true),
                    Pelve = table.Column<int>(nullable: false),
                    Pes = table.Column<int>(nullable: false),
                    Plantigrama = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacoesFisicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacoesFisicas_Persons_PatirntId",
                        column: x => x.PatirntId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacoesFisicas_PatirntId",
                table: "AvaliacoesFisicas",
                column: "PatirntId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacoesFisicas");
        }
    }
}
