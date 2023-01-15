using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Tienda
    {
        public static Entitys.Result GetAll(Entitys.Tienda tienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    tienda.Sucursal = (tienda.Sucursal == null) ? "" : tienda.Sucursal;

                    var query = context.Tienda.FromSqlRaw($"TiendaGetAll '{tienda.Sucursal}'").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Entitys.Tienda tiendaa = new Entitys.Tienda();

                            tiendaa.IdTienda = item.IdTienda;
                            tiendaa.Sucursal = item.Sucursal;

                            tiendaa.DireccionTienda = new Entitys.DireccionTienda();
                            tiendaa.DireccionTienda.IdDireccionTienda = item.IdDireccionTienda;
                            tiendaa.DireccionTienda.Calle = item.Calle;
                            tiendaa.DireccionTienda.NumeroInterior = item.NumeroInterior;
                            tiendaa.DireccionTienda.NumeroExterior = item.NumeroExterior;

                            tiendaa.DireccionTienda.Colonia = new Entitys.Colonia();
                            tiendaa.DireccionTienda.Colonia.IdColonia = item.IdColonia;
                            tiendaa.DireccionTienda.Colonia.Nombre = item.NombreColonia;
                            tiendaa.DireccionTienda.Colonia.CodigoPostal = item.CodigoPostal;

                            tiendaa.DireccionTienda.Colonia.Municipio = new Entitys.Municipio();
                            tiendaa.DireccionTienda.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                            tiendaa.DireccionTienda.Colonia.Municipio.Nombre = item.NombreMunicipio;

                            tiendaa.DireccionTienda.Colonia.Municipio.Estado = new Entitys.Estado();
                            tiendaa.DireccionTienda.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                            tiendaa.DireccionTienda.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                            tiendaa.DireccionTienda.Colonia.Municipio.Estado.Pais = new Entitys.Pais();
                            tiendaa.DireccionTienda.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                            tiendaa.DireccionTienda.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;

                            result.Objects.Add(tiendaa);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de tiendas" + result.Ex;
            }

            return result;
        }

        public static Entitys.Result GetById(int idTienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var item = context.Tienda.FromSqlRaw($"TiendaGetById '{idTienda}'").AsEnumerable().SingleOrDefault();

                    if (item != null)
                    {
                        Entitys.Tienda tienda = new Entitys.Tienda();

                        tienda.IdTienda = item.IdTienda;
                        tienda.Sucursal = item.Sucursal;

                        tienda.DireccionTienda = new Entitys.DireccionTienda();
                        tienda.DireccionTienda.IdDireccionTienda = item.IdDireccionTienda;
                        tienda.DireccionTienda.Calle = item.Calle;
                        tienda.DireccionTienda.NumeroInterior = item.NumeroInterior;
                        tienda.DireccionTienda.NumeroExterior = item.NumeroExterior;

                        tienda.DireccionTienda.Colonia = new Entitys.Colonia();
                        tienda.DireccionTienda.Colonia.IdColonia = item.IdColonia;
                        tienda.DireccionTienda.Colonia.Nombre = item.NombreColonia;
                        tienda.DireccionTienda.Colonia.CodigoPostal = item.CodigoPostal;

                        tienda.DireccionTienda.Colonia.Municipio = new Entitys.Municipio();
                        tienda.DireccionTienda.Colonia.Municipio.IdMunicipio = item.IdMunicipio;
                        tienda.DireccionTienda.Colonia.Municipio.Nombre = item.NombreMunicipio;

                        tienda.DireccionTienda.Colonia.Municipio.Estado = new Entitys.Estado();
                        tienda.DireccionTienda.Colonia.Municipio.Estado.IdEstado = item.IdEstado;
                        tienda.DireccionTienda.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                        tienda.DireccionTienda.Colonia.Municipio.Estado.Pais = new Entitys.Pais();
                        tienda.DireccionTienda.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais;
                        tienda.DireccionTienda.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;

                        result.Object = tienda;
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la tienda" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Add(Entitys.Tienda tienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"TiendaAdd '{tienda.Sucursal}', '{tienda.DireccionTienda.Calle}', '{tienda.DireccionTienda.NumeroInterior}', '{tienda.DireccionTienda.NumeroExterior}', '{tienda.DireccionTienda.Colonia.IdColonia}'");

                    if (query > 0)
                    {
                        result.Message = "Se inserto la tienda correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar la tienda" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Update(Entitys.Tienda tienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"TiendaUpdate '{tienda.IdTienda}','{tienda.Sucursal}', '{tienda.DireccionTienda.Calle}', '{tienda.DireccionTienda.NumeroInterior}', '{tienda.DireccionTienda.NumeroExterior}', '{tienda.DireccionTienda.Colonia.IdColonia}'");

                    if (query > 0)
                    {
                        result.Message = "Se actualizo la tienda correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar la tienda" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Delete(int idTienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"TiendaDelete '{idTienda}'");

                    if (query > 0)
                    {
                        result.Message = "Se elimino la tienda correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la tienda" + result.Ex;
            }
            return result;
        }
    }
}
