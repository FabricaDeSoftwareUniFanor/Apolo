using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class addTabelaFlexiteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flexitestes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AbducaoQuadril = table.Column<int>(nullable: false),
                    AducaoPostOmbro = table.Column<int>(nullable: false),
                    ExtensaoAducaoTronco = table.Column<int>(nullable: false),
                    ExtensaoPostOmbro = table.Column<int>(nullable: false),
                    ExtensaoQuadril = table.Column<int>(nullable: false),
                    FlexaoLatTronco = table.Column<int>(nullable: false),
                    FlexaoQuadril = table.Column<int>(nullable: false),
                    FlexaoTronco = table.Column<int>(nullable: false),
                    Indice = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flexitestes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flexitestes_Persons_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flexitestes_PatientId",
                table: "Flexitestes",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flexitestes");
        }
    }
}
