using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitys
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public Entitys.DireccionCliente DireccionCliente { get; set; }
        public Entitys.Usuario Usuario { get; set; }
        public List<Object> Clientes { get; set; }
    }
}
