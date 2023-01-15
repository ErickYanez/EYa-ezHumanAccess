using System;
using System.Collections.Generic;

namespace Data;

public partial class Tiendum
{
    public int IdTienda { get; set; }

    public string? Sucursal { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; } = new List<ArticuloTiendum>();

    public virtual ICollection<DireccionTiendum> DireccionTienda { get; } = new List<DireccionTiendum>();
    public int IdDireccionTienda { get; set; }
    public string Calle { get; set; }
    public string NumeroInterior { get; set; }
    public string NumeroExterior { get; set; }
    public int IdColonia { get; set; }
    public string NombreColonia { get; set; }
    public string CodigoPostal { get; set; }
    public int IdMunicipio { get; set; }
    public string NombreMunicipio { get; set; }
    public int IdEstado { get; set; }
    public string NombreEstado { get; set; }
    public int IdPais { get; set; }
    public string NombrePais { get; set; }
}
