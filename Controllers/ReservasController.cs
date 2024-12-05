using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Caribbean2.Models;

namespace Caribbean2.Controllers
{
    public class ReservasController : Controller
    {
        private readonly CaribbeanContext _context;

        public ReservasController(CaribbeanContext context)
        {
            _context = context;
        }

        [RoleAuthorize(2, 3, 4)]
        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var caribbeanContext = _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Include(r => r.Estado)
                .Include(r => r.Huespedes)
                .Include(r => r.Servicios)
                .Include(r => r.Pagos);
            return View(await caribbeanContext.ToListAsync());
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Include(r => r.Estado)
                .Include(r => r.Huespedes)
                .Include(r => r.Servicios)
                .Include(r => r.Pagos)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            try 
            {
                var clientes = _context.Clientes
                    .Where(c => c.ClienteEstado)
                    .ToList();
                var habitaciones = _context.Habitaciones
                    .Where(h => h.IdEstado == 1)
                    .ToList();
                var huespedes = _context.Huespedes.ToList();
                var estados = _context.ReservaEstados.ToList();
                var serviciosActivos = _context.Servicios
                    .Where(s => s.EstadoServicio)
                    .ToList();

                // Validar que existan datos
                if (!clientes.Any())
                    ModelState.AddModelError("", "No hay clientes disponibles");
                if (!habitaciones.Any())
                    ModelState.AddModelError("", "No hay habitaciones disponibles");
                if (!huespedes.Any())
                    ModelState.AddModelError("", "No hay huéspedes disponibles");
                if (!estados.Any())
                    ModelState.AddModelError("", "No hay estados disponibles");
                if (!serviciosActivos.Any())
                    ModelState.AddModelError("", "No hay servicios disponibles");

                // Corregir los nombres de las propiedades según el modelo Cliente
                ViewBag.IdCliente = new SelectList(clientes, "idCliente", "nombre");
                ViewBag.IdHabitacion = new SelectList(habitaciones.Select(h => new
                {
                    IdHabitacion = h.IdHabitacion,
                    DisplayText = $"Habitación {h.NumeroHabitacion} - {h.Nombre} - Precio: ${h.PrecioHabitacion}",
                    h.Capacidad
                }), "IdHabitacion", "DisplayText");
                ViewBag.Huespedes = new MultiSelectList(huespedes, "Id", "NombreCompleto");
                ViewBag.IdEstado = new SelectList(estados, "IdEstado", "Nombre");
                ViewBag.ServiciosActivos = serviciosActivos;

                ViewBag.HabitacionesCapacidad = habitaciones.ToDictionary(h => h.IdHabitacion, h => h.Capacidad);

                return View();
            }
            catch (Exception ex)
            {
                // Log the error
                ModelState.AddModelError("", "Ocurrió un error al cargar los datos" + ex);
                return View();
            }
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,IdCliente,IdHabitacion,FechaInicio,FechaFin,NumeroPersonas,PrecioTotal,Anticipo,Notas,IdEstado")] Reserva reserva, int[] HuespedesSeleccionados, int[] ServiciosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                // Validar capacidad de la habitación
                var habitacion = await _context.Habitaciones.FindAsync(reserva.IdHabitacion);
                if (habitacion != null && reserva.NumeroPersonas > habitacion.Capacidad)
                {
                    ModelState.AddModelError("NumeroPersonas", "El número de personas excede la capacidad de la habitación");
                    return View(reserva);
                }

                foreach (var huespedId in HuespedesSeleccionados)
                {
                    var huesped = await _context.Huespedes.FindAsync(huespedId);
                    if (huesped != null)
                    {
                        reserva.Huespedes.Add(huesped);
                    }
                }

                foreach (var servicioId in ServiciosSeleccionados)
                {
                    var servicio = await _context.Servicios.FindAsync(servicioId);
                    if (servicio != null)
                    {
                        reserva.Servicios.Add(servicio);
                    }
                }

                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCliente = new SelectList(_context.Clientes, "IdCliente", "NombreCompleto", reserva.IdCliente);
            ViewBag.IdHabitacion = new SelectList(_context.Habitaciones, "IdHabitacion", "NumeroHabitacion", reserva.IdHabitacion);
            ViewBag.Huespedes = new SelectList(_context.Huespedes, "Id", "NombreCompleto");
            ViewBag.IdEstado = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            ViewBag.ServiciosActivos = _context.Servicios.Where(s => s.EstadoServicio.Equals(true)).ToList();
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Huespedes)
                .Include(r => r.Servicios)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewBag.IdCliente = new SelectList(_context.Clientes, "IdCliente", "Nombre", reserva.IdCliente);
            ViewBag.IdHabitacion = new SelectList(_context.Habitaciones, "IdHabitacion", "NumeroHabitacion", reserva.IdHabitacion);
            ViewBag.Huespedes = new SelectList(_context.Huespedes, "Id", "NombreCompleto");
            ViewBag.IdEstado = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            ViewBag.ServiciosActivos = _context.Servicios.Where(s => s.EstadoServicio.Equals(true)).ToList();
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdCliente,IdHabitacion,FechaInicio,FechaFin,NumeroPersonas,PrecioTotal,Anticipo,Notas,IdEstado")] Reserva reserva, int[] HuespedesSeleccionados, int[] ServiciosSeleccionados)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var reservaToUpdate = await _context.Reservas
                        .Include(r => r.Huespedes)
                        .Include(r => r.Servicios)
                        .FirstOrDefaultAsync(m => m.IdReserva == id);

                    if (reservaToUpdate == null)
                    {
                        return NotFound();
                    }

                    reservaToUpdate.IdCliente = reserva.IdCliente;
                    reservaToUpdate.IdHabitacion = reserva.IdHabitacion;
                    reservaToUpdate.FechaInicio = reserva.FechaInicio;
                    reservaToUpdate.FechaFin = reserva.FechaFin;
                    reservaToUpdate.NumeroPersonas = reserva.NumeroPersonas;
                    reservaToUpdate.PrecioTotal = reserva.PrecioTotal;
                    reservaToUpdate.Anticipo = reserva.Anticipo;
                    reservaToUpdate.IdEstado = reserva.IdEstado;
                    reservaToUpdate.Notas = reserva.Notas;

                    reservaToUpdate.Huespedes.Clear();
                    foreach (var huespedId in HuespedesSeleccionados)
                    {
                        var huesped = await _context.Huespedes.FindAsync(huespedId);
                        if (huesped != null)
                        {
                            reservaToUpdate.Huespedes.Add(huesped);
                        }
                    }

                    reservaToUpdate.Servicios.Clear();
                    foreach (var servicioId in ServiciosSeleccionados)
                    {
                        var servicio = await _context.Servicios.FindAsync(servicioId);
                        if (servicio != null)
                        {
                            reservaToUpdate.Servicios.Add(servicio);
                        }
                    }

                    _context.Update(reservaToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.IdCliente = new SelectList(_context.Clientes, "IdCliente", "NombreCompleto", reserva.IdCliente);
            ViewBag.IdHabitacion = new SelectList(_context.Habitaciones, "IdHabitacion", "NumeroHabitacion", reserva.IdHabitacion);
            ViewBag.Huespedes = new SelectList(_context.Huespedes, "Id", "NombreCompleto");
            ViewBag.IdEstado = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            ViewBag.ServiciosActivos = _context.Servicios.Where(s => s.EstadoServicio.Equals(true)).ToList();
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Include(r => r.Estado)
                .Include(r => r.Huespedes)
                .Include(r => r.Servicios)
                .Include(r => r.Pagos)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}