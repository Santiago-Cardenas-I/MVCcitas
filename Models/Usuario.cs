using System;
using System.Collections.Generic;

namespace MVCcitas.Models;

public partial class Usuario
{
    public int IdIdentificacion { get; set; }

    public string? Apellido { get; set; }

    public string? Nombres { get; set; }

    public string? Direccion { get; set; }

    public string? Celular { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
