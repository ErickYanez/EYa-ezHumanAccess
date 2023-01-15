using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Imagen { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Entitys.Rol Rol { get; set; }
        public Entitys.Cliente Cliente { get; set; }
        public List<Object> Usuarios { get; set; }
    }
}
