using System;
using System.Collections.Generic;

namespace Data;

public partial class Pai
{
    public int IdPais { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Estado> Estados { get; } = new List<Estado>();
}
