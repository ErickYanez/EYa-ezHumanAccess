using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Colonia
    {
        public static Entitys.Result GetByIdMunicipio(int idColonia)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var query = context.Colonia.FromSqlRaw($"ColoniaGetByIdMunicipio '{idColonia}'").AsEnumerable().ToList();

                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            Entitys.Colonia colonia = new Entitys.Colonia();

                            colonia.IdColonia = item.IdColonia;
                            colonia.Nombre = item.Nombre;

                            result.Objects.Add(colonia);
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

                throw;
            }
            return result;
        }
    }
}
