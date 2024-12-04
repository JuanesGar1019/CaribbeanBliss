using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Caribbean2.Migrations
{
    /// <inheritdoc />
    public partial class Caribbeaann : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HabitacionEstados",
                columns: new[] { "IdEstado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Disponible" },
                    { 2, "Ocupada" },
                    { 3, "Inhabilitada" }
                });

            migrationBuilder.InsertData(
                table: "HuespedEstados",
                columns: new[] { "IdEstadoHuesped", "NombreEstado" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 3, "Proceso Check-Out" },
                    { 4, "Check-Out Completado" },
                    { 5, "Cancelado" },
                    { 6, "Aplazado" },
                    { 7, "Suspendido" }
                });

            migrationBuilder.InsertData(
                table: "ReservaEstados",
                columns: new[] { "IdEstado", "Nombre" },
                values: new object[,]
                {
                    { 1, "En Pendiente" },
                    { 2, "Confirmada" },
                    { 3, "En Progreso" },
                    { 4, "Completada" },
                    { 5, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "IdServicio", "Descripcion", "EstadoServicio", "Nombre", "PrecioServicio" },
                values: new object[,]
                {
                    { 1, "Vive la emoción del paracaidismo con un salto en tándem. Disfruta de vistas impresionantes y la adrenalina de caer en caída libre, acompañado de un instructor experto. Un servicio único para quienes buscan una experiencia extrema y memorable, ¡haz realidad tu sueño de volar!", true, "Paracaidismo", 99.99m },
                    { 5, "Recibe asesoramiento experto con nuestras guías de viaje personalizadas que te ayudarán a descubrir lo mejor del Caribe.", true, "Viaje Personalizadas", 69.99m },
                    { 8, "Viaja con comodidad en nuestros vehículos de lujo, equipados para ofrecerte la mejor experiencia de transporte.", true, "Transporte de Lujo", 49.99m },
                    { 9, "Diviértete en nuestro parque acuático, con emocionantes toboganes, piscinas de olas y zonas de relajación. Ideal para toda la familia, ofrece atracciones para todos los gustos, desde aventuras acuáticas hasta momentos de descanso. Ven y disfruta de un día lleno de diversión y frescura bajo el sol", true, "Parque acuático", 119.00m },
                    { 10, "Relájate y rejuvenece con nuestros servicios de spa de primera clase, diseñados para ofrecerte una experiencia de bienestar.", true, "Servicios de Spa", 39.99m },
                    { 11, "Saborea una selección de platos gourmet preparados por chefs expertos, con ingredientes frescos y locales.", true, "Cenas Gourmet", 59.99m }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 4, 6, 24, 2, 434, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.InsertData(
                table: "Habitaciones",
                columns: new[] { "IdHabitacion", "Capacidad", "Descripcion", "IdEstado", "Nombre", "PrecioHabitacion" },
                values: new object[,]
                {
                    { 1, 2, "Habitación Deluxe con diseño moderno, equipada con comodidades premium para una experiencia única de confort.", 1, "Deluxe", 359.99m },
                    { 2, 8, "Habitación ideal para familias, amplia y cómoda, con capacidad para grupos grandes y servicios adaptados a sus necesidades.", 1, "Familiar", 239.99m },
                    { 3, 1, "Habitación perfecta para una sola persona, diseñada para garantizar privacidad y un espacio acogedor.", 1, "Individual", 119.99m },
                    { 4, 2, "Habitación VIP con servicios exclusivos, lujo excepcional y diseño elegante para huéspedes exigentes.", 1, "VIP", 539.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HabitacionEstados",
                keyColumn: "IdEstado",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HabitacionEstados",
                keyColumn: "IdEstado",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Habitaciones",
                keyColumn: "IdHabitacion",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HuespedEstados",
                keyColumn: "IdEstadoHuesped",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HuespedEstados",
                keyColumn: "IdEstadoHuesped",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HuespedEstados",
                keyColumn: "IdEstadoHuesped",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HuespedEstados",
                keyColumn: "IdEstadoHuesped",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HuespedEstados",
                keyColumn: "IdEstadoHuesped",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HuespedEstados",
                keyColumn: "IdEstadoHuesped",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReservaEstados",
                keyColumn: "IdEstado",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "IdServicio",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "IdServicio",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "IdServicio",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "IdServicio",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "IdServicio",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Servicios",
                keyColumn: "IdServicio",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HabitacionEstados",
                keyColumn: "IdEstado",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioID",
                keyValue: 1,
                column: "FechaRegistro",
                value: new DateTime(2024, 12, 3, 19, 20, 2, 626, DateTimeKind.Local).AddTicks(5361));
        }
    }
}
