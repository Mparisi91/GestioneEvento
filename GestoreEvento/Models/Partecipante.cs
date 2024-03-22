using System;
using System.Collections.Generic;

namespace GestoreEvento.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nominativo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? Deleted { get; set; }


}
