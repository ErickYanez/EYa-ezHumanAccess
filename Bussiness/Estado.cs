using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Estado
    {
        public static Entitys.Result GetByIdPais(int idEstado)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var query = context.Estados.FromSqlRaw($"EstadoGetByIdPais '{idEstado}'").AsEnumerable().ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Entitys.Estado estado = new Entitys.Estado();

                            estado.IdEstado = item.IdEstado;
                            estado.Nombre = item.Nombre;

                            result.Objects.Add(estado);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar el estado" + result.Ex;
            }
            return result;
        }
    }
}
