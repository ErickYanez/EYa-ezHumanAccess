using System;
using System.Collections.Generic;

namespace Data;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Imagen { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? IdRol { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Rol? IdRolNavigation { get; set; }
}
