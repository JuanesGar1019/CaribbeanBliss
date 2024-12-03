using Caribbean2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class CaribbeanContext : DbContext
{
    public DbSet<Huesped> Huespedes { get; set; }
    public DbSet<HuespedEstado> HuespedEstados { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<Habitacion> Habitaciones { get; set; }
    public DbSet<HabitacionEstado> HabitacionEstados { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Permiso> Permisos { get; set; }
    public DbSet<Suscripcion> Suscripciones { get; set; }
    public DbSet<Metrica> Metricas { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<ReservaEstado> ReservaEstados { get; set; }
    public CaribbeanContext(DbContextOptions<CaribbeanContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.ConfigureWarnings(warnings =>
           warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Rol>().HasData(
            new Rol { IdRol = 1, NombreRol = "Cliente", DescripcionRol = "Cliente", EstadoRol = true },
            new Rol { IdRol = 2, NombreRol = "Empleado", DescripcionRol = "Empleado", EstadoRol = false },
            new Rol { IdRol = 3, NombreRol = "Administrador", DescripcionRol = "Administrador", EstadoRol = true },
            new Rol { IdRol = 4, NombreRol = "Gerente", DescripcionRol = "Gerente", EstadoRol = false }
        );

        // Usuario administrador predeterminado
        modelBuilder.Entity<Usuarios>().HasData(
            new Usuarios
            {
                UsuarioID = 1,
                NombresApellidos = "admin",
                TipoIdentificacion = "CC",
                Identificacion = "1",
                Telefono = "1",
                Correo = "admin@admincorreo.com",
                Contrasena = "nimad4321",
                FechaRegistro = DateTime.Now,
                Estado = true,
                IdRol = 3
            }
        );

        modelBuilder.Entity<Reserva>()
        .HasOne(r => r.Cliente)
        .WithMany(c => c.Reservas)
        .HasForeignKey(r => r.IdCliente);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Huesped)
            .WithMany()
            .HasForeignKey(r => r.IdHuesped);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Habitacion)
            .WithMany(h => h.Reservas)
            .HasForeignKey(r => r.IdHabitacion);

        modelBuilder.Entity<Reserva>()
            .HasMany(r => r.Servicios)
            .WithMany(s => s.Reservas);

        modelBuilder.Entity<Reserva>()
            .HasMany(r => r.Pagos)
            .WithOne(p => p.idReservaNavigation)
            .HasForeignKey(p => p.idReserva);

        modelBuilder.Entity<Reserva>()
            .HasOne(r => r.Estado)
            .WithMany(e => e.Reservas)
            .HasForeignKey(r => r.IdEstado)
            .OnDelete(DeleteBehavior.Restrict);
                
        // Configuraciones adicionales si es necesario
        modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Identificacion)
                .IsUnique();

        modelBuilder.Entity<Usuarios>()
        .HasKey(u => u.UsuarioID);

        modelBuilder.Entity<Usuarios>()
            .HasIndex(u => u.Correo)
            .IsUnique();

        modelBuilder.Entity<Usuarios>()
            .Property(u => u.Correo)
            .IsRequired()
            .HasMaxLength(255);

        modelBuilder.Entity<Usuarios>()
            .Property(u => u.Contrasena)
            .IsRequired();
        
        modelBuilder.Entity<Usuarios>()
            .HasIndex(u => u.Correo)
            .IsUnique();

        modelBuilder.Entity<Usuarios>()
            .HasOne(u => u.Rol)
            .WithMany(r => r.Usuarios) 
            .HasForeignKey(u => u.IdRol)
            .OnDelete(DeleteBehavior.Restrict);
            
        // Configuración de la relación entre Usuario y Rol
        modelBuilder.Entity<Usuarios>()
            .HasOne<Rol>()
            .WithMany()
            .HasForeignKey(u => u.IdRol)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired(); // Hace que IdRol sea requerido

        modelBuilder.Entity<Usuarios>()
            .Property(u => u.IdRol)
            .HasDefaultValue(1); // Establece 1 como valor predeterminado

        // Suscripcion
        modelBuilder.Entity<Suscripcion>()
            .HasKey(b => b.IdSuscripcion);
        modelBuilder.Entity<Suscripcion>()
            .Property(b => b.IdSuscripcion)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Suscripcion>()
            .HasIndex(b => b.Email)
            .IsUnique();
        modelBuilder.Entity<Suscripcion>()
            .Property(s => s.FechaSuscripcion)
            .HasDefaultValueSql("GETDATE()");

        // Empleados
        modelBuilder.Entity<Empleado>()
            .HasKey(e => e.IdEmpleado);
        modelBuilder.Entity<Empleado>()
            .Property(e => e.IdEmpleado)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Empleado>()
            .HasIndex(e => e.EmailEmpleado)
            .IsUnique();

        modelBuilder.Entity<Empleado>()
            .HasOne(e => e.Rol)
            .WithMany(r => r.Empleados)
            .HasForeignKey(e => e.RolId)
            .OnDelete(DeleteBehavior.Restrict);

        // Roles
        modelBuilder.Entity<Rol>()
            .HasKey(r => r.IdRol);
        modelBuilder.Entity<Rol>()
            .Property(r => r.IdRol)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Rol>()
            .HasIndex(r => r.NombreRol)
            .IsUnique();
        modelBuilder.Entity<Rol>()
            .Property(r => r.DescripcionRol)
            .HasMaxLength(255);

        // Permisos
        modelBuilder.Entity<Permiso>()
            .HasKey(p => p.IdPermiso);
        modelBuilder.Entity<Permiso>()
            .Property(p => p.IdPermiso)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<Permiso>()
            .HasIndex(p => p.NombrePermiso)
            .IsUnique();

        // Relación muchos a muchos entre Roles y Permisos
        modelBuilder.Entity<Rol>()
            .HasMany(r => r.Permisos)
            .WithMany(p => p.Roles)
            .UsingEntity<Dictionary<string, object>>(
                "RolPermiso",
                r => r.HasOne<Permiso>().WithMany().HasForeignKey("IdPermiso"),
                p => p.HasOne<Rol>().WithMany().HasForeignKey("IdRol")
            );

        // Configuración de la relación 1 a N entre Rol y Empleado
        modelBuilder.Entity<Rol>()
            .HasMany(r => r.Empleados)
            .WithOne(e => e.Rol)
            .HasForeignKey(e => e.RolId)
            .OnDelete(DeleteBehavior.Restrict); // Evita eliminación en cascada de empleados si el rol es eliminado

        base.OnModelCreating(modelBuilder);
    }
}


