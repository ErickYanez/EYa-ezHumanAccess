using System;
using System.Collections.Generic;

namespace Data;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; } = new List<ClienteArticulo>();

    public virtual ICollection<DireccionCliente> DireccionClientes { get; } = new List<DireccionCliente>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
    public int IdRol { get; set; }
    public string NombreRol { get; set; }
    public int IdDireccionCliente { get; set; }
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
    public string Imagen { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
