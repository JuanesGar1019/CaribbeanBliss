using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caribbean2.Migrations
{
    /// <inheritdoc />
    public partial class InicialDos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaAdmin_Habitaciones_IdHabitacion",
                table: "ReservaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_ReservaAdmin_IdHabitacion",
                table: "ReservaAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "IdHabitacion",
                table: "ReservaAdmin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HabitacionIdHabitacion",
                table: "ReservaAdmin",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ReservaAdmin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 2, 16, 50, 26, 934, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.CreateIndex(
                name: "IX_ReservaAdmin_HabitacionIdHabitacion",
                table: "ReservaAdmin",
                column: "HabitacionIdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaAdmin_Habitaciones_HabitacionIdHabitacion",
                table: "ReservaAdmin",
                column: "HabitacionIdHabitacion",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaAdmin_Habitaciones_HabitacionIdHabitacion",
                table: "ReservaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_ReservaAdmin_HabitacionIdHabitacion",
                table: "ReservaAdmin");

            migrationBuilder.DropColumn(
                name: "HabitacionIdHabitacion",
                table: "ReservaAdmin");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ReservaAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "IdHabitacion",
                table: "ReservaAdmin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 2, 13, 33, 48, 69, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.CreateIndex(
                name: "IX_ReservaAdmin_IdHabitacion",
                table: "ReservaAdmin",
                column: "IdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaAdmin_Habitaciones_IdHabitacion",
                table: "ReservaAdmin",
                column: "IdHabitacion",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion");
        }
    }
}
