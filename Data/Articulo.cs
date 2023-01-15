using System;
using System.Collections.Generic;

namespace Data;

public partial class Articulo
{
    public int IdArticulo { get; set; }

    public int? Codigo { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Precio { get; set; }

    public string? Imagen { get; set; }

    public int? Stock { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; } = new List<ArticuloTiendum>();

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; } = new List<ClienteArticulo>();
}
