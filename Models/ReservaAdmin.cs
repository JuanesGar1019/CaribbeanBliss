using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace Caribbean2.Models
{
    public class ReservaAdmin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio.")]
        [StringLength(70, ErrorMessage = "El nombre del cliente no puede tener más de 70 caracteres.")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "El estado de la reserva es obligatorio.")]
        [StringLength(20, ErrorMessage = "El estado de la reserva no puede tener más de 20 caracteres.")]
        public string EstadoReserva { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un huésped.")]
        public int IdHuesped { get; set; }

        public List<Huesped> Huespeds { get; set; } = new List<Huesped>();

        [Required(ErrorMessage = "Debe seleccionar una habitación.")]
        public int IdHabitacion { get; set; }

        // Relación de navegación con Habitación
        public Habitacion Habitacion { get; set; }

        [Required(ErrorMessage = "El precio total es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio total debe ser mayor a 0.")]
        public decimal PrecioTotal { get; set; }

        [Required(ErrorMessage = "Debe especificar al menos un servicio.")]
        public List<Servicio> Servicios { get; set; } = new List<Servicio>();

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de inicio debe ser una fecha válida.")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de fin debe ser una fecha válida.")]
        public DateTime FechaFin { get; set; }
    }
}
