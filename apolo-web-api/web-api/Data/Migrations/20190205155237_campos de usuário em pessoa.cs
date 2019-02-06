using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ApoloWebApi.Data.Migrations
{
    public partial class camposdeusuárioempessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_UserId",
                table: "Pessoas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_AspNetUsers_UserId",
                table: "Pessoas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_AspNetUsers_UserId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_UserId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pessoas");
        }
    }
}
