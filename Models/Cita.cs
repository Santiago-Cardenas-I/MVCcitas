using System;
using System.Collections.Generic;

namespace MVCcitas.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int? IdIdentificacionUs { get; set; }

    public int? IdIdentificacionMed { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? VlrCopago { get; set; }

    public string? Ips { get; set; }

    public int? NroConsultorio { get; set; }

    public virtual Medico? IdIdentificacionMedNavigation { get; set; }

    public virtual Usuario? IdIdentificacionUsNavigation { get; set; }
}
