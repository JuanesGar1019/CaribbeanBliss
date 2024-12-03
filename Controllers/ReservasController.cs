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

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var caribbeanContext = _context.Reservas.Include(r => r.Cliente).Include(r => r.Estado).Include(r => r.Habitacion).Include(r => r.Huesped);
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
                .Include(r => r.Estado)
                .Include(r => r.Habitacion)
                .Include(r => r.Huesped)
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "idCliente", "nombre");
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre");
            ViewData["IdHabitacion"] = _context.Habitaciones.Select(h => new SelectListItem
            {
                Value = h.IdHabitacion.ToString(),
                Text = $"{h.Nombre} - {h.PrecioHabitacion:C}"
            }).ToList();
            ViewData["IdHuesped"] = new SelectList(_context.Huespedes, "Id", "NombreCompleto");
            ViewData["ServiciosActivos"] = _context.Servicios.Where(s => s.EstadoServicio == true).ToList();
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,IdCliente,IdHuesped,IdHabitacion,FechaInicio,FechaFin,NumeroPersonas,PrecioTotal,Anticipo,Notas")] Reserva reserva, int[] ServiciosSeleccionados)
        {
            if (ModelState.IsValid)
            {
                // Asignar IdEstado a 1 por defecto
                reserva.IdEstado = 1;

                reserva.Servicios = await _context.Servicios.Where(s => ServiciosSeleccionados.Contains(s.IdServicio)).ToListAsync();
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "idCliente", "nombre", reserva.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", reserva.IdHabitacion);
            ViewData["IdHuesped"] = new SelectList(_context.Huespedes, "Id", "CorreoElectronico", reserva.IdHuesped);
            ViewData["ServiciosActivos"] = _context.Servicios.Where(s => s.EstadoServicio == true).ToList();
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
                .Include(r => r.Servicios)
                .FirstOrDefaultAsync(m => m.IdReserva == id);
            if (reserva == null)
            {
                return NotFound();
            }

            ViewData["IdCliente"] = new SelectList(_context.Clientes, "idCliente", "nombre", reserva.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            ViewData["IdHabitacion"] = _context.Habitaciones.Select(h => new SelectListItem
            {
                Value = h.IdHabitacion.ToString(),
                Text = $"{h.Nombre} - {h.PrecioHabitacion:C}"
            }).ToList();
            ViewData["IdHuesped"] = new SelectList(_context.Huespedes, "Id", "NombreCompleto", reserva.IdHuesped);
            ViewData["ServiciosActivos"] = _context.Servicios.Where(s => s.EstadoServicio == true).ToList();

            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,IdCliente,IdHuesped,IdHabitacion,FechaInicio,FechaFin,NumeroPersonas,PrecioTotal,Anticipo,IdEstado,Notas")] Reserva reserva, int[] ServiciosSeleccionados)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar los servicios seleccionados
                    var reservaExistente = await _context.Reservas
                        .Include(r => r.Servicios)
                        .FirstOrDefaultAsync(r => r.IdReserva == id);

                    if (reservaExistente != null)
                    {
                        reservaExistente.Servicios.Clear();
                        reservaExistente.Servicios = await _context.Servicios.Where(s => ServiciosSeleccionados.Contains(s.IdServicio)).ToListAsync();

                        // Actualizar los demás campos
                        reservaExistente.IdCliente = reserva.IdCliente;
                        reservaExistente.IdHuesped = reserva.IdHuesped;
                        reservaExistente.IdHabitacion = reserva.IdHabitacion;
                        reservaExistente.FechaInicio = reserva.FechaInicio;
                        reservaExistente.FechaFin = reserva.FechaFin;
                        reservaExistente.NumeroPersonas = reserva.NumeroPersonas;
                        reservaExistente.PrecioTotal = reserva.PrecioTotal;
                        reservaExistente.Anticipo = reserva.Anticipo;
                        reservaExistente.IdEstado = reserva.IdEstado;
                        reservaExistente.Notas = reserva.Notas;

                        _context.Update(reservaExistente);
                        await _context.SaveChangesAsync();
                    }
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

            ViewData["IdCliente"] = new SelectList(_context.Clientes, "idCliente", "nombre", reserva.IdCliente);
            ViewData["IdEstado"] = new SelectList(_context.ReservaEstados, "IdEstado", "Nombre", reserva.IdEstado);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "IdHabitacion", "Nombre", reserva.IdHabitacion);
            ViewData["IdHuesped"] = new SelectList(_context.Huespedes, "Id", "CorreoElectronico", reserva.IdHuesped);
            ViewData["ServiciosActivos"] = _context.Servicios.Where(s => s.EstadoServicio == true).ToList();

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
                .Include(r => r.Estado)
                .Include(r => r.Habitacion)
                .Include(r => r.Huesped)
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
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}
