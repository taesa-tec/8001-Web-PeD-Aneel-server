﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace APIGestor.Migrations
{
    public partial class DemandaHistoricoRevisao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Revisao",
                table: "DemandaFormHistoricos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revisao",
                table: "DemandaFormHistoricos");
        }
    }
}