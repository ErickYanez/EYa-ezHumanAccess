using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace Bussiness
{
    public class Cliente
    {
        public static Entitys.Result GetAll(Entitys.Cliente cliente)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {

                    cliente.Nombre = (cliente.Nombre == null) ? "" : cliente.Nombre;
                    cliente.ApellidoPaterno = (cliente.ApellidoPaterno == null) ? "" : cliente.ApellidoPaterno;

                    var query = context.Clientes.FromSqlRaw($"ClienteGetAll '{cliente.Nombre}','{cliente.ApellidoPaterno}'").ToList();                 

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                           Entitys.Cliente clientee = new Entitys.Cliente();

                            clientee.IdCliente = item.IdCliente;
                            clientee.Nombre = item.Nombre;
                            clientee.ApellidoPaterno = item.ApellidoPaterno;
                            clientee.ApellidoMaterno = item.ApellidoMaterno;

                            clientee.DireccionCliente = new Entitys.DireccionCliente();
                            clientee.DireccionCliente.IdDireccionCliente = item.IdDireccionCliente;
                            clientee.DireccionCliente.Calle = item.Calle;
                            clientee.DireccionCliente.NumeroInterior = item.NumeroInterior;
                            clientee.DireccionCliente.NumeroExterior = item.NumeroExterior;

                            clientee.DireccionCliente.Colonia = new Entitys.Colonia();
                            clientee.DireccionCliente.Colonia.IdColonia = item.IdColonia;
                            clientee.DireccionCliente.Colonia.Nombre = item.NombreColonia;
                            clientee.DireccionCliente.Colonia.CodigoPostal = item.CodigoPostal;

                            clientee.DireccionCliente.Colonia.Municipio = new Entitys.Municipio();
                            clientee.DireccionCliente.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                            clientee.DireccionCliente.Colonia.Municipio.Nombre = item.NombreMunicipio;

                            clientee.DireccionCliente.Colonia.Municipio.Estado = new Entitys.Estado();
                            clientee.DireccionCliente.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                            clientee.DireccionCliente.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                            clientee.DireccionCliente.Colonia.Municipio.Estado.Pais = new Entitys.Pais();
                            clientee.DireccionCliente.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                            clientee.DireccionCliente.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;

                            clientee.Usuario = new Entitys.Usuario();
                            clientee.Usuario.Imagen = item.Imagen;
                            clientee.Usuario.Email = item.Email;
                            clientee.Usuario.Password = item.Password;

                            clientee.Usuario.Rol = new Entitys.Rol();
                            clientee.Usuario.Rol.IdRol = item.IdRol;
                            clientee.Usuario.Rol.Nombre = item.NombreRol;

                            result.Objects.Add(clientee);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de clientes" + result.Ex;
            }

            return result;
        }

        public static Entitys.Result GetById(int idCliente)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var item = context.Clientes.FromSqlRaw($"ClienteGetById '{idCliente}'").AsEnumerable().SingleOrDefault();

                    if (item != null)
                    {
                        Entitys.Cliente cliente = new Entitys.Cliente();

                        cliente.IdCliente = item.IdCliente;
                        cliente.Nombre = item.Nombre;
                        cliente.ApellidoPaterno = item.ApellidoPaterno;
                        cliente.ApellidoMaterno = item.ApellidoMaterno;

                        cliente.DireccionCliente = new Entitys.DireccionCliente();
                        cliente.DireccionCliente.IdDireccionCliente = item.IdDireccionCliente;
                        cliente.DireccionCliente.Calle = item.Calle;
                        cliente.DireccionCliente.NumeroInterior = item.NumeroInterior;
                        cliente.DireccionCliente.NumeroExterior = item.NumeroExterior;

                        cliente.DireccionCliente.Colonia = new Entitys.Colonia();
                        cliente.DireccionCliente.Colonia.IdColonia = item.IdColonia;
                        cliente.DireccionCliente.Colonia.Nombre = item.NombreColonia;
                        cliente.DireccionCliente.Colonia.CodigoPostal = item.CodigoPostal;

                        cliente.DireccionCliente.Colonia.Municipio = new Entitys.Municipio();
                        cliente.DireccionCliente.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                        cliente.DireccionCliente.Colonia.Municipio.Nombre = item.NombreMunicipio;

                        cliente.DireccionCliente.Colonia.Municipio.Estado = new Entitys.Estado();
                        cliente.DireccionCliente.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                        cliente.DireccionCliente.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                        cliente.DireccionCliente.Colonia.Municipio.Estado.Pais = new Entitys.Pais();
                        cliente.DireccionCliente.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                        cliente.DireccionCliente.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;

                        cliente.Usuario = new Entitys.Usuario();
                        cliente.Usuario.Imagen = item.Imagen;
                        cliente.Usuario.Email = item.Email;
                        cliente.Usuario.Password = item.Password;

                        cliente.Usuario.Rol = new Entitys.Rol();
                        cliente.Usuario.Rol.IdRol = item.IdRol;
                        cliente.Usuario.Rol.Nombre = item.NombreRol;

                        result.Object = cliente;
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar el cliente" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Add(Entitys.Cliente cliente)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ClienteAdd '{cliente.Nombre}','{cliente.ApellidoPaterno}', '{cliente.ApellidoMaterno}', '{cliente.DireccionCliente.Calle}', '{cliente.DireccionCliente.NumeroInterior}', '{cliente.DireccionCliente.NumeroExterior}', '{cliente.DireccionCliente.Colonia.IdColonia}','{cliente.Usuario.Imagen}','{cliente.Usuario.Email}','{cliente.Usuario.Password}'");

                    if (query > 0)
                    {
                        result.Message = "Se inserto el cliente correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el cliente" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Update(Entitys.Cliente cliente)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ClienteUpdate '{cliente.IdCliente}','{cliente.Nombre}','{cliente.ApellidoPaterno}', '{cliente.ApellidoMaterno}', '{cliente.DireccionCliente.Calle}', '{cliente.DireccionCliente.NumeroInterior}', '{cliente.DireccionCliente.NumeroExterior}', '{cliente.DireccionCliente.Colonia.IdColonia}','{cliente.Usuario.Imagen}','{cliente.Usuario.Email}','{cliente.Usuario.Password}'");

                    if (query > 0)
                    {
                        result.Message = "Se actualizo el cliente correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el cliente" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Delete(int idCliente)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ClienteDelete '{idCliente}'");

                    if (query > 0)
                    {
                        result.Message = "Se elimino el cliente correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el cliente" + result.Ex;
            }
            return result;
        }
    }
}