using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caribbean2.Migrations
{
    /// <inheritdoc />
    public partial class InicialTres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Reservas_idReserva",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Huespedes_IdHuesped",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdHuesped",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdHuesped",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "tipo_pago",
                table: "Pago");

            migrationBuilder.RenameColumn(
                name: "valor",
                table: "Pago",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "idReserva",
                table: "Pago",
                newName: "IdReserva");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "Pago",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "idPago",
                table: "Pago",
                newName: "IdPago");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_idReserva",
                table: "Pago",
                newName: "IX_Pago_IdReserva");

            migrationBuilder.AlterColumn<string>(
                name: "Notas",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Pago",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Pago",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "TipoPago",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumeroHabitacion",
                table: "Habitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservaHuesped",
                columns: table => new
                {
                    HuespedesId = table.Column<int>(type: "int", nullable: false),
                    ReservasIdReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHuesped", x => new { x.HuespedesId, x.ReservasIdReserva });
                    table.ForeignKey(
                        name: "FK_ReservaHuesped_Huespedes_HuespedesId",
                        column: x => x.HuespedesId,
                        principalTable: "Huespedes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaHuesped_Reservas_ReservasIdReserva",
                        column: x => x.ReservasIdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 1,
                column: "NumeroHabitacion",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 2,
                column: "NumeroHabitacion",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 3,
                column: "NumeroHabitacion",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 4,
                column: "NumeroHabitacion",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 1,
                column: "Nombre",
                value: "Pendiente");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 4, 15, 36, 51, 754, DateTimeKind.Local).AddTicks(9843));

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHuesped_ReservasIdReserva",
                table: "ReservaHuesped",
                column: "ReservasIdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Reservas_IdReserva",
                table: "Pago",
                column: "IdReserva",
                principalTable: "Reservas",
                principalColumn: "IdReserva",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Reservas_IdReserva",
                table: "Pago");

            migrationBuilder.DropTable(
                name: "ReservaHuesped");

            migrationBuilder.DropColumn(
                name: "TipoPago",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "NumeroHabitacion",
                table: "Habitaciones");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Pago",
                newName: "valor");

            migrationBuilder.RenameColumn(
                name: "IdReserva",
                table: "Pago",
                newName: "idReserva");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Pago",
                newName: "fecha");

            migrationBuilder.RenameColumn(
                name: "IdPago",
                table: "Pago",
                newName: "idPago");

            migrationBuilder.RenameIndex(
                name: "IX_Pago_IdReserva",
                table: "Pago",
                newName: "IX_Pago_idReserva");

            migrationBuilder.AlterColumn<string>(
                name: "Notas",
                table: "Reservas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdHuesped",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "valor",
                table: "Pago",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "fecha",
                table: "Pago",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "tipo_pago",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 1,
                column: "Nombre",
                value: "En Pendiente");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 4, 6, 24, 2, 434, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHuesped",
                table: "Reservas",
                column: "IdHuesped");

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Reservas_idReserva",
                table: "Pago",
                column: "idReserva",
                principalTable: "Reservas",
                principalColumn: "IdReserva",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Huespedes_IdHuesped",
                table: "Reservas",
                column: "IdHuesped",
                principalTable: "Huespedes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
