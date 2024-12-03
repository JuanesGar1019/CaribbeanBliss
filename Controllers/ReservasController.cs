using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caribbean2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caribbean2.Controllers
{
    public class ReservasController : Controller
    {
        private readonly CaribbeanContext _context;

        public ReservasController(CaribbeanContext context)
        {
            _context = context;
        }

        // GET: Reservas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas
                .Include(r => r.IdHabitacion)
                .Include(r => r.ServiciosSeleccionados)
                .Include(r => r.IdCliente)
                .Include(r => r.IdEstado)
                .ToListAsync();

            var reservasAdmin = reservas.Select(r => new ReservaAdmin
            {
                IdReserva = r.IdReserva,
                NombreCliente = r.IdCliente.nombre,
                EstadoReserva = r.IdEstado.nombre,
                IdHuesped = r.IdCliente.idCliente,
                Huespeds = new List<Huesped> { new Huesped { Id = r.IdCliente.idCliente, NombreCompleto = r.IdCliente.nombre } },
                IdHabitacion = r.IdHabitacion.IdHabitacion,
                PrecioTotal = r.PrecioReserva,
                Servicios = r.ServiciosSeleccionados.ToList(),
                FechaInicio = r.FechaInicio,
                FechaFin = r.FechaFin
            }).ToList();

            return View(reservasAdmin);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            // Filtrar habitaciones activas
            var habitacionesActivas = _context.Habitaciones
                .Where(h => h.EstadoHabitacion.Nombre == "Activo")
                .Select(h => new { h.IdHabitacion, h.Nombre })
                .ToList();

            ViewData["IdHabitacion"] = new SelectList(habitacionesActivas, "IdHabitacion", "Nombre");
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Nombre");
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,FechaInicio,FechaFin,IdHabitacion,PrecioReserva,IdCliente,IdEstado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Filtrar habitaciones activas
            var habitacionesActivas = _context.Habitaciones
                .Where(h => h.EstadoHabitacion.Nombre == "Activa")
                .Select(h => new { h.IdHabitacion, h.Nombre })
                .ToList();

            ViewData["IdHabitacion"] = new SelectList(habitacionesActivas, "IdHabitacion", "Nombre", reserva.IdHabitacion);
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Nombre", reserva.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            return View(reserva);
        }

        // Método para el administrador
        public IActionResult CreateAdmin()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "Nombre");
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre");
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre");
            ViewData["Servicios"] = new MultiSelectList(_context.Servicios, "IdServicio", "Nombre");
            return View("Index"); // Cambia el nombre de la vista si es necesario
        }

        // Método para el cliente
        public IActionResult CreateCliente()
        {
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre");
            ViewData["Servicios"] = new MultiSelectList(_context.Servicios, "IdServicio", "Nombre");
            return View("ReservaAdmin"); // Cambia el nombre de la vista si es necesario
        }

        // GET: Reservas/ReservaAdmin
        public IActionResult ReservaAdmin()
        {
            ViewBag.HabitacionesActivas = _context.Habitaciones
                .Where(h => h.EstadoHabitacion.Nombre == "Activa")
                .ToList();

            ViewBag.ServiciosActivos = _context.Servicios
                .Where(s => s.EstadoServicio == true)
                .ToList();

            ViewBag.ClientesActivos = _context.Clientes
                .Where(c => c.ClienteEstado == true)
                .ToList();

            ViewBag.HuespedesActivos = _context.Huespedes
                .Where(h => h.IdEstadoHuesped == 1) // Asumiendo que 1 es el estado activo
                .ToList();

            return View();
        }

        // Método para calcular el precio total de la reserva
        private async Task<decimal> CalcularPrecioReserva(Reserva reserva, int[] serviciosSeleccionados)
        {
            var habitacion = await _context.Habitaciones.FindAsync(reserva.IdHabitacion.IdHabitacion);
            if (habitacion == null)
                return 0;

            var dias = (reserva.FechaFin - reserva.FechaInicio).Days;

            var servicios = await _context.Servicios
                .Where(s => serviciosSeleccionados.Contains(s.IdServicio))
                .ToListAsync();

            var precioServicios = servicios.Sum(s => s.PrecioServicio);

            return (habitacion.PrecioHabitacion * dias) + precioServicios;
        }

        // POST: Reservas/CreateAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAdmin([Bind("IdReserva,FechaInicio,FechaFin,IdCliente,IdEstado,IdHabitacion")] Reserva reserva, int[] serviciosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                if (reserva.FechaInicio > reserva.FechaFin)
                {
                    ModelState.AddModelError("", "La fecha de inicio debe ser anterior a la fecha de fin.");
                    return View("Index", reserva);
                }

                reserva.PrecioReserva = await CalcularPrecioReserva(reserva, serviciosSeleccionados);

                // Relacionar los servicios seleccionados con la reserva
                reserva.ServiciosSeleccionados = await _context.Servicios
                    .Where(s => serviciosSeleccionados.Contains(s.IdServicio))
                    .ToListAsync();

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Reestablecer los datos de las listas desplegables
            ViewData["IdCliente"] = new SelectList(_context.Huespedes, "Id", "NombreCompleto", reserva.IdCliente.idCliente);
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "idEstado", "nombre", reserva.IdEstado.idEstado);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", reserva.IdHabitacion.IdHabitacion);
            ViewData["Servicios"] = new MultiSelectList(_context.Servicios, "IdServicio", "Nombre", serviciosSeleccionados);

            return View("Index", reserva);
        }

        // POST: Reservas/CreateCliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCliente([Bind("IdReserva,FechaInicio,FechaFin,IdHabitacion")] Reserva reserva, int[] serviciosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                if (reserva.FechaInicio > reserva.FechaFin)
                {
                    ModelState.AddModelError("", "La fecha de inicio debe ser anterior a la fecha de fin.");
                    return View("ClienteCreate", reserva);
                }

                reserva.PrecioReserva = await CalcularPrecioReserva(reserva, serviciosSeleccionados);

                // Relacionar los servicios seleccionados con la reserva
                reserva.ServiciosSeleccionados = await _context.Servicios
                    .Where(s => serviciosSeleccionados.Contains(s.IdServicio))
                    .ToListAsync();

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Reestablecer los datos de las listas desplegables
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", reserva.IdHabitacion.IdHabitacion);
            ViewData["Servicios"] = new MultiSelectList(_context.Servicios, "IdServicio", "Nombre", serviciosSeleccionados);

            return View("ReservaAdmin", reserva);
        }

        // POST: Reservas/ReservaAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReservaAdmin([Bind("IdReserva,NombreCliente,EstadoReserva,IdHuesped,FechaInicio,FechaFin,IdHabitacion")] ReservaAdmin reservaAdmin, int[] ServiciosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                var reserva = new Reserva
                {
                    FechaInicio = reservaAdmin.FechaInicio,
                    FechaFin = reservaAdmin.FechaFin,
                    IdHabitacion = await _context.Habitaciones.FindAsync(reservaAdmin.IdHabitacion),
                    ServiciosSeleccionados = await _context.Servicios
                        .Where(s => ServiciosSeleccionados.Contains(s.IdServicio))
                        .ToListAsync(),
                    IdCliente = await _context.Clientes.FindAsync(reservaAdmin.IdHuesped),
                    IdEstado = await _context.ReservaEstados.FirstOrDefaultAsync(e => e.nombre == reservaAdmin.EstadoReserva)
                };

                reserva.PrecioReserva = await CalcularPrecioReserva(reserva, ServiciosSeleccionados);

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.HabitacionesActivas = _context.Habitaciones
                .Where(h => h.EstadoHabitacion.Nombre == "Activa")
                .ToList();

            ViewBag.ServiciosActivos = _context.Servicios
                .Where(s => s.EstadoServicio == true)
                .ToList();

            ViewBag.ClientesActivos = _context.Clientes
                .Where(c => c.ClienteEstado == true)
                .ToList();

            ViewBag.HuespedesActivos = _context.Huespedes
                .Where(h => h.IdEstadoHuesped == 1) // Asumiendo que 1 es el estado activo
                .ToList();

            return View(reservaAdmin);
        }

    }
}
