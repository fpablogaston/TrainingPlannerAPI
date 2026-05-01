using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AgregadoFechaCreacionYRutinaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ejercicios_Rutinas_RutinaId",
                table: "Ejercicios");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Rutinas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "RutinaId",
                table: "Ejercicios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ejercicios_Rutinas_RutinaId",
                table: "Ejercicios",
                column: "RutinaId",
                principalTable: "Rutinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ejercicios_Rutinas_RutinaId",
                table: "Ejercicios");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Rutinas");

            migrationBuilder.AlterColumn<int>(
                name: "RutinaId",
                table: "Ejercicios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ejercicios_Rutinas_RutinaId",
                table: "Ejercicios",
                column: "RutinaId",
                principalTable: "Rutinas",
                principalColumn: "Id");
        }
    }
}
