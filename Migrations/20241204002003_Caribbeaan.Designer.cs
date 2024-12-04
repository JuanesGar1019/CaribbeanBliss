﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Caribbean2.Migrations
{
    [DbContext(typeof(CaribbeanContext))]
    [Migration("20241204002003_Caribbeaan")]
    partial class Caribbeaan
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Caribbean2.Models.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCliente"));

                    b.Property<bool>("ClienteEstado")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idRol")
                        .HasColumnType("int");

                    b.Property<int?>("idRolNavigationIdRol")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCliente");

                    b.HasIndex("idRolNavigationIdRol");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Caribbean2.Models.Consulta", b =>
                {
                    b.Property<int>("IdConsulta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdConsulta"));

                    b.Property<string>("Asunto")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("FechaConsulta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("NombresApellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdConsulta");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Caribbean2.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmpleado"));

                    b.Property<string>("EmailEmpleado")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EstadoEmpleado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreEmpleado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("IdEmpleado");

                    b.HasIndex("EmailEmpleado")
                        .IsUnique();

                    b.HasIndex("RolId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Caribbean2.Models.Huesped", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdEstadoHuesped")
                        .HasColumnType("int");

                    b.Property<string>("LugarResidencia")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("NumeroContacto")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TipoDocumento")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoHuesped");

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("Caribbean2.Models.HuespedEstado", b =>
                {
                    b.Property<int>("IdEstadoHuesped")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstadoHuesped"));

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdEstadoHuesped");

                    b.ToTable("HuespedEstados");
                });

            modelBuilder.Entity("Caribbean2.Models.Metrica", b =>
                {
                    b.Property<int>("IdMetrica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMetrica"));

                    b.Property<int>("Cancelaciones")
                        .HasColumnType("int");

                    b.Property<double>("DuracionPromedioEstadia")
                        .HasColumnType("float");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ImpactoFinancieroCancelaciones")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IngresosTotales")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumeroHuespedes")
                        .HasColumnType("int");

                    b.Property<int>("OcupacionDiaria")
                        .HasColumnType("int");

                    b.Property<int>("OcupacionMensual")
                        .HasColumnType("int");

                    b.Property<int>("OcupacionSemanal")
                        .HasColumnType("int");

                    b.Property<double>("PromedioDiasAnticipacionReserva")
                        .HasColumnType("float");

                    b.Property<int>("ReservasNuevas")
                        .HasColumnType("int");

                    b.Property<int>("SuscritosBoletin")
                        .HasColumnType("int");

                    b.Property<double>("TasaOcupacion")
                        .HasColumnType("float");

                    b.HasKey("IdMetrica");

                    b.ToTable("Metricas");
                });

            modelBuilder.Entity("Caribbean2.Models.Pago", b =>
                {
                    b.Property<int>("idPago")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idPago"));

                    b.Property<DateOnly>("fecha")
                        .HasColumnType("date");

                    b.Property<int>("idReserva")
                        .HasColumnType("int");

                    b.Property<string>("tipo_pago")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("valor")
                        .HasColumnType("int");

                    b.HasKey("idPago");

                    b.HasIndex("idReserva");

                    b.ToTable("Pago");
                });

            modelBuilder.Entity("Caribbean2.Models.Permiso", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermiso"));

                    b.Property<string>("DescripcionPermiso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombrePermiso")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPermiso");

                    b.HasIndex("NombrePermiso")
                        .IsUnique();

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("Caribbean2.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"));

                    b.Property<decimal>("Anticipo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("IdHuesped")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("NumeroPersonas")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdHabitacion");

                    b.HasIndex("IdHuesped");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Caribbean2.Models.ReservaEstado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdEstado");

                    b.ToTable("ReservaEstados");
                });

            modelBuilder.Entity("Caribbean2.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("DescripcionRol")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("EstadoRol")
                        .HasColumnType("bit");

                    b.Property<string>("NombreRol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRol");

                    b.HasIndex("NombreRol")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IdRol = 1,
                            DescripcionRol = "Cliente",
                            EstadoRol = true,
                            NombreRol = "Cliente"
                        },
                        new
                        {
                            IdRol = 2,
                            DescripcionRol = "Empleado",
                            EstadoRol = false,
                            NombreRol = "Empleado"
                        },
                        new
                        {
                            IdRol = 3,
                            DescripcionRol = "Administrador",
                            EstadoRol = true,
                            NombreRol = "Administrador"
                        },
                        new
                        {
                            IdRol = 4,
                            DescripcionRol = "Gerente",
                            EstadoRol = false,
                            NombreRol = "Gerente"
                        });
                });

            modelBuilder.Entity("Caribbean2.Models.Servicio", b =>
                {
                    b.Property<int>("IdServicio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServicio"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<bool>("EstadoServicio")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("PrecioServicio")
                        .HasColumnType("money");

                    b.HasKey("IdServicio");

                    b.ToTable("Servicios");
                });

            modelBuilder.Entity("Caribbean2.Models.Suscripcion", b =>
                {
                    b.Property<int>("IdSuscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSuscripcion"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaSuscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdSuscripcion");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Suscripciones");
                });

            modelBuilder.Entity("Caribbean2.Models.Usuarios", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioID"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NombresApellidos")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime?>("ResetPasswordExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResetPasswordToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolIdRol")
                        .HasColumnType("int");

                    b.Property<string>("Telefono")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TipoIdentificacion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UsuarioID");

                    b.HasIndex("Correo")
                        .IsUnique();

                    b.HasIndex("IdRol");

                    b.HasIndex("Identificacion")
                        .IsUnique();

                    b.HasIndex("RolIdRol");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioID = 1,
                            Contrasena = "nimad4321",
                            Correo = "admin@admincorreo.com",
                            Estado = true,
                            FechaRegistro = new DateTime(2024, 12, 3, 19, 20, 2, 626, DateTimeKind.Local).AddTicks(5361),
                            IdRol = 3,
                            Identificacion = "1",
                            NombresApellidos = "admin",
                            Telefono = "1",
                            TipoIdentificacion = "CC"
                        });
                });

            modelBuilder.Entity("Habitacion", b =>
                {
                    b.Property<int>("IdHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHabitacion"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("PrecioHabitacion")
                        .HasColumnType("money");

                    b.HasKey("IdHabitacion");

                    b.HasIndex("IdEstado");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("HabitacionEstado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdEstado");

                    b.ToTable("HabitacionEstados");
                });

            modelBuilder.Entity("ReservaServicio", b =>
                {
                    b.Property<int>("ReservasIdReserva")
                        .HasColumnType("int");

                    b.Property<int>("ServiciosIdServicio")
                        .HasColumnType("int");

                    b.HasKey("ReservasIdReserva", "ServiciosIdServicio");

                    b.HasIndex("ServiciosIdServicio");

                    b.ToTable("ReservaServicio");
                });

            modelBuilder.Entity("RolPermiso", b =>
                {
                    b.Property<int>("IdPermiso")
                        .HasColumnType("int");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.HasKey("IdPermiso", "IdRol");

                    b.HasIndex("IdRol");

                    b.ToTable("RolPermiso");
                });

            modelBuilder.Entity("Caribbean2.Models.Cliente", b =>
                {
                    b.HasOne("Caribbean2.Models.Rol", "idRolNavigation")
                        .WithMany()
                        .HasForeignKey("idRolNavigationIdRol");

                    b.Navigation("idRolNavigation");
                });

            modelBuilder.Entity("Caribbean2.Models.Empleado", b =>
                {
                    b.HasOne("Caribbean2.Models.Rol", "Rol")
                        .WithMany("Empleados")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Caribbean2.Models.Huesped", b =>
                {
                    b.HasOne("Caribbean2.Models.HuespedEstado", "EstadoHuesped")
                        .WithMany("Huespedes")
                        .HasForeignKey("IdEstadoHuesped");

                    b.Navigation("EstadoHuesped");
                });

            modelBuilder.Entity("Caribbean2.Models.Pago", b =>
                {
                    b.HasOne("Caribbean2.Models.Reserva", "idReservaNavigation")
                        .WithMany("Pagos")
                        .HasForeignKey("idReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("idReservaNavigation");
                });

            modelBuilder.Entity("Caribbean2.Models.Reserva", b =>
                {
                    b.HasOne("Caribbean2.Models.Cliente", "Cliente")
                        .WithMany("Reservas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caribbean2.Models.ReservaEstado", "Estado")
                        .WithMany("Reservas")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Habitacion", "Habitacion")
                        .WithMany("Reservas")
                        .HasForeignKey("IdHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caribbean2.Models.Huesped", "Huesped")
                        .WithMany()
                        .HasForeignKey("IdHuesped")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Estado");

                    b.Navigation("Habitacion");

                    b.Navigation("Huesped");
                });

            modelBuilder.Entity("Caribbean2.Models.Usuarios", b =>
                {
                    b.HasOne("Caribbean2.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Caribbean2.Models.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolIdRol");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Habitacion", b =>
                {
                    b.HasOne("HabitacionEstado", "EstadoHabitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoHabitacion");
                });

            modelBuilder.Entity("ReservaServicio", b =>
                {
                    b.HasOne("Caribbean2.Models.Reserva", null)
                        .WithMany()
                        .HasForeignKey("ReservasIdReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caribbean2.Models.Servicio", null)
                        .WithMany()
                        .HasForeignKey("ServiciosIdServicio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RolPermiso", b =>
                {
                    b.HasOne("Caribbean2.Models.Permiso", null)
                        .WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Caribbean2.Models.Rol", null)
                        .WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Caribbean2.Models.Cliente", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Caribbean2.Models.HuespedEstado", b =>
                {
                    b.Navigation("Huespedes");
                });

            modelBuilder.Entity("Caribbean2.Models.Reserva", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Caribbean2.Models.ReservaEstado", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Caribbean2.Models.Rol", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Habitacion", b =>
                {
                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("HabitacionEstado", b =>
                {
                    b.Navigation("Habitaciones");
                });
#pragma warning restore 612, 618
        }
    }
}