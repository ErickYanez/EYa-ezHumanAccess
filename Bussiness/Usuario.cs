using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness
{
    public class Usuario
    {
        public static Entitys.Result Login(string email)
        {
            Entitys.Result result = new Entitys.Result();
            try
            {
                using (Data.EyañezHumanAccessContext context = new Data.EyañezHumanAccessContext())
                {
                    var item = context.Usuarios.FromSqlRaw($"LoginUser '{email}'").AsEnumerable().FirstOrDefault();

                    if (item != null)
                    {
                        Entitys.Usuario usuario = new Entitys.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.Email = item.Email;
                        usuario.Password = item.Password;

                        result.Object = usuario;
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Usuario no encontrado" + result.Ex;
            }
            return result;
        }
    }
}
