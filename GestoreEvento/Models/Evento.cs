using System;
using System.Collections.Generic;

namespace GestoreEvento.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string NomeEvento { get; set; } = null!;

    public string? DescrizioneEvento { get; set; }

    public DateTime DataEvento { get; set; }

    public string LuogoEvento { get; set; } = null!;

    public int CapacitaMassima { get; set; }

    public DateTime? Deleted { get; set; }

    public virtual ICollection<Risorse> Risorses { get; set; } = new List<Risorse>();

    public override string ToString()
    {
        return $"{EventoId} {NomeEvento} {DescrizioneEvento} {DataEvento.ToString("d")} {LuogoEvento} {CapacitaMassima}";
    }
}
