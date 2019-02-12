using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaRetracaoecampodataemFlexiteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Flexitestes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Retracoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comentarios = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Isquiotibiais = table.Column<int>(nullable: false),
                    Lombares = table.Column<int>(nullable: false),
                    Ombros = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Peitoral = table.Column<int>(nullable: false),
                    Psoas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retracoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retracoes_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Retracoes_PatientId",
                table: "Retracoes",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Retracoes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Flexitestes");
        }
    }
}
