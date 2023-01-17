using Data;
using Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class ArticuloTienda
    {
        public static Entitys.Result ArticuloTiendaAsignados(int idTienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var query = context.ArticuloTienda.FromSqlRaw($"ArticulosTiendaAgregados '{idTienda}'").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Entitys.ArticuloTienda articuloTienda = new Entitys.ArticuloTienda();

                            articuloTienda.IdArticuloTienda = articuloTienda.IdArticuloTienda;

                            articuloTienda.Tienda = new Entitys.Tienda();
                            articuloTienda.Tienda.IdTienda = item.IdTienda.Value;
                            articuloTienda.Tienda.Sucursal = item.Sucursal;

                            articuloTienda.Articulo = new Entitys.Articulo();
                            articuloTienda.Articulo.IdArticulo = item.IdArticulo.Value;
                            articuloTienda.Articulo.Nombre = item.Nombre;
                            articuloTienda.Articulo.Codigo = item.Codigo;
                            articuloTienda.Articulo.Descripcion = item.Descripcion;
                            articuloTienda.Articulo.Precio = item.Precio;
                            articuloTienda.Articulo.Imagen = item.Imagen;
                            articuloTienda.Articulo.Stock = item.Stock;

                            result.Objects.Add(articuloTienda);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los articulos" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result ArticuloTiendaNoAsignados(int idTienda)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var query = context.Articulos.FromSqlRaw($"ArticulosTiendaNoAgregados '{idTienda}'").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var item in query)
                        {
                            Entitys.ArticuloTienda articuloTienda = new Entitys.ArticuloTienda();

                            articuloTienda.IdArticuloTienda = articuloTienda.IdArticuloTienda;

                            articuloTienda.Tienda = new Entitys.Tienda();
                            articuloTienda.Tienda.IdTienda = item.IdTienda;
                            articuloTienda.Tienda.Sucursal = item.Sucursal;

                            articuloTienda.Articulo = new Entitys.Articulo();
                            articuloTienda.Articulo.IdArticulo = item.IdArticulo;
                            articuloTienda.Articulo.Nombre = item.Nombre;
                            articuloTienda.Articulo.Codigo = item.Codigo.Value;
                            articuloTienda.Articulo.Descripcion = item.Descripcion;
                            articuloTienda.Articulo.Precio = item.Precio.Value;
                            articuloTienda.Articulo.Imagen = item.Imagen;
                            articuloTienda.Articulo.Stock = item.Stock.Value;

                            result.Objects.Add(articuloTienda);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar los articulos" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Add(int idTienda, int idArticulo)
        {
            Entitys.Result result = new Entitys.Result();

            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ArticuloTiendaAdd '{idTienda}','{idArticulo}'");

                    if (query > 0)
                    {
                        result.Message = "Se inserto el articulo correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el articulo" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Delete(int idTienda, int idArticulo)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ArticuloTiendaDelete '{idTienda}','{idArticulo}'");

                    if (query > 0)
                    {
                        result.Message = "Se elimino el articulo correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el articulo" + result.Ex;
            }
            return result;
        }

    }
}
