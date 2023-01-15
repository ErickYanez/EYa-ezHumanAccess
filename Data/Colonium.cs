using System;
using System.Collections.Generic;

namespace Data;

public partial class Colonium
{
    public int IdColonia { get; set; }

    public string? Nombre { get; set; }

    public string? CodigoPostal { get; set; }

    public int? IdMunicipio { get; set; }

    public virtual ICollection<DireccionCliente> DireccionClientes { get; } = new List<DireccionCliente>();

    public virtual ICollection<DireccionTiendum> DireccionTienda { get; } = new List<DireccionTiendum>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }
}
