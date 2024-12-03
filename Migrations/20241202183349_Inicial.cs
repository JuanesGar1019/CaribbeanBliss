using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Caribbean2.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    IdConsulta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresApellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Asunto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.IdConsulta);
                });

            migrationBuilder.CreateTable(
                name: "HabitacionEstados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitacionEstados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "HuespedEstados",
                columns: table => new
                {
                    IdEstadoHuesped = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuespedEstados", x => x.IdEstadoHuesped);
                });

            migrationBuilder.CreateTable(
                name: "Metricas",
                columns: table => new
                {
                    IdMetrica = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IngresosTotales = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TasaOcupacion = table.Column<double>(type: "float", nullable: false),
                    OcupacionDiaria = table.Column<int>(type: "int", nullable: false),
                    OcupacionSemanal = table.Column<int>(type: "int", nullable: false),
                    OcupacionMensual = table.Column<int>(type: "int", nullable: false),
                    ReservasNuevas = table.Column<int>(type: "int", nullable: false),
                    Cancelaciones = table.Column<int>(type: "int", nullable: false),
                    ImpactoFinancieroCancelaciones = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromedioDiasAnticipacionReserva = table.Column<double>(type: "float", nullable: false),
                    NumeroHuespedes = table.Column<int>(type: "int", nullable: false),
                    SuscritosBoletin = table.Column<int>(type: "int", nullable: false),
                    DuracionPromedioEstadia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metricas", x => x.IdMetrica);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePermiso = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DescripcionPermiso = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "ReservaEstados",
                columns: table => new
                {
                    idEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaEstados", x => x.idEstado);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionRol = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EstadoRol = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Suscripciones",
                columns: table => new
                {
                    IdSuscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaSuscripcion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscripciones", x => x.IdSuscripcion);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    PrecioHabitacion = table.Column<decimal>(type: "money", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.IdHabitacion);
                    table.ForeignKey(
                        name: "FK_Habitaciones_HabitacionEstados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "HabitacionEstados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteEstado = table.Column<bool>(type: "bit", nullable: false),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    idRolNavigationIdRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idCliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Roles_idRolNavigationIdRol",
                        column: x => x.idRolNavigationIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailEmpleado = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoEmpleado = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermiso", x => new { x.IdPermiso, x.IdRol });
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permisos_IdPermiso",
                        column: x => x.IdPermiso,
                        principalTable: "Permisos",
                        principalColumn: "IdPermiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombresApellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    TipoIdentificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    RolIdRol = table.Column<int>(type: "int", nullable: true),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Roles",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "ReservaAdmin",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    EstadoReserva = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdHuesped = table.Column<int>(type: "int", nullable: false),
                    IdHabitacion = table.Column<int>(type: "int", nullable: true),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaAdmin", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_ReservaAdmin_Habitaciones_IdHabitacion",
                        column: x => x.IdHabitacion,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdHabitacion1 = table.Column<int>(type: "int", nullable: true),
                    PrecioReserva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    idCliente = table.Column<int>(type: "int", nullable: true),
                    idEstado = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente");
                    table.ForeignKey(
                        name: "FK_Reservas_Habitaciones_IdHabitacion1",
                        column: x => x.IdHabitacion1,
                        principalTable: "Habitaciones",
                        principalColumn: "IdHabitacion");
                    table.ForeignKey(
                        name: "FK_Reservas_ReservaEstados_idEstado",
                        column: x => x.idEstado,
                        principalTable: "ReservaEstados",
                        principalColumn: "idEstado");
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumeroIdentificacion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumeroContacto = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    LugarResidencia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEstadoHuesped = table.Column<int>(type: "int", nullable: true),
                    ReservaAdminIdReserva = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huespedes_HuespedEstados_IdEstadoHuesped",
                        column: x => x.IdEstadoHuesped,
                        principalTable: "HuespedEstados",
                        principalColumn: "IdEstadoHuesped");
                    table.ForeignKey(
                        name: "FK_Huespedes_ReservaAdmin_ReservaAdminIdReserva",
                        column: x => x.ReservaAdminIdReserva,
                        principalTable: "ReservaAdmin",
                        principalColumn: "IdReserva");
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PrecioServicio = table.Column<decimal>(type: "money", nullable: false),
                    EstadoServicio = table.Column<bool>(type: "bit", nullable: false),
                    ReservaAdminIdReserva = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                    table.ForeignKey(
                        name: "FK_Servicios_ReservaAdmin_ReservaAdminIdReserva",
                        column: x => x.ReservaAdminIdReserva,
                        principalTable: "ReservaAdmin",
                        principalColumn: "IdReserva");
                });

            migrationBuilder.CreateTable(
                name: "ReservaServicio",
                columns: table => new
                {
                    ReservasIdReserva = table.Column<int>(type: "int", nullable: false),
                    ServiciosSeleccionadosIdServicio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaServicio", x => new { x.ReservasIdReserva, x.ServiciosSeleccionadosIdServicio });
                    table.ForeignKey(
                        name: "FK_ReservaServicio_Reservas_ReservasIdReserva",
                        column: x => x.ReservasIdReserva,
                        principalTable: "Reservas",
                        principalColumn: "IdReserva",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservaServicio_Servicios_ServiciosSeleccionadosIdServicio",
                        column: x => x.ServiciosSeleccionadosIdServicio,
                        principalTable: "Servicios",
                        principalColumn: "IdServicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "IdRol", "DescripcionRol", "EstadoRol", "NombreRol" },
                values: new object[,]
                {
                    { 1, "Cliente", true, "Cliente" },
                    { 2, "Empleado", false, "Empleado" },
                    { 3, "Administrador", true, "Administrador" },
                    { 4, "Gerente", false, "Gerente" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Contrasena", "Correo", "Estado", "FechaRegistro", "IdRol", "Identificacion", "NombresApellidos", "ResetPasswordExpiry", "ResetPasswordToken", "RolIdRol", "Telefono", "TipoIdentificacion" },
                values: new object[] { 1, "nimad4321", "admin@admincorreo.com", true, new DateTime(2024, 12, 2, 13, 33, 48, 69, DateTimeKind.Local).AddTicks(4298), 3, "1", "admin", null, null, null, "1", "CC" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_idRolNavigationIdRol",
                table: "Clientes",
                column: "idRolNavigationIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EmailEmpleado",
                table: "Empleados",
                column: "EmailEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_RolId",
                table: "Empleados",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_IdEstado",
                table: "Habitaciones",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_IdEstadoHuesped",
                table: "Huespedes",
                column: "IdEstadoHuesped");

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_ReservaAdminIdReserva",
                table: "Huespedes",
                column: "ReservaAdminIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_NombrePermiso",
                table: "Permisos",
                column: "NombrePermiso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservaAdmin_IdHabitacion",
                table: "ReservaAdmin",
                column: "IdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_idCliente",
                table: "Reservas",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_idEstado",
                table: "Reservas",
                column: "idEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdHabitacion1",
                table: "Reservas",
                column: "IdHabitacion1");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaServicio_ServiciosSeleccionadosIdServicio",
                table: "ReservaServicio",
                column: "ServiciosSeleccionadosIdServicio");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_NombreRol",
                table: "Roles",
                column: "NombreRol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_IdRol",
                table: "RolPermiso",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ReservaAdminIdReserva",
                table: "Servicios",
                column: "ReservaAdminIdReserva");

            migrationBuilder.CreateIndex(
                name: "IX_Suscripciones_Email",
                table: "Suscripciones",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Correo",
                table: "Usuarios",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Identificacion",
                table: "Usuarios",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "Metricas");

            migrationBuilder.DropTable(
                name: "ReservaServicio");

            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "Suscripciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "HuespedEstados");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ReservaEstados");

            migrationBuilder.DropTable(
                name: "ReservaAdmin");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "HabitacionEstados");
        }
    }
}
