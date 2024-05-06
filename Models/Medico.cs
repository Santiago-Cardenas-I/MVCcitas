using System;
using System.Collections.Generic;

namespace MVCcitas.Models;

public partial class Medico
{
    public int IdIdentificacionMed { get; set; }

    public string? Apellido { get; set; }

    public string? Nombre { get; set; }

    public string? Especialidad { get; set; }

    public string? Celular { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
