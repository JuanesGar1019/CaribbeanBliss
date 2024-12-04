using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Caribbean2.Migrations
{
    /// <inheritdoc />
    public partial class Caribbeaan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Huespedes_ReservaAdmin_ReservaAdminIdReserva",
                table: "Huespedes");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_idCliente",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion1",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_ReservaEstados_idEstado",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaServicio_Servicios_ServiciosSeleccionadosIdServicio",
                table: "ReservaServicio");

            migrationBuilder.DropForeignKey(
                name: "FK_Servicios_ReservaAdmin_ReservaAdminIdReserva",
                table: "Servicios");

            migrationBuilder.DropTable(
                name: "ReservaAdmin");

            migrationBuilder.DropIndex(
                name: "IX_Servicios_ReservaAdminIdReserva",
                table: "Servicios");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdHabitacion1",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Huespedes_ReservaAdminIdReserva",
                table: "Huespedes");

            migrationBuilder.DropColumn(
                name: "ReservaAdminIdReserva",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "IdHabitacion1",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "ReservaAdminIdReserva",
                table: "Huespedes");

            migrationBuilder.RenameColumn(
                name: "ServiciosSeleccionadosIdServicio",
                table: "ReservaServicio",
                newName: "ServiciosIdServicio");

            migrationBuilder.RenameIndex(
                name: "IX_ReservaServicio_ServiciosSeleccionadosIdServicio",
                table: "ReservaServicio",
                newName: "IX_ReservaServicio_ServiciosIdServicio");

            migrationBuilder.RenameColumn(
                name: "idEstado",
                table: "Reservas",
                newName: "IdEstado");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Reservas",
                newName: "IdCliente");

            migrationBuilder.RenameColumn(
                name: "PrecioReserva",
                table: "Reservas",
                newName: "PrecioTotal");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_idEstado",
                table: "Reservas",
                newName: "IX_Reservas_IdEstado");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_idCliente",
                table: "Reservas",
                newName: "IX_Reservas_IdCliente");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "ReservaEstados",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "idEstado",
                table: "ReservaEstados",
                newName: "IdEstado");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCliente",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Anticipo",
                table: "Reservas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IdHabitacion",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdHuesped",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notas",
                table: "Reservas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroPersonas",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "ReservaEstados",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    idPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_pago = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    valor = table.Column<int>(type: "int", nullable: false),
                    idReserva = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.idPago);
                    table.ForeignKey(
                        name: "FK_Pago_Reservas_idReserva",
                        column: x => x.idReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 3, 19, 20, 2, 626, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHuesped",
                table: "Reservas",
                column: "IdHuesped");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_idReserva",
                table: "Pago",
                column: "idReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_IdCliente",
                table: "Reservas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "idCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion",
                table: "Reservas",
                column: "IdHabitacion",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Huespedes_IdHuesped",
                table: "Reservas",
                column: "IdHuesped",
                principalTable: "Huespedes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_ReservaEstados_IdEstado",
                table: "Reservas",
                column: "IdEstado",
                principalTable: "ReservaEstados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaServicio_Servicios_ServiciosIdServicio",
                table: "ReservaServicio",
                column: "ServiciosIdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Clientes_IdCliente",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Huespedes_IdHuesped",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_ReservaEstados_IdEstado",
                table: "Reservas");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaServicio_Servicios_ServiciosIdServicio",
                table: "ReservaServicio");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_IdHuesped",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Anticipo",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdHabitacion",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "IdHuesped",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Notas",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "NumeroPersonas",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "ServiciosIdServicio",
                table: "ReservaServicio",
                newName: "ServiciosSeleccionadosIdServicio");

            migrationBuilder.RenameIndex(
                name: "IX_ReservaServicio_ServiciosIdServicio",
                table: "ReservaServicio",
                newName: "IX_ReservaServicio_ServiciosSeleccionadosIdServicio");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Reservas",
                newName: "idEstado");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Reservas",
                newName: "idCliente");

            migrationBuilder.RenameColumn(
                name: "PrecioTotal",
                table: "Reservas",
                newName: "PrecioReserva");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_IdEstado",
                table: "Reservas",
                newName: "IX_Reservas_idEstado");

            migrationBuilder.RenameIndex(
                name: "IX_Reservas_IdCliente",
                table: "Reservas",
                newName: "IX_Reservas_idCliente");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "ReservaEstados",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "ReservaEstados",
                newName: "idEstado");

            migrationBuilder.AddColumn<int>(
                name: "ReservaAdminIdReserva",
                table: "Servicios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idEstado",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "idCliente",
                table: "Reservas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdHabitacion1",
                table: "Reservas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "ReservaEstados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ReservaAdminIdReserva",
                table: "Huespedes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReservaAdmin",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HabitacionIdHabitacion = table.Column<int>(type: "int", nullable: true),
                    EstadoReserva = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: false),
                    IdHuesped = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaAdmin", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_ReservaAdmin_Habitaciones_HabitacionIdHabitacion",
                        column: x => x.HabitacionIdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion");
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 3, 9, 47, 56, 741, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ReservaAdminIdReserva",
                table: "Servicios",
                column: "ReservaAdminIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHabitacion1",
                table: "Reservas",
                column: "IdHabitacion1");

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_ReservaAdminIdReserva",
                table: "Huespedes",
                column: "ReservaAdminIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaAdmin_HabitacionIdHabitacion",
                table: "ReservaAdmin",
                column: "HabitacionIdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Huespedes_ReservaAdmin_ReservaAdminIdReserva",
                table: "Huespedes",
                column: "ReservaAdminIdReserva",
                principalTable: "ReservaAdmin",
                principalColumn: "IdReserva");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Clientes_idCliente",
                table: "Reservas",
                column: "idCliente",
                principalTable: "Clientes",
                principalColumn: "idCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Habitaciones_IdHabitacion1",
                table: "Reservas",
                column: "IdHabitacion1",
                principalTable: "Habitaciones",
                principalColumn: "IdHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_ReservaEstados_idEstado",
                table: "Reservas",
                column: "idEstado",
                principalTable: "ReservaEstados",
                principalColumn: "idEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaServicio_Servicios_ServiciosSeleccionadosIdServicio",
                table: "ReservaServicio",
                column: "ServiciosSeleccionadosIdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Servicios_ReservaAdmin_ReservaAdminIdReserva",
                table: "Servicios",
                column: "ReservaAdminIdReserva",
                principalTable: "ReservaAdmin",
                principalColumn: "IdReserva");
        }
    }
}
