using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caribbean2.Models;

    public class Reserva

    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdReserva { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Habitacion IdHabitacion { get; set; }

        public decimal PrecioReserva { get; set; }

        public ICollection<Servicio> ServiciosSeleccionados { get; set; }

        public Cliente IdCliente { get; set; }
        public ReservaEstado IdEstado { get; set; }

    }


