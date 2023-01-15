using System;
using System.Collections.Generic;

namespace Data;

public partial class DireccionCliente
{
    public int IdDireccionCliente { get; set; }

    public string? Calle { get; set; }

    public string? NumeroExterior { get; set; }

    public string? NumeroInterior { get; set; }

    public int? IdColonia { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Colonium? IdColoniaNavigation { get; set; }
}
