using System;
using System.Collections.Generic;

namespace Data;

public partial class ArticuloTiendum
{
    public int IdArticuloTienda { get; set; }

    public int? IdArticulo { get; set; }

    public int? IdTienda { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Articulo? IdArticuloNavigation { get; set; }

    public virtual Tiendum? IdTiendaNavigation { get; set; }

    public string Sucursal { get; set; }
    public string Nombre { get; set; }
    public int Codigo { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public string Imagen { get; set; }
    public int Stock { get; set; }
}
