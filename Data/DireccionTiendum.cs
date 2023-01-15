using System;
using System.Collections.Generic;

namespace Data;

public partial class DireccionTiendum
{
    public int IdDireccionTienda { get; set; }

    public string? Calle { get; set; }

    public string? NumeroExterior { get; set; }

    public string? NumeroInterior { get; set; }

    public int? IdColonia { get; set; }

    public int? IdTienda { get; set; }

    public virtual Colonium? IdColoniaNavigation { get; set; }

    public virtual Tiendum? IdTiendaNavigation { get; set; }
}
