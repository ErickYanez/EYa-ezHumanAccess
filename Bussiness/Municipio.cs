using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Municipio
    {
        public static Entitys.Result GetByIdEstado(int idMunicipio)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var query = context.Municipios.FromSqlRaw($"MunicipioGetByIdEstado '{idMunicipio}'").AsEnumerable().ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Entitys.Municipio municipio = new Entitys.Municipio();

                            municipio.IdMunicipio = item.IdMunicipio;
                            municipio.Nombre = item.Nombre;

                            result.Objects.Add(municipio);
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
