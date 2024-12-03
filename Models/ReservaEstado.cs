using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caribbean2.Models;

public partial class ReservaEstado
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idEstado { get; set; }

    public string nombre { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
