using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Articulo
    {
        public static Entitys.Result GetAll(Entitys.Articulo articulo)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    articulo.Nombre = (articulo.Nombre == null) ? "" : articulo.Nombre;

                    var query = context.Articulos.FromSqlRaw($"ArticuloGetAll '{articulo.Nombre}'").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Entitys.Articulo articuloo = new Entitys.Articulo();

                            articuloo.IdArticulo = item.IdArticulo;
                            articuloo.Nombre = item.Nombre;
                            articuloo.Codigo = item.Codigo.Value;
                            articuloo.Descripcion = item.Descripcion;
                            articuloo.Precio = item.Precio.Value;
                            articuloo.Imagen = item.Imagen;
                            articuloo.Stock = item.Stock.Value;

                            result.Objects.Add(articuloo);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de articulos" + result.Ex;
            }

            return result;
        }

        public static Entitys.Result GetById(int idArticulo)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var item = context.Articulos.FromSqlRaw($"ArticuloGetById '{idArticulo}'").AsEnumerable().SingleOrDefault();

                    if (item != null)
                    {
                        Entitys.Articulo articulo = new Entitys.Articulo();

                        articulo.IdArticulo = item.IdArticulo;
                        articulo.Nombre = item.Nombre;
                        articulo.Codigo = item.Codigo.Value;
                        articulo.Descripcion = item.Descripcion;
                        articulo.Precio = item.Precio.Value;
                        articulo.Imagen = item.Imagen;
                        articulo.Stock = item.Stock.Value;

                        result.Object = articulo;
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar el articulo" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Add(Entitys.Articulo articulo)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlInterpolated($"ArticuloAdd @Nombre={articulo.Nombre}, @Codigo={articulo.Codigo}, @Descripcion={articulo.Descripcion}, @Precio={articulo.Precio}, @Imagen={articulo.Imagen}, @Stock={articulo.Stock}");

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

        public static Entitys.Result Update(Entitys.Articulo articulo)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlInterpolated($"ArticuloUpdate @IdArticulo={articulo.IdArticulo}, @Nombre={articulo.Nombre}, @Codigo={articulo.Codigo}, @Descripcion={articulo.Descripcion}, @Precio={articulo.Precio}, @Imagen={articulo.Imagen}, @Stock={articulo.Stock}");
                    if (query > 0)
                    {
                        result.Message = "Se actualizo el articulo correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el articulo" + result.Ex;
            }
            return result;
        }

        public static Entitys.Result Delete(int idArticulo)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ArticuloDelete '{idArticulo}'");

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
