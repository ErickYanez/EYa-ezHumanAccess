using System;
using System.Collections.Generic;

namespace Data;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
