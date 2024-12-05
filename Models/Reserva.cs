using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caribbean2.Models
{
    public class Reserva
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReserva { get; set; }

        // Relación con Cliente
        [Required(ErrorMessage = "Debe asignar un cliente a la reserva.")]
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }

        // Relación con Huesped
        [Required(ErrorMessage = "Debe asignar un huésped a la reserva.")]
        public int IdHuesped { get; set; }
        [ForeignKey("IdHuesped")]
        public virtual Huesped Huesped { get; set; }

        // Relación con Habitación
        [Required(ErrorMessage = "Debe asignar una habitación a la reserva.")]
        public int IdHabitacion { get; set; }
        [ForeignKey("IdHabitacion")]
        public virtual Habitacion Habitacion { get; set; }

        // Relación con Servicios (muchos a muchos)
        public virtual ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
        public DateTime FechaReserva { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La fecha de inicio es obligatoria.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Reserva), nameof(ValidateFechaInicio))]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Reserva), nameof(ValidateFechaFin))]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "Debe especificar el número de personas.")]
        [Range(1, 4, ErrorMessage = "El número de personas debe estar entre 1 y 4.")]
        public int NumeroPersonas { get; set; }

        [Required(ErrorMessage = "El precio total es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio total debe ser mayor a 0.")]
        public decimal PrecioTotal { get; set; }

        [Required(ErrorMessage = "El anticipo es obligatorio.")]
        [Range(0.0, double.MaxValue, ErrorMessage = "El anticipo debe ser mayor o igual a 0.")]
        public decimal Anticipo { get; set; }
        public decimal ValorParcial => PrecioTotal - Anticipo; // Cálculo del valor pendiente

        [Required(ErrorMessage = "El estado de la reserva es obligatorio.")]
        public int IdEstado { get; set; }
        [ForeignKey("IdEstado")]
        public virtual ReservaEstado Estado { get; set; }

        [StringLength(200, ErrorMessage = "Las notas no pueden exceder los 200 caracteres.")]
        public string Notas { get; set; }

        // Validación de las fechas
        public static ValidationResult ValidateFechaInicio(DateTime fechaInicio, ValidationContext context)
        {
            if (fechaInicio.Date < DateTime.Today.AddDays(1))
            {
                return new ValidationResult("La fecha de inicio debe ser al menos un día después de la fecha actual.");
            }

            if (fechaInicio.Date > DateTime.Today.AddDays(45))
            {
                return new ValidationResult("La fecha de inicio no puede ser mayor a 45 días en el futuro.");
            }

            return ValidationResult.Success;
        }

        public static ValidationResult ValidateFechaFin(DateTime fechaFin, ValidationContext context)
        {
            var instance = (Reserva)context.ObjectInstance;
            if (fechaFin.Date <= instance.FechaInicio.Date)
            {
                return new ValidationResult("La fecha de fin debe ser posterior a la fecha de inicio.");
            }

            if ((fechaFin - instance.FechaInicio).Days > 15)
            {
                return new ValidationResult("La duración máxima de la reserva es de 15 días.");
            }

            return ValidationResult.Success;
        }

        // Relación con Pago
        public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
